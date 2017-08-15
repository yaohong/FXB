using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
namespace FXB.Data
{
    //部门数据
    public class DepartmentData : BasicDataInterface
    {
        public DepartmentData(Int64 tmpId, string tmpName, Int64 tmpSuperiorId, QtLevel tmpQtLevel)
        {
            if (tmpQtLevel == QtLevel.Salesman)
            {
                //部门不能设置成业务员级别
                throw new CrashException("部门不能设置为业务员级别");
            }

            id = tmpId;
            name = tmpName;
            superiorId = tmpSuperiorId;
            qtLevel = tmpQtLevel;

            childSet = new SortedSet<Int64>();
            employeeSet = new SortedSet<string>();
            layer = -1;
        }
        //部门ID
        private Int64 id;
        //上级部门id
        private Int64 superiorId;
        //部门名称
        private string name;
        //部门主管工号
        private string ownerJobNumber;
        //是否是根部门
        //部门的QT级别
        private QtLevel qtLevel;

        private SortedSet<Int64> childSet;
        private SortedSet<string> employeeSet; 

        Int32 layer;
        public Int64 Id
        {
            get { return id; }
        }

        public Int64 SuperiorId
        {
            get { return superiorId; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string OwnerJobNumber
        {
            get { return ownerJobNumber; }
            set 
            { 
                if (ownerJobNumber != "")
                {
                    throw new CrashException("重复设置部门主管");
                }

                ownerJobNumber = value; 
            }
        }

        public QtLevel QTLevel
        {
            get {return qtLevel;}
        }

        public SortedSet<Int64> ChildSet
        {
            get { return childSet; }
        }

        public SortedSet<string> EmployeeSet
        {
            get { return employeeSet; }
        }

        public Int32 Layer
        {
            get { return layer; }
            set
            {
                if (layer != -1)
                {
                    throw new CrashException("层级只能设置一次");
                }

                if (value < 0 || value > 3)
                {
                    //部门关系只能有四层
                    throw new CrashException("错误的层级值");
                }
               
                layer = value;
            }
        }

        public bool IsMaxLayer()
        {
            return layer == 3;
        }

        public void AddEmployee(string jobNumber)
        {

        }
    }
}
