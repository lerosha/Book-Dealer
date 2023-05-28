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
            SuspendLayout();
            // 
            // BookIdTextBox
            // 
            BookIdTextBox.Location = new Point(271, 50);
            BookIdTextBox.Name = "BookIdTextBox";
            BookIdTextBox.Size = new Size(240, 27);
            BookIdTextBox.TabIndex = 0;
            // 
            // BookPriceTextBox
            // 
            BookPriceTextBox.Location = new Point(271, 111);
            BookPriceTextBox.Name = "BookPriceTextBox";
            BookPriceTextBox.Size = new Size(240, 27);
            BookPriceTextBox.TabIndex = 1;
            // 
            // BookAuthorTextBox
            // 
            BookAuthorTextBox.Location = new Point(271, 172);
            BookAuthorTextBox.Name = "BookAuthorTextBox";
            BookAuthorTextBox.Size = new Size(240, 27);
            BookAuthorTextBox.TabIndex = 2;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(345, 395);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 3;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // BookPublisherTextBox
            // 
            BookPublisherTextBox.Location = new Point(271, 232);
            BookPublisherTextBox.Name = "BookPublisherTextBox";
            BookPublisherTextBox.ReadOnly = true;
            BookPublisherTextBox.Size = new Size(240, 27);
            BookPublisherTextBox.TabIndex = 4;
            // 
            // BookGenreTextBox
            // 
            BookGenreTextBox.Location = new Point(271, 282);
            BookGenreTextBox.Name = "BookGenreTextBox";
            BookGenreTextBox.ReadOnly = true;
            BookGenreTextBox.Size = new Size(240, 27);
            BookGenreTextBox.TabIndex = 5;
            // 
            // BookProviderTextBox
            // 
            BookProviderTextBox.Location = new Point(271, 346);
            BookProviderTextBox.Name = "BookProviderTextBox";
            BookProviderTextBox.ReadOnly = true;
            BookProviderTextBox.Size = new Size(240, 27);
            BookProviderTextBox.TabIndex = 6;
            // 
            // EditDataBooks
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}