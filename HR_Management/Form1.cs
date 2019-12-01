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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void departmentEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartment dept = new frmDepartment();
            dept.MdiParent = this;
            dept.Show();
        }

        private void designationEntyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignation desig = new frmDesignation();
            desig.MdiParent = this;
            desig.Show();
        }

        private void sectionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection();
            sec.MdiParent = this;
            sec.Show();
        }

        private void countryEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCountry co = new frmCountry();
            co.MdiParent = this;
            co.Show();
        }

        private void cityEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCity city = new frmCity();
            city.MdiParent = this;
            city.Show();
        }

        private void employeeEntryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEmployee emp = new frmEmployee();
            emp.MdiParent = this;
            emp.Show();
        }

        private void allEmployeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAllEmployee alE = new frmAllEmployee();
            alE.MdiParent = this;
            alE.Show();
        }

        private void departmentWiseEmployeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentWiseEmployee dpE = new frmDepartmentWiseEmployee();
            dpE.MdiParent = this;
            dpE.Show();

        }

        private void designationWiseEmployeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignationWiseEmployee dsE = new frmDesignationWiseEmployee();
            dsE.MdiParent = this;
            dsE.Show();
        }
    }
}
