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
            //SortedSet<int> s = new SortedSet<int>();
            //bool a = s.Add(1);
            //a = s.Add(2);
            //a = s.Add(1);
        }



        private void 员工档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("PersonnelDataDlg");

        }

        private void main_Load(object sender, EventArgs e)
        {
            //初始化操作
            try 
            {
                SqlMgr.Instance().Init();
                DepartmentDataMgr.Instance().Load();
                JobGradeDataMgr.Instance().Load();
                ProjectDataMgr.Instance().Load();
                EmployeeDataMgr.Instance().Load();
                QtMgr.Instance().Load();
                DxDuplicateMgr.Instance().Load();
                AuthMgr.Instance().Load();
                HYMgr.Instance().Init();
                LoginDlg loginDlg = new LoginDlg();
                if (DialogResult.OK != loginDlg.ShowDialog())
                {
                    System.Environment.Exit(0);
                    return;
                }

                //根据权限隐藏菜单
                AuthData curLoginAuth = AuthMgr.Instance().CurLoginEmployee.AuthData;
                if (!curLoginAuth.IfOwner)
                {
                    //不是管理员
                    if (!curLoginAuth.ShowYuangongDanganMenu())
                    {
                        员工档案ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowZhijiDanganMenu())
                    {
                        职级档案ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowXiangmuDanganMenu())
                    {
                        项目档案ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowYonghuquanxianMenu())
                    {
                        用户权限ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowShuaXinShujuMenu())
                    {
                        刷新数据ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowKaiDanMenu())
                    {
                        开单录入ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowHuiYongMenu())
                    {
                        回佣录入ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowTuiDanMenu())
                    {
                        退单录入ToolStripMenuItem.Visible = false;
                    }


                    if (!curLoginAuth.ShowDixinLuruMenu())
                    {
                        底薪录入ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowGenerateDixinFubenMenu())
                    {
                        生成底薪副本ToolStripMenuItem.Visible = false;
                    }

                    if (!curLoginAuth.ShowQtTaskMenu())
                    {
                        QT任务ToolStripMenuItem.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }

        }

        private void 职级档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("JobGradeDataDlg");
        }

        private void 项目档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("ProjectDataDlg");
        }

        private void ShowDialog(string dlgName)
        {
            Form[] allMdiChildren = this.MdiChildren;
            foreach (Form childDlg in allMdiChildren)
            {
                if (childDlg.Name == dlgName)
                {
                    if (childDlg.WindowState == FormWindowState.Minimized)
                    {
                        childDlg.WindowState = FormWindowState.Maximized;
                    }
                    childDlg.Activate();

                    return;
                }
            }

            if (dlgName == "PersonnelDataDlg")
            {
                PersonnelDataDlg dlg = new PersonnelDataDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else if (dlgName == "JobGradeDataDlg")
            {
                JobGradeDataDlg dlg = new JobGradeDataDlg();
                dlg.MdiParent = this;
                dlg.Show();
            } 
            else if (dlgName == "ProjectDataDlg")
            {
                ProjectDataDlg dlg = new ProjectDataDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else if (dlgName == "QtTaskOperDlg")
            {
                QtTaskOperDlg dlg = new QtTaskOperDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else if (dlgName == "SalaryDuplicateOperDlg")
            {
                SalaryDuplicateOperDlg dlg = new SalaryDuplicateOperDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else if (dlgName == "OrderDataDlg")
            {
                OrderDataDlg dlg = new OrderDataDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else if (dlgName == "AuthDataDlg")
            {
                AuthDataDlg dlg = new AuthDataDlg();
                dlg.MdiParent = this;
                dlg.Show();
            }
            else 
            {
                MessageBox.Show("未知的窗口名字");
                System.Environment.Exit(0);
            }
        }

        private void QT任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("QtTaskOperDlg");
        }

        private void 生成底薪副本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("SalaryDuplicateOperDlg");
        }

        private void 开单录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("OrderDataDlg");
        }

        private void 用户权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDialog("AuthDataDlg");
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordDlg dlg = new ChangePasswordDlg();
            dlg.ShowDialog();
        }

    }
}
