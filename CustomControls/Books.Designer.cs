namespace BookDealer.CustomControls
{
    partial class Books
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
            FromBooksButton = new Button();
            Booksdb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveBooksDB = new Button();
            UpdateBooksDB = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Booksdb).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromBooksButton, 0, 3);
            tableLayoutPanel1.Controls.Add(Booksdb, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8459091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.66628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.0344849F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.505747F));
            tableLayoutPanel1.Size = new Size(920, 435);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(422, 8);
            label1.Name = "label1";
            label1.Size = new Size(75, 31);
            label1.TabIndex = 0;
            label1.Text = "Книги";
            // 
            // FromBooksButton
            // 
            FromBooksButton.Dock = DockStyle.Fill;
            FromBooksButton.Location = new Point(3, 400);
            FromBooksButton.Name = "FromBooksButton";
            FromBooksButton.Size = new Size(914, 32);
            FromBooksButton.TabIndex = 3;
            FromBooksButton.Text = "Назад";
            FromBooksButton.UseVisualStyleBackColor = true;
            FromBooksButton.Click += FromBooksButton_Click;
            // 
            // Booksdb
            // 
            Booksdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booksdb.Dock = DockStyle.Fill;
            Booksdb.Location = new Point(3, 92);
            Booksdb.Name = "Booksdb";
            Booksdb.RowHeadersWidth = 51;
            Booksdb.RowTemplate.Height = 29;
            Booksdb.Size = new Size(914, 302);
            Booksdb.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveBooksDB, 1, 0);
            tableLayoutPanel2.Controls.Add(UpdateBooksDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(914, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveBooksDB
            // 
            SaveBooksDB.Anchor = AnchorStyles.Right;
            SaveBooksDB.Location = new Point(763, 3);
            SaveBooksDB.Name = "SaveBooksDB";
            SaveBooksDB.Size = new Size(148, 29);
            SaveBooksDB.TabIndex = 0;
            SaveBooksDB.Text = "Сохранить отчет";
            SaveBooksDB.UseVisualStyleBackColor = true;
            // 
            // UpdateBooksDB
            // 
            UpdateBooksDB.Dock = DockStyle.Right;
            UpdateBooksDB.Location = new Point(602, 3);
            UpdateBooksDB.Name = "UpdateBooksDB";
            UpdateBooksDB.Size = new Size(148, 30);
            UpdateBooksDB.TabIndex = 1;
            UpdateBooksDB.Text = "Обновить таблицу";
            UpdateBooksDB.UseVisualStyleBackColor = true;
            // 
            // Books
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Books";
            Size = new Size(920, 435);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Booksdb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromBooksButton;
        private DataGridView Booksdb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveBooksDB;
        private Button UpdateBooksDB;
    }
}
