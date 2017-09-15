using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FXB.Data;
using FXB.DataManager;
using FXB.Common;
namespace FXB.DataManager
{
    class HYMgr
    {
        private static HYMgr ins;
        private SortedDictionary<Int64, HYData> allHYData;

        public SortedDictionary<Int64, HYData> AllHYData
        {
            get { return allHYData; }
        }
        private HYMgr()
        {
            allHYData = new SortedDictionary<Int64, HYData>();
        }

        public static HYMgr Instance()
        {
            if (ins == null)
            {
                ins = new HYMgr();
            }

            return ins;
        }

        public void Init()
        {
            //将回佣数据添加到订单引用
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                QtOrder order = OrderMgr.Instance().AllOrderData[data.OrderId];
                order.AllHYData[item.Key] = data;
            }
        }



        public HYData AddNewHY(Int64 orderId, double amount, UInt32 addTime, string entryJobNumber)
        {
            if (!OrderMgr.Instance().AllOrderData.ContainsKey(orderId))
            {
                throw new ConditionCheckException(string.Format("订单id[{0}]不存在", orderId));
            }

            QtOrder order = OrderMgr.Instance().AllOrderData[orderId];
            if (amount > order.CommissionAmount)
            {
                throw new ConditionCheckException(string.Format("回佣金额[{0}]大于佣金总额[{1}]", amount, order.CommissionAmount));
            }

            if (!order.CheckState)
            {
                //订单未审核不能添加回佣
                throw new ConditionCheckException(string.Format("订单id[{0}]未审核不能添加回佣", orderId));
            }

            //HY的时间就不审核了

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO qtorderhy(
                                    orderid,
                                    amount,
                                    addtime,
                                    entryjobnumber,
                                    checkstate,
                                    checkjobnumber,
                                    checktime) output inserted.Id VALUES(
                                    @orderid,
                                    @amount,
                                    @addtime,
                                    @entryjobnumber,
                                    @checkstate,
                                    @checkjobnumber,
                                    @checktime);select @@identity";
            command.Parameters.AddWithValue("@orderid", orderId);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@addtime", (Int32)addTime);
            command.Parameters.AddWithValue("@entryjobnumber", entryJobNumber);
            command.Parameters.AddWithValue("@checkstate", false);
            command.Parameters.AddWithValue("@checkjobnumber", "");
            command.Parameters.AddWithValue("@checktime", (Int32)0);

            Int64 hyId = (Int64)command.ExecuteScalar();
            HYData newHyData = new HYData(hyId, orderId, amount, addTime, entryJobNumber, false, "", 0);

            allHYData[hyId] = newHyData;
            order.AllHYData[hyId] = newHyData;

            return newHyData;
        }


        public void UpdateCheckState(Int64 hyId, bool checkState, string checkjobnumber, UInt32 checktime)
        {
            if (!allHYData.ContainsKey(hyId))
            {
                throw new ConditionCheckException(string.Format("回佣id[{0}]不存在", hyId));
            }

            HYData hyData = allHYData[hyId];
            //检测回佣对应的工资是否结算,结算了则不能修改
            //if (hyData.IsSettlement)
            //{
            //    throw new ConditionCheckException(string.Format("回佣id[{0}]已经结算不能变更审核状态", hyId));
            //}

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"update qtorderhy set 
                                    checkstate=@checkstate,
                                    checkjobnumber=@checkjobnumber,
                                    checktime=@checktime where id=@id";
            command.Parameters.AddWithValue("@checkstate", checkState);
            command.Parameters.AddWithValue("@checkjobnumber", checkjobnumber);
            command.Parameters.AddWithValue("@checktime", (Int32)checktime);
            command.Parameters.AddWithValue("@id", hyId);
            command.ExecuteNonQuery();

            hyData.CheckState = checkState;
            hyData.CheckJobNumber = checkjobnumber;
            hyData.CheckTime = checktime;
        }

        public void RemoveHY(Int64 hyId)
        {
            if (!allHYData.ContainsKey(hyId))
            {
                throw new ConditionCheckException(string.Format("回佣id[{0}]不存在", hyId));
            }

            //检测回佣对应的工资是否结算,结算了则不能删除
            //if (hyData.IsSettlement)
            //{
            //    throw new ConditionCheckException(string.Format("回佣id[{0}]已经结算不能变更审核状态", hyId));
            //}

            HYData hyData = allHYData[hyId];
            QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from qtorderhy where id=@id";
            command.Parameters.AddWithValue("@id", hyId);
            command.ExecuteScalar();

            order.AllHYData.Remove(hyId);
            allHYData.Remove(hyId);

        }
    }
}
