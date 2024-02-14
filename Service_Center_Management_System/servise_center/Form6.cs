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
    public partial class Form6 : Form
    {
        public static string Customer_ID = "";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        static String ID = "0";
        public static String getID = "";
        public Form6()
        {
            InitializeComponent();
        }
        string username;
        
        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ID = txt_id.Text;
            String name = txtName.Text;
            String mobile = txtContactNo.Text;
            String address = txtAddress.Text;
            
            try
            {
                SqlCommand cmd = null;
                cmd = new SqlCommand("INSERT INTO [dbo].[Customer_Details] ([Customer_ID] ,[Customer_Name] ,[Contact_No] ,[Address]) VALUES('" + ID + "','" + name + "','" + mobile + "','" + address + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Added");

                txtName.Clear();
                txtContactNo.Clear();
                txtAddress.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*string nic = txtID.Text;

            try
            {

                con.Open();

                SqlCommand cmd = new SqlCommand("Select * from Customer_Details where Customer_ID = '" + nic + "'", con);

                SqlDataReader myR = cmd.ExecuteReader();
                if (myR.HasRows)
                {
                    while (myR.Read())
                    {
                         //= myR["Customer_ID"].ToString();
                         textBox2.Text = myR[0].ToString();
                        txtName.Text = myR[1].ToString();
                        txtContactNo.Text = myR[2].ToString();
                        txtAddress.Text = myR[3].ToString();


                    }
                }
                else
                {
                    MessageBox.Show("Sorry, No record from this id..");
                }

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                con.Close();
            }*/
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

        
            SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Customer_Details] SET [Customer_ID] = '"+txt_id.Text+"' ,[Customer_Name] = '"+txtName.Text+"' ,[Contact_No] ='"+txtContactNo.Text+"' ,[Address] = '"+txtAddress.Text+"'  WHERE Customer_ID = '" + txt_id.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update  Successfully", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

                }
                catch (Exception ee)
                {
                    //throw;
                    MessageBox.Show(ee.Message);
                    con.Close();
                }
            

        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Customer_ID = txt_id.Text;

            Form7 frm7 = new Form7();
             getID = txt_id.Text;

            frm7.Show();
            this.Hide();
        }
       

      
        private void Form6_Load_1(object sender, EventArgs e)
        {
            String name = loging.getUser;

            if (name == "Admin")
            {
                admin.Show();

            }
            else
            {
                admin.Hide();

            }

            getLetterDetails();
            
        }
        private void getLetterDetails()
        {

            SqlCommand cmd = new SqlCommand("Select * FROM [dbo].[Customer_Details] ", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            con.Close();

            dataGridView1.DataSource = dt;

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SqlCommand cmd = new SqlCommand(@"Select * FROM [dbo].[Customer_Details] where Customer_ID = '" + textbox1.Text + "'", con);
            DataTable dt = new DataTable();
            DataView dv = dt.DefaultView;

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Customer_Details]  WHERE Customer_ID = '" + txt_id.Text + "'", con);
            SqlCommand cmd2 = new SqlCommand("DELETE FROM [dbo].[Service_Details]  WHERE Customer_ID = '" + txt_id.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Delete  Successfully", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void admin_Click(object sender, EventArgs e)
        {
            Form2 admindashboard = new Form2();
            admindashboard.Show();
            this.Hide();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
