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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace servise_center
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void Form15_Load(object sender, EventArgs e)
        {

            string username = loging.getUser;
            // Insert the service details into the database
            SqlCommand cmd = null;
            cmd = new SqlCommand("SELECT [Fname] ,[Lname] ,[Phone] ,[address] ,[email],[username]   FROM [dbo].[employee_details] where username Like '%" + username + "%'", con);
            con.Open();

            SqlDataReader myR = cmd.ExecuteReader();
            if (myR.HasRows)
            {
                while (myR.Read())
                {

                    txt_fname.Text = myR[0].ToString();
                    txt_lname.Text = myR[1].ToString();
                    txt_phone.Text = myR[2].ToString();
                    txt_address.Text = myR[3].ToString();
                    txt_email.Text = myR[4].ToString();
                    lbl_username.Text = myR[5].ToString();
                }
            }
            con.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to edit","Edit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string username = loging.getUser;
                SqlCommand cmd = null;
                cmd = new SqlCommand("  UPDATE [dbo].[employee_details]   SET [Fname] = ' " + txt_fname.Text + "' ,[Lname] = '" + txt_lname.Text + "' ,[Phone] = '" + txt_phone.Text + "' ,[address] = '" + txt_address.Text + "' ,[email] = '" + txt_email.Text + "'    WHERE username LIKE '" + username + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Edit Success.....!!");
                Form14 profile = new Form14();
                profile.Show();
                this.Hide();
            }
            else
            {
                Form14 profile = new Form14();
                profile.Show();
                this.Hide();
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 profile = new Form14();
            profile.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
