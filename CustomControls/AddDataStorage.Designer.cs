namespace BookDealer.CustomControls
{
    partial class AddDataStorage
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
            label7 = new Label();
            label5 = new Label();
            label1 = new Label();
            bookNameComboBox = new ComboBox();
            countTextBox = new TextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(178, 30);
            label7.Name = "label7";
            label7.Size = new Size(207, 31);
            label7.TabIndex = 18;
            label7.Text = "Добавление книги";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(319, 91);
            label5.Name = "label5";
            label5.Size = new Size(163, 28);
            label5.TabIndex = 17;
            label5.Text = "Название книги:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(44, 91);
            label1.Name = "label1";
            label1.Size = new Size(171, 28);
            label1.TabIndex = 16;
            label1.Text = "Количество книг:";
            // 
            // bookNameComboBox
            // 
            bookNameComboBox.FormattingEnabled = true;
            bookNameComboBox.Location = new Point(319, 136);
            bookNameComboBox.Name = "bookNameComboBox";
            bookNameComboBox.Size = new Size(193, 28);
            bookNameComboBox.TabIndex = 15;
            // 
            // countTextBox
            // 
            countTextBox.Location = new Point(44, 137);
            countTextBox.Name = "countTextBox";
            countTextBox.Size = new Size(193, 27);
            countTextBox.TabIndex = 14;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(192, 197);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 19;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddDataStorage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 263);
            Controls.Add(SaveButton);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(bookNameComboBox);
            Controls.Add(countTextBox);
            Name = "AddDataStorage";
            Text = "AddDataStorage";
            Load += AddDataStorage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label5;
        private Label label1;
        private ComboBox bookNameComboBox;
        private TextBox countTextBox;
        private Button SaveButton;
    }
}