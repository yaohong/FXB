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
        }

        private void addHYBtn_Click(object sender, EventArgs e)
        {
            if (hyAmountEdi.Text == "")
            {
                MessageBox.Show("回佣金额不能为空");
                return;
            }
            else
            {
                if (!DoubleUtil.Check(hyAmountEdi.Text))
                {
                    MessageBox.Show("回佣金额格式错误");
                    return;
                }
            }

            double hyAmount = System.Math.Round(Convert.ToDouble(hyAmountEdi.Text), 2);
            EmployeeData curEmplyee = AuthMgr.Instance().CurLoginEmployee;

            try
            {
                HYData data = HYMgr.Instance().AddNewHY(orderId, hyAmount, TimeUtil.DateTimeToTimestamp(hyAddTime.Value), curEmplyee.JobNumber);
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
                Application.Exit();
                return;
            }


        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
