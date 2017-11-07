using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Data;
using FXB.Common;
using FXB.DataManager;
namespace FXB.Dialog
{
    public partial class JobEditDlg : Form
    {
        private QtTask qtTask;
        private QtJob job;
        private bool checkState;

        public QtJob Job
        {
            get { return job; }
        }
        public JobEditDlg(QtTask tmpQtTask, QtJob tmpJob)
        {
            qtTask = tmpQtTask;
            if (tmpJob== null)
            {
                job = new QtJob();
            }
            else
            {
                job = tmpJob.Clone();
            }
            InitializeComponent();
        }

        public JobEditDlg(QtTask tmpQtTask, QtJob tmpJob, bool tmpCheckState)
        {
            qtTask = tmpQtTask;
            job = tmpJob.Clone();

            checkState = tmpCheckState;
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            SingleJobEditDlg dlg = new SingleJobEditDlg(qtTask);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string addJob = dlg.EditJobnumber;
                Int32 addProp = dlg.EditProp;

                if (job.Exist(addJob))
                {
                    MessageBox.Show("同一个顾问不能重复添加");
                    return;
                }

                job.Add(addJob, addProp);

                int newLine = myDataGridView1.Rows.Add();
                addJobData(myDataGridView1.Rows[newLine], addJob, addProp);

            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (myDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectRow = myDataGridView1.SelectedRows[0];
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)selectRow.Cells["gonghao"];
            string gonghao = (string)selectCell.Value;

            job.Remove(gonghao);
            //删除选中行
            myDataGridView1.Rows.RemoveAt(selectRow.Index);

        }

        private void JobEditDlg_Load(object sender, EventArgs e)
        {
            //this.ControlBox = false; 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (checkState)
            {
                AddBtn.Enabled = false;
                RemoveBtn.Enabled = false;
            }
            SetDataGridViewColumn();

            foreach (var item in job.Jobs)
            {
                string job_ = item.Key;
                Int32 prop_ = item.Value;

                int newLine = myDataGridView1.Rows.Add();
                addJobData(myDataGridView1.Rows[newLine], job_, prop_);

            }
        }

        private void addJobData(DataGridViewRow row, string job, Int32 prop)
        {
            EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[job];

            row.Cells["gonghao"].Value = job;
            row.Cells["prop"].Value = string.Format("{0}%", ((double)prop) / 100);
            row.Cells["name"].Value = employee.Name;
            row.Cells["bumen"].Value = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, job));
            row.Cells["qtlevel"].Value = QtUtil.GetQTLevelString(QtTaskUtil.GetJobQtLevelByQtTask(qtTask, job));
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 110;
            myDataGridView1.Columns.Add(gonghao);

            DataGridViewTextBoxColumn prop = new DataGridViewTextBoxColumn();
            prop.Name = "prop";
            prop.HeaderText = "比例";
            prop.Width = 100;
            myDataGridView1.Columns.Add(prop);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "姓名";
            name.Width = 100;
            myDataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn bumen = new DataGridViewTextBoxColumn();
            bumen.Name = "bumen";
            bumen.HeaderText = "部门";
            bumen.Width = 200;
            myDataGridView1.Columns.Add(bumen);

            DataGridViewTextBoxColumn qtlevel = new DataGridViewTextBoxColumn();
            qtlevel.Name = "qtlevel";
            qtlevel.HeaderText = "QT级别";
            qtlevel.Width = 100;
            myDataGridView1.Columns.Add(qtlevel);

        }

        private void myDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (myDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)myDataGridView1.SelectedRows[0].Cells["gonghao"];
            string gonghao = (string)selectCell.Value;

            Int32 prop = job.GetProp(gonghao);

            SingleJobEditDlg dlg = new SingleJobEditDlg(qtTask, gonghao, prop);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                //string addJob = dlg.EditJobnumber;
                //只能修改比例
                Int32 addProp = dlg.EditProp;
                job.SetProp(gonghao, addProp); ;

                addJobData(myDataGridView1.SelectedRows[0], gonghao, addProp);

            }

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            //计算比例
            if (!job.Check(false) && !job.Check(true))
            {
                //无论有没有客源方都失败
                MessageBox.Show("业务顾问的比例设置异常");
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
