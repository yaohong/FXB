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
    public partial class QtTaskOperDlg : Form
    {
        private string curShowQtKey = "";
        public QtTaskOperDlg()
        {
            InitializeComponent();
        }

        private void QtTaskOperDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            qtTaskTimeSelect.CustomFormat = "yyyy-MM";
            qtTaskTimeSelect.Format = DateTimePickerFormat.Custom;

            foreach (var item in QtMgr.Instance().AllQtTask)
            {
                qtCb.Items.Insert(0, item.Key);
            }

            SetDataGridViewColumn();
            
        }

        private void qtTaskGenerateBtn_Click(object sender, EventArgs e)
        {
            string qtKey = qtTaskTimeSelect.Text;
            try
            {
                QtTask newQtTask = QtMgr.Instance().AddNewQtTask(qtKey);
                qtCb.Items.Insert(0, qtKey);
                qtCb.SelectedIndex = 0;
                ShowQtTask(newQtTask);
            }
            catch (ConditionCheckException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                System.Environment.Exit(0);
            }
            
        }

        private void viewQtTaskBtn_Click(object sender, EventArgs e)
        {
           if (qtCb.SelectedItem != null)
           {
               string qtKey = (string)qtCb.SelectedItem;
               QtTask selectQtTask = QtMgr.Instance().AllQtTask[qtKey];
               ShowQtTask(selectQtTask);
           }
        }

        private void ShowQtTask(QtTask qtTask)
        {
            curShowQtKey = qtTask.QtKey;
            dataGridView1.Rows.Clear();
            IterationShowQtTask(qtTask.RootQtDepartment, qtTask);
        }

        private void IterationShowQtTask(QtDepartment qtDepartment, QtTask qtTask)
        {
            if (qtDepartment.QtLevel == QtLevel.ZhuchangZongjian ||
                qtDepartment.QtLevel == QtLevel.ZhuchangZhuguan)
            {
                return;
            }

            if (qtDepartment.OwnerJobNumber != "" && !DoubleUtil.Equal(System.Math.Round(qtDepartment.NeedCompleteTaskAmount, 2), 0))
            {
                int newLine = dataGridView1.Rows.Add();

                dataGridView1.Rows[newLine].Cells["department"].Value = DepartmentUtil.GetQtDepartmentShowText(qtTask, qtDepartment.Id);
                dataGridView1.Rows[newLine].Cells["qtlevel"].Value = QtUtil.GetQTLevelString(qtDepartment.QtLevel);


                EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[qtDepartment.OwnerJobNumber];
                dataGridView1.Rows[newLine].Cells["owner"].Value = employeeData.Name;

                dataGridView1.Rows[newLine].Cells["qtTaskAmount"].Value = DoubleUtil.Show(qtDepartment.NeedCompleteTaskAmount);
                if (!qtTask.Closing)
                {
                    //没有结算
                    dataGridView1.Rows[newLine].Cells["ifSettle"].Value = false;
                }
                else
                {
                    dataGridView1.Rows[newLine].Cells["ifSettle"].Value = true;
                    dataGridView1.Rows[newLine].Cells["completeTaskAmount"].Value = DoubleUtil.Show(qtDepartment.AlreadyCompleteTaskAmount);

                    QtEmployee qtEmployee = qtTask.AllQtEmployee[qtDepartment.OwnerJobNumber];
                    dataGridView1.Rows[newLine].Cells["prop"].Value = CommissionUtil.GetCommissionPropToStr(qtDepartment, qtEmployee);

                }
            }


            foreach (var item in qtDepartment.ChildDepartmentIdSet)
            {
                QtDepartment chidQtDepartment = qtTask.AllQtDepartment[item];
                IterationShowQtTask(chidQtDepartment, qtTask);
            }
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn department = new DataGridViewTextBoxColumn();
            department.Name = "department";
            department.HeaderText = "部门";
            department.Width = 300;
            dataGridView1.Columns.Add(department);

            DataGridViewTextBoxColumn qtLevel = new DataGridViewTextBoxColumn();
            qtLevel.Name = "qtlevel";
            qtLevel.HeaderText = "部门QT级别";
            qtLevel.Width = 120;
            dataGridView1.Columns.Add(qtLevel);

            DataGridViewTextBoxColumn owner = new DataGridViewTextBoxColumn();
            owner.Name = "owner";
            owner.HeaderText = "主管";
            owner.Width = 100;
            dataGridView1.Columns.Add(owner);

            DataGridViewTextBoxColumn needCompleteTaskAmount = new DataGridViewTextBoxColumn();
            needCompleteTaskAmount.Name = "qtTaskAmount";
            needCompleteTaskAmount.HeaderText = "任务金额";
            needCompleteTaskAmount.Width = 100;
            dataGridView1.Columns.Add(needCompleteTaskAmount);

            DataGridViewCheckBoxColumn ifSettle = new DataGridViewCheckBoxColumn();
            ifSettle.Name = "ifSettle";
            ifSettle.HeaderText = "是否结算";
            ifSettle.Width = 70;
            dataGridView1.Columns.Add(ifSettle);

            DataGridViewTextBoxColumn completeTaskAmount = new DataGridViewTextBoxColumn();
            completeTaskAmount.Name = "completeTaskAmount";
            completeTaskAmount.HeaderText = "完成金额";
            completeTaskAmount.Width = 100;
            dataGridView1.Columns.Add(completeTaskAmount);

            DataGridViewTextBoxColumn prop = new DataGridViewTextBoxColumn();
            prop.Name = "prop";
            prop.HeaderText = "提成比例";
            prop.Width = 100;
            dataGridView1.Columns.Add(prop);
        }

        private void removeQtTaskBtn_Click(object sender, EventArgs e)
        {
            if (qtCb.SelectedItem != null)
            {
                if (MessageBox.Show("确认要删除QT任务?", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
                string qtKey = (string)qtCb.SelectedItem;


                try
                {
                    QtMgr.Instance().RemoveQtTask(qtKey);
                    qtCb.Items.Remove(qtKey);
                    if (qtKey == curShowQtKey)
                    {
                        dataGridView1.Rows.Clear();
                    }
                }
                catch (ConditionCheckException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    System.Environment.Exit(0);
                }
            }
        }

        private void generateQtPushbtn_Click(object sender, EventArgs e)
        {
            if (qtCb.SelectedItem != null)
            {
                string qtKey = (string)qtCb.SelectedItem;

                try
                {
                    QtMgr.Instance().CalcQtCommission(qtKey);
                    QtTask qtTak = QtMgr.Instance().AllQtTask[qtKey];
                    ShowQtTask(qtTak);
                }
                catch (ConditionCheckException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    System.Environment.Exit(0);
                }
            }
        }

        private void clearQtPushBtn_Click(object sender, EventArgs e)
        {
            if (qtCb.SelectedItem != null)
            {
                string qtKey = (string)qtCb.SelectedItem;

                try
                {
                    QtMgr.Instance().ClearQtCommission(qtKey);
                    QtTask qtTak = QtMgr.Instance().AllQtTask[qtKey];
                    ShowQtTask(qtTak);
                }
                catch (ConditionCheckException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    System.Environment.Exit(0);
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            ExcelUtil.ExportData(dataGridView1);
        }


    }
}
