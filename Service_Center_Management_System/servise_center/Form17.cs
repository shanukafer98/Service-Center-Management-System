using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace servise_center
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Form17_Load(object sender, EventArgs e)
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

            treeView1.Nodes.Add("Motorbike");
            treeView1.Nodes.Add("Threewheeler");
            treeView1.Nodes.Add("Car");
            treeView1.Nodes.Add("Van");
            treeView1.Nodes.Add("Lorry");

            treeView1.Nodes[0].Nodes.Add("Full Service  Rs.1500.00");
            treeView1.Nodes[0].Nodes.Add("Interior Cleaning  Rs.800.00");
            treeView1.Nodes[0].Nodes.Add("Exterior Cleaning  Rs.500.00");
            treeView1.Nodes[0].Nodes.Add("Change oil  Rs.1000.00");

            treeView1.Nodes[1].Nodes.Add("Full Service  Rs.3000.00");
            treeView1.Nodes[1].Nodes.Add("Interior Cleaning  Rs.1000.00");
            treeView1.Nodes[1].Nodes.Add("Exterior Cleaning  Rs.1000.00");
            treeView1.Nodes[1].Nodes.Add("Change oil  Rs.1000.00");

            treeView1.Nodes[2].Nodes.Add("Full Service  Rs.6000.00");
            treeView1.Nodes[2].Nodes.Add("Interior Cleaning  Rs.2000.00");
            treeView1.Nodes[2].Nodes.Add("Exterior Cleaning  Rs.1000.00");
            treeView1.Nodes[2].Nodes.Add("Change oil  Rs.3000.00");


            treeView1.Nodes[3].Nodes.Add("Full Service  Rs.8000.00");
            treeView1.Nodes[3].Nodes.Add("Interior Cleaning  Rs.3000.00");
            treeView1.Nodes[3].Nodes.Add("Exterior Cleaning  Rs.2000.00");
            treeView1.Nodes[3].Nodes.Add("Change oil  Rs.3000.00");

            treeView1.Nodes[4].Nodes.Add("Full Service  Rs.12000.00");
            treeView1.Nodes[4].Nodes.Add("Interior Cleaning  Rs.3000.00");
            treeView1.Nodes[4].Nodes.Add("Exterior Cleaning  Rs.2000.00");
            treeView1.Nodes[4].Nodes.Add("Change oil  Rs.7000.00");


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 dashboard = new Form4();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dashboard = new Form2();
            dashboard.Show();
            this.Hide();    
        }
    }
}
