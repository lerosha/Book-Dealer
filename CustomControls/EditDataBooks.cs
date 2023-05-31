using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class EditDataBooks : Form
    {
        public EditDataBooks()
        {
            InitializeComponent();
        }
        public string BookName
        {
            get { return BookIdTextBox.Text; }
            set { BookIdTextBox.Text = value; }
        }
        public decimal BookPrice
        {
            get { return decimal.Parse(BookPriceTextBox.Text); }
            set { BookPriceTextBox.Text = value.ToString(); }
        }
        public string BookAuthor
        {
            get { return BookAuthorTextBox.Text; }
            set { BookAuthorTextBox.Text = value; }
        }

        public string BookPulisher
        {
            get { return BookPublisherTextBox.Text; }
            set { BookPublisherTextBox.Text = value; }
        }

        public string BookGenre
        {
            get { return BookGenreTextBox.Text; }
            set { BookGenreTextBox.Text = value; }
        }

        public string BookProvider
        {
            get { return BookProviderTextBox.Text; }
            set { BookProviderTextBox.Text = value; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
