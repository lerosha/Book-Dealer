namespace BookDealer.CustomControls
{
    partial class SupplyContracts
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
            FromSupplyButton = new Button();
            Suppludb = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveSupplyDB = new Button();
            UpdateSupplyDB = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Suppludb).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(FromSupplyButton, 0, 3);
            tableLayoutPanel1.Controls.Add(Suppludb, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8459091F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.66628F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.0344849F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.505747F));
            tableLayoutPanel1.Size = new Size(917, 432);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(334, 7);
            label1.Name = "label1";
            label1.Size = new Size(249, 31);
            label1.TabIndex = 0;
            label1.Text = "Договоры на поставку";
            // 
            // FromSupplyButton
            // 
            FromSupplyButton.Dock = DockStyle.Fill;
            FromSupplyButton.Location = new Point(3, 396);
            FromSupplyButton.Name = "FromSupplyButton";
            FromSupplyButton.Size = new Size(911, 33);
            FromSupplyButton.TabIndex = 3;
            FromSupplyButton.Text = "Назад";
            FromSupplyButton.UseVisualStyleBackColor = true;
            FromSupplyButton.Click += FromSupplyButton_Click;
            // 
            // Suppludb
            // 
            Suppludb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Suppludb.Dock = DockStyle.Fill;
            Suppludb.Location = new Point(3, 90);
            Suppludb.Name = "Suppludb";
            Suppludb.RowHeadersWidth = 51;
            Suppludb.RowTemplate.Height = 29;
            Suppludb.Size = new Size(911, 300);
            Suppludb.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(SaveSupplyDB, 1, 0);
            tableLayoutPanel2.Controls.Add(UpdateSupplyDB, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 49);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(911, 35);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // SaveSupplyDB
            // 
            SaveSupplyDB.Anchor = AnchorStyles.Right;
            SaveSupplyDB.Location = new Point(760, 3);
            SaveSupplyDB.Name = "SaveSupplyDB";
            SaveSupplyDB.Size = new Size(148, 29);
            SaveSupplyDB.TabIndex = 0;
            SaveSupplyDB.Text = "Сохранить отчет";
            SaveSupplyDB.UseVisualStyleBackColor = true;
            // 
            // UpdateSupplyDB
            // 
            UpdateSupplyDB.Dock = DockStyle.Right;
            UpdateSupplyDB.Location = new Point(600, 3);
            UpdateSupplyDB.Name = "UpdateSupplyDB";
            UpdateSupplyDB.Size = new Size(148, 29);
            UpdateSupplyDB.TabIndex = 1;
            UpdateSupplyDB.Text = "Обновить таблицу";
            UpdateSupplyDB.UseVisualStyleBackColor = true;
            // 
            // SupplyContracts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SupplyContracts";
            Size = new Size(917, 432);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Suppludb).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button FromSupplyButton;
        private DataGridView Suppludb;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveSupplyDB;
        private Button UpdateSupplyDB;
    }
}
