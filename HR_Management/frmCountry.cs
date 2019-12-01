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
    public partial class frmCountry : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
        public frmCountry()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string exist = "";
            SqlCommand cm = new SqlCommand("SELECT * FROM tblCountry WHERE Country='" + txtCountry.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Country"].ToString();
            }
            con.Close();

            if (txtCountry.Text == "")
            {
                MessageBox.Show("You Have To Give A Country Name!!!");
            }
            else if (txtCountry.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("Country " + txtCountry.Text + " Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblCountry VALUES('" + txtCountry.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                LoadGrid();
                txtCountry.Clear();
                txtCountry.Focus();
                con.Close();
                LoadID();
            }
        }

        private void frmCountry_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadID();
        }
        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT CountryId AS ID, Country FROM tblCountry", con);
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
            SqlCommand cm = new SqlCommand("SELECT * FROM tblCountry WHERE Country='" + txtCountry.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Country"].ToString();
            }
            con.Close();


            if (cmbID.Text == "")
            {
                MessageBox.Show("Please Select A Country ID");
            }
            else if (txtCountry.Text.Length == 0)
            {
                MessageBox.Show("Please Give A Name Of Country");
            }
            else if (txtCountry.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("Country " + txtCountry.Text + " Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblCountry SET Country = '" + txtCountry.Text + "' WHERE CountryId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                LoadGrid();
                txtCountry.Clear();
                txtCountry.Focus();
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCountry", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["CountryId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["CountryId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
            cmbID.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select A Country ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblCountry WHERE CountryId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["CountryId"].ToString();
                    txtCountry.Text = dr["Country"].ToString();
                }
                else
                {
                    MessageBox.Show("No Country Found...");
                }
                con.Close();
            }

        }
    }
}
