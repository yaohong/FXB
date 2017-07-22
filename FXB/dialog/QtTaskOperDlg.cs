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
    public partial class QtTaskOperDlg : Form
    {
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
                QtMgr.Instance().AddNewQtTask(qtKey);
                qtCb.Items.Insert(0, qtKey);
            }
            catch (ConditionCheckException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                Application.Exit();
            }
            
        }

        private void viewQtTaskBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn department = new DataGridViewTextBoxColumn();
            department.Name = "department";
            department.HeaderText = "部门";
            department.Width = 100;
            dataGridView1.Columns.Add(department);

            DataGridViewTextBoxColumn qtLevel = new DataGridViewTextBoxColumn();
            qtLevel.Name = "qtlevel";
            qtLevel.HeaderText = "QT级别";
            qtLevel.Width = 70;
            dataGridView1.Columns.Add(qtLevel);

            DataGridViewTextBoxColumn owner = new DataGridViewTextBoxColumn();
            owner.Name = "owner";
            owner.HeaderText = "管理员";
            owner.Width = 100;
            dataGridView1.Columns.Add(owner);

            DataGridViewTextBoxColumn needCompleteTaskAmount = new DataGridViewTextBoxColumn();
            needCompleteTaskAmount.Name = "qtTaskAmount";
            needCompleteTaskAmount.HeaderText = "QT任务";
            needCompleteTaskAmount.Width = 250;
            dataGridView1.Columns.Add(needCompleteTaskAmount);

        }
    }
}
