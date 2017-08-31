using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class ControlMask
    {
        public static Int64 YuangongDanganMenuMask = Convert.ToInt64("1", 2);
        public static Int64 ZhijiDanganMenuMask = Convert.ToInt64("10", 2);
        public static Int64 XiangmuDanganMenuMask = Convert.ToInt64("100", 2);
        public static Int64 YonghuquanxianMenuMask = Convert.ToInt64("1000", 2);
        public static Int64 ShuaXinShujuMenuMask = Convert.ToInt64("10000", 2);
        public static Int64 KaiDanMenuMask = Convert.ToInt64("100000", 2);
        public static Int64 HuiYongMenuMask = Convert.ToInt64("1000000", 2);
        public static Int64 TuiDanMenuMask = Convert.ToInt64("10000000", 2);
        public static Int64 DixinLuruMenuMask = Convert.ToInt64("100000000", 2);
        public static Int64 GenerateDixinFubenMenuMask = Convert.ToInt64("1000000000", 2);
        public static Int64 QtTaskMenuMask = Convert.ToInt64("10000000000", 2);
        public static Int64 AddOrderBtnMask = Convert.ToInt64("100000000000", 2);
        public static Int64 DeleteOrderBtnMask = Convert.ToInt64("1000000000000", 2);
        public static Int64 OrderCheckBtnMask = Convert.ToInt64("10000000000000", 2);
    }
    
        
    public class AuthData
    {
        private string jobNumber;
        private string password;
        private Int64 operMake;
        private bool prohibit;          //是否禁止登陆
        private bool ifOwner;           //是否是管理员
        private Int32 viewLevel;        //数据查看级别 0(查看自己),1(查看部门),2(查看全部)

        public string JobNumber
        {
            get { return jobNumber; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Prohibit
        {
            get { return prohibit; }
            set { prohibit = value; }
        }

        public  Int64 OperMake
        {
            get { return operMake; }
            set { operMake = value; }
        }

        public bool IfOwner
        {
            get { return ifOwner; }
        }

        public Int32 ViewLevel
        {
            get { return viewLevel; }
            set { viewLevel = value; }
        }
        public AuthData(string tmpJobnumber, string tmpPassword, Int64 tmpOperMake, bool tmpProhibit, bool tmpifOwner, Int32 tmpViewLevel)
        {
            jobNumber = tmpJobnumber;
            password = tmpPassword;
            operMake = tmpOperMake;
            prohibit = tmpProhibit;
            ifOwner = tmpifOwner;
            viewLevel = tmpViewLevel;
        }

        public bool ShowYuangongDanganMenu()
        {
            return (operMake & ControlMask.YuangongDanganMenuMask) == 0 ? false : true;
        }
        public bool ShowZhijiDanganMenu()
        {
            return (operMake & ControlMask.ZhijiDanganMenuMask) == 0 ? false : true;
        }
        public bool ShowXiangmuDanganMenu()
        {
            return (operMake & ControlMask.XiangmuDanganMenuMask) == 0 ? false : true;
        }

        public bool ShowYonghuquanxianMenu()
        {
            return (operMake & ControlMask.YonghuquanxianMenuMask) == 0 ? false : true;
        }

        public bool ShowShuaXinShujuMenu()
        {
            return (operMake & ControlMask.ShuaXinShujuMenuMask) == 0 ? false : true;
        }

        public bool ShowKaiDanMenu()
        {
            return (operMake & ControlMask.KaiDanMenuMask) == 0 ? false : true;
        }

        public bool ShowHuiYongMenu()
        {
            return (operMake & ControlMask.HuiYongMenuMask) == 0 ? false : true;
        }

        public bool ShowTuiDanMenu()
        {
            return (operMake & ControlMask.TuiDanMenuMask) == 0 ? false : true;
        }

        public bool ShowDixinLuruMenu()
        {
            return (operMake & ControlMask.DixinLuruMenuMask) == 0 ? false : true;
        }

        public bool ShowGenerateDixinFubenMenu()
        {
            return (operMake & ControlMask.GenerateDixinFubenMenuMask) == 0 ? false : true;
        }

        public bool ShowQtTaskMenu()
        {
            return (operMake & ControlMask.QtTaskMenuMask) == 0 ? false : true;
        }

        public bool ShowAddOrderBtn()
        {
            return (operMake & ControlMask.AddOrderBtnMask) == 0 ? false : true;
        }

        public bool ShowDeleteOrderBtn()
        {
            return (operMake & ControlMask.DeleteOrderBtnMask) == 0 ? false : true;
        }

        public bool ShowOrderCheckBtn()
        {
            return (operMake & ControlMask.OrderCheckBtnMask) == 0 ? false : true;
        }
    }
}
