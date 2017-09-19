using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class TDData
    {
        private Int64 orderId;                  //和订单ID用同一个ID
        private bool isReturn;                  //是否退单
        private string returnJobnumber;         //退单人
        private UInt32 returnTime;              //退单时间

        public Int64 OrderId
        {
            get { return orderId; }
        }

        public bool IsReturn
        {
            get { return isReturn; }
            set { isReturn = value; }
        }

        public string ReturnJobnumber
        {
            get { return returnJobnumber; }
            set { returnJobnumber = value; }
        }

        public UInt32 ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }


        public TDData(Int64 tmpOrderId, bool tmpIsReturn, string tmpReturnJobnumber, UInt32 tmpReturnTime)
        {
            orderId = tmpOrderId;
            isReturn = tmpIsReturn;
            returnJobnumber = tmpReturnJobnumber;
            returnTime = tmpReturnTime;


        }
    }
}
