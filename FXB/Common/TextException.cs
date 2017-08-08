using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Common
{
    class CrashException : Exception
    {
        public CrashException(string msg) : base(msg) 
        {

        }
    }


    class ConditionCheckException : Exception
    {
        public ConditionCheckException(string msg)
            : base(msg) 
        {

        }
    }
}
