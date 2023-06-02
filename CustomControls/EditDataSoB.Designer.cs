namespace BookDealer.CustomControls
{
    partial class EditDataSoB
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
            BookNameTextBox = new TextBox();
            SCTextBox = new TextBox();
            btnOK = new Button();
            SumTextBox = new TextBox();
            CountTextBox = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(139, 213);
            label5.Name = "label5";
            label5.Size = new Size(70, 28);
            label5.TabIndex = 22;
            label5.Text = "Книга:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(139, 161);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 21;
            label4.Text = "Контракт:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(139, 113);
            label3.Name = "label3";
            label3.Size = new Size(113, 28);
            label3.TabIndex = 20;
            label3.Text = "Стоимость:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(139, 65);
            label2.Name = "label2";
            label2.Size = new Size(124, 28);
            label2.TabIndex = 19;
            label2.Text = "Количество:";
            // 
            // BookNameTextBox
            // 
            BookNameTextBox.Location = new Point(330, 213);
            BookNameTextBox.Name = "BookNameTextBox";
            BookNameTextBox.ReadOnly = true;
            BookNameTextBox.Size = new Size(240, 27);
            BookNameTextBox.TabIndex = 17;
            // 
            // SCTextBox
            // 
            SCTextBox.Location = new Point(330, 161);
            SCTextBox.Name = "SCTextBox";
            SCTextBox.ReadOnly = true;
            SCTextBox.Size = new Size(240, 27);
            SCTextBox.TabIndex = 16;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(267, 282);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 15;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // SumTextBox
            // 
            SumTextBox.Location = new Point(330, 113);
            SumTextBox.Name = "SumTextBox";
            SumTextBox.ReadOnly = true;
            SumTextBox.Size = new Size(240, 27);
            SumTextBox.TabIndex = 14;
            // 
            // CountTextBox
            // 
            CountTextBox.Location = new Point(330, 65);
            CountTextBox.Name = "CountTextBox";
            CountTextBox.Size = new Size(240, 27);
            CountTextBox.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(139, 21);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 24;
            label1.Text = "Номер заказа:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(330, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 27);
            textBox1.TabIndex = 23;
            // 
            // EditDataSoB
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 350);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BookNameTextBox);
            Controls.Add(SCTextBox);
            Controls.Add(btnOK);
            Controls.Add(SumTextBox);
            Controls.Add(CountTextBox);
            Name = "EditDataSoB";
            Text = "EditDataSoB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        public TextBox BookNameTextBox;
        public TextBox SCTextBox;
        private Button btnOK;
        public TextBox SumTextBox;
        public TextBox CountTextBox;
        private Label label1;
        public TextBox textBox1;
    }
}