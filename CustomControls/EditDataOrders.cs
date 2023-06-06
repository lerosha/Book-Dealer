using NodaTime.Text;
using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;
using System.Net;

namespace BookDealer.CustomControls
{
    public partial class EditDataOrders : Form
    {
        private NpgsqlConnection? connection = null;
        private bool add = false;
        public EditDataOrders()
        {
            InitializeComponent();
        }

        public int OrderName
        {
            get { return int.Parse(NameTextBox.Text); }
            set { NameTextBox.Text = value.ToString(); }
        }

        public DateTime Date
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }

        public decimal Count
        {
            get { return decimal.Parse(CountTextBox.Text); }
            set { CountTextBox.Text = value.ToString(); }
        }

        public decimal Sum
        {
            get { return decimal.Parse(SumTextBox.Text); }
            set { SumTextBox.Text = value.ToString(); }
        }

        public string Contract
        {
            get { return contractTextBox.Text; }
            set { contractTextBox.Text = value; }
        }

        public string BookName
        {
            get { return BookTextBox.Text; }
            set { BookTextBox.Text = value; }
        }


        private int GetSupConIdByName(string saleCon)
        {
            string query = "SELECT contractid FROM salescontracts WHERE information = @information";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@information", saleCon);
            int supConId = Convert.ToInt32(command.ExecuteScalar());
            return supConId;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            string query = "SELECT bookid FROM books WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", BookTextBox.Text);
            int bookId = Convert.ToInt32(command.ExecuteScalar());

            //current amount 
            string selectQuery = "SELECT count FROM orders WHERE orderid = @orderid";
            NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@orderid", OrderName);
            decimal currentCount = (int)selectCommand.ExecuteScalar();

            string countQuery = "SELECT count FROM storeroom WHERE bookid = @bookid";
            NpgsqlCommand countCommand = new NpgsqlCommand(@countQuery, connection);
            countCommand.Parameters.AddWithValue("@bookid", bookId);
            int countStorge = (int)countCommand.ExecuteScalar();

            decimal newAmount = decimal.Parse(CountTextBox.Text);

            int supConId = GetSupConIdByName(Contract);

            string checkQuery = "SELECT payment, shipment FROM salesinvoices WHERE contractid = @contractid";
            NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection);
            checkCommand.Parameters.AddWithValue("@contractid", supConId);
            NpgsqlDataReader reader = checkCommand.ExecuteReader();

            bool paid = false;
            //bool dispatched = false;
            if (reader.Read())
            {
                paid = reader.GetBoolean(0);
                //dispatched = reader.GetBoolean(1);
            }
            reader.Close();

            if (paid)
            {
                if (add == false)
                {
                    if (newAmount >= currentCount && newAmount - currentCount <= countStorge)
                    {
                        string updateQuery = "UPDATE storeroom SET count = count - (@newAmount - @currentAmount) WHERE  bookid = @bookid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@newAmount", newAmount);
                        updateCommand.Parameters.AddWithValue("@currentAmount", currentCount);
                        updateCommand.Parameters.AddWithValue("@bookid", bookId);
                        updateCommand.ExecuteNonQuery();
                        add = true;

                    }
                    else if (newAmount < currentCount)
                    {
                        string updateQuery = "UPDATE storeroom SET count = count + (@currentAmount - @newAmount) WHERE  bookid = @bookid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@newAmount", newAmount);
                        updateCommand.Parameters.AddWithValue("@currentAmount", currentCount);
                        updateCommand.Parameters.AddWithValue("@bookid", bookId);
                        updateCommand.ExecuteNonQuery();
                        add = true;

                    }
                    else if (newAmount > countStorge)
                    {
                        MessageBox.Show("Недостаточное количество книг на складе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            

        }


    }
}
