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
                cb.Items.Insert(0, "没有QT级别");
                cb.Items.Insert(1, "业务员");
                cb.Items.Insert(2, "小主管");
                cb.Items.Insert(3, "大主管");
                cb.Items.Insert(4, "总监");

                cb.SelectedIndex = 0;
                return;
            }

            if (mode == CbSetMode.CBSM_Department)
            {
                cb.Items.Insert(0, "没有QT级别");
                cb.Items.Insert(1, "小主管");
                cb.Items.Insert(2, "大主管");
                cb.Items.Insert(3, "总监");

                cb.SelectedIndex = 0;
                return;
            }
        }


        static public QtLevel GetQTLevel(ComboBox cb, CbSetMode mode)
        {
            QtLevel level = QtLevel.None;
            if (mode == CbSetMode.CBSM_Employee)
            {
                if (cb.SelectedIndex == 0)
                {
                    level = QtLevel.None;
                } 
                else if (cb.SelectedIndex == 1)
                {
                    level = QtLevel.Salesman;
                } 
                else if (cb.SelectedIndex == 2)
                {
                    level = QtLevel.SmallCharge;
                } 
                else if (cb.SelectedIndex == 3)
                {
                    level = QtLevel.LargeCharge;
                } 
                else if (cb.SelectedIndex == 4)
                {
                    level = QtLevel.Majordomo;
                }
                else
                {
                    throw (new TextException("错误的QT索引"));
                }
            } 
            else if (mode == CbSetMode.CBSM_Department)
            {
                if (cb.SelectedIndex == 0)
                {
                    level = QtLevel.None;
                }
                else if (cb.SelectedIndex == 1)
                {
                    level = QtLevel.SmallCharge;
                }
                else if (cb.SelectedIndex == 2)
                {
                    level = QtLevel.LargeCharge;
                }
                else if (cb.SelectedIndex == 3)
                {
                    level = QtLevel.Majordomo;
                }
                else
                {
                    throw (new TextException("错误的QT索引"));
                }
            }
            else
            {
                throw (new TextException("错误的cb类型"));
            }


            return level;
        }
    }
}
