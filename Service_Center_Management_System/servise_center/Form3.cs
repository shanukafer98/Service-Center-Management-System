using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace servise_center
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            combo_gender.Items.Add("Mail");
            combo_gender.Items.Add("Femail");
            combo_emp.Items.Add("Admin");
            combo_emp.Items.Add("Supperviser");
            combo_emp.Items.Add("Labbers");
            combo_emp.Items.Add("Cashier");
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection conn2 = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[employee_details]
           ([Fname]
           ,[Lname]
           ,[Gender]
           ,[Phone]
           ,[Emp_Type]
           ,[address]
           ,[email]
           ,[salary]
           ,[username]
           ,[emp_id])
     VALUES
           ('" + txt_fname.Text+"','"+txt_lname.Text+"','"+combo_gender.SelectedItem.ToString()+"','"+txt_phone.Text+ "','"+combo_emp.SelectedItem.ToString()+ "','"+txt_adress.Text+"','" + txt_email.Text+"','"+txt_sal.Text+"','"+txt_username.Text+"','"+txt_empid.Text+"')",conn2);

            conn2.Open();
            cmd.ExecuteNonQuery();
            conn2.Close();


            MessageBox.Show("Register Successfully", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
           
            loging form1= new loging();
            form1.Show();
            this.Hide();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loging log = new loging();
            log.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
