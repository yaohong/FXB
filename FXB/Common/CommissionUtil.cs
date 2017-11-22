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
        static public string GetCommissionPropToStr(QtDepartment qtDepartment, QtEmployee qtEmployee) 
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
                if (qtEmployee.JobGradeName == "总监")
                {
                    return "3%";
                }
                else if (qtEmployee.JobGradeName == "区域总监")
                {
                    return "3.5%";
                }
                else if (qtEmployee.JobGradeName == "大区总监")
                {
                    return "4%";
                }
                {
                    throw new CrashException(string.Format("QT级别为总监的职级不对[{0}]", qtEmployee.JobGradeName));

                }
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


        //获取小主管的完成提成
        static public double GetQTSmallChargeProp()
        {
            return 0.06;
        }

        //获取大主管的完成提成
        static public double GetQtLargeChargeProp()
        {
            return 0.04;
        }


        static public double GetCommissionPropToProp(QtDepartment qtDepartment, QtEmployee qtEmployee)
        {
            bool isComplete = qtDepartment.AlreadyCompleteTaskAmount >= qtDepartment.NeedCompleteTaskAmount;
            if (qtDepartment.QtLevel == QtLevel.SmallCharge)
            {
                if (isComplete)
                {
                    return 0.06;
                }
                else
                {
                    return 0.03;
                }
            }
            else if (qtDepartment.QtLevel == QtLevel.LargeCharge)
            {
                if (isComplete)
                {
                    return 0.04;
                }
                else
                {
                    return 0.02;
                }
            }
            else if (qtDepartment.QtLevel == QtLevel.Majordomo)
            {
                if (qtEmployee.JobGradeName == "总监")
                {
                    return 0.03;
                }
                else if (qtEmployee.JobGradeName == "区域总监")
                {
                    return 0.035;
                }
                else if (qtEmployee.JobGradeName == "大区总监")
                {
                    return 0.04;
                }
                else
                {
                    throw new CrashException(string.Format("QT级别为总监的职级不对[{0}]", qtEmployee.JobGradeName));

                }
            }
            else if (qtDepartment.QtLevel == QtLevel.None)
            {
                if (qtDepartment.ParentDepartmentId != 0)
                {
                    throw new CrashException("QT结构的非根目录的QT属性为NONE");
                }
                //根目录
                return 0.02;
            }
            else
            {
                throw new CrashException("QT结构的QT属性异常");
            }
        }
    }
}
