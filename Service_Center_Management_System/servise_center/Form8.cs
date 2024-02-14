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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace servise_center
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void Form8_Load(object sender, EventArgs e)
        {
            getLetterDetails();
            String name = loging.getUser;

            if (name == "Admin")
            {
                btn_admin.Show();

            }
            else
            {
                btn_admin.Hide();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        
        

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }

        private void getLetterDetails()
        {

            SqlCommand cmd = new SqlCommand("SELECT [phone_num],[date],[time]  FROM [dbo].[appoinment]", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();

            dataGridView1.DataSource = dt;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 dashboard = new Form4();
            dashboard.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 appoinmnt = new Form9();
            appoinmnt.Show();
            this.Hide();
        }

        private void txt_date_Click(object sender, EventArgs e)
        {
            txt_date.Text = " ";
        }

        private void Form8_Click(object sender, EventArgs e)
        {
            getLetterDetails();
        }

        private void txt_date_KeyPress(object sender, KeyPressEventArgs e)

        {

            SqlCommand cmd = new SqlCommand(@"SELECT [phone_num]
      ,[date]
      ,[time]
  FROM [dbo].[appoinment]
     Where date = '" + txt_date.Text + "'", conn);
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            conn.Close();



        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 admindashboard = new Form2();
            admindashboard.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txt_date.Text = "MM-DD-YYYY";
            getLetterDetails();
        }
    }
}
