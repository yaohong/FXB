using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Data;
using System.Windows.Forms;
namespace FXB.Common
{
    class JobGradeUtil
    {
        static public void setDataGridViewColumn(DataGridView view)
        {
            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 100;
            view.Columns.Add(zhiji);

            DataGridViewTextBoxColumn xulie = new DataGridViewTextBoxColumn();
            xulie.Name = "xulie";
            xulie.HeaderText = "所属序列";
            xulie.Width = 100;
            view.Columns.Add(xulie);

            DataGridViewTextBoxColumn dixin = new DataGridViewTextBoxColumn();
            dixin.Name = "dixin";
            dixin.HeaderText = "对应底薪";
            dixin.Width = 100;
            view.Columns.Add(dixin);

            DataGridViewTextBoxColumn beizhu = new DataGridViewTextBoxColumn();
            beizhu.Name = "beizhu";
            beizhu.HeaderText = "备注";
            beizhu.Width = 300;
            view.Columns.Add(beizhu);
        }
    }
}
