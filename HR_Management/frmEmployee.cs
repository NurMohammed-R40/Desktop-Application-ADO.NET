using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Management
{
    public partial class frmEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True;MultipleActiveResultSets=true");

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadID();
            LoadCountry();
            LoadDepartment();
            LoadDesignation();
            LoadSection();
            ClearAll();
        }
        private void LoadID()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblEmployee", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["EmployeeId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["EmployeeId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
        }
        private void LoadCountry()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCountry", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Select Country";
            dt.Rows.InsertAt(dr, 0);
            cmbCountry.DataSource = dt;
            cmbCountry.DisplayMember = "Country";
            cmbCountry.ValueMember = "CountryId";
            con.Close();
        }
        private void LoadDepartment()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDepartment", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDepartment.DisplayMember = ds.Tables[0].Columns["Department"].ToString();
            cmbDepartment.ValueMember = ds.Tables[0].Columns["DepartmentId"].ToString();
            cmbDepartment.DataSource = ds.Tables[0];
            con.Close();
        }
        private void LoadDesignation()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDesignation", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbDesignation.DisplayMember = ds.Tables[0].Columns["Designation"].ToString();
            cmbDesignation.ValueMember = ds.Tables[0].Columns["DesignationId"].ToString();
            cmbDesignation.DataSource = ds.Tables[0];
            con.Close();
        }
        private void LoadSection()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSection", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbSection.DisplayMember = ds.Tables[0].Columns["Section"].ToString();
            cmbSection.ValueMember = ds.Tables[0].Columns["SectionId"].ToString();
            cmbSection.DataSource = ds.Tables[0];
            con.Close();
        }
        private void ClearAll()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtSalary.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            cmbID.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;
            cmbReligion.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
            cmbSection.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;

        }
        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCity WHERE CountryId=" + cmbCountry.SelectedValue + "", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCity.DisplayMember = ds.Tables[0].Columns["City"].ToString();
            cmbCity.ValueMember = ds.Tables[0].Columns["CityId"].ToString();
            cmbCity.DataSource = ds.Tables[0];
            con.Close();
            cmbCity.SelectedIndex = -1;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Enter A Employee Name!!!");
            }
            else if (cmbGender.Text == "")
            {
                MessageBox.Show("Select Gender!!!");
            }
            else if (cmbReligion.Text == "")
            {
                MessageBox.Show("Select Religion!!!");
            }
            else if (cmbCity.Text == "")
            {
                MessageBox.Show("Select City!!!");
            }
            else if (cmbDepartment.Text == "")
            {
                MessageBox.Show("Select Department!!!");
            }
            else if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Select Designation!!!");
            }
            else if (cmbSection.Text == "")
            {
                MessageBox.Show("Select Section!!!");
            }
            else if (txtSalary.Text == "")
            {
                MessageBox.Show("Enter Salary!!!");
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Enter Mobile No.!!!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Email!!!");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Full Address!!!");
            }
            else if (dtJoinDate.Value<=dtDOB.Value)
            {
                MessageBox.Show("A Man Can't Join Work Before His Birth !!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblEmployee VALUES('" + txtName.Text + "'," + cmbDepartment.SelectedValue + "," + cmbDesignation.SelectedValue + "," + cmbSection.SelectedValue + ",'" + dtJoinDate.Value.ToString() + "'," + txtSalary.Text + ",'" + dtDOB.Value.ToString() + "','" + cmbGender.SelectedItem + "','" + cmbReligion.SelectedItem + "'," + cmbCountry.SelectedValue + "," + cmbCity.SelectedValue + ",'" + txtAddress.Text + "','" + txtContact.Text + "','" + txtEmail.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                con.Close();
                ClearAll();
                LoadID();
                LoadCountry();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select An Employee ID");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM tblEmployee WHERE EmployeeId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted successfully!!!");
                con.Close();
                ClearAll();
                LoadID();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select An Employee ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblEmployee e INNER JOIN tblCountry co ON e.CountryId = co.CountryId INNER JOIN tblCity ci ON e.CityId = ci.CityId INNER JOIN tblDepartment d ON e.DepartmentId = d.DepartmentId INNER JOIN tblDesignation dg ON e.DesignationId = dg.DesignationId INNER JOIN tblSection s ON e.SectionId = s.SectionId WHERE e.EmployeeId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["EmployeeId"].ToString();
                    txtName.Text = dr["Name"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    dtDOB.Text = dr["DateOfBirth"].ToString();
                    txtSalary.Text = dr["Salary"].ToString();
                    txtContact.Text = dr["Contact"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    dtJoinDate.Text = dr["JoiningDate"].ToString();
                    cmbDesignation.SelectedValue = dr["DesignationId"].ToString();
                    cmbSection.SelectedValue = dr["SectionId"].ToString();
                    cmbDepartment.SelectedValue = dr["DepartmentId"].ToString();
                    cmbGender.SelectedItem = dr["Gender"].ToString();
                    cmbReligion.SelectedItem = dr["Religion"].ToString();
                    cmbCountry.SelectedValue = dr["CountryId"].ToString();
                    //cmbCity.SelectedValue = dr["CityId"].ToString();
                }
                else
                {
                    MessageBox.Show("No Employee Found...");
                }
                con.Close();
                //cmbCity.SelectedIndex = -1;
                LoadCountry();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select An Employee ID");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Enter A Employee Name!!!");
            }
            else if (cmbGender.Text == "")
            {
                MessageBox.Show("Select Gender!!!");
            }
            else if (cmbReligion.Text == "")
            {
                MessageBox.Show("Select Religion!!!");
            }
            else if (cmbCity.Text == "")
            {
                MessageBox.Show("Select City!!!");
            }
            else if (cmbDepartment.Text == "")
            {
                MessageBox.Show("Select Department!!!");
            }
            else if (cmbDesignation.Text == "")
            {
                MessageBox.Show("Select Designation!!!");
            }
            else if (cmbSection.Text == "")
            {
                MessageBox.Show("Select Section!!!");
            }
            else if (txtSalary.Text == "")
            {
                MessageBox.Show("Enter Salary!!!");
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Enter Mobile No.!!!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter Email!!!");
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Full Address!!!");
            }
            else if (dtJoinDate.Value <= dtDOB.Value)
            {
                MessageBox.Show("A Man Can't Join Work Before His Birth !!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblEmployee SET Name='" + txtName.Text + "', DepartmentId=" + cmbDepartment.SelectedValue + ", DesignationId=" + cmbDesignation.SelectedValue + ", SectionId=" + cmbSection.SelectedValue + ", JoiningDate='" + dtJoinDate.Value.ToString() + "', Salary = " + txtSalary.Text + ", DateOfBirth='" + dtDOB.Value.ToString() + "', Gender='" + cmbGender.SelectedItem + "', Religion= '" + cmbReligion.SelectedItem + "', CountryId =" + cmbCountry.SelectedValue + ",CityId=" + cmbCity.SelectedValue + ",Address='" + txtAddress.Text + "', Contact='" + txtContact.Text + "', Email='" + txtEmail.Text + "' WHERE EmployeeId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                con.Close();
                ClearAll();
                LoadCountry();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please Enter A Name");
            }
            else
            {
                con.Open();
                string str = "SELECT e.EmployeeId AS ID, e.Name, d.Department,dg.Designation,s.Section,e.JoiningDate AS [Joining Date],CAST(e.Salary AS NUMERIC(10,2)) AS Salary, e.DateOfBirth AS [Date Of Birth] ,co.Country,ci.City,e.Address,e.Email,e.Contact AS [Mobile No.],e.Gender,e.Religion  FROM tblEmployee e INNER JOIN tblCountry co ON e.CountryId = co.CountryId INNER JOIN tblCity ci ON e.CityId = ci.CityId INNER JOIN tblDepartment d ON e.DepartmentId = d.DepartmentId INNER JOIN tblDesignation dg ON e.DesignationId = dg.DesignationId INNER JOIN tblSection s ON e.SectionId = s.SectionId WHERE e.Name LIKE '%" + txtName.Text + "%' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd); 
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Employee Found...");
                }
                con.Close();
            }
        }
        private void Only_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ab = e.KeyChar;
            if (Char.IsDigit(ab) == true || ab == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Only Numbers Are Allowed");
                e.Handled = true;
            }
        }
        private void Money_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ab = e.KeyChar;
            if (Char.IsDigit(ab) == true || ab == 8 || ab == 46)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Money Should Be In Number");
                e.Handled = true;
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
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[0-9a-zA-Z]{2,9})$";
            if (txtEmail.Text=="" || Regex.IsMatch(txtEmail.Text, email))
            {

            }
            else
            {
                MessageBox.Show("Invalid Email!!!\nFor Example:-\nuser@example.com");
                txtEmail.Focus();
            }
        }
        private void txtSalary_Leave(object sender, EventArgs e)
        {
            string email = "^([0-9]*[\\.]?[0-9]+)$";
            if (txtSalary.Text=="" || Regex.IsMatch(txtSalary.Text, email))
            {

            }
            else
            {
                MessageBox.Show("Invalid Money Format");
                txtSalary.Focus();
            }
        }

    }
}
