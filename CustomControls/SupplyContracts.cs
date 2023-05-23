using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class SupplyContracts : UserControl
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "supplycontracts";
        private string tableID = "contractid";
        private int columns = 4;

        private bool newRowAdding = false;
        public SupplyContracts()
        {
            InitializeComponent();
        }

        private void FromSupplyButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            ContractsControl contractsControl = parentForm.Controls.Find("contractsControl1", true).FirstOrDefault() as ContractsControl;
            contractsControl.Visible = true;
        }

        public void LoadData()
        {
            try
            {
                dataAdapter = new NpgsqlDataAdapter("SELECT *, 'Удалить' as delete FROM " + table, connection);

                commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, table);

                Suppludb.DataSource = dataSet.Tables[table];

                Suppludb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка LoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReLoadData()
        {
            try
            {
                dataSet.Tables[table].Clear();

                dataAdapter.Fill(dataSet, table);

                Suppludb.DataSource = dataSet.Tables[table];

                Suppludb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Suppludb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Suppludb[columns, i] = linkCell;
            }
        }

        private void UpdateSupplyDB_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void SupplyContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void Suppludb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columns && Suppludb.Rows[e.RowIndex].Cells[columns].Value != null)
                {
                    string task = Suppludb.Rows[e.RowIndex].Cells[columns].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Suppludb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Suppludb.Rows[e.RowIndex].Cells[tableID].Value;
                                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM " + table + " WHERE " + tableID + " = @" + tableID, connection))
                                {
                                    cmd.Parameters.AddWithValue("@" + tableID, id);
                                    cmd.ExecuteNonQuery();
                                }
                                LoadData(); // Обновляем таблицу

                            }

                        }
                    }
                    else if (task == "Добавить")
                    {
                        int rowIndex = Suppludb.Rows.Count - 2;

                        DataRow row = dataSet.Tables[table].NewRow();

                        row["information"] = Suppludb.Rows[rowIndex].Cells["information"].Value;
                        row["date"] = Suppludb.Rows[rowIndex].Cells["name"].Value;
                        row["providerid"] = Suppludb.Rows[rowIndex].Cells["providerid"].Value;

                        dataSet.Tables[table].Rows.Add(row);

                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 2);

                        Suppludb.Rows.RemoveAt(Suppludb.Rows.Count - 2);

                        Suppludb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";

                        dataAdapter.Update(dataSet, table);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables[table].Rows[r];

                        row.BeginEdit();
                        row["name"] = Suppludb.Rows[r].Cells["name"].Value;
                        row["date"] = Suppludb.Rows[r].Cells["date"].Value;
                        row["providerid"] = Suppludb.Rows[r].Cells["providerid"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, table);
                        Suppludb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";
                        ReLoadData();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Suppludb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Suppludb.Rows.Count - 2;

                    DataGridViewRow row = Suppludb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Suppludb[columns, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Suppludb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Suppludb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Suppludb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Suppludb[columns, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GetMaxLengths()
        {
            int[] maxLengths = new int[Suppludb.Columns.Count];

            for (int i = 0; i < Suppludb.Columns.Count; i++)
            {
                int maxLength = Suppludb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Suppludb.Rows)
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


        private void SavetoFile(string filename)
        {
            FileStream fs = new FileStream(@"C:\Users\jbunk\Desktop\учебные пособия\базы данных\BookDealer\BookDealer\reports\" + filename, FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                int[] maxLengths = GetMaxLengths();

                for (int j = 0; j < Suppludb.Rows.Count; j++)
                {
                    for (int i = 0; i < Suppludb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Suppludb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Suppludb.Columns.Count - 1)
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
        private void SaveSupplyDB_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "SupplyContracts.txt");
            SavetoFile(s);
        }
    }
}
