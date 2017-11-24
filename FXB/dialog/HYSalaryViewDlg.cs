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

    public partial class HYSalaryViewDlg : Form
    {
        private string selectJobNumber = "";
        public HYSalaryViewDlg()
        {
            InitializeComponent();
        }


        string GetPayTypeString(PayType pt)
        {
            switch (pt)
            {
                case PayType.PT_COMMISSION_PAY:
                    return "业务员提成";
                case PayType.PT_COMMISSION_SmallCharge_PAY:
                    return "业务员小主管提成";
                case PayType.PT_COMMISSION_LargeCharge_PAY:
                    return "业务员大主管提成";
                case PayType.PT_COMMISSION_Majordomo_PAY:
                    return "业务员总监提成";
                case PayType.PT_KYF_COMMISSION_PAY:
                    return "客源方提成";
                case PayType.PT_KYF_COMMISSION_SmallCharge_PAY:
                    return "客源方小主管提成";
                case PayType.PT_KYF_COMMISSION_LargeCharge_PAY:
                    return "客源方大主管提成";
                case PayType.PT_KYF_COMMISSION_Majordomo_PAY:
                    return "客源方总监提成";
                case PayType.PT_None_COMMISSION_PAY:
                    return "总经理提成";
                case PayType.PT_ZhuchangZhuanyuan_COMMISSION_PAY:
                    return "驻场专员提成";
                case PayType.PT_ZhuchangZhuguan_COMMISSION_PAY:
                    return "驻场主管提成";
                case PayType.PT_ZhuchangZongjian_COMMISSION_PAY:
                    return "驻场总监提成";
                default:
                    throw new CrashException(string.Format("错误的提成类型 {0}", pt));
            }
        }

        void ShowQuery(SortedDictionary<Int64, List<PayItem>> singlePayItem, string qtKey, string curJob)
        {
            myDataGridView1.Rows.Clear();
            SortedDictionary<Int64, List<Int64>> orderToHy = new SortedDictionary<Int64, List<Int64>>();

            foreach (var item in singlePayItem)
            {
                HYData hyData = HYMgr.Instance().AllHYData[item.Key];
                QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];

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

            double totoalShichuticheng = 0;
            foreach (var item2 in orderToHy)
            {
                Int64 orderId = item2.Key;
                List<Int64> hyIdList = item2.Value;
                QtOrder qtOrder = OrderMgr.Instance().AllOrderData[orderId];

                foreach (var hyId in hyIdList)
                {
                    List<PayItem> payItemList = singlePayItem[hyId];
                    foreach (var payItem in payItemList)
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
                        newRow.Cells["chengjiaozongjia"].Value = DoubleUtil.Show(qtOrder.ClosingTheDealMoney);
                        newRow.Cells["yongjinzonge"].Value = DoubleUtil.Show(qtOrder.CommissionAmount);
                        newRow.Cells["leijihuiyong"].Value = DoubleUtil.Show(qtOrder.CalcAllHyWhenCheck());
                        newRow.Cells["benyuehuiyong"].Value = DoubleUtil.Show(qtOrder.CalcMonthHyWhenCheck(qtKey));
                        newRow.Cells["shuifeiandshouxufei"].Value = DoubleUtil.Show(qtOrder.CalcMonthShuifeishouxufeiWhenCheck(qtKey)); ;
                        newRow.Cells["shichuyongjin"].Value = DoubleUtil.Show(qtOrder.CalcMonthHyWhenCheck(qtKey) - qtOrder.CalcMonthShuifeishouxufeiWhenCheck(qtKey));

                        newRow.Cells["yichujiangjing"].Value = 0;
                        newRow.Cells["shichuticheng"].Value = DoubleUtil.Show(payItem.money);
                        totoalShichuticheng += payItem.money;
                        newRow.Cells["tichengleixing"].Value = GetPayTypeString(payItem.type);
                        if (payItem.type == PayType.PT_KYF_COMMISSION_PAY)
                        {
                            newRow.Cells["fenchaibili"].Value = "10%";
                        }
                        else if (payItem.type == PayType.PT_COMMISSION_PAY)
                        {
                            int prop = qtOrder.YxJob.GetProp(curJob);
                            newRow.Cells["fenchaibili"].Value = string.Format("{0}%", prop / 100);
                        }
                        else
                        {
                            newRow.Cells["fenchaibili"].Value = "";
                        }
                    }

                


                }

            }
            //末尾添加一行总计
            {
                int count = myDataGridView1.Rows.Count;

                int endRowId = myDataGridView1.Rows.Add();
                DataGridViewRow endRow = myDataGridView1.Rows[endRowId];
                endRow.Cells["chengjiaoriqi"].Value = "总额:";

                endRow.Cells["shichuticheng"].Value = DoubleUtil.Show(totoalShichuticheng);
            }
        }

        private void InqueryBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtSelectCb.SelectedIndex)
            {
                return;
            }

            EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
            string curJob = curEmployee.JobNumber;

            if (selectJobNumber != "")
            {
                curJob = selectJobNumber;
            }

            string qtKey = qtSelectCb.SelectedItem as string;
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];

            if (!qtTask.Closing)
            {
                MessageBox.Show("没有生成QT提成");
                return;
            }


            SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> hyPay = new SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>>();
            PayUtil.GeneratePay(qtKey, ref hyPay);

            if (!hyPay.ContainsKey(curJob))
            {
                MessageBox.Show("没有QT工资");
                return;
            }

            //归类订单
            ShowQuery(hyPay[curJob], qtKey, curJob);
            
        }

        private void HYSalaryViewDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            foreach (var item in QtMgr.Instance().AllQtTask)
            {

                qtSelectCb.Items.Add(item.Key);
            }

            SetDataGridViewColumn();

            selectJobEdi.Visible = false;
            selectBtn.Visible = false;
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


            DataGridViewTextBoxColumn chengjiaozongjia = new DataGridViewTextBoxColumn();
            chengjiaozongjia.Name = "chengjiaozongjia";
            chengjiaozongjia.HeaderText = "成交总价";
            chengjiaozongjia.Width = 100;
            myDataGridView1.Columns.Add(chengjiaozongjia);

            DataGridViewTextBoxColumn yongjinzonge = new DataGridViewTextBoxColumn();
            yongjinzonge.Name = "yongjinzonge";
            yongjinzonge.HeaderText = "公司佣金";
            yongjinzonge.Width = 100;
            myDataGridView1.Columns.Add(yongjinzonge);

            DataGridViewTextBoxColumn leijihuiyong = new DataGridViewTextBoxColumn();
            leijihuiyong.Name = "leijihuiyong";
            leijihuiyong.HeaderText = "累计回佣";
            leijihuiyong.Width = 100;
            myDataGridView1.Columns.Add(leijihuiyong);

            DataGridViewTextBoxColumn benyuehuiyong = new DataGridViewTextBoxColumn();
            benyuehuiyong.Name = "benyuehuiyong";
            benyuehuiyong.HeaderText = "本月回佣";
            benyuehuiyong.Width = 100;
            myDataGridView1.Columns.Add(benyuehuiyong);

            DataGridViewTextBoxColumn shuifeiandshouxufei = new DataGridViewTextBoxColumn();
            shuifeiandshouxufei.Name = "shuifeiandshouxufei";
            shuifeiandshouxufei.HeaderText = "税费/手续费";
            shuifeiandshouxufei.Width = 100;
            myDataGridView1.Columns.Add(shuifeiandshouxufei);

            DataGridViewTextBoxColumn shichuyongjin = new DataGridViewTextBoxColumn();
            shichuyongjin.Name = "shichuyongjin";
            shichuyongjin.HeaderText = "实出佣金";
            shichuyongjin.Width = 100;
            myDataGridView1.Columns.Add(shichuyongjin);

            DataGridViewTextBoxColumn yichujiangjing = new DataGridViewTextBoxColumn();
            yichujiangjing.Name = "yichujiangjing";
            yichujiangjing.HeaderText = "预发工资";
            yichujiangjing.Width = 100;
            myDataGridView1.Columns.Add(yichujiangjing);

            DataGridViewTextBoxColumn shichuticheng = new DataGridViewTextBoxColumn();
            shichuticheng.Name = "shichuticheng";
            shichuticheng.HeaderText = "实出提成";
            shichuticheng.Width = 100;
            myDataGridView1.Columns.Add(shichuticheng);

            DataGridViewTextBoxColumn tichengleixing = new DataGridViewTextBoxColumn();
            tichengleixing.Name = "tichengleixing";
            tichengleixing.HeaderText = "提成类型";
            tichengleixing.Width = 200;
            myDataGridView1.Columns.Add(tichengleixing);

            DataGridViewTextBoxColumn fenchaibili = new DataGridViewTextBoxColumn();
            fenchaibili.Name = "fenchaibili";
            fenchaibili.HeaderText = "分拆比例";
            fenchaibili.Width = 100;
            myDataGridView1.Columns.Add(fenchaibili);

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(null);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                selectJobNumber = selectDlg.SelectEmployeeJobNumber;
                if (selectJobNumber != "")
                {
                    EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[selectJobNumber];
                    selectJobEdi.Text = employeeData.Name;
                }
                else
                {
                    selectJobEdi.Text = "";
                }

            }
        }

    }
}
