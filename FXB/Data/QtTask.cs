using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.DataManager;
using FXB.Common;
namespace FXB.Data
{

    //QT任务
    //用年-月-日 的字符串做为key
    public class QtTask
    {
        private string qtKey;               //任务key
        private bool closing;               //QT任务是否结算(点击生成QT提成)
        private QtDepartment rootQtDepartment = null;
        private SortedDictionary<Int64, QtDepartment> allQtDepartment;
        private SortedDictionary<string, QtEmployee> allQtEmployee;
        private SortedDictionary<Int64, QtOrder> allQtOrder;
        public static float singleTaskAmount = 10000.0f;

        public string QtKey
        {
            get { return qtKey; }
        }
        public bool Closing
        {
            get { return closing; }
            set { closing = true; }
        }

        public QtDepartment RootQtDepartment
        {
            get { return rootQtDepartment; }
        }

        public SortedDictionary<Int64, QtDepartment> AllQtDepartment
        {
            get { return allQtDepartment; }
        }

        public SortedDictionary<string, QtEmployee> AllQtEmployee
        {
            get { return allQtEmployee; }
        }

        public SortedDictionary<Int64, QtOrder> AllQtOrder
        {
            get { return allQtOrder; }
        }
        //生成新QT任务的构造函数
        public QtTask(string timeKey)
        {
            qtKey = timeKey;
            closing = false;
            rootQtDepartment = null;

            allQtDepartment = new SortedDictionary<Int64, QtDepartment>();
            allQtEmployee = new SortedDictionary<string, QtEmployee>();
            allQtOrder = new SortedDictionary<Int64, QtOrder>();
            //用当前的部门结构构造QT部门结构
            DepartmentData rootDepartment = DepartmentDataMgr.Instance().RootDepartment;
            rootQtDepartment = rootDepartment.GenerateQtDepartment();
            allQtDepartment[rootDepartment.Id] = rootQtDepartment;

            AddEmployee(rootDepartment);

            foreach (var item in rootDepartment.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel == QtLevel.Majordomo || childDepartmentData.QTLevel == QtLevel.ZhuchangZongjian)
                {
                    //只有QT部门才生成QT任务
                    QtDepartment childQtDepartment = childDepartmentData.GenerateQtDepartment();
                    GenerateQtDepartmentRelation(childQtDepartment);
                    if (!rootQtDepartment.ChildDepartmentIdSet.Add(childDepartmentData.Id))
                    {
                        throw new CrashException("生成QT任务失败1");
                    }
                    allQtDepartment[childDepartmentData.Id] = childQtDepartment;
                }
            }

            rootQtDepartment.CalcTaskAmount(this);
        }

