using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer
{
    public partial class EditDataStorage : Form
    {
        public EditDataStorage()
        {
            InitializeComponent();
        }

        public string BookName
        {
            get { return BookNameTextBox.Text; }
            set { BookNameTextBox.Text = value; }
        }

        public decimal CountBook
        {
            get { return decimal.Parse(CountTextBox.Text); }
            set { CountTextBox.Text = value.ToString(); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
