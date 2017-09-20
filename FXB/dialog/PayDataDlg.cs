﻿using System;
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
                if (data.OldGenerateTime == 0 || DoubleUtil.Equal(data.CurPay, data.OldPay))
                {
                    //什么都不做
                } 
                else
                {
                    row.Cells["qtpay2"].Value = data.OldPay;
                }
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
            bumen.Width = 100;
            myDataGridView1.Columns.Add(bumen);

            DataGridViewTextBoxColumn qtpay = new DataGridViewTextBoxColumn();
            qtpay.Name = "qtpay";
            qtpay.HeaderText = "QT工资";
            qtpay.Width = 100;
            myDataGridView1.Columns.Add(qtpay);


            DataGridViewTextBoxColumn qtpay2 = new DataGridViewTextBoxColumn();
            qtpay2.Name = "qtpay2";
            qtpay2.HeaderText = "QT工资2";
            qtpay2.Width = 100;
            myDataGridView1.Columns.Add(qtpay2);
        }
    }
}