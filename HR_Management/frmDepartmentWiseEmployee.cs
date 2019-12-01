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
    public partial class frmDepartmentWiseEmployee : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HR_DB;Integrated Security=True");
        public frmDepartmentWiseEmployee()
        {
            InitializeComponent();
        }

        private void frmDepartmentWiseEmployee_Load(object sender, EventArgs e)
        {
            LoadDepartment();
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
        private void No_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Select One From Drop-Down List");
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (HR_DBEntities2 db = new HR_DBEntities2())
            {
                int Department = Convert.ToInt32(cmbDepartment.SelectedValue);
                spDepartmentWiseEmployeeListResultBindingSource.DataSource = db.spDepartmentWiseEmployeeList(Department).ToList();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<spDepartmentWiseEmployeeList_Result> list = spDepartmentWiseEmployeeListResultBindingSource.DataSource as List<spDepartmentWiseEmployeeList_Result>;
            if (list != null)
            {
                using (frmDepartmentWiseEmployeeList frm = new frmDepartmentWiseEmployeeList(list))
                {
                    frm.ShowDialog();
                }
            }
        }

    }
}
