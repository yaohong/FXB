using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.DataManager;
using FXB.Data;
using FXB.Common;
namespace FXB.Dialog
{
   
    public partial class DepartmentSelectDlg : Form
    {
        private bool qtDepartment = false;
        private DepartmentData selectDepartment = null;
        private QtDepartment selectQtDepartment = null;

        //选择QT部门时需要的参数
        private string qtkey = "";
        private QtLevel departmentQtLevel;
        public DepartmentData SelectDepartment
        {
            get 
            { 
                if (qtDepartment)
                {
                    throw new CrashException("qtDepartment = true");
                }
                return selectDepartment; 
            }
            //set { selectDepartment = value; }
        }

        public QtDepartment SelectQtDepartment
        {
            get 
            { 
                if (!qtDepartment)
                {
                    throw new CrashException("qtDepartment = false");
                }
                return selectQtDepartment; 
            }
        }
        public DepartmentSelectDlg()
        {
            qtDepartment = false;
            InitializeComponent();
        }

        public DepartmentSelectDlg(string tmpQtKey, QtLevel tmpDepartmentQtLevel)
        {
            qtDepartment = true;
            qtkey = tmpQtKey;
            departmentQtLevel = tmpDepartmentQtLevel;
            InitializeComponent();
        }

        private void DepartmentSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (!qtDepartment)
            {
                DepartmentDataMgr.Instance().SetTreeView(treeView1);
            }
            else
            {
                this.Text = "请选择要加入的QT部门";
                QtTask qtTask = QtMgr.Instance().AllQtTask[qtkey];
                //初始化树形控件
                QtTask.SetTreeView(qtTask, treeView1);

            }
        }



        private void okBtn_Click(object sender, EventArgs e)
        {

            GetSelectDepartment();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetSelectDepartment();
        }


        private void GetSelectDepartment()
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                Int64 departmentId = Convert.ToInt64(selectNode.Name);
                if (!qtDepartment)
                {
                    selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
                }
                else
                {
                    QtTask qtTask = QtMgr.Instance().AllQtTask[qtkey];
                    selectQtDepartment = qtTask.AllQtDepartment[departmentId];
                    if (selectQtDepartment.QtLevel != departmentQtLevel)
                    {
                        MessageBox.Show("只能选择小主管部门或者驻场主管级别的部门");
                        selectQtDepartment = null;
                        return;
                    }
                    
                    if (DialogResult.OK != MessageBox.Show(string.Format("QT部门选择之后不能修改,确认选择部门[{0}]", selectQtDepartment.DepartmentName), "注意", MessageBoxButtons.OKCancel))
                    {
                        return;
                    }
                }
                DialogResult = DialogResult.OK;
                Close();
                
            }
        }
    }
}
