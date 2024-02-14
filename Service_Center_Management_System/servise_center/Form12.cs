using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace servise_center
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_repasword.Text == txt_password.Text)
            {
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[loging]   SET  [passward] = '" + txt_repasword.Text + "'WHERE username = '" + txt_username.Text + "' ", conn2);
                conn2.Open();
                cmd.ExecuteNonQuery();
                conn2.Close();
                MessageBox.Show("reset successfully","succesfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                loging form1 = new loging();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The new password does not match your same password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_password.Clear();
            txt_repasword.Clear();
            txt_username.Clear();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loging loging = new loging();
            loging.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
