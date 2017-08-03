using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Common
{
    public class TimeUtil
    {
        public static DateTime TimestampToDatetTime(UInt32 time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            DateTime dt = startTime.AddSeconds(time);
            return dt;
        }

        public static UInt32 DatetTimeToTimestamp(DateTime dateTime)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            long timeStamp = (long)(dateTime - startTime).TotalSeconds;
            return (UInt32)timeStamp;
        }
    }
}
