using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
