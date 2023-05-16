namespace BookDealer.CustomControls
{
    partial class Storage
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
            FromStorageButton = new Button();
            Storagedb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveStorageDB = new Button();
            UpdateStorageDB = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Storagedb).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromStorageButton, 0, 3);
            tableLayoutPanel1.Controls.Add(Storagedb, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8459091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.66628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.0344849F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.505747F));
            tableLayoutPanel1.Size = new Size(923, 438);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(423, 8);
            label1.Name = "label1";
            label1.Size = new Size(76, 31);
            label1.TabIndex = 0;
            label1.Text = "Склад";
            // 
            // FromStorageButton
            // 
            FromStorageButton.Dock = DockStyle.Fill;
            FromStorageButton.Location = new Point(3, 402);
            FromStorageButton.Name = "FromStorageButton";
            FromStorageButton.Size = new Size(917, 33);
            FromStorageButton.TabIndex = 3;
            FromStorageButton.Text = "Назад";
            FromStorageButton.UseVisualStyleBackColor = true;
            FromStorageButton.Click += FromStorageButton_Click;
            // 
            // Storagedb
            // 
            Storagedb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Storagedb.Dock = DockStyle.Fill;
            Storagedb.Location = new Point(3, 92);
            Storagedb.Name = "Storagedb";
            Storagedb.RowHeadersWidth = 51;
            Storagedb.RowTemplate.Height = 29;
            Storagedb.Size = new Size(917, 304);
            Storagedb.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveStorageDB, 1, 0);
            tableLayoutPanel2.Controls.Add(UpdateStorageDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(917, 36);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveStorageDB
            // 
            SaveStorageDB.Anchor = AnchorStyles.Right;
            SaveStorageDB.Location = new Point(766, 3);
            SaveStorageDB.Name = "SaveStorageDB";
            SaveStorageDB.Size = new Size(148, 29);
            SaveStorageDB.TabIndex = 0;
            SaveStorageDB.Text = "Сохранить отчет";
            SaveStorageDB.UseVisualStyleBackColor = true;
            // 
            // UpdateStorageDB
            // 
            UpdateStorageDB.Dock = DockStyle.Right;
            UpdateStorageDB.Location = new Point(605, 3);
            UpdateStorageDB.Name = "UpdateStorageDB";
            UpdateStorageDB.Size = new Size(148, 30);
            UpdateStorageDB.TabIndex = 1;
            UpdateStorageDB.Text = "Обновить таблицу";
            UpdateStorageDB.UseVisualStyleBackColor = true;
            // 
            // Storage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Storage";
            Size = new Size(923, 438);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Storagedb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromStorageButton;
        private DataGridView Storagedb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveStorageDB;
        private Button UpdateStorageDB;
    }
}
