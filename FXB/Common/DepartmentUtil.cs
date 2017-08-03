using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.DataManager;
using FXB.Data;
namespace FXB.Common
{
    class DepartmentUtil
    {
        public static string GetDepartmentShowText(Int64 departmentId)
        {
            if (departmentId == 0)
            {
                return "";
            }
            else
            {
                string departmentName = "";
                while (true) {
                    DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
                    if (departmentData.SuperiorId == 0)
                    {
                        //跟部门了
                        if (departmentName == "")
                        {
                            return departmentData.Name;
                        } 
                        else 
                        {
                            return string.Format("{0}|{1}", departmentData.Name, departmentName);
                        }
                        
                    }
                    else
                    {
                        if (departmentName == "")
                        {
                            departmentName = departmentData.Name;
                        }
                        else
                        {
                            departmentName = string.Format("{0}|{1}", departmentData.Name, departmentName);
                        }
                        
                        departmentId = departmentData.SuperiorId;
                    }
                }



            }
            
        }
    }
}
