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
    public partial class AddDataPublishers : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;

        public AddDataPublishers()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string pubName = pubNameTextBox.Text;
                string pubAddr = pubAddrTextBox.Text;
                string pubDir = pubDirTextBox.Text;
                string pubBank = pubBankTextBox.Text;

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO publishers (name, address, director, bankaccount) VALUES (@name, @address, @director, @bankaccount)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", pubName);
                insertCommand.Parameters.AddWithValue("@address", pubAddr);
                insertCommand.Parameters.AddWithValue("@director", pubDir);
                insertCommand.Parameters.AddWithValue("@bankaccount", pubBank);
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

        private void AddDataPublishers_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
