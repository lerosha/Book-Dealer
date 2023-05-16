namespace BookDealer.CustomControls
{
    partial class ContractsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            SupplyBtn = new Button();
            SalesBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(923, 438);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(401, 6);
            label1.Name = "label1";
            label1.Size = new Size(120, 31);
            label1.TabIndex = 0;
            label1.Text = "Договоры";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(SupplyBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(SalesBtn, 0, 1);
            tableLayoutPanel2.Location = new Point(284, 103);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(354, 274);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // SupplyBtn
            // 
            SupplyBtn.Anchor = AnchorStyles.None;
            SupplyBtn.Location = new Point(10, 36);
            SupplyBtn.Name = "SupplyBtn";
            SupplyBtn.Size = new Size(333, 65);
            SupplyBtn.TabIndex = 0;
            SupplyBtn.Text = "Договоры на поставку";
            SupplyBtn.UseVisualStyleBackColor = true;
            SupplyBtn.Click += SupplyBtn_Click;
            // 
            // SalesBtn
            // 
            SalesBtn.Anchor = AnchorStyles.None;
            SalesBtn.Location = new Point(10, 173);
            SalesBtn.Name = "SalesBtn";
            SalesBtn.Size = new Size(333, 65);
            SalesBtn.TabIndex = 1;
            SalesBtn.Text = "Договоры на продажу";
            SalesBtn.UseVisualStyleBackColor = true;
            SalesBtn.Click += SalesBtn_Click;
            // 
            // ContractsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ContractsControl";
            Size = new Size(923, 438);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SupplyBtn;
        private Button SalesBtn;
    }
}
