using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class EditDataSoB : Form
    {
        private NpgsqlConnection? connection = null;
        private decimal total;

        public EditDataSoB()
        {
            InitializeComponent();
        }

        public int orderId
        {
            get { return int.Parse(textBox1.Text); }
            set { textBox1.Text = value.ToString(); }
        }

        public decimal count
        {
            get { return decimal.Parse(CountTextBox.Text); }
            set { CountTextBox.Text = value.ToString(); }
        }

        public decimal sum
        {
            get { return total; }
            set { SumTextBox.Text = value.ToString(); }
        }

        public string saleCon
        {
            get { return SCTextBox.Text; }
            set { SCTextBox.Text = value; }
        }

        public string bookName
        {
            get { return BookNameTextBox.Text; }
            set { BookNameTextBox.Text = value; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(CountTextBox.Text);
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            string query = "SELECT bookid FROM books WHERE name = @name";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", BookNameTextBox.Text);
            int bookId = Convert.ToInt32(command.ExecuteScalar());

            string priceQuery = "SELECT price FROM books WHERE bookid = @bookid";
            NpgsqlCommand priceCommand = new NpgsqlCommand(priceQuery, connection);
            priceCommand.Parameters.AddWithValue("@bookid", bookId);
            decimal price = Convert.ToDecimal(priceCommand.ExecuteScalar());
            total = amount * price;

            int editSetId = int.Parse(textBox1.Text);
            string querySet = "SELECT setid FROM setsofbooks WHERE setid = @setId";
            NpgsqlCommand commandSet = new NpgsqlCommand(querySet, connection);
            commandSet.Parameters.AddWithValue("@setId", editSetId);
            int setId = Convert.ToInt32(commandSet.ExecuteScalar());

            //текущее знач суммы
            string selectQuery = "SELECT sum FROM setsofbooks WHERE setid = @setid";
            NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@setid", setId);
            decimal currentSum = (decimal)selectCommand.ExecuteScalar();

            decimal newSum = total - currentSum;
            string updateQuery = "UPDATE storeroom SET count = count + @newSum / @price WHERE  bookid = @bookid";
            NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
            updateCommand.Parameters.AddWithValue("@newSum", newSum);
            updateCommand.Parameters.AddWithValue("@price", price);
            updateCommand.Parameters.AddWithValue("@bookid", bookId);
            updateCommand.ExecuteNonQuery();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
