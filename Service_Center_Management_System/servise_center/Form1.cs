using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace servise_center
{
    public partial class loging : Form
    {
        

        String username, user_passward;
        public static String getUser = "";
        public loging()
        {
            InitializeComponent();
        }
        

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void loging_Load(object sender, EventArgs e)
        {
        }


       

        

        private void btn_loging_Click(object sender, EventArgs e)
        {
            
            username = txt_username.Text;
            user_passward = txt_password.Text;
         
            

            try
            {
                String querry = "SELECT  username,passward  FROM loging WHERE username ='" + txt_username.Text+"' AND passward ='"+txt_password.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = txt_username.Text;
                    getUser = txt_username.Text;
                    user_passward = txt_password.Text;
                    Form6 customer = new Form6();
                   
                    if (username.Contains("Admin"))
                    {
                        Form2 AdminDashboard = new Form2();
                        AdminDashboard.setname(username);
                        AdminDashboard.Show();
                        this.Hide();

                    }
                    else if (username.Contains("Cashier"))
                    {
                        Form4 CashierDashboard = new Form4();
                       
                        CashierDashboard.Show();
                        this.Hide();
                    }

                   

                }
                else
                {
                    MessageBox.Show("Invalid loging Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();

                    //to focus username
                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

            finally
            {
                conn.Close();
            }

           
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();

            txt_username.Focus();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

            DialogResult res;
            res = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(res== DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Form13 verification  = new Form13();
            verification.Show();
            this.Hide();
        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
