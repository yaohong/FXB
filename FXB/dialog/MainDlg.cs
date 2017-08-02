using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Dialog;
using FXB.Data;
using FXB.Common;
using FXB.DataManager;
namespace FXB
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = Convert.ToInt64(ts.TotalSeconds);
        }



        private void 员工档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] allMdiChildren = this.MdiChildren;
            foreach (Form childDlg in allMdiChildren)
            {
                if (childDlg.Name == "PersonnelDataDlg")
                {
                    if (childDlg.WindowState == FormWindowState.Minimized)
                    {
                        childDlg.WindowState = FormWindowState.Maximized;
                    }
                    childDlg.Activate();

                    return;
                }
            }

            PersonnelDataDlg dlg = new PersonnelDataDlg();
            dlg.MdiParent = this;
            dlg.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //初始化操作
            try 
            {
                SqlMgr.Instance().Init();
                DepartmentDataMgr.Instance().Load();
                JobGradeDataMgr.Instance().Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

        }

        private void 职级档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] allMdiChildren = this.MdiChildren;
            foreach (Form childDlg in allMdiChildren)
            {
                if (childDlg.Name == "JobGradeDataDlg")
                {
                    if (childDlg.WindowState == FormWindowState.Minimized)
                    {
                        childDlg.WindowState = FormWindowState.Maximized;
                    }
                    childDlg.Activate();

                    return;
                }
            }

            JobGradeDataDlg dlg = new JobGradeDataDlg();
            dlg.MdiParent = this;
            dlg.Show();
        }

        private void 项目档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] allMdiChildren = this.MdiChildren;
            foreach (Form childDlg in allMdiChildren)
            {
                if (childDlg.Name == "ProjectDataDlg")
                {
                    if (childDlg.WindowState == FormWindowState.Minimized)
                    {
                        childDlg.WindowState = FormWindowState.Maximized;
                    }
                    childDlg.Activate();

                    return;
                }
            }

            ProjectDataDlg dlg = new ProjectDataDlg();
            dlg.MdiParent = this;
            dlg.Show();
        }







    }
}
