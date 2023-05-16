namespace BookDealer.CustomControls
{
    partial class ListOfBooks
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
            FromListsBtn = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            Solddb = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            SaveDataSold = new Button();
            UpdateDBSold = new Button();
            tabPage2 = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            Delivereddb = new DataGridView();
            tableLayoutPanel5 = new TableLayoutPanel();
            SaveDBdelivered = new Button();
            UpdateBDdelivered = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Solddb).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Delivereddb).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(FromListsBtn, 0, 1);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90.86758F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.132421F));
            tableLayoutPanel1.Size = new Size(923, 438);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // FromListsBtn
            // 
            FromListsBtn.Dock = DockStyle.Fill;
            FromListsBtn.Location = new Point(3, 401);
            FromListsBtn.Name = "FromListsBtn";
            FromListsBtn.Size = new Size(917, 34);
            FromListsBtn.TabIndex = 0;
            FromListsBtn.Text = "Назад";
            FromListsBtn.UseVisualStyleBackColor = true;
            FromListsBtn.Click += FromListsBtn_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(917, 392);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(909, 359);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Проданные товары";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(Solddb, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 78F));
            tableLayoutPanel2.Size = new Size(903, 353);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(342, 3);
            label1.Name = "label1";
            label1.Size = new Size(218, 31);
            label1.TabIndex = 0;
            label1.Text = "Проданные товары";
            // 
            // Solddb
            // 
            Solddb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Solddb.Dock = DockStyle.Fill;
            Solddb.Location = new Point(3, 79);
            Solddb.Name = "Solddb";
            Solddb.RowHeadersWidth = 51;
            Solddb.RowTemplate.Height = 29;
            Solddb.Size = new Size(897, 271);
            Solddb.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel3.Controls.Add(SaveDataSold, 1, 0);
            tableLayoutPanel3.Controls.Add(UpdateDBSold, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 41);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(897, 32);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // SaveDataSold
            // 
            SaveDataSold.Anchor = AnchorStyles.Right;
            SaveDataSold.Location = new Point(746, 3);
            SaveDataSold.Name = "SaveDataSold";
            SaveDataSold.Size = new Size(148, 26);
            SaveDataSold.TabIndex = 0;
            SaveDataSold.Text = "Сохранить отчет";
            SaveDataSold.UseVisualStyleBackColor = true;
            // 
            // UpdateDBSold
            // 
            UpdateDBSold.Dock = DockStyle.Right;
            UpdateDBSold.Location = new Point(588, 3);
            UpdateDBSold.Name = "UpdateDBSold";
            UpdateDBSold.Size = new Size(148, 26);
            UpdateDBSold.TabIndex = 1;
            UpdateDBSold.Text = "Обовить таблицу";
            UpdateDBSold.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel4);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(909, 359);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Поставленные товары";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(Delivereddb, 0, 2);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 78F));
            tableLayoutPanel4.Size = new Size(903, 353);
            tableLayoutPanel4.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(328, 3);
            label2.Name = "label2";
            label2.Size = new Size(247, 31);
            label2.TabIndex = 0;
            label2.Text = "Поставленные товары";
            // 
            // Delivereddb
            // 
            Delivereddb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Delivereddb.Dock = DockStyle.Fill;
            Delivereddb.Location = new Point(3, 79);
            Delivereddb.Name = "Delivereddb";
            Delivereddb.RowHeadersWidth = 51;
            Delivereddb.RowTemplate.Height = 29;
            Delivereddb.Size = new Size(897, 271);
            Delivereddb.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel5.Controls.Add(SaveDBdelivered, 1, 0);
            tableLayoutPanel5.Controls.Add(UpdateBDdelivered, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 41);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(897, 32);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // SaveDBdelivered
            // 
            SaveDBdelivered.Anchor = AnchorStyles.Right;
            SaveDBdelivered.Location = new Point(746, 3);
            SaveDBdelivered.Name = "SaveDBdelivered";
            SaveDBdelivered.Size = new Size(148, 26);
            SaveDBdelivered.TabIndex = 0;
            SaveDBdelivered.Text = "Сохранить отчет";
            SaveDBdelivered.UseVisualStyleBackColor = true;
            // 
            // UpdateBDdelivered
            // 
            UpdateBDdelivered.Dock = DockStyle.Right;
            UpdateBDdelivered.Location = new Point(588, 3);
            UpdateBDdelivered.Name = "UpdateBDdelivered";
            UpdateBDdelivered.Size = new Size(148, 26);
            UpdateBDdelivered.TabIndex = 1;
            UpdateBDdelivered.Text = "Обовить таблицу";
            UpdateBDdelivered.UseVisualStyleBackColor = true;
            // 
            // ListOfBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ListOfBooks";
            Size = new Size(923, 438);
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Solddb).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Delivereddb).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button FromListsBtn;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private DataGridView Solddb;
        private TableLayoutPanel tableLayoutPanel3;
        private Button SaveDataSold;
        private Button UpdateDBSold;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private DataGridView Delivereddb;
        private TableLayoutPanel tableLayoutPanel5;
        private Button SaveDBdelivered;
        private Button UpdateBDdelivered;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
