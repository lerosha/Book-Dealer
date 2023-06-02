namespace BookDealer.CustomControls
{
    partial class AddDataPublishers
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SaveButton = new Button();
            pubDirTextBox = new TextBox();
            pubAddrTextBox = new TextBox();
            pubNameTextBox = new TextBox();
            pubBankTextBox = new TextBox();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(224, 24);
            label7.Name = "label7";
            label7.Size = new Size(285, 31);
            label7.TabIndex = 27;
            label7.Text = "Добавление издательства";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(129, 267);
            label4.Name = "label4";
            label4.Size = new Size(168, 28);
            label4.TabIndex = 24;
            label4.Text = "Банковский счет:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(129, 200);
            label3.Name = "label3";
            label3.Size = new Size(163, 28);
            label3.TabIndex = 23;
            label3.Text = "ФИО директора:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(129, 138);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 22;
            label2.Text = "Адрес:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(129, 74);
            label1.Name = "label1";
            label1.Size = new Size(239, 28);
            label1.TabIndex = 21;
            label1.Text = "Навзвание издательства:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(295, 326);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(180, 33);
            SaveButton.TabIndex = 20;
            SaveButton.Text = "Добавить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // pubDirTextBox
            // 
            pubDirTextBox.Location = new Point(383, 204);
            pubDirTextBox.Name = "pubDirTextBox";
            pubDirTextBox.Size = new Size(257, 27);
            pubDirTextBox.TabIndex = 16;
            // 
            // pubAddrTextBox
            // 
            pubAddrTextBox.Location = new Point(383, 142);
            pubAddrTextBox.Name = "pubAddrTextBox";
            pubAddrTextBox.Size = new Size(257, 27);
            pubAddrTextBox.TabIndex = 15;
            // 
            // pubNameTextBox
            // 
            pubNameTextBox.Location = new Point(383, 78);
            pubNameTextBox.Name = "pubNameTextBox";
            pubNameTextBox.Size = new Size(257, 27);
            pubNameTextBox.TabIndex = 14;
            // 
            // pubBankTextBox
            // 
            pubBankTextBox.Location = new Point(383, 268);
            pubBankTextBox.Name = "pubBankTextBox";
            pubBankTextBox.Size = new Size(257, 27);
            pubBankTextBox.TabIndex = 28;
            // 
            // AddDataPublishers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 371);
            Controls.Add(pubBankTextBox);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SaveButton);
            Controls.Add(pubDirTextBox);
            Controls.Add(pubAddrTextBox);
            Controls.Add(pubNameTextBox);
            Name = "AddDataPublishers";
            Text = "AddDataPublishers";
            Load += AddDataPublishers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button SaveButton;
        private TextBox pubDirTextBox;
        private TextBox pubAddrTextBox;
        private TextBox pubNameTextBox;
        private TextBox pubBankTextBox;
    }
}