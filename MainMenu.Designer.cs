namespace BookDealer
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu = new TableLayoutPanel();
            tabControl = new TabControl();
            Goods = new TabPage();
            dataGridView1 = new DataGridView();
            Contracts = new TabPage();
            Clients = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            SaveData = new Button();
            UpdateDBClient = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            Clientsdb = new DataGridView();
            Publishers = new TabPage();
            Providers = new TabPage();
            Sellers = new TabPage();
            Exit = new Button();
            Menu.SuspendLayout();
            tabControl.SuspendLayout();
            Goods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Clients.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Clientsdb).BeginInit();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.ColumnCount = 1;
            Menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Menu.Controls.Add(tabControl, 0, 0);
            Menu.Controls.Add(Exit, 0, 1);
            Menu.Dock = DockStyle.Fill;
            Menu.Location = new Point(0, 0);
            Menu.Name = "Menu";
            Menu.RowCount = 2;
            Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 93F));
            Menu.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            Menu.Size = new Size(943, 520);
            Menu.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(Goods);
            tabControl.Controls.Add(Contracts);
            tabControl.Controls.Add(Clients);
            tabControl.Controls.Add(Publishers);
            tabControl.Controls.Add(Providers);
            tabControl.Controls.Add(Sellers);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(937, 477);
            tabControl.TabIndex = 0;
            // 
            // Goods
            // 
            Goods.BackColor = Color.Transparent;
            Goods.Controls.Add(dataGridView1);
            Goods.Location = new Point(4, 29);
            Goods.Name = "Goods";
            Goods.Padding = new Padding(3);
            Goods.Size = new Size(929, 444);
            Goods.TabIndex = 0;
            Goods.Text = "Товары";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(105, 52);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(478, 269);
            dataGridView1.TabIndex = 0;
            // 
            // Contracts
            // 
            Contracts.BackColor = Color.Transparent;
            Contracts.Location = new Point(4, 29);
            Contracts.Name = "Contracts";
            Contracts.Padding = new Padding(3);
            Contracts.Size = new Size(929, 444);
            Contracts.TabIndex = 1;
            Contracts.Text = "Договоры";
            // 
            // Clients
            // 
            Clients.Controls.Add(tableLayoutPanel1);
            Clients.Location = new Point(4, 29);
            Clients.Name = "Clients";
            Clients.Size = new Size(929, 444);
            Clients.TabIndex = 2;
            Clients.Text = "Клиенты";
            Clients.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.237875F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.8314056F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(929, 444);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(413, 6);
            label1.Name = "label1";
            label1.Size = new Size(102, 31);
            label1.TabIndex = 0;
            label1.Text = "Клиенты";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.4660645F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.5339375F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(SaveData, 1, 0);
            tableLayoutPanel2.Controls.Add(UpdateDBClient, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 47);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(923, 34);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // SaveData
            // 
            SaveData.Anchor = AnchorStyles.Right;
            SaveData.Location = new Point(772, 3);
            SaveData.Name = "SaveData";
            SaveData.Size = new Size(148, 27);
            SaveData.TabIndex = 1;
            SaveData.Text = "Сохранить очет";
            SaveData.UseVisualStyleBackColor = true;
            // 
            // UpdateDBClient
            // 
            UpdateDBClient.Dock = DockStyle.Right;
            UpdateDBClient.Location = new Point(610, 3);
            UpdateDBClient.Name = "UpdateDBClient";
            UpdateDBClient.Size = new Size(148, 28);
            UpdateDBClient.TabIndex = 0;
            UpdateDBClient.Text = "Обновить таблицу";
            UpdateDBClient.UseVisualStyleBackColor = true;
            UpdateDBClient.Click += UpdateDB_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(Clientsdb, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 87);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(923, 354);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // Clientsdb
            // 
            Clientsdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Clientsdb.Dock = DockStyle.Fill;
            Clientsdb.Location = new Point(3, 3);
            Clientsdb.Name = "Clientsdb";
            Clientsdb.RowHeadersWidth = 51;
            Clientsdb.RowTemplate.Height = 29;
            Clientsdb.Size = new Size(917, 348);
            Clientsdb.TabIndex = 0;
            Clientsdb.CellContentClick += Clientsdb_CellContentClick;
            Clientsdb.CellValueChanged += Clientsdb_CellValueChanged;
            Clientsdb.DataBindingComplete += Clientsdb_DataBindingComplete;
            Clientsdb.UserAddedRow += Clientsdb_UserAddedRow;
            // 
            // Publishers
            // 
            Publishers.Location = new Point(4, 29);
            Publishers.Name = "Publishers";
            Publishers.Size = new Size(929, 444);
            Publishers.TabIndex = 3;
            Publishers.Text = "Издательства";
            Publishers.UseVisualStyleBackColor = true;
            // 
            // Providers
            // 
            Providers.Location = new Point(4, 29);
            Providers.Name = "Providers";
            Providers.Size = new Size(929, 444);
            Providers.TabIndex = 4;
            Providers.Text = "Поставщики";
            Providers.UseVisualStyleBackColor = true;
            // 
            // Sellers
            // 
            Sellers.Location = new Point(4, 29);
            Sellers.Name = "Sellers";
            Sellers.Size = new Size(929, 444);
            Sellers.TabIndex = 5;
            Sellers.Text = "Продавцы";
            Sellers.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            Exit.Dock = DockStyle.Fill;
            Exit.Location = new Point(3, 486);
            Exit.Name = "Exit";
            Exit.Size = new Size(937, 31);
            Exit.TabIndex = 1;
            Exit.Text = "Выйти";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 520);
            Controls.Add(Menu);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            Menu.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            Goods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Clients.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Clientsdb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Menu;
        private TabControl tabControl;
        private TabPage Goods;
        private TabPage Contracts;
        private TabPage Clients;
        private TabPage Publishers;
        private TabPage Providers;
        private TabPage Sellers;
        private Button Exit;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button SaveData;
        private Button UpdateDBClient;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView Clientsdb;
        private DataGridView dataGridView1;
    }
}