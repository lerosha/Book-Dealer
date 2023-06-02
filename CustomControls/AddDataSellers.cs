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
    public partial class AddDataSellers : Form
    {

        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataSellers()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string surname = SurTextBox.Text;
                string middleName = MidTextBox.Text;
                int salary = int.Parse(SellTextBox.Text);

                // Вставить новую запись в таблицу
                string insertQuery = "INSERT INTO sellers (name, surname, middlename, salary) VALUES (@name, @surname, @middlename, @salary)";
                NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@name", name);
                insertCommand.Parameters.AddWithValue("@surname", surname);
                insertCommand.Parameters.AddWithValue("@middlename", middleName);
                insertCommand.Parameters.AddWithValue("@salary", salary);
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

        private void AddDataSellers_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
