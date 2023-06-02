namespace BookDealer.CustomControls
{
    partial class EditDataProviders
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
            label2 = new Label();
            label1 = new Label();
            prNameTextBox = new TextBox();
            SaveButton = new Button();
            prAddrTextBox = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(121, 22);
            label7.Name = "label7";
            label7.Size = new Size(330, 31);
            label7.TabIndex = 23;
            label7.Text = "Редактирование поставщиков";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(120, 132);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 18;
            label2.Text = "Адрес:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(69, 73);
            label1.Name = "label1";
            label1.Size = new Size(219, 28);
            label1.TabIndex = 17;
            label1.Text = "Название поставщика:";
            // 
            // prNameTextBox
            // 
            prNameTextBox.Location = new Point(300, 73);
            prNameTextBox.Name = "prNameTextBox";
            prNameTextBox.Size = new Size(193, 27);
            prNameTextBox.TabIndex = 14;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(208, 202);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 24;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // prAddrTextBox
            // 
            prAddrTextBox.Location = new Point(300, 133);
            prAddrTextBox.Name = "prAddrTextBox";
            prAddrTextBox.Size = new Size(193, 27);
            prAddrTextBox.TabIndex = 25;
            // 
            // EditDataProviders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 268);
            Controls.Add(prAddrTextBox);
            Controls.Add(SaveButton);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(prNameTextBox);
            Name = "EditDataProviders";
            Text = "EditDataProviders";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox bookAuthorTextBox;
        private TextBox bookPriceTextBox;
        private TextBox prNameTextBox;
        private Button SaveButton;
        private TextBox prAddrTextBox;
    }
}