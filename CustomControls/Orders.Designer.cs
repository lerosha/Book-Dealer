namespace BookDealer.CustomControls
{
    partial class Orders
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
            FromOrdersButton = new Button();
            Setsdb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveOrdersDB = new Button();
            AddOrdersDB = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Setsdb).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromOrdersButton, 0, 3);
            tableLayoutPanel1.Controls.Add(Setsdb, 0, 2);
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
            tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(367, 8);
            label1.Name = "label1";
            label1.Size = new Size(188, 31);
            label1.TabIndex = 0;
            label1.Text = "Заказы клиентов";
            // 
            // FromOrdersButton
            // 
            FromOrdersButton.Dock = DockStyle.Fill;
            FromOrdersButton.Location = new Point(3, 402);
            FromOrdersButton.Name = "FromOrdersButton";
            FromOrdersButton.Size = new Size(917, 33);
            FromOrdersButton.TabIndex = 3;
            FromOrdersButton.Text = "Назад";
            FromOrdersButton.UseVisualStyleBackColor = true;
            FromOrdersButton.Click += FromOrdersButton_Click;
            // 
            // Setsdb
            // 
            Setsdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Setsdb.Dock = DockStyle.Fill;
            Setsdb.Location = new Point(3, 92);
            Setsdb.Name = "Setsdb";
            Setsdb.ReadOnly = true;
            Setsdb.RowHeadersWidth = 51;
            Setsdb.RowTemplate.Height = 29;
            Setsdb.Size = new Size(917, 304);
            Setsdb.TabIndex = 2;
            Setsdb.CellContentClick += Setsdb_CellContentClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveOrdersDB, 1, 0);
            tableLayoutPanel2.Controls.Add(AddOrdersDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(917, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveOrdersDB
            // 
            SaveOrdersDB.Anchor = AnchorStyles.Right;
            SaveOrdersDB.Location = new Point(766, 3);
            SaveOrdersDB.Name = "SaveOrdersDB";
            SaveOrdersDB.Size = new Size(148, 29);
            SaveOrdersDB.TabIndex = 0;
            SaveOrdersDB.Text = "Сохранить отчет";
            SaveOrdersDB.UseVisualStyleBackColor = true;
            SaveOrdersDB.Click += SaveOrdersDB_Click;
            // 
            // AddOrdersDB
            // 
            AddOrdersDB.Dock = DockStyle.Right;
            AddOrdersDB.Location = new Point(605, 3);
            AddOrdersDB.Name = "AddOrdersDB";
            AddOrdersDB.Size = new Size(148, 30);
            AddOrdersDB.TabIndex = 1;
            AddOrdersDB.Text = "Добавить";
            AddOrdersDB.UseVisualStyleBackColor = true;
            AddOrdersDB.Click += AddOrdersDB_Click;
            // 
            // Orders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Orders";
            Size = new Size(923, 438);
            Load += Orders_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Setsdb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromOrdersButton;
        private DataGridView Setsdb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveOrdersDB;
        private Button AddOrdersDB;
    }
}
