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


        private void okBtn_Click(object sender, EventArgs e)
        {

        }

        private void checkBtn_Click(object sender, EventArgs e)
        {

        }

        private void ViewHYDlg_Load(object sender, EventArgs e)
        {
            hyIDEdi.Enabled = false;
            hyAmountEdi.Enabled = false;
            hyTime.Enabled = false;
            jiesuanCb.Enabled = false;
            checkStateEdi.Enabled = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            hyIDEdi.Text = editHyData.Id.ToString();
            hyAmountEdi.Text = editHyData.Amount.ToString();
            hyTime.Value = TimeUtil.TimestampToDateTime(editHyData.AddTime);
            jiesuanCb.Checked = true;// editHyData.IsSettlement;
            checkStateEdi.Text = editHyData.CheckState ? "已审核" : "未审核";
            if (editHyData.CheckState)
            {
                checkJobNumberEdi.Text = EmployeeDataMgr.Instance().AllEmployeeData[editHyData.CheckJobNumber].Name;
                checkTimeEdi.Text = TimeUtil.TimestampToDateTime(editHyData.CheckTime).ToLongDateString();
            }

            //显示预发工资
        }
    }
}
