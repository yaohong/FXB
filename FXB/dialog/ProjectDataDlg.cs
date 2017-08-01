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
        }

        private void inquireBtn_Click(object sender, EventArgs e)
        {

        }

        private void setDataGridViewColumn()
        {
            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "项目名称";
            name.Width = 200;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.Name = "code";
            code.HeaderText = "项目编码";
            code.Width = 100;
            dataGridView1.Columns.Add(code);

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

            DataGridViewCheckBoxColumn state = new DataGridViewCheckBoxColumn();
            state.Name = "state";
            state.HeaderText = "是否可用";
            state.Width = 80;
            dataGridView1.Columns.Add(state);
        }
    }
}
