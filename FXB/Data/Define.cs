using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
namespace FXB.Data
{
    //qt级别
    public enum QtLevel
    {
        // 摘要: 
        //没有qt级别
        None = 0,
        //
        // 摘要: 
        //     业务员。
        Salesman = 1,
        // 摘要: 
        //     小主管。
        SmallCharge = 2,
        //
        // 摘要: 
        //     大主管。
        LargeCharge = 3,
        //
        // 摘要: 
        //     总监。
        Majordomo = 4,
    }

    public class QtString
    {
        static readonly public string None = "没有QT级别";
        static readonly public string Salesman = "业务员";
        static readonly public string SmallCharge = "小主管";
        static readonly public string LargeCharge = "大主管";
        static readonly public string Majordomo = "总监";
    }

    public enum EditMode
    {
        EM_ADD = 0,
        EM_EDIT = 1,
    }

    //职级过滤的函数
    delegate bool DataFilter(BasicDataInterface data);
}
