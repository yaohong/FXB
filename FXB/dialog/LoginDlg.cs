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
                AuthData authItem = AuthMgr.Instance().GetAuth(jobnumberEdi.Text);
                if (authItem.Password != passwordEdi.Text)
                {
                    MessageBox.Show("密码错误");
                    return;
                }

                AuthMgr.Instance().CurLoginAuth = authItem;
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
                Application.Exit();
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
