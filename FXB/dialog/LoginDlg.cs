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
    public partial class LoginDlg : Form
    {
        public LoginDlg()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (jobnumberEdi.Text == "")
            {
                MessageBox.Show("工号不能为空");
                return;
            }

            if (passwordEdi.Text == "")
            {
                MessageBox.Show("密码不能为空");
                return;
            }

            try
            {
                string loginJobnumber = "";
                if (!EmployeeDataMgr.Instance().AllEmployeeData.ContainsKey(jobnumberEdi.Text))
                {
                    //当手机号尝试
                    if (!EmployeeDataMgr.Instance().AllPhoneToJobnumber.ContainsKey(jobnumberEdi.Text))
                    {
                        MessageBox.Show("账号错误");
                        return;
                    }
                    loginJobnumber = EmployeeDataMgr.Instance().AllPhoneToJobnumber[jobnumberEdi.Text];
                } 
                else
                {
                    loginJobnumber = jobnumberEdi.Text;
                }
                EmployeeData data = EmployeeDataMgr.Instance().AllEmployeeData[loginJobnumber];
                if (data.AuthData.Password != passwordEdi.Text)
                {
                    MessageBox.Show("密码错误");
                    return;
                }

                AuthMgr.Instance().CurLoginEmployee = data;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ConditionCheckException e1)
            {
                MessageBox.Show(e1.Message);
                return;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
                System.Environment.Exit(0);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
