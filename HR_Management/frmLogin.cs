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
    public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblUser WHERE Username='"+txtUser.Text+"' and Password='"+txtPassword.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmRegistration().Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            label4.Text = "Project Made by";
            label5.Text = "Nur Mohammed";
            label6.Text = "ID-1248604";
            label7.Text = "ESAD-CS/PNTL-M/40/01";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnlogin.Enabled = true;
        }
        private void Only_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ab = e.KeyChar;
            if (Char.IsDigit(ab) == true || ab==8)
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
            if (ab==32)
            {
                MessageBox.Show("Space Not Allowed!!!");
                e.Handled = true;
            }
        }

    }
}
