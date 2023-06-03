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
    public partial class AddDataSupplyContracts : Form
    {
        private NpgsqlConnection? connection = null;
        public event EventHandler DataAdded;

        public AddDataSupplyContracts()
        {
            InitializeComponent();
        }

        public event EventHandler DataSaved;
        private int GetSupplierIdByName(string SupplierName)
        {
            string query = "SELECT providerid FROM providers WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", SupplierName);
            int SupplierId = Convert.ToInt32(command.ExecuteScalar());
            return SupplierId;
        }

        private void AddDataSupplyContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            try
            {
                // Заполнение ComboBox из таблицы "publishers"
                string query = "SELECT name FROM providers";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string comboitem = reader["name"].ToString();
                    comboBox1.Items.Add(comboitem);
                }
                reader.Close();

                // Аналогично заполните ComboBox для других связанных таблиц
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string description = textBox1.Text;
                DateTime dateTime = dateTimePicker1.Value;
                LocalDateTime localTime = LocalDateTime.FromDateTime(dateTime);
                string supplier = comboBox1.SelectedItem.ToString();
                string invoicenumber = textBox2.Text;
                bool paid = checkBox1.Checked;
                bool dispatch = checkBox2.Checked;

                // Get the identifiers of the related records based on the selected values
                int supplierid = GetSupplierIdByName(supplier);

                string insertContractQuery = "INSERT INTO supplycontracts (information, date, providerid) VALUES (@information, @date, @providerid) RETURNING contractid";
                NpgsqlCommand insertContractCommand = new NpgsqlCommand(insertContractQuery, connection);
                insertContractCommand.Parameters.AddWithValue("@information", description);
                insertContractCommand.Parameters.AddWithValue("@date", localTime.ToDateTimeUnspecified());
                insertContractCommand.Parameters.AddWithValue("@providerid", supplierid);
                int contractsupplyid = Convert.ToInt32(insertContractCommand.ExecuteScalar());


                string insertInvoiceQuery = "INSERT INTO supplyinvoices (number, payment, shipment, sum, contractid) VALUES (@number, @payment, @shipment, @sum, @contractid)";
                NpgsqlCommand insertInvoiceCommand = new NpgsqlCommand(insertInvoiceQuery, connection);
                insertInvoiceCommand.Parameters.AddWithValue("@number", invoicenumber);
                insertInvoiceCommand.Parameters.AddWithValue("@payment", paid);
                insertInvoiceCommand.Parameters.AddWithValue("@shipment", dispatch);
                insertInvoiceCommand.Parameters.AddWithValue("@sum", 0); // Update with appropriate value
                insertInvoiceCommand.Parameters.AddWithValue("@contractid", contractsupplyid);
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
    }
}
