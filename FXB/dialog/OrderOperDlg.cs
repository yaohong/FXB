using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXB.Dialog
{
    public partial class OrderOperDlg : Form
    {
        public OrderOperDlg()
        {
            InitializeComponent();
        }

        private void OrderOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }



        private void RefreshCheckState(string checkState, string checkPersoName, string checkTime, string luruPersoName )
        {
            string str = string.Format("审核状态:{0}        审核人:{1}        审核日期:{2}         录入人:{3}", checkState, checkPersoName, checkPersoName, luruPersoName);
            shenheInfo.Text = str;
        }
    }
}
