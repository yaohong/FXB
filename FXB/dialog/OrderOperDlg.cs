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
using FXB.DataManager;
using FXB.Common;
namespace FXB.Dialog
{
    public partial class OrderOperDlg : Form
    {
        EditMode mod;
        private string selectProjectCode = "";       //选择的项目
        private string selectGuwen = "";        //选择的顾问
        private string selectKeyuanfang = "";   //选择的客源方
        private string selectZhuchang1 = "";    //选择的驻场1
        private string selectZhuchang2 = "";    //选择的驻场2

        private QtOrder editQtOrder = null;     //编辑模式下选择的订单
        public OrderOperDlg()
        {
            InitializeComponent();
            mod = EditMode.EM_ADD;
        }

        public OrderOperDlg(QtOrder qtOrder)
        {
            InitializeComponent();
            mod = EditMode.EM_EDIT;
            editQtOrder = qtOrder;
        }

        private void OrderOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            projectNameEdi.Enabled = false;
            guwenEdi.Enabled = false;
            keyuanEdi.Enabled = false;
            zhuchang1Edi.Enabled = false;
            zhuchang2Edi.Enabled = false;
            if (mod == EditMode.EM_ADD)
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
            this.Text = "添加";
        }

        private void EditInit()
        {
            this.Text = "编辑";
        }


        private void RefreshCheckState(string checkState, string checkPersoName, string checkTime, string luruPersoName )
        {
            string str = string.Format("审核状态:{0}        审核人:{1}        审核日期:{2}         录入人:{3}", checkState, checkPersoName, checkPersoName, luruPersoName);
            shenheInfo.Text = str;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void projectNameSelectBtn_Click(object sender, EventArgs e)
        {
            ProjectSelectDlg dlg = new ProjectSelectDlg();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                selectProjectCode = dlg.SelectProjectCode;
                if (selectProjectCode != "")
                {
                    ProjectData projectData = ProjectDataMgr.Instance().AllProjectData[selectProjectCode];
                    projectNameEdi.Text = projectData.Name;
                }
            }
        }

        private bool GuwenInquireFilterFunc(BasicDataInterface bd)
        {
            //选择顾问的过滤函数
            EmployeeData data = bd as EmployeeData;
            if (data.QTLevel != QtLevel.Salesman &&
                data.QTLevel != QtLevel.SmallCharge &&
                data.QTLevel != QtLevel.LargeCharge &&
                data.QTLevel != QtLevel.Majordomo)
            {
                return false;
            }

            return true;
        }

        private bool KeyuanfangInquireFilterFunc(BasicDataInterface bd)
        {
            //选择客源方的函数,必须在QT结构下
            EmployeeData data = bd as EmployeeData;
            string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.AllQtEmployee.ContainsKey(data.JobNumber))
            {
                return false;
            }

            if (data.QTLevel != QtLevel.Salesman &&
                data.QTLevel != QtLevel.SmallCharge &&
                data.QTLevel != QtLevel.LargeCharge &&
                data.QTLevel != QtLevel.Majordomo)
            {
                return false;
            }

