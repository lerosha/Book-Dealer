namespace BookDealer.CustomControls
{
    partial class SetsOfBooks
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
            FromSetsButton = new Button();
            Setsdb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveSetsDB = new Button();
            UpdateSetsDB = new Button();
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
            tableLayoutPanel1.Controls.Add(FromSetsButton, 0, 3);
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
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(378, 8);
            label1.Name = "label1";
            label1.Size = new Size(167, 31);
            label1.TabIndex = 0;
            label1.Text = "Заказы партий";
            // 
            // FromSetsButton
            // 
            FromSetsButton.Dock = DockStyle.Fill;
            FromSetsButton.Location = new Point(3, 402);
            FromSetsButton.Name = "FromSetsButton";
            FromSetsButton.Size = new Size(917, 33);
            FromSetsButton.TabIndex = 3;
            FromSetsButton.Text = "Назад";
            FromSetsButton.UseVisualStyleBackColor = true;
            FromSetsButton.Click += FromSetsButton_Click;
            // 
            // Setsdb
            // 
            Setsdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Setsdb.Dock = DockStyle.Fill;
            Setsdb.Location = new Point(3, 92);
            Setsdb.Name = "Setsdb";
            Setsdb.RowHeadersWidth = 51;
            Setsdb.RowTemplate.Height = 29;
            Setsdb.Size = new Size(917, 304);
            Setsdb.TabIndex = 2;
            Setsdb.CellContentClick += Setsdb_CellContentClick;
            Setsdb.CellValueChanged += Setsdb_CellValueChanged;
            Setsdb.UserAddedRow += Setsdb_UserAddedRow;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveSetsDB, 1, 0);
            tableLayoutPanel2.Controls.Add(UpdateSetsDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(917, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveSetsDB
            // 
            SaveSetsDB.Anchor = AnchorStyles.Right;
            SaveSetsDB.Location = new Point(766, 3);
            SaveSetsDB.Name = "SaveSetsDB";
            SaveSetsDB.Size = new Size(148, 29);
            SaveSetsDB.TabIndex = 0;
            SaveSetsDB.Text = "Сохранить отчет";
            SaveSetsDB.UseVisualStyleBackColor = true;
            SaveSetsDB.Click += SaveSetsDB_Click;
            // 
            // UpdateSetsDB
            // 
            UpdateSetsDB.Dock = DockStyle.Right;
            UpdateSetsDB.Location = new Point(605, 3);
            UpdateSetsDB.Name = "UpdateSetsDB";
            UpdateSetsDB.Size = new Size(148, 30);
            UpdateSetsDB.TabIndex = 1;
            UpdateSetsDB.Text = "Обновить таблицу";
            UpdateSetsDB.UseVisualStyleBackColor = true;
            UpdateSetsDB.Click += UpdateSetsDB_Click;
            // 
            // SetsOfBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SetsOfBooks";
            Size = new Size(923, 438);
            Load += SetsOfBooks_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Setsdb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromSetsButton;
        private DataGridView Setsdb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveSetsDB;
        private Button UpdateSetsDB;
    }
}
