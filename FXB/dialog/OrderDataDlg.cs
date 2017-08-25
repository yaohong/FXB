using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXB.Dialog
{
    public partial class OrderDataDlg : Form
    {
        public OrderDataDlg()
        {
            InitializeComponent();
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {

        }

        private void OrderDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            salesmanEdi.Enabled = false;

            SetDataGridViewColumn();
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn orderid = new DataGridViewTextBoxColumn();
            orderid.Name = "orderid";
            orderid.HeaderText = "开单编号";
            orderid.Width = 120;
            dataGridView1.Columns.Add(orderid);

            DataGridViewTextBoxColumn ordertime = new DataGridViewTextBoxColumn();
            ordertime.Name = "ordertime";
            ordertime.HeaderText = "开单日期";
            ordertime.Width = 120;
            dataGridView1.Columns.Add(ordertime);

            DataGridViewTextBoxColumn customerName = new DataGridViewTextBoxColumn();
            customerName.Name = "customerName";
            customerName.HeaderText = "客户名称";
            customerName.Width = 100;
            dataGridView1.Columns.Add(customerName);

            DataGridViewTextBoxColumn projectName = new DataGridViewTextBoxColumn();
            projectName.Name = "projectName";
            projectName.HeaderText = "项目名称";
            projectName.Width = 100;
            dataGridView1.Columns.Add(projectName);

            DataGridViewTextBoxColumn roomNumber = new DataGridViewTextBoxColumn();
            roomNumber.Name = "roomNumber";
            roomNumber.HeaderText = "房号";
            roomNumber.Width = 100;
            dataGridView1.Columns.Add(roomNumber);

            DataGridViewTextBoxColumn closingTheDealMoney = new DataGridViewTextBoxColumn();
            closingTheDealMoney.Name = "closingTheDealMoney";
            closingTheDealMoney.HeaderText = "成交总价";
            closingTheDealMoney.Width = 100;
            dataGridView1.Columns.Add(closingTheDealMoney);

            DataGridViewTextBoxColumn commissionAmount = new DataGridViewTextBoxColumn();
            commissionAmount.Name = "commissionAmount";
            commissionAmount.HeaderText = "佣金总额";
            commissionAmount.Width = 100;
            dataGridView1.Columns.Add(commissionAmount);

            DataGridViewTextBoxColumn yxConsultantName = new DataGridViewTextBoxColumn();
            yxConsultantName.Name = "yxConsultantName";
            yxConsultantName.HeaderText = "营销顾问";
            yxConsultantName.Width = 100;
            dataGridView1.Columns.Add(yxConsultantName);

            DataGridViewTextBoxColumn kyfConsultanName = new DataGridViewTextBoxColumn();
            kyfConsultanName.Name = "kyfConsultanName";
            kyfConsultanName.HeaderText = "客源方";
            kyfConsultanName.Width = 100;
            dataGridView1.Columns.Add(kyfConsultanName);

            DataGridViewTextBoxColumn zhuchang1Name = new DataGridViewTextBoxColumn();
            zhuchang1Name.Name = "zhuchang1Name";
            zhuchang1Name.HeaderText = "驻场1";
            zhuchang1Name.Width = 100;
            dataGridView1.Columns.Add(zhuchang1Name);

            DataGridViewTextBoxColumn zhuchang2Name = new DataGridViewTextBoxColumn();
            zhuchang2Name.Name = "zhuchang2Name";
            zhuchang2Name.HeaderText = "驻场2";
            zhuchang2Name.Width = 100;
            dataGridView1.Columns.Add(zhuchang2Name);

            DataGridViewCheckBoxColumn checkState = new DataGridViewCheckBoxColumn();
            checkState.Name = "checkState";
            checkState.HeaderText = "审核状态";
            checkState.Width = 100;
            dataGridView1.Columns.Add(checkState);

            DataGridViewTextBoxColumn checkPersonName = new DataGridViewTextBoxColumn();
            checkPersonName.Name = "checkPersonName";
            checkPersonName.HeaderText = "审核人";
            checkPersonName.Width = 100;
            dataGridView1.Columns.Add(checkPersonName);

            DataGridViewTextBoxColumn checkTime = new DataGridViewTextBoxColumn();
            checkTime.Name = "checkTime";
            checkTime.HeaderText = "审核日期";
            checkTime.Width = 100;
            dataGridView1.Columns.Add(checkTime);

            DataGridViewTextBoxColumn entryPersonName = new DataGridViewTextBoxColumn();
            entryPersonName.Name = "entryPersonName";
            entryPersonName.HeaderText = "录入人";
            entryPersonName.Width = 100;
            dataGridView1.Columns.Add(entryPersonName);

            DataGridViewCheckBoxColumn orderState = new DataGridViewCheckBoxColumn();
            orderState.Name = "orderState";
            orderState.HeaderText = "订单状态";
            orderState.Width = 100;
            dataGridView1.Columns.Add(orderState);

            DataGridViewTextBoxColumn comment = new DataGridViewTextBoxColumn();
            comment.Name = "comment";
            comment.HeaderText = "备注";
            comment.Width = 300;
            dataGridView1.Columns.Add(comment);

            DataGridViewTextBoxColumn buyTime = new DataGridViewTextBoxColumn();
            buyTime.Name = "buyTime";
            buyTime.HeaderText = "购买日期";
            buyTime.Width = 100;
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
            dlg.ShowDialog();
        }

        private void salesmanSelectBtn_Click(object sender, EventArgs e)
        {
            EmployeeSelectDlg selectDlg = new EmployeeSelectDlg(null);
            selectDlg.ShowDialog();
        }
    }
}
