using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{

    public class QtEmployee
    {
        private string jobNumber;
        private string jobGradeName;            //职级(算订单的奖励)
        private Int64 departmentId;
        private QtLevel qtLevel;
        private bool isOwner;

        public QtEmployee(string tmpJobNumber, string tmpJobGradeName, Int64 tmpDepartmentId, QtLevel tmpQtLevel, bool tmpIsOwner)
        {
            jobNumber = tmpJobNumber;
            jobGradeName = tmpJobGradeName;
            departmentId = tmpDepartmentId;
            qtLevel = tmpQtLevel;
            isOwner = tmpIsOwner;
        }


        public string JobNumber
        {
            get { return jobNumber; }
        }

        public string JobGradeName
        {
            get { return jobGradeName; }
        }

        public Int64 DepartmentId
        {
            get { return departmentId; }
        }

        public QtLevel QtLevel
        {
            get { return qtLevel; }
        }

        public bool IsOwner
        {
            get { return isOwner; }
        }

    }
}
