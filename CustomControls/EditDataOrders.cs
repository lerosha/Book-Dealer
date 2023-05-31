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

namespace BookDealer.CustomControls
{
    public partial class EditDataOrders : Form
    {
        private NpgsqlConnection? connection = null;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
