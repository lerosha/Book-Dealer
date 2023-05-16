﻿using System;
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
    public partial class SalesContracts : UserControl
    {
        public SalesContracts()
        {
            InitializeComponent();
        }

        private void FromSalesButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            ContractsControl contractsControl = parentForm.Controls.Find("contractsControl1", true).FirstOrDefault() as ContractsControl;
            contractsControl.Visible = true;
        }
    }
}
