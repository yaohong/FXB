using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
using FXB.DataManager;
namespace FXB.Data
{
    //描述QT部门
    public class QtDepartment
    {
        private Int64 deparmentId;
        private QtLevel qtLevel;
        private string ownerJobNumber;
        private string deparmentName;
        private Int64 parentDepartmentId;
        private SortedSet<Int64> childDepartmentIdSet;      //所有的子部门
        private double needCompleteTaskAmount;              //需要完成的任务金额



        //不存DB的数据
        private bool isCalcTaskAmount;                        //是否计算任务金额
        private float alreadyCompleteTaskAmount;            //已经完成的任务金额
        public QtDepartment(Int64 tmpDeparmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, string tmpDeparmentName,Int64 tmpParentDepartmentId)
        {
            deparmentId = tmpDeparmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            deparmentName = tmpDeparmentName;
            parentDepartmentId = tmpParentDepartmentId;

            childDepartmentIdSet = new SortedSet<Int64>();
            needCompleteTaskAmount = 0.0f;

            isCalcTaskAmount = false;
            alreadyCompleteTaskAmount = 0.0f;
        }

        public QtDepartment(Int64 tmpDeparmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, string tmpDeparmentName, Int64 tmpParentDepartmentId, double tmpNeedCompleteTaskAmount)
        {
            deparmentId = tmpDeparmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            deparmentName = tmpDeparmentName;

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

        public string DepartmentName
        {
            get { return deparmentName; }
        }

        public Int64 ParentDepartmentId
        {
            get { return parentDepartmentId; }
        }

        public double NeedCompleteTaskAmount
        {
            get { return needCompleteTaskAmount; }
        }

        public double AlreadyCompleteTaskAmount
        {
            get { return alreadyCompleteTaskAmount; }
            set { alreadyCompleteTaskAmount = value; }
        }
        public float CalcTaskAmount(QtTask qtTask)
        {
            if (isCalcTaskAmount)
            {
                throw new CrashException("重复计算部门任务");
            }
            isCalcTaskAmount = true;

            
            if (qtLevel == QtLevel.ZhuchangZongjian || 
                qtLevel == QtLevel.ZhuchangZhuguan)
            {
                //驻场没有金额要求 为0
                return 0.0f;
            }

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
}
