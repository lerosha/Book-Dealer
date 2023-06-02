namespace BookDealer.CustomControls
{
    partial class EditDataSellers
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
            SalTextBox = new TextBox();
            MidTextBox = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnOK = new Button();
            SurTextBox = new TextBox();
            NameTextBox = new TextBox();
            SuspendLayout();
            // 
            // SalTextBox
            // 
            SalTextBox.Location = new Point(362, 224);
            SalTextBox.Name = "SalTextBox";
            SalTextBox.Size = new Size(240, 27);
            SalTextBox.TabIndex = 49;
            // 
            // MidTextBox
            // 
            MidTextBox.Location = new Point(362, 179);
            MidTextBox.Name = "MidTextBox";
            MidTextBox.Size = new Size(240, 27);
            MidTextBox.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(162, 26);
            label6.Name = "label6";
            label6.Size = new Size(424, 31);
            label6.TabIndex = 47;
            label6.Text = "Редактиование информации продавца";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(171, 223);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 46;
            label4.Text = "Зарплата:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(171, 175);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 45;
            label3.Text = "Отчество:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(171, 127);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 44;
            label2.Text = "Фамилия:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(171, 78);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 43;
            label1.Text = "Имя:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(295, 291);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 42;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // SurTextBox
            // 
            SurTextBox.Location = new Point(362, 127);
            SurTextBox.Name = "SurTextBox";
            SurTextBox.Size = new Size(240, 27);
            SurTextBox.TabIndex = 41;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(362, 78);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(240, 27);
            NameTextBox.TabIndex = 40;
            // 
            // EditDataSellers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 353);
            Controls.Add(SalTextBox);
            Controls.Add(MidTextBox);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(SurTextBox);
            Controls.Add(NameTextBox);
            Name = "EditDataSellers";
            Text = "EditDataSellers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox SalTextBox;
        public TextBox MidTextBox;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnOK;
        public TextBox SurTextBox;
        public TextBox NameTextBox;
    }
}