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
    public partial class Storage : UserControl
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "storeroom";
        private string tableID = "collectbooksid";
        private int columns = 3;

        private bool newRowAdding = false;

        public Storage()
        {
            InitializeComponent();
        }

        private void FromStorageButton_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            GoodsControl goodsControl = parentForm.Controls.Find("goodsControl1", true).FirstOrDefault() as GoodsControl;
            goodsControl.Visible = true;
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

                Storagedb.DataSource = dataSet.Tables[table];

                Storagedb.DataBindingComplete += DataBindingComplete;

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

                Storagedb.DataSource = dataSet.Tables[table];

                Storagedb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Storagedb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Storagedb[columns, i] = linkCell;
            }
        }

        private void UpdateStorageDB_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void Storage_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void Storagedb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Storagedb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Storagedb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Storagedb[columns, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Storagedb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columns && Storagedb.Rows[e.RowIndex].Cells[columns].Value != null)
                {
                    string task = Storagedb.Rows[e.RowIndex].Cells[columns].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Storagedb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Storagedb.Rows[e.RowIndex].Cells[tableID].Value;
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
                        int rowIndex = Storagedb.Rows.Count - 2;

                        DataRow row = dataSet.Tables[table].NewRow();

                        row["count"] = Storagedb.Rows[rowIndex].Cells["count"].Value;
                        row["bookid"] = Storagedb.Rows[rowIndex].Cells["bookid"].Value;

                        dataSet.Tables[table].Rows.Add(row);

                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 2);

                        Storagedb.Rows.RemoveAt(Storagedb.Rows.Count - 2);

                        Storagedb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";

                        dataAdapter.Update(dataSet, table);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables[table].Rows[r];

                        row.BeginEdit();
                        row["count"] = Storagedb.Rows[r].Cells["count"].Value;
                        row["bookid"] = Storagedb.Rows[r].Cells["bookid"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, table);
                        Storagedb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";
                        ReLoadData();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Storagedb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Storagedb.Rows.Count - 2;

                    DataGridViewRow row = Storagedb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Storagedb[columns, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GetMaxLengths()
        {
            int[] maxLengths = new int[Storagedb.Columns.Count];

            for (int i = 0; i < Storagedb.Columns.Count; i++)
            {
                int maxLength = Storagedb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Storagedb.Rows)
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

                for (int j = 0; j < Storagedb.Rows.Count; j++)
                {
                    for (int i = 0; i < Storagedb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Storagedb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Storagedb.Columns.Count - 1)
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
        private void SaveStorageDB_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Storage.txt");
            SavetoFile(s);
        }
    }
}
