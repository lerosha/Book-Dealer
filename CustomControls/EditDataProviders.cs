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
    public partial class EditDataProviders : Form
    {
        public EditDataProviders()
        {
            InitializeComponent();
        }

        public string prName
        {
            get { return prNameTextBox.Text; }
            set { prNameTextBox.Text = value; }
        }

        public string prAddr
        {
            get { return prAddrTextBox.Text; }
            set { prAddrTextBox.Text = value; }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
