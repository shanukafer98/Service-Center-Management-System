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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }



        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand(@"SELECT [phone_num]
      ,[date]
      ,[time]
  FROM [dbo].[appoinment]
     Where phone_num = '"+textBox1.Text+"'",conn);
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            conn.Close();

          

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var result = MessageBox.Show("Do you wish to pay: Rs" + 500,"Advance payment ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO [dbo].[appoinment] ( [phone_num], [date], [time]) VALUES ( @phoneNumber, @date, @time)", conn2);


                cmd2.Parameters.AddWithValue("@phoneNumber", txt_phone.Text);
                cmd2.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                cmd2.Parameters.AddWithValue("@time", dateTimePicker2.Value.ToShortTimeString());

                conn2.Open();
                cmd2.ExecuteNonQuery();
                conn2.Close();

                MessageBox.Show("Add Appointment Successfully \n , pay Advance successfully!!\n have a nice day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Can't arrange appointment ", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }

            getLetterDetails();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            getLetterDetails();
            String name = loging.getUser;

            if (name == "Admin")
            {
                button2.Show();

            }
            else
            {
                button2.Hide();

            }

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

        private void textBox1_Click(object sender, EventArgs e)
        {
            
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

        private void Form9_Click(object sender, EventArgs e)
        {
            getLetterDetails();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
