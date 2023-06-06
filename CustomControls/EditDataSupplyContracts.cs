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
    public partial class EditDataSupplyContracts : Form
    {
        private NpgsqlConnection? connection = null;

        public EditDataSupplyContracts()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value.ToString(); }
        }
        public DateTime Date
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        public decimal Sum
        {
            get { return decimal.Parse(textBox5.Text); }
            set { textBox5.Text = value.ToString(); }
        }
        public string Supplier
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Invoiceid
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public bool Payment
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        public bool Dispatch
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }

        private void AddToStorage()
        {
            try
            {
                string infCon = textBox1.Text;
                string querySet = "SELECT contractid FROM supplycontracts WHERE information = @information";
                NpgsqlCommand commandSet = new NpgsqlCommand(querySet, connection);
                commandSet.Parameters.AddWithValue("@information", infCon);
                int conId = Convert.ToInt32(commandSet.ExecuteScalar());

                // Проверить значения полей payment и shipment в таблице salesinvoices
                string checkQuery = "SELECT payment, shipment FROM supplyinvoices WHERE contractid = @contractid";
                NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@contractid", conId);
                NpgsqlDataReader reader = checkCommand.ExecuteReader();

                bool paid = false;
                bool dispatched = false;

                // Если есть запись в таблице salesinvoices для данного contractid, прочитайте значения payment и shipment
                if (reader.Read())
                {
                    paid = Payment;
                    dispatched = Dispatch;
                }

                reader.Close();

                // Проверьте значения payment и shipment
                if (paid && dispatched)
                {
                    // Получить текущее значение из поля count в таблице storeroom
                    string selectQuery = "SELECT count FROM setsofbooks WHERE contractid = @contractid";
                    NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@contractid", conId);
                    decimal currentCount = (int)selectCommand.ExecuteScalar();

                    string selectBook = "SELECT bookid FROM setsofbooks WHERE contractid = @contractid";
                    NpgsqlCommand bookCommand = new NpgsqlCommand(selectBook, connection);
                    bookCommand.Parameters.AddWithValue("@contractid", conId);
                    decimal bookId = (int)bookCommand.ExecuteScalar();

                    // Выполнить обновление в таблице storeroom
                    string updateQuery = "UPDATE storeroom SET count = count + @addCount WHERE  bookid = @bookid";
                    NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@addCount", currentCount);
                    updateCommand.Parameters.AddWithValue("@bookid", bookId);
                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления в базу данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            AddToStorage();
            Close();
        }

        private void EditDataSupplyContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
