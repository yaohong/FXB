using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FXB.Common
{
    class CheckBoxUtil
    {
        public static bool cbStateToBool(CheckState state)
        {
            if (state == CheckState.Checked)
            {
                return true;
            }
            else if (state == CheckState.Unchecked)
            {
                return false;
            }
            else
            {
                throw new CrashException("checkbox状态错误");
            }


        }

        public static CheckState boolToCbState(bool bl)
        {
            if (bl)
            {
                return CheckState.Checked;
            }
            else
            {
                return CheckState.Unchecked;
            }
        }
    }
}
