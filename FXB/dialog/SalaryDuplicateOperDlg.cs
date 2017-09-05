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
    public partial class SalaryDuplicateOperDlg : Form
    {
        private string curShowDxKey = "";
        public SalaryDuplicateOperDlg()
        {
            InitializeComponent();
        }

        private void SalaryDuplicateOperDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dxTaskTimeSelect.CustomFormat = "yyyy-MM";
            dxTaskTimeSelect.Format = DateTimePickerFormat.Custom;

            foreach (var item in DxDuplicateMgr.Instance().AllDxDuplicate)
            {
                dxCb.Items.Insert(0, item.Key);
            }

            SetDataGridViewColumn();
        }

        private void generateDxBtn_Click(object sender, EventArgs e)
        {
            string dxKey = dxTaskTimeSelect.Text;
            try
            {
                DxDuplicate newDxDuplicate = DxDuplicateMgr.Instance().AddNewDxDuplicate(dxKey);
                dxCb.Items.Insert(0, dxKey);
                dxCb.SelectedIndex = 0;
                ShowQtTask(newDxDuplicate);
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


        void ShowQtTask(DxDuplicate tmpDxDuplicate)
        {
            curShowDxKey = tmpDxDuplicate.DxKey;
            dataGridView1.Rows.Clear();
            foreach (var item in tmpDxDuplicate.AllDx)
            {
                int newLine = dataGridView1.Rows.Add();
                dataGridView1.Rows[newLine].Cells["gonghao"].Value = item.Key ;
                EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[item.Key];
                dataGridView1.Rows[newLine].Cells["name"].Value = employeeData.Name;
                dataGridView1.Rows[newLine].Cells["dx"].Value = item.Value;
            }
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 100;
            dataGridView1.Columns.Add(gonghao);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "姓名";
            name.Width = 100;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn dx = new DataGridViewTextBoxColumn();
            dx.Name = "dx";
            dx.HeaderText = "底薪";
            dx.Width = 100;
            dataGridView1.Columns.Add(dx);
        }

        private void viewDxBtn_Click(object sender, EventArgs e)
        {
            if (dxCb.SelectedItem != null)
            {
                string dxKey = (string)dxCb.SelectedItem;
                DxDuplicate dxDuplicate = DxDuplicateMgr.Instance().AllDxDuplicate[dxKey];
                ShowQtTask(dxDuplicate);
            }
        }

        private void removeDxBtn_Click(object sender, EventArgs e)
        {
            if (dxCb.SelectedItem != null)
            {
                string dxKey = (string)dxCb.SelectedItem;
                DxDuplicate dxDuplicate = DxDuplicateMgr.Instance().AllDxDuplicate[dxKey];

                try
                {
                    DxDuplicateMgr.Instance().RemoveDxDuplicate(dxKey);
                    dxCb.Items.Remove(dxKey);
                    if (dxKey == curShowDxKey)
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
    }
}
