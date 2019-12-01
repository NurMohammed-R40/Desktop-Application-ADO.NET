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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter A Username");
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Enter A Mobile No.");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Enter An Email");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter A Password");
            }
            else if (txtConfirm.Text == "")
            {
                MessageBox.Show("Enter The Password Again");
            }
            else if (txtConfirm.Text != txtPassword.Text)
            {
                MessageBox.Show("Password Not Match");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO tblUser VALUES('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtEmail.Text + "','" + txtContact.Text + "')";
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Registration successfully!!!";
                txtUsername.Clear();
                txtPassword.Clear();
                txtConfirm.Clear();
                txtEmail.Clear();
                txtContact.Clear();
                txtUsername.Focus();
                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
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
        private void No_Space_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ab = e.KeyChar;
            if (ab == 32)
            {
                MessageBox.Show("Space Not Allowed!!!");
                e.Handled = true;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            string email = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[0-9a-zA-Z]{2,9})$";
            if (txtEmail.Text == "" || Regex.IsMatch(txtEmail.Text, email))
            {

            }
            else
            {
                MessageBox.Show("Invalid Email!!!\nFor Example:-\nuser@example.com");
                txtEmail.Focus();
            }
        }

    }
}
