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



        ZhuchangZhuanyuan = 5,
        ZhuchangZhuguan = 6,
        ZhuchangZongjian = 7
    }

    public class QtString
    {
        static readonly public string None = "没有QT级别";
        static readonly public string Salesman = "QT业务员";
        static readonly public string SmallCharge = "QT小主管";
        static readonly public string LargeCharge = "QT大主管";
        static readonly public string Majordomo = "QT总监";

        static readonly public string ZhuchangZhuanyuan = "驻场专员";
        static readonly public string ZhuchangZhuguan = "驻场主管";
        static readonly public string ZhuchangZongjian = "驻场总监";
    }

    public enum EditMode
    {
        EM_ADD = 0,
        EM_EDIT = 1,
    }

    //职级过滤的函数
    public delegate bool DataFilter(BasicDataInterface data);
}
