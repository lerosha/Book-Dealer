using BookDealer.CustomControls;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using NodaTime;
using Npgsql;
using NPOI.XWPF.UserModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace BookDealer
{
    public partial class MainMenu : Form
    {
        private NpgsqlConnection? connection = null;
        //private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        public MainMenu()
        {
            InitializeComponent();
            genres1.Visible = false;
            books1.Visible = false;
            storage1.Visible = false;
            listOfBooks1.Visible = false;
            setsOfBooks1.Visible = false;
            orders1.Visible = false;
            supplyContracts1.Visible = false;
            salesContracts1.Visible = false;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Клиенты
        public void LoadDataClients()
        {
            try
            {
                string query = "SELECT c.clientsid, c.name, c.surname, c.middlename, c.bankaccount, c.address, " +
                    "'Редактировать' AS Edit " +
               "FROM clients AS c";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Clientsdb.DataSource = bindingSource;
                Clientsdb.Columns["clientsid"].Visible = false;
                Clientsdb.Sort(Clientsdb.Columns["clientsid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControl(int clintId)
        {
            try
            {
                string query = "SELECT c.clientsid, c.name, c.surname, c.middlename, c.bankaccount, c.address, " +
                    "'Редактировать' AS Edit " +
               "FROM clients AS c " +
               "WHERE c.clientsid = @clientsid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@clientsid", clintId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "clients");

                if (dataSet.Tables["clients"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataClients = new EditDataClients();
                    editDataClients.ClientsName = dataSet.Tables["clients"].Rows[0]["name"].ToString();
                    editDataClients.Surname = dataSet.Tables["clients"].Rows[0]["surname"].ToString();
                    editDataClients.MiddelName = dataSet.Tables["clients"].Rows[0]["middlename"].ToString();
                    editDataClients.Bank = dataSet.Tables["clients"].Rows[0]["bankaccount"].ToString();
                    editDataClients.Address = dataSet.Tables["clients"].Rows[0]["address"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataClients.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string updatedName = editDataClients.ClientsName;
                        string updatedSur = editDataClients.Surname;
                        string updatedMid = editDataClients.MiddelName;
                        string updatedBank = editDataClients.Bank;
                        string updatedAddress = editDataClients.Address;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE clients SET name = @name, surname = @surname, middlename = @middlename, bankaccount = @bankaccount, address = @address WHERE clientsid = @clientsid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", updatedName);
                        updateCommand.Parameters.AddWithValue("@surname", updatedSur);
                        updateCommand.Parameters.AddWithValue("@middlename", updatedMid);
                        updateCommand.Parameters.AddWithValue("@bankaccount", updatedBank);
                        updateCommand.Parameters.AddWithValue("@address", updatedAddress);
                        updateCommand.Parameters.AddWithValue("@clientsid", clintId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["clients"].Rows[0];
                        updatedRow["name"] = updatedName;
                        updatedRow["surname"] = updatedSur;
                        updatedRow["middlename"] = updatedMid;
                        updatedRow["bankaccount"] = updatedBank;
                        updatedRow["address"] = updatedAddress;

                        int rowIndex = Clientsdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Clientsdb.Rows[rowIndex];
                        dataGridViewRow.Cells["name"].Value = updatedName;
                        dataGridViewRow.Cells["surname"].Value = updatedSur;
                        dataGridViewRow.Cells["middlename"].Value = updatedMid;
                        dataGridViewRow.Cells["bankaccount"].Value = updatedBank;
                        dataGridViewRow.Cells["address"].Value = updatedAddress;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Clientsdb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Книга с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadDataClients();
            LoadDataPublishers();
            LoadDataProiders();
            LoadDataSellers();
        }


        private void Clientsdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Clientsdb.Columns["Edit"].Index)
                {
                    int clientId = (int)Clientsdb.Rows[e.RowIndex].Cells["clientsid"].Value;
                    OpenCustomControl(clientId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void RefreshDataGridView()
        {
            string query = "SELECT c.clientsid, c.name, c.surname, c.middlename, c.bankaccount, c.address, " +
                    "'Редактировать' AS Edit " +
               "FROM clients AS c";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "clients");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Clientsdb.DataSource = dataSet.Tables["clients"];
        }

        private void OpenAddDataOrders()
        {
            var addDataClients = new AddDataClients();
            addDataClients.DataAdded += AddDataForm_DataAdded;
            addDataClients.ShowDialog();
        }
        private void AddDataForm_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridView();
        }
        private void AddDBClient_Click(object sender, EventArgs e)
        {
            OpenAddDataOrders();
            Clientsdb.Sort(Clientsdb.Columns["clientsid"], ListSortDirection.Ascending);
        }

        public void GenerateWordDocument(DataGridView dataGridView)
        {
            // Создание нового документа Word
            XWPFDocument document = new XWPFDocument();

            // Создание таблицы в документе
            XWPFTable table = document.CreateTable(dataGridView.Rows.Count, dataGridView.Columns.Count - 1);

            // Заполнение заголовков таблицы
            XWPFTableRow headerRow = table.GetRow(0);
            for (int i = 1; i < dataGridView.Columns.Count - 1; i++)
            {
                string headerText = dataGridView.Columns[i].HeaderText;
                headerRow.GetCell(i).SetText(headerText);
            }

            // Заполнение таблицы данными из DataGridView
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                XWPFTableRow row = table.GetRow(i + 1);
                for (int j = 1; j < dataGridView.Columns.Count - 1; j++)
                {
                    string cellValue = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? string.Empty;
                    row.GetCell(j).SetText(cellValue);
                }
            }

            // Отображение диалогового окна выбора пути сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохранение документа в выбранный путь
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    document.Write(fileStream);
                }
            }
        }

        private void SaveDataClients_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Clientsdb);
        }
        #endregion

        #region Издательства
        public void LoadDataPublishers()
        {
            try
            {
                string query = "SELECT p.publisherid, p.name, p.address, p.director, p.bankaccount, " +
                    "'Редактировать' AS Edit " +
               "FROM publishers AS p";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Publishersdb.DataSource = bindingSource;
                Publishersdb.Columns["publisherid"].Visible = false;
                Publishersdb.Sort(Publishersdb.Columns["publisherid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControlPublishers(int publisherId)
        {
            try
            {
                string query = "SELECT p.publisherid, p.name, p.address, p.director, p.bankaccount, " +
                    "'Редактировать' AS Edit " +
               "FROM publishers AS p " +
               "WHERE p.publisherid = @publisherid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@publisherid", publisherId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "publishers");

                if (dataSet.Tables["publishers"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataPublishers = new EditDataPublishers();
                    editDataPublishers.pubName = dataSet.Tables["publishers"].Rows[0]["name"].ToString();
                    editDataPublishers.pubAddress = dataSet.Tables["publishers"].Rows[0]["address"].ToString();
                    editDataPublishers.pubDir = dataSet.Tables["publishers"].Rows[0]["director"].ToString();
                    editDataPublishers.pubBank = dataSet.Tables["publishers"].Rows[0]["bankaccount"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataPublishers.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        // Получить обновленную дату из формы EditDataOrders
                        string updatedPubName = editDataPublishers.pubName;
                        string updatedPubAddress = editDataPublishers.pubAddress;
                        string updatedPubDir = editDataPublishers.pubDir;
                        string updatedPubBank = editDataPublishers.pubBank;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE publishers SET name = @name, address = @address, director = @director, bankaccount = @bankaccount WHERE publisherid = @publisherid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", updatedPubName);
                        updateCommand.Parameters.AddWithValue("@address", updatedPubAddress);
                        updateCommand.Parameters.AddWithValue("@director", updatedPubDir);
                        updateCommand.Parameters.AddWithValue("@bankaccount", updatedPubBank);
                        updateCommand.Parameters.AddWithValue("@publisherid", publisherId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["publishers"].Rows[0];
                        updatedRow["name"] = updatedPubName;
                        updatedRow["address"] = updatedPubAddress;
                        updatedRow["director"] = updatedPubDir;
                        updatedRow["bankaccount"] = updatedPubBank;

                        int rowIndex = Publishersdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Publishersdb.Rows[rowIndex];
                        dataGridViewRow.Cells["name"].Value = updatedPubName;
                        dataGridViewRow.Cells["address"].Value = updatedPubAddress;
                        dataGridViewRow.Cells["director"].Value = updatedPubDir;
                        dataGridViewRow.Cells["bankaccount"].Value = updatedPubBank;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Publishersdb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Книга с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Publishersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Publishersdb.Columns["Edit"].Index)
                {
                    int PublisherId = (int)Publishersdb.Rows[e.RowIndex].Cells["publisherid"].Value;
                    OpenCustomControlPublishers(PublisherId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshDataGridViewPublishers()
        {
            string query = "SELECT p.publisherid, p.name, p.address, p.director, p.bankaccount, " +
                    "'Редактировать' AS Edit " +
               "FROM publishers AS p";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "publishers");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Publishersdb.DataSource = dataSet.Tables["publishers"];
            Publishersdb.Columns["publisherid"].Visible = false;
        }

        private void OpenAddDataPublishers()
        {
            var addDataPub = new AddDataPublishers();
            addDataPub.DataAdded += AddDataPublishers_DataAdded;
            addDataPub.ShowDialog();
        }
        private void AddDataPublishers_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridViewPublishers();
        }
        private void AddDBPublishers_Click(object sender, EventArgs e)
        {
            OpenAddDataPublishers();
            Publishersdb.Sort(Publishersdb.Columns["publisherid"], ListSortDirection.Ascending);
        }

        private void SaveDataPublishers_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Publishersdb);
        }
        #endregion
        #region Поставщики

        public void LoadDataProiders()
        {
            try
            {
                string query = "SELECT p.providerid, p.name, p.address, " +
                    "'Редактировать' AS Edit " +
               "FROM providers AS p";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Providersdb.DataSource = bindingSource;
                Providersdb.Columns["providerid"].Visible = false;
                Providersdb.Sort(Providersdb.Columns["providerid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControlProviders(int providerId)
        {
            try
            {
                string query = "SELECT p.providerid, p.name, p.address, " +
                    "'Редактировать' AS Edit " +
               "FROM providers AS p " +
               "WHERE p.providerid = @providerid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@providerid", providerId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "providers");

                if (dataSet.Tables["providers"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataProviders = new EditDataProviders();
                    editDataProviders.prName = dataSet.Tables["providers"].Rows[0]["name"].ToString();
                    editDataProviders.prAddr = dataSet.Tables["providers"].Rows[0]["address"].ToString();
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataProviders.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string updateName = editDataProviders.prName;
                        string updatedAddr = editDataProviders.prAddr;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE providers SET name = @name, address = @address WHERE providerid = @providerid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", updateName);
                        updateCommand.Parameters.AddWithValue("@address", updatedAddr);
                        updateCommand.Parameters.AddWithValue("@providerid", providerId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["providers"].Rows[0];
                        updatedRow["name"] = updateName;
                        updatedRow["address"] = updatedAddr;

                        int rowIndex = Providersdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Providersdb.Rows[rowIndex];
                        dataGridViewRow.Cells["name"].Value = updateName;
                        dataGridViewRow.Cells["address"].Value = updatedAddr;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Providersdb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Книга с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Providersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Providersdb.Columns["Edit"].Index)
                {
                    int providerId = (int)Providersdb.Rows[e.RowIndex].Cells["providerid"].Value;
                    OpenCustomControlProviders(providerId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshDataGridViewProviders()
        {
            string query = "SELECT p.providerid, p.name, p.address, " +
                    "'Редактировать' AS Edit " +
               "FROM providers AS p";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "providers");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Providersdb.DataSource = dataSet.Tables["providers"];
            Providersdb.Columns["providerid"].Visible = false;
        }

        private void OpenAddDataProviders()
        {
            var addDataProv = new AddDataProviders();
            addDataProv.DataAdded += AddDataProviders_DataAdded;
            addDataProv.ShowDialog();
        }
        private void AddDataProviders_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridViewProviders();
        }

        private void AddProviders_Click(object sender, EventArgs e)
        {
            OpenAddDataProviders();
            Providersdb.Sort(Providersdb.Columns["providerid"], ListSortDirection.Ascending);
        }

        private void SaveDataProviders_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Providersdb);
        }

        #endregion
        #region Продавцы
        public void LoadDataSellers()
        {
            try
            {
                string query = "SELECT s.sellerid, s.name, s.surname, s.middlename, s.salary, " +
                    "'Редактировать' AS Edit " +
               "FROM sellers AS s";

                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                dataAdapter = adapter;

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Result");

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataSet.Tables["Result"];
                Sellersdb.DataSource = bindingSource;
                Sellersdb.Columns["sellerid"].Visible = false;
                Sellersdb.Sort(Sellersdb.Columns["sellerid"], ListSortDirection.Ascending);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCustomControlSellers(int sellerId)
        {
            try
            {
                string query = "SELECT s.sellerid, s.name, s.surname, s.middlename, s.salary, " +
                    "'Редактировать' AS Edit " +
               "FROM sellers AS s " +
               "WHERE s.sellerid = @sellerid";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@sellerid", sellerId);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "sellers");

                if (dataSet.Tables["sellers"].Rows.Count > 0)
                {
                    // Создать и открыть форму EditDataBooks
                    var editDataSellers = new EditDataSellers();
                    editDataSellers.salName = dataSet.Tables["sellers"].Rows[0]["name"].ToString();
                    editDataSellers.salSurname = dataSet.Tables["sellers"].Rows[0]["surname"].ToString();
                    editDataSellers.surMidname = dataSet.Tables["sellers"].Rows[0]["middlename"].ToString();
                    editDataSellers.sallary = int.Parse(dataSet.Tables["sellers"].Rows[0]["salary"].ToString());
                    // Продолжите добавлять остальные параметры книги в форму EditDataBooks

                    DialogResult result = editDataSellers.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        string updatedName = editDataSellers.salName;
                        string updatedSur = editDataSellers.salSurname;
                        string updatedMid = editDataSellers.surMidname;
                        int updatedSal = editDataSellers.sallary;

                        // Обновить базу данных с новыми значениями
                        string updateQuery = "UPDATE sellers SET name = @name, surname = @surname, middlename = @middlename, salary = @salary WHERE sellerid = @sellerid";
                        NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@name", updatedName);
                        updateCommand.Parameters.AddWithValue("@surname", updatedSur);
                        updateCommand.Parameters.AddWithValue("@middlename", updatedMid);
                        updateCommand.Parameters.AddWithValue("@salary", updatedSal);
                        updateCommand.Parameters.AddWithValue("@sellerid", sellerId);
                        updateCommand.ExecuteNonQuery();

                        DataRow updatedRow = dataSet.Tables["sellers"].Rows[0];
                        updatedRow["name"] = updatedName;
                        updatedRow["surname"] = updatedSur;
                        updatedRow["middlename"] = updatedMid;
                        updatedRow["salary"] = updatedSal;

                        int rowIndex = Sellersdb.SelectedCells[0].RowIndex;
                        DataGridViewRow dataGridViewRow = Sellersdb.Rows[rowIndex];
                        dataGridViewRow.Cells["name"].Value = updatedName;
                        dataGridViewRow.Cells["surname"].Value = updatedSur;
                        dataGridViewRow.Cells["middlename"].Value = updatedMid;
                        dataGridViewRow.Cells["salary"].Value = updatedSal;
                        // Обновите остальные ячейки в соответствии с обновлениями

                        // Очистите выделение в DataGridView
                        Sellersdb.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Книга с указанным названием не найдена.", "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка OpenCustomControl!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sellersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == Sellersdb.Columns["Edit"].Index)
                {
                    int sellerId = (int)Sellersdb.Rows[e.RowIndex].Cells["sellerid"].Value;
                    OpenCustomControlSellers(sellerId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataSellers_Click(object sender, EventArgs e)
        {
            GenerateWordDocument(Sellersdb);
        }

        public void RefreshDataGridViewSeller()
        {
            string query = "SELECT s.sellerid, s.name, s.surname, s.middlename, s.salary, " +
                    "'Редактировать' AS Edit " +
               "FROM sellers AS s";

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "sellers");

            // Предполагается, что у вас есть DataGridView с именем BooksDataGridView
            Sellersdb.DataSource = dataSet.Tables["sellers"];
        }

        private void OpenAddDataSellers()
        {
            var addDataSellers = new AddDataSellers();
            addDataSellers.DataAdded += AddDataFormSeelers_DataAdded;
            addDataSellers.ShowDialog();
        }
        private void AddDataFormSeelers_DataAdded(object sender, EventArgs e)
        {
            // Обновление данных в DataGridView
            RefreshDataGridViewSeller();
        }

        private void AddDBSellers_Click(object sender, EventArgs e)
        {
            OpenAddDataSellers();
            Sellersdb.Sort(Sellersdb.Columns["sellerid"], ListSortDirection.Ascending);
        }
        #endregion


    }
}