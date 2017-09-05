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
    public partial class ChangePasswordDlg : Form
    {
        public ChangePasswordDlg()
        {
            InitializeComponent();
        }

        private void ChangePasswordDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            EmployeeData curLoginEmployee = AuthMgr.Instance().CurLoginEmployee;
            AuthData authData = curLoginEmployee.AuthData;
            string oldPwd = oldPwdEdi.Text;
            if (oldPwd != authData.Password)
            {
                MessageBox.Show("旧密码错误");
                return;
            }

            if (newPwdEdi.Text == "")
            {
                MessageBox.Show("新密码不能为空");
                return;
            }

            if (newPwdEdi.Text != newPwdEdi1.Text)
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            
            try
            {
                AuthMgr.Instance().ChangePassword(authData.JobNumber, newPwdEdi.Text);
                authData.Password = newPwdEdi.Text;
                MessageBox.Show("修改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }

            Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
