using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartMovers
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ucProdcut1.BringToFront();
            lblHome.Text = "Product Registration";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            ucJob1.BringToFront();
            lblHome.Text = "Job Registration";
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ucCustomer1.BringToFront(); 
            lblHome.Text = "Customer Registration";
        }
        

        private void btnDeport_Click(object sender, EventArgs e)
        {
            ucDepot1.BringToFront();
            lblHome.Text = "Depot Registration";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ucLoad11.BringToFront();
            lblHome.Text = "Load Registration";

        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            ucTransport1.BringToFront();
            lblHome.Text = "Trasport";
            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ucEmployee1.BringToFront();
            lblHome.Text = "Employee Registration";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToString("yyyy-MMM-dd | hh:mm:ss tt");
        }
    }
}
