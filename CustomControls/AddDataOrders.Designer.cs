namespace BookDealer.CustomControls
{
    partial class AddDataOrders
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
            BookComboBox = new ComboBox();
            SalesConComboBox = new ComboBox();
            SumTextBox = new TextBox();
            CountTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(316, 35);
            label7.Name = "label7";
            label7.Size = new Size(215, 31);
            label7.TabIndex = 27;
            label7.Text = "Добавление заказа";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(364, 95);
            label5.Name = "label5";
            label5.Size = new Size(207, 28);
            label5.TabIndex = 25;
            label5.Text = "Договор на продажу";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(396, 158);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 24;
            label4.Text = "Книга:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 223);
            label3.Name = "label3";
            label3.Size = new Size(76, 28);
            label3.TabIndex = 23;
            label3.Text = "Сумма:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 158);
            label2.Name = "label2";
            label2.Size = new Size(120, 28);
            label2.TabIndex = 22;
            label2.Text = "Количество";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 95);
            label1.Name = "label1";
            label1.Size = new Size(121, 28);
            label1.TabIndex = 21;
            label1.Text = "Дата заказа:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(343, 303);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 20;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // BookComboBox
            // 
            BookComboBox.FormattingEnabled = true;
            BookComboBox.Location = new Point(577, 162);
            BookComboBox.Name = "BookComboBox";
            BookComboBox.Size = new Size(193, 28);
            BookComboBox.TabIndex = 18;
            // 
            // SalesConComboBox
            // 
            SalesConComboBox.FormattingEnabled = true;
            SalesConComboBox.Location = new Point(577, 95);
            SalesConComboBox.Name = "SalesConComboBox";
            SalesConComboBox.Size = new Size(193, 28);
            SalesConComboBox.TabIndex = 17;
            // 
            // SumTextBox
            // 
            SumTextBox.Location = new Point(156, 224);
            SumTextBox.Name = "SumTextBox";
            SumTextBox.Size = new Size(193, 27);
            SumTextBox.TabIndex = 16;
            // 
            // CountTextBox
            // 
            CountTextBox.Location = new Point(156, 163);
            CountTextBox.Name = "CountTextBox";
            CountTextBox.Size = new Size(193, 27);
            CountTextBox.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(156, 96);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(193, 27);
            dateTimePicker1.TabIndex = 28;
            // 
            // AddDataOrders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 371);
            Controls.Add(dateTimePicker1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(BookComboBox);
            Controls.Add(SalesConComboBox);
            Controls.Add(SumTextBox);
            Controls.Add(CountTextBox);
            Name = "AddDataOrders";
            Text = "AddDataOrders";
            Load += AddDataOrders_Load;
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
        private ComboBox BookComboBox;
        private ComboBox SalesConComboBox;
        private TextBox SumTextBox;
        private TextBox CountTextBox;
        private DateTimePicker dateTimePicker1;
    }
}