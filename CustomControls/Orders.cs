using Microsoft.VisualBasic;
using Npgsql;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NodaTime.Text;
using NPOI.XWPF.UserModel;

namespace BookDealer.CustomControls
{
    public partial class Orders : UserControl
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        public Orders()
        {
            InitializeComponent();
        }

        private void FromOrdersButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            GoodsControl goodsControl = parentForm.Controls.Find("goodsControl1", true).FirstOrDefault() as GoodsControl;
            goodsControl.Visible = true;
        }

        public void LoadData()
        {
            try
            {
                string query = "SELECT o.orderid, o.date, o.count, o.sum, s.information AS salescontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM orders AS o " +
               "JOIN salescontracts AS s ON o.contractid = s.contractid " +
               "JOIN books AS b ON o.bookid = b.bookid";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Setsdb.DataSource = bindingSource;
                Setsdb.Sort(Setsdb.Columns["orderid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void OpenCustomControl(int orderId)
        {
            try
            {
                string query = "SELECT o.orderid, o.date, o.count, o.sum, s.information AS salescontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM orders AS o " +
               "JOIN salescontracts AS s ON o.contractid = s.contractid " +
               "JOIN books AS b ON o.bookid = b.bookid " +
               "WHERE o.orderid = @orderid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderid", orderId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "orders");

                if (dataSet.Tables["orders"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataOrders = new EditDataOrders();
                    editDataOrders.OrderName = orderId;
                    string dateString = dataSet.Tables["orders"].Rows[0]["date"].ToString();
                    DateTime databaseDateTime = DateTime.Parse(dateString);
                    DateTime databaseDateOnly = databaseDateTime.Date;

                    LocalDate parsedDate = LocalDate.FromDateTime(databaseDateOnly);
                    editDataOrders.Date = parsedDate.ToDateTimeUnspecified();
                    editDataOrders.Count = decimal.Parse(dataSet.Tables["orders"].Rows[0]["count"].ToString());
                    editDataOrders.Sum = decimal.Parse(dataSet.Tables["orders"].Rows[0]["sum"].ToString());
                    editDataOrders.Contract = dataSet.Tables["orders"].Rows[0]["salescontract"].ToString();
                    editDataOrders.BookName = dataSet.Tables["orders"].Rows[0]["book"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataOrders.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получить обновленную дату из формы EditDataOrders
                        DateTime updatedDateTime = editDataOrders.Date;

                        // Преобразовать дату в тип LocalDate
                        LocalDate updatedDate = LocalDate.FromDateTime(updatedDateTime);
                        decimal updatedCount = editDataOrders.Count;
                        decimal updatedSum = editDataOrders.Sum;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE orders SET date = @date, count = @count, sum = @sum WHERE orderid = @orderid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@date", updatedDate.ToDateTimeUnspecified());
                        updateCommand.Parameters.AddWithValue("@count", updatedCount);
                        updateCommand.Parameters.AddWithValue("@sum", updatedSum);
                        updateCommand.Parameters.AddWithValue("@orderid", orderId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["orders"].Rows[0];
                        updatedRow["date"] = updatedDate.ToDateTimeUnspecified();
                        updatedRow["count"] = updatedCount;
                        updatedRow["sum"] = updatedSum;

                        int rowIndex = Setsdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Setsdb.Rows[rowIndex];
                        dataGridViewRow.Cells["date"].Value = updatedDate.ToDateTimeUnspecified();
                        dataGridViewRow.Cells["count"].Value = updatedCount;
                        dataGridViewRow.Cells["sum"].Value = updatedSum;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Setsdb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Книга с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setsdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Setsdb.Columns["Edit"].Index)
                {
                    int orderId = (int)Setsdb.Rows[e.RowIndex].Cells["orderid"].Value;
                    OpenCustomControl(orderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenerateWordDocument(DataGridView dataGridView)
        {
            // Создание нового документа Word
            XWPFDocument document = new XWPFDocument();

            // Создание таблицы в документе
            XWPFTable table = document.CreateTable(dataGridView.Rows.Count, dataGridView.Columns.Count - 1);

            // Заполнение заголовков таблицы
            XWPFTableRow headerRow = table.GetRow(0);
            for (int i = 0; i < dataGridView.Columns.Count - 1; i++)
            {
                string headerText = dataGridView.Columns[i].HeaderText;
                headerRow.GetCell(i).SetText(headerText);
            }

            // Заполнение таблицы данными из DataGridView
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                XWPFTableRow row = table.GetRow(i + 1);
                for (int j = 0; j < dataGridView.Columns.Count - 1; j++)
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

        private void SaveOrdersDB_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Setsdb);
        }
        public void RefreshDataGridView()
        {
            string query = "SELECT o.orderid, o.date, o.count, o.sum, s.information AS salescontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM orders AS o " +
               "JOIN salescontracts AS s ON o.contractid = s.contractid " +
               "JOIN books AS b ON o.bookid = b.bookid";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "orders");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Setsdb.DataSource = dataSet.Tables["orders"];
        }

        private void OpenAddDataOrders()
        {
            var addDataOrders = new AddDataOrders();
            addDataOrders.DataAdded += AddDataForm_DataAdded;
            addDataOrders.ShowDialog();
        }
        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }


        private void AddOrdersDB_Click(object sender, EventArgs e)
        {
            OpenAddDataOrders();
            Setsdb.Sort(Setsdb.Columns["orderid"], ListSortDirection.Ascending);
        }
    }
}
