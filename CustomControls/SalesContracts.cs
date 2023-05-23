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
    public partial class SalesContracts : UserControl
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "salescontracts";
        private string tableID = "contractid";
        private int columns = 5;

        private bool newRowAdding = false;
        public SalesContracts()
        {
            InitializeComponent();
        }

        private void FromSalesButton_Click(object sender, EventArgs e)
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

                Salesdb.DataSource = dataSet.Tables[table];

                Salesdb.DataBindingComplete += DataBindingComplete;

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

                Salesdb.DataSource = dataSet.Tables[table];

                Salesdb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Salesdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Salesdb[columns, i] = linkCell;
            }
        }

        private void UpdateSalesDB_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void SalesContracts_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void Suppludb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columns && Salesdb.Rows[e.RowIndex].Cells[columns].Value != null)
                {
                    string task = Salesdb.Rows[e.RowIndex].Cells[columns].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Salesdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Salesdb.Rows[e.RowIndex].Cells[tableID].Value;
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
                        int rowIndex = Salesdb.Rows.Count - 2;

                        DataRow row = dataSet.Tables[table].NewRow();

                        row["information"] = Salesdb.Rows[rowIndex].Cells["information"].Value;
                        row["date"] = Salesdb.Rows[rowIndex].Cells["date"].Value;
                        row["clienstid"] = Salesdb.Rows[rowIndex].Cells["clienstid"].Value;
                        row["sellerid"] = Salesdb.Rows[rowIndex].Cells["sellerid"].Value;

                        dataSet.Tables[table].Rows.Add(row);

                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 2);

                        Salesdb.Rows.RemoveAt(Salesdb.Rows.Count - 2);

                        Salesdb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";

                        dataAdapter.Update(dataSet, table);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables[table].Rows[r];

                        row.BeginEdit();
                        row["name"] = Salesdb.Rows[r].Cells["name"].Value;
                        row["date"] = Salesdb.Rows[r].Cells["date"].Value;
                        row["clientsid"] = Salesdb.Rows[r].Cells["clientsid"].Value;
                        row["sellerid"] = Salesdb.Rows[r].Cells["sellerid"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, table);
                        Salesdb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";
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

                    int lastRow = Salesdb.Rows.Count - 2;

                    DataGridViewRow row = Salesdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Salesdb[columns, lastRow] = linkCell;

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
                    int rowIndex = Salesdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Salesdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Salesdb[columns, rowIndex] = linkCell;

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
            int[] maxLengths = new int[Salesdb.Columns.Count];

            for (int i = 0; i < Salesdb.Columns.Count; i++)
            {
                int maxLength = Salesdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Salesdb.Rows)
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

                for (int j = 0; j < Salesdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Salesdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Salesdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Salesdb.Columns.Count - 1)
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

        private void SaveSelesDB_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "SalesContracts.txt");
            SavetoFile(s);
        }
    }
}
