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
            goodsControl1 = new CustomControls.GoodsControl();
            genres1 = new CustomControls.Genres();
            books1 = new CustomControls.Books();
            storage1 = new CustomControls.Storage();
            listOfBooks1 = new CustomControls.ListOfBooks();
            setsOfBooks1 = new CustomControls.SetsOfBooks();
            orders1 = new CustomControls.Orders();
            Contracts = new TabPage();
            contractsControl1 = new CustomControls.ContractsControl();
            supplyContracts1 = new CustomControls.SupplyContracts();
            salesContracts1 = new CustomControls.SalesContracts();
            Clients = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            UpdateDBClient = new Button();
            SaveDataClients = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            Clientsdb = new DataGridView();
            label1 = new Label();
            Publishers = new TabPage();
            tableLayoutPanel6 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            UpdateDBPublishers = new Button();
            SaveDataPublishers = new Button();
            Publishersdb = new DataGridView();
            label3 = new Label();
            Providers = new TabPage();
            tableLayoutPanel8 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            UpdateDBProviders = new Button();
            SaveDataProviders = new Button();
            Providersdb = new DataGridView();
            label4 = new Label();
            Sellers = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            UpdateDBSellers = new Button();
            SaveDataSellers = new Button();
            label2 = new Label();
            Sellersdb = new DataGridView();
            Exit = new Button();
            Menu.SuspendLayout();
            tabControl.SuspendLayout();
            Goods.SuspendLayout();
            Contracts.SuspendLayout();
            Clients.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Clientsdb).BeginInit();
            Publishers.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Publishersdb).BeginInit();
            Providers.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Providersdb).BeginInit();
            Sellers.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Sellersdb).BeginInit();
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
            Goods.Controls.Add(goodsControl1);
            Goods.Controls.Add(genres1);
            Goods.Controls.Add(books1);
            Goods.Controls.Add(storage1);
            Goods.Controls.Add(listOfBooks1);
            Goods.Controls.Add(setsOfBooks1);
            Goods.Controls.Add(orders1);
            Goods.Location = new Point(4, 29);
            Goods.Name = "Goods";
            Goods.Padding = new Padding(3);
            Goods.Size = new Size(929, 444);
            Goods.TabIndex = 0;
            Goods.Text = "Товары";
            // 
            // goodsControl1
            // 
            goodsControl1.Dock = DockStyle.Fill;
            goodsControl1.Location = new Point(3, 3);
            goodsControl1.Name = "goodsControl1";
            goodsControl1.Size = new Size(923, 438);
            goodsControl1.TabIndex = 0;
            // 
            // genres1
            // 
            genres1.Location = new Point(6, 3);
            genres1.Name = "genres1";
            genres1.Size = new Size(920, 435);
            genres1.TabIndex = 1;
            // 
            // books1
            // 
            books1.Location = new Point(6, 6);
            books1.Name = "books1";
            books1.Size = new Size(917, 435);
            books1.TabIndex = 2;
            // 
            // storage1
            // 
            storage1.Location = new Point(3, 3);
            storage1.Name = "storage1";
            storage1.Size = new Size(923, 435);
            storage1.TabIndex = 3;
            // 
            // listOfBooks1
            // 
            listOfBooks1.Location = new Point(3, 3);
            listOfBooks1.Name = "listOfBooks1";
            listOfBooks1.Size = new Size(923, 435);
            listOfBooks1.TabIndex = 4;
            // 
            // setsOfBooks1
            // 
            setsOfBooks1.Location = new Point(3, 3);
            setsOfBooks1.Name = "setsOfBooks1";
            setsOfBooks1.Size = new Size(923, 438);
            setsOfBooks1.TabIndex = 5;
            // 
            // orders1
            // 
            orders1.Location = new Point(6, 6);
            orders1.Name = "orders1";
            orders1.Size = new Size(918, 438);
            orders1.TabIndex = 6;
            // 
            // Contracts
            // 
            Contracts.BackColor = Color.Transparent;
            Contracts.Controls.Add(contractsControl1);
            Contracts.Controls.Add(supplyContracts1);
            Contracts.Controls.Add(salesContracts1);
            Contracts.Location = new Point(4, 29);
            Contracts.Name = "Contracts";
            Contracts.Padding = new Padding(3);
            Contracts.Size = new Size(192, 67);
            Contracts.TabIndex = 1;
            Contracts.Text = "Договоры";
            // 
            // contractsControl1
            // 
            contractsControl1.Dock = DockStyle.Fill;
            contractsControl1.Location = new Point(3, 3);
            contractsControl1.Name = "contractsControl1";
            contractsControl1.Size = new Size(186, 61);
            contractsControl1.TabIndex = 1;
            // 
            // supplyContracts1
            // 
            supplyContracts1.Dock = DockStyle.Fill;
            supplyContracts1.Location = new Point(3, 3);
            supplyContracts1.Name = "supplyContracts1";
            supplyContracts1.Size = new Size(186, 61);
            supplyContracts1.TabIndex = 0;
            // 
            // salesContracts1
            // 
            salesContracts1.Location = new Point(3, 3);
            salesContracts1.Name = "salesContracts1";
            salesContracts1.Size = new Size(923, 438);
            salesContracts1.TabIndex = 2;
            // 
            // Clients
            // 
            Clients.Controls.Add(tableLayoutPanel1);
            Clients.Location = new Point(4, 29);
            Clients.Name = "Clients";
            Clients.Size = new Size(192, 67);
            Clients.TabIndex = 2;
            Clients.Text = "Клиенты";
            Clients.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.237875F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80.8314056F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(192, 67);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel2.Controls.Add(UpdateDBClient, 0, 0);
            tableLayoutPanel2.Controls.Add(SaveDataClients, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 9);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(186, 1);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // UpdateDBClient
            // 
            UpdateDBClient.Dock = DockStyle.Right;
            UpdateDBClient.Location = new Point(3, 3);
            UpdateDBClient.Name = "UpdateDBClient";
            UpdateDBClient.Size = new Size(147, 1);
            UpdateDBClient.TabIndex = 0;
            UpdateDBClient.Text = "Обновить таблицу";
            UpdateDBClient.UseVisualStyleBackColor = true;
            UpdateDBClient.Click += UpdateDB_Click;
            // 
            // SaveDataClients
            // 
            SaveDataClients.Dock = DockStyle.Right;
            SaveDataClients.Location = new Point(156, 3);
            SaveDataClients.Name = "SaveDataClients";
            SaveDataClients.Size = new Size(27, 1);
            SaveDataClients.TabIndex = 1;
            SaveDataClients.Text = "Сохранить отчет";
            SaveDataClients.UseVisualStyleBackColor = true;
            SaveDataClients.Click += SaveDataClients_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(Clientsdb, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 15);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(186, 49);
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
            Clientsdb.Size = new Size(180, 43);
            Clientsdb.TabIndex = 0;
            Clientsdb.CellContentClick += Clientsdb_CellContentClick;
            Clientsdb.CellValueChanged += Clientsdb_CellValueChanged;
            Clientsdb.DataBindingComplete += Clientsdb_DataBindingComplete;
            Clientsdb.UserAddedRow += Clientsdb_UserAddedRow;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 6);
            label1.TabIndex = 0;
            label1.Text = "Клиенты";
            // 
            // Publishers
            // 
            Publishers.Controls.Add(tableLayoutPanel6);
            Publishers.Location = new Point(4, 29);
            Publishers.Name = "Publishers";
            Publishers.Size = new Size(192, 67);
            Publishers.TabIndex = 3;
            Publishers.Text = "Издательства";
            Publishers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Controls.Add(tableLayoutPanel7, 0, 1);
            tableLayoutPanel6.Controls.Add(Publishersdb, 0, 2);
            tableLayoutPanel6.Controls.Add(label3, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(0, 0);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 3;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 9.993005F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 9.233537F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 80.77346F));
            tableLayoutPanel6.Size = new Size(192, 67);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel7.Controls.Add(UpdateDBPublishers, 0, 0);
            tableLayoutPanel7.Controls.Add(SaveDataPublishers, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 9);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Size = new Size(186, 1);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // UpdateDBPublishers
            // 
            UpdateDBPublishers.Dock = DockStyle.Right;
            UpdateDBPublishers.Location = new Point(3, 3);
            UpdateDBPublishers.Name = "UpdateDBPublishers";
            UpdateDBPublishers.Size = new Size(147, 1);
            UpdateDBPublishers.TabIndex = 1;
            UpdateDBPublishers.Text = "Обновить таблицу";
            UpdateDBPublishers.UseVisualStyleBackColor = true;
            UpdateDBPublishers.Click += UpdateDBPublishers_Click;
            // 
            // SaveDataPublishers
            // 
            SaveDataPublishers.Dock = DockStyle.Right;
            SaveDataPublishers.Location = new Point(156, 3);
            SaveDataPublishers.Name = "SaveDataPublishers";
            SaveDataPublishers.Size = new Size(27, 1);
            SaveDataPublishers.TabIndex = 2;
            SaveDataPublishers.Text = "Сохранить отчет";
            SaveDataPublishers.UseVisualStyleBackColor = true;
            SaveDataPublishers.Click += SaveDataPublishers_Click;
            // 
            // Publishersdb
            // 
            Publishersdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Publishersdb.Dock = DockStyle.Fill;
            Publishersdb.Location = new Point(3, 15);
            Publishersdb.Name = "Publishersdb";
            Publishersdb.RowHeadersWidth = 51;
            Publishersdb.RowTemplate.Height = 29;
            Publishersdb.Size = new Size(186, 49);
            Publishersdb.TabIndex = 1;
            Publishersdb.CellContentClick += Publishersdb_CellContentClick;
            Publishersdb.CellValueChanged += Publishersdb_CellValueChanged;
            Publishersdb.UserAddedRow += Publishersdb_UserAddedRow;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 6);
            label3.TabIndex = 2;
            label3.Text = "Издательства";
            // 
            // Providers
            // 
            Providers.Controls.Add(tableLayoutPanel8);
            Providers.Location = new Point(4, 29);
            Providers.Name = "Providers";
            Providers.Size = new Size(192, 67);
            Providers.TabIndex = 4;
            Providers.Text = "Поставщики";
            Providers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel8.Controls.Add(Providersdb, 0, 2);
            tableLayoutPanel8.Controls.Add(label4, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(0, 0);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 3;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 9.993005F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 9.233537F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 80.77346F));
            tableLayoutPanel8.Size = new Size(192, 67);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel9.Controls.Add(UpdateDBProviders, 0, 0);
            tableLayoutPanel9.Controls.Add(SaveDataProviders, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 9);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(186, 1);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // UpdateDBProviders
            // 
            UpdateDBProviders.Dock = DockStyle.Right;
            UpdateDBProviders.Location = new Point(3, 3);
            UpdateDBProviders.Name = "UpdateDBProviders";
            UpdateDBProviders.Size = new Size(147, 1);
            UpdateDBProviders.TabIndex = 0;
            UpdateDBProviders.Text = "Обновить таблицу";
            UpdateDBProviders.UseVisualStyleBackColor = true;
            UpdateDBProviders.Click += UpdateDBProviders_Click;
            // 
            // SaveDataProviders
            // 
            SaveDataProviders.Dock = DockStyle.Right;
            SaveDataProviders.Location = new Point(156, 3);
            SaveDataProviders.Name = "SaveDataProviders";
            SaveDataProviders.Size = new Size(27, 1);
            SaveDataProviders.TabIndex = 1;
            SaveDataProviders.Text = "Сохранить отчет";
            SaveDataProviders.UseVisualStyleBackColor = true;
            SaveDataProviders.Click += SaveDataProviders_Click;
            // 
            // Providersdb
            // 
            Providersdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Providersdb.Dock = DockStyle.Fill;
            Providersdb.Location = new Point(3, 15);
            Providersdb.Name = "Providersdb";
            Providersdb.RowHeadersWidth = 51;
            Providersdb.RowTemplate.Height = 29;
            Providersdb.Size = new Size(186, 49);
            Providersdb.TabIndex = 1;
            Providersdb.CellContentClick += Providersdb_CellContentClick;
            Providersdb.CellValueChanged += Providersdb_CellValueChanged;
            Providersdb.UserAddedRow += Providersdb_UserAddedRow;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(24, 0);
            label4.Name = "label4";
            label4.Size = new Size(143, 6);
            label4.TabIndex = 2;
            label4.Text = "Поставщики";
            // 
            // Sellers
            // 
            Sellers.Controls.Add(tableLayoutPanel4);
            Sellers.Location = new Point(4, 29);
            Sellers.Name = "Sellers";
            Sellers.Size = new Size(929, 444);
            Sellers.TabIndex = 5;
            Sellers.Text = "Продавцы";
            Sellers.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(Sellersdb, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.993005F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 9.233537F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80.77346F));
            tableLayoutPanel4.Size = new Size(929, 444);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.47F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.53F));
            tableLayoutPanel5.Controls.Add(UpdateDBSellers, 0, 0);
            tableLayoutPanel5.Controls.Add(SaveDataSellers, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 47);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(923, 34);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // UpdateDBSellers
            // 
            UpdateDBSellers.Dock = DockStyle.Right;
            UpdateDBSellers.Location = new Point(611, 3);
            UpdateDBSellers.Name = "UpdateDBSellers";
            UpdateDBSellers.Size = new Size(147, 28);
            UpdateDBSellers.TabIndex = 1;
            UpdateDBSellers.Text = "Обновить таблицу";
            UpdateDBSellers.UseVisualStyleBackColor = true;
            UpdateDBSellers.Click += UpdateDBSellers_Click;
            // 
            // SaveDataSellers
            // 
            SaveDataSellers.Dock = DockStyle.Right;
            SaveDataSellers.Location = new Point(893, 3);
            SaveDataSellers.Name = "SaveDataSellers";
            SaveDataSellers.Size = new Size(27, 28);
            SaveDataSellers.TabIndex = 2;
            SaveDataSellers.Text = "Сохранить отчет";
            SaveDataSellers.UseVisualStyleBackColor = true;
            SaveDataSellers.Click += SaveDataSellers_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(402, 6);
            label2.Name = "label2";
            label2.Size = new Size(124, 31);
            label2.TabIndex = 1;
            label2.Text = "Продавцы";
            // 
            // Sellersdb
            // 
            Sellersdb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Sellersdb.Dock = DockStyle.Fill;
            Sellersdb.Location = new Point(3, 87);
            Sellersdb.Name = "Sellersdb";
            Sellersdb.RowHeadersWidth = 51;
            Sellersdb.RowTemplate.Height = 29;
            Sellersdb.Size = new Size(923, 354);
            Sellersdb.TabIndex = 2;
            Sellersdb.CellContentClick += Sellersdb_CellContentClick;
            Sellersdb.CellValueChanged += Sellersdb_CellValueChanged;
            Sellersdb.UserAddedRow += Sellersdb_UserAddedRow;
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
            Contracts.ResumeLayout(false);
            Clients.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Clientsdb).EndInit();
            Publishers.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Publishersdb).EndInit();
            Providers.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Providersdb).EndInit();
            Sellers.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Sellersdb).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel Menu;
        private Button Exit;
        private TabControl tabControl;
        private TabPage Goods;
        private TabPage Contracts;
        private TabPage Clients;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button UpdateDBClient;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView Clientsdb;
        private Label label1;
        private TabPage Publishers;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Button UpdateDBPublishers;
        private DataGridView Publishersdb;
        private Label label3;
        private TabPage Providers;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private Button UpdateDBProviders;
        private DataGridView Providersdb;
        private Label label4;
        private TabPage Sellers;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button UpdateDBSellers;
        private Label label2;
        private DataGridView Sellersdb;
        private CustomControls.GoodsControl goodsControl1;
        private CustomControls.Genres genres1;
        private CustomControls.Books books1;
        private CustomControls.Storage storage1;
        private CustomControls.ListOfBooks listOfBooks1;
        private CustomControls.SetsOfBooks setsOfBooks1;
        private CustomControls.Orders orders1;
        private CustomControls.ContractsControl contractsControl1;
        private CustomControls.SupplyContracts supplyContracts1;
        private CustomControls.SalesContracts salesContracts1;
        private Button SaveDataClients;
        private Button SaveDataPublishers;
        private Button SaveDataProviders;
        private Button SaveDataSellers;
    }
}