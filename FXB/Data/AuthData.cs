using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    class AuthData
    {
        private string jobNumber;
        private string password;
        private Int64 operMake;
        private bool prohibit;
        private bool ifOwner;

        public string JobNumber
        {
            get { return jobNumber; }
        }

        public string Password
        {
            get { return password; }
        }

        public bool Prohibit
        {
            get { return prohibit; }
        }

        public bool IfOwner
        {
            get { return ifOwner; }
        }
        public AuthData(string tmpJobnumber, string tmpPassword, Int64 tmpOperMake, bool tmpProhibit, bool tmpifOwner)
        {
            jobNumber = tmpJobnumber;
            password = tmpPassword;
            operMake = tmpOperMake;
            prohibit = tmpProhibit;
            ifOwner = tmpifOwner;
        }
    }
}
