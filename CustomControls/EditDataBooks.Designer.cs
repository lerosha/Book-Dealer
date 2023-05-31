namespace BookDealer.CustomControls
{
    partial class EditDataBooks
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BookIdTextBox = new TextBox();
            BookPriceTextBox = new TextBox();
            BookAuthorTextBox = new TextBox();
            btnOK = new Button();
            BookPublisherTextBox = new TextBox();
            BookGenreTextBox = new TextBox();
            BookProviderTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // BookIdTextBox
            // 
            BookIdTextBox.Location = new Point(364, 53);
            BookIdTextBox.Name = "BookIdTextBox";
            BookIdTextBox.Size = new Size(240, 27);
            BookIdTextBox.TabIndex = 0;
            // 
            // BookPriceTextBox
            // 
            BookPriceTextBox.Location = new Point(364, 102);
            BookPriceTextBox.Name = "BookPriceTextBox";
            BookPriceTextBox.Size = new Size(240, 27);
            BookPriceTextBox.TabIndex = 1;
            // 
            // BookAuthorTextBox
            // 
            BookAuthorTextBox.Location = new Point(364, 150);
            BookAuthorTextBox.Name = "BookAuthorTextBox";
            BookAuthorTextBox.Size = new Size(240, 27);
            BookAuthorTextBox.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(282, 362);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 3;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // BookPublisherTextBox
            // 
            BookPublisherTextBox.Location = new Point(364, 198);
            BookPublisherTextBox.Name = "BookPublisherTextBox";
            BookPublisherTextBox.ReadOnly = true;
            BookPublisherTextBox.Size = new Size(240, 27);
            BookPublisherTextBox.TabIndex = 4;
            // 
            // BookGenreTextBox
            // 
            BookGenreTextBox.Location = new Point(364, 250);
            BookGenreTextBox.Name = "BookGenreTextBox";
            BookGenreTextBox.ReadOnly = true;
            BookGenreTextBox.Size = new Size(240, 27);
            BookGenreTextBox.TabIndex = 5;
            // 
            // BookProviderTextBox
            // 
            BookProviderTextBox.Location = new Point(364, 298);
            BookProviderTextBox.Name = "BookProviderTextBox";
            BookProviderTextBox.ReadOnly = true;
            BookProviderTextBox.Size = new Size(240, 27);
            BookProviderTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(173, 53);
            label1.Name = "label1";
            label1.Size = new Size(163, 28);
            label1.TabIndex = 7;
            label1.Text = "Название книги:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(173, 102);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 8;
            label2.Text = "Цена:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(173, 150);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 9;
            label3.Text = "Автор:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(173, 198);
            label4.Name = "label4";
            label4.Size = new Size(140, 28);
            label4.TabIndex = 10;
            label4.Text = "Издательство:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(173, 250);
            label5.Name = "label5";
            label5.Size = new Size(67, 28);
            label5.TabIndex = 11;
            label5.Text = "Жанр:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(173, 297);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 12;
            label6.Text = "Поставщик:";
            // 
            // EditDataBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 440);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BookProviderTextBox);
            Controls.Add(BookGenreTextBox);
            Controls.Add(BookPublisherTextBox);
            Controls.Add(btnOK);
            Controls.Add(BookAuthorTextBox);
            Controls.Add(BookPriceTextBox);
            Controls.Add(BookIdTextBox);
            Name = "EditDataBooks";
            Text = "EditDataBooks";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox BookIdTextBox;
        public TextBox BookPriceTextBox;
        public TextBox BookAuthorTextBox;
        private Button btnOK;
        public TextBox BookPublisherTextBox;
        public TextBox BookGenreTextBox;
        public TextBox BookProviderTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}