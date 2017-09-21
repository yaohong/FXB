using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FXB.Data;
using FXB.DataManager;
namespace FXB.Common
{
    public class PayUtil
    {
        static SortedDictionary<string, PayData> GeneratePay(string qtKey)
        {
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.Closing)
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]没有生成提成，不能计算工资", qtKey));
            }

            SortedDictionary<string, PayData> allPayData = new SortedDictionary<string, PayData>();
            //查找复合条件的回佣
            List<HYData> tmpHy = new List<HYData>();
            foreach (var hyItem in HYMgr.Instance().AllHYData)
            {
                HYData hyData = hyItem.Value;
                if (!hyData.CheckState)
                {
                    //没有审核
                    continue;
                }

                //查看HY的添加时间
                DateTime dateTime = TimeUtil.TimestampToDateTime(hyData.AddTime);
                string belongQtKey = dateTime.ToString("yyyy-MM");
                if (qtKey != belongQtKey)
                {
                    continue;
                }

                tmpHy.Add(hyData);
            }

            foreach (var item in tmpHy)
            {
                HYData validHy = item;
                QtOrder order = OrderMgr.Instance().AllOrderData[validHy.OrderId];

                //订单所属的qtkey
                string orderQtKey = order.QtKey;
            }


            return allPayData;
        }
    }
}
