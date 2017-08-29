using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.DataManager;
using FXB.Data;
namespace FXB.Common
{
    public class CommissionUtil
    {
        //获取各个QT级别获取的提成比例
        static public string GetCommissionPropToStr(QtDepartment qtDepartment) 
        {
            bool isComplete = qtDepartment.AlreadyCompleteTaskAmount >= qtDepartment.NeedCompleteTaskAmount;
            if (qtDepartment.QtLevel == QtLevel.SmallCharge)
            {
                if (isComplete)
                {
                    return "6%";
                }
                else
                {
                    return "3%";
                }
            }
            else if (qtDepartment.QtLevel == QtLevel.LargeCharge)
            {
                if (isComplete)
                {
                    return "4%";
                }
                else
                {
                    return "2%";
                }
            }
            else if (qtDepartment.QtLevel == QtLevel.Majordomo)
            {
                return "3%";
            }
            else if (qtDepartment.QtLevel == QtLevel.None)
            {
                if (qtDepartment.ParentDepartmentId != 0)
                {
                    throw new CrashException("QT结构的非根目录的QT属性为NONE");
                }
                //根目录
                return "2%";
            }
            else 
            {
                throw new CrashException("QT结构的QT属性异常");
            }
        }
    }
}
