using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Common;
namespace FXB.Data
{
    //部门数据
    class DepartmentData
    {
        public DepartmentData(UInt32 tmpId, string tmpName, UInt32 tmpSuperiorId, QtLevel tmpQtLevel)
        {
            if (tmpQtLevel == QtLevel.Salesman)
            {
                //部门不能设置成业务员级别
                throw new TextException("部门不能设置为业务员级别");
            }

            id = tmpId;
            name = tmpName;
            superiorId = tmpSuperiorId;
            qtLevel = tmpQtLevel;
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
        }

        public string OwnerJobNumber
        {
            get { return ownerJobNumber; }
            set { ownerJobNumber = value; }
        }

        public QtLevel QTLevel
        {
            get {return qtLevel;}
        }
    }
}
