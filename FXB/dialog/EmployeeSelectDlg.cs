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
namespace FXB.Dialog
{
    public partial class EmployeeSelectDlg : Form
    {
        public EmployeeSelectDlg()
        {
            InitializeComponent();
        }

        private void EmployeeSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.StartPosition = FormStartPosition.CenterParent; ;
            DepartmentDataMgr.Instance().SetTreeView(myTreeView1);
            SetDataGridViewColumn();
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {
            EmployeeDataMgr.Instance().SetBasicDataGridView(dataGridView1);
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
    }
}
