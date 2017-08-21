using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.DataManager;
using FXB.Common;
namespace FXB.Data
{
    
    //描述QT部门
    public class QtDepartment
    {
        private Int64 deparmentId;
        private QtLevel qtLevel;
        private string ownerJobNumber;
        private Int64 parentDepartmentId;
        private SortedSet<Int64> childDepartmentIdSet;      //所有的子部门
        private float needCompleteTaskAmount;                   //需要完成的任务金额



        //不存DB的数据
        private bool isCalcTaskAmount;                        //是否计算任务金额
        private float alreadyCompleteTaskAmount;            //已经完成的任务金额
        public QtDepartment(Int64 tmpDeparmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, Int64 tmpParentDepartmentId)
        {
            deparmentId = tmpDeparmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            parentDepartmentId = tmpParentDepartmentId;
            childDepartmentIdSet = new SortedSet<Int64>();
            needCompleteTaskAmount = 0.0f;

            isCalcTaskAmount = false;
            alreadyCompleteTaskAmount = 0.0f;
        }

        public QtDepartment(Int64 tmpDeparmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, Int64 tmpParentDepartmentId, float tmpNeedCompleteTaskAmount)
        {
            deparmentId = tmpDeparmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            parentDepartmentId = tmpParentDepartmentId;
            childDepartmentIdSet = new SortedSet<Int64>();
            needCompleteTaskAmount = tmpNeedCompleteTaskAmount;

            isCalcTaskAmount = true;
            alreadyCompleteTaskAmount = 0.0f;
        }

        public SortedSet<Int64> ChildDepartmentIdSet
        {
            get { return childDepartmentIdSet; }
        }

        public Int64 Id
        {
            get { return deparmentId; }
        }

        public QtLevel QtLevel
        {
            get { return qtLevel; }
        }

        public string OwnerJobNumber
        {
            get { return ownerJobNumber; }
        }

        public Int64 ParentDepartmentId
        {
            get { return parentDepartmentId; }
        }

        public float NeedCompleteTaskAmount
        {
            get { return needCompleteTaskAmount; }
        }

        public float CalcTaskAmount(QtTask qtTask)
        {
            if (isCalcTaskAmount)
            {
                throw new CrashException("重复计算部门任务");
            }
            isCalcTaskAmount = true;
            float tmpNeedCompleteTaskAmount = 0.0f;
            if (ownerJobNumber != "")
            {
                //有管理员
                tmpNeedCompleteTaskAmount += QtTask.singleTaskAmount;
            }

            //看员工
            DepartmentData data = DepartmentDataMgr.Instance().AllDepartmentData[deparmentId];
            if (qtLevel == QtLevel.SmallCharge)
            {
                //QT小主管级别,计算员工的
                tmpNeedCompleteTaskAmount += (QtTask.singleTaskAmount * data.EmployeeSet.Count);
            }
            else
            {
                if (data.EmployeeSet.Count > 0)
                {
                    throw new CrashException("非小主管部门不能有业务员");
                }
            }

            //累计子部门的
            foreach (var child in childDepartmentIdSet)
            {
                QtDepartment childQtDepartment = qtTask.AllQtDepartment[child];
                tmpNeedCompleteTaskAmount += childQtDepartment.CalcTaskAmount(qtTask);
            }

            needCompleteTaskAmount = tmpNeedCompleteTaskAmount;

            return tmpNeedCompleteTaskAmount;
        }
    }

    //QT任务
    //用年-月-日 的字符串做为key
    public class QtTask
    {
        private string qtKey;               //任务key
        private bool closing;               //QT任务是否结算(点击生成QT提成)
        private QtDepartment rootQtDepartment = null;
        private SortedDictionary<Int64, QtDepartment> allQtDepartment;

        public static float singleTaskAmount = 10000.0f;

        public string QtKey
        {
            get { return qtKey; }
        }
        public bool Closing
        {
            get { return closing; }
        }

        public QtDepartment RootQtDepartment
        {
            get { return rootQtDepartment; }
        }

