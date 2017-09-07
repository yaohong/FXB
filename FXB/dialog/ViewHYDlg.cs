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
    public partial class ViewHYDlg : Form
    {
        private HYData editHyData;
        public ViewHYDlg(HYData hyData)
        {
            InitializeComponent();

            editHyData = hyData;
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (editHyData.CheckState)
                {
                    //取消审核
                    HYMgr.Instance().UpdateCheckState(editHyData.Id, false, "", 0);

                    checkStateEdi.Text = "未审核";
                    checkJobNumberEdi.Text = "";
                    checkTimeEdi.Text = "";

                    checkBtn.Text = "审核";
                }
                else
                {
                    //审核
                    EmployeeData curEmployeeData = AuthMgr.Instance().CurLoginEmployee;
                    UInt32 timestamp = TimeUtil.DateTimeToTimestamp(DateTime.Now);
                    HYMgr.Instance().UpdateCheckState(editHyData.Id, true, curEmployeeData.JobNumber, timestamp);

                    checkStateEdi.Text = "已审核";
                    checkJobNumberEdi.Text = curEmployeeData.Name;
                    checkTimeEdi.Text = TimeUtil.TimestampToDateTime(timestamp).ToString("yyyy-MM-dd HH:mm:ss");

                    checkBtn.Text = "取消审核";
                }
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
                return;
            }
        }

        private void ViewHYDlg_Load(object sender, EventArgs e)
        {

            {
                EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
                AuthData authData = curEmployee.AuthData;
                if (!authData.ShowCheckHyBtn())
                {
                    checkBtn.Visible = false;
                }
            }

            hyIDEdi.Enabled = false;
            hyAmountEdi.Enabled = false;
            hyTime.Enabled = false;
            jiesuanCb.Enabled = false;
            checkStateEdi.Enabled = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            hyIDEdi.Text = editHyData.Id.ToString();
            hyAmountEdi.Text = editHyData.Amount.ToString();
            hyTime.Value = TimeUtil.TimestampToDateTime(editHyData.AddTime);
            jiesuanCb.Checked = editHyData.IsSettlement;
            checkStateEdi.Text = editHyData.CheckState ? "已审核" : "未审核";
            if (editHyData.CheckState)
            {
                checkJobNumberEdi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editHyData.CheckJobNumber].Name;
                checkTimeEdi.Text = TimeUtil.TimestampToDateTime(editHyData.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");

                checkBtn.Text = "取消审核";
            } 
            else
            {
                checkBtn.Text = "审核";
            }
            checkJobNumberEdi.Enabled = false;
            checkTimeEdi.Enabled = false;

            ywyEdi.Enabled = false;
            ywyGZEdi.Enabled = false;
            kyfEdi.Enabled = false;
            kyfGZEdi.Enabled = false;
            //显示预发工资

            QtOrder order = OrderMgr.Instance().AllOrderData[editHyData.OrderId];//editHyData.OrderId
            QtTask qtTask = QtMgr.Instance().AllQtTask[order.QtKey];

            //姓名不能修改，直接从employeeMgr里面取
            string yxName = EmployeeDataMgr.Instance().AllEmployeeData[order.YxConsultantJobNumber].Name;
            double yxYFGongzi = editHyData.Amount * 0.1;
            string kyfName = "";
            double kyfYFGongzi = 0.0f;
            if (order.KyfConsultanJobNumber != "")
            {
                kyfName = EmployeeDataMgr.Instance().AllEmployeeData[order.KyfConsultanJobNumber].Name;

                yxYFGongzi = (editHyData.Amount * 0.9) * 0.1;
                kyfYFGongzi = (editHyData.Amount * 0.1) * 0.1;

                kyfEdi.Text = kyfName;
                kyfGZEdi.Text = System.Math.Round(kyfYFGongzi, 2).ToString();
            }

            ywyEdi.Text = yxName;
            ywyGZEdi.Text = System.Math.Round(yxYFGongzi, 2).ToString();


        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
