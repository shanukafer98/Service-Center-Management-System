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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbl_fname_Click(object sender, EventArgs e)
        {

        }

        private void lbl_lname_Click(object sender, EventArgs e)
        {

        }

        private void lbl_address_Click(object sender, EventArgs e)
        {

        }

        private void lbl_phone_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string id = Form6.getID;
            SqlCommand cmd = null;
            cmd = new SqlCommand("  SELECT [Customer_ID] ,[Car_Number] ,[Vahicle_Type] ,[Service_Type] ,[Date] ,[Time] ,[Payment]  ,[Status] FROM [dbo].[Service_Details] where Customer_ID Like '%" + id + "%'", con);
            con.Open();

            SqlDataReader myR = cmd.ExecuteReader();
            if (myR.HasRows)
            {
                while (myR.Read())
                {
                    lbl_custID.Text = myR[0].ToString();
                    lbl_invoicenum.Text = myR[0].ToString();
                    lbl_vehinum.Text = myR[1].ToString();
                    lbl_vehitype.Text = myR[2].ToString();
                    lbl_servictype.Text = myR[3].ToString();
                    lbl_date.Text = myR[4].ToString();
                    lbl_status.Text = myR[6].ToString();
                    lbl_payamount.Text = myR[7].ToString();
                }
            }
            lb_date.Text = DateTime.Now.ToShortDateString();
            lb_time.Text = DateTime.Now.ToShortTimeString();
            con.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form7 pay = new Form7();
            pay.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            printDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("S4 Vehicle Care \n\n\n   Invoice  \n\n Customer ID\t\t\t" + lbl_custID.Text +"\nVehicle Number\t\t\t"+lbl_vehinum.Text+ "\nVehicle Type\t\t\t" + lbl_vehitype.Text + "\nService Type\t\t\t" + lbl_servictype.Text + "\nService Day\t\t\t" + lbl_date.Text + "\nPayment Status\t\t\t" + lbl_status.Text + "\nPayment Amount\t\t\t" + lbl_payamount.Text + "\n\n\nThank You...!!!\t\t\t" , new Font("Arial",10), Brushes.Black, 150, 125);
        }
    }
}
