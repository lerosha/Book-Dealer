namespace BookDealer.CustomControls
{
    partial class AddDataForm
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
            bookNameTextBox = new TextBox();
            bookPriceTextBox = new TextBox();
            bookAuthorTextBox = new TextBox();
            publisherComboBox = new ComboBox();
            genreComboBox = new ComboBox();
            providerComboBox = new ComboBox();
            SaveButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // bookNameTextBox
            // 
            bookNameTextBox.Location = new Point(192, 94);
            bookNameTextBox.Name = "bookNameTextBox";
            bookNameTextBox.Size = new Size(193, 27);
            bookNameTextBox.TabIndex = 0;
            // 
            // bookPriceTextBox
            // 
            bookPriceTextBox.Location = new Point(192, 157);
            bookPriceTextBox.Name = "bookPriceTextBox";
            bookPriceTextBox.Size = new Size(193, 27);
            bookPriceTextBox.TabIndex = 1;
            // 
            // bookAuthorTextBox
            // 
            bookAuthorTextBox.Location = new Point(192, 220);
            bookAuthorTextBox.Name = "bookAuthorTextBox";
            bookAuthorTextBox.Size = new Size(193, 27);
            bookAuthorTextBox.TabIndex = 2;
            // 
            // publisherComboBox
            // 
            publisherComboBox.FormattingEnabled = true;
            publisherComboBox.Location = new Point(559, 94);
            publisherComboBox.Name = "publisherComboBox";
            publisherComboBox.Size = new Size(193, 28);
            publisherComboBox.TabIndex = 3;
            // 
            // genreComboBox
            // 
            genreComboBox.FormattingEnabled = true;
            genreComboBox.Location = new Point(559, 157);
            genreComboBox.Name = "genreComboBox";
            genreComboBox.Size = new Size(193, 28);
            genreComboBox.TabIndex = 4;
            // 
            // providerComboBox
            // 
            providerComboBox.FormattingEnabled = true;
            providerComboBox.Location = new Point(559, 219);
            providerComboBox.Name = "providerComboBox";
            providerComboBox.Size = new Size(193, 28);
            providerComboBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(325, 298);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 90);
            label1.Name = "label1";
            label1.Size = new Size(174, 28);
            label1.TabIndex = 7;
            label1.Text = "Навзвание книги:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 153);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 8;
            label2.Text = "Цена:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 219);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 9;
            label3.Text = "Автор:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(413, 153);
            label4.Name = "label4";
            label4.Size = new Size(67, 28);
            label4.TabIndex = 10;
            label4.Text = "Жанр:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(413, 94);
            label5.Name = "label5";
            label5.Size = new Size(140, 28);
            label5.TabIndex = 11;
            label5.Text = "Издательство:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(413, 220);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 12;
            label6.Text = "Поставщик:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(298, 30);
            label7.Name = "label7";
            label7.Size = new Size(207, 31);
            label7.TabIndex = 13;
            label7.Text = "Добавление книги";
            // 
            // AddDataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 371);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(providerComboBox);
            Controls.Add(genreComboBox);
            Controls.Add(publisherComboBox);
            Controls.Add(bookAuthorTextBox);
            Controls.Add(bookPriceTextBox);
            Controls.Add(bookNameTextBox);
            Name = "AddDataForm";
            Text = "AddDataForm";
            Load += AddDataForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox bookNameTextBox;
        private TextBox bookPriceTextBox;
        private TextBox bookAuthorTextBox;
        private ComboBox publisherComboBox;
        private ComboBox genreComboBox;
        private ComboBox providerComboBox;
        private Button SaveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}