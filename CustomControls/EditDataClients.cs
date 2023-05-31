using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class EditDataClients : Form
    {
        public EditDataClients()
        {
            InitializeComponent();
        }

        public string ClientsName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }

        public string Surname
        {
            get { return SurTextBox.Text; }
            set { SurTextBox.Text = value; }
        }

        public string MiddelName
        {
            get { return midTextBox.Text; }
            set { midTextBox.Text = value; }
        }

        public string Bank
        {
            get { return bankTextBox.Text; }
            set { bankTextBox.Text = value; }
        }

        public string Address
        {
            get { return addressTextBox.Text; }
            set { addressTextBox.Text = value; }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
