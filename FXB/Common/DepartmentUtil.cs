﻿using System;
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

        public static string GetQtDepartmentSimShowText(QtTask qtTask, Int64 departmentId)
        {
            if (departmentId == 0)
            {
                return "";
            }
            else
            {

                string departmentName = "";
                while (true)
                {
                    QtDepartment departmentData = qtTask.AllQtDepartment[departmentId];
                    if (departmentData.ParentDepartmentId == 0)
                    {
                        //跟部门了
                        if (departmentName == "")
                        {
                            return departmentData.DepartmentName;
                        }
                        else
                        {
                            //return string.Format("{0}|{1}", departmentData.DepartmentName, departmentName);
                            return string.Format("{0}", departmentName);
                        }

                    }
                    else
                    {
                        if (departmentName == "")
                        {
                            departmentName = departmentData.DepartmentName;
                        }
                        else
                        {
                            departmentName = string.Format("{0}|{1}", departmentData.DepartmentName, departmentName);
                        }

                        departmentId = departmentData.ParentDepartmentId;
                    }
                }
            }

        }
        public static string GetQtDepartmentShowText(QtTask qtTask, Int64 departmentId)
        {
            if (departmentId == 0)
            {
                return "";
            }
            else
            {
                
                string departmentName = "";
                while (true)
                {
                    QtDepartment departmentData = qtTask.AllQtDepartment[departmentId];
                    if (departmentData.ParentDepartmentId == 0)
                    {
                        //跟部门了
                        if (departmentName == "")
                        {
                            return departmentData.DepartmentName;
                        }
                        else
                        {
                            return string.Format("{0}|{1}", departmentData.DepartmentName, departmentName);
                        }

                    }
                    else
                    {
                        if (departmentName == "")
                        {
                            departmentName = departmentData.DepartmentName;
                        }
                        else
                        {
                            departmentName = string.Format("{0}|{1}", departmentData.DepartmentName, departmentName);
                        }

                        departmentId = departmentData.ParentDepartmentId;
                    }
                }



            }

        }

        //检测加入关系
        public static bool CheckAddInDepartment(string gongHao, QtLevel roleQtLevel, Int64 addIndepartmentId, bool isOwner)
        {
            if (addIndepartmentId == 0)
            {
                //没有选择部门
                return true;
            }

            DepartmentData ownerDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[addIndepartmentId];
            if (ownerDepartmentData.Layer == 0)
            {
                if (!isOwner)
                {
                    //不是管理员
                    return false;
                }

                //选择的是根目录房小白,QT级别必须是【没有QT级别】
                if (roleQtLevel != QtLevel.None)
                {
                    return false;
                }

                //已经有管理员了
                if (ownerDepartmentData.OwnerJobNumber != "" &&
                    ownerDepartmentData.OwnerJobNumber != gongHao)
                {
                    return false;
                }


                return true;
            }

            //选择的QT部门
            if (ownerDepartmentData.QTLevel != QtLevel.None)
            {
                //员工没有QT级别
                if (roleQtLevel == QtLevel.None)
                {
                    return false;
                }

                if (roleQtLevel == ownerDepartmentData.QTLevel)
                {
                    //非节点部门不能是普通员工
                    if (!isOwner)
                    {
                        return false;
                    }

                    //设置部门主管
                    if (ownerDepartmentData.OwnerJobNumber != "" &&
                        ownerDepartmentData.OwnerJobNumber != gongHao)
                    {
                        //已经有管理员了
                        return false;
                    }

                    return true;
                }
                else
                {
                    //只能是非管理员
                    if (isOwner)
                    {
                        return false;
                    }

                    if (ownerDepartmentData.QTLevel == QtLevel.SmallCharge &&
                        roleQtLevel == QtLevel.Salesman)
                    {
                        //给小主管添加业务员
                        return true;
                    }

                    if (ownerDepartmentData.QTLevel == QtLevel.ZhuchangZhuguan && 
                        roleQtLevel == QtLevel.ZhuchangZhuanyuan)
                    {
                        //给驻场主管添加驻场专员
                        return true;
                    }

                    return false;
                }
            }



            //非QT部门
            if (roleQtLevel != QtLevel.None)
            {
                return false;
            }

            if (isOwner)
            {
                //设置成管理员
                if (ownerDepartmentData.OwnerJobNumber != "" &&
                    ownerDepartmentData.OwnerJobNumber != gongHao)
                {
                    //有管理员了
                    return false;
                }

                return true;
            }
            else
            {
                if (ownerDepartmentData.ChildSet.Count > 0)
                {
                    //部门有子部门了
                    return false;
                }

                return true;
            }
        }

        public static bool FindEmployeeByDepartment(Int64 departmentId, string gonghao)
        {
            DepartmentData data = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];
            if (data.EmployeeSet.Contains(gonghao))
            {
                return true;
            }

            if (data.OwnerJobNumber == gonghao)
            {
                return true;
            }

            //查看子节点
            foreach (var item in data.ChildSet)
            {
                if (FindEmployeeByDepartment(item, gonghao))
                {
                    return true;
                }
            }

            return false;
        }
    }



}
