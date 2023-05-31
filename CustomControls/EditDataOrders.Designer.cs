namespace BookDealer.CustomControls
{
    partial class EditDataOrders
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BookTextBox = new TextBox();
            contractTextBox = new TextBox();
            SumTextBox = new TextBox();
            btnOK = new Button();
            CountTextBox = new TextBox();
            NameTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(185, 296);
            label6.Name = "label6";
            label6.Size = new Size(170, 28);
            label6.TabIndex = 25;
            label6.Text = "Товар (название)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(185, 249);
            label5.Name = "label5";
            label5.Size = new Size(207, 28);
            label5.TabIndex = 24;
            label5.Text = "Договор на продажу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(185, 197);
            label4.Name = "label4";
            label4.Size = new Size(76, 28);
            label4.TabIndex = 23;
            label4.Text = "Сумма:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(185, 149);
            label3.Name = "label3";
            label3.Size = new Size(129, 28);
            label3.TabIndex = 22;
            label3.Text = "Количество: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(185, 101);
            label2.Name = "label2";
            label2.Size = new Size(121, 28);
            label2.TabIndex = 21;
            label2.Text = "Дата заказа:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(185, 52);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 20;
            label1.Text = "Номер заказа:";
            // 
            // BookTextBox
            // 
            BookTextBox.Location = new Point(397, 296);
            BookTextBox.Name = "BookTextBox";
            BookTextBox.ReadOnly = true;
            BookTextBox.Size = new Size(240, 27);
            BookTextBox.TabIndex = 19;
            // 
            // contractTextBox
            // 
            contractTextBox.Location = new Point(397, 253);
            contractTextBox.Name = "contractTextBox";
            contractTextBox.ReadOnly = true;
            contractTextBox.Size = new Size(240, 27);
            contractTextBox.TabIndex = 18;
            // 
            // SumTextBox
            // 
            SumTextBox.Location = new Point(397, 198);
            SumTextBox.Name = "SumTextBox";
            SumTextBox.Size = new Size(240, 27);
            SumTextBox.TabIndex = 17;
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
            // CountTextBox
            // 
            CountTextBox.Location = new Point(397, 150);
            CountTextBox.Name = "CountTextBox";
            CountTextBox.Size = new Size(240, 27);
            CountTextBox.TabIndex = 15;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(397, 52);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.ReadOnly = true;
            NameTextBox.Size = new Size(240, 27);
            NameTextBox.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(397, 102);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(240, 27);
            dateTimePicker1.TabIndex = 26;
            // 
            // EditDataOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BookTextBox);
            Controls.Add(contractTextBox);
            Controls.Add(SumTextBox);
            Controls.Add(btnOK);
            Controls.Add(CountTextBox);
            Controls.Add(NameTextBox);
            Name = "EditDataOrders";
            Text = "EditDataOrders";
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
        public TextBox BookTextBox;
        public TextBox contractTextBox;
        public TextBox SumTextBox;
        private Button btnOK;
        public TextBox CountTextBox;
        public TextBox NameTextBox;
        private DateTimePicker dateTimePicker1;
    }
}