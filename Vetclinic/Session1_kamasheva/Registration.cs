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
using System.Text.RegularExpressions;

namespace Session1_kamasheva
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager Manager = new Manager();
            Manager.Show();
        }

        private string strConnection()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=vetclinic;";
            return connection;
        }

        private string queryRegister()
        {
            string queryRegister = "SELECT  login, password, name ,type FROM users";
            return queryRegister;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection dbConnection = new MySqlConnection(strConnection());
            MySqlCommand cmdDB = new MySqlCommand(queryRegister(), dbConnection);
            cmdDB.CommandTimeout = 60;


            dbConnection.Open();

            var cmd = new MySqlCommand("INSERT INTO users ( login, password, name,type) VALUES(@login, @password, @name, @type)", dbConnection);



            //var hasNumber = new Regex(@"[0-9]+");
            //var hasUpperChar = new Regex(@"[A-Z]+");
            //var hasSpecialSymbols = new Regex(@"[!@#$%^]");
            //var hasMinimum6Chars = new Regex(@".{6,}");


            //var isValidated =
            //    hasNumber.IsMatch(textBox2.Text) &&
            //    hasUpperChar.IsMatch(textBox2.Text) &&
            //    hasSpecialSymbols.IsMatch(textBox2.Text) &&
            //    hasMinimum6Chars.IsMatch(textBox2.Text);



            //if (!isValidated)
            //{
            //    MessageBox.Show("пароль неверен, попробуйте снова!");
            //}
            //else
            //{

                cmd.Parameters.AddWithValue("@login", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
            if(comboBox1.SelectedItem.ToString() == "Фармацевт")
            {
                cmd.Parameters.AddWithValue("@type", 4);
            }
            else if (comboBox1.SelectedItem.ToString() == "Уборщик")
            {
                cmd.Parameters.AddWithValue("@type", 3);
            }
            else if (comboBox1.SelectedItem.ToString() == "Лечащий врач")
            {
                cmd.Parameters.AddWithValue("@type", 2);
            }
            else if (comboBox1.SelectedItem.ToString() == "Менеджер")
            {
                cmd.Parameters.AddWithValue("@type", 1);
            }

            cmd.ExecuteNonQuery();

                DialogResult result = MessageBox.Show("Хотите зарегистрировать ещё одного пользователя?", "Пользователь успешно зарегистрирован.", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    this.Hide();
                    Manager Manager = new Manager();
                    Manager.Show();
                }
              
            //}

            dbConnection.Close();
        }

      
            }
}
 
