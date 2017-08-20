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
        private QtDepartment parentDepartment;
        private SortedSet<QtDepartment> childDepartmentSet;      //所有的子部门
        private float needCompleteTaskAmount;               //需要完成的任务金额
//        private bool isCalcTaskAmount;                      //是否计算任务金额

        //不存DB的数据(动态算出来的)
        private float alreadyCompleteTaskAmount;            //已经完成的任务金额
        public QtDepartment(Int64 tmpDeparmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, QtDepartment tmpParentDepartment)
        {
            deparmentId = tmpDeparmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            parentDepartment = tmpParentDepartment;
            childDepartmentSet = new SortedSet<QtDepartment>();
            needCompleteTaskAmount = 0.0f;

            alreadyCompleteTaskAmount = 0.0f;
        }

        public SortedSet<QtDepartment> ChildDepartmentSet
        {
            get { return childDepartmentSet; }
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

        public QtDepartment ParentDepartment
        {
            get { return parentDepartment; }
        }


        public float CalcTaskAmount()
        {
            //if (isCalcTaskAmount)
            //{
            //    throw new CrashException("重复计算部门任务");
            //}
            //isCalcTaskAmount = true;
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
            foreach (var child in childDepartmentSet)
            {
                tmpNeedCompleteTaskAmount += child.CalcTaskAmount();
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
        private QtDepartment rootQtDepartment;
        private SortedDictionary<Int64, QtDepartment> allQtDepartment;
        public static float singleTaskAmount = 10000.0f;
        public QtTask(string timeKey)
        {
            qtKey = timeKey;
            closing = false;
            rootQtDepartment = null;

            allQtDepartment = new SortedDictionary<Int64, QtDepartment>();
        }

        public bool Closing
        {
            get { return closing; }
        }

        public SortedDictionary<Int64, QtDepartment> AllQtDepartment
        {
            get { return allQtDepartment; }
        }

        public void GenerateNewQtTask()
        {
            rootQtDepartment = null;
            allQtDepartment.Clear();

            DepartmentData rootDepartment = DepartmentDataMgr.Instance().RootDepartment;
            rootQtDepartment = new QtDepartment(rootDepartment.Id, rootDepartment.QTLevel, rootDepartment.OwnerJobNumber, null);
            allQtDepartment[rootDepartment.Id] = rootQtDepartment;
            foreach (var item in rootDepartment.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel == QtLevel.Majordomo)
                {
                    //只有QT部门才生成QT任务
                    QtDepartment qtDepartment = new QtDepartment(childDepartmentData.Id, childDepartmentData.QTLevel, childDepartmentData.OwnerJobNumber, rootQtDepartment);
                    GenerateQtDepartmentRelation(qtDepartment);
                    if (!rootQtDepartment.ChildDepartmentSet.Add(qtDepartment))
                    {
                        throw new CrashException("生成QT任务失败1");
                    }
                    allQtDepartment[childDepartmentData.Id] = qtDepartment;
                }
            }

            rootQtDepartment.CalcTaskAmount();
        }



        private void GenerateQtDepartmentRelation(QtDepartment qtDepartment)
        {
            //设置子节点
            DepartmentData data = DepartmentDataMgr.Instance().AllDepartmentData[qtDepartment.Id];

            //遍历子部门
            foreach (var item in data.ChildSet)
            {
                DepartmentData childDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[item];
                if (childDepartmentData.QTLevel != QtLevel.SmallCharge && childDepartmentData.QTLevel != QtLevel.LargeCharge)
                {
                    throw new CrashException("部门QT属性错误，生成QT任务失败");
                }

                QtDepartment childQtDepartment = new QtDepartment(childDepartmentData.Id, childDepartmentData.QTLevel, childDepartmentData.OwnerJobNumber, qtDepartment);
                if (!qtDepartment.ChildDepartmentSet.Add(childQtDepartment))
                {
                    throw new CrashException("生成QT任务失败2");
                }
                allQtDepartment[childDepartmentData.Id] = childQtDepartment;
                GenerateQtDepartmentRelation(childQtDepartment);


            }
        }

    }
}
