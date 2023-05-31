namespace BookDealer.CustomControls
{
    partial class AddDataClients
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveButton = new Button();
            MidTextBox = new TextBox();
            SurTextBox = new TextBox();
            NameTextBox = new TextBox();
            BankTextBox = new TextBox();
            AddressTextBox = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(293, 29);
            label7.Name = "label7";
            label7.Size = new Size(230, 31);
            label7.TabIndex = 27;
            label7.Text = "Добавление клиента";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(355, 89);
            label5.Name = "label5";
            label5.Size = new Size(168, 28);
            label5.TabIndex = 25;
            label5.Text = "Банковский счет:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(355, 152);
            label4.Name = "label4";
            label4.Size = new Size(71, 28);
            label4.TabIndex = 24;
            label4.Text = "Адрес:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(7, 218);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 23;
            label3.Text = "Отчество:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(7, 152);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 22;
            label2.Text = "Фамилия:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 89);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 21;
            label1.Text = "Имя:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(312, 290);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 20;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // MidTextBox
            // 
            MidTextBox.Location = new Point(129, 219);
            MidTextBox.Name = "MidTextBox";
            MidTextBox.Size = new Size(193, 27);
            MidTextBox.TabIndex = 16;
            // 
            // SurTextBox
            // 
            SurTextBox.Location = new Point(129, 156);
            SurTextBox.Name = "SurTextBox";
            SurTextBox.Size = new Size(193, 27);
            SurTextBox.TabIndex = 15;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(129, 93);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(193, 27);
            NameTextBox.TabIndex = 14;
            // 
            // BankTextBox
            // 
            BankTextBox.Location = new Point(529, 93);
            BankTextBox.Name = "BankTextBox";
            BankTextBox.Size = new Size(193, 27);
            BankTextBox.TabIndex = 28;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(529, 152);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(193, 27);
            AddressTextBox.TabIndex = 29;
            // 
            // AddDataClients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 369);
            Controls.Add(AddressTextBox);
            Controls.Add(BankTextBox);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(MidTextBox);
            Controls.Add(SurTextBox);
            Controls.Add(NameTextBox);
            Name = "AddDataClients";
            Text = "AddDataClients";
            Load += AddDataClients_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SaveButton;
        private TextBox MidTextBox;
        private TextBox SurTextBox;
        private TextBox NameTextBox;
        private TextBox BankTextBox;
        private TextBox AddressTextBox;
    }
}