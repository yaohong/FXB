using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class PayData
    {
        private string qtKey;
        private string jobNumber;
        private double curPay;
        private UInt32 generateTime;

        public PayData(string tmpQtKey, string tmpJobNumber, double tmpCurPay, UInt32 tmpGenerateTime)
        {
            qtKey = tmpQtKey;
            jobNumber = tmpJobNumber;
            curPay = tmpCurPay;
            generateTime = tmpGenerateTime;
        }

        public string QtKey
        {
            get { return qtKey; }
            set { qtKey = value; }
        }

        public string JobNumber
        {
            get { return jobNumber; }
            set { jobNumber = value; }
        }

        public double CurPay
        {
            get { return curPay; }
            set { curPay = value; }
        }

        public UInt32 GenerateTime
        {
            get { return generateTime; }
            set { generateTime = value; }
        }

    }
}
