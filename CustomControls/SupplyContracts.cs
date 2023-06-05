using Microsoft.VisualBasic;
using NodaTime;
using Npgsql;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class SupplyContracts : UserControl
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "supplycontracts";
        private string tableid = "contractid";

        public SupplyContracts()
        {
            InitializeComponent();
            this.VisibleChanged += SupplyContracts_VisibleChanged;
        }

        private void FromSupplyButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            ContractsControl contractsControl = parentForm.Controls.Find("contractsControl1", true).FirstOrDefault() as ContractsControl;
            contractsControl.Visible = true;
        }

        public void LoadData()
        {
            try
            {
                string query = "SELECT s." + tableid + ", s.information, s.date, i.sum AS total, sp.name AS supplier, i.number AS invoicenumber, i.payment AS paid, i.shipment AS dispatched, " +
               "'Редактировать' AS Edit " +
               "FROM supplycontracts AS s " +
               "JOIN supplyinvoices AS i ON i.contractid = s.contractid " +
               "JOIN providers AS sp ON s.providerid = sp.providerid";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                foreach (DataRow row in dataSet.Tables["Result"].Rows)
                {
                    int contractId = Convert.ToInt32(row["contractid"]);
                    decimal totalSum = CalculateTotalSum(contractId);
                    row["total"] = totalSum;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Suppludb.DataSource = bindingSource;
                Suppludb.Columns[tableid].Visible = false;
                Suppludb.Sort(Suppludb.Columns[tableid], ListSortDirection.Ascending);

                Suppludb.Columns["information"].HeaderText = "Информация";
                Suppludb.Columns["date"].HeaderText = "Дата";
                Suppludb.Columns["total"].HeaderText = "Итог.сумма";
                Suppludb.Columns["supplier"].HeaderText = "Поставщик";
                Suppludb.Columns["invoicenumber"].HeaderText = "Номер счета";
                Suppludb.Columns["paid"].HeaderText = "Оплачено";
                Suppludb.Columns["dispatched"].HeaderText = "Отгружено";
                Suppludb.Columns["Edit"].HeaderText = "Редактировать";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateTotalSum(int contractId)
        {
            string sumQuery = "SELECT SUM(sum) FROM setsofbooks WHERE contractid = @contractid";
            using (NpgsqlCommand sumCommand = new NpgsqlCommand(sumQuery, connection))
            {
                sumCommand.Parameters.AddWithValue("@contractid", contractId);
                object result = sumCommand.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToDecimal(result);
                }
                else
                {
                    return 0;
                }
            }
        }

        private void SupplyContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void OpenCustomControl(int editrowId)
        {
            try
            {
                string query = "SELECT s.contractid , s.information, s.date, i.sum AS total, sp.name AS supplier, i.number AS invoicenumber, i.payment AS paid, i.shipment AS dispatched, " +
               "'Редактировать' AS Edit " +
               "FROM supplycontracts AS s " +
               "JOIN supplyinvoices AS i ON i.contractid = s.contractid " +
               "JOIN providers AS sp ON s.providerid = sp.providerid " +
                "WHERE  s.contractid = @contractid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@" + tableid, editrowId);

                Suppludb.Columns[tableid].Visible = false;

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, table);

                if (dataSet.Tables[table].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editform = new EditDataSupplyContracts();

                    string dateString = dataSet.Tables[table].Rows[0]["date"].ToString();
                    DateTime databaseDateTime = DateTime.Parse(dateString);
                    DateTime databaseDateOnly = databaseDateTime.Date;

                    LocalDate parsedDate = LocalDate.FromDateTime(databaseDateOnly);
                    editform.Description = dataSet.Tables[table].Rows[0]["information"].ToString();
                    editform.Date = parsedDate.ToDateTimeUnspecified();
                    editform.Sum = decimal.Parse(dataSet.Tables[table].Rows[0]["total"].ToString());
                    editform.Supplier = dataSet.Tables[table].Rows[0]["supplier"].ToString();
                    editform.Invoiceid = dataSet.Tables[table].Rows[0]["invoicenumber"].ToString();
                    editform.Payment = (bool)dataSet.Tables[table].Rows[0]["paid"];
                    editform.Dispatch = (bool)dataSet.Tables[table].Rows[0]["dispatched"];
                    DialogResult result = editform.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        DateTime updatedDateTime = editform.Date;

                        LocalDate updatedDate = LocalDate.FromDateTime(updatedDateTime);
                        string updateddescripton = editform.Description;
                        bool updatedpaid = editform.Payment;
                        bool updateddispatched = editform.Dispatch;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE supplycontracts SET date = @date, information = @information WHERE " + tableid + " = @" + tableid;
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@date", updatedDate.ToDateTimeUnspecified());
                        updateCommand.Parameters.AddWithValue("@information", updateddescripton);
                        updateCommand.Parameters.AddWithValue("@" + tableid, editrowId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables[table].Rows[0];
                        updatedRow["date"] = updatedDate.ToDateTimeUnspecified();
                        updatedRow["information"] = updateddescripton;

                        string updateQueryinvoice = "UPDATE supplyinvoices SET payment = @payment, shipment = @shipment WHERE " + tableid + " = @" + tableid;
                        NpgsqlCommand updateCommandinvoice = new NpgsqlCommand(updateQueryinvoice, connection);
                        updateCommandinvoice.Parameters.AddWithValue("@payment", updatedpaid);
                        updateCommandinvoice.Parameters.AddWithValue("@shipment", updateddispatched);
                        updateCommandinvoice.Parameters.AddWithValue("@" + tableid, editrowId);
                        updateCommandinvoice.ExecuteNonQuery();

                        int rowIndex = Suppludb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Suppludb.Rows[rowIndex];
                        dataGridViewRow.Cells["date"].Value = updatedDate.ToDateTimeUnspecified();
                        dataGridViewRow.Cells["information"].Value = updateddescripton;
                        dataGridViewRow.Cells["paid"].Value = updatedpaid;
                        dataGridViewRow.Cells["dispatched"].Value = updateddispatched;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Suppludb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Заказ с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RefreshDataGridView()
        {
            string query = "SELECT s.contractid , s.information, s.date, i.sum AS total, sp.name AS supplier, i.number AS invoicenumber, i.payment AS paid, i.shipment AS dispatched, " +
              "'Редактировать' AS Edit " +
              "FROM supplycontracts AS s " +
              "JOIN supplyinvoices AS i ON i.contractid = s.contractid " +
              "JOIN providers AS sp ON s.providerid = sp.providerid";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "supplycontracts");

            foreach (DataRow row in dataSet.Tables["supplycontracts"].Rows)
            {
                int contractId = Convert.ToInt32(row["contractid"]);
                decimal totalSum = CalculateTotalSum(contractId);
                row["total"] = totalSum;
            }

            Suppludb.DataSource = dataSet.Tables["supplycontracts"];
            Suppludb.Columns["contractid"].Visible = false;
        }

        public void GenerateWordDocument(DataGridView dataGridView)
        {
            // Создание нового документа Word
            XWPFDocument document = new XWPFDocument();

            // Создание таблицы в документе
            XWPFTable table = document.CreateTable(dataGridView.Rows.Count, dataGridView.Columns.Count - 1);

            // Заполнение заголовков таблицы
            XWPFTableRow headerRow = table.GetRow(0);
            for (int i = 1; i < dataGridView.Columns.Count - 1; i++)
            {
                string headerText = dataGridView.Columns[i].HeaderText;
                headerRow.GetCell(i).SetText(headerText);
            }

            // Заполнение таблицы данными из DataGridView
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                XWPFTableRow row = table.GetRow(i + 1);
                for (int j = 1; j < dataGridView.Columns.Count - 1; j++)
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

        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }


        private void Suppludb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Suppludb.Columns["Edit"].Index)
                {
                    int convar = (int)Suppludb.Rows[e.RowIndex].Cells[tableid].Value;
                    OpenCustomControl(convar);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveSupplyDB_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Suppludb);
        }

        private void OpenAddDataForm()
        {
            var addDataForm = new AddDataSupplyContracts();
            addDataForm.DataAdded += AddDataForm_DataAdded;
            addDataForm.ShowDialog();
        }

        private void UpdateSupplyDB_Click(object sender, EventArgs e)
        {
            OpenAddDataForm();
            Suppludb.Sort(Suppludb.Columns[tableid], ListSortDirection.Ascending);
        }

        private void SupplyContracts_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshDataGridView();
            }
        }
    }
}
