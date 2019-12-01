namespace HR_Management
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hREntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designationEntyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryEntryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cityEntryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeEntryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeEntryToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allEmployeeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentWiseEmployeeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designationWiseEmployeeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hREntryToolStripMenuItem,
            this.countryEntryToolStripMenuItem,
            this.employeeEntryToolStripMenuItem1,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hREntryToolStripMenuItem
            // 
            this.hREntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentEntryToolStripMenuItem,
            this.designationEntyToolStripMenuItem,
            this.sectionEntryToolStripMenuItem});
            this.hREntryToolStripMenuItem.Name = "hREntryToolStripMenuItem";
            this.hREntryToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.hREntryToolStripMenuItem.Text = "HR Entry";
            // 
            // departmentEntryToolStripMenuItem
            // 
            this.departmentEntryToolStripMenuItem.Name = "departmentEntryToolStripMenuItem";
            this.departmentEntryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.departmentEntryToolStripMenuItem.Text = "Department Entry";
            this.departmentEntryToolStripMenuItem.Click += new System.EventHandler(this.departmentEntryToolStripMenuItem_Click);
            // 
            // designationEntyToolStripMenuItem
            // 
            this.designationEntyToolStripMenuItem.Name = "designationEntyToolStripMenuItem";
            this.designationEntyToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.designationEntyToolStripMenuItem.Text = "Designation Enty";
            this.designationEntyToolStripMenuItem.Click += new System.EventHandler(this.designationEntyToolStripMenuItem_Click);
            // 
            // sectionEntryToolStripMenuItem
            // 
            this.sectionEntryToolStripMenuItem.Name = "sectionEntryToolStripMenuItem";
            this.sectionEntryToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sectionEntryToolStripMenuItem.Text = "Section Entry";
            this.sectionEntryToolStripMenuItem.Click += new System.EventHandler(this.sectionEntryToolStripMenuItem_Click);
            // 
            // countryEntryToolStripMenuItem
            // 
            this.countryEntryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countryEntryToolStripMenuItem1,
            this.cityEntryToolStripMenuItem1});
            this.countryEntryToolStripMenuItem.Name = "countryEntryToolStripMenuItem";
            this.countryEntryToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.countryEntryToolStripMenuItem.Text = "Country Entry";
            // 
            // countryEntryToolStripMenuItem1
            // 
            this.countryEntryToolStripMenuItem1.Name = "countryEntryToolStripMenuItem1";
            this.countryEntryToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.countryEntryToolStripMenuItem1.Text = "Country Entry";
            this.countryEntryToolStripMenuItem1.Click += new System.EventHandler(this.countryEntryToolStripMenuItem1_Click);
            // 
            // cityEntryToolStripMenuItem1
            // 
            this.cityEntryToolStripMenuItem1.Name = "cityEntryToolStripMenuItem1";
            this.cityEntryToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.cityEntryToolStripMenuItem1.Text = "City Entry";
            this.cityEntryToolStripMenuItem1.Click += new System.EventHandler(this.cityEntryToolStripMenuItem1_Click);
            // 
            // employeeEntryToolStripMenuItem1
            // 
            this.employeeEntryToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeEntryToolStripMenuItem2});
            this.employeeEntryToolStripMenuItem1.Name = "employeeEntryToolStripMenuItem1";
            this.employeeEntryToolStripMenuItem1.Size = new System.Drawing.Size(101, 20);
            this.employeeEntryToolStripMenuItem1.Text = "Employee Entry";
            // 
            // employeeEntryToolStripMenuItem2
            // 
            this.employeeEntryToolStripMenuItem2.Name = "employeeEntryToolStripMenuItem2";
            this.employeeEntryToolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.employeeEntryToolStripMenuItem2.Text = "Employee Entry";
            this.employeeEntryToolStripMenuItem2.Click += new System.EventHandler(this.employeeEntryToolStripMenuItem2_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allEmployeeListToolStripMenuItem,
            this.departmentWiseEmployeeListToolStripMenuItem,
            this.designationWiseEmployeeListToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // allEmployeeListToolStripMenuItem
            // 
            this.allEmployeeListToolStripMenuItem.Name = "allEmployeeListToolStripMenuItem";
            this.allEmployeeListToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.allEmployeeListToolStripMenuItem.Text = "All Employee List";
            this.allEmployeeListToolStripMenuItem.Click += new System.EventHandler(this.allEmployeeListToolStripMenuItem_Click);
            // 
            // departmentWiseEmployeeListToolStripMenuItem
            // 
            this.departmentWiseEmployeeListToolStripMenuItem.Name = "departmentWiseEmployeeListToolStripMenuItem";
            this.departmentWiseEmployeeListToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.departmentWiseEmployeeListToolStripMenuItem.Text = "Department Wise Employee List";
            this.departmentWiseEmployeeListToolStripMenuItem.Click += new System.EventHandler(this.departmentWiseEmployeeListToolStripMenuItem_Click);
            // 
            // designationWiseEmployeeListToolStripMenuItem
            // 
            this.designationWiseEmployeeListToolStripMenuItem.Name = "designationWiseEmployeeListToolStripMenuItem";
            this.designationWiseEmployeeListToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.designationWiseEmployeeListToolStripMenuItem.Text = "Designation Wise Employee List";
            this.designationWiseEmployeeListToolStripMenuItem.Click += new System.EventHandler(this.designationWiseEmployeeListToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nur\'s Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hREntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designationEntyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countryEntryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cityEntryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem employeeEntryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem employeeEntryToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allEmployeeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentWiseEmployeeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designationWiseEmployeeListToolStripMenuItem;
    }
}

