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
            viewLevelCb.Items.Insert(0, "查看本人");
            viewLevelCb.Items.Insert(1, "查看本部门");
            viewLevelCb.Items.Insert(2, "查看全公司");

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            gonghaoEdi.Text = employeeData.JobNumber;
            nameEdi.Text = employeeData.Name;
            bumenEdi.Text = DepartmentUtil.GetDepartmentShowText(employeeData.DepartmentId);
            zhijieEdi.Text = employeeData.JobGradeName;
            pwdEdi.Text = employeeData.AuthData.Password;
            prohibitCb.CheckState = CheckBoxUtil.boolToCbState(employeeData.AuthData.Prohibit);
            viewLevelCb.SelectedIndex = employeeData.AuthData.ViewLevel;

            InitControlCheck();

        }

        void InitControlCheck()
        {
            AuthData authData = employeeData.AuthData;
            jobMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowYuangongDanganMenu());
            jobLevelMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowZhijiDanganMenu());
            projectMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowXiangmuDanganMenu());
            userAuthMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowYonghuquanxianMenu());
            refreshMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowShuaXinShujuMenu());
            kaidanMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowKaiDanMenu());
            huyongMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowHuiYongMenu());
            tuidanMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowTuiDanMenu());
            dxluruMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowDixinLuruMenu());
            generateDxMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowGenerateDixinFubenMenu());
            qtTaskMenuCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowQtTaskMenu());
            addOrderBtnCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowAddOrderBtn());
            removeOrderBtnCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowDeleteOrderBtn());
            orderCheckBtnCb.CheckState = CheckBoxUtil.boolToCbState(authData.ShowOrderCheckBtn());
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            AuthData authData = employeeData.AuthData;

            bool newProhibit = CheckBoxUtil.cbStateToBool(prohibitCb.CheckState);
            Int32 newViewLevel = viewLevelCb.SelectedIndex;

            Int64 newControlMask = 0;
            if (jobMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.YuangongDanganMenuMask);
            }

            if (jobLevelMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.ZhijiDanganMenuMask);
            }

            if (projectMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.XiangmuDanganMenuMask);
            }

            if (userAuthMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.YonghuquanxianMenuMask);
            }

            if (refreshMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.ShuaXinShujuMenuMask);
            }

            if (kaidanMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.KaiDanMenuMask);
            }

            if (huyongMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.HuiYongMenuMask);
            }

            if (tuidanMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.TuiDanMenuMask);
            }

            if (dxluruMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.DixinLuruMenuMask);
            }

            if (generateDxMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.GenerateDixinFubenMenuMask);
            }

            if (qtTaskMenuCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.QtTaskMenuMask);
            }

            if (addOrderBtnCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.AddOrderBtnMask);
            }


            if (removeOrderBtnCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.DeleteOrderBtnMask);
            }

            if (orderCheckBtnCb.CheckState == CheckState.Checked)
            {
                newControlMask = (newControlMask | ControlMask.OrderCheckBtnMask);
            }

            if (authData.Prohibit != newProhibit ||
                authData.ViewLevel != newViewLevel ||
                authData.OperMake != newControlMask)
            {
                try 
                {
                    AuthMgr.Instance().ChangeAuthAttr(authData.JobNumber, newControlMask, newProhibit, newViewLevel);
                    authData.OperMake = newControlMask;
                    authData.Prohibit = newProhibit;
                    authData.ViewLevel = newViewLevel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    System.Environment.Exit(0);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void resertPwdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (employeeData.AuthData.Password == "123")
                {
                    return;
                }
                AuthMgr.Instance().ChangePassword(employeeData.JobNumber, "123");
                employeeData.AuthData.Password = "123";
                pwdEdi.Text = employeeData.AuthData.Password;
                MessageBox.Show("修改成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
