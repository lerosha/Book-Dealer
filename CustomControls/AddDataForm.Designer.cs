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
            SuspendLayout();
            // 
            // bookNameTextBox
            // 
            bookNameTextBox.Location = new Point(362, 65);
            bookNameTextBox.Name = "bookNameTextBox";
            bookNameTextBox.Size = new Size(125, 27);
            bookNameTextBox.TabIndex = 0;
            // 
            // bookPriceTextBox
            // 
            bookPriceTextBox.Location = new Point(359, 128);
            bookPriceTextBox.Name = "bookPriceTextBox";
            bookPriceTextBox.Size = new Size(125, 27);
            bookPriceTextBox.TabIndex = 1;
            // 
            // bookAuthorTextBox
            // 
            bookAuthorTextBox.Location = new Point(362, 187);
            bookAuthorTextBox.Name = "bookAuthorTextBox";
            bookAuthorTextBox.Size = new Size(125, 27);
            bookAuthorTextBox.TabIndex = 2;
            // 
            // publisherComboBox
            // 
            publisherComboBox.FormattingEnabled = true;
            publisherComboBox.Location = new Point(348, 257);
            publisherComboBox.Name = "publisherComboBox";
            publisherComboBox.Size = new Size(151, 28);
            publisherComboBox.TabIndex = 3;
            // 
            // genreComboBox
            // 
            genreComboBox.FormattingEnabled = true;
            genreComboBox.Location = new Point(94, 81);
            genreComboBox.Name = "genreComboBox";
            genreComboBox.Size = new Size(151, 28);
            genreComboBox.TabIndex = 4;
            // 
            // providerComboBox
            // 
            providerComboBox.FormattingEnabled = true;
            providerComboBox.Location = new Point(94, 164);
            providerComboBox.Name = "providerComboBox";
            providerComboBox.Size = new Size(151, 28);
            providerComboBox.TabIndex = 5;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(376, 356);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "button1";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddDataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}