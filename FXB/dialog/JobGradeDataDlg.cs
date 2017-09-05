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
    public partial class JobGradeDataDlg : Form, DBUpdateInterface
    {
        public JobGradeDataDlg()
        {
            InitializeComponent();
        }

        private void JobGradeDataDlg_Load(object sender, EventArgs e)
        {
            JobGradeUtil.setDataGridViewColumn(dataGridView1);
            this.WindowState = FormWindowState.Maximized;

            //禁止改变表格的大小
            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            JobGradeDataMgr.Instance().SetDataGridView(dataGridView1);
        }

        //职级过滤的函数
        private bool levelNameInquire(BasicDataInterface bd)
        {
            JobGradeData data = bd as JobGradeData;
            if (keyEdit.Text == "")
            {
                return true;
            }
            if (data.LevelName.IndexOf(keyEdit.Text) != -1)
            {
                return true;
            }

            return false;
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {
            
            JobGradeDataMgr.Instance().SetDataGridView(dataGridView1, levelNameInquire);
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            JobGradeOperDlg dlg = new JobGradeOperDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.NewLevelName != "")
                {
                    JobGradeData newGradeData = JobGradeDataMgr.Instance().AllJobGradeData[dlg.NewLevelName];
                    int newLine = dataGridView1.Rows.Add();
                    UpdateGridViewRow(dataGridView1.Rows[newLine], newGradeData);
                }
            }
            
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow selectRow = dataGridView1.SelectedRows[0];
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)selectRow.Cells[0];
            string zhiji = (string)selectCell.Value;
            JobGradeData selectData = JobGradeDataMgr.Instance().AllJobGradeData[zhiji];


            try
            {
                JobGradeDataMgr.Instance().DeleteJobGrade(selectData.LevelName);
                //删除选中行
                dataGridView1.Rows.RemoveAt(selectRow.Index);

            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells[0];
            string zhiji = (string)selectCell.Value;

            JobGradeData selectData = JobGradeDataMgr.Instance().AllJobGradeData[zhiji];
            JobGradeOperDlg dlg = new JobGradeOperDlg(selectData);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //修改
                UpdateGridViewRow(dataGridView1.SelectedRows[0], selectData);
            }
        }


        private void UpdateGridViewRow(DataGridViewRow row, JobGradeData data)
        {
            row.Cells["zhiji"].Value = data.LevelName;
            row.Cells["xulie"].Value = data.XuLie;
            row.Cells["dixin"].Value = data.BaseSalary;
            row.Cells["beizhu"].Value = data.Comment;
        }

        public void DbRefresh()
        {

        }


    }
}
