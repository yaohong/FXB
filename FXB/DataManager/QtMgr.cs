using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.DataManager
{
    class QtMgr
    {
        private static QtMgr ins;

        private QtMgr()
        {

        }

        public static QtMgr Instance()
        {
            if (ins == null)
            {
                ins = new QtMgr();
            }

            return ins;
        }


    }
}
