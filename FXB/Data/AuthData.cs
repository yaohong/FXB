using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class AuthData
    {
        private string jobNumber;
        private string password;
        private Int64 operMake;
        private bool prohibit;          //是否禁止登陆
        private bool ifOwner;           //是否是管理员
        private Int32 viewLevel;        //数据查看级别 0(查看自己),1(查看部门),2(查看全部)

        public string JobNumber
        {
            get { return jobNumber; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Prohibit
        {
            get { return prohibit; }
        }

        public bool IfOwner
        {
            get { return ifOwner; }
        }

        public Int32 ViewLevel
        {
            get { return viewLevel; }
        }
        public AuthData(string tmpJobnumber, string tmpPassword, Int64 tmpOperMake, bool tmpProhibit, bool tmpifOwner, Int32 tmpViewLevel)
        {
            jobNumber = tmpJobnumber;
            password = tmpPassword;
            operMake = tmpOperMake;
            prohibit = tmpProhibit;
            ifOwner = tmpifOwner;
            viewLevel = tmpViewLevel;
        }
    }
}
