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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        static String ID = "0";
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        

        }
        private void getLetterDetails()
        {

            SqlCommand cmd = new SqlCommand("Select * FROM [dbo].[Service_Details] ", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            con.Close();

            dataGridView1.DataSource = dt;

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            getLetterDetails();
            String name = loging.getUser;

            if (name == "Admin")
            {
                button1.Show();

            }
            else
            {
                button1.Hide();

            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Select * FROM [dbo].[Service_Details] where Date LIKE '%" + txt_date.Text + "%'", con);
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txt_date.Text = "";
        }

        private void Form5_Click(object sender, EventArgs e)
        {
            txt_date.Text = "YYYY-MM-DD";
        }

        private void txt_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 dashboard = new Form4();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dashboard = new Form2();
            dashboard.Show();
            this.Hide();
        }
    }
}
