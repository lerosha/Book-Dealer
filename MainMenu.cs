using BookDealer.CustomControls;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Npgsql;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace BookDealer
{
    public partial class MainMenu : Form
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

        private NpgsqlConnection? connectionP = null;
        private NpgsqlCommandBuilder? commandBuilderP = null;
        private NpgsqlDataAdapter? dataAdapterP = null;
        private DataSet? dataSetP = null;
        private string tableP = "publishers";
        private string tablePID = "publisherid";
        private int columnsP = 5;

        private NpgsqlConnection? connectionProv = null;
        private NpgsqlCommandBuilder? commandBuilderProv = null;
        private NpgsqlDataAdapter? dataAdapterProv = null;
        private DataSet? dataSetProv = null;
        private string tableProv = "providers";
        private string tableProvID = "providerid";
        private int columnsProv = 3;

        private NpgsqlConnection? connectionS = null;
        private NpgsqlCommandBuilder? commandBuilderS = null;
        private NpgsqlDataAdapter? dataAdapterS = null;
        private DataSet? dataSetS = null;
        private string tableS = "sellers";
        private string tableSID = "sellerid";
        private int columnsS = 5;

        private bool newRowAdding = false;
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

        public void LoadDataClients()
        {
            try
            {
                dataAdapter = new NpgsqlDataAdapter("SELECT *, 'Удалить' as delete FROM clients", connection);

                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "clients");

                Clientsdb.DataSource = dataSet.Tables["clients"];

                Clientsdb.DataBindingComplete += Clientsdb_DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadDataClients!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ReLoadDataClients()
        {
            try
            {
                dataSet.Tables["clients"].Clear();

                dataAdapter.Fill(dataSet, "clients");

                Clientsdb.DataSource = dataSet.Tables["clients"];

                Clientsdb.DataBindingComplete += Clientsdb_DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadDataClients!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadDataClients();
            LoadDataP();
            LoadDataProv();
            LoadDataS();
        }

        private void UpdateDB_Click(object sender, EventArgs e)
        {
            ReLoadDataClients();
        }

        private void Clientsdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6 && Clientsdb.Rows[e.RowIndex].Cells[6].Value != null)
                {
                    string task = Clientsdb.Rows[e.RowIndex].Cells[6].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Clientsdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Clientsdb.Rows[e.RowIndex].Cells["clientsid"].Value;
                                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM clients WHERE clientsid = @clientsid", connection))
                                {
                                    cmd.Parameters.AddWithValue("@clientsid", id);
                                    cmd.ExecuteNonQuery();
                                }
                                LoadDataClients(); // Обновляем таблицу

                            }

                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = Clientsdb.Rows.Count - 2;

                        DataRow row = dataSet.Tables["clients"].NewRow();

                        row["name"] = Clientsdb.Rows[rowIndex].Cells["name"].Value;
                        row["surname"] = Clientsdb.Rows[rowIndex].Cells["surname"].Value;
                        row["middle name"] = Clientsdb.Rows[rowIndex].Cells["middle name"].Value;
                        row["bank account"] = Clientsdb.Rows[rowIndex].Cells["bank account"].Value;
                        row["address"] = Clientsdb.Rows[rowIndex].Cells["address"].Value;

                        dataSet.Tables["clients"].Rows.Add(row);

                        dataSet.Tables["clients"].Rows.RemoveAt(dataSet.Tables["clients"].Rows.Count - 2);

                        Clientsdb.Rows.RemoveAt(Clientsdb.Rows.Count - 2);

                        Clientsdb.Rows[e.RowIndex].Cells[6].Value = "Удалить";

                        dataAdapter.Update(dataSet, "clients");

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables["clients"].Rows[r];

                        row.BeginEdit();
                        row["name"] = Clientsdb.Rows[r].Cells["name"].Value;
                        row["surname"] = Clientsdb.Rows[r].Cells["surname"].Value;
                        row["middle name"] = Clientsdb.Rows[r].Cells["middle name"].Value;
                        row["bank account"] = Clientsdb.Rows[r].Cells["bank account"].Value;
                        row["address"] = Clientsdb.Rows[r].Cells["address"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, "clients");
                        Clientsdb.Rows[e.RowIndex].Cells[6].Value = "Удалить";
                        ReLoadDataClients();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Clientsdb_CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Clientsdb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Clientsdb.Rows.Count - 2;

                    DataGridViewRow row = Clientsdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Clientsdb[6, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Clientsdb_UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clientsdb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Clientsdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Clientsdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Clientsdb[6, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка Clientsdb_CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clientsdb_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Clientsdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Clientsdb[6, i] = linkCell;
            }
        }

        private int[] GetMaxLengthsClients()
        {
            int[] maxLengths = new int[Clientsdb.Columns.Count];

            for (int i = 0; i < Clientsdb.Columns.Count; i++)
            {
                int maxLength = Clientsdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Clientsdb.Rows)
                {
                    if (row.Cells[i].Value != null)
                    {
                        int cellLength = row.Cells[i].Value.ToString().Length;
                        if (cellLength > maxLength)
                        {
                            maxLength = cellLength;
                        }
                    }
                }
                maxLengths[i] = maxLength;
            }

            return maxLengths;
        }


        private void SavetoFileClients(string filename)
        {
            FileStream fs = new FileStream(@"C:\Users\jbunk\Desktop\учебные пособия\базы данных\BookDealer\BookDealer\reports\" + filename, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                int[] maxLengths = GetMaxLengthsClients();

                for (int j = 0; j < Clientsdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Clientsdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Clientsdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Clientsdb.Columns.Count - 1)
                        {
                            streamWriter.Write("    ");
                        }
                    }
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Report saved!");
            }
            catch
            {
                MessageBox.Show("Cannot save report!");
            }
        }

        private void SaveDataClients_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Clients.txt");
            SavetoFileClients(s);
        }

        #region Издательства
        public void LoadDataP()
        {
            try
            {
                dataAdapterP = new NpgsqlDataAdapter("SELECT *, 'Удалить' as delete FROM " + tableP, connection);

                commandBuilderP = new NpgsqlCommandBuilder(dataAdapterP);
                dataAdapterP.UpdateCommand = commandBuilderP.GetUpdateCommand();
                dataAdapterP.DeleteCommand = commandBuilderP.GetDeleteCommand();
                dataAdapterP.InsertCommand = commandBuilderP.GetInsertCommand();

                dataSetP = new DataSet();

                dataAdapterP.Fill(dataSetP, tableP);

                Publishersdb.DataSource = dataSetP.Tables[tableP];

                Publishersdb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadDataP!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReLoadDataP()
        {
            try
            {
                dataSetP.Tables[tableP].Clear();

                dataAdapterP.Fill(dataSetP, tableP);

                Publishersdb.DataSource = dataSetP.Tables[tableP];

                Publishersdb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadDataP!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Publishersdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Publishersdb[columnsP, i] = linkCell;
            }
        }

        private void UpdateDBPublishers_Click(object sender, EventArgs e)
        {
            ReLoadDataP();
        }

        private void Publishersdb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Publishersdb.Rows.Count - 2;

                    DataGridViewRow row = Publishersdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Publishersdb[columnsP, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Publishersdb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Publishersdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Publishersdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Publishersdb[columnsP, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Publishersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columnsP && Publishersdb.Rows[e.RowIndex].Cells[columnsP].Value != null)
                {
                    string task = Publishersdb.Rows[e.RowIndex].Cells[columnsP].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Publishersdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Publishersdb.Rows[e.RowIndex].Cells[tablePID].Value;
                                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " + tableP + " WHERE " + tablePID + " = @" + tablePID, connection))
                                {
                                    cmd.Parameters.AddWithValue("@" + tablePID, id);
                                    cmd.ExecuteNonQuery();
                                }
                                LoadDataP(); // Обновляем таблицу

                            }

                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = Publishersdb.Rows.Count - 2;

                        DataRow row = dataSetP.Tables[tableP].NewRow();

                        row["name"] = Publishersdb.Rows[rowIndex].Cells["name"].Value;
                        row["address"] = Publishersdb.Rows[rowIndex].Cells["address"].Value;
                        row["director"] = Publishersdb.Rows[rowIndex].Cells["director"].Value;
                        row["bank account"] = Publishersdb.Rows[rowIndex].Cells["bank account"].Value;

                        dataSetP.Tables[tableP].Rows.Add(row);

                        dataSetP.Tables[tableP].Rows.RemoveAt(dataSetP.Tables[tableP].Rows.Count - 2);

                        Publishersdb.Rows.RemoveAt(Publishersdb.Rows.Count - 2);

                        Publishersdb.Rows[e.RowIndex].Cells[columnsP].Value = "Удалить";

                        dataAdapterP.Update(dataSetP, tableP);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSetP.Tables[tableP].Rows[r];

                        row.BeginEdit();
                        row["name"] = Publishersdb.Rows[r].Cells["name"].Value;
                        row["address"] = Publishersdb.Rows[r].Cells["address"].Value;
                        row["director"] = Publishersdb.Rows[r].Cells["director"].Value;
                        row["bank account"] = Publishersdb.Rows[r].Cells["bank account"].Value;
                        row.EndEdit();

                        dataAdapterP.Update(dataSetP, tableP);
                        Publishersdb.Rows[e.RowIndex].Cells[columnsP].Value = "Удалить";
                        ReLoadDataP();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GetMaxLengthsP()
        {
            int[] maxLengths = new int[Publishersdb.Columns.Count];

            for (int i = 0; i < Publishersdb.Columns.Count; i++)
            {
                int maxLength = Publishersdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Publishersdb.Rows)
                {
                    if (row.Cells[i].Value != null)
                    {
                        int cellLength = row.Cells[i].Value.ToString().Length;
                        if (cellLength > maxLength)
                        {
                            maxLength = cellLength;
                        }
                    }
                }
                maxLengths[i] = maxLength;
            }

            return maxLengths;
        }

        private void SavetoFileP(string filename)
        {
            FileStream fs = new FileStream(@"C:\Users\jbunk\Desktop\учебные пособия\базы данных\BookDealer\BookDealer\reports\" + filename, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                int[] maxLengths = GetMaxLengthsP();

                for (int j = 0; j < Publishersdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Publishersdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Publishersdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Publishersdb.Columns.Count - 1)
                        {
                            streamWriter.Write("    ");
                        }
                    }
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Report saved!");
            }
            catch
            {
                MessageBox.Show("Cannot save report!");
            }
        }

        private void SaveDataPublishers_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Publishers.txt");
            SavetoFileP(s);

        }
        #endregion
        #region Поставщики
        public void LoadDataProv()
        {
            try
            {
                dataAdapterProv = new NpgsqlDataAdapter("SELECT *, 'Удалить' as delete FROM " + tableProv, connection);

                commandBuilderProv = new NpgsqlCommandBuilder(dataAdapterProv);
                dataAdapterProv.UpdateCommand = commandBuilderProv.GetUpdateCommand();
                dataAdapterProv.DeleteCommand = commandBuilderProv.GetDeleteCommand();
                dataAdapterProv.InsertCommand = commandBuilderProv.GetInsertCommand();

                dataSetProv = new DataSet();
                dataAdapterProv.Fill(dataSetProv, tableProv);

                Providersdb.DataSource = dataSetProv.Tables[tableProv];

                Providersdb.DataBindingComplete += DataBindingCompleteProv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReLoadDataProv()
        {
            try
            {
                dataSetProv.Tables[tableProv].Clear();
                dataAdapterProv.Fill(dataSetProv, tableProv);

                Providersdb.DataSource = dataSetProv.Tables[tableProv];

                Providersdb.DataBindingComplete += DataBindingCompleteProv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingCompleteProv(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Providersdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Providersdb[columnsProv, i] = linkCell;
            }
        }


        private void Providersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columnsProv && Providersdb.Rows[e.RowIndex].Cells[columnsProv].Value != null)
                {
                    string task = Providersdb.Rows[e.RowIndex].Cells[columnsProv].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Providersdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Providersdb.Rows[e.RowIndex].Cells[tableProvID].Value;
                                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " + tableProv + " WHERE " + tableProvID + " = @" + tableProvID, connection))
                                {
                                    cmd.Parameters.AddWithValue("@" + tableProvID, id);
                                    cmd.ExecuteNonQuery();
                                }
                                LoadDataProv(); // Обновляем таблицу

                            }

                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = Providersdb.Rows.Count - 2;

                        DataRow row = dataSetProv.Tables[tableProv].NewRow();

                        row["name"] = Providersdb.Rows[rowIndex].Cells["name"].Value;
                        row["address"] = Providersdb.Rows[rowIndex].Cells["address"].Value;

                        dataSetProv.Tables[tableProv].Rows.Add(row);

                        dataSetProv.Tables[tableProv].Rows.RemoveAt(dataSetProv.Tables[tableProv].Rows.Count - 2);

                        Providersdb.Rows.RemoveAt(Providersdb.Rows.Count - 2);

                        Providersdb.Rows[e.RowIndex].Cells[columnsProv].Value = "Удалить";

                        dataAdapterProv.Update(dataSetProv, tableProv);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSetProv.Tables[tableProv].Rows[r];

                        row.BeginEdit();
                        row["name"] = Providersdb.Rows[r].Cells["name"].Value;
                        row["address"] = Providersdb.Rows[r].Cells["address"].Value;
                        row.EndEdit();

                        dataAdapterProv.Update(dataSetProv, tableProv);
                        Providersdb.Rows[e.RowIndex].Cells[columnsProv].Value = "Удалить";
                        ReLoadDataProv();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Providersdb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Providersdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Providersdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Providersdb[columnsProv, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Providersdb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Providersdb.Rows.Count - 2;

                    DataGridViewRow row = Providersdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Providersdb[columnsProv, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDBProviders_Click(object sender, EventArgs e)
        {
            ReLoadDataProv();
        }

        private int[] GetMaxLengthsProv()
        {
            int[] maxLengths = new int[Providersdb.Columns.Count];

            for (int i = 0; i < Providersdb.Columns.Count; i++)
            {
                int maxLength = Providersdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Providersdb.Rows)
                {
                    if (row.Cells[i].Value != null)
                    {
                        int cellLength = row.Cells[i].Value.ToString().Length;
                        if (cellLength > maxLength)
                        {
                            maxLength = cellLength;
                        }
                    }
                }
                maxLengths[i] = maxLength;
            }

            return maxLengths;
        }

        private void SavetoFileProv(string filename)
        {
            FileStream fs = new FileStream(@"C:\Users\jbunk\Desktop\учебные пособия\базы данных\BookDealer\BookDealer\reports\" + filename, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                int[] maxLengths = GetMaxLengthsProv();

                for (int j = 0; j < Providersdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Providersdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Providersdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Providersdb.Columns.Count - 1)
                        {
                            streamWriter.Write("    ");
                        }
                    }
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Report saved!");
            }
            catch
            {
                MessageBox.Show("Cannot save report!");
            }
        }

        private void SaveDataProviders_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Providers.txt");
            SavetoFileProv(s);
        }

        #endregion
        #region Продавцы
        public void LoadDataS()
        {
            try
            {
                dataAdapterS = new NpgsqlDataAdapter("SELECT *, 'Удалить' as delete FROM " + tableS, connection);

                commandBuilderS = new NpgsqlCommandBuilder(dataAdapterS);
                dataAdapterS.UpdateCommand = commandBuilderS.GetUpdateCommand();
                dataAdapterS.DeleteCommand = commandBuilderS.GetDeleteCommand();
                dataAdapterS.InsertCommand = commandBuilderS.GetInsertCommand();

                dataSetS = new DataSet();

                dataAdapterS.Fill(dataSetS, tableS);

                Sellersdb.DataSource = dataSetS.Tables[tableS];

                Sellersdb.DataBindingComplete += DataBindingCompleteS;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReLoadDataS()
        {
            try
            {
                dataSetS.Tables[tableS].Clear();

                dataAdapterS.Fill(dataSetS, tableS);

                Sellersdb.DataSource = dataSetS.Tables[tableS];

                Sellersdb.DataBindingComplete += DataBindingCompleteS;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingCompleteS(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Sellersdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Sellersdb[columnsS, i] = linkCell;
            }
        }



        private void Sellersdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columnsS && Sellersdb.Rows[e.RowIndex].Cells[columnsS].Value != null)
                {
                    string task = Sellersdb.Rows[e.RowIndex].Cells[columnsS].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Sellersdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Sellersdb.Rows[e.RowIndex].Cells[tableSID].Value;
                                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " + tableS + " WHERE " + tableSID + " = @" + tableSID, connection))
                                {
                                    cmd.Parameters.AddWithValue("@" + tableSID, id);
                                    cmd.ExecuteNonQuery();
                                }
                                LoadDataS(); // Обновляем таблицу

                            }

                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = Sellersdb.Rows.Count - 2;

                        DataRow row = dataSetS.Tables[tableS].NewRow();

                        row["name"] = Sellersdb.Rows[rowIndex].Cells["name"].Value;
                        row["surname"] = Sellersdb.Rows[rowIndex].Cells["surname"].Value;
                        row["middle name"] = Sellersdb.Rows[rowIndex].Cells["middle name"].Value;
                        row["salary"] = Sellersdb.Rows[rowIndex].Cells["salary"].Value;

                        dataSetS.Tables[tableS].Rows.Add(row);

                        dataSetS.Tables[tableS].Rows.RemoveAt(dataSetS.Tables[tableS].Rows.Count - 2);

                        Sellersdb.Rows.RemoveAt(Sellersdb.Rows.Count - 2);

                        Sellersdb.Rows[e.RowIndex].Cells[columnsS].Value = "Удалить";

                        dataAdapterS.Update(dataSetS, tableS);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSetS.Tables[tableS].Rows[r];

                        row.BeginEdit();
                        row["name"] = Sellersdb.Rows[r].Cells["name"].Value;
                        row["surname"] = Sellersdb.Rows[r].Cells["surame"].Value;
                        row["middle name"] = Sellersdb.Rows[r].Cells["middle name"].Value;
                        row["salary"] = Sellersdb.Rows[r].Cells["salary"].Value;
                        row.EndEdit();

                        dataAdapterS.Update(dataSetS, tableS);
                        Sellersdb.Rows[e.RowIndex].Cells[columnsS].Value = "Удалить";
                        ReLoadDataS();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sellersdb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Sellersdb.Rows.Count - 2;

                    DataGridViewRow row = Sellersdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Sellersdb[columnsS, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Sellersdb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Sellersdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Sellersdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Sellersdb[columnsS, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GetMaxLengthsS()
        {
            int[] maxLengths = new int[Sellersdb.Columns.Count];

            for (int i = 0; i < Sellersdb.Columns.Count; i++)
            {
                int maxLength = Sellersdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Sellersdb.Rows)
                {
                    if (row.Cells[i].Value != null)
                    {
                        int cellLength = row.Cells[i].Value.ToString().Length;
                        if (cellLength > maxLength)
                        {
                            maxLength = cellLength;
                        }
                    }
                }
                maxLengths[i] = maxLength;
            }

            return maxLengths;
        }

        private void SavetoFileS(string filename)
        {
            FileStream fs = new FileStream(@"C:\Users\jbunk\Desktop\учебные пособия\базы данных\BookDealer\BookDealer\reports\" + filename, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                int[] maxLengths = GetMaxLengthsS();

                for (int j = 0; j < Sellersdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Sellersdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Sellersdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Sellersdb.Columns.Count - 1)
                        {
                            streamWriter.Write("    ");
                        }
                    }
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Report saved!");
            }
            catch
            {
                MessageBox.Show("Cannot save report!");
            }
        }

        private void SaveDataSellers_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Sellers.txt");
            SavetoFileS(s);
        }

        private void UpdateDBSellers_Click(object sender, EventArgs e)
        {
            ReLoadDataS();
        }
        #endregion

    }
}