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

        //创建的新订单
        private QtOrder newOrder = null;
        public QtOrder NewOrder
        {
            get { return newOrder; }
        }
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

            RefreshCheckState(true, "姚鸿", "22016-10-5", "黄平", false);
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


        private void RefreshCheckState(bool checkState, string checkPersoName, string checkTime, string luruPersoName, bool orderState)
        {
            checkStateLable.Text = "已审核";
            checkJobNumberLable.Text = "石頭哥哥";
            checkTimeLable.Text = "2016-10-09 23:11:20";
            luruJobNumberLable.Text = "石頭哥哥的";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (kehuNameEdi.Text == "")
            {
                MessageBox.Show("客户名称不为空");
                return;
            }

            if (selectProjectCode == "")
            {
                MessageBox.Show("项目不能为空");
                return;
            }

            if (roomNumberEdi.Text == "")
            {
                MessageBox.Show("房号不能为空");
                return;
            }

            if (cjZongjiaEdi.Text == "")
            {
                MessageBox.Show("成交总价不能为空");
                return;
            } 
            else
            {
                try
                {
                    Convert.ToDouble(cjZongjiaEdi.Text);
                } 
                catch (Exception )
                {
                    MessageBox.Show("成交总价格式错误");
                    return;
                }
                    
            }

            if (kehudianhuaEdi.Text == "")
            {
                MessageBox.Show("联系电话不能为空");
                return;
            }

            if (shenfenzhengEdi.Text == "")
            {
                MessageBox.Show("身份证不能为空");
                return;
            }

            if (yongjinzongeEdi.Text == "")
            {
                MessageBox.Show("佣金总额不能为空");
                return;
            } 
            else
            {
                try
                {
                    Convert.ToDouble(yongjinzongeEdi.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("佣金总额格式错误");
                    return;
                }
            }
            if (mianjiEdi.Text != "")
            {
                try
                {
                    Convert.ToDouble(mianjiEdi.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("面积格式错误");
                    return;
                }
            }
            else
            {
                MessageBox.Show("面积不能为空");
                return;
            }

            if (daikuanjineEdi.Text != "")
            {
                try
                {
                    Convert.ToDouble(daikuanjineEdi.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("贷款金额格式错误");
                    return;
                }
            }


            if (selectGuwen == "")
            {
                MessageBox.Show("营销顾问不能为空");
                return;
            }


            if (selectGuwen == selectKeyuanfang)
            {
                MessageBox.Show("营销顾问和客源方不能为同一个人");
                return;
            }

            if (selectZhuchang1 == selectZhuchang2 && selectZhuchang1 != "")
            {
                MessageBox.Show("2个驻场不能为同一个人");
                return;
            }



            if (mod == EditMode.EM_ADD)
            {
                AddSave();
            }
            else
            {
                EditSave();
            }
        }





        private void AddSave()
        {

            try 
            {
                string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
                QtOrder tmpNewOrder = 
                QtMgr.Instance().AddNewQtOrder(
                    TimeUtil.DateTimeToTimestamp(orderGenerateTime.Value),
                    System.Math.Round(Convert.ToDouble(yongjinzongeEdi.Text), 2),
                    kehuNameEdi.Text,
                    selectProjectCode,
                    roomNumberEdi.Text,
                    System.Math.Round(Convert.ToDouble(cjZongjiaEdi.Text), 2),
                    selectGuwen,
                    EmployeeDataMgr.Instance().AllEmployeeData[selectGuwen].DepartmentId,
                    selectKeyuanfang,
                    selectKeyuanfang == "" ? 0 : EmployeeDataMgr.Instance().AllEmployeeData[selectKeyuanfang].DepartmentId,
                    selectZhuchang1,
                    selectZhuchang1 == "" ? 0 : EmployeeDataMgr.Instance().AllEmployeeData[selectZhuchang1].DepartmentId,
                    selectZhuchang2,
                    selectZhuchang2 == "" ? 0 : EmployeeDataMgr.Instance().AllEmployeeData[selectZhuchang2].DepartmentId,
                    false,
                    "",
                    0,
                    false,
                    "",
                    0,
                    "owner",        //暂时填owner，真实情况应该为登陆用户
                    beizhuEdi.Text,
                    TimeUtil.DateTimeToTimestamp(buyTime.Value),
                    kehudianhuaEdi.Text,
                    shenfenzhengEdi.Text,
                    shoujuEdi.Text,
                    System.Math.Round(Convert.ToDouble(mianjiEdi.Text), 2),
                    hetongzhuangtaiEdi.Text,
                    fukuanTypeEdi.Text,
                    daikuanjineEdi.Text == "" ? 0.0f : System.Math.Round(Convert.ToDouble(daikuanjineEdi.Text), 2),
                    false,
                    qtKey);
                newOrder = tmpNewOrder;
                DialogResult = DialogResult.OK;
                Close();

            }
            catch (ConditionCheckException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                Application.Exit();
            }
        }

        private void EditSave()
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
            string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.AllQtEmployee.ContainsKey(data.JobNumber))
            {
                //不属于QT任务里的只能是业务员
                if (data.QTLevel == QtLevel.Salesman)
                {
                    if (!qtTask.AllQtDepartment.ContainsKey(data.DepartmentId))
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

        private bool ZhuchangInquireFilterFunc(BasicDataInterface bd)
        {
            //选择驻场的函数,不是必须在QT任务里面
            EmployeeData data = bd as EmployeeData;
            string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.AllQtEmployee.ContainsKey(data.JobNumber))
            {
                if (data.QTLevel == QtLevel.ZhuchangZhuanyuan)
                {
                    if (!qtTask.AllQtDepartment.ContainsKey(data.DepartmentId))
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
                if (data.QTLevel != QtLevel.ZhuchangZhuanyuan &&
                    data.QTLevel != QtLevel.ZhuchangZhuguan &&
                    data.QTLevel != QtLevel.ZhuchangZongjian)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


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
                            MessageBox.Show(string.Format("顾问[{0}]的部门在QT任务生成后发生更改不能开单.", employee.Name));
                            return;
                        }
                    }
                    else
                    {
                        //不是当前QT结构下的人开单，只能是业务员,且部门必须是QT任务下的部门
                        if (employee.QTLevel != QtLevel.Salesman)
                        {
                            MessageBox.Show(string.Format("顾问[{0}]不属于当前QT任务的结构，且QT级别不为业务员，不能开单.", employee.Name));
                            return;
                        }

                        if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        {
                            MessageBox.Show(string.Format("顾问[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能开单.", employee.Name));
                            return;
                        }
                    }

                    selectGuwen = jobNumber;
                    guwenEdi.Text = employee.Name;

                    yxBumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employee.DepartmentId);
                    yxQtLevelEdi.Text = QtUtil.GetQTLevelString(employee.QTLevel);
                }
                else
                {
                    selectGuwen = "";
                    guwenEdi.Text = "";

                    yxBumenEdi.Text = "";
                    yxQtLevelEdi.Text = "";
                }
                
            }
        }

        private void orderGenerateTime_ValueChanged(object sender, EventArgs e)
        {
            //选择的QT任务发生变化
            selectGuwen = "";
            guwenEdi.Text = "";
            yxBumenEdi.Text = "";
            yxQtLevelEdi.Text = "";

            //客源方清空
            selectKeyuanfang = "";
            keyuanEdi.Text = "";
            kyfBumenEdi.Text = "";
            kyfQtLevelEdi.Text = "";

            selectZhuchang1 = "";
            zhuchang1Edi.Text = "";
            zc1BumenEdi.Text = "";
            zc1QtLevelEdi.Text = "";


            selectZhuchang2 = "";
            zhuchang2Edi.Text = "";
            zc2BumenEdi.Text = "";
            zc2QtLevelEdi.Text = "";
        }

        private void keyuanSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(GuwenInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                
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

                    //客源方必须是当前QT结构下的人
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
                        if (employee.QTLevel != QtLevel.Salesman)
                        {
                            MessageBox.Show(string.Format("客源方[{0}]不属于当前QT任务的结构，且QT级别不为业务员，不能被指定.", employee.Name));
                            return;
                        }

                        if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        {
                            MessageBox.Show(string.Format("客源方[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                            return;
                        }
                    }

                    selectKeyuanfang = jobNumber;
                    keyuanEdi.Text = employee.Name;

                    kyfBumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employee.DepartmentId);
                    kyfQtLevelEdi.Text = QtUtil.GetQTLevelString(employee.QTLevel);

                }
                else
                {
                    selectKeyuanfang = "";
                    keyuanEdi.Text = "";
                    kyfBumenEdi.Text = "";
                    kyfQtLevelEdi.Text = "";
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
                        //不是当前QT结构下的人开单，只能是业务员,且部门必须是QT任务下的部门
                        if (employee.QTLevel != QtLevel.ZhuchangZhuanyuan)
                        {
                            MessageBox.Show(string.Format("驻场1[{0}]不属于当前QT任务的结构，且QT级别不为驻场专员，不能被指定.", employee.Name));
                            return;
                        }

                        if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        {
                            MessageBox.Show(string.Format("驻场1[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                            return;
                        }
                    }

                    selectZhuchang1 = jobNumber;
                    zhuchang1Edi.Text = employee.Name;
                    zc1BumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employee.DepartmentId);
                    zc1QtLevelEdi.Text = QtUtil.GetQTLevelString(employee.QTLevel);
                }
                else
                {
                    selectZhuchang1 = "";
                    zhuchang1Edi.Text = "";
                    zc1BumenEdi.Text = "";
                    zc1QtLevelEdi.Text = "";
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
                        //不是当前QT结构下的人开单，只能是驻场专员,且部门必须是QT任务下的部门
                        if (employee.QTLevel != QtLevel.ZhuchangZhuanyuan)
                        {
                            MessageBox.Show(string.Format("驻场2[{0}]不属于当前QT任务的结构，且QT级别不为驻场专员，不能被指定.", employee.Name));
                            return;
                        }

                        if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        {
                            MessageBox.Show(string.Format("驻场2[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                            return;
                        }
                    }

                    selectZhuchang2 = jobNumber;
                    zhuchang2Edi.Text = employee.Name;
                    zc2BumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employee.DepartmentId);
                    zc2QtLevelEdi.Text = QtUtil.GetQTLevelString(employee.QTLevel);
                }
                else
                {
                    selectZhuchang2 = "";
                    zhuchang2Edi.Text = "";
                    zc2BumenEdi.Text = "";
                    zc2QtLevelEdi.Text = "";
                }

            }
        }
    }
}
