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

    public partial class SingleJobEditDlg : Form
    {
        EditMode mode;
        private QtTask curQtTask;


        private string editJobnumber = "";
        private Int32 editProp = 0;

        public string EditJobnumber
        {
            get { return editJobnumber; }
        }

        public Int32 EditProp
        {
            get { return editProp; }
        }
        public SingleJobEditDlg(QtTask qtTask)
        {
            curQtTask = qtTask;
            mode = EditMode.EM_ADD;


            InitializeComponent();
        }

        public SingleJobEditDlg(QtTask qtTask, string tmpJobnumber, Int32 tmpProp)
        {
            curQtTask = qtTask;
            mode = EditMode.EM_EDIT;

            editJobnumber = tmpJobnumber;
            editProp = tmpProp;


            InitializeComponent();
        }

        private void SingleJobEditDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (mode == EditMode.EM_ADD)
            {
                AddInit();
            }
            else
            {
                EditInit();
            }

        }

        private void AddInit()
        {
            
        }

        private void EditInit()
        {
            selectBtn.Enabled = false;

            EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[editJobnumber];
            jobEdi.Text = employee.Name;
            //显示为百分比
            propEdi.Text = ((double)editProp / 100).ToString();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {

            if (curQtTask.Closing)
            {
                MessageBox.Show(string.Format("QT任务:{0} 已经结算", curQtTask.QtKey));
                return;
            }

            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(GuwenInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;

                if (jobNumber != "")
                {

                    //客源方必须是当前QT结构下的人
                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (curQtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                    }
                    else
                    {

                        if (DialogResult.OK != MessageBox.Show(string.Format("选择的顾问[{0}]不在指定的QT任务中,是否要加入", jobNumber), "提示", MessageBoxButtons.OKCancel))
                        {
                            return;
                        }

                        //插入数据到QT任务
                        QtMgr.Instance().AddNewEmployeeToQtTask(employee, curQtTask);
                    }

                    editJobnumber = jobNumber;
                    jobEdi.Text = employee.Name;

                }
                else
                {
                    editJobnumber = "";
                    jobEdi.Text = "";
                    propEdi.Text = "";
                }

            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (editJobnumber == "")
            {
                MessageBox.Show("业务顾问不能为空");
                return;
            }

            try
            {
                double rawProp = Convert.ToDouble(propEdi.Text);
                Int32 intProp = (Int32)(rawProp * 100);
                editProp = intProp;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("比例的格式错误:" + ex1.Message);
            }
        }


        private bool GuwenInquireFilterFunc(BasicDataInterface bd)
        {
            //选择顾问的过滤函数
            EmployeeData data = bd as EmployeeData;
            if (!data.JobState)
            {
                //离职的
                return false;
            }

            if (!curQtTask.AllQtEmployee.ContainsKey(data.JobNumber))
            {
                //不属于QT任务里的只能是业务员
                if (data.QTLevel == QtLevel.Salesman)
                {
                    if (!curQtTask.AllQtDepartment.ContainsKey(data.DepartmentId))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (data.QTLevel != QtLevel.Salesman &&
                    data.QTLevel != QtLevel.SmallCharge &&
                    data.QTLevel != QtLevel.LargeCharge &&
                    data.QTLevel != QtLevel.Majordomo)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
