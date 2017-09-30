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
    public partial class PayDataDlg : Form
    {
        public PayDataDlg()
        {
            InitializeComponent();
        }

        private void InquireBtn_Click(object sender, EventArgs e)
        {
            if (-1 == monthSelectCb.SelectedIndex)
            {
                return;
            }

            string qtKey = monthSelectCb.SelectedItem as string;

            if (!PayDataMgr.Instance().AllQtPay.ContainsKey(qtKey))
            {
                MessageBox.Show("工资没有生成");
                return;
            }
            myDataGridView1.Rows.Clear();
            SortedDictionary<string, PayData> allPayData = PayDataMgr.Instance().AllQtPay[qtKey];
            
            foreach (var item in allPayData)
            {
                PayData data = item.Value;
                int lineIndex = myDataGridView1.Rows.Add();
                DataGridViewRow row = myDataGridView1.Rows[lineIndex];
                row.Cells["qtkey"].Value = qtKey;
                row.Cells["gonghao"].Value = item.Key;

                EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[item.Key];
                row.Cells["name"].Value = employeeData.Name;
                row.Cells["bumen"].Value = DepartmentUtil.GetDepartmentShowText(employeeData.DepartmentId);
                row.Cells["qtpay"].Value = data.CurPay;
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            if (-1 == monthSelectCb.SelectedIndex)
            {
                return;
            }

            string qtKey = monthSelectCb.SelectedItem as string;

            if (PayDataMgr.Instance().AllQtPay.ContainsKey(qtKey))
            {
                MessageBox.Show("工资已经生成");
                return;
            }

            //查找qtkey标示月份所导入的回佣
            SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> hyPay = new SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>>();
            SortedDictionary<string, SortedDictionary<string, double>> dxPay = new SortedDictionary<string, SortedDictionary<string, double>>();

            try
            {
                PayUtil.GeneratePay(qtKey, ref hyPay, ref dxPay);
                PayDataMgr.Instance().GeneratePay(qtKey, hyPay, dxPay);
            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
                return;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                System.Environment.Exit(0);
                return;
            }
            
        }

        private void PayDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            foreach (var item in QtMgr.Instance().AllQtTask)
            {
                monthSelectCb.Items.Add(item.Key);
            }

            SetDataGridViewColumn();
        }



        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn qtkey = new DataGridViewTextBoxColumn();
            qtkey.Name = "qtkey";
            qtkey.HeaderText = "月份";
            qtkey.Width = 100;
            qtkey.Visible = false;
            myDataGridView1.Columns.Add(qtkey);

            //DataGridViewTextBoxColumn jobnumber = new DataGridViewTextBoxColumn();
            //jobnumber.Name = "jobnumber";
            //jobnumber.HeaderText = "工号";
            //jobnumber.Width = 100;
            //jobnumber.Visible = false;
            //myDataGridView1.Columns.Add(jobnumber);

            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 100;
            myDataGridView1.Columns.Add(gonghao);

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

            DataGridViewTextBoxColumn qtpay = new DataGridViewTextBoxColumn();
            qtpay.Name = "qtpay";
            qtpay.HeaderText = "QT工资";
            qtpay.Width = 100;
            myDataGridView1.Columns.Add(qtpay);

        }
    }
}
