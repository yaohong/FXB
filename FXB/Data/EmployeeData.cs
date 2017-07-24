using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    //员工数据
    class EmployeeData
    {
        //员工工号
        private string jobNumber;
        //员工姓名
        private string name;
        //所属部门(部门id)
        private string departmentId;
        //职级(职级id)
        private string jobGradeId;
        //电话
        private string phoneNumber;
        //在职状态
        private bool jobState;
        //入职时间
        private string entryTime;
        //离职时间
        private string dimissionTime;
        //身份证
        private string idCard;
        //生日
        private string birthday;
        //性别
        private bool sex;
        //名族籍贯
        private string ethnicAndOrigin;
        //居住地址
        private string residentialAddress;
        //学历
        private string education;
        //毕业学校
        private string schoolTag;
        //专业
        private string specialities;
        //紧急联系人
        private string emergencyContact;
        //紧急联系电话
        private string emergencyTelephoneNumber;
        //介绍人
        private string introducer;
        //备注
        private string comment;
        //QT级别
        private QtLevel qtLevel;


        public string JobNumber
        {
            get
            {
                return jobNumber;
            }

            set
            {
                jobNumber = value;
            }
        }

        public QtLevel QTLevel
        {
            get
            {
                return qtLevel;
            }

            set
            {
                qtLevel = value;
            }
        }
    }
}
