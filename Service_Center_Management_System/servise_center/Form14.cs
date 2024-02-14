using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace servise_center
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void Form14_Load(object sender, EventArgs e)
        {
            string username = loging.getUser;
            // Insert the service details into the database
            SqlCommand cmd = null;
            cmd = new SqlCommand("SELECT [Fname] ,[Lname] ,[Phone] ,[address] ,[email]   FROM [dbo].[employee_details] where username Like '%"+username+"%'", con);
            con.Open();

            SqlDataReader myR = cmd.ExecuteReader();
            if (myR.HasRows)
            {
                while (myR.Read())
                {
                    
                    lbl_fname.Text = myR[0].ToString();
                    lbl_lname.Text = myR[1].ToString();
                    lbl_phone.Text = myR[2].ToString();
                    lbl_address.Text = myR[3].ToString();
                    lbl_email.Text = myR[4].ToString();
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form15 edit = new Form15();
            edit.Show();
            this.Hide();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = loging.getUser;

            if (name == "Admin")
            {
                Form2 admindashboard = new Form2();
                admindashboard.Show();
                this.Hide();

            }
            else
            {
                Form4 dashboard = new Form4();
                dashboard.Show();
                this.Hide();

            }
        }
    }
}
