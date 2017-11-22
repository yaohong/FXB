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
    public partial class HyTotalViewDlg : Form
    {
        public HyTotalViewDlg()
        {
            InitializeComponent();
        }

        private void HyTotalViewDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            foreach (var item in QtMgr.Instance().AllQtTask)
            {

                qtCb.Items.Add(item.Key);
            }

            SetDataGridViewColumn();
        }

        private void InqueryBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtCb.SelectedIndex)
            {
                return;
            }

            EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
            string curJob = curEmployee.JobNumber;



            string qtKey = qtCb.SelectedItem as string;
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];

            if (!qtTask.Closing)
            {
                MessageBox.Show("没有生成QT提成");
                return;
            }


            ShowQuery(qtTask);
        }

        string GetMajordomoDepartmentName(QtTask qtTask, QtDepartment department)
        {

            Int64 departmentId = department.Id;
            while (departmentId != 0)
            {
                QtDepartment curDepartment = qtTask.AllQtDepartment[departmentId];
                if (curDepartment.QtLevel == QtLevel.Majordomo)
                {
                    return curDepartment.DepartmentName;
                }

                departmentId = curDepartment.ParentDepartmentId;
            }

            throw new CrashException("QT部门结构错误");
        }
        string GetJobDazhuguanBumen(string job, QtTask qtTask)
        {
            QtEmployee employee = qtTask.AllQtEmployee[job];
            QtDepartment department = qtTask.AllQtDepartment[employee.DepartmentId];

            return GetMajordomoDepartmentName(qtTask, department);
        }

        string GetJobQtLevelString(string job, QtTask qtTask)
        {
            QtEmployee employee = qtTask.AllQtEmployee[job];
            return QtUtil.GetQTLevelString(employee.QtLevel);
        }

        string GetJobName(string job, QtTask qtTask)
        {
            return EmployeeDataMgr.Instance().AllEmployeeData[job].Name;
        }

        string GetXiaozhuguanName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman)
            {
                //业务员开单
                QtDepartment parmentDepartment = qtTask.AllQtDepartment[kaidanDepartment.Id];
                replyJob = parmentDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
        }

        double GetXiaozhuguanBili(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];
            if (kaidanEmployee.QtLevel == QtLevel.Salesman)
            {
                QtDepartment parmentDepartment = qtTask.AllQtDepartment[kaidanDepartment.Id];
                if (parmentDepartment.OwnerJobNumber == "")
                {
                    //没有小主管
                    return 0;
                }

                QtEmployee ownerEmployee = qtTask.AllQtEmployee[parmentDepartment.OwnerJobNumber];
                return CommissionUtil.GetCommissionPropToProp(parmentDepartment, ownerEmployee);
            }
            else if (kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                return CommissionUtil.GetCommissionPropToProp(kaidanDepartment, kaidanEmployee); 
            }
            else
            {
                return CommissionUtil.GetQTSmallChargeProp();
            }
        }

        string GetDazhuguanName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                replyJob = kaidanDepartment.OwnerJobNumber;
            } 
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
        }

        double GetDazhuguanBili(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                QtDepartment parmentDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                if (parmentDepartment.OwnerJobNumber == "")
                {
                    //大主管为空
                    return 0;
                }
                QtEmployee ownerEmployee = qtTask.AllQtEmployee[parmentDepartment.OwnerJobNumber];
                return CommissionUtil.GetCommissionPropToProp(parmentDepartment, ownerEmployee);
            }
            else if (kaidanEmployee.QtLevel == QtLevel.LargeCharge)
            {
                return CommissionUtil.GetCommissionPropToProp(kaidanDepartment, kaidanEmployee);
            }
            else
            {
                return CommissionUtil.GetQtLargeChargeProp();
            }
        }

        string GetZongjianName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                for (int i = 0; i < 2; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }
                    
                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else if (kaidanEmployee.QtLevel == QtLevel.LargeCharge)
            {
                for (int i = 0; i < 1; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }
                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
        }

        double GetZongjianBili(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                for (int i = 0; i < 2; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }

                if (kaidanDepartment.OwnerJobNumber == "")
                {
                    //总监为空
                    return 0;
                }
                QtEmployee ownerEmployee = qtTask.AllQtEmployee[kaidanDepartment.OwnerJobNumber];
                return CommissionUtil.GetCommissionPropToProp(kaidanDepartment, ownerEmployee);
            }
            else if (kaidanEmployee.QtLevel == QtLevel.LargeCharge)
            {
                for (int i = 0; i < 1; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }

                if (kaidanDepartment.OwnerJobNumber == "")
                {
                    //总监为空
                    return 0;
                }
                QtEmployee ownerEmployee = qtTask.AllQtEmployee[kaidanDepartment.OwnerJobNumber];
                return CommissionUtil.GetCommissionPropToProp(kaidanDepartment, ownerEmployee);
            }
            else
            {
                return CommissionUtil.GetCommissionPropToProp(kaidanDepartment, kaidanEmployee);
            }
        }

        void ShowQuery(QtTask qtTask)
        {
            myDataGridView1.Rows.Clear();

            SortedDictionary<Int64, List<Int64>> orderToHy = new SortedDictionary<Int64, List<Int64>>();

            string[] ym = qtTask.QtKey.Split('-');

            Int32 qtYear = Convert.ToInt32(ym[0]);
            Int32 qtMonth = Convert.ToInt32(ym[1]);

            foreach (var item in HYMgr.Instance().AllHYData)
            {
                HYData hyData = item.Value;
                if (!hyData.CheckState)
                {
                    //回佣没有审核
                    continue;
                }

                QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];
                if (order.ReturnData.IsReturn)
                {
                    //所属的订单已经退单了
                    continue;
                }

                //查看HY的添加时间
                DateTime hyDateTime = TimeUtil.TimestampToDateTime(hyData.AddTime);
                if (hyDateTime.Month != qtMonth || hyDateTime.Year != qtYear)
                {
                    //不是计算工资的年和月份
                    continue;
                }

                List<Int64> hyIdList;
                if (orderToHy.ContainsKey(order.Id))
                {
                    hyIdList = orderToHy[order.Id];
                }
                else
                {
                    hyIdList = new List<Int64>();
                    orderToHy[order.Id] = hyIdList;
                }

                hyIdList.Add(item.Key);
            }

            //double totoalShichuticheng = 0;
            foreach (var item2 in orderToHy)
            {
                Int64 orderId = item2.Key;
                List<Int64> hyIdList = item2.Value;
                QtOrder qtOrder = OrderMgr.Instance().AllOrderData[orderId];
                if (qtOrder.Id == 100164)
                {
                    int i = 0;
                    i++;
                }
                foreach (var hyId in hyIdList)
                {
                    HYData hyData = HYMgr.Instance().AllHYData[hyId];
                    foreach (var jobItem in qtOrder.YxJob.Jobs)
                    {
                        string jobnumber = jobItem.Key;
                        Int32 prop = jobItem.Value;

                        UpdateRow(qtTask, qtOrder, hyData, jobnumber, prop, "业务员");


                    }

                    if (qtOrder.KyfConsultanJobNumber != "")
                    {
                        UpdateRow(qtTask, qtOrder, hyData, qtOrder.KyfConsultanJobNumber, 1000, "客源方");
                    }
                }

            }
            //末尾添加一行总计
            //{
            //    int count = myDataGridView1.Rows.Count;

            //    int endRowId = myDataGridView1.Rows.Add();
            //    DataGridViewRow endRow = myDataGridView1.Rows[endRowId];
            //    endRow.Cells["chengjiaoriqi"].Value = "总额:";

            //    endRow.Cells["shichuticheng"].Value = DoubleUtil.Show(totoalShichuticheng);
            //}
        }

        void UpdateRow(QtTask qtTask, QtOrder qtOrder, HYData hyData, string jobnumber, Int32 prop, string type)
        {
            int rowId = myDataGridView1.Rows.Add();
            DataGridViewRow newRow = myDataGridView1.Rows[rowId];
            DateTime dt = TimeUtil.TimestampToDateTime(qtOrder.GenerateTime);
            newRow.Cells["chengjiaoriqi"].Value = dt.ToLongDateString();
            {
                ProjectData projectData = ProjectDataMgr.Instance().AllProjectData[qtOrder.ProjectCode];
                newRow.Cells["xiangmumingcheng"].Value = projectData.Name;
            }

            newRow.Cells["kehuxingming"].Value = qtOrder.CustomerName;
            newRow.Cells["fanghao"].Value = qtOrder.RoomNumber;

            //显示业务员部门(大主管一级)
            Int64 ownerQtDepartmentId = QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, jobnumber);
            newRow.Cells["bumen"].Value = DepartmentUtil.GetQtDepartmentSimShowText(qtTask, ownerQtDepartmentId);
            newRow.Cells["zhiji"].Value = GetJobQtLevelString(jobnumber, qtTask);
            newRow.Cells["chaifenbili"].Value = string.Format("%{0}", prop / 100);

            newRow.Cells["gongsiyongjin"].Value = DoubleUtil.Show((hyData.Amount * prop) / 10000);
            newRow.Cells["shuifei"].Value = DoubleUtil.Show((hyData.Shuifei * prop) / 10000);
            newRow.Cells["shouxufei"].Value = DoubleUtil.Show((hyData.Shouxufei * prop) / 10000);
            newRow.Cells["shishouyongjin"].Value = DoubleUtil.Show(((hyData.Amount - hyData.Shuifei - hyData.Shouxufei) * prop) / 10000);

            newRow.Cells["chengjiaoren"].Value = GetJobName(jobnumber, qtTask);
            newRow.Cells["chengjiaoleixing"].Value = type;

            double basic = ((hyData.Amount - hyData.Shuifei - hyData.Shouxufei) * prop) / 10000;
            {
                //已出奖金按100去整
                int v = (int)(basic * 0.1);
                v = v - (v % 100);
                newRow.Cells["yichujiangjin"].Value = DoubleUtil.Show(v);
            }
            

            
            newRow.Cells["shichuticheng"].Value = DoubleUtil.Show(basic * 0.2);

            {
                newRow.Cells["xiaozhuguan"].Value = GetXiaozhuguanName(jobnumber, qtTask);
                double bili = GetXiaozhuguanBili(jobnumber, qtTask);
                newRow.Cells["xiaozhuguanbili"].Value = string.Format("%{0}", bili * 100);
                newRow.Cells["xiaozhuguanticheng"].Value = DoubleUtil.Show(basic * bili);
            }

            {
                newRow.Cells["dazhuguan"].Value = GetDazhuguanName(jobnumber, qtTask);
                double bili = GetDazhuguanBili(jobnumber, qtTask);
                newRow.Cells["dazhuguanbili"].Value = string.Format("%{0}", bili * 100);
                newRow.Cells["dazhuguanticheng"].Value = DoubleUtil.Show(basic * bili);
            }

            {
                newRow.Cells["zongjian"].Value = GetZongjianName(jobnumber, qtTask);
                double bili = GetZongjianBili(jobnumber, qtTask);
                newRow.Cells["zongjianbili"].Value = string.Format("%{0}", bili * 100);
                newRow.Cells["zongjianticheng"].Value = DoubleUtil.Show(basic * bili);
            }
        }

        private void SetDataGridViewColumn()
        {

            DataGridViewTextBoxColumn chengjiaoriqi = new DataGridViewTextBoxColumn();
            chengjiaoriqi.Name = "chengjiaoriqi";
            chengjiaoriqi.HeaderText = "成交日期";
            chengjiaoriqi.Width = 100;
            myDataGridView1.Columns.Add(chengjiaoriqi);

            DataGridViewTextBoxColumn xiangmumingcheng = new DataGridViewTextBoxColumn();
            xiangmumingcheng.Name = "xiangmumingcheng";
            xiangmumingcheng.HeaderText = "项目名称";
            xiangmumingcheng.Width = 100;
            myDataGridView1.Columns.Add(xiangmumingcheng);

            DataGridViewTextBoxColumn kehuxingming = new DataGridViewTextBoxColumn();
            kehuxingming.Name = "kehuxingming";
            kehuxingming.HeaderText = "客户姓名";
            kehuxingming.Width = 100;
            myDataGridView1.Columns.Add(kehuxingming);

            DataGridViewTextBoxColumn fanghao = new DataGridViewTextBoxColumn();
            fanghao.Name = "fanghao";
            fanghao.HeaderText = "房号";
            fanghao.Width = 100;
            myDataGridView1.Columns.Add(fanghao);


            DataGridViewTextBoxColumn bumen = new DataGridViewTextBoxColumn();
            bumen.Name = "bumen";
            bumen.HeaderText = "部门";
            bumen.Width = 170;
            myDataGridView1.Columns.Add(bumen);

            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 100;
            myDataGridView1.Columns.Add(zhiji);

            DataGridViewTextBoxColumn chaifenbili = new DataGridViewTextBoxColumn();
            chaifenbili.Name = "chaifenbili";
            chaifenbili.HeaderText = "拆分比例";
            chaifenbili.Width = 100;
            myDataGridView1.Columns.Add(chaifenbili);

            DataGridViewTextBoxColumn gongsiyongjin = new DataGridViewTextBoxColumn();
            gongsiyongjin.Name = "gongsiyongjin";
            gongsiyongjin.HeaderText = "公司佣金";
            gongsiyongjin.Width = 100;
            myDataGridView1.Columns.Add(gongsiyongjin);

            DataGridViewTextBoxColumn shuifei = new DataGridViewTextBoxColumn();
            shuifei.Name = "shuifei";
            shuifei.HeaderText = "税费";
            shuifei.Width = 100;
            myDataGridView1.Columns.Add(shuifei);

            DataGridViewTextBoxColumn shouxufei = new DataGridViewTextBoxColumn();
            shouxufei.Name = "shouxufei";
            shouxufei.HeaderText = "手续费";
            shouxufei.Width = 100;
            myDataGridView1.Columns.Add(shouxufei);

            DataGridViewTextBoxColumn shishouyongjin = new DataGridViewTextBoxColumn();
            shishouyongjin.Name = "shishouyongjin";
            shishouyongjin.HeaderText = "实收佣金";
            shishouyongjin.Width = 100;
            myDataGridView1.Columns.Add(shishouyongjin);

            DataGridViewTextBoxColumn chengjiaoren = new DataGridViewTextBoxColumn();
            chengjiaoren.Name = "chengjiaoren";
            chengjiaoren.HeaderText = "成交人";
            chengjiaoren.Width = 100;
            myDataGridView1.Columns.Add(chengjiaoren);

            DataGridViewTextBoxColumn chengjiaoleixing = new DataGridViewTextBoxColumn();
            chengjiaoleixing.Name = "chengjiaoleixing";
            chengjiaoleixing.HeaderText = "成交类型";
            chengjiaoleixing.Width = 100;
            myDataGridView1.Columns.Add(chengjiaoleixing);

            DataGridViewTextBoxColumn yichujiangjin = new DataGridViewTextBoxColumn();
            yichujiangjin.Name = "yichujiangjin";
            yichujiangjin.HeaderText = "预发工资";
            yichujiangjin.Width = 100;
            myDataGridView1.Columns.Add(yichujiangjin);

            DataGridViewTextBoxColumn shichuticheng = new DataGridViewTextBoxColumn();
            shichuticheng.Name = "shichuticheng";
            shichuticheng.HeaderText = "实出提成";
            shichuticheng.Width = 100;
            myDataGridView1.Columns.Add(shichuticheng);

            DataGridViewTextBoxColumn xiaozhuguan = new DataGridViewTextBoxColumn();
            xiaozhuguan.Name = "xiaozhuguan";
            xiaozhuguan.HeaderText = "小主管";
            xiaozhuguan.Width = 100;
            myDataGridView1.Columns.Add(xiaozhuguan);

            DataGridViewTextBoxColumn xiaozhuguanbili = new DataGridViewTextBoxColumn();
            xiaozhuguanbili.Name = "xiaozhuguanbili";
            xiaozhuguanbili.HeaderText = "比例";
            xiaozhuguanbili.Width = 100;
            myDataGridView1.Columns.Add(xiaozhuguanbili);

            DataGridViewTextBoxColumn xiaozhuguanticheng = new DataGridViewTextBoxColumn();
            xiaozhuguanticheng.Name = "xiaozhuguanticheng";
            xiaozhuguanticheng.HeaderText = "提成";
            xiaozhuguanticheng.Width = 100;
            myDataGridView1.Columns.Add(xiaozhuguanticheng);


            DataGridViewTextBoxColumn dazhuguan = new DataGridViewTextBoxColumn();
            dazhuguan.Name = "dazhuguan";
            dazhuguan.HeaderText = "大主管";
            dazhuguan.Width = 100;
            myDataGridView1.Columns.Add(dazhuguan);

            DataGridViewTextBoxColumn dazhuguanbili = new DataGridViewTextBoxColumn();
            dazhuguanbili.Name = "dazhuguanbili";
            dazhuguanbili.HeaderText = "比例";
            dazhuguanbili.Width = 100;
            myDataGridView1.Columns.Add(dazhuguanbili);

            DataGridViewTextBoxColumn dazhuguanticheng = new DataGridViewTextBoxColumn();
            dazhuguanticheng.Name = "dazhuguanticheng";
            dazhuguanticheng.HeaderText = "提成";
            dazhuguanticheng.Width = 100;
            myDataGridView1.Columns.Add(dazhuguanticheng);


            DataGridViewTextBoxColumn zongjian = new DataGridViewTextBoxColumn();
            zongjian.Name = "zongjian";
            zongjian.HeaderText = "总监";
            zongjian.Width = 100;
            myDataGridView1.Columns.Add(zongjian);

            DataGridViewTextBoxColumn zongjianbili = new DataGridViewTextBoxColumn();
            zongjianbili.Name = "zongjianbili";
            zongjianbili.HeaderText = "比例";
            zongjianbili.Width = 100;
            myDataGridView1.Columns.Add(zongjianbili);

            DataGridViewTextBoxColumn zongjianticheng = new DataGridViewTextBoxColumn();
            zongjianticheng.Name = "zongjianticheng";
            zongjianticheng.HeaderText = "提成";
            zongjianticheng.Width = 100;
            myDataGridView1.Columns.Add(zongjianticheng);

        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExcelUtil.ExportData(myDataGridView1);
        }
    }
}
