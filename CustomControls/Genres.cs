using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class Genres : UserControl
    {
        private NpgsqlConnection? connection = null;
        private NpgsqlCommandBuilder? commandBuilder = null;
        private NpgsqlDataAdapter? dataAdapter = null;
        private DataSet? dataSet = null;
        private string table = "genres";
        private string tableID = "genreid";
        private int columns = 2;

        private bool newRowAdding = false;

        public Genres()
        {
            InitializeComponent();
        }

        private void FromGenresButton_Click(object sender, EventArgs e)
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

                dataGridView1.DataSource = dataSet.Tables[table];

                dataGridView1.DataBindingComplete += DataBindingComplete;

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

                dataGridView1.DataSource = dataSet.Tables[table];

                dataGridView1.DataBindingComplete += DataBindingComplete;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ReLoadData!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                dataGridView1[columns, i] = linkCell;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void Genres_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["BookDealer"].ConnectionString);
            connection.Open();

            LoadData();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView1.Rows.Count - 2;

                    DataGridViewRow row = dataGridView1.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[columns, lastRow] = linkCell;

                    row.Cells["delete"].Value = "Добавить";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка UserAddedRow!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == columns && dataGridView1.Rows[e.RowIndex].Cells[columns].Value != null)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[columns].Value.ToString();
                    if (task == "Удалить")
                    {
                        if (dataGridView1.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
                        {
                            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[tableID].Value;
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
                        int rowIndex = dataGridView1.Rows.Count - 2;

                        DataRow row = dataSet.Tables[table].NewRow();

                        row["name"] = dataGridView1.Rows[rowIndex].Cells["name"].Value;       

                        dataSet.Tables[table].Rows.Add(row);

                        dataSet.Tables[table].Rows.RemoveAt(dataSet.Tables[table].Rows.Count - 2);

                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);

                        dataGridView1.Rows[e.RowIndex].Cells[columns].Value = "Удалить";

                        dataAdapter.Update(dataSet, table);

                        newRowAdding = false;

                    }
                    else if (task == "Редактировать")
                    {
                        int r = e.RowIndex;

                        DataRow row = dataSet.Tables[table].Rows[r];

                        row.BeginEdit();
                        row["name"] = dataGridView1.Rows[r].Cells["name"].Value;
                        row.EndEdit();

                        dataAdapter.Update(dataSet, table);
                        dataGridView1.Rows[e.RowIndex].Cells[columns].Value = "Удалить";
                        ReLoadData();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellContentClick!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[columns, rowIndex] = linkCell;

                    editingRow.Cells["delete"].Value = "Редактировать";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка CellValueChanged!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
