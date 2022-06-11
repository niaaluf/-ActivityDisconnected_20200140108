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


namespace DisconnectedEnvironment
{
    public partial class Form1 : Form
    {

        DataTable dt;
        DataRow dr;
        string code;

        public Form1()
        {
            InitializeComponent();

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hRDataSet9.empdetails' table. You can move, or remove it, as needed.
            this.empdetailsTableAdapter7.Fill(this.hRDataSet9.empdetails);

         
            
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            cbDesignation.Items.Add("MANAGER");
            cbDesignation.Items.Add("AUTHOR");
            cbDesignation.Items.Add("DESIGNER");
            cbDepartment.Items.Add("MARKETING");
            cbDepartment.Items.Add("FINANCE");
            cbDepartment.Items.Add("IDO");
            cmdSave.Enabled = false;

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            cbDesignation.Enabled = true;
            cbDepartment.Enabled = true;
            txtName.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            cbDesignation.Text = "";
            cbDepartment.Text = "";
            int ctr, len;
            string codeval;
            dt = hRDataSet9.Tables["empdetails"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr >= 1)&& (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C00" + ctr;
            }
            else if ((ctr >= 9)&&(ctr < 99))
            {
                ctr = ctr + 1;
                txtCode.Text = "C0" + ctr;
            }
            else if (ctr >= 99)
            {
                ctr = ctr + 1;
                txtCode.Text = "C" + ctr;
            }
            cmdAdd.Enabled = false;

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = hRDataSet9.Tables["empdetails"];
            dr = dt.NewRow();
            dr[0] = txtCode.Text;
            dr[1] = txtName.Text;
            dr[2] = txtAddress.Text;
            dr[3] = txtState.Text;
            dr[4] = txtCountry.Text;
            dr[5] = cbDesignation.SelectedItem;
            dr[6] = cbDepartment.SelectedItem;
            dt.Rows.Add(dr);
            empdetailsTableAdapter7.Update(hRDataSet9);
            txtCode.Text = System.Convert.ToString(dr[0]);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            cbDesignation.Enabled = false;
            cbDepartment.Enabled = false;
            this.empdetailsTableAdapter7.Fill(this.hRDataSet9.empdetails);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtCode.Text;
            dr = hRDataSet9.Tables["empdetails"].Rows.Find(code);
            dr.Delete();
            empdetailsTableAdapter7.Update(hRDataSet9);
        }

        private void bindingNavigatorCountItem_Click(object sender, EventArgs e)
        {

        }
    }
}
