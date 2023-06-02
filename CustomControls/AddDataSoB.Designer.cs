namespace BookDealer.CustomControls
{
    partial class AddDataSoB
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
            label2 = new Label();
            countTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            BookComboBox = new ComboBox();
            SupConComboBox = new ComboBox();
            SaveButton = new Button();
            label7 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(118, 56);
            label2.Name = "label2";
            label2.Size = new Size(124, 28);
            label2.TabIndex = 26;
            label2.Text = "Количество:";
            // 
            // countTextBox
            // 
            countTextBox.Location = new Point(334, 60);
            countTextBox.Name = "countTextBox";
            countTextBox.Size = new Size(193, 27);
            countTextBox.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(118, 121);
            label5.Name = "label5";
            label5.Size = new Size(207, 28);
            label5.TabIndex = 31;
            label5.Text = "Договор на продажу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(118, 189);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 30;
            label4.Text = "Книга:";
            // 
            // BookComboBox
            // 
            BookComboBox.FormattingEnabled = true;
            BookComboBox.Location = new Point(334, 193);
            BookComboBox.Name = "BookComboBox";
            BookComboBox.Size = new Size(193, 28);
            BookComboBox.TabIndex = 29;
            // 
            // SupConComboBox
            // 
            SupConComboBox.FormattingEnabled = true;
            SupConComboBox.Location = new Point(334, 125);
            SupConComboBox.Name = "SupConComboBox";
            SupConComboBox.Size = new Size(193, 28);
            SupConComboBox.TabIndex = 28;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(232, 262);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 32;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(232, 9);
            label7.Name = "label7";
            label7.Size = new Size(151, 31);
            label7.TabIndex = 33;
            label7.Text = "Заказ партии";
            // 
            // AddDataSoB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 321);
            Controls.Add(label7);
            Controls.Add(SaveButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(BookComboBox);
            Controls.Add(SupConComboBox);
            Controls.Add(label2);
            Controls.Add(countTextBox);
            Name = "AddDataSoB";
            Text = "AddDataSoB";
            Load += AddDataSoB_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private TextBox SumTextBox;
        private TextBox countTextBox;
        private Label label5;
        private Label label4;
        private ComboBox BookComboBox;
        private ComboBox SupConComboBox;
        private Button SaveButton;
        private Label label7;
    }
}