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
    public partial class frmCity : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");

        public frmCity()
        {
            InitializeComponent();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCountry", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbCountry.DisplayMember = ds.Tables[0].Columns["Country"].ToString();
            cmbCountry.ValueMember = ds.Tables[0].Columns["CountryId"].ToString();
            cmbCountry.DataSource = ds.Tables[0];
            con.Close();
            cmbCountry.SelectedIndex = -1;
            LoadGrid();
            LoadID();
        }
        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT c.CityId AS ID, co.Country, c.City FROM tblCity c INNER JOIN tblCountry co ON c.CountryId=co.CountryId ORDER BY co.Country", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string city = "";
            int country = 0;
            SqlCommand cm = new SqlCommand("SELECT * FROM tblCity WHERE City='" + txtCity.Text + "' AND CountryId="+cmbCountry.SelectedValue+"", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                city = dr["City"].ToString();
                country = Convert.ToInt32(dr["CountryId"]);
            }
            con.Close();

            if (cmbCountry.Text == "")
            {
                MessageBox.Show("You Have To Select A Country!!!");
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("You Have To Give A City Name!!!");
            }
            else if (txtCity.Text.ToLower() == city.ToLower() && Convert.ToInt32(cmbCountry.SelectedValue)==country)
            {
                MessageBox.Show("City " + txtCity.Text + " In "+cmbCountry.Text+" Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblCity VALUES(" + cmbCountry.SelectedValue + ",'" + txtCity.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                LoadGrid();
                txtCity.Clear();
                txtCity.Focus();
                cmbCountry.SelectedIndex = -1;
                con.Close();
                LoadID();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            string city = "";
            int country = 0;
            SqlCommand cm = new SqlCommand("SELECT * FROM tblCity WHERE City='" + txtCity.Text + "' AND CountryId=" + cmbCountry.SelectedValue + "", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                city = dr["City"].ToString();
                country = Convert.ToInt32(dr["CountryId"]);
            }
            con.Close();

            if (cmbID.Text == "")
            {
                MessageBox.Show("Please Select A City ID");
            }
            else if (cmbCountry.Text == "")
            {
                MessageBox.Show("Please Select A Country");
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("Please Give A Name Of City");
            }
            else if (txtCity.Text.ToLower() == city.ToLower() && Convert.ToInt32(cmbCountry.SelectedValue) == country)
            {
                MessageBox.Show("City " + txtCity.Text + " In " + cmbCountry.Text + " Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblCity SET CountryID = '" + cmbCountry.SelectedValue + "', City = '" + txtCity.Text + "' WHERE CityId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                LoadGrid();
                txtCity.Clear();
                txtCity.Focus();
                cmbCountry.SelectedIndex = -1;
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblCity", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["CityId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["CityId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
            cmbID.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select A City ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblCity WHERE CityId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["CityId"].ToString();
                    cmbCountry.SelectedValue = dr["CountryID"].ToString();
                    txtCity.Text = dr["City"].ToString();
                }
                else
                {
                    MessageBox.Show("No City Found...");
                }
                con.Close();
            }

        }
    }
}
