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
        public void LoadDataP()
        {

        }


        private void Publishersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void SaveDataPublishers_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Поставщики

        private void Providersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void SaveDataProviders_Click(object sender, EventArgs e)
        {

        }

        #endregion
        #region Продавцы
        public void LoadDataS()
        {

        }

        private void Sellersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void SaveDataSellers_Click(object sender, EventArgs e)
        {

        }

        #endregion

        
    }
}