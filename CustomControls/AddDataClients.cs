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
    public partial class AddDataClients : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataClients()
        {
            InitializeComponent();
        }
        public event EventHandler DataSaved;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string clientName = NameTextBox.Text;
                string clientSur = SurTextBox.Text;
                string clientMid = MidTextBox.Text;
                string clientBank = BankTextBox.Text;
                string clientAddress = AddressTextBox.Text;

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO clients (name, surname, middlename, bankaccount, address) VALUES (@name, @surname, @middlename, @bankaccount, @address)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", clientName);
                insertCommand.Parameters.AddWithValue("@surname", clientSur);
                insertCommand.Parameters.AddWithValue("@middlename", clientMid);
                insertCommand.Parameters.AddWithValue("@bankaccount", clientBank);
                insertCommand.Parameters.AddWithValue("@address", clientAddress);
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

        private void AddDataClients_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
