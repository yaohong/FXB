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
    public partial class AuthDataDlg : Form
    {
        public AuthDataDlg()
        {
            InitializeComponent();
        }

        private bool jobNumberOrNameInquire(BasicDataInterface bd)
        {
            EmployeeData data = bd as EmployeeData;
            if (paramEdi.Text != "")
            {
                if (data.JobNumber.IndexOf(paramEdi.Text) == -1 &&
                    data.Name.IndexOf(paramEdi.Text) == -1)
                {
                    return false;
                }

            }

            TreeNode selectNode = treeView1.SelectedNode;
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

        private void InquireBtn_Click(object sender, EventArgs e)
        {
            EmployeeDataMgr.Instance().SetAuthDataGridView(dataGridView1, jobNumberOrNameInquire);
        }

        private void AuthDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            DepartmentDataMgr.Instance().SetTreeView(treeView1);
            SetDataGridViewColumn();
            EmployeeDataMgr.Instance().SetAuthDataGridView(dataGridView1);
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "姓名";
            name.Width = 80;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn jobnumber = new DataGridViewTextBoxColumn();
            jobnumber.Name = "jobnumber";
            jobnumber.HeaderText = "工号";
            jobnumber.Width = 120;
            dataGridView1.Columns.Add(jobnumber);

            DataGridViewCheckBoxColumn jobstate = new DataGridViewCheckBoxColumn();
            jobstate.Name = "jobstate";
            jobstate.HeaderText = "是否在职";
            jobstate.Width = 70;
            dataGridView1.Columns.Add(jobstate);

            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 100;
            dataGridView1.Columns.Add(zhiji);



            DataGridViewTextBoxColumn department = new DataGridViewTextBoxColumn();
            department.Name = "department";
            department.HeaderText = "部门";
            department.Width = 250;
            dataGridView1.Columns.Add(department);


            DataGridViewTextBoxColumn departmentOwner = new DataGridViewTextBoxColumn();
            departmentOwner.Name = "departmentOwner";
            departmentOwner.HeaderText = "部门主管";
            departmentOwner.Width = 80;
            dataGridView1.Columns.Add(departmentOwner);

            DataGridViewTextBoxColumn dianhua = new DataGridViewTextBoxColumn();
            dianhua.Name = "dianhua";
            dianhua.HeaderText = "电话";
            dianhua.Width = 80;
            dataGridView1.Columns.Add(dianhua);

            DataGridViewTextBoxColumn idCard = new DataGridViewTextBoxColumn();
            idCard.Name = "idCard";
            idCard.HeaderText = "身份证";
            idCard.Width = 120;
            dataGridView1.Columns.Add(idCard);

            DataGridViewCheckBoxColumn prohibit = new DataGridViewCheckBoxColumn();
            prohibit.Name = "prohibit";
            prohibit.HeaderText = "禁止登陆";
            prohibit.Width = 70;
            dataGridView1.Columns.Add(prohibit);
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            EmployeeDataMgr.Instance().SetAuthDataGridView(dataGridView1, jobNumberOrNameInquire);
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
            } 
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells["jobnumber"];
            string jobnumber = (string)selectCell.Value;

            EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[jobnumber];
            AuthEditDlg authEditDlg = new AuthEditDlg();
            if (authEditDlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
