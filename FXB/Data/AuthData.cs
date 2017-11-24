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
        //public static Int64 AddOrderBtnMask = Convert.ToInt64("1000000", 2);            //新增开单
        //public static Int64 RemoveOrderBtnMask = Convert.ToInt64("10000000", 2);        //删除开单
        public static Int64 DixinLuruMenuMask = Convert.ToInt64("100000000", 2);
        public static Int64 GenerateDixinFubenMenuMask = Convert.ToInt64("1000000000", 2);
        public static Int64 QtTaskMenuMask = Convert.ToInt64("10000000000", 2);
        public static Int64 AddOrderBtnMask = Convert.ToInt64("100000000000", 2);           //新增开单
        public static Int64 DeleteOrderBtnMask = Convert.ToInt64("1000000000000", 2);       //删除开单
        public static Int64 OrderCheckBtnMask = Convert.ToInt64("10000000000000", 2);       //订单审核

        public static Int64 HYVisibleTabMask = Convert.ToInt64("100000000000000", 2);       //回佣是否可见
        public static Int64 AddHyBtnMask = Convert.ToInt64("1000000000000000", 2);          //添加回佣
        public static Int64 DeleteHyBtnMask = Convert.ToInt64("10000000000000000", 2);      //删除回佣
        public static Int64 CheckHyBtnMask = Convert.ToInt64("100000000000000000", 2);      //回佣审核按钮

        public static Int64 TDVisibleTabMask = Convert.ToInt64("1000000000000000000", 2);   //退单页签是否可见
        public static Int64 TDCbMask = Convert.ToInt64("10000000000000000000", 2);          //退单选择框是否可点击
        public static Int64 TDCheckCbMask = Convert.ToInt64("100000000000000000000", 2);    //退单审核是否可点击

        public static Int64 GenerateQtGongziMenuMask = Convert.ToInt64("1000000000000000000000", 2);    //生成QT工资

        public static Int64 TichengmingxibiaoMenuMask = Convert.ToInt64("10000000000000000000000", 2);    //生成QT工资
        public static Int64 ChengjiaobaogaoMenuMask = Convert.ToInt64("100000000000000000000000", 2);    //生成QT工资
        public static Int64 ZhuchangtichengMenuMask = Convert.ToInt64("1000000000000000000000000", 2);    //生成QT工资
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


        public bool ShowDixinLuruMenu()
        {
            return (operMake & ControlMask.DixinLuruMenuMask) == 0 ? false : true;
        }

        public bool ShowGenerateDixinFubenMenu()
        {
            return (operMake & ControlMask.GenerateDixinFubenMenuMask) == 0 ? false : true;
        }

        public bool ShowGenerateQtGongziMenu()
        {
            return (operMake & ControlMask.GenerateQtGongziMenuMask) == 0 ? false : true;
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

        public bool ShowHYVisibleTab()
        {
            return (operMake & ControlMask.HYVisibleTabMask) == 0 ? false : true;
        }

        public bool ShowAddHyBtn()
        {
            return (operMake & ControlMask.AddHyBtnMask) == 0 ? false : true;
        }

        public bool ShowDeleteHyBtn()
        {
            return (operMake & ControlMask.DeleteHyBtnMask) == 0 ? false : true;
        }

        public bool ShowCheckHyBtn()
        {
            return (operMake & ControlMask.CheckHyBtnMask) == 0 ? false : true;
        }


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public bool ShowTDVisibleTab()
        {
            return (operMake & ControlMask.TDVisibleTabMask) == 0 ? false : true;
        }

        public bool ShowTDCb()
        {
            return (operMake & ControlMask.TDCbMask) == 0 ? false : true;
        }

        public bool ShowTDCheckCb()
        {
            return (operMake & ControlMask.TDCheckCbMask) == 0 ? false : true;
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        public bool ShowTichengmingxibiaoMenu()
        {
            return (operMake & ControlMask.TichengmingxibiaoMenuMask) == 0 ? false : true;
        }

        public bool ShowChengjiaobaogaoMenu()
        {
            return (operMake & ControlMask.ChengjiaobaogaoMenuMask) == 0 ? false : true;
        }

        public bool ShowZhuchangtichengMenu()
        {
            return (operMake & ControlMask.ZhuchangtichengMenuMask) == 0 ? false : true;
        }
    }
}
