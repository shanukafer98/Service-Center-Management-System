using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servise_center
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lb_date.Text = DateTime.Now.ToShortDateString();
            lb_time.Text =DateTime.Now.ToString();
            
        }
         
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 service = new Form5();
            service.Show();
            this.Hide();
        }
         public void setname(String name)
        {
            label3.Text = name;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form17 service_menu  = new Form17();
            service_menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 Customer= new Form6();
            Customer.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Payment = new Form5();
            Payment.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 service_availability = new Form8();
            service_availability.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 appoinment = new Form9();
            appoinment.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form16 revenue = new Form16();
            revenue.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 registration = new Form11();
            registration.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form14 profile = new Form14();
            profile.Show();
            this.Hide();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loging log = new loging();
            log.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToShortTimeString();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
