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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void btn_register_Click(object sender, EventArgs e)
        {
            String email, code;
            email = txt_email.Text;
            code = txt_code.Text;

            try
            {
                String querry = "SELECT  email,Code  FROM loging WHERE email ='" + txt_email.Text + "' AND Code ='" + txt_code.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    email = txt_email.Text;
                    code = txt_code.Text;

                    //page load next
                    Form12 change_password = new Form12();
                    //change_password.getemail(email);
                    change_password.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid  Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_email.Clear();
                    txt_code.Clear();

                    //to focus username
                    txt_email.Focus();
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

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}
