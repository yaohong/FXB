using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Data;
namespace FXB.Common
{

    public enum CbSetMode
    {
        CBSM_Employee = 0,           //员工
        CBSM_Department = 1          //部门
    }
    class QtUtil
    {
        static public void SetComboxValue(ComboBox cb,  CbSetMode mode)
        {
            if (mode == CbSetMode.CBSM_Employee)
            {
                cb.Items.Insert(0, QtString.None);
                cb.Items.Insert(1, QtString.Salesman);
                cb.Items.Insert(2, QtString.SmallCharge);
                cb.Items.Insert(3, QtString.LargeCharge);
                cb.Items.Insert(4, QtString.Majordomo);

                cb.SelectedIndex = 0;
                return;
            }

            if (mode == CbSetMode.CBSM_Department)
            {
                cb.Items.Insert(0, QtString.None);
                cb.Items.Insert(1, QtString.SmallCharge);
                cb.Items.Insert(2, QtString.LargeCharge);
                cb.Items.Insert(3, QtString.Majordomo);

                cb.SelectedIndex = 0;
                return;
            }
        }


        static public QtLevel GetQTLevel(string str)
        {
            if (str == QtString.None)
            {
                return QtLevel.None;
            } else if (str == QtString.Salesman)
            {
                return QtLevel.Salesman;
            } else if (str == QtString.SmallCharge)
            {
                return QtLevel.SmallCharge;
            } else if (str == QtString.LargeCharge)
            {
                return QtLevel.LargeCharge;
            } else if (str == QtString.Majordomo)
            {
                return QtLevel.Majordomo;
            }

            throw new TextException("错误QT级别字符串");
        }

        static public string GetQTLevelString(QtLevel level)
        {
            if (level == QtLevel.None)
            {
                return QtString.None;
            }
            else if (level == QtLevel.Salesman)
            {
                return QtString.Salesman;
            }
            else if (level == QtLevel.SmallCharge)
            {
                return QtString.SmallCharge;
            }
            else if (level == QtLevel.LargeCharge)
            {
                return QtString.LargeCharge;
            }
            else if (level == QtLevel.Majordomo)
            {
                return QtString.Majordomo;
            }

            throw new TextException("错误QT级别字符串");
        }
    }
}
