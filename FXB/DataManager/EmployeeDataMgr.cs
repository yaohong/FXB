using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FXB.Data;
using FXB.Common;
namespace FXB.DataManager
{
    
    class EmployeeDataMgr
    {
        private static EmployeeDataMgr ins;
        private Dictionary<string, EmployeeData> allEmployeeData;
        private EmployeeDataMgr()
        {
            allEmployeeData = new Dictionary<string, EmployeeData>();
        }

        public static EmployeeDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new EmployeeDataMgr();
            }

            return ins;
        }

        //重新load数据
        public void Load()
        {
            allEmployeeData.Clear();
            //重新从数据库里加载
        }

        Dictionary<string, EmployeeData> AllEmployeeData
        {
            get
            {
                return allEmployeeData;
            }
        }
        public void AddEmployeeDataToCache(
            string jobNumber,
            string name,
            Int64 departmentId,
            string jobGradeName,
            QtLevel qtLevel,
            string phoneNumber,
            bool jobState,
            UInt32 entryTime,
            UInt32 dimissionTime,
            string idCard,
            UInt32 birthday,
            bool sex,
            string ethnicAndOrigin,
            string residentialAddress,
            string education,
            string schoolTag,
            string specialities,
            string emergencyContact,
            string emergencyTelephoneNumber,
            string introducer,
            string comment
            )
        {
            if (allEmployeeData.ContainsKey(jobNumber))
            {
                throw new TextException(string.Format("工号重复:{0}", jobNumber));
            }
            //检测部门关系
            if (!CheckDepartmentRelation(qtLevel, departmentId))
            {
                throw new TextException("员工QT级别和部门QT级别对应不上");
            }

            //添加到缓存
            EmployeeData newEmployeeData = new EmployeeData(jobNumber);
            newEmployeeData.Name = name;
            newEmployeeData.DepartmentId = departmentId;
            newEmployeeData.JobGradeName = jobGradeName;
            newEmployeeData.PhoneNumber = phoneNumber;
            newEmployeeData.JobState = jobState;
            newEmployeeData.EnteryTime = entryTime;
            newEmployeeData.DimissionTime = dimissionTime;
            newEmployeeData.IdCard = idCard;
            newEmployeeData.Birthday = birthday;
            newEmployeeData.Sex = sex;
            newEmployeeData.EthnicAndOrigin = ethnicAndOrigin;
            newEmployeeData.ResidentialAddress = residentialAddress;
            newEmployeeData.Education = education;
            newEmployeeData.SchoolTag = schoolTag;
            newEmployeeData.Specialities = specialities;
            newEmployeeData.EmergencyContact = emergencyContact;
            newEmployeeData.EmergencyTelephoneNumber = emergencyTelephoneNumber;
            newEmployeeData.Introducer = introducer;
            newEmployeeData.Comment = comment;
            newEmployeeData.QTLevel = qtLevel;
            allEmployeeData.Add(jobNumber, newEmployeeData);
        }


        bool CheckDepartmentRelation(QtLevel roleQtLeve, Int64 departmentId)
        {
            if (departmentId == 0)
            {
                //没有加入部门
                return true;
            }

            DepartmentData ownerDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[departmentId];

            return false;
        }
    }
}
