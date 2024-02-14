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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[loging]   ([username],[passward],[email],[Code]) VALUES('"+txt_username.Text+"','"+txt_password.Text+"','"+txt_email.Text+"','"+txt_code.Text+ "')", conn2);
            conn2.Open();
            cmd.ExecuteNonQuery();
            conn2.Close();
            MessageBox.Show("New Member Add Successfully", "succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[loging]  WHERE username = '"+txt_username.Text+"'", conn2);
            conn2.Open();
            cmd.ExecuteNonQuery();
            conn2.Close();
            MessageBox.Show("Delete  Successfully", "succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_email.Clear();
                txt_code.Clear();
                
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dashboard = new Form2();
            dashboard.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
