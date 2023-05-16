using BookDealer.CustomControls;
using Npgsql;
using System.Configuration;
using System.Data;

namespace BookDealer
{
    public partial class MainMenu : Form
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;

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


    }
}