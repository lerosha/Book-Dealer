using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class Storage : UserControl
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        public Storage()
        {
            InitializeComponent();
        }

        private void FromStorageButton_Click(object sender, EventArgs e)
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
                string query = "SELECT s.collectbooksid, s.count, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM storeroom AS s " +
               "JOIN books AS b ON s.bookid = b.bookid";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Storagedb.DataSource = bindingSource;
                Storagedb.Columns["collectbooksid"].Visible = false;
                Storagedb.Sort(Storagedb.Columns["collectbooksid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControl(int storageId)
        {
            try
            {
                string query = "SELECT s.collectbooksid, s.count, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM storeroom AS s " +
               "JOIN books AS b ON s.bookid = b.bookid " +
               "WHERE s.collectbooksid = @collectbooksid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@collectbooksid", storageId);
                Storagedb.Columns["collectbooksid"].Visible = false;

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "storeroom");

                if (dataSet.Tables["storeroom"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataStorage = new EditDataStorage();
                    editDataStorage.BookName = dataSet.Tables["storeroom"].Rows[0]["book"].ToString();
                    editDataStorage.CountBook = decimal.Parse(dataSet.Tables["storeroom"].Rows[0]["count"].ToString());

                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataStorage.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        decimal updatedCount = editDataStorage.CountBook;
                       
                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE storeroom SET count = @count WHERE collectbooksid = @collectbooksid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);

                        updateCommand.Parameters.AddWithValue("@count", updatedCount);
                        updateCommand.Parameters.AddWithValue("@collectbooksid", storageId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["storeroom"].Rows[0];
                        updatedRow["count"] = updatedCount;

                        int rowIndex = Storagedb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Storagedb.Rows[rowIndex];
                        dataGridViewRow.Cells["count"].Value = updatedCount;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Storagedb.ClearSelection();
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

        public void RefreshDataGridView()
        {
            string query = "SELECT s.collectbooksid, s.count, b.name AS book, " +
                    "'Редактировать' AS Edit " +
               "FROM storeroom AS s " +
               "JOIN books AS b ON s.bookid = b.bookid";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "storeroom");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Storagedb.DataSource = dataSet.Tables["storeroom"];
            Storagedb.Columns["collectbooksid"].Visible = false;
        }

        private void OpenAddDataForm()
        {
            var addDataStorage = new AddDataStorage();
            addDataStorage.DataAdded += AddDataForm_DataAdded;
            addDataStorage.ShowDialog();
        }
        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }

        private void AddStorageDB_Click(object sender, EventArgs e)
        {
            OpenAddDataForm();
            Storagedb.Sort(Storagedb.Columns["collectbooksid"], ListSortDirection.Ascending);
        }

        private void Storage_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void Storagedb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Storagedb.Columns["Edit"].Index)
                {
                    int storageid = (int)Storagedb.Rows[e.RowIndex].Cells["collectbooksid"].Value;
                    OpenCustomControl(storageid);
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

        private void SaveStorageDB_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Storagedb);
        }
    }
}
