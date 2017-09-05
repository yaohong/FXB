using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Common
{
    public class DoubleUtil
    {
        public static bool Check(string doubleStr)
        {
            try
            {
                Convert.ToDouble(doubleStr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Equal(double l, double r)
        {
            if (Math.Abs(l - r) < 0.001f)
            {
                return true;
            }

            return false;
        }
    }


    

}
