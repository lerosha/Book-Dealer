using NodaTime;
using Npgsql;
using NPOI.SS.Formula.Functions;
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
    public partial class AddDataOrders : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataOrders()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;
        private bool isEnough;

        private int GetPublisherIdByName(string salesConName)
        {
            string query = "SELECT contractid FROM salescontracts WHERE information = @information";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@information", salesConName);
            int salesConId = Convert.ToInt32(command.ExecuteScalar());
            return salesConId;
        }
        private int GetGenreIdByName(string bookName)
        {
            string query = "SELECT bookid FROM books WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", bookName);
            int bookId = Convert.ToInt32(command.ExecuteScalar());
            return bookId;
        }

        private void SubtractFromStoreroom(int subtractCount, int bookid)
        {
            try
            {
                // Получить текущее значение из поля count в таблице storeroom
                string selectQuery = "SELECT count FROM storeroom WHERE bookid = @bookid";
                NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@bookid", bookid);
                decimal currentCount = (int)selectCommand.ExecuteScalar();

                // Проверить, есть ли достаточное количество для вычитания
                if (currentCount >= subtractCount)
                {
                    string updateQuery = "UPDATE storeroom SET count = count - @subtractCount WHERE bookid = @bookid";
                    NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@subtractCount", subtractCount);
                    updateCommand.Parameters.AddWithValue("@bookid", bookid);
                    updateCommand.ExecuteNonQuery();
                    isEnough = true;

                }
                else
                {
                    isEnough = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка вычитания из базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateTime = dateTimePicker1.Value;
                LocalDateTime localTime = LocalDateTime.FromDateTime(dateTime);
                string bookName = BookComboBox.SelectedItem.ToString();
                string salesConName = SalesConComboBox.SelectedItem.ToString();
                decimal orderSum = decimal.Parse(SumTextBox.Text);
                decimal orderCount = decimal.Parse(CountTextBox.Text);

                // Получить идентификаторы связанных записей на основе выбранных значений
                int salesConId = GetPublisherIdByName(salesConName);
                int bookId = GetGenreIdByName(bookName);

                int subtractCount = int.Parse(CountTextBox.Text);
                SubtractFromStoreroom(subtractCount, bookId);

                if (isEnough == true)
                {
                    // Вставить новую запись в таблицу
                    string insertQuery = "INSERT INTO orders (date, count, sum, contractid, bookid) VALUES (@date, @count, @sum, @contractid, @bookid)";
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@date", localTime.ToDateTimeUnspecified());
                    insertCommand.Parameters.AddWithValue("@count", orderCount);
                    insertCommand.Parameters.AddWithValue("@sum", orderSum);
                    insertCommand.Parameters.AddWithValue("@contractid", salesConId);
                    insertCommand.Parameters.AddWithValue("@bookid", bookId);
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (isEnough == false)
                {
                    MessageBox.Show("Недостаточное количество книг на складе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Обновить отображение в DataGridView
                DataAdded?.Invoke(this, EventArgs.Empty);
                Close();
                // Предполагается, что у вас есть DataGridView с именем BooksDataGridView

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDataOrders_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT information FROM salescontracts";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string salesConName = reader["information"].ToString();
                    SalesConComboBox.Items.Add(salesConName);
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

        }
    }
}
