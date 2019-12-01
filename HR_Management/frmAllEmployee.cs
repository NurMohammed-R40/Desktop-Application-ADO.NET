using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Management
{
    public partial class frmAllEmployee : Form
    {
        public frmAllEmployee()
        {
            InitializeComponent();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<spEmployeeList_Result> list = spEmployeeListResultBindingSource.DataSource as List<spEmployeeList_Result>;
            if (list != null)
            {
                using(frmEmployeeList frm = new frmEmployeeList(list))
                {
                    frm.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (HR_DBEntities db = new HR_DBEntities())
            {
                spEmployeeListResultBindingSource.DataSource = db.spEmployeeList().ToList();
            }
        }

    }
}
