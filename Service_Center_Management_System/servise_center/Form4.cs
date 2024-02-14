using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servise_center
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 service_availability = new Form8();
            service_availability.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 Customer = new Form6();
            Customer.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Payment = new Form5();
            Payment.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form17 service_menu = new Form17();
            service_menu.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 appoinment = new Form9();
            appoinment.Show();
            this.Hide();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loging log = new loging();
            log.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form14 profile = new Form14();
            profile.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lb_date.Text= DateTime.Now.ToShortDateString();
            lb_time.Text = DateTime.Now.ToShortTimeString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
