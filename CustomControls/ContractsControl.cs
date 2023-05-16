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
    public partial class ContractsControl : UserControl
    {
        public ContractsControl()
        {
            InitializeComponent();
        }

        private void SupplyBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            SupplyContracts supplyContracts = parentForm.Controls.Find("supplyContracts1", true).FirstOrDefault() as SupplyContracts;
            supplyContracts.Visible = true;
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            SalesContracts salesContracts = parentForm.Controls.Find("salesContracts1", true).FirstOrDefault() as SalesContracts;
            salesContracts.Visible = true;
        }
    }
}
