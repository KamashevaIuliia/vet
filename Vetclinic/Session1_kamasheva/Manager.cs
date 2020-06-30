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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
           
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

        private void регистрацияToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Registration Registration = new Registration();
            Registration.MdiParent = this;
            Registration.Show();
        }

        private void приёмыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Appointments app = new Appointments();
            app.MdiParent = this;
            app.Show();
        }

        private void уборкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cleaner clean = new Cleaner("", false);
            clean.MdiParent = this;
            clean.Show();

        }
    }
}
