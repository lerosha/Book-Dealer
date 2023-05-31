namespace BookDealer.CustomControls
{
    partial class EditDataClients
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            addressTextBox = new TextBox();
            bankTextBox = new TextBox();
            btnOK = new Button();
            midTextBox = new TextBox();
            SurTextBox = new TextBox();
            NameTextBox = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(181, 293);
            label5.Name = "label5";
            label5.Size = new Size(71, 28);
            label5.TabIndex = 24;
            label5.Text = "Адрес:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(181, 241);
            label4.Name = "label4";
            label4.Size = new Size(168, 28);
            label4.TabIndex = 23;
            label4.Text = "Банковский счет:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(181, 193);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 22;
            label3.Text = "Отчество:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(181, 145);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 21;
            label2.Text = "Фамилия:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(181, 96);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 20;
            label1.Text = "Имя:";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(372, 293);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.ReadOnly = true;
            addressTextBox.Size = new Size(240, 27);
            addressTextBox.TabIndex = 18;
            // 
            // bankTextBox
            // 
            bankTextBox.Location = new Point(372, 241);
            bankTextBox.Name = "bankTextBox";
            bankTextBox.ReadOnly = true;
            bankTextBox.Size = new Size(240, 27);
            bankTextBox.TabIndex = 17;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(294, 361);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 16;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // midTextBox
            // 
            midTextBox.Location = new Point(372, 193);
            midTextBox.Name = "midTextBox";
            midTextBox.Size = new Size(240, 27);
            midTextBox.TabIndex = 15;
            // 
            // SurTextBox
            // 
            SurTextBox.Location = new Point(372, 145);
            SurTextBox.Name = "SurTextBox";
            SurTextBox.Size = new Size(240, 27);
            SurTextBox.TabIndex = 14;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(372, 96);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(240, 27);
            NameTextBox.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(251, 31);
            label6.Name = "label6";
            label6.Size = new Size(260, 31);
            label6.TabIndex = 25;
            label6.Text = "Редактиование клиента";
            // 
            // EditDataClients
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 419);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addressTextBox);
            Controls.Add(bankTextBox);
            Controls.Add(btnOK);
            Controls.Add(midTextBox);
            Controls.Add(SurTextBox);
            Controls.Add(NameTextBox);
            Name = "EditDataClients";
            Text = "EditDataClients";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        public TextBox addressTextBox;
        public TextBox bankTextBox;
        private Button btnOK;
        public TextBox midTextBox;
        public TextBox SurTextBox;
        public TextBox NameTextBox;
        private Label label6;
    }
}