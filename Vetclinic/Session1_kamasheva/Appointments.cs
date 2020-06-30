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
using Newtonsoft.Json;
using System.IO;

namespace Session1_kamasheva
{

    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
            Fill();
        }
        private void Fill()
        {
            string jsonString = File.ReadAllText("D:/Учёба/Программирование/Юлечка/Юлечка/vet/db.json");

            try
            {
                var jobj = JsonConvert.DeserializeObject<LibAppointments>(jsonString);
                if (jobj != null)
                {
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = jobj.Appointments;
                }


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
        public class Appointment
        {

            [JsonProperty("id")]
            [DisplayName("Номер")]
            public int Id { get; set; }

            [JsonProperty("name")]
            [DisplayName("Имя")]
            public string Name { get; set; }

            [JsonProperty("service")]
            [DisplayName("Услуга")]
            public string Service { get; set; }

            [JsonProperty("time")]
            [DisplayName("Время")]
            public string Time { get; set; }

            [JsonProperty("date")]
            [DisplayName("Дата")]
            public string Date { get; set; }

            [JsonProperty("doctor")]
            [DisplayName("Доктор")]
            public string Doctor { get; set; }



        }
        public class LibAppointments
        {

            [JsonProperty("appointments")]
            public BindingList<Appointment> Appointments { get; set; }
        }
       
    }
}