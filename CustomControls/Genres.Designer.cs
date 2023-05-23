namespace BookDealer.CustomControls
{
    partial class Genres
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            FromGenresButton = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromGenresButton, 0, 3);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(button2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8459091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.66628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 72.08897F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.39884567F));
            tableLayoutPanel1.Size = new Size(961, 567);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(410, 15);
            label1.Name = "label1";
            label1.Size = new Size(141, 31);
            label1.TabIndex = 0;
            label1.Text = "Жанры книг";
            // 
            // FromGenresButton
            // 
            FromGenresButton.Dock = DockStyle.Fill;
            FromGenresButton.Location = new Point(3, 526);
            FromGenresButton.Name = "FromGenresButton";
            FromGenresButton.Size = new Size(955, 38);
            FromGenresButton.TabIndex = 3;
            FromGenresButton.Text = "Назад";
            FromGenresButton.UseVisualStyleBackColor = true;
            FromGenresButton.Click += FromGenresButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(331, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(298, 397);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.UserAddedRow += dataGridView1_UserAddedRow;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(331, 67);
            button2.Name = "button2";
            button2.Size = new Size(298, 41);
            button2.TabIndex = 4;
            button2.Text = "Обновить таблицу";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Genres
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Genres";
            Size = new Size(961, 567);
            Load += Genres_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button FromGenresButton;
        private Button button2;
    }
}
