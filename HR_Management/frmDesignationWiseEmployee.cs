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
    public partial class frmDesignationWiseEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");

        public frmDesignationWiseEmployee()
        {
            InitializeComponent();
        }

        private void frmDesignationWiseEmployee_Load(object sender, EventArgs e)
        {
            LoadDepartment();
            LoadDesignation();
        }
        private void No_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Select One From Drop-Down List");
            e.Handled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (HR_DBEntities3 db = new HR_DBEntities3())
            {
                int Department = Convert.ToInt32(cmbDepartment.SelectedValue);
                int Designation = Convert.ToInt32(cmbDesignation.SelectedValue);
                spDesignationWiseEmployeeListResultBindingSource.DataSource = db.spDesignationWiseEmployeeList(Department,Designation).ToList();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<spDesignationWiseEmployeeList_Result> list = spDesignationWiseEmployeeListResultBindingSource.DataSource as List<spDesignationWiseEmployeeList_Result>;
            if (list != null)
            {
                using (frmDesignationWiseEmployeeList frm = new frmDesignationWiseEmployeeList(list))
                {
                    frm.ShowDialog();
                }
            }

        }
    }
}
