namespace BookDealer.CustomControls
{
    partial class GoodsControl
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
            tableLayoutPanel2 = new TableLayoutPanel();
            genresBtn = new Button();
            BooksBtn = new Button();
            StorageBtn = new Button();
            ListOfBooksBtn = new Button();
            SetsOfBooksBtn = new Button();
            OrdersBtn = new Button();
            label1 = new Label();
            tableLayoutPanel11 = new TableLayoutPanel();
            GenreOpenButton = new Button();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.0095778F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 88.9904251F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(961, 567);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(genresBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(BooksBtn, 0, 1);
            tableLayoutPanel2.Controls.Add(StorageBtn, 0, 2);
            tableLayoutPanel2.Controls.Add(ListOfBooksBtn, 0, 3);
            tableLayoutPanel2.Controls.Add(SetsOfBooksBtn, 0, 4);
            tableLayoutPanel2.Controls.Add(OrdersBtn, 0, 5);
            tableLayoutPanel2.Location = new Point(310, 139);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel2.Size = new Size(341, 350);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // genresBtn
            // 
            genresBtn.Anchor = AnchorStyles.None;
            genresBtn.Location = new Point(52, 3);
            genresBtn.Name = "genresBtn";
            genresBtn.Size = new Size(236, 52);
            genresBtn.TabIndex = 0;
            genresBtn.Text = "Жанры";
            genresBtn.UseVisualStyleBackColor = true;
            genresBtn.Click += genresBtn_Click;
            // 
            // BooksBtn
            // 
            BooksBtn.Anchor = AnchorStyles.None;
            BooksBtn.Location = new Point(52, 61);
            BooksBtn.Name = "BooksBtn";
            BooksBtn.Size = new Size(236, 52);
            BooksBtn.TabIndex = 1;
            BooksBtn.Text = "Поставляемые книги";
            BooksBtn.UseVisualStyleBackColor = true;
            BooksBtn.Click += BooksBtn_Click;
            // 
            // StorageBtn
            // 
            StorageBtn.Anchor = AnchorStyles.None;
            StorageBtn.Location = new Point(52, 119);
            StorageBtn.Name = "StorageBtn";
            StorageBtn.Size = new Size(236, 52);
            StorageBtn.TabIndex = 2;
            StorageBtn.Text = "Склад";
            StorageBtn.UseVisualStyleBackColor = true;
            StorageBtn.Click += StorageBtn_Click;
            // 
            // ListOfBooksBtn
            // 
            ListOfBooksBtn.Anchor = AnchorStyles.None;
            ListOfBooksBtn.Location = new Point(52, 177);
            ListOfBooksBtn.Name = "ListOfBooksBtn";
            ListOfBooksBtn.Size = new Size(236, 52);
            ListOfBooksBtn.TabIndex = 3;
            ListOfBooksBtn.Text = "Список книг";
            ListOfBooksBtn.UseVisualStyleBackColor = true;
            ListOfBooksBtn.Click += ListOfBooksBtn_Click;
            // 
            // SetsOfBooksBtn
            // 
            SetsOfBooksBtn.Anchor = AnchorStyles.None;
            SetsOfBooksBtn.Location = new Point(52, 235);
            SetsOfBooksBtn.Name = "SetsOfBooksBtn";
            SetsOfBooksBtn.Size = new Size(236, 52);
            SetsOfBooksBtn.TabIndex = 4;
            SetsOfBooksBtn.Text = "Заказы партий";
            SetsOfBooksBtn.UseVisualStyleBackColor = true;
            SetsOfBooksBtn.Click += SetsOfBooksBtn_Click;
            // 
            // OrdersBtn
            // 
            OrdersBtn.Anchor = AnchorStyles.None;
            OrdersBtn.Location = new Point(52, 294);
            OrdersBtn.Name = "OrdersBtn";
            OrdersBtn.Size = new Size(236, 52);
            OrdersBtn.TabIndex = 5;
            OrdersBtn.Text = "Заказы клиентов";
            OrdersBtn.UseVisualStyleBackColor = true;
            OrdersBtn.Click += OrdersBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(434, 15);
            label1.Name = "label1";
            label1.Size = new Size(93, 31);
            label1.TabIndex = 0;
            label1.Text = "Товары";
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.Anchor = AnchorStyles.None;
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.Controls.Add(GenreOpenButton, 0, 0);
            tableLayoutPanel11.Location = new Point(0, 0);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 2;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel11.Size = new Size(200, 100);
            tableLayoutPanel11.TabIndex = 0;
            // 
            // GenreOpenButton
            // 
            GenreOpenButton.Anchor = AnchorStyles.None;
            GenreOpenButton.Location = new Point(3, 3);
            GenreOpenButton.Name = "GenreOpenButton";
            GenreOpenButton.Size = new Size(194, 14);
            GenreOpenButton.TabIndex = 0;
            GenreOpenButton.Text = "Жанры";
            GenreOpenButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(3, 61);
            button2.Name = "button2";
            button2.Size = new Size(194, 52);
            button2.TabIndex = 1;
            button2.Text = "Поставляемые книги";
            button2.UseVisualStyleBackColor = true;
            // 
            // GoodsControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "GoodsControl";
            Size = new Size(961, 567);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel11;
        private Button GenreOpenButton;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel2;
        private Button genresBtn;
        private Button BooksBtn;
        private Button StorageBtn;
        private Button ListOfBooksBtn;
        private Button SetsOfBooksBtn;
        private Button OrdersBtn;
    }
}