            return true;
        }

        private bool ZhuchangInquireFilterFunc(BasicDataInterface bd)
        {
            //选择驻场的函数,必须在QT结构下
            EmployeeData data = bd as EmployeeData;
            string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.AllQtEmployee.ContainsKey(data.JobNumber))
            {
                return false;
            }

            if (data.QTLevel != QtLevel.ZhuchangZhuanyuan &&
                data.QTLevel != QtLevel.ZhuchangZhuguan &&
                data.QTLevel != QtLevel.ZhuchangZongjian)
            {
                return false;
            }

            return true;
        }
        private void guwenSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(GuwenInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //顾问可以是非当前QT结构下的人
                if (jobNumber != "")
                {
                    string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
                    if (!QtMgr.Instance().AllQtTask.ContainsKey(qtKey))
                    {
                        MessageBox.Show(string.Format("QT任务:{0}不存在", qtKey));
                        return;
                    }

                    QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
                    if (qtTask.Closing)
                    {
                        MessageBox.Show(string.Format("QT任务:{0} 已经结算", qtKey));
                        return;
                    }

                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        //是QT关系下的人
                        //检测部门是否发生变更
                        QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        if (qtEmployee.DepartmentId != employee.DepartmentId)
                        {
                            MessageBox.Show(string.Format("顾问[{0}]的部门在QT任务生成后发生更改不能开单."));
                            return;
                        }
                    }
                    else
                    {
                        //不是当前QT结构下的人开单，只能是业务员,且部门必须是QT任务下的部门
                        if (employee.QTLevel != QtLevel.Salesman)
                        {
                            MessageBox.Show(string.Format("顾问[{0}]不属于当前QT任务的结构，且QT级别不为业务员，不能开单."));
                            return;
                        }

                        if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        {
                            MessageBox.Show(string.Format("顾问[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能开单."));
                            return;
                        }
                    }

                    selectGuwen = jobNumber;
                    guwenEdi.Text = employee.Name;
                    
                }
                
            }
        }

        private void orderGenerateTime_ValueChanged(object sender, EventArgs e)
        {
            //选择的QT任务发生变化
            selectGuwen = "";
            guwenEdi.Text = "";

            //客源方清空
            selectKeyuanfang = "";
            keyuanEdi.Text = "";

            selectZhuchang1 = "";
            zhuchang1Edi.Text = "";
            zhuchang2Edi.Text = "";
        }

        private void keyuanSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(KeyuanfangInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //顾问可以是非当前QT结构下的人
                if (jobNumber != "")
                {
                    string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
                    if (!QtMgr.Instance().AllQtTask.ContainsKey(qtKey))
                    {
                        MessageBox.Show(string.Format("QT任务:{0}不存在", qtKey));
                        return;
                    }

                    QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
                    if (qtTask.Closing)
                    {
                        MessageBox.Show(string.Format("QT任务:{0} 已经结算", qtKey));
                        return;
                    }

                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        //是QT关系下的人
                        //检测部门是否发生变更
                        QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        if (qtEmployee.DepartmentId != employee.DepartmentId)
                        {
                            MessageBox.Show(string.Format("客源方[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("客源方[{0}]不属于当前QT结构，不能被选择", employee.Name));
                        return;
                    }

                    selectKeyuanfang = jobNumber;
                    keyuanEdi.Text = employee.Name;

                }

            }
        }

        private void zhuchang1SelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(ZhuchangInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //
                if (jobNumber != "")
                {
                    string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
                    if (!QtMgr.Instance().AllQtTask.ContainsKey(qtKey))
                    {
                        MessageBox.Show(string.Format("QT任务:{0}不存在", qtKey));
                        return;
                    }

                    QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
                    if (qtTask.Closing)
                    {
                        MessageBox.Show(string.Format("QT任务:{0} 已经结算", qtKey));
                        return;
                    }

                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        //是QT关系下的人
                        //检测部门是否发生变更
                        QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        if (qtEmployee.DepartmentId != employee.DepartmentId)
                        {
                            MessageBox.Show(string.Format("驻场1[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("驻场1[{0}]不属于当前QT结构不能被选择", employee.Name));
                        return;
                    }

                    selectZhuchang1 = jobNumber;
                    zhuchang1Edi.Text = employee.Name;

                }

            }
        }

        private void zhuchang2SelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(ZhuchangInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //
                if (jobNumber != "")
                {
                    string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
                    if (!QtMgr.Instance().AllQtTask.ContainsKey(qtKey))
                    {
                        MessageBox.Show(string.Format("QT任务:{0}不存在", qtKey));
                        return;
                    }

                    QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
                    if (qtTask.Closing)
                    {
                        MessageBox.Show(string.Format("QT任务:{0} 已经结算", qtKey));
                        return;
                    }

                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        //是QT关系下的人
                        //检测部门是否发生变更
                        QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        if (qtEmployee.DepartmentId != employee.DepartmentId)
                        {
                            MessageBox.Show(string.Format("驻场2[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("驻场2[{0}]不属于当前QT结构不能被选择", employee.Name));
                        return;
                    }

                    selectZhuchang2 = jobNumber;
                    zhuchang2Edi.Text = employee.Name;

                }

            }
        }
    }
}
