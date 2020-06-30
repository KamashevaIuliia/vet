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
    public partial class Cleaner : Form
    {

        public Cleaner(string name, bool ba)
        {
            InitializeComponent();
           
            Fill(queryTable());
            if(ba == false)
            {
                dataGridView1.Enabled = false;
            }
            else
            { 
                label1.Text = "Здравствуйте, " + name + "!";

            }
        }
        private void Fill(string command)
        {

            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            MySqlCommand cmdDB = new MySqlCommand(command, dbConnection);

            cmdDB.CommandTimeout = 60;

            MySqlDataReader reader;

            Image img;

            try
            {
                dbConnection.Open();
                reader = cmdDB.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetInt32(2) == 1)
                        {
                            img = Image.FromFile("D:/Учёба/Программирование/Vetclinic/Yes.png");

                        }
                        else
                        {
                            img = Image.FromFile("D:/Учёба/Программирование/Vetclinic/No.png");
                        }


                        dataGridView1.Rows.Add(reader.GetString(1), img, reader.GetInt32(0), reader.GetString(2));


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

                dataGridView1.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string queryTable()
        {
            string queryTable = "SELECT ID, time, status from clean";
            return queryTable;
        }
        private string strConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=vetclinic;";
            return connection;
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            Image imgYes = Image.FromFile("D:/Учёба/Программирование/Vetclinic/Yes.png");
            Image imgNo = Image.FromFile("D:/Учёба/Программирование/Vetclinic/No.png");
            var cmd = new MySqlCommand("UPDATE clean SET status = @status WHERE ID = @id ", dbConnection);
            dbConnection.Open();

            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                
                switch (dataGridView1["Column4", dataGridView1.CurrentCell.RowIndex].Value.ToString())
                {
                    case "0":
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
                        cmd.Parameters.AddWithValue("@status", 1);
                        cmd.ExecuteNonQuery();
                        dataGridView1["Column4", dataGridView1.CurrentCell.RowIndex].Value = 1;
                        dataGridView1["Column2", dataGridView1.CurrentCell.RowIndex].Value = imgYes;
                        break;
                    case "1":
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@id", dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value);
                        cmd.Parameters.AddWithValue("@status", 0);
                        cmd.ExecuteNonQuery();
                        dataGridView1["Column4", dataGridView1.CurrentCell.RowIndex].Value = 0;
                        dataGridView1["Column2", dataGridView1.CurrentCell.RowIndex].Value = imgNo;
                        break;




                }
            }
            dbConnection.Close();
        }

       
    }
}
