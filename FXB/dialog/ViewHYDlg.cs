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

                    checkBtn.Text = "审核(回佣)";
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

                    checkBtn.Text = "取消审核(回佣)";
                }

                UpdateMoneyState(editHyData.CheckState);
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

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            {
                EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
                AuthData authData = curEmployee.AuthData;
                if (!authData.IfOwner && !authData.ShowCheckHyBtn())
                {
                    checkBtn.Visible = false;
                }
            }

            //回佣ID，回佣时间，审核状态，审核人，审核时间禁止编辑
            hyIDEdi.Enabled = false;
            //
            checkStateEdi.Enabled = false;
            checkJobNumberEdi.Enabled = false;
            checkTimeEdi.Enabled = false;

            

            hyIDEdi.Text = editHyData.Id.ToString();

            hyAmountEdi.Text = editHyData.Amount.ToString();
            shouxufeiEdi.Text = editHyData.Shouxufei.ToString();
            shuifeiEdi.Text = editHyData.Shuifei.ToString();

            hyTime.Value = TimeUtil.TimestampToDateTime(editHyData.AddTime);
            checkStateEdi.Text = editHyData.CheckState ? "已审核" : "未审核";
            if (editHyData.CheckState)
            {
                checkJobNumberEdi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editHyData.CheckJobNumber].Name;
                checkTimeEdi.Text = TimeUtil.TimestampToDateTime(editHyData.CheckTime).ToString("yyyy-MM-dd HH:mm:ss");

                checkBtn.Text = "取消审核(回佣)";
            } 
            else
            {
                checkBtn.Text = "审核(回佣)";
            }



            UpdateMoneyState(editHyData.CheckState);

            //显示预发工资

            //QtOrder order = OrderMgr.Instance().AllOrderData[editHyData.OrderId];//editHyData.OrderId
            //QtTask qtTask = QtMgr.Instance().AllQtTask[order.QtKey];


        }


        void UpdateMoneyState(bool checkState)
        {
            hyAmountEdi.Enabled = !checkState;
            shouxufeiEdi.Enabled = !checkState;
            shuifeiEdi.Enabled = !checkState;
            hyTime.Enabled = !checkState;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hyAmountEdi.Text == "")
                {
                    MessageBox.Show("回佣金额不能为空");
                    return;
                }

                if (shouxufeiEdi.Text == "")
                {
                    MessageBox.Show("手续费不能为空");
                    return;
                }

                if (shuifeiEdi.Text == "")
                {
                    MessageBox.Show("税费不能为空");
                    return;
                }


                if (!DoubleUtil.Check(hyAmountEdi.Text))
                {
                    MessageBox.Show("回佣金额格式错误");
                    return;
                }

                if (!DoubleUtil.Check(shouxufeiEdi.Text))
                {
                    MessageBox.Show("手续费格式错误");
                    return;
                }

                if (!DoubleUtil.Check(shuifeiEdi.Text))
                {
                    MessageBox.Show("税费格式错误");
                    return;
                }

                double newHyAmount = System.Math.Round(Convert.ToDouble(hyAmountEdi.Text), 2);
                double newShouxufei = System.Math.Round(Convert.ToDouble(shouxufeiEdi.Text), 2);
                double newShuifei = System.Math.Round(Convert.ToDouble(shuifeiEdi.Text), 2);
                UInt32 newTime = TimeUtil.DateTimeToTimestamp(hyTime.Value);
                HYMgr.Instance().UpdateAmount(editHyData.Id, newHyAmount, newShouxufei, newShuifei, newTime);
                DialogResult = DialogResult.OK;
                MessageBox.Show("保存成功");
                //Close();
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
    }
}
