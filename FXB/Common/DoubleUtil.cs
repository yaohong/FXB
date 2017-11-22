using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Common
{
    public class DoubleUtil
    {
        const double DBL_EPSILON  = 2.2204460492503131e-016;
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
            double v = Math.Abs(l - r);
            if (v < DoubleUtil.DBL_EPSILON)
            {
                return true;
            }

            return false;
        }


        public static string Show(double v)
        {
            return v.ToString("0.00");
        }
    }


    

}
