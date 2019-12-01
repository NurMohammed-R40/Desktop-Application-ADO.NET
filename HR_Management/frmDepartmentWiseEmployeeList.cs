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
    public partial class frmDepartmentWiseEmployeeList : Form
    {
        List<spDepartmentWiseEmployeeList_Result> list;
        public frmDepartmentWiseEmployeeList(List<spDepartmentWiseEmployeeList_Result> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void frmDepartmentWiseEmployeeList_Load(object sender, EventArgs e)
        {
            DepartmentWiseEmployee1.SetDataSource(list);
            crystalReportViewer2.Refresh();
        }
    }
}
