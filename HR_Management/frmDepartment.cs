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
    public partial class frmDepartment : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
        public frmDepartment()
        {
            InitializeComponent();
        }

        private void btnDeptInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string exist = "";
            SqlCommand cm = new SqlCommand("SELECT * FROM tblDepartment WHERE Department='" + txtDeptName.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Department"].ToString();
            }
            con.Close();

            if (txtDeptName.Text.Length == 0)
            {
                MessageBox.Show("You Have To Give A Department Name!!!");
            }
            else if (txtDeptName.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtDeptName.Text + " Department Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblDepartment VALUES('" + txtDeptName.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                LoadGrid();
                txtDeptName.Clear();
                txtDeptName.Focus();
                con.Close();
                LoadID();
            }
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadID();
        }

        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT DepartmentId AS ID, Department FROM tblDepartment", con);
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
            SqlCommand cm = new SqlCommand("SELECT * FROM tblDepartment WHERE Department='" + txtDeptName.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Department"].ToString();
            }
            con.Close();

            if (cmbID.Text == "")
            {
                MessageBox.Show("Please Select A Department ID");
            }
            else if (txtDeptName.Text.Length == 0)
            {
                MessageBox.Show("Please Give A Name Of Departmet");
            }
            else if (txtDeptName.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtDeptName.Text + " Department Already Exist!!!");
            }

            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblDepartment SET Department = '" + txtDeptName.Text + "' WHERE DepartmentId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                LoadGrid();
                txtDeptName.Clear();
                txtDeptName.Focus();
                con.Close();
                LoadID();
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDepartment", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["DepartmentId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["DepartmentId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
            cmbID.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select A Department ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblDepartment WHERE DepartmentId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["DepartmentId"].ToString();
                    txtDeptName.Text = dr["Department"].ToString();
                }
                else
                {
                    MessageBox.Show("No Department Found...");
                }
                con.Close();
            }
        }
    }
}
