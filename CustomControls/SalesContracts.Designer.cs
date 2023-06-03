namespace BookDealer.CustomControls
{
    partial class SalesContracts
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
            FromSalesButton = new Button();
            Salesdb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveSelesDB = new Button();
            AddSalesDB = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Salesdb).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromSalesButton, 0, 3);
            tableLayoutPanel1.Controls.Add(Salesdb, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8459091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.66628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.0344849F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.505747F));
            tableLayoutPanel1.Size = new Size(923, 438);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(336, 8);
            label1.Name = "label1";
            label1.Size = new Size(250, 31);
            label1.TabIndex = 0;
            label1.Text = "Договоры на продажу";
            // 
            // FromSalesButton
            // 
            FromSalesButton.Dock = DockStyle.Fill;
            FromSalesButton.Location = new Point(3, 402);
            FromSalesButton.Name = "FromSalesButton";
            FromSalesButton.Size = new Size(917, 33);
            FromSalesButton.TabIndex = 3;
            FromSalesButton.Text = "Назад";
            FromSalesButton.UseVisualStyleBackColor = true;
            FromSalesButton.Click += FromSalesButton_Click;
            // 
            // Salesdb
            // 
            Salesdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Salesdb.Dock = DockStyle.Fill;
            Salesdb.Location = new Point(3, 92);
            Salesdb.Name = "Salesdb";
            Salesdb.ReadOnly = true;
            Salesdb.RowHeadersWidth = 51;
            Salesdb.RowTemplate.Height = 29;
            Salesdb.Size = new Size(917, 304);
            Salesdb.TabIndex = 2;
            Salesdb.CellContentClick += Suppludb_CellContentClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveSelesDB, 1, 0);
            tableLayoutPanel2.Controls.Add(AddSalesDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(917, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveSelesDB
            // 
            SaveSelesDB.Anchor = AnchorStyles.Right;
            SaveSelesDB.Location = new Point(766, 3);
            SaveSelesDB.Name = "SaveSelesDB";
            SaveSelesDB.Size = new Size(148, 29);
            SaveSelesDB.TabIndex = 0;
            SaveSelesDB.Text = "Сохранить отчет";
            SaveSelesDB.UseVisualStyleBackColor = true;
            SaveSelesDB.Click += SaveSelesDB_Click;
            // 
            // AddSalesDB
            // 
            AddSalesDB.Dock = DockStyle.Right;
            AddSalesDB.Location = new Point(605, 3);
            AddSalesDB.Name = "AddSalesDB";
            AddSalesDB.Size = new Size(148, 30);
            AddSalesDB.TabIndex = 1;
            AddSalesDB.Text = "Добавить";
            AddSalesDB.UseVisualStyleBackColor = true;
            AddSalesDB.Click += AddSalesDB_Click;
            // 
            // SalesContracts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SalesContracts";
            Size = new Size(923, 438);
            Load += SalesContracts_Load;
            VisibleChanged += SalesContracts_VisibleChanged;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Salesdb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromSalesButton;
        private DataGridView Salesdb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveSelesDB;
        private Button AddSalesDB;
    }
}
