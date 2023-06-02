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
    public partial class AddDataProviders : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataProviders()
        {
            InitializeComponent();
        }
        public event EventHandler DataSaved;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string prAddName = prAddNameTextBox.Text;
                string prAddAddr = prAddAddrTextBox.Text;

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO providers (name, address) VALUES (@name, @address)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", prAddName);
                insertCommand.Parameters.AddWithValue("@address", prAddAddr);
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

        private void AddDataProviders_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
