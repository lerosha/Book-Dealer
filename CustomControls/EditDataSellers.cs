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
    public partial class EditDataSellers : Form
    {
        public EditDataSellers()
        {
            InitializeComponent();
        }

        public string salName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }

        public string salSurname
        {
            get { return SurTextBox.Text; }
            set { SurTextBox.Text = value; }
        }

        public string surMidname
        {
            get { return MidTextBox.Text;}
            set { MidTextBox.Text = value; }
        }

        public int sallary
        {
            get { return int.Parse(SalTextBox.Text); }
            set { SalTextBox.Text = value.ToString(); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
