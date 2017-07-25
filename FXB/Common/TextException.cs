using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Common
{
    class TextException : Exception
    {
        public TextException(string msg) : base(msg) 
        {

        }
    }
}
