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
    public partial class AddHYDlg : Form
    {
        private Int64 newHYId = 0;


        private Int64 orderId;
        public Int64 NewHYId
        {
            get { return newHYId; }
        }
        public AddHYDlg(Int64 tmpOrderId)
        {
            InitializeComponent();

            orderId = tmpOrderId;
        }

        private void AddHYDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            shouxufeiEdi.Text = "0";
            shuifeiEdi.Text = "0";
        }

        private void addHYBtn_Click(object sender, EventArgs e)
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


            

            double hyAmount = System.Math.Round(Convert.ToDouble(hyAmountEdi.Text), 2);
            double shouxufei = System.Math.Round(Convert.ToDouble(shouxufeiEdi.Text), 2);
            double shuifei = System.Math.Round(Convert.ToDouble(shuifeiEdi.Text), 2);

            EmployeeData curEmplyee = AuthMgr.Instance().CurLoginEmployee;

            try
            {
                HYData data = HYMgr.Instance().AddNewHY(
                    orderId, 
                    hyAmount, 
                    TimeUtil.DateTimeToTimestamp(hyAddTime.Value),
                    curEmplyee.JobNumber, 
                    shouxufei, 
                    shuifei);
                newHYId = data.Id;
                DialogResult = DialogResult.OK;
                return;
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
