using NodaTime;
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
    public partial class AddDataSalesContracts : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;
        public AddDataSalesContracts()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;

        private int GetClientIdByName(string ClientName)
        {
            string[] names = ClientName.Split(' ');
            string firstname = names[0];
            string lastname = names[1];

            string query = "SELECT clientsid FROM clients WHERE name = @name AND surname = @surname";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", firstname);
            command.Parameters.AddWithValue("@surname", lastname);
            int ClientId = Convert.ToInt32(command.ExecuteScalar());
            return ClientId;
        }

        private int GetSellerIdByName(string SellerName)
        {
            string[] names = SellerName.Split(' ');
            string firstname = names[0];
            string lastname = names[1];

            string query = "SELECT sellerid FROM sellers WHERE name = @name AND surname = @surname";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", firstname);
            command.Parameters.AddWithValue("@surname", lastname);
            int SellerId = Convert.ToInt32(command.ExecuteScalar());
            return SellerId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string description = textBox1.Text;
                DateTime dateTime = dateTimePicker1.Value;
                LocalDateTime localTime = LocalDateTime.FromDateTime(dateTime);
                string client = comboBox1.SelectedItem.ToString();
                string seller = comboBox2.SelectedItem.ToString();
                string invoicenumber = textBox2.Text;
                bool paid = checkBox1.Checked;
                bool dispatch = checkBox2.Checked;

                // Get the identifiers of the related records based on the selected values
                int clientId = GetClientIdByName(client);
                int sellerId = GetSellerIdByName(seller);

                // Insert a new record into the contractssale table
                string insertContractQuery = "INSERT INTO salescontracts (information, date, clienstid, sellerid) VALUES (@information, @date, @clienstid, @sellerid) RETURNING contractid";
                NpgsqlCommand insertContractCommand = new NpgsqlCommand(insertContractQuery, connection);
                insertContractCommand.Parameters.AddWithValue("@information", description);
                insertContractCommand.Parameters.AddWithValue("@date", localTime.ToDateTimeUnspecified());
                insertContractCommand.Parameters.AddWithValue("@clienstid", clientId);
                insertContractCommand.Parameters.AddWithValue("@sellerid", sellerId);
                int contractsaleid = Convert.ToInt32(insertContractCommand.ExecuteScalar());

                // Insert a new record into the saleinvoices table
                string insertInvoiceQuery = "INSERT INTO salesinvoices (number, payment, shipment, sum, contractid) VALUES (@number, @payment, @shipment, @sum, @contractid)";
                NpgsqlCommand insertInvoiceCommand = new NpgsqlCommand(insertInvoiceQuery, connection);
                insertInvoiceCommand.Parameters.AddWithValue("@number", invoicenumber);
                insertInvoiceCommand.Parameters.AddWithValue("@payment", paid);
                insertInvoiceCommand.Parameters.AddWithValue("@shipment", dispatch);
                insertInvoiceCommand.Parameters.AddWithValue("@sum", 0); // Update with appropriate value
                insertInvoiceCommand.Parameters.AddWithValue("@contractid", contractsaleid);
                insertInvoiceCommand.ExecuteNonQuery();

                MessageBox.Show("Договор успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataAdded?.Invoke(this, EventArgs.Empty);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDataSalesContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT name, surname FROM clients";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string comboitem = $"{reader["name"]} {reader["surname"]}";
                    comboBox1.Items.Add(comboitem);
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
                string query = "SELECT name, surname FROM sellers";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string comboitem = $"{reader["name"]} {reader["surname"]}";
                    comboBox2.Items.Add(comboitem);
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
