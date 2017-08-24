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
    public partial class ProjectSelectDlg : Form
    {
        private string selectProjectCode = "";
        public string SelectProjectCode
        {
            get { return selectProjectCode; }
        }
        public ProjectSelectDlg()
        {
            InitializeComponent();
        }

        private bool codeOrNameOrAddressInquire(BasicDataInterface bd)
        {
            ProjectData data = bd as ProjectData;
            if (paramEdi.Text == "")
            {
                return true;
            }
            if (data.Code.IndexOf(paramEdi.Text) != -1 ||
                data.Name.IndexOf(paramEdi.Text) != -1 ||
                data.Address.IndexOf(paramEdi.Text) != -1)
            {
                return true;
            }

            return false;
        }
        private void inquireBtn_Click(object sender, EventArgs e)
        {
            ProjectDataMgr.Instance().SetDataGridView(dataGridView1, codeOrNameOrAddressInquire);
        }

        private void ProjectSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            setDataGridViewColumn();
        }

        private void setDataGridViewColumn()
        {
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.Name = "code";
            code.HeaderText = "项目编码";
            code.Width = 100;
            dataGridView1.Columns.Add(code);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "项目名称";
            name.Width = 200;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn address = new DataGridViewTextBoxColumn();
            address.Name = "address";
            address.HeaderText = "地址";
            address.Width = 300;
            dataGridView1.Columns.Add(address);

            DataGridViewTextBoxColumn comment = new DataGridViewTextBoxColumn();
            comment.Name = "comment";
            comment.HeaderText = "备注";
            comment.Width = 300;
            dataGridView1.Columns.Add(comment);

            DataGridViewCheckBoxColumn available = new DataGridViewCheckBoxColumn();
            available.Name = "available";
            available.HeaderText = "是否可用";
            available.Width = 80;
            dataGridView1.Columns.Add(available);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells["code"];
            selectProjectCode = (string)selectCell.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
