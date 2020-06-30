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
    public partial class Authorization : Form
    {
       
        public Authorization()
        {
            

            InitializeComponent();
            pictureBox1.Image = Image.FromFile("D:/Учёба/Программирование/Vetclinic/Логотип.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            string s = Environment.Is64BitOperatingSystem ? "64" : "32";
            label5.Text = "Операционная система:\n\r" + Environment.OSVersion.ToString() + "\n\rРазрядность: " + s + "\n\rЧисло процессоров: " + Environment.ProcessorCount.ToString() + "\n\rИмя машины: " + Environment.MachineName.ToString() + "\n\rИмя пользователя: "+ Environment.UserName.ToString();
            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            MySqlCommand cmdDB = new MySqlCommand(queryOS(), dbConnection);
            cmdDB.CommandTimeout = 60;


            dbConnection.Open();

            var cmd = new MySqlCommand("INSERT INTO OS ( os, raz, countp, namemachine, nameme) VALUES(@os, @raz, @countp, @namemachine, @nameme)", dbConnection);
            cmd.Parameters.AddWithValue("@os", Environment.OSVersion.ToString());
            cmd.Parameters.AddWithValue("@raz", s);
            cmd.Parameters.AddWithValue("@countp", Environment.ProcessorCount.ToString());
            cmd.Parameters.AddWithValue("@namemachine", Environment.MachineName.ToString());
            cmd.Parameters.AddWithValue("@nameme", Environment.UserName.ToString());

            cmd.ExecuteNonQuery();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            MySqlCommand cmdDB = new MySqlCommand(queryControl(), dbConnection);
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

                        List<string> getLogin = new List<string>() { reader.GetString(0) };
                        List<string> getPass = new List<string>() { reader.GetString(1) };
                        List<string> getName = new List<string>() { reader.GetString(2) };

                        List<string> getType = new List<string>() { reader.GetString(3) };

                        foreach (string login in getLogin)
                        {
                            foreach (string pass in getPass)
                            {
                              
                                        if (
                                textBox1.Text == login
                                &&
                                textBox2.Text == pass)
                                        {
                                            
                                                switch (getType[getLogin.IndexOf(login)])
                                                {
                                                       
                                                        case "1":
                                                            this.Hide();
                                                            Manager manager = new Manager();
                                                            manager.Show();
                                                            break;

                                                        case "2":
                                                            this.Hide();
                                                            Doctor doctor = new Doctor(getName[getLogin.IndexOf(login)]);
                                                            doctor.Show();
                                                            break;


                                                        case "3":
                                                            this.Hide();
                                                            Cleaner Cleaner = new Cleaner(getName[getLogin.IndexOf(login)], true);
                                                            Cleaner.Show();
                                                            break;

                                                        case "4":
                                                            this.Hide();
                                                            Pharmacist Pharmacist = new Pharmacist(getName[getLogin.IndexOf(login)]);
                                                            Pharmacist.Show();
                                                            break;

                                    }

                                }

                            }
                        }

                     }

                 }
                   

                
                else
                {
                    MessageBox.Show("Error");
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private string strConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=vetclinic;";
            return connection;
        }

        private string queryControl()
        {
            string queryControl = "SELECT login, password, name, type FROM users";
            return queryControl;
        }
        private string queryOS()
        {
            string queryControl = "SELECT os, raz, countp, namemachine, nameme FROM OS";
            return queryControl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

        
    }
}
