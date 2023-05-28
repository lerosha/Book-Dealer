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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookDealer.CustomControls
{
    public partial class AddDataForm : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataForm()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private int GetPublisherIdByName(string publisherName)
        {
            string query = "SELECT publisherid FROM publishers WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", publisherName);
            int publisherId = Convert.ToInt32(command.ExecuteScalar());
            return publisherId;
        }
        private int GetGenreIdByName(string genreName)
        {
            string query = "SELECT genreid FROM genres WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", genreName);
            int genreId = Convert.ToInt32(command.ExecuteScalar());
            return genreId;
        }
        private int GetProviderIdByName(string providerName)
        {
            string query = "SELECT providerid FROM providers WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", providerName);
            int providerId = Convert.ToInt32(command.ExecuteScalar());
            return providerId;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                string bookName = bookNameTextBox.Text;
                int bookPrice = int.Parse(bookPriceTextBox.Text);
                string bookAuthor = bookAuthorTextBox.Text;
                string publisherName = publisherComboBox.SelectedItem.ToString();
                string genreName = genreComboBox.SelectedItem.ToString();
                string providerName = providerComboBox.SelectedItem.ToString();

                // Получить идентификаторы связанных записей на основе выбранных значений
                int publisherId = GetPublisherIdByName(publisherName);
                int genreId = GetGenreIdByName(genreName);
                int providerId = GetProviderIdByName(providerName);

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO books (name, price, author, publisherid, genreid, providerid) VALUES (@name, @price, @author, @publisherid, @genreid, @providerid)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", bookName);
                insertCommand.Parameters.AddWithValue("@price", bookPrice);
                insertCommand.Parameters.AddWithValue("@author", bookAuthor);
                insertCommand.Parameters.AddWithValue("@publisherid", publisherId);
                insertCommand.Parameters.AddWithValue("@genreid", genreId);
                insertCommand.Parameters.AddWithValue("@providerid", providerId);
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

        private void AddDataForm_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT name FROM publishers";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string publisherName = reader["name"].ToString();
                    publisherComboBox.Items.Add(publisherName);
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
                string query = "SELECT name FROM genres";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string genreName = reader["name"].ToString();
                    genreComboBox.Items.Add(genreName);
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
                string query = "SELECT name FROM providers";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string providerName = reader["name"].ToString();
                    providerComboBox.Items.Add(providerName);
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
