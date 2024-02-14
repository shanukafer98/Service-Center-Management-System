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

namespace servise_center
{
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9EBLP28\\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        static String getID = "0";
        
        public Form7()
        {
            InitializeComponent();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            String status;
            // Get customer ID from the text box
            String ID = txt_id.Text;
            getID = ID;
            if (string.IsNullOrEmpty(ID))
            {
                // Show an error message if customer ID is empty
                MessageBox.Show("Please enter a valid Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get car number, vehicle type, service type, date, and time from the form controls
            String carnumber = txtCarNumber.Text;
            String vehicletype = cmbVehicleType?.SelectedItem?.ToString();
            String servicetype = cmbServiceType.SelectedItem.ToString();
         
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string time = dateTimePicker2.Value.ToString("HH:mm:ss");
           

            // Determine the status based on whether the "Appointment" checkbox is checked
            //String status = Appoinment.Checked ? "Appointment" : "Completed";

            double payment = 0;
            // Check if both vehicle type and service type are selected
            if (!string.IsNullOrEmpty(vehicletype) && !string.IsNullOrEmpty(servicetype))
            {
                // Calculate the payment based on the selected vehicle type and service type
                string selectedVehicleType = cmbVehicleType.SelectedItem.ToString();
                string selectedServiceType = cmbServiceType.SelectedItem.ToString();

                if (selectedVehicleType == "Motorbike")
                {
                    if (selectedServiceType == "Full ")
                    {
                        payment = 1500.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Interior")
                    {
                        payment = 800.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Exterior")
                    {
                        payment = 500.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Change oil")
                    {
                        payment = 1000.00;
                        lbl_price.Text = payment.ToString();
                    }
                }
                else if (selectedVehicleType == "Threewheeler")
                {
                    if (selectedServiceType == "Full ")
                    {
                        payment = 3000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Interior")
                    {
                        payment = 1000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Exterior")
                    {
                        payment = 1000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Change oil")
                    {
                        payment = 1000.00;
                        lbl_price.Text = payment.ToString();
                    }
                }
                else if (selectedVehicleType == "Car")
                {
                    if (selectedServiceType == "Full ")
                    {
                        payment = 6000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Interior")
                    {
                        payment = 2000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Exterior")
                    {
                        payment = 1000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Change oil")
                    {
                        payment = 3000.00;
                        lbl_price.Text = payment.ToString();
                    }
                }
                else if (selectedVehicleType == "Van")
                {
                    if (selectedServiceType == "Full ")
                    {
                        payment = 8000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Interior")
                    {
                        payment = 3000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Exterior")
                    {
                        payment = 2000.00;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Change oil")
                    {
                        payment = 3000.00;
                        lbl_price.Text = payment.ToString();
                    }
                }
                else if (selectedVehicleType == "Lorry")
                {
                    if (selectedServiceType == "Full ")
                    {
                        payment = 12000;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Interior")
                    {
                        payment = 3000;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Exterior")
                    {
                        payment = 2000;
                        lbl_price.Text = payment.ToString();
                    }
                    else if (selectedServiceType == "Change oil")
                    {
                        payment = 7000;
                        lbl_price.Text = payment.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Show an error message if either vehicle type or service type is empty
                MessageBox.Show("Please input vehicle type and the service type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Show a confirmation dialog with the calculated payment
            var result = MessageBox.Show("Do you wish to pay: Rs" + payment, "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                 status = "Paid";
                // Show a success message if the user clicks "Yes"
                MessageBox.Show("Payment Successful! \n Have a nice day", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                status = "Unpaid";
                // Show a message if the user clicks "No"
                MessageBox.Show("Payment Denied! \n Have a nice day", "Payment Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                payment = 0;
            }
            // Insert the service details into the database
            
            SqlCommand cmd = null;
            cmd = new SqlCommand("INSERT INTO [dbo].[Service_Details] ([Customer_ID]    ,[Car_Number]  ,[Vahicle_Type] ,[Service_Type] ,[Date] ,[Time] ,[Payment]  ,[Status]) VALUES('" + ID + "','" + carnumber + "','" + vehicletype + "','" + servicetype + "','" + date + "','" + time + "','" + payment + "','" + status + "')", con);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            try
            {
                

                // Clear form fields and reset ComboBox selections after successful submission
                txtID.Clear();
                txtCarNumber.Clear();
                cmbVehicleType.SelectedIndex = -1; // Clear vehicle type selection
                cmbServiceType.SelectedIndex = -1; // Clear service type selection
                

                var anotherPaymentResult = MessageBox.Show("Do you wish to make another payment?", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (anotherPaymentResult == DialogResult.Yes)
                {
                    // User wants to make another payment
                    txtID.Focus();
                }
                else
                {
                    Form10 invoice = new Form10();
                    invoice.Show();
                    // User does not want to make another payment, close the form
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Show an error message if there's an exception during database insertion
                MessageBox.Show("Error: " + ex);

            }


        }




         private   void Form7_Load(object sender, EventArgs e)
        {
            String name = loging.getUser;

            if (name == "Admin")
            {
                button1.Show();

            }
            else
            {
                button1.Hide();

            }

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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 admindashboard = new Form2();
            admindashboard.Show();
            this.Hide();    
        }
    }
}

