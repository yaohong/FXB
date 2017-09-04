﻿using System;
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
    public partial class OrderDataDlg : Form
    {
        private string selectJobNumber = "";
        public OrderDataDlg()
        {
            InitializeComponent();
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {
            string qtKey = "";
            if (qtCbSelect.SelectedIndex == -1)
            {
                return;
            }
            dataGridView1.Rows.Clear();
            qtKey = qtCbSelect.SelectedItem as string;

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            foreach (var item in qtTask.AllQtOrder)
            {
                QtOrder qtOrder = item.Value;
                if (selectJobNumber != "" && qtOrder.YxConsultantJobNumber != selectJobNumber)
                {
                    //过滤营销顾问
                    continue;
                }

                if (paramEdi.Text != "")
                {
                    //过滤查询关键字
                    if (qtOrder.RoomNumber.IndexOf(paramEdi.Text) == -1 &&
                        qtOrder.ProjectCode.IndexOf(paramEdi.Text) == -1)
                    {
                        continue;
                    }
                }

                int lineIndex = dataGridView1.Rows.Add();
                UpdateGridViewRow(dataGridView1.Rows[lineIndex], qtOrder);
            }

        }

        private void OrderDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            salesmanEdi.Enabled = false;

            SetDataGridViewColumn();

            foreach (var item in QtMgr.Instance().AllQtTask)
            {
                qtCbSelect.Items.Add(item.Key);
            }

            AuthData curAuth = AuthMgr.Instance().CurLoginEmployee.AuthData;
            if (!curAuth.IfOwner && !curAuth.ShowAddOrderBtn())
            {
                //不显示新增开单
                addOrderBtn.Visible = false;
            }

            if (!curAuth.IfOwner && !curAuth.ShowDeleteOrderBtn())
            {
                removeOrderBtn.Visible = false;
            }
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn orderid = new DataGridViewTextBoxColumn();
            orderid.Name = "orderid";
            orderid.HeaderText = "开单编号";
            orderid.Width = 80;
            dataGridView1.Columns.Add(orderid);

            DataGridViewTextBoxColumn ordertime = new DataGridViewTextBoxColumn();
            ordertime.Name = "ordertime";
            ordertime.HeaderText = "开单日期";
            ordertime.Width = 80;
            dataGridView1.Columns.Add(ordertime);

            DataGridViewTextBoxColumn qtKey = new DataGridViewTextBoxColumn();
            qtKey.Name = "qtKey";
            qtKey.HeaderText = "所属QT任务";
            qtKey.Width = 110;
            dataGridView1.Columns.Add(qtKey);

            DataGridViewTextBoxColumn customerName = new DataGridViewTextBoxColumn();
            customerName.Name = "customerName";
            customerName.HeaderText = "客户名称";
            customerName.Width = 80;
            dataGridView1.Columns.Add(customerName);

            DataGridViewTextBoxColumn projectName = new DataGridViewTextBoxColumn();
            projectName.Name = "projectName";
            projectName.HeaderText = "项目名称";
            projectName.Width = 100;
            dataGridView1.Columns.Add(projectName);

            DataGridViewTextBoxColumn roomNumber = new DataGridViewTextBoxColumn();
            roomNumber.Name = "roomNumber";
            roomNumber.HeaderText = "房号";
            roomNumber.Width = 130;
            dataGridView1.Columns.Add(roomNumber);

            DataGridViewTextBoxColumn closingTheDealMoney = new DataGridViewTextBoxColumn();
            closingTheDealMoney.Name = "closingTheDealMoney";
            closingTheDealMoney.HeaderText = "成交总价";
            closingTheDealMoney.Width = 80;
            dataGridView1.Columns.Add(closingTheDealMoney);

            DataGridViewTextBoxColumn commissionAmount = new DataGridViewTextBoxColumn();
            commissionAmount.Name = "commissionAmount";
            commissionAmount.HeaderText = "佣金总额";
            commissionAmount.Width = 80;
            dataGridView1.Columns.Add(commissionAmount);

            DataGridViewTextBoxColumn yxConsultantName = new DataGridViewTextBoxColumn();
            yxConsultantName.Name = "yxConsultantName";
            yxConsultantName.HeaderText = "营销顾问";
            yxConsultantName.Width = 80;
            dataGridView1.Columns.Add(yxConsultantName);

            DataGridViewTextBoxColumn kyfConsultanName = new DataGridViewTextBoxColumn();
            kyfConsultanName.Name = "kyfConsultanName";
            kyfConsultanName.HeaderText = "客源方";
            kyfConsultanName.Width = 80;
            dataGridView1.Columns.Add(kyfConsultanName);

            DataGridViewTextBoxColumn zhuchang1Name = new DataGridViewTextBoxColumn();
            zhuchang1Name.Name = "zhuchang1Name";
            zhuchang1Name.HeaderText = "驻场1";
            zhuchang1Name.Width = 80;
            dataGridView1.Columns.Add(zhuchang1Name);

            DataGridViewTextBoxColumn zhuchang2Name = new DataGridViewTextBoxColumn();
            zhuchang2Name.Name = "zhuchang2Name";
            zhuchang2Name.HeaderText = "驻场2";
            zhuchang2Name.Width = 80;
            dataGridView1.Columns.Add(zhuchang2Name);

            DataGridViewCheckBoxColumn checkState = new DataGridViewCheckBoxColumn();
            checkState.Name = "checkState";
            checkState.HeaderText = "审核状态";
            checkState.Width = 80;
            dataGridView1.Columns.Add(checkState);

            DataGridViewTextBoxColumn checkPersonName = new DataGridViewTextBoxColumn();
            checkPersonName.Name = "checkPersonName";
            checkPersonName.HeaderText = "审核人";
            checkPersonName.Width = 100;
            dataGridView1.Columns.Add(checkPersonName);

            DataGridViewTextBoxColumn checkTime = new DataGridViewTextBoxColumn();
            checkTime.Name = "checkTime";
            checkTime.HeaderText = "审核日期";
            checkTime.Width = 130;
            dataGridView1.Columns.Add(checkTime);

            DataGridViewTextBoxColumn entryPersonName = new DataGridViewTextBoxColumn();
            entryPersonName.Name = "entryPersonName";
            entryPersonName.HeaderText = "录入人";
            entryPersonName.Width = 100;
            dataGridView1.Columns.Add(entryPersonName);

            DataGridViewCheckBoxColumn cbState = new DataGridViewCheckBoxColumn();
            cbState.Name = "cbState";
            cbState.HeaderText = "是否退单";
            cbState.Width = 100;
            dataGridView1.Columns.Add(cbState);

            DataGridViewTextBoxColumn cbName = new DataGridViewTextBoxColumn();
            cbName.Name = "cbName";
            cbName.HeaderText = "退单人";
            cbName.Width = 100;
            dataGridView1.Columns.Add(cbName);

            DataGridViewTextBoxColumn cbTime = new DataGridViewTextBoxColumn();
            cbTime.Name = "cbTime";
            cbTime.HeaderText = "退单日期";
            cbTime.Width = 130;
            dataGridView1.Columns.Add(cbTime);

            DataGridViewTextBoxColumn comment = new DataGridViewTextBoxColumn();
            comment.Name = "comment";
            comment.HeaderText = "备注";
            comment.Width = 300;
            dataGridView1.Columns.Add(comment);

            DataGridViewTextBoxColumn buyTime = new DataGridViewTextBoxColumn();
            buyTime.Name = "buyTime";
            buyTime.HeaderText = "购买日期";
            buyTime.Width = 130;
            dataGridView1.Columns.Add(buyTime);

            DataGridViewTextBoxColumn customerPhone = new DataGridViewTextBoxColumn();
            customerPhone.Name = "customerPhone";
            customerPhone.HeaderText = "联系电话";
            customerPhone.Width = 100;
            dataGridView1.Columns.Add(customerPhone);

            DataGridViewTextBoxColumn customerIdCard = new DataGridViewTextBoxColumn();
            customerIdCard.Name = "customerIdCard";
            customerIdCard.HeaderText = "客户身份证";
            customerIdCard.Width = 120;
            dataGridView1.Columns.Add(customerIdCard);

            DataGridViewTextBoxColumn receipt = new DataGridViewTextBoxColumn();
            receipt.Name = "receipt";
            receipt.HeaderText = "收据";
            receipt.Width = 100;
            dataGridView1.Columns.Add(receipt);

            DataGridViewTextBoxColumn roomArea = new DataGridViewTextBoxColumn();
            roomArea.Name = "roomArea";
            roomArea.HeaderText = "面积";
            roomArea.Width = 100;
            dataGridView1.Columns.Add(roomArea);

            DataGridViewTextBoxColumn contractState = new DataGridViewTextBoxColumn();
            contractState.Name = "contractState";
            contractState.HeaderText = "合同状态";
            contractState.Width = 100;
            dataGridView1.Columns.Add(contractState);

            DataGridViewTextBoxColumn paymentMethod = new DataGridViewTextBoxColumn();
            paymentMethod.Name = "paymentMethod";
            paymentMethod.HeaderText = "付款方式";
            paymentMethod.Width = 100;
            dataGridView1.Columns.Add(paymentMethod);

            DataGridViewTextBoxColumn loansMoney = new DataGridViewTextBoxColumn();
            loansMoney.Name = "loansMoney";
            loansMoney.HeaderText = "贷款金额";
            loansMoney.Width = 100;
            dataGridView1.Columns.Add(loansMoney);
        }

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            OrderOperDlg dlg = new OrderOperDlg();
            if (DialogResult.OK ==  dlg.ShowDialog())
            {
                QtOrder newOrder = dlg.NewOrder;
                int newLine = dataGridView1.Rows.Add();
                UpdateGridViewRow(dataGridView1.Rows[newLine], newOrder);
            }
        }

        private void UpdateGridViewRow(DataGridViewRow row, QtOrder data)
        {
            row.Cells["orderid"].Value = data.Id;
            row.Cells["ordertime"].Value = TimeUtil.TimestampToDateTime(data.GenerateTime).ToShortDateString();
            row.Cells["qtKey"].Value = data.QtKey;
            row.Cells["customerName"].Value = data.CustomerName;
            row.Cells["projectName"].Value = ProjectDataMgr.Instance().AllProjectData[data.ProjectCode].Name ;
            row.Cells["roomNumber"].Value = data.RoomNumber;

            row.Cells["closingTheDealMoney"].Value = data.ClosingTheDealMoney;
            row.Cells["commissionAmount"].Value = data.CommissionAmount;

            row.Cells["yxConsultantName"].Value = EmployeeDataMgr.Instance().AllEmployeeData[data.YxConsultantJobNumber].Name;
            row.Cells["kyfConsultanName"].Value = data.KyfConsultanJobNumber != "" ? EmployeeDataMgr.Instance().AllEmployeeData[data.KyfConsultanJobNumber].Name : "";
            row.Cells["zhuchang1Name"].Value = data.Zc1JobNumber != "" ? EmployeeDataMgr.Instance().AllEmployeeData[data.Zc1JobNumber].Name : "";
            row.Cells["zhuchang2Name"].Value = data.Zc2JobNumber != "" ? EmployeeDataMgr.Instance().AllEmployeeData[data.Zc2JobNumber].Name : "";
            row.Cells["checkState"].Value = data.CheckState;
            if (data.CheckState)
            {
                row.Cells["checkPersonName"].Value = EmployeeDataMgr.Instance().AllEmployeeData[data.CheckPersonJobNumber].Name; ;
                row.Cells["checkTime"].Value = TimeUtil.TimestampToDateTime(data.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                row.Cells["checkPersonName"].Value ="";
                row.Cells["checkTime"].Value = "";
            }

            //录入人暂时不填
            row.Cells["entryPersonName"].Value = EmployeeDataMgr.Instance().AllEmployeeData[data.EntryPersonJobNumber].Name;

            //row.Cells["cbState"].Value = data.IfChargeback;
            //if (data.IfChargeback)
            //{
            //    row.Cells["cbName"].Value = EmployeeDataMgr.Instance().AllEmployeeData[data.CbJobNumber].Name; ;
            //    row.Cells["cbTime"].Value = TimeUtil.TimestampToDateTime(data.CbTime).ToString("yyyy-MM-dd HH:mm:ss");
            //}

            row.Cells["comment"].Value = data.Comment;
            row.Cells["buyTime"].Value = TimeUtil.TimestampToDateTime(data.BuyTime).ToString("yyyy-MM-dd HH:mm:ss");
            row.Cells["customerPhone"].Value = data.CustomerPhone;
            row.Cells["customerIdCard"].Value = data.CustomerIdCard;
            row.Cells["receipt"].Value = data.Receipt;
            row.Cells["roomArea"].Value = data.RoomArea;
            row.Cells["contractState"].Value = data.ContractState;
            row.Cells["paymentMethod"].Value = data.PaymentMethod;
            row.Cells["loansMoney"].Value = data.LoansMoney;
        }

        private void salesmanSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(null);
            if (DialogResult.OK == selectDlg.ShowDialog())
            {
                selectJobNumber = selectDlg.SelectEmployeeJobNumber;
                if (selectJobNumber != "")
                {
                    EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[selectJobNumber];
                    salesmanEdi.Text = employeeData.Name;
                }
                else
                {
                    salesmanEdi.Text = "";
                }

            }
        }

        private void removeOrderBtn_Click(object sender, EventArgs e)
        {
            //删除订单
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewRow selectRow = dataGridView1.SelectedRows[0];

            Int64 orderId = (Int64)selectRow.Cells["orderid"].Value;
            string qtKey = (string)selectRow.Cells["qtKey"].Value;
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (qtTask.Closing)
            {
                MessageBox.Show(string.Format("QT任务[{0}]已经结算，请执行 [清除QT提成] 后在执行该操作", qtKey));
                return;
            }

            
            if (!qtTask.AllQtOrder.ContainsKey(orderId))
            {
                MessageBox.Show(string.Format("订单[{0}]不属于QT任务[{1}], 请重新查询", orderId, qtKey));
                return;
            }
            //审核过后也可以删
            //QtOrder qtOrder = qtTask.AllQtOrder[orderId];
            //if (qtOrder.CheckState)
            //{
            //    MessageBox.Show(string.Format("订单[{0}]已经通过审核，请执行 [取消审核后] 后在执行该操作", orderId));
            //    return;
            //}

            try
            {
                QtMgr.Instance().RemoveQtOrder(orderId);
                qtTask.AllQtOrder.Remove(orderId);
                dataGridView1.Rows.RemoveAt(selectRow.Index);
            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewRow selectRow = dataGridView1.SelectedRows[0];

            Int64 orderId = (Int64)selectRow.Cells["orderid"].Value;
            string qtKey = (string)selectRow.Cells["qtKey"].Value;

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];

            if (!qtTask.AllQtOrder.ContainsKey(orderId))
            {
                MessageBox.Show(string.Format("订单[{0}]不属于QT任务[{1}], 请重新查询", orderId, qtKey));
                return;
            }
            QtOrder qtOrder = qtTask.AllQtOrder[orderId];

            OrderOperDlg dlg = new OrderOperDlg(qtOrder);
            dlg.ShowDialog();
            UpdateGridViewRow(selectRow, qtOrder);

        }
    }
}
