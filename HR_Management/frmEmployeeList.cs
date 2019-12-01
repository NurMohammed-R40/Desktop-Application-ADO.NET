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
    public partial class frmEmployeeList : Form
    {
        List<spEmployeeList_Result> list;
        public frmEmployeeList(List<spEmployeeList_Result> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            EmployeeList1.SetDataSource(list);
            crystalReportViewer1.Refresh();
        }
    }
}
