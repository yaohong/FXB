using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{

    class QtEmployee
    {
        private string jobNumber;
        private Int64 departmentId;
        private QtLevel qtLevel;
        private bool isOwner;

        public QtEmployee(string tmpJobNumber, Int64 tmpDepartmentId, QtLevel tmpQtLevel, bool tmpIsOwner)
        {
            jobNumber = tmpJobNumber;
            departmentId = tmpDepartmentId;
            qtLevel = tmpQtLevel;
            isOwner = tmpIsOwner;
        }


        public string JobNumber
        {
            get { return jobNumber; }
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
