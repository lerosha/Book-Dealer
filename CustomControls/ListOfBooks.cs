using Npgsql;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class ListOfBooks : UserControl
    {
        private NpgsqlConnection connection = null;
        private NpgsqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        public ListOfBooks()
        {
            InitializeComponent();
            this.VisibleChanged += tableLayoutPanel2_VisibleChanged;
        }

        private void FromListsBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            GoodsControl goodsControl = parentForm.Controls.Find("goodsControl1", true).FirstOrDefault() as GoodsControl;
            goodsControl.Visible = true;
        }

        public void LoadDataSale(NpgsqlConnection connection)
        {
            try
            {
                string selectedOption = comboBox1.SelectedItem.ToString();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Количество");
                dataTable.Columns.Add("Книга");
                dataTable.Columns.Add("Издательство");
                dataTable.Columns.Add("Поставщик");
                dataTable.Columns.Add("Дог.Продажа");

                string ordersTable = (selectedOption == "Проданные товары") ? "orders" : "setsofbooks";
                string instrumentsTable = "books";
                string contractsTable = (selectedOption == "Проданные товары") ? "salescontracts" : "supplycontracts";
                string invoicesTable = (selectedOption == "Проданные товары") ? "salesinvoices" : "supplyinvoices";
                string contractIdColumn = (selectedOption == "Проданные товары") ? "contractid" : "contractid";

                // Get the invoice records that have payment and dispatch both set to true
                string invoicesQuery = $"SELECT * FROM {invoicesTable} WHERE payment = true AND shipment = true";
                using (NpgsqlCommand invoicesCommand = new NpgsqlCommand(invoicesQuery, connection))
                {
                    NpgsqlDataAdapter invoicesAdapter = new NpgsqlDataAdapter(invoicesCommand);
                    DataTable invoicesDataTable = new DataTable();
                    invoicesAdapter.Fill(invoicesDataTable);

                    foreach (DataRow invoiceRow in invoicesDataTable.Rows)
                    {
                        int contractId = Convert.ToInt32(invoiceRow[contractIdColumn]);

                        // Get the order records for the current contract ID
                        string ordersQuery = $"SELECT * FROM {ordersTable} WHERE {contractIdColumn} = {contractId}";
                        using (NpgsqlCommand ordersCommand = new NpgsqlCommand(ordersQuery, connection))
                        {
                            NpgsqlDataAdapter ordersAdapter = new NpgsqlDataAdapter(ordersCommand);
                            DataTable ordersDataTable = new DataTable();
                            ordersAdapter.Fill(ordersDataTable);

                            foreach (DataRow orderRow in ordersDataTable.Rows)
                            {
                                int amount = Convert.ToInt32(orderRow["count"]);
                                int instrumentId = Convert.ToInt32(orderRow["bookid"]);

                                // Get the instrument record for the current instrument ID
                                string instrumentsQuery = $"SELECT * FROM {instrumentsTable} WHERE bookid = {instrumentId}";
                                using (NpgsqlCommand instrumentsCommand = new NpgsqlCommand(instrumentsQuery, connection))
                                {
                                    NpgsqlDataAdapter instrumentsAdapter = new NpgsqlDataAdapter(instrumentsCommand);
                                    DataTable instrumentsDataTable = new DataTable();
                                    instrumentsAdapter.Fill(instrumentsDataTable);

                                    if (instrumentsDataTable.Rows.Count > 0)
                                    {
                                        DataRow instrumentRow = instrumentsDataTable.Rows[0];
                                        string instrumentName = instrumentRow["name"].ToString();

                                        int manufacturerId = Convert.ToInt32(instrumentRow["publisherid"]);
                                        string manufacturer = GetManufacturerNameById(manufacturerId, connection);

                                        int supplierId = Convert.ToInt32(instrumentRow["providerid"]);
                                        string supplier = GetSupplierNameById(supplierId, connection);

                                        // Get the contract record for the current contract ID
                                        string contractsQuery = $"SELECT * FROM {contractsTable} WHERE {contractIdColumn} = {contractId}";
                                        using (NpgsqlCommand contractsCommand = new NpgsqlCommand(contractsQuery, connection))
                                        {
                                            NpgsqlDataAdapter contractsAdapter = new NpgsqlDataAdapter(contractsCommand);
                                            DataTable contractsDataTable = new DataTable();
                                            contractsAdapter.Fill(contractsDataTable);

                                            DataRow contractRow = contractsDataTable.Rows[0];
                                            string saleContract = contractRow["information"].ToString();

                                            dataTable.Rows.Add(amount, instrumentName, manufacturer, supplier, saleContract);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Bind the dataTable as the data source for the ClientsGridView
                Listsdb.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in LoadDataSale!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetManufacturerNameById(int manufacturerId, NpgsqlConnection connection)
        {
            string name = string.Empty;

            try
            {
                string query = "SELECT name FROM publishers WHERE publisherid = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", manufacturerId);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        name = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in GetManufacturerNameById!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return name;
        }

        public string GetSupplierNameById(int supplierId, NpgsqlConnection connection)
        {
            string name = string.Empty;

            try
            {
                string query = "SELECT name FROM providers WHERE providerid = @id";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", supplierId);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        name = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in GetSupplierNameById!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Listsdb);
        }

        public void GenerateWordDocument(DataGridView dataGridView)
        {
            // Создание нового документа Word
            XWPFDocument document = new XWPFDocument();

            // Создание таблицы в документе
            XWPFTable table = document.CreateTable(dataGridView.Rows.Count + 1, dataGridView.Columns.Count);

            // Заполнение заголовков таблицы
            XWPFTableRow headerRow = table.GetRow(0);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                string headerText = dataGridView.Columns[i].HeaderText;
                headerRow.GetCell(i).SetText(headerText);
            }

            // Заполнение таблицы данными из DataGridView
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                XWPFTableRow row = table.GetRow(i + 1);
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    string cellValue = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                    row.GetCell(j).SetText(cellValue);
                }
            }

            // Отображение диалогового окна выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохранение документа в выбранный путь
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    document.Write(fileStream);
                }
            }
        }

        private void tableLayoutPanel2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                // The control is now visible, so refresh the DataGridView
                RefreshDataGridView();
            }
        }

        private void ListOfBooks_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadDataSale(connection);
        }

        public void RefreshDataGridView()
        {
            Listsdb.DataSource = null; // Clear the current data source
            Listsdb.Rows.Clear(); // Clear the rows

            LoadDataSale(connection);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
