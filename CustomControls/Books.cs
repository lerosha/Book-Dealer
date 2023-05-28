using Npgsql;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using NPOI.XWPF.UserModel;

namespace BookDealer.CustomControls
{
    public partial class Books : UserControl
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        public Books()
        {
            InitializeComponent();
        }

        private void FromBooksButton_Click(object sender, EventArgs e)
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
                string query = "SELECT b.bookid, b.name, b.price, b.author, p.name AS publisher, g.name AS genre, pr.name AS provider, " +
                    "'Редактировать' AS Edit " +
               "FROM books AS b " +
               "JOIN publishers AS p ON b.publisherid = p.publisherid " +
               "JOIN genres AS g ON b.genreid = g.genreid " +
               "JOIN providers AS pr ON b.providerid = pr.providerid";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Booksdb.DataSource = bindingSource;
                Booksdb.Columns["bookid"].Visible = false;
                Booksdb.Sort(Booksdb.Columns["bookid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControl(string bookName)
        {
            try
            {
                string query = "SELECT b.name, b.price, b.author, p.name AS publisher, g.name AS genre, pr.name AS provider, " +
               "'Редактировать' AS Edit " +
               "FROM books AS b " +
               "JOIN publishers AS p ON b.publisherid = p.publisherid " +
               "JOIN genres AS g ON b.genreid = g.genreid " +
               "JOIN providers AS pr ON b.providerid = pr.providerid " +
               "WHERE b.name = @name";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", bookName);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "books");

                if (dataSet.Tables["books"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataBooks = new EditDataBooks();
                    editDataBooks.BookName = bookName;
                    editDataBooks.BookPrice = decimal.Parse(dataSet.Tables["books"].Rows[0]["price"].ToString());
                    editDataBooks.BookAuthor = dataSet.Tables["books"].Rows[0]["author"].ToString();
                    editDataBooks.BookPulisher = dataSet.Tables["books"].Rows[0]["publisher"].ToString();
                    editDataBooks.BookGenre = dataSet.Tables["books"].Rows[0]["genre"].ToString();
                    editDataBooks.BookProvider = dataSet.Tables["books"].Rows[0]["provider"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataBooks.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получить обновленные параметры книги из формы EditDataBooks
                        string updatedName = editDataBooks.BookName;
                        decimal updatedPrice = editDataBooks.BookPrice;
                        string updatedAuthor = editDataBooks.BookAuthor;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE books SET name = @name, price = @price, author = @author WHERE name = @oldName";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", updatedName);
                        updateCommand.Parameters.AddWithValue("@price", updatedPrice);
                        updateCommand.Parameters.AddWithValue("@author", updatedAuthor);
                        updateCommand.Parameters.AddWithValue("@oldName", bookName);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["books"].Rows[0];
                        updatedRow["name"] = updatedName;
                        updatedRow["price"] = updatedPrice;
                        updatedRow["author"] = updatedAuthor;

                        int rowIndex = Booksdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Booksdb.Rows[rowIndex];
                        dataGridViewRow.Cells["name"].Value = updatedName;
                        dataGridViewRow.Cells["price"].Value = updatedPrice;
                        dataGridViewRow.Cells["author"].Value = updatedAuthor;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Booksdb.ClearSelection();
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
            string query = "SELECT b.bookid, b.name, b.price, b.author, p.name AS publisher, g.name AS genre, pr.name AS provider, " +
                    "'Редактировать' AS Edit " +
               "FROM books AS b " +
               "JOIN publishers AS p ON b.publisherid = p.publisherid " +
               "JOIN genres AS g ON b.genreid = g.genreid " +
               "JOIN providers AS pr ON b.providerid = pr.providerid";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "books");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Booksdb.DataSource = dataSet.Tables["books"];
            Booksdb.Columns["bookid"].Visible = false;
        }

        private void Booksdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Booksdb.Columns["Edit"].Index)
                {
                    string bookName = Booksdb.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    OpenCustomControl(bookName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Books_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
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
                for (int j = 1; j < dataGridView.Columns.Count -1; j++)
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

        private void SaveBooksDB_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Booksdb);
        }

        private void OpenAddDataForm()
        {
            var addDataForm = new AddDataForm();
            addDataForm.DataAdded += AddDataForm_DataAdded;
            addDataForm.ShowDialog();
        }
        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddDataForm addDataForm = new AddDataForm();
            OpenAddDataForm();    
            Booksdb.Sort(Booksdb.Columns["bookid"], ListSortDirection.Ascending);
        }
    }
}
