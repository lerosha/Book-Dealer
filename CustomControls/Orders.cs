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
    public partial class Orders : UserControl
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "orders";
        private string tableID = "orderid";
        private int columns = 6;

        private bool newRowAdding = false;
        public Orders()
        {
            InitializeComponent();
        }

        private void FromOrdersButton_Click(object sender, EventArgs e)
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

                Setsdb.DataSource = dataSet.Tables[table];

                Setsdb.DataBindingComplete += DataBindingComplete;

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

                Setsdb.DataSource = dataSet.Tables[table];

                Setsdb.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < Setsdb.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                Setsdb[columns, i] = linkCell;
            }
        }

        private void UpdateOrdersDB_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void Setsdb_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = Setsdb.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = Setsdb.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Setsdb[columns, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setsdb_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = Setsdb.Rows.Count - 2;

                    DataGridViewRow row = Setsdb.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    Setsdb[columns, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Setsdb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columns && Setsdb.Rows[e.RowIndex].Cells[columns].Value != null)
                {
                    string task = Setsdb.Rows[e.RowIndex].Cells[columns].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (Setsdb.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)Setsdb.Rows[e.RowIndex].Cells[tableID].Value;
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
                        int rowIndex = Setsdb.Rows.Count - 2;

                        DataRow row = dataSet.Tables[table].NewRow();

                        row["date"] = Setsdb.Rows[rowIndex].Cells["date"].Value;
                        row["count"] = Setsdb.Rows[rowIndex].Cells["count"].Value;
                        row["sum"] = Setsdb.Rows[rowIndex].Cells["sum"].Value;
                        row["contractid"] = Setsdb.Rows[rowIndex].Cells["contractid"].Value;
                        row["bookid"] = Setsdb.Rows[rowIndex].Cells["bookid"].Value;

                        dataSet.Tables[table].Rows.Add(row);

                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 2);

                        Setsdb.Rows.RemoveAt(Setsdb.Rows.Count - 2);

                        Setsdb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";

                        dataAdapter.Update(dataSet, table);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables[table].Rows[r];

                        row.BeginEdit();
                        row["name"] = Setsdb.Rows[r].Cells["name"].Value;
                        row["count"] = Setsdb.Rows[r].Cells["count"].Value;
                        row["sum"] = Setsdb.Rows[r].Cells["sum"].Value;
                        row["contractid"] = Setsdb.Rows[r].Cells["contractid"].Value;
                        row["bookid"] = Setsdb.Rows[r].Cells["bookid"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, table);
                        Setsdb.Rows[e.RowIndex].Cells[columns].Value = "Удалить";
                        ReLoadData();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int[] GetMaxLengths()
        {
            int[] maxLengths = new int[Setsdb.Columns.Count];

            for (int i = 0; i < Setsdb.Columns.Count; i++)
            {
                int maxLength = Setsdb.Columns[i].HeaderText.Length;
                foreach (DataGridViewRow row in Setsdb.Rows)
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

                for (int j = 0; j < Setsdb.Rows.Count; j++)
                {
                    for (int i = 0; i < Setsdb.Columns.Count - 1; i++)
                    {
                        string cellValue = (Setsdb[i, j].Value ?? "").ToString();

                        string formattedCellValue = string.Format("{0,-" + maxLengths[i] + "}", cellValue);

                        streamWriter.Write(formattedCellValue);
                        if (i < Setsdb.Columns.Count - 1)
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

        private void SaveOrdersDB_Click(object sender, EventArgs e)
        {
            string s = Interaction.InputBox("Save as..", "Save", "Orders.txt");
            SavetoFile(s);
        }
    }
}
