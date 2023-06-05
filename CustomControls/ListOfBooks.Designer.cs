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
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            Listsdb = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Listsdb).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(FromListsBtn, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
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
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(button1, 0, 1);
            tableLayoutPanel2.Controls.Add(comboBox1, 0, 2);
            tableLayoutPanel2.Controls.Add(Listsdb, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Size = new Size(917, 392);
            tableLayoutPanel2.TabIndex = 1;
            tableLayoutPanel2.VisibleChanged += tableLayoutPanel2_VisibleChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(388, 13);
            label1.Name = "label1";
            label1.Size = new Size(141, 31);
            label1.TabIndex = 0;
            label1.Text = "Списки книг";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.Location = new Point(772, 63);
            button1.Name = "button1";
            button1.Size = new Size(142, 29);
            button1.TabIndex = 1;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Проданные товары", "Поставленные товары" });
            comboBox1.Location = new Point(729, 102);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(185, 28);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Проданные товары";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Listsdb
            // 
            Listsdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Listsdb.Dock = DockStyle.Fill;
            Listsdb.Location = new Point(3, 139);
            Listsdb.Name = "Listsdb";
            Listsdb.RowHeadersWidth = 51;
            Listsdb.RowTemplate.Height = 29;
            Listsdb.Size = new Size(911, 250);
            Listsdb.TabIndex = 3;
            // 
            // ListOfBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ListOfBooks";
            Size = new Size(923, 438);
            Load += ListOfBooks_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Listsdb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button FromListsBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView Listsdb;
    }
}
