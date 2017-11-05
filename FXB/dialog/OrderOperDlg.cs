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
        private QtJob selectQtJob = null;
        private string selectKeyuanfang = "";   //选择的客源方
        private string selectZhuchang1 = "";    //选择的驻场1
        private string selectZhuchang2 = "";    //选择的驻场2

        //编辑模式
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
            //guwenEdi.Enabled = false;
            keyuanEdi.Enabled = false;
            zhuchang1Edi.Enabled = false;
            zhuchang2Edi.Enabled = false;

            fukuanTypeCb.Items.Add("按揭");
            fukuanTypeCb.Items.Add("一次性");
            fukuanTypeCb.Items.Add("分期");

            hetongzhuangtaiCb.Items.Add("认购");
            hetongzhuangtaiCb.Items.Add("草签");
            hetongzhuangtaiCb.Items.Add("网签");

            AuthData curAuth = AuthMgr.Instance().CurLoginEmployee.AuthData;
            if (!curAuth.IfOwner && !curAuth.ShowOrderCheckBtn())
            {
                //不显示审核
                shenheBtn.Visible = false;
            }

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
            tabPage3.Parent = null;
            tabPage4.Parent = null;

            this.Text = "添加";
            shenheBtn.Visible = false;
            checkStateLable.Text = "未审核";
            luruJobNumberLable.Text = AuthMgr.Instance().CurLoginEmployee.Name;

        }

        private void EditInit()
        {
            this.Text = "编辑";
            {
                //权限设置
                //回佣界面初始化
                EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
                AuthData authData = curEmployee.AuthData;
                if (!authData.IfOwner && !authData.ShowHYVisibleTab())
                {
                    //不显示回佣页签
                    tabPage3.Parent = null;
                }

                if (!authData.IfOwner && !authData.ShowAddHyBtn())
                {
                    addHuiyongBtn.Visible = false;
                }

                if (!authData.IfOwner && !authData.ShowDeleteHyBtn())
                {
                    deleteHuiYongBtn.Visible = false;
                }

                //退单结算初始化
                if (!authData.IfOwner && ! authData.ShowTDVisibleTab())
                {
                    //不显示退单页签
                    tabPage4.Parent = null;
                }

                if (!authData.IfOwner && ! authData.ShowTDCb())
                {
                    tuidanCb.Enabled = false;
                }

                //if (!authData.IfOwner && ! authData.ShowTDCheckCb())
                //{
                //    tdCheckCb.Enabled = false;
                //}

            }
            //设置录入人
            EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[editQtOrder.EntryPersonJobNumber];
            luruJobNumberLable.Text = employeeData.Name;
            if (editQtOrder.CheckState)
            {
                EmployeeData checkEmployeeData = EmployeeDataMgr.Instance().AllEmployeeData[editQtOrder.CheckPersonJobNumber];
                checkStateLable.Text = "已审核";
                checkJobNumberLable.Text = checkEmployeeData.Name;
                checkTimeLable.Text = TimeUtil.TimestampToDateTime(editQtOrder.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");

                //将控件变灰
                EnableControl(false);
                shenheBtn.Text = "取消审核";
            }
            else
            {
                checkStateLable.Text = "未审核";
                shenheBtn.Text = "审核";
            }

            //编辑模式下订单生成时间不允许修改
            orderGenerateTime.Enabled = false;

            kehuNameEdi.Text = editQtOrder.CustomerName;
            projectNameEdi.Text = ProjectDataMgr.Instance().AllProjectData[editQtOrder.ProjectCode].Name;
            roomNumberEdi.Text = editQtOrder.RoomNumber;
            cjZongjiaEdi.Text = editQtOrder.ClosingTheDealMoney.ToString();
            buyTime.Value = TimeUtil.TimestampToDateTime(editQtOrder.BuyTime);
            kehudianhuaEdi.Text = editQtOrder.CustomerPhone;
            shenfenzhengEdi.Text = editQtOrder.CustomerIdCard;
            shoujuEdi.Text = editQtOrder.Receipt;
            mianjiEdi.Text = editQtOrder.RoomArea.ToString();
            hetongzhuangtaiCb.Text = editQtOrder.ContractState;
            fukuanTypeCb.Text = editQtOrder.PaymentMethod;
            daikuanjineEdi.Text = editQtOrder.LoansMoney.ToString();
            beizhuEdi.Text = editQtOrder.Comment;
            yongjinzongeEdi.Text = editQtOrder.CommissionAmount.ToString();
            orderGenerateTime.Value = TimeUtil.TimestampToDateTime(editQtOrder.GenerateTime);

            //下面的设置必须放在 orderGenerateTime.Value 之后
            selectProjectCode = editQtOrder.ProjectCode;

            selectQtJob = editQtOrder.YxJob.Clone();
            selectKeyuanfang = editQtOrder.KyfConsultanJobNumber;
            selectZhuchang1 = editQtOrder.Zc1JobNumber;
            selectZhuchang2 = editQtOrder.Zc2JobNumber; 

            QtTask qtTask = QtMgr.Instance().AllQtTask[editQtOrder.QtKey];

            //设置客源方
            {
                if (editQtOrder.KyfConsultanJobNumber != "")
                {
                    keyuanEdi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editQtOrder.KyfConsultanJobNumber].Name;
                    kyfBumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, editQtOrder.KyfConsultanJobNumber));
                    QtLevel kyfQtLevel = QtTaskUtil.GetJobQtLevelByQtTask(qtTask, editQtOrder.KyfConsultanJobNumber);
                    kyfQtLevelEdi.Text = QtUtil.GetQTLevelString(kyfQtLevel);
                }
            }

            //设置驻场1
            {
                if (editQtOrder.Zc1JobNumber != "")
                {
                    zhuchang1Edi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editQtOrder.Zc1JobNumber].Name;
                    zc1BumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, editQtOrder.Zc1JobNumber));
                    QtLevel zcQtLevel = QtTaskUtil.GetJobQtLevelByQtTask(qtTask, editQtOrder.Zc1JobNumber);
                    zc1QtLevelEdi.Text = QtUtil.GetQTLevelString(zcQtLevel);
                }
            }
            //设置驻场2
            {
                if (editQtOrder.Zc2JobNumber != "")
                {
                    zhuchang2Edi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editQtOrder.Zc2JobNumber].Name;
                    zc2BumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, editQtOrder.Zc2JobNumber));
                    QtLevel zcQtLevel = QtTaskUtil.GetJobQtLevelByQtTask(qtTask, editQtOrder.Zc2JobNumber);
                    zc2QtLevelEdi.Text = QtUtil.GetQTLevelString(zcQtLevel);
                }
            }


            //设置回佣dataGridView的字段
            SetHYDataGridViewFiled();
            InitHYDataGridView();


            InitTDTable();
        }



        void EnableControl(bool bl)
        {
            kehuNameEdi.Enabled = bl;
            projectNameSelectBtn.Enabled = bl;
            roomNumberEdi.Enabled = bl;
            cjZongjiaEdi.Enabled = bl;
            buyTime.Enabled = bl;
            kehudianhuaEdi.Enabled = bl;
            shenfenzhengEdi.Enabled = bl;
            shoujuEdi.Enabled = bl;
            mianjiEdi.Enabled = bl;
            hetongzhuangtaiCb.Enabled = bl;
            fukuanTypeCb.Enabled = bl;
            daikuanjineEdi.Enabled = bl;
            beizhuEdi.Enabled = bl;
            yongjinzongeEdi.Enabled = bl;

            orderGenerateTime.Enabled = bl;
            //guwenSelectBtn.Enabled = bl;
            keyuanSelectBtn.Enabled = bl;
            zhuchang1SelectBtn.Enabled = bl;
            zhuchang2SelectBtn.Enabled = bl;
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
                if (!DoubleUtil.Check(cjZongjiaEdi.Text))
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

                if (!DoubleUtil.Check(yongjinzongeEdi.Text))
                {
                    MessageBox.Show("佣金总额格式错误");
                    return;
                }

            }
            if (mianjiEdi.Text != "")
            {
                if (!DoubleUtil.Check(mianjiEdi.Text))
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
                if (!DoubleUtil.Check(daikuanjineEdi.Text))
                {
                    MessageBox.Show("贷款金额格式错误");
                    return;
                }
            }

            if (selectQtJob == null)
            {
                MessageBox.Show("顾问必须设置");
                return;
            }

            if (!selectQtJob.Check(selectKeyuanfang != ""))
            {
                MessageBox.Show("顾问的占比总数必须为90%或者100%");
                return;
            }

            if (selectKeyuanfang != "")
            {
                if (selectQtJob.Exist(selectKeyuanfang))
                {
                    MessageBox.Show("顾问[{0}]不能同时指定为客源方", selectKeyuanfang);
                    return;
                }
            }

            if (selectZhuchang1 == "")
            {
                MessageBox.Show("驻场1必须设置");
                return;
            }

            if (selectZhuchang1 == selectZhuchang2)
            {
                MessageBox.Show("2个驻场不能为同一个人");
                return;
            }

            if (fukuanTypeCb.SelectedIndex == -1)
            {
                MessageBox.Show("付款方式不能为空");
                return;
            }

            if (hetongzhuangtaiCb.SelectedIndex == -1)
            {
                MessageBox.Show("合同状态不能为空");
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
            EmployeeData curEmployeeData = AuthMgr.Instance().CurLoginEmployee;
            try 
            {
                string qtKey = orderGenerateTime.Value.ToString("yyyy-MM");

                QtOrder tmpNewOrder = 
                OrderMgr.Instance().AddNewQtOrder(
                    TimeUtil.DateTimeToTimestamp(orderGenerateTime.Value),
                    System.Math.Round(Convert.ToDouble(yongjinzongeEdi.Text), 2),
                    kehuNameEdi.Text,
                    selectProjectCode,
                    roomNumberEdi.Text,
                    System.Math.Round(Convert.ToDouble(cjZongjiaEdi.Text), 2),
                    selectQtJob,
                    selectKeyuanfang,
                    selectZhuchang1,
                    selectZhuchang2,
                    false,
                    "",
                    0,
                    curEmployeeData.JobNumber,
                    beizhuEdi.Text,
                    TimeUtil.DateTimeToTimestamp(buyTime.Value),
                    kehudianhuaEdi.Text,
                    shenfenzhengEdi.Text,
                    shoujuEdi.Text,
                    System.Math.Round(Convert.ToDouble(mianjiEdi.Text), 2),
                    hetongzhuangtaiCb.Text,
                    fukuanTypeCb.Text,
                    daikuanjineEdi.Text == "" ? 0.0f : System.Math.Round(Convert.ToDouble(daikuanjineEdi.Text), 2),
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
                System.Environment.Exit(0);
            }
        }

        private void EditSave()
        {
            
            if (kehuNameEdi.Text != editQtOrder.CustomerName || 
                selectProjectCode != editQtOrder.ProjectCode ||
                roomNumberEdi.Text != editQtOrder.RoomNumber ||
                cjZongjiaEdi.Text != editQtOrder.ClosingTheDealMoney.ToString() ||
                TimeUtil.DateTimeToTimestamp(buyTime.Value) != editQtOrder.BuyTime || 
               
                kehudianhuaEdi.Text != editQtOrder.CustomerPhone ||
                shenfenzhengEdi.Text != editQtOrder.CustomerIdCard ||
                shoujuEdi.Text != editQtOrder.Receipt || 
                mianjiEdi.Text != editQtOrder.RoomArea.ToString() ||
                hetongzhuangtaiCb.Text != editQtOrder.ContractState || 
                fukuanTypeCb.Text != editQtOrder.PaymentMethod ||
                daikuanjineEdi.Text != editQtOrder.LoansMoney.ToString() ||
                beizhuEdi.Text != editQtOrder.Comment ||
                yongjinzongeEdi.Text != editQtOrder.CommissionAmount.ToString() || 
                selectQtJob.Encode() != editQtOrder.YxJob.Encode() ||
                selectKeyuanfang != editQtOrder.KyfConsultanJobNumber || 
                selectZhuchang1 != editQtOrder.Zc1JobNumber || 
                selectZhuchang2 != editQtOrder.Zc2JobNumber
                )
            {

                try
                {
                    OrderMgr.Instance().ModifyQtOrder(
                        editQtOrder.Id,
                        System.Math.Round(Convert.ToDouble(yongjinzongeEdi.Text), 2),
                        kehuNameEdi.Text,
                        selectProjectCode,
                        roomNumberEdi.Text,
                        System.Math.Round(Convert.ToDouble(cjZongjiaEdi.Text), 2),
                        selectQtJob, 
                        selectKeyuanfang, 
                        selectZhuchang1, 
                        selectZhuchang2,

                        beizhuEdi.Text,
                        TimeUtil.DateTimeToTimestamp(buyTime.Value),
                        kehudianhuaEdi.Text,
                        shenfenzhengEdi.Text,
                        shoujuEdi.Text,
                        System.Math.Round(Convert.ToDouble(mianjiEdi.Text), 2),
                        hetongzhuangtaiCb.Text,
                        fukuanTypeCb.Text,
                        daikuanjineEdi.Text == "" ? 0.0f : System.Math.Round(Convert.ToDouble(daikuanjineEdi.Text), 2));


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
                    System.Environment.Exit(0);
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
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
            if (!data.JobState)
            {
                //离职的
                return false;
            }
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
            if (!data.JobState)
            {
                //离职的
                return false;
            }
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

            JobEditDlg dlg = null;
            if (mod == EditMode.EM_EDIT)
            {
                dlg = new JobEditDlg(qtTask, selectQtJob, editQtOrder.CheckState);
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    selectQtJob = dlg.Job;
                }
            }
            else
            {
                dlg = new JobEditDlg(qtTask);
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    selectQtJob = dlg.Job;
                }
                else
                {
                    selectQtJob = null;
                }
            }

            

        }

        private void orderGenerateTime_ValueChanged(object sender, EventArgs e)
        {
            //选择的QT任务发生变化
            selectQtJob = null;
            //guwenEdi.Text = "";
            //yxBumenEdi.Text = "";
            //yxQtLevelEdi.Text = "";

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

            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(GuwenInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                
                if (jobNumber != "")
                {

                    //客源方必须是当前QT结构下的人
                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        ////是QT关系下的人
                        ////检测部门是否发生变更
                        //QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        //if (qtEmployee.DepartmentId != employee.DepartmentId)
                        //{
                        //    MessageBox.Show(string.Format("客源方[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                        //    return;
                        //}
                    }
                    else
                    {
                        //if (employee.QTLevel != QtLevel.Salesman)
                        //{
                        //    MessageBox.Show(string.Format("客源方[{0}]不属于当前QT任务的结构，且QT级别不为业务员，不能被指定.", employee.Name));
                        //    return;
                        //}

                        //if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        //{
                        //    MessageBox.Show(string.Format("客源方[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                        //    return;
                        //}
                        if (DialogResult.OK != MessageBox.Show(string.Format("选择的客源方[{0}]不在指定的QT任务中,是否要加入", jobNumber), "提示", MessageBoxButtons.OKCancel))
                        {
                            return;
                        }

                        //插入数据到QT任务
                        QtMgr.Instance().AddNewEmployeeToQtTask(employee, qtTask);
                    }

                    selectKeyuanfang = jobNumber;
                    keyuanEdi.Text = employee.Name;
                    kyfBumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, selectKeyuanfang));
                    kyfQtLevelEdi.Text = QtUtil.GetQTLevelString(QtTaskUtil.GetJobQtLevelByQtTask(qtTask, selectKeyuanfang));

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

            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(ZhuchangInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //
                if (jobNumber != "")
                {
                    //检测是否一样
                    if (selectZhuchang2 == jobNumber)
                    {
                        MessageBox.Show("驻场1和驻场2不能为同一个人");
                        return;
                    }
                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        ////是QT关系下的人
                        ////检测部门是否发生变更
                        //QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        //if (qtEmployee.DepartmentId != employee.DepartmentId)
                        //{
                        //    MessageBox.Show(string.Format("驻场1[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                        //    return;
                        //}
                    }
                    else
                    {
                        //不是当前QT结构下的人开单，只能是业务员,且部门必须是QT任务下的部门
                        //if (employee.QTLevel != QtLevel.ZhuchangZhuanyuan)
                        //{
                        //    MessageBox.Show(string.Format("驻场1[{0}]不属于当前QT任务的结构，且QT级别不为驻场专员，不能被指定.", employee.Name));
                        //    return;
                        //}

                        //if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        //{
                        //    MessageBox.Show(string.Format("驻场1[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                        //    return;
                        //}
                        if (DialogResult.OK != MessageBox.Show(string.Format("选择的驻场[{0}]不在指定的QT任务中,是否要加入", jobNumber), "提示", MessageBoxButtons.OKCancel))
                        {
                            return;
                        }

                        //插入数据到QT任务
                        QtMgr.Instance().AddNewEmployeeToQtTask(employee, qtTask);
                    }

                    selectZhuchang1 = jobNumber;
                    zhuchang1Edi.Text = employee.Name;
                    zc1BumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, selectZhuchang1));
                    zc1QtLevelEdi.Text = QtUtil.GetQTLevelString(QtTaskUtil.GetJobQtLevelByQtTask(qtTask, selectZhuchang1));
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

            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(ZhuchangInquireFilterFunc);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                string jobNumber = selectDlg.SelectEmployeeJobNumber;
                //
                if (jobNumber != "")
                {
                    if (selectZhuchang1 == jobNumber)
                    {
                        MessageBox.Show("驻场1和驻场2不能为同一个人");
                        return;
                    }
                    EmployeeData employee = EmployeeDataMgr.Instance().AllEmployeeData[jobNumber];
                    if (qtTask.AllQtEmployee.ContainsKey(jobNumber))
                    {
                        ////是QT关系下的人
                        ////检测部门是否发生变更
                        //QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                        //if (qtEmployee.DepartmentId != employee.DepartmentId)
                        //{
                        //    MessageBox.Show(string.Format("驻场2[{0}]的部门在QT任务生成后发生更改不能被选择.", employee.Name));
                        //    return;
                        //}
                    }
                    else
                    {
                        ////不是当前QT结构下的人开单，只能是驻场专员,且部门必须是QT任务下的部门
                        //if (employee.QTLevel != QtLevel.ZhuchangZhuanyuan)
                        //{
                        //    MessageBox.Show(string.Format("驻场2[{0}]不属于当前QT任务的结构，且QT级别不为驻场专员，不能被指定.", employee.Name));
                        //    return;
                        //}

                        //if (!qtTask.AllQtDepartment.ContainsKey(employee.DepartmentId))
                        //{
                        //    MessageBox.Show(string.Format("驻场2[{0}]不属于当前QT任务的结构，且所属的部门也不属于当前QT任务结构，不能被指定.", employee.Name));
                        //    return;
                        //}
                        if (DialogResult.OK != MessageBox.Show(string.Format("选择的驻场[{0}]不在指定的QT任务中,是否要加入", jobNumber), "提示", MessageBoxButtons.OKCancel))
                        {
                            return;
                        }

                        //插入数据到QT任务
                        QtMgr.Instance().AddNewEmployeeToQtTask(employee, qtTask);
                    }

                    selectZhuchang2 = jobNumber;
                    zhuchang2Edi.Text = employee.Name;
                    zc2BumenEdi.Text = DepartmentUtil.GetQtDepartmentShowText(qtTask, QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, selectZhuchang2));
                    zc2QtLevelEdi.Text = QtUtil.GetQTLevelString(QtTaskUtil.GetJobQtLevelByQtTask(qtTask, selectZhuchang2));
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

        private void shenheBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (editQtOrder.CheckState)
                {
                    //当前是审核状态
                    //取消审核
                    OrderMgr.Instance().UpdateCheckState(editQtOrder.Id, false, "", 0);

                    EnableControl(true);
                    //生成时间不允许修改
                    orderGenerateTime.Enabled = false;

                    checkStateLable.Text = "未审核";
                    checkJobNumberLable.Text = "";
                    checkTimeLable.Text = "";
                    shenheBtn.Text = "审核";
                }
                else
                {
                    //当前是取消审核状态
                    //审核
                    EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
                    UInt32 timestamp = TimeUtil.DateTimeToTimestamp(DateTime.Now);
                    OrderMgr.Instance().UpdateCheckState(editQtOrder.Id, true, curEmployee.JobNumber, timestamp);

                    EnableControl(false);

                    checkStateLable.Text = "已审核";
                    checkJobNumberLable.Text = curEmployee.Name;
                    checkTimeLable.Text = TimeUtil.TimestampToDateTime(editQtOrder.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");
                    shenheBtn.Text = "取消审核";
                }
            }
            catch (ConditionCheckException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                System.Environment.Exit(0);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addHuiyongBtn_Click(object sender, EventArgs e)
        {
            AddHYDlg dlg = new AddHYDlg(editQtOrder.Id);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Int64 newHYId = dlg.NewHYId;
                HYData hyData = HYMgr.Instance().AllHYData[newHYId];
                int newRow = hyDataGridView1.Rows.Add();
                UpdateHYGridViewRow(hyDataGridView1.Rows[newRow], hyData);
            }
        }


        private void UpdateHYGridViewRow(DataGridViewRow row, HYData data)
        {
            row.Cells["id"].Value = data.Id;
            row.Cells["hyAmount"].Value = data.Amount;
            row.Cells["hyTime"].Value = TimeUtil.TimestampToDateTime(data.AddTime).ToShortDateString();
            row.Cells["entryJobNumber"].Value = EmployeeDataMgr.Instance().AllEmployeeData[data.EntryJobNumber].Name;
            row.Cells["checkState"].Value = data.CheckState;
        }


        void SetHYDataGridViewFiled()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "id";
            id.HeaderText = "回佣ID";
            id.Width = 80;
            hyDataGridView1.Columns.Add(id);

            DataGridViewTextBoxColumn hyAmount = new DataGridViewTextBoxColumn();
            hyAmount.Name = "hyAmount";
            hyAmount.HeaderText = "回佣金额";
            hyAmount.Width = 80;
            hyDataGridView1.Columns.Add(hyAmount);

            DataGridViewTextBoxColumn hyTime = new DataGridViewTextBoxColumn();
            hyTime.Name = "hyTime";
            hyTime.HeaderText = "回佣时间";
            hyTime.Width = 80;
            hyDataGridView1.Columns.Add(hyTime);

            DataGridViewTextBoxColumn entryJobNumber = new DataGridViewTextBoxColumn();
            entryJobNumber.Name = "entryJobNumber";
            entryJobNumber.HeaderText = "录入人";
            entryJobNumber.Width = 80;
            hyDataGridView1.Columns.Add(entryJobNumber);

            DataGridViewCheckBoxColumn checkState = new DataGridViewCheckBoxColumn();
            checkState.Name = "checkState";
            checkState.HeaderText = "是否审核";
            checkState.Width = 80;
            hyDataGridView1.Columns.Add(checkState);

            //DataGridViewTextBoxColumn checkJobNumber = new DataGridViewTextBoxColumn();
            //checkJobNumber.Name = "checkJobNumber";
            //checkJobNumber.HeaderText = "审核人";
            //checkJobNumber.Width = 100;
            //hyDataGridView1.Columns.Add(checkJobNumber);

            //DataGridViewTextBoxColumn checkTime = new DataGridViewTextBoxColumn();
            //checkTime.Name = "checkTime";
            //checkTime.HeaderText = "审核时间";
            //checkTime.Width = 120;
            //hyDataGridView1.Columns.Add(checkTime);

        }

        void InitHYDataGridView()
        {
            hyDataGridView1.Rows.Clear();
            foreach (var item in editQtOrder.AllHYData)
            {
                int newRow = hyDataGridView1.Rows.Add();
                UpdateHYGridViewRow(hyDataGridView1.Rows[newRow], item.Value);
            }
        }

        private void deleteHuiYongBtn_Click(object sender, EventArgs e)
        {
            if (hyDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewRow selectRow = hyDataGridView1.SelectedRows[0];
            Int64 hyId = (Int64)selectRow.Cells["id"].Value;

            try
            {
                HYMgr.Instance().RemoveHY(hyId);
                hyDataGridView1.Rows.RemoveAt(selectRow.Index);
            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                System.Environment.Exit(0);
            }
        }

        private void hyDataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (hyDataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectRow = hyDataGridView1.SelectedRows[0];
            Int64 hyId = (Int64)selectRow.Cells["id"].Value;
            HYData hyData = HYMgr.Instance().AllHYData[hyId];
            ViewHYDlg dlg = new ViewHYDlg(hyData);
            dlg.ShowDialog();
            UpdateHYGridViewRow(selectRow, hyData);
        }



        //初始化退單界面
        private void InitTDTable()
        {
            TDData tdData = editQtOrder.ReturnData;
            if (tdData.IsReturn) 
            {
                tuidanCb.Checked = true;
                tuidanJobEdit.Text = EmployeeDataMgr.Instance().AllEmployeeData[tdData.ReturnJobnumber].Name;
                tuidanTimeEdit.Text = TimeUtil.TimestampToDateTime(tdData.ReturnTime).ToString("yyyy-MM-dd HH:mm:ss");

                //if (tdData.IsCheck)
                //{
                //    tdCheckCb.Checked = true;
                //    tdCheckJobEdit.Text = EmployeeDataMgr.Instance().AllEmployeeData[tdData.CheckJobnumber].Name;
                //    tdCheckJobEdit.Text = TimeUtil.TimestampToDateTime(tdData.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");
                //}
            }
            else
            {
                tuidanCb.Checked = false;
            }
            //else
            //{
            //    //没有退单的话，审核界面不显示
            //    shenheLable.Visible = false;
            //}
        }


        private void tuidanCb_CheckedChanged(object sender, EventArgs e)
        {
            TDData tdData = editQtOrder.ReturnData;
            if (tuidanCb.Checked != tdData.IsReturn)
            {
                //退单的状态发生变化了
                EmployeeData curLoginEmployee = AuthMgr.Instance().CurLoginEmployee;
                UInt32 timestamp = TimeUtil.DateTimeToTimestamp(DateTime.Now);
                try
                {
                    if (tuidanCb.Checked)
                    {
                        //退单了
                        TDMgr.Instance().UpdateState(tdData.OrderId, true, curLoginEmployee.JobNumber, timestamp);
                        tuidanJobEdit.Text = curLoginEmployee.Name;
                        tuidanTimeEdit.Text = TimeUtil.TimestampToDateTime(timestamp).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        //取消退单
                        TDMgr.Instance().UpdateState(tdData.OrderId, false, "", 0);
                        tuidanJobEdit.Text = "";
                        tuidanTimeEdit.Text = "";
                    }
                } 
                catch (ConditionCheckException ex1)
                {
                    MessageBox.Show(ex1.Message);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                    System.Environment.Exit(0);
                }

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
