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
    public partial class AuthEditDlg : Form
    {
        private EmployeeData employeeData = null;
        public AuthEditDlg(EmployeeData data)
        {
            InitializeComponent();
            employeeData = data;
        }

        private void AuthEditDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gonghaoEdi.Text = employeeData.JobNumber;
            nameEdi.Text = employeeData.Name;
            bumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employeeData.DepartmentId);
            zhijieEdi.Text = employeeData.JobGradeName;
            pwdEdi.Text = employeeData.AuthData.Password;
            prohibitCb.CheckState = CheckBoxUtil.boolToCbState(employeeData.AuthData.Prohibit);

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void resertPwdBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
