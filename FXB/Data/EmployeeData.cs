using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    //员工数据
    public class EmployeeData
    {
        public EmployeeData(string tmpJobNumber)
        {
            jobNumber = tmpJobNumber;
        }
        //员工工号
        private string jobNumber;
        public string JobNumber
        {
            get { return jobNumber; }
        }
        //员工姓名
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //所属部门(部门id)
        private Int64 departmentId;
        public Int64 DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
        //职级(职级id)
        private string jobGradeName;
        public string JobGradeName
        {
            get { return jobGradeName; }
            set { jobGradeName = value; }
        }
        //电话
        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        //在职状态
        private bool jobState;
        public bool JobState
        {
            get { return jobState; }
            set { jobState = value; }
        }
        //入职时间
        private UInt32 entryTime;
        public UInt32 EnteryTime
        {
            get { return entryTime; }
            set { entryTime = value; }
        }
        //离职时间
        private UInt32 dimissionTime;
        public UInt32 DimissionTime
        {
            get { return dimissionTime; }
            set { dimissionTime = value; }
        }
        //身份证
        private string idCard;
        public string IdCard
        {
            get { return idCard; }
            set { idCard = value; }
        }
        //生日
        private UInt32 birthday;
        public UInt32 Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        //性别 true男 flase女
        private bool sex;
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        //名族籍贯
        private string ethnicAndOrigin;
        public string EthnicAndOrigin
        {
            get { return ethnicAndOrigin; }
            set { ethnicAndOrigin = value; }
        }
        //居住地址
        private string residentialAddress;
        public string ResidentialAddress
        {
            get { return residentialAddress; }
            set { residentialAddress = value; }
        }
        //学历
        private string education;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }
        //毕业学校
        private string schoolTag;
        public string SchoolTag
        {
            get { return schoolTag; }
            set { schoolTag = value; }
        }
        //专业
        private string specialities;
        public string Specialities
        {
            get { return specialities; }
            set { specialities = value; }
        }
        //紧急联系人
        private string emergencyContact;
        public string EmergencyContact
        {
            get { return emergencyContact; }
            set { emergencyContact = value; }
        }
        //紧急联系电话
        private string emergencyTelephoneNumber;
        public string EmergencyTelephoneNumber
        {
            get { return emergencyTelephoneNumber; }
            set { emergencyTelephoneNumber = value; }
        }
        //介绍人
        private string introducer;
        public string Introducer
        {
            get { return introducer; }
            set { introducer = value; }
        }
        //备注
        private string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        //QT级别
        private QtLevel qtLevel;
        // 摘要:
        // QT级别
        public QtLevel QTLevel
        {
            get { return qtLevel; }
            set { qtLevel = value; }
        }







        ////////////////////////////////////////////////////////////////////////////////////////////
    }
}
