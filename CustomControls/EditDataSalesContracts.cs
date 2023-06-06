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
    public partial class EditDataSalesContracts : Form
    {
        private NpgsqlConnection? connection = null;

        public EditDataSalesContracts()
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
            get { return decimal.Parse(textBox3.Text); }
            set { textBox3.Text = value.ToString(); }
        }
        public string Client
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }
        public string Seller
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string Invoiceid
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
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

        private void SubtractToStorage()
        {
            try
            {
                string infCon = textBox1.Text;
                string querySet = "SELECT contractid FROM salescontracts WHERE information = @information";
                NpgsqlCommand commandSet = new NpgsqlCommand(querySet, connection);
                commandSet.Parameters.AddWithValue("@information", infCon);
                int conId = Convert.ToInt32(commandSet.ExecuteScalar());

                string selectQuery = "SELECT bookid, count FROM orders WHERE contractid = @contractid";
                NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@contractid", conId);
                NpgsqlDataReader reader = selectCommand.ExecuteReader();

                Dictionary<int, decimal> bookCounts = new Dictionary<int, decimal>();

                while (reader.Read())
                {
                    int bookId = reader.GetInt32(0);
                    decimal count = reader.GetDecimal(1);

                    if (bookCounts.ContainsKey(bookId))
                    {
                        bookCounts[bookId] += count;
                    }
                    else
                    {
                        bookCounts.Add(bookId, count);
                    }
                }

                reader.Close();

                foreach (var kvp in bookCounts)
                {
                    int bookId = kvp.Key;
                    decimal orderCount = kvp.Value;

                    // Получить текущее значение из поля count в таблице storeroom для данного bookId
                    string currentCountQuery = "SELECT count FROM storeroom WHERE bookid = @bookid";
                    NpgsqlCommand currentCountCommand = new NpgsqlCommand(currentCountQuery, connection);
                    currentCountCommand.Parameters.AddWithValue("@bookid", bookId);
                    decimal currentCount = Convert.ToDecimal(currentCountCommand.ExecuteScalar());

                    if (currentCount >= orderCount)
                    {
                        // Выполнить обновление в таблице storeroom для данного bookId
                        string updateQuery = "UPDATE storeroom SET count = count - @orderCount WHERE bookid = @bookid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@orderCount", orderCount);
                        updateCommand.Parameters.AddWithValue("@bookid", bookId);
                        updateCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        Payment = false;
                        MessageBox.Show("Недостаточное количество книг на складе.", "Ошибка добавления в базу данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Выход из цикла или обработка ошибки недостаточного количества книг
                        break;
                    }
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
            SubtractToStorage();
            Close();
        }

        private void EditDataSalesContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();
        }
    }
}
