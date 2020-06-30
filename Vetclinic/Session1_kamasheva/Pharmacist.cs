using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Session1_kamasheva
{
    public partial class Pharmacist : Form
    {
        public Pharmacist(string name)
        {
            InitializeComponent();
            label1.Text = "Здравствуйте, " + name + "!";
            Fill(queryTable());

        }
        private void Fill(string command)
        {

            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            MySqlCommand cmdDB = new MySqlCommand(command, dbConnection);

            cmdDB.CommandTimeout = 60;

            MySqlDataReader reader;


            try
            {
                dbConnection.Open();
                reader = cmdDB.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(0));
                        if (reader.GetInt32(2) < 5)
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Red;

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
                dbConnection.Close();

                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; ++j)
                    {

                        object o = dataGridView1[j, i].Value;
                    }
                }
                this.dataGridView1.Sort(this.Column2, ListSortDirection.Ascending);
                dataGridView1.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string queryTable()
        {
            string queryTable = "SELECT ID, medicament, count from medicaments";
            return queryTable;
        }
        private string strConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=vetclinic;";
            return connection;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection dbConnection = new MySqlConnection(strConnection());

            var cmd = new MySqlCommand("UPDATE medicaments SET  count = @count WHERE ID = @id ", dbConnection);
            dbConnection.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
            cmd.Parameters.AddWithValue("@count", dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value);
       
            cmd.ExecuteNonQuery();
            dbConnection.Close();

            if (Convert.ToInt32(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value) < 5)
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            
        }

    }
}
