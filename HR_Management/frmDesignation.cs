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

namespace HR_Management
{
    public partial class frmDesignation : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
        public frmDesignation()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string exist = "";
            SqlCommand cm = new SqlCommand("SELECT * FROM tblDesignation WHERE Designation='" + txtDesignation.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Designation"].ToString();
            }
            con.Close();

            if (txtDesignation.Text.Length == 0)
            {
                MessageBox.Show("You Have To Give A Designation Name!!!");
            }
            else if (txtDesignation.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtDesignation.Text + " Designation Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblDesignation VALUES('" + txtDesignation.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                LoadGrid();
                txtDesignation.Clear();
                txtDesignation.Focus();
                con.Close();
                LoadID();
            }
        }

        private void frmDesignation_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadID();
        }
        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT DesignationId AS ID, Designation FROM tblDesignation", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string exist = "";
            SqlCommand cm = new SqlCommand("SELECT * FROM tblDesignation WHERE Designation='" + txtDesignation.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Designation"].ToString();
            }
            con.Close();

            if (cmbID.Text == "")
            {
                MessageBox.Show("Please Select A Designation ID");
            }
            else if (txtDesignation.Text.Length == 0)
            {
                MessageBox.Show("Please Give A Name Of Designagtion");
            }
            else if (txtDesignation.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtDesignation.Text + " Designation Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblDesignation SET Designation = '" + txtDesignation.Text + "' WHERE DesignationId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                LoadGrid();
                txtDesignation.Clear();
                txtDesignation.Focus();
                con.Close();
            }
        }
        private void Only_Letter_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ab = e.KeyChar;
            if (Char.IsLetter(ab) == true || ab == 8 || ab == 32 || ab == 45 || ab == 46)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Only Letters, Space, Hyphen and Dot Are Allowed");
                e.Handled = true;
            }
        }
        private void No_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Select One From Drop-Down List");
            e.Handled = true;
        }
        private void LoadID()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDesignation", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["DesignationId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["DesignationId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
            cmbID.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select A Designation ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblDesignation WHERE DesignationId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["DesignationId"].ToString();
                    txtDesignation.Text = dr["Designation"].ToString();
                }
                else
                {
                    MessageBox.Show("No Designation Found...");
                }
                con.Close();
            }
        }
    }
}
