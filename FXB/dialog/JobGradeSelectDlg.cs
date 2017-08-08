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
using FXB.Common;
namespace FXB.Dialog
{
    public partial class JobGradeSelectDlg : Form
    {
        private string selectJobGradeId = "";

        public string SelectJobGradeId
        {
            get { return selectJobGradeId; }
        }
        public JobGradeSelectDlg()
        {
            InitializeComponent();
        }

        private void LevelNameSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;


            JobGradeUtil.setDataGridViewColumn(dataGridView1);
            JobGradeDataMgr.Instance().SetDataGridView(dataGridView1);
            
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            GetSelectJobGrade();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            GetSelectJobGrade();
        }

        private void GetSelectJobGrade()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells[0];
            selectJobGradeId = (string)selectCell.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
