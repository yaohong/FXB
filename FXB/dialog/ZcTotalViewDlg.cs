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
    public partial class ZcTotalViewDlg : Form
    {
        public ZcTotalViewDlg()
        {
            InitializeComponent();
        }

        private void ZcTotalViewDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            foreach (var item in QtMgr.Instance().AllQtTask)
            {

                qtSelect.Items.Add(item.Key);
            }

            SetDataGridViewColumn();
        }

        private void InquertBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtSelect.SelectedIndex)
            {
                return;
            }

            EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
            string curJob = curEmployee.JobNumber;



            string qtKey = qtSelect.SelectedItem as string;
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];

            if (!qtTask.Closing)
            {
                MessageBox.Show("没有生成QT提成");
                return;
            }

            ShowQuery(qtTask);
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
            bumen.Width = 70;
            myDataGridView1.Columns.Add(bumen);

            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 100;
            myDataGridView1.Columns.Add(zhiji);

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

            DataGridViewTextBoxColumn zhuanyuan = new DataGridViewTextBoxColumn();
            zhuanyuan.Name = "zhuanyuan";
            zhuanyuan.HeaderText = "驻场专员";
            zhuanyuan.Width = 100;
            myDataGridView1.Columns.Add(zhuanyuan);


            DataGridViewTextBoxColumn zuanyuanbili = new DataGridViewTextBoxColumn();
            zuanyuanbili.Name = "zuanyuanbili";
            zuanyuanbili.HeaderText = "比例";
            zuanyuanbili.Width = 100;
            myDataGridView1.Columns.Add(zuanyuanbili);

            DataGridViewTextBoxColumn zuanyuanticheng = new DataGridViewTextBoxColumn();
            zuanyuanticheng.Name = "zuanyuanticheng";
            zuanyuanticheng.HeaderText = "实出提成";
            zuanyuanticheng.Width = 100;
            myDataGridView1.Columns.Add(zuanyuanticheng);


            DataGridViewTextBoxColumn zhuguan = new DataGridViewTextBoxColumn();
            zhuguan.Name = "zhuguan";
            zhuguan.HeaderText = "驻场主管";
            zhuguan.Width = 100;
            myDataGridView1.Columns.Add(zhuguan);

            DataGridViewTextBoxColumn zhuguanbili = new DataGridViewTextBoxColumn();
            zhuguanbili.Name = "zhuguanbili";
            zhuguanbili.HeaderText = "比例";
            zhuguanbili.Width = 100;
            myDataGridView1.Columns.Add(zhuguanbili);

            DataGridViewTextBoxColumn zhuguanticheng = new DataGridViewTextBoxColumn();
            zhuguanticheng.Name = "zhuguanticheng";
            zhuguanticheng.HeaderText = "实出提成";
            zhuguanticheng.Width = 100;
            myDataGridView1.Columns.Add(zhuguanticheng);


            DataGridViewTextBoxColumn zongjian = new DataGridViewTextBoxColumn();
            zongjian.Name = "zongjian";
            zongjian.HeaderText = "驻场总监";
            zongjian.Width = 100;
            myDataGridView1.Columns.Add(zongjian);

            DataGridViewTextBoxColumn zongjianbili = new DataGridViewTextBoxColumn();
            zongjianbili.Name = "zongjianbili";
            zongjianbili.HeaderText = "比例";
            zongjianbili.Width = 100;
            myDataGridView1.Columns.Add(zongjianbili);

            DataGridViewTextBoxColumn zongjianticheng = new DataGridViewTextBoxColumn();
            zongjianticheng.Name = "zongjianticheng";
            zongjianticheng.HeaderText = "实出提成";
            zongjianticheng.Width = 100;
            myDataGridView1.Columns.Add(zongjianticheng);

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
                foreach (var hyId in hyIdList)
                {
                    HYData hyData = HYMgr.Instance().AllHYData[hyId];
                    double prop = 0.007;
                    if (qtOrder.Zc2JobNumber != "")
                    {
                        prop = 0.0035;
                    }

                    UpdateRow(qtTask, qtOrder, hyData, qtOrder.Zc1JobNumber, prop, true);

                    if (qtOrder.Zc2JobNumber != "")
                    {
                        UpdateRow(qtTask, qtOrder, hyData, qtOrder.KyfConsultanJobNumber, 0.0035, false);
                    }
                }

            }

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

        string GetZhuguanName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuanyuan)
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

        string GetZongjianName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuanyuan || kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuguan)
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

        void UpdateRow(QtTask qtTask, QtOrder qtOrder, HYData hyData, string jobnumber, double prop, bool isShowParent)
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

            newRow.Cells["gongsiyongjin"].Value = DoubleUtil.Show(hyData.Amount);
            newRow.Cells["shuifei"].Value = DoubleUtil.Show(hyData.Shuifei);
            newRow.Cells["shouxufei"].Value = DoubleUtil.Show(hyData.Shouxufei);
            newRow.Cells["shishouyongjin"].Value = DoubleUtil.Show(hyData.Amount - hyData.Shuifei - hyData.Shouxufei);

            double basic = hyData.Amount - hyData.Shuifei - hyData.Shouxufei;
            {
                newRow.Cells["zhuanyuan"].Value = GetJobName(jobnumber, qtTask); ;
                newRow.Cells["zuanyuanbili"].Value = string.Format("%{0}", prop * 100);
                newRow.Cells["zuanyuanticheng"].Value = DoubleUtil.Show(basic * prop);
            }

            if (isShowParent)
            {

                newRow.Cells["zhuguan"].Value = GetZhuguanName(jobnumber, qtTask);
                newRow.Cells["zhuguanbili"].Value = string.Format("%{0}", 0.003 * 100);
                newRow.Cells["zhuguanticheng"].Value = DoubleUtil.Show(basic * 0.003);



                newRow.Cells["zongjian"].Value = GetZongjianName(jobnumber, qtTask);
                newRow.Cells["zongjianbili"].Value = string.Format("%{0}", 0.003 * 100);
                newRow.Cells["zongjianticheng"].Value = DoubleUtil.Show(basic * 0.003);
            }
            else
            {
                newRow.Cells["zhuguan"].Value ="";
                newRow.Cells["zhuguanbili"].Value = "";
                newRow.Cells["zhuguanticheng"].Value = "";



                newRow.Cells["zongjian"].Value = "";
                newRow.Cells["zongjianbili"].Value = "";
                newRow.Cells["zongjianticheng"].Value = "";
            }

        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExcelUtil.ExportData(myDataGridView1);
        }

    }
}