        private void GenerateQtDepartmentRelation(QtDepartment partentQtDepartment)
        {
            //设置子节点
            DepartmentData departmentData = DepartmentDataMgr.Instance().AllDepartmentData[partentQtDepartment.Id];
            AddEmployee(departmentData);
            //遍历子部门
            foreach (var item in departmentData.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel != QtLevel.SmallCharge && 
                    childDepartmentData.QTLevel != QtLevel.LargeCharge &&
                    childDepartmentData.QTLevel != QtLevel.ZhuchangZhuguan)
                {
                    throw new CrashException("部门QT属性错误，生成QT任务失败");
                }

                QtDepartment childQtDepartment = childDepartmentData.GenerateQtDepartment();
                if (!partentQtDepartment.ChildDepartmentIdSet.Add(childQtDepartment.Id))
                {
                    throw new CrashException("生成QT任务失败2");
                }
                allQtDepartment[childDepartmentData.Id] = childQtDepartment;
                GenerateQtDepartmentRelation(childQtDepartment);


            }
        }

        private void AddEmployee(DepartmentData departmentData)
        {
            //添加管理员
            if (departmentData.OwnerJobNumber != "")
            {
                EmployeeData ownerEmployeeData = EmployeeDataMgr.Instance().AllEmployeeData[departmentData.OwnerJobNumber];
                allQtEmployee[departmentData.OwnerJobNumber] = ownerEmployeeData.GenerateQtEmployee();
            }

            //添加员工
            foreach (var employeeJobNumber in departmentData.EmployeeSet)
            {
                EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[employeeJobNumber];
                allQtEmployee[employeeJobNumber] = employeeData.GenerateQtEmployee();
            }
        }

        //由DB数据构建QT任务
        public QtTask(
            DbQtTaskIndex qtIndexData, 
            SortedDictionary<Int64, QtDepartment> qtDepartmentData,
            SortedDictionary<string, QtEmployee> qtEmployeeData,
            SortedDictionary<Int64, QtOrder> qtOrderData)
        {
            qtKey = qtIndexData.QtKey;
            closing = qtIndexData.Closing;
            rootQtDepartment = null;
            allQtDepartment = qtDepartmentData;
            allQtEmployee = qtEmployeeData;  
            allQtOrder = qtOrderData;

            ////建立部门的上级关系
            //foreach (var item in allQtDepartment)
            //{
            //    GenerateQtDepartmentSuperiorRelation(item.Value);
            //}

            //建立部门的下级关系
            foreach (var item in allQtDepartment)
            {
                GenerateQtDepartmentLowerRelation(item.Value);
            }

            rootQtDepartment = allQtDepartment[qtIndexData.RootqtDepartmentId];
        }

        private void GenerateQtDepartmentLowerRelation(QtDepartment qtDepartment)
        {
            if (qtDepartment.ParentDepartmentId != 0)
            {
                QtDepartment parentQtDepartment = allQtDepartment[qtDepartment.ParentDepartmentId];
                parentQtDepartment.ChildDepartmentIdSet.Add(qtDepartment.Id);
            }
        }


        public void CalcQtCommission()
        {
            //计算QT提成
            if (closing)
            {
                throw new ConditionCheckException("QT提成已经生成");
            }
            closing = true;
            //先清零
            foreach (var kv in allQtDepartment)
            {
                kv.Value.AlreadyCompleteTaskAmount = 0.0f;
            }

            foreach (var item in allQtOrder)
            {
                QtOrder qtOrder = item.Value;
                if (!qtOrder.CheckState)
                {
                    //没有审核的订单不参与计算
                    continue;
                }

                //if (qtOrder.IfChargeback)
                //{
                //    //已经退单了
                //    continue;
                //}

                Int64 departmentId = qtOrder.YxQtDepartmentId;
                double yxCommission = qtOrder.CommissionAmount;
                if (qtOrder.KyfConsultanJobNumber != "")
                {
                    //有客源方
                    yxCommission = qtOrder.CommissionAmount * 0.9;
                    double kyfCommission = qtOrder.CommissionAmount * 0.1;
                    //给客源方加业绩
                    Int64 kyfDepartmentId = qtOrder.KyfQtDepartmentId;
                    while (kyfDepartmentId != 0)
                    {
                        QtDepartment kyfQtDepartment = allQtDepartment[kyfDepartmentId];
                        //if (kyfQtDepartment.OwnerJobNumber != "")
                        //{
                            kyfQtDepartment.AlreadyCompleteTaskAmount += kyfCommission;
                        //}
                        kyfDepartmentId = kyfQtDepartment.ParentDepartmentId;
                    }
                }

                //给自身添加业绩
                while (departmentId != 0)
                {
                    QtDepartment qtDepartment = allQtDepartment[departmentId];
                    //if (qtDepartment.OwnerJobNumber != "")
                    //{
                    qtDepartment.AlreadyCompleteTaskAmount += yxCommission;
                    //}
                    departmentId = qtDepartment.ParentDepartmentId;
                }

            }
        }

        
        public void ClearQtCommission()
        {
            //重置QT提成
            if (!closing)
            {
                return;
            }

            closing = false;
            //需要检测是否有回佣
            foreach (var kv in allQtDepartment)
            {
                kv.Value.AlreadyCompleteTaskAmount = 0.0f;
            }
        }

    }
}