        public SortedDictionary<Int64, QtDepartment> AllQtDepartment
        {
            get { return allQtDepartment; }
        }
        //生成新QT任务的构造函数
        public QtTask(string timeKey)
        {
            qtKey = timeKey;
            closing = false;
            rootQtDepartment = null;

            allQtDepartment = new SortedDictionary<Int64, QtDepartment>();

            //用当前的部门结构构造QT部门结构
            DepartmentData rootDepartment = DepartmentDataMgr.Instance().RootDepartment;
            rootQtDepartment = new QtDepartment(rootDepartment.Id, rootDepartment.QTLevel, rootDepartment.OwnerJobNumber, 0);
            allQtDepartment[rootDepartment.Id] = rootQtDepartment;
            foreach (var item in rootDepartment.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel == QtLevel.Majordomo)
                {
                    //只有QT部门才生成QT任务
                    QtDepartment childQtDepartment = new QtDepartment(childDepartmentData.Id, childDepartmentData.QTLevel, childDepartmentData.OwnerJobNumber, rootDepartment.Id);
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

            //遍历子部门
            foreach (var item in departmentData.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel != QtLevel.SmallCharge && childDepartmentData.QTLevel != QtLevel.LargeCharge)
                {
                    throw new CrashException("部门QT属性错误，生成QT任务失败");
                }

                QtDepartment childQtDepartment = new QtDepartment(childDepartmentData.Id, childDepartmentData.QTLevel, childDepartmentData.OwnerJobNumber, partentQtDepartment.Id);
                if (!partentQtDepartment.ChildDepartmentIdSet.Add(childQtDepartment.Id))
                {
                    throw new CrashException("生成QT任务失败2");
                }
                allQtDepartment[childDepartmentData.Id] = childQtDepartment;
                GenerateQtDepartmentRelation(childQtDepartment);


            }
        }

        //由DB数据构建QT任务
        public QtTask(DbQtTaskIndex qtIndexData, SortedDictionary<Int64, DbQtTaskDepartment> qtDepartmentData )
        {
            qtKey = qtIndexData.QtKey;
            closing = qtIndexData.Closing;
            rootQtDepartment = null;
            allQtDepartment = new SortedDictionary<Int64, QtDepartment>();

            //建立部门的上级关系
            foreach (var item in qtDepartmentData)
            {
                GenerateQtDepartmentSuperiorRelation(qtDepartmentData, item.Value);
            }

            //建立部门的下级关系
            foreach (var item in allQtDepartment)
            {
                GenerateQtDepartmentLowerRelation(item.Value);
            }

            rootQtDepartment = allQtDepartment[qtIndexData.RootqtDepartmentId];
        }



        private QtDepartment GenerateQtDepartmentSuperiorRelation(SortedDictionary<Int64, DbQtTaskDepartment> allDbQtDepartment, DbQtTaskDepartment qtDbDepartmentData)
        {
            if (allQtDepartment.ContainsKey(qtDbDepartmentData.QtDepartmentId))
            {
                //已经有了
                return allQtDepartment[qtDbDepartmentData.QtDepartmentId];
            }

            QtDepartment parentQtDepartment = null;
            if (qtDbDepartmentData.ParentDepartmentId != 0)
            {
                parentQtDepartment = GenerateQtDepartmentSuperiorRelation(allDbQtDepartment, allDbQtDepartment[qtDbDepartmentData.ParentDepartmentId]);
            }

            QtDepartment qtDepartment = new QtDepartment(
                qtDbDepartmentData.QtDepartmentId,
                qtDbDepartmentData.QtLevel,
                qtDbDepartmentData.OwnerJobNumber, 
                parentQtDepartment.Id,
                qtDbDepartmentData.NeedCompleteTaskAmount);
            allQtDepartment[qtDbDepartmentData.QtDepartmentId] = qtDepartment;
            return qtDepartment;
        }

        private void GenerateQtDepartmentLowerRelation(QtDepartment qtDepartment)
        {
            if (qtDepartment.ParentDepartmentId != 0)
            {
                QtDepartment parentQtDepartment = allQtDepartment[qtDepartment.ParentDepartmentId];
                parentQtDepartment.ChildDepartmentIdSet.Add(qtDepartment.Id);
            }
        }




    }
}
