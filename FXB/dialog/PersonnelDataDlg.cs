using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Common;
using FXB.Data;
using FXB.DataManager;
namespace FXB.Dialog
{
    public partial class PersonnelDataDlg : Form, DBUpdateInterface
    {
        public PersonnelDataDlg()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
        }

        private void InquireBtn_Click(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Text;
        }

        private void PersonnelDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //禁止改变窗口大小
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.DoubleBuffered = true;

            //禁止改变表格的大小
            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            DepartmentDataMgr.Instance().SetTreeView(treeView1);
        }

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = treeView1.SelectedNode;
            DepartmentData selectDepartment = null;
            if (n != null)
            {
                Int64 selectDepartmentId = Convert.ToInt64(n.Name);
                selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[selectDepartmentId];

                if (selectDepartment.IsMaxLayer())
                {
                    MessageBox.Show("只能有四层部门");
                    return;
                }

                if (selectDepartment.QTLevel == QtLevel.ZhuchangZhuguan)
                {
                    MessageBox.Show("驻场只能有三层部门");
                    return;
                }
            }
            DepartmentOperDlg dlg = new DepartmentOperDlg(EditMode.EM_ADD, selectDepartment);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //重新刷新树
                if (dlg.NewDepartmentId != 0)
                {
                    DepartmentData newDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[dlg.NewDepartmentId];

                    var allTreeNode = treeView1.Nodes.Find(newDepartmentData.SuperiorId.ToString(), true);
                    //因为ID是不重复的所以返回的是只有一个数组的元素
                    int childCount = allTreeNode.Count<TreeNode>();
                    if (childCount != 1)
                    {
                        MessageBox.Show("部门关系发生异常，请重新启动程序");
                        Application.Exit();
                    }
                    TreeNode parentNode = allTreeNode[0];
                    parentNode.Nodes.Add(newDepartmentData.Id.ToString(), newDepartmentData.Name);
                }
                //DepartmentDataMgr.Instance().SetTreeView(treeView1);
            }

        }

        private void ModifyDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = treeView1.SelectedNode;
            if (n == null)
            {
                return;
            }

            Int64 selectDepartmentId = Convert.ToInt64(n.Name);
            DepartmentData selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[selectDepartmentId];
            DepartmentOperDlg dlg = new DepartmentOperDlg(EditMode.EM_EDIT, selectDepartment);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //重新刷新树
                //DepartmentDataMgr.Instance().SetTreeView(treeView1);
                //只能修改部门名字
                //n.Name = selectDepartment.Name;
                n.Text = selectDepartment.Name;
            }


        }

        public void DbRefresh()
        {

        }

        private void AddPersonnelBtn_Click(object sender, EventArgs e)
        {
            EmployeeOperDlg dlg = new EmployeeOperDlg(EditMode.EM_ADD);
            dlg.ShowDialog();
        }

        private void RemoveDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = treeView1.SelectedNode;
            if (n == null)
            {
                return;
            }

            if (n.Nodes.Count != 0)
            {
                MessageBox.Show("部门还有子部门，不能删除");
                return;
            }

            Int64 departmentId = Convert.ToInt64(n.Name);
            try
            {
                DepartmentDataMgr.Instance().DeleteDepartment(departmentId);
                n.Remove();
                //重新刷新树
                //DepartmentDataMgr.Instance().SetTreeView(treeView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
