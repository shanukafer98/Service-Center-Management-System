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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9EBLP28\SQLEXPRESS;Initial Catalog=log_info;Integrated Security=True");
        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            // Get the selected start and end dates and times from the DateTimePicker controls
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            // Initialize the progress bar
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Visible = true;

            // Create a Timer to simulate the progress bar filling
            Timer timer = new Timer();
            timer.Interval = 20; // Set the interval to fill the progress bar within 2 seconds
            timer.Tick += (s, args) =>
            {
                progressBar1.PerformStep();
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    // When the progress bar is filled, stop the timer and calculate the revenue
                    timer.Stop();
                    CalculateRevenue(startDate, endDate);
                }
            };

            // Start the timer to fill the progress bar
            timer.Start();
        }
        private async void CalculateRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                con.Open();
                //DATEDIFF(day, @StartDate, @EndDate)
                // Create an SQL command to select the sum of payments from the Service_Details table based on the selected time frame
                SqlCommand cmd = new SqlCommand("SELECT SUM(Payment), count(Date) FROM Service_Details WHERE Date >= @StartDate AND Date <= @EndDate", con);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                // Execute the SQL command asynchronously
                var asyncResult = await cmd.ExecuteReaderAsync();

                // Read the result (total payment and total days)
                if (await asyncResult.ReadAsync())
                {
                    if (!asyncResult.IsDBNull(0))
                    {
                        decimal totalPayment = asyncResult.GetDecimal(0);
                        int totalDays = asyncResult.GetInt32(1);

                        // Set the total revenue and total days in the respective text boxes
                        txtRevenue.Text = totalPayment.ToString();
                        txtTotalDays.Text = totalDays.ToString();
                    }
                    else
                    {
                        // Handle the case where no records were found
                        txtRevenue.Text = "0";
                        txtTotalDays.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form16_Click(object sender, EventArgs e)
        {
            txtRevenue.Text = " ";
            txtTotalDays.Text = " ";
            progressBar1.Value = 0;
        }

        private void btnRevenue_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtRevenue.Text = " ";
            txtTotalDays.Text = " ";
            progressBar1.Value = 0;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dashboard = new Form2();
            dashboard.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
