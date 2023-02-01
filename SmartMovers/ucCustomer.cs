using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartMovers
{
    public partial class ucCustomer : UserControl
    {
        public ucCustomer()
        {
            InitializeComponent();
            
        }
        static string cs = @"server=localhost;userid=root;password=1234;database=dbsmartmovers;Charset=utf8";
        MySqlConnection con = new MySqlConnection(cs);

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string myCommand = "INSERT INTO dbsmartmovers.tbl_customer(cust_id,cust_name,cust_type,cust_address)VALUES('" + txtCustId.Text + "','" + txtFname.Text + "','" + txtCusttype.Text + "','" +txtAddress.Text+ "');";
                MySqlCommand cmd = new MySqlCommand(myCommand, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Added", "Smart Movers Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAllTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Smart Movers Managment System", MessageBoxButtons.OK);
            }
            finally
            {
                con.Close();
            }

        }



        private void clearAllTextbox()
        {
            txtCustId.Text = "";
            txtAddress.Text="";
            txtContact.Text="";
            txtCusttype.Text="";
            txtFname.Text = "";
            txtSerach.Text = "";

            
        }

        private void btnAddMore_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string myCommand = "INSERT INTO dbsmartmovers.tbl_cust_contact(cust_id,contact)VALUES('" + txtCustId.Text + "','" + txtContact.Text + "');";
                MySqlCommand cmd = new MySqlCommand(myCommand, con);
                cmd.ExecuteNonQuery();
                txtContact.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            GridFill();
         
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearAllTextbox();
        }

        private void dgvCustDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(cs))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("smartMoversViewAll", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblbook = new DataTable();
                sqlDa.Fill(dtblbook);
                dgvCustDetails.DataSource = dtblbook;

            }
            using (MySqlConnection mysqlCon = new MySqlConnection(cs))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("smartMoversCustcontactViewAll", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblbook = new DataTable();
                sqlDa.Fill(dtblbook);
                dvgContact.DataSource = dtblbook;
               

            }
           

        }
        private void setDataGridView(DataGridView dgvCustDetails)
        {

            try
            {
                MySqlCommand resultscommand = null;
                MySqlDataAdapter mysqladp = new MySqlDataAdapter();
                DataTable resultstable = new DataTable();
                resultscommand = new MySqlCommand("select * from tbl_customer", con);
                mysqladp.SelectCommand = resultscommand;
                mysqladp.Fill(resultstable);
                dgvCustDetails.DataSource = resultstable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Smart Movers Managemetn System - Registation - Set Data  Gridview Customer");
            }
        }

        private void ucCustomer_Load(object sender, EventArgs e)
        {
            GridFill();
        }

        private void dgvCustDetails_MouseClick(object sender, MouseEventArgs e)
        {
            
            txtCustId.Text = dgvCustDetails.CurrentRow.Cells[0].Value.ToString();
            txtFname.Text = dgvCustDetails.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvCustDetails.CurrentRow.Cells[3].Value.ToString();
            txtCusttype.Text = dgvCustDetails.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnDelette_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string myCommand = "DELETE FROM dbsmartmovers.tbl_customer WHERE cust_id='" +txtCustId.Text + "';";
                MySqlCommand cmd = new MySqlCommand(myCommand, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Do you want to Deleting?", "Delete Record!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                clearAllTextbox();
                GridFill();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "School_System");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btmUpdate_Click(object sender, EventArgs e)
        {

        //    cust_id varchar(10) PK 
        //cust_name varchar(60) 
        //    cust_type varchar(10) 
        //    cust_address varchar(70)
            try
            {
                con.Open();
                string myCommand = "UPDATE dbsmartmovers.tbl_customer SET cust_name = '" + txtFname.Text + "',cust_type='" + txtCusttype.Text + "',cust_address = '" + txtAddress.Text + "' WHERE cust_id = '" + txtCustId.Text+ "';";
                MySqlCommand cmd = new MySqlCommand(myCommand, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated", "Smart Movers Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAllTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Smart Movers Management System");
            }
            finally
            {
                con.Close();
            }
            GridFill();
        }

        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(cs))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("smartMoversSearch", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_SearchValue",txtSerach.Text);
                DataTable dtblcust = new DataTable();
                sqlDa.Fill(dtblcust);
                dgvCustDetails.DataSource = dtblcust;


            }
            using (MySqlConnection mysqlCon = new MySqlConnection(cs))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("smartMoversContactSearch", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_SearchValue", txtSerach.Text);
                DataTable dtblcustcontact = new DataTable();
                sqlDa.Fill(dtblcustcontact);
                dvgContact.DataSource = dtblcustcontact;


            }
        }
    }
}//end of name scape
