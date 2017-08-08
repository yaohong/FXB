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
namespace FXB.Dialog
{
    public partial class DepartmentSelectDlg : Form
    {
        private DepartmentData selectDepartment = null;
        public DepartmentData SelectDepartment
        {
            get { return selectDepartment; }
            set { selectDepartment = value; }
        }
        public DepartmentSelectDlg()
        {
            InitializeComponent();
        }

        private void DepartmentSelectDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            DepartmentDataMgr.Instance().SetTreeView(treeView1);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            GetSelectDepartment();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetSelectDepartment();
        }


        private void GetSelectDepartment()
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                Int64 departmentId = Convert.ToInt64(selectNode.Name);
                selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
