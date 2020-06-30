using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


using static Session1_kamasheva.Appointments;

namespace Session1_kamasheva
{
    public partial class Doctor : Form
    {
       
        public Doctor(string name)
        {
            InitializeComponent();
            label1.Text = "Здравствуйте, " + name + "!";
            string jsonString = File.ReadAllText("D:/Учёба/Программирование/Юлечка/Юлечка/vet/db.json");
            DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonString);

            DataTable dataTable = dataSet.Tables["appointments"];
            dataTable.Columns.RemoveAt(2);
            dataTable.Columns.RemoveAt(4);
            dataTable.Columns.RemoveAt(0);
            
            for(int i = dataTable.Rows.Count - 1; i >0; i--)
            {
                if (dataTable.Rows[i][1].ToString() != name)
                {
                    dataTable.Rows.RemoveAt(i);
                }
            }
            

            dataGridView1.DataSource = dataTable;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();

            dataGridView1.AutoSizeRowsMode =DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            //using (FileStream fs = new FileStream("D:/Учёба/Программирование/Юлечка/Юлечка/vet/db.json", FileMode.OpenOrCreate))
            ////{
            //    MyObj appointments = JsonSerializer.Deserialize<MyObj>(jsonString);
            //    MessageBox.Show(MyObj.count.ToString());
            ////for (int i = 0; i < MyObj.count; i++)
            ////{
            ////if (appointments.Doctor == name)
            ////{
            //dataGridView1.DataSource = appointments;
            //dataGridView1.Rows.Add(appointments.Id,appointments.Name, appointments.Service, appointments.Time, appointments.Date, appointments.Doctor );

            //}
            //}

            //}


            //BindingSource bs = new BindingSource();

            //BindingList<myObj> myObjList = JsonSerializer.Deserialize<myObj>(jsonString);



            //try
            //{
            //    var jobj = JsonConvert.DeserializeObject<LibAppointments>(jsonString);
            //    if (jobj != null)
            //    {
            //        dataGridView1.AutoGenerateColumns = true;
            //        dataGridView1.DataSource = jobj.Appointments;

            //    }



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //BindingList<myObj> filtered = new BindingList<myObj>(myObjList.Where(obj => obj.Name.Contains(name)).ToList());

            //dataGridView1.DataSource = filtered;
            //dataGridView1.Update();
            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("name = '{0}'", name);



            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (row.Cells[5].Value.ToString() != name)
            //    {

            //        row.Visible = false;
            //        this.Refresh();
            //    }


            //}





        }



        //public class MyObj
        //{

        //    public int Id { get; set; }

           
        //    public string Name { get; set; }

          
        //    public string Service { get; set; }

        //    public string Time { get; set; }

     
        //    public string Date { get; set; }

           
        //    public string Doctor { get; set; }
        //   public static int count;

        //    public MyObj()
        //    {
        //        count++;
        //    }
        //}

        //public class MyObjList
        //{

        
        //    public List<MyObj> ObjList { get; set; }
        //}


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram About = new AboutProgram();
            About.MdiParent = this;
            About.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Authorization auth = new Authorization();
                auth.Show();
            }
        }

        
    }
}
