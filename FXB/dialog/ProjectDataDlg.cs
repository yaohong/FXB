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
    public partial class ProjectDataDlg : Form
    {
        public ProjectDataDlg()
        {
            InitializeComponent();
        }

        private void ProjectDataDlg_Load(object sender, EventArgs e)
        {
            setDataGridViewColumn();
            this.WindowState = FormWindowState.Maximized;

            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            ProjectDataMgr.Instance().SetDataGridView(dataGridView1);
        }

        private bool codeOrNameOrAddressInquire(BasicDataInterface bd)
        {
            ProjectData data = bd as ProjectData;
            if (keyEdi.Text == "")
            {
                return true;
            }
            if (data.Code.IndexOf(keyEdi.Text) != -1 || 
                data.Name.IndexOf(keyEdi.Text) != -1 ||
                data.Address.IndexOf(keyEdi.Text) != -1)
            {
                return true;
            }

            return false;
        }
        private void inquireBtn_Click(object sender, EventArgs e)
        {
            ProjectDataMgr.Instance().SetDataGridView(dataGridView1, codeOrNameOrAddressInquire);
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            ProjectOperDlg dlg = new ProjectOperDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.NewCode != "")
                {
                    ProjectData newProjectData = ProjectDataMgr.Instance().AllProjectData[dlg.NewCode];
                    int newLine = dataGridView1.Rows.Add();
                    UpdateGridViewRow(dataGridView1.Rows[newLine], newProjectData);
                }
            }
        }

        private void UpdateGridViewRow(DataGridViewRow row, ProjectData data)
        {
            row.Cells["code"].Value = data.Code;
            row.Cells["name"].Value = data.Name;
            row.Cells["address"].Value = data.Address;
            row.Cells["comment"].Value = data.Comment;
            row.Cells["available"].Value = data.IsAvailable;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells[0];
            string code = (string)selectCell.Value;

            ProjectData selectData = ProjectDataMgr.Instance().AllProjectData[code];
            ProjectOperDlg dlg = new ProjectOperDlg(selectData);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //修改
                UpdateGridViewRow(dataGridView1.SelectedRows[0], selectData);
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
            string code = (string)selectCell.Value;
            ProjectData selectData = ProjectDataMgr.Instance().AllProjectData[code];


            try
            {
                ProjectDataMgr.Instance().DeleteProject(selectData.Code);
                //删除选中行
                dataGridView1.Rows.RemoveAt(selectRow.Index);

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
