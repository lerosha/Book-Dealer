using Org.BouncyCastle.Asn1.IsisMtt.X509;
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
    public partial class EditDataPublishers : Form
    {
        public EditDataPublishers()
        {
            InitializeComponent();
        }

        public string pubName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }

        public string pubAddress
        {
            get { return AddressTextBox.Text; }
            set { AddressTextBox.Text = value; }
        }

        public string pubDir
        {
            get { return DirBox.Text; }
            set { DirBox.Text = value; }
        }
        public string pubBank
        {
            get { return MoneyBox.Text; }
            set { MoneyBox.Text = value; }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
