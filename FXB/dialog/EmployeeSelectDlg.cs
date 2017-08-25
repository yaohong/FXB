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
    public partial class EmployeeSelectDlg : Form
    {
        private DataFilter filterFunc = null;
        private string selectEmployeeJobNumber = "";

        public string SelectEmployeeJobNumber
        {
            get { return selectEmployeeJobNumber; }
        }
        public EmployeeSelectDlg(DataFilter tmpFilterFunc)
        {
            InitializeComponent();
            filterFunc = tmpFilterFunc;
        }

        private void EmployeeSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.StartPosition = FormStartPosition.CenterParent; ;
            DepartmentDataMgr.Instance().SetTreeView(myTreeView1);
            SetDataGridViewColumn();
        }

        private bool InquireFilterFunc(BasicDataInterface bd)
        {

            EmployeeData data = bd as EmployeeData;
            if (filterFunc != null)
            {
                if (!filterFunc(data))
                {
                    return false;
                }
            }
            if (paramEdi.Text != "")
            {
                if (data.JobNumber.IndexOf(paramEdi.Text) == -1 &&
                    data.Name.IndexOf(paramEdi.Text) == -1 &&
                    data.JobGradeName.IndexOf(paramEdi.Text) == -1)
                {
                    return false;
                }
            }

            TreeNode selectNode = myTreeView1.SelectedNode;
            if (selectNode != null)
            {
                Console.WriteLine("selectNodeText:{0}", selectNode.Text);
                Int64 departmentId = Convert.ToInt64(selectNode.Name);
                if (!DepartmentUtil.FindEmployeeByDepartment(departmentId, data.JobNumber))
                {
                    return false;
                }

            }

            return true;
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {
            EmployeeDataMgr.Instance().SetBasicDataGridView(dataGridView1, InquireFilterFunc);
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 100;
            dataGridView1.Columns.Add(gonghao);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "姓名";
            name.Width = 70;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn qt = new DataGridViewTextBoxColumn();
            qt.Name = "qt";
            qt.HeaderText = "QT级别";
            qt.Width = 100;
            dataGridView1.Columns.Add(qt);

            DataGridViewTextBoxColumn departmentName = new DataGridViewTextBoxColumn();
            departmentName.Name = "departmentName";
            departmentName.HeaderText = "部门";
            departmentName.Width = 250;
            dataGridView1.Columns.Add(departmentName);

            DataGridViewCheckBoxColumn isOwner = new DataGridViewCheckBoxColumn();
            isOwner.Name = "isOwner";
            isOwner.HeaderText = "主管";
            isOwner.Width = 40;
            dataGridView1.Columns.Add(isOwner);


            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 60;
            dataGridView1.Columns.Add(zhiji);


            DataGridViewCheckBoxColumn jobState = new DataGridViewCheckBoxColumn();
            jobState.Name = "jobState";
            jobState.HeaderText = "在职状态";
            jobState.Width = 60;
            dataGridView1.Columns.Add(jobState);

        }

        private void myTreeView1_Click(object sender, EventArgs e)
        {
            EmployeeDataMgr.Instance().SetBasicDataGridView(dataGridView1, InquireFilterFunc);
        }

        private void myTreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                myTreeView1.SelectedNode = myTreeView1.GetNodeAt(e.X, e.Y);
            } 
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells["gonghao"];
            selectEmployeeJobNumber = (string)selectCell.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
