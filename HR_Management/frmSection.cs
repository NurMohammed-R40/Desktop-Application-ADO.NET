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
    public partial class frmSection : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
        public frmSection()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            string exist = "";
            SqlCommand cm = new SqlCommand("SELECT * FROM tblSection WHERE Section='" + txtSection.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Section"].ToString();
            }
            con.Close();

            if (txtSection.Text.Length == 0)
            {
                MessageBox.Show("You Have To Give A Section Name!!!");
            }
            else if (txtSection.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtSection.Text + " Section Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblSection VALUES('" + txtSection.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted successfully!!!");
                LoadGrid();
                txtSection.Clear();
                txtSection.Focus();
                con.Close();
                LoadID();
            }
        }

        private void frmSection_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadID();
        }
        private void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT SectionId AS ID, Section FROM tblSection", con);
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
            SqlCommand cm = new SqlCommand("SELECT * FROM tblSection WHERE Section='" + txtSection.Text + "' ", con);
            SqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                exist = dr["Section"].ToString();
            }
            con.Close();

            if (cmbID.Text == "")
            {
                MessageBox.Show("Please Select A Section ID");
            }
            else if (txtSection.Text.Length == 0)
            {
                MessageBox.Show("Please Give A Name Of Section");
            }
            else if (txtSection.Text.ToLower() == exist.ToLower())
            {
                MessageBox.Show("" + txtSection.Text + " Section Already Exist!!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE tblSection SET Section = '" + txtSection.Text + "' WHERE SectionId=" + cmbID.SelectedValue + "";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated successfully!!!");
                LoadGrid();
                txtSection.Clear();
                txtSection.Focus();
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblSection", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmbID.DisplayMember = ds.Tables[0].Columns["SectionId"].ToString();
            cmbID.ValueMember = ds.Tables[0].Columns["SectionId"].ToString();
            cmbID.DataSource = ds.Tables[0];
            con.Close();
            cmbID.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbID.Text == "")
            {
                MessageBox.Show("Plese Select A Section ID");
            }
            else
            {
                con.Open();
                string str = "SELECT * FROM tblSection WHERE SectionId = '" + cmbID.SelectedValue + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cmbID.SelectedValue = dr["SectionId"].ToString();
                    txtSection.Text = dr["Section"].ToString();
                }
                else
                {
                    MessageBox.Show("No Section Found...");
                }
                con.Close();
            }

        }
    }
}
