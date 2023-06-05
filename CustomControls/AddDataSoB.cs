using Npgsql;
using NPOI.SS.Formula.Functions;
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
    public partial class AddDataSoB : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;

        public AddDataSoB()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private int GetSupConIdByName(string supConName)
        {
            string query = "SELECT contractid FROM supplycontracts WHERE information = @information";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@information", supConName);
            int supConId = Convert.ToInt32(command.ExecuteScalar());
            return supConId;
        }
        private int GetBookIdByName(string bookName)
        {
            string query = "SELECT bookid FROM books WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", bookName);
            int bookId = Convert.ToInt32(command.ExecuteScalar());
            return bookId;
        }

        private void AddToStorage(int addCount, int bookId)
        {
            try
            {
                // Получить текущее значение из поля count в таблице storeroom
                string selectQuery = "SELECT count FROM storeroom";
                NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
                decimal currentCount = (int)selectCommand.ExecuteScalar();

                // Проверить, есть ли достаточное количество для вычитания

                string updateQuery = "UPDATE storeroom SET count = count + @addCount WHERE  bookid = @bookid";
                NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@addCount", addCount);
                updateCommand.Parameters.AddWithValue("@bookid", bookId);
                updateCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления в базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int count = int.Parse(countTextBox.Text);
                string supConName = SupConComboBox.SelectedItem.ToString();
                string bookName = BookComboBox.SelectedItem.ToString();

                // Получить идентификаторы связанных записей на основе выбранных значений
                int suoConId = GetSupConIdByName(supConName);
                int bookId = GetBookIdByName(bookName);

                // Get the price from the instruments table
                string priceQuery = "SELECT price FROM books WHERE bookid = @bookid";
                NpgsqlCommand priceCommand = new NpgsqlCommand(priceQuery, connection);
                priceCommand.Parameters.AddWithValue("@bookid", bookId);
                decimal price = Convert.ToDecimal(priceCommand.ExecuteScalar());

                decimal total = count * price;

                int addCount = int.Parse(countTextBox.Text);
                AddToStorage(addCount, bookId);

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO setsofbooks (count, sum, contractid, bookid) VALUES (@count, @sum, @contractid, @bookid)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@count", count);
                insertCommand.Parameters.AddWithValue("@sum", total);
                insertCommand.Parameters.AddWithValue("@contractid", suoConId);
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

        private void AddDataSoB_Load(object sender, EventArgs e)
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
                    BookComboBox.Items.Add(bookName);
                }
                reader.Close();

                // Аналогично заполните ComboBox для других связанных таблиц
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT information FROM supplycontracts";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string supConName = reader["information"].ToString();
                    SupConComboBox.Items.Add(supConName);
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
