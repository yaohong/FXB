using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FXB.MyControl
{
    class MyTableLayoutPanel : TableLayoutPanel
    {
        public MyTableLayoutPanel()
        {
            this.SetStyle(ControlStyles.UserPaint |ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
