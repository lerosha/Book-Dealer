namespace BookDealer
{
    partial class EditDataStorage
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
            label4 = new Label();
            label1 = new Label();
            BookNameTextBox = new TextBox();
            btnOK = new Button();
            CountTextBox = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(96, 82);
            label4.Name = "label4";
            label4.Size = new Size(163, 28);
            label4.TabIndex = 23;
            label4.Text = "Название книги:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(96, 152);
            label1.Name = "label1";
            label1.Size = new Size(171, 28);
            label1.TabIndex = 20;
            label1.Text = "Количество книг:";
            // 
            // BookNameTextBox
            // 
            BookNameTextBox.Location = new Point(287, 82);
            BookNameTextBox.Name = "BookNameTextBox";
            BookNameTextBox.ReadOnly = true;
            BookNameTextBox.Size = new Size(240, 27);
            BookNameTextBox.TabIndex = 17;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(255, 229);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(142, 38);
            btnOK.TabIndex = 16;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // CountTextBox
            // 
            CountTextBox.Location = new Point(287, 152);
            CountTextBox.Name = "CountTextBox";
            CountTextBox.Size = new Size(240, 27);
            CountTextBox.TabIndex = 13;
            // 
            // EditDataStorage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 319);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(BookNameTextBox);
            Controls.Add(btnOK);
            Controls.Add(CountTextBox);
            Name = "EditDataStorage";
            Text = "EditDataStorage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label1;
        public TextBox BookNameTextBox;
        private Button btnOK;
        public TextBox CountTextBox;
    }
}