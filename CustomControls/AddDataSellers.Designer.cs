namespace BookDealer.CustomControls
{
    partial class AddDataSellers
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
            SellTextBox = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveButton = new Button();
            MidTextBox = new TextBox();
            SurTextBox = new TextBox();
            NameTextBox = new TextBox();
            SuspendLayout();
            // 
            // SellTextBox
            // 
            SellTextBox.Location = new Point(201, 273);
            SellTextBox.Name = "SellTextBox";
            SellTextBox.Size = new Size(193, 27);
            SellTextBox.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(110, 28);
            label7.Name = "label7";
            label7.Size = new Size(251, 31);
            label7.TabIndex = 39;
            label7.Text = "Добавление продавца";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(79, 269);
            label5.Name = "label5";
            label5.Size = new Size(100, 28);
            label5.TabIndex = 38;
            label5.Text = "Зарплата:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(79, 212);
            label3.Name = "label3";
            label3.Size = new Size(100, 28);
            label3.TabIndex = 36;
            label3.Text = "Отчество:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(79, 146);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 35;
            label2.Text = "Фамилия:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(79, 83);
            label1.Name = "label1";
            label1.Size = new Size(55, 28);
            label1.TabIndex = 34;
            label1.Text = "Имя:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(153, 340);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 33;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // MidTextBox
            // 
            MidTextBox.Location = new Point(201, 213);
            MidTextBox.Name = "MidTextBox";
            MidTextBox.Size = new Size(193, 27);
            MidTextBox.TabIndex = 32;
            // 
            // SurTextBox
            // 
            SurTextBox.Location = new Point(201, 150);
            SurTextBox.Name = "SurTextBox";
            SurTextBox.Size = new Size(193, 27);
            SurTextBox.TabIndex = 31;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(201, 87);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(193, 27);
            NameTextBox.TabIndex = 30;
            // 
            // AddDataSellers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 410);
            Controls.Add(SellTextBox);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(MidTextBox);
            Controls.Add(SurTextBox);
            Controls.Add(NameTextBox);
            Name = "AddDataSellers";
            Text = "AddDataSellers";
            Load += AddDataSellers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SellTextBox;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SaveButton;
        private TextBox MidTextBox;
        private TextBox SurTextBox;
        private TextBox NameTextBox;
    }
}