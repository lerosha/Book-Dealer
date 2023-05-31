using Npgsql;
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
    public partial class AddDataStorage : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataStorage()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private int GetNameIdByName(string bookName)
        {
            string query = "SELECT bookid FROM books WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", bookName);
            int bookId = Convert.ToInt32(command.ExecuteScalar());
            return bookId;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int bookCount = int.Parse(countTextBox.Text);
                string bookName = bookNameComboBox.SelectedItem.ToString();

                // Получить идентификаторы связанных записей на основе выбранных значений
                int bookId = GetNameIdByName(bookName);

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO storeroom (count, bookid) VALUES (@count, @bookid)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@count", bookCount);
                insertCommand.Parameters.AddWithValue("@bookid", bookId);
                insertCommand.ExecuteNonQuery();

                // Обновить отображение в DataGridView
                DataAdded?.Invoke(this, EventArgs.Empty);
                Close();
                // Предполагается, что у вас есть DataGridView с именем BooksDataGridView

                MessageBox.Show("Данные успешно добавлены!", "Добавление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDataStorage_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT name FROM books";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string bookName = reader["name"].ToString();
                    bookNameComboBox.Items.Add(bookName);
                }
                reader.Close();

                // Аналогично заполните ComboBox для других связанных таблиц
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
