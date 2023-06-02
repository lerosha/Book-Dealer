namespace BookDealer.CustomControls
{
    partial class AddDataProviders
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
            prAddAddrTextBox = new TextBox();
            prAddNameTextBox = new TextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(230, 22);
            label7.Name = "label7";
            label7.Size = new Size(273, 31);
            label7.TabIndex = 18;
            label7.Text = "Добавление поставщика";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(176, 144);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 17;
            label2.Text = "Адрес:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(150, 78);
            label1.Name = "label1";
            label1.Size = new Size(118, 28);
            label1.TabIndex = 16;
            label1.Text = "Поставщик:";
            // 
            // prAddAddrTextBox
            // 
            prAddAddrTextBox.Location = new Point(330, 145);
            prAddAddrTextBox.Name = "prAddAddrTextBox";
            prAddAddrTextBox.Size = new Size(193, 27);
            prAddAddrTextBox.TabIndex = 15;
            // 
            // prAddNameTextBox
            // 
            prAddNameTextBox.Location = new Point(330, 82);
            prAddNameTextBox.Name = "prAddNameTextBox";
            prAddNameTextBox.Size = new Size(193, 27);
            prAddNameTextBox.TabIndex = 14;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(246, 215);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 19;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // AddDataProviders
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 275);
            Controls.Add(SaveButton);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(prAddAddrTextBox);
            Controls.Add(prAddNameTextBox);
            Name = "AddDataProviders";
            Text = "AddDataProviders";
            Load += AddDataProviders_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label2;
        private Label label1;
        private TextBox prAddAddrTextBox;
        private TextBox prAddNameTextBox;
        private Button SaveButton;
    }
}