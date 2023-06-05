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
    public partial class SetsOfBooks : UserControl
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        public SetsOfBooks()
        {
            InitializeComponent();
        }

        private void FromSetsButton_Click(object sender, EventArgs e)
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
                string query = "SELECT s.setid, s.count, s.sum, sc.information AS supplycontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM setsofbooks AS s " +
               "JOIN supplycontracts AS sc ON s.contractid = sc.contractid " +
               "JOIN books AS b ON s.bookid = b.bookid";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Setsdb.DataSource = bindingSource;
                Setsdb.Sort(Setsdb.Columns["setid"], ListSortDirection.Ascending);

                Setsdb.Columns["setid"].HeaderText = "Номер заказа";
                Setsdb.Columns["count"].HeaderText = "Количество";
                Setsdb.Columns["sum"].HeaderText = "Сумма";
                Setsdb.Columns["supplycontract"].HeaderText = "Договор";
                Setsdb.Columns["book"].HeaderText = "Книга";
                Setsdb.Columns["Edit"].HeaderText = "Редактировать";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SetsOfBooks_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void OpenCustomControl(int setId)
        {
            try
            {
                string query = "SELECT s.setid, s.count, s.sum, sc.information AS supplycontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM setsofbooks AS s " +
               "JOIN supplycontracts AS sc ON s.contractid = sc.contractid " +
               "JOIN books AS b ON s.bookid = b.bookid " +
               "WHERE s.setid = @setid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@setid", setId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "setsofbooks");

                if (dataSet.Tables["setsofbooks"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataSoB = new EditDataSoB();
                    editDataSoB.orderId = int.Parse(dataSet.Tables["setsofbooks"].Rows[0]["setid"].ToString());
                    editDataSoB.count = decimal.Parse(dataSet.Tables["setsofbooks"].Rows[0]["count"].ToString());
                    editDataSoB.sum = decimal.Parse(dataSet.Tables["setsofbooks"].Rows[0]["sum"].ToString());
                    editDataSoB.saleCon = dataSet.Tables["setsofbooks"].Rows[0]["supplycontract"].ToString();
                    editDataSoB.bookName = dataSet.Tables["setsofbooks"].Rows[0]["book"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataSoB.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        decimal updatedCount = editDataSoB.count;
                        decimal updatedSum = editDataSoB.sum;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE setsofbooks SET count = @count, sum = @sum WHERE setid = @setid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@count", updatedCount);
                        updateCommand.Parameters.AddWithValue("@sum", updatedSum);
                        updateCommand.Parameters.AddWithValue("@setid", setId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["setsofbooks"].Rows[0];
                        updatedRow["count"] = updatedCount;
                        updatedRow["sum"] = updatedSum;

                        int rowIndex = Setsdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Setsdb.Rows[rowIndex];
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
                    int setId = (int)Setsdb.Rows[e.RowIndex].Cells["setid"].Value;
                    OpenCustomControl(setId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshDataGridView()
        {
            string query = "SELECT s.setid, s.count, s.sum, sc.information AS supplycontract, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM setsofbooks AS s " +
               "JOIN supplycontracts AS sc ON s.contractid = sc.contractid " +
               "JOIN books AS b ON s.bookid = b.bookid";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "setsofbooks");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Setsdb.DataSource = dataSet.Tables["setsofbooks"];
        }

        private void OpenAddDataSoB()
        {
            var addDataOSoB = new AddDataSoB();
            addDataOSoB.DataAdded += AddDataForm_DataAdded;
            addDataOSoB.ShowDialog();
        }
        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }

        private void SaveSetsDB_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Setsdb);
        }

        private void AddSetsDB_Click(object sender, EventArgs e)
        {
            OpenAddDataSoB();
            Setsdb.Sort(Setsdb.Columns["setid"], ListSortDirection.Ascending);
        }
    }
}
