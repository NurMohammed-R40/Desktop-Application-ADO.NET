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
    public partial class frmDesignationWiseEmployeeList : Form
    {
        List<spDesignationWiseEmployeeList_Result> list;
        public frmDesignationWiseEmployeeList(List<spDesignationWiseEmployeeList_Result> list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void frmDesignationWiseEmployeeList_Load(object sender, EventArgs e)
        {
            DesignationWiseEmployee1.SetDataSource(list);
            crystalReportViewer3.Refresh();
        }
    }
}
