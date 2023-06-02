namespace BookDealer.CustomControls
{
    partial class EditDataPublishers
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
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnOK = new Button();
            AddressTextBox = new TextBox();
            NameTextBox = new TextBox();
            DirBox = new TextBox();
            MoneyBox = new TextBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(165, 25);
            label6.Name = "label6";
            label6.Size = new Size(458, 31);
            label6.TabIndex = 37;
            label6.Text = "Редактиование информации издательства";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(174, 222);
            label4.Name = "label4";
            label4.Size = new Size(168, 28);
            label4.TabIndex = 35;
            label4.Text = "Банковский счет:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(174, 174);
            label3.Name = "label3";
            label3.Size = new Size(106, 28);
            label3.TabIndex = 34;
            label3.Text = "Директор:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(174, 126);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 33;
            label2.Text = "Адрес:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(174, 77);
            label1.Name = "label1";
            label1.Size = new Size(104, 28);
            label1.TabIndex = 32;
            label1.Text = "Название:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(298, 290);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 29;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(365, 126);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(240, 27);
            AddressTextBox.TabIndex = 27;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(365, 77);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(240, 27);
            NameTextBox.TabIndex = 26;
            // 
            // DirBox
            // 
            DirBox.Location = new Point(365, 178);
            DirBox.Name = "DirBox";
            DirBox.Size = new Size(240, 27);
            DirBox.TabIndex = 38;
            // 
            // MoneyBox
            // 
            MoneyBox.Location = new Point(365, 223);
            MoneyBox.Name = "MoneyBox";
            MoneyBox.Size = new Size(240, 27);
            MoneyBox.TabIndex = 39;
            // 
            // EditDataPublishers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 358);
            Controls.Add(MoneyBox);
            Controls.Add(DirBox);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(AddressTextBox);
            Controls.Add(NameTextBox);
            Name = "EditDataPublishers";
            Text = "EditDataPublishers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        public TextBox addressTextBox;
        public TextBox bankTextBox;
        private Button btnOK;
        public TextBox midTextBox;
        public TextBox AddressTextBox;
        public TextBox NameTextBox;
        public TextBox DirBox;
        public TextBox MoneyBox;
    }
}