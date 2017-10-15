using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using FXB.Common;
using FXB.Data;
namespace FXB.DataManager
{
    class OrderMgr
    {
        private static OrderMgr ins;
        private SortedDictionary<Int64, QtOrder> allOrderData;
        private OrderMgr()
        {
            allOrderData = new SortedDictionary<Int64, QtOrder>();
        }

        public static OrderMgr Instance()
        {
            if (ins == null)
            {
                ins = new OrderMgr();
            }

            return ins;
        }

        public SortedDictionary<Int64, QtOrder> AllOrderData
        {
            get { return allOrderData; }
        }

        //删除QT任务时，由QtMgr调过来
        public void RemoveOrderByQtTask(string qtKey)
        {
            //删除指定qtkey下面的所有订单
            List<Int64> deleteKey = new List<Int64>();
            foreach (var item in allOrderData)
            {
                if (item.Value.QtKey == qtKey)
                {
                    deleteKey.Add(item.Key);
                }
            }

            foreach (var v in deleteKey)
            {
                allOrderData.Remove(v);
            }
        }


        public void RemoveQtOrder(Int64 orderId)
        {
            QtOrder order = allOrderData[orderId];
            QtTask qtTask = QtMgr.Instance().AllQtTask[order.QtKey];

            if (qtTask.Closing)
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]已经结算，请执行 [清除QT提成] 后在执行该操作", order.QtKey));
            }

            //还有回佣不能删
            if (order.AllHYData.Count > 0)
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]已经生成回佣,请删除后在进行该操作", order.QtKey));
            }

            SqlTransaction sqlTran = null;
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                //删除订单
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;


                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qtordertd where orderid=@orderid";
                command.Parameters.AddWithValue("@orderid", orderId);
                command.ExecuteScalar();
                //删除对应的退单数据
                command.Parameters.Clear();

                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskorder where id=@id";
                command.Parameters.AddWithValue("@id", orderId);
                command.ExecuteScalar();


                sqlTran.Commit();

                qtTask.AllQtOrder.Remove(orderId);
                allOrderData.Remove(orderId);
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }
        }

        public QtOrder AddNewQtOrder(
            UInt32 generateTime,            //订单生成时间
            double commissionAmount,        //佣金总额
            string customerName,            //客户名称
            string projectCode,             //项目编码
            string roomNumber,              //房间编号
            double closingTheDealMoney,     //成交总价
            string yxConsultantJobNumber,   //营销顾问
            string kyfConsultanJobNumber,   //客源方顾问
            string zc1JobNumber,            //驻场1
            string zc2JobNumber,            //驻场2

            bool checkState,                //审核状态
            string checkPersonJobNumber,    //审核人
            UInt32 checkTime,               //审核时间

            string entryPersonJobNumber,    //录入人

            string comment,                 //备注

            UInt32 buyTime,                 //购买时间
            string customerPhone,           //客户电话
            string customerIdCard,          //客户身份证
            string receipt,                 //收据
            double roomArea,                //面积
            string contractState,           //合同状态
            string paymentMethod,           //付款方式
            double loansMoney,              //贷款金额

            string qtKey                    //所属的QT任务
            )
        {
            if (!QtMgr.Instance().AllQtTask.ContainsKey(qtKey))
            {
                throw new ConditionCheckException("QT任务不存在");
            }

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (qtTask.Closing)
            {
                throw new ConditionCheckException("提成已经生成，本月不能在开单了");
            }

            SqlTransaction sqlTran = null;

            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;


                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO qttaskorder(
                                        generatetime,
                                        commissionamount,
                                        customername,
                                        projectcode,
                                        roomnumber,
                                        closingthedealmoney,
                                        yxconsultantjobnumber,
                                        yxqtdepartmentid,
                                        yxlevelname,
                                        kyfconsultanjobnumber,
                                        kyfqtdepartmentid,
                                        zc1jobnumber,
                                        zc1qtdepartmentid,
                                        zc2jobnumber,
                                        zc2qtdepartmentid,
                                        checkstate,
                                        checkpersonjobnumber,
                                        checktime,
                                        entrypersonjobnumber,
                                        comment,
                                        buytime,    
                                        customerphone,
                                        customeridcard,
                                        receipt,
                                        roomarea,
                                        contractstate,
                                        paymentmethod,
                                        loansmoney,
                                        qtkey) output inserted.Id VALUES(
                                        @generatetime,
                                        @commissionamount,
                                        @customername,
                                        @projectcode,
                                        @roomnumber,
                                        @closingthedealmoney,
                                        @yxconsultantjobnumber,
                                        @yxqtdepartmentid,
                                        @yxlevelname,
                                        @kyfconsultanjobnumber,
                                        @kyfqtdepartmentid,
                                        @zc1jobnumber,
                                        @zc1qtdepartmentid,
                                        @zc2jobnumber,
                                        @zc2qtdepartmentid,
                                        @checkstate,
                                        @checkpersonjobnumber,
                                        @checktime,
                                        @entrypersonjobnumber,
                                        @comment,
                                        @buytime,    
                                        @customerphone,
                                        @customeridcard,
                                        @receipt,
                                        @roomarea,
                                        @contractstate,
                                        @paymentmethod,
                                        @loansmoney,
                                        @qtkey);select @@identity";
                command.Parameters.AddWithValue("@generatetime", (Int32)generateTime);
                command.Parameters.AddWithValue("@commissionamount", commissionAmount);
                command.Parameters.AddWithValue("@customername", customerName);
                command.Parameters.AddWithValue("@projectcode", projectCode);
                command.Parameters.AddWithValue("@roomnumber", roomNumber);
                command.Parameters.AddWithValue("@closingthedealmoney", closingTheDealMoney);
                command.Parameters.AddWithValue("@yxconsultantjobnumber", yxConsultantJobNumber);
                command.Parameters.AddWithValue("@yxqtdepartmentid", 0);
                command.Parameters.AddWithValue("@yxlevelname", "");
                command.Parameters.AddWithValue("@kyfconsultanjobnumber", kyfConsultanJobNumber);
                command.Parameters.AddWithValue("@kyfqtdepartmentid", 0);
                command.Parameters.AddWithValue("@zc1jobnumber", zc1JobNumber);
                command.Parameters.AddWithValue("@zc1qtdepartmentid", 0);
                command.Parameters.AddWithValue("@zc2jobnumber", zc2JobNumber);
                command.Parameters.AddWithValue("@zc2qtdepartmentid", 0);
                command.Parameters.AddWithValue("@checkstate", checkState);
                command.Parameters.AddWithValue("@checkpersonjobnumber", checkPersonJobNumber);
                command.Parameters.AddWithValue("@checktime", (Int32)checkTime);

                command.Parameters.AddWithValue("@entrypersonjobnumber", entryPersonJobNumber);
                command.Parameters.AddWithValue("@comment", comment);
                command.Parameters.AddWithValue("@buytime", (Int32)buyTime);
                command.Parameters.AddWithValue("@customerphone", customerPhone);
                command.Parameters.AddWithValue("@customeridcard", customerIdCard);
                command.Parameters.AddWithValue("@receipt", receipt);
                command.Parameters.AddWithValue("@roomarea", roomArea);
                command.Parameters.AddWithValue("@contractstate", contractState);
                command.Parameters.AddWithValue("@paymentmethod", paymentMethod);
                command.Parameters.AddWithValue("@loansmoney", loansMoney);
                command.Parameters.AddWithValue("@qtkey", qtKey);
                Int64 orderId = (Int64)command.ExecuteScalar();

                command.Parameters.Clear();
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO qtordertd(
                                        orderid,isreturn,returnjobnumber,returntime) 
                                        values (@orderid,@isreturn,@returnjobnumber,@returntime)";
                command.Parameters.AddWithValue("@orderid", orderId);
                command.Parameters.AddWithValue("@isreturn", false);
                command.Parameters.AddWithValue("@returnjobnumber", "");
                command.Parameters.AddWithValue("@returntime", 0);
                command.ExecuteNonQuery();
                sqlTran.Commit();

                QtOrder newQtOrder = new QtOrder(
                    orderId,
                    generateTime,
                    commissionAmount,
                    customerName,
                    projectCode,
                    roomNumber,
                    closingTheDealMoney,
                    yxConsultantJobNumber,
                    kyfConsultanJobNumber,
                    zc1JobNumber,
                    zc2JobNumber,
                    checkState, checkPersonJobNumber, checkTime,
                    entryPersonJobNumber,
                    comment,
                    buyTime,
                    customerPhone,
                    customerIdCard,
                    receipt,
                    roomArea,
                    contractState,
                    paymentMethod,
                    loansMoney,
                    qtKey);
                qtTask.AllQtOrder[orderId] = newQtOrder;
                allOrderData[orderId] = newQtOrder;

                //添加退單數據
                TDData tdData = new TDData(orderId, false, "", 0);
                newQtOrder.ReturnData = tdData;
                //添加到退單管理器
                //TDMgr.Instance().AllTDData.Add(orderId);
                return newQtOrder;
            }
            catch (Exception ex) 
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }
        }


        public void ModifyQtOrder(
            Int64 orderId,                     //订单ID

            double newCommissionAmount,        //佣金总额
            string newCustomerName,            //客户名称
            string newProjectCode,             //项目编码
            string newRoomNumber,              //房间编号
            double newClosingTheDealMoney,     //成交总价
            string newYxConsultantJobNumber,   //营销顾问

            string newKyfConsultanJobNumber,  //客源方顾问
            string newZc1JobNumber,            //驻场1
            string newZc2JobNumber,            //驻场2

            string newComment,                 //备注

            UInt32 newBuyTime,                 //购买时间
            string newCustomerPhone,           //客户电话
            string newCustomerIdCard,          //客户身份证
            string newReceipt,                 //收据
            double newRoomArea,                //面积
            string newContractState,           //合同状态
            string newPaymentMethod,           //付款方式
            double newPoansMoney               //贷款金额
            )
        {
            QtOrder editQtOrder = allOrderData[orderId];
            if (editQtOrder.CheckState)
            {
                throw new ConditionCheckException(string.Format("订单[{0}]已经审核，不能修改.", orderId));
            }

            QtTask qtTask = QtMgr.Instance().AllQtTask[editQtOrder.QtKey];
            if (qtTask.Closing)
            {
                throw new ConditionCheckException(string.Format("订单[{0}]所属的QT任务[{1}]已经结算，不能修改.", orderId, editQtOrder.QtKey));
            }

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = @"update qttaskorder set 
                                    commissionamount=@commissionamount,
                                    customername=@customername,
                                    projectcode=@projectcode,
                                    roomnumber=@roomnumber,
                                    closingthedealmoney=@closingthedealmoney,
                                    yxconsultantjobnumber=@yxconsultantjobnumber,
                                    kyfconsultanjobnumber=@kyfconsultanjobnumber,
                                    zc1jobnumber=@zc1jobnumber,
                                    zc2jobnumber=@zc2jobnumber,
                                    comment=@comment,
                                    buytime=@buytime,
                                    customerphone=@customerphone,
                                    customeridcard=@customeridcard,
                                    receipt=@receipt,
                                    roomarea=@roomarea,
                                    contractstate=@contractstate,
                                    paymentmethod=@paymentmethod,
                                    loansmoney=@loansmoney where id=@id";
            command.Parameters.AddWithValue("@commissionamount", newCommissionAmount);
            command.Parameters.AddWithValue("@customername", newCustomerName);
            command.Parameters.AddWithValue("@projectcode", newProjectCode);
            command.Parameters.AddWithValue("@roomnumber", newRoomNumber);
            command.Parameters.AddWithValue("@closingthedealmoney", newClosingTheDealMoney);
            command.Parameters.AddWithValue("@yxconsultantjobnumber", newYxConsultantJobNumber);
            command.Parameters.AddWithValue("@kyfconsultanjobnumber", newKyfConsultanJobNumber);
            command.Parameters.AddWithValue("@zc1jobnumber", newZc1JobNumber);
            command.Parameters.AddWithValue("@zc2jobnumber", newZc2JobNumber);

            command.Parameters.AddWithValue("@comment", newComment);

            command.Parameters.AddWithValue("@buytime", (Int32)newBuyTime);
            command.Parameters.AddWithValue("@customerphone", newCustomerPhone);
            command.Parameters.AddWithValue("@customeridcard", newCustomerIdCard);
            command.Parameters.AddWithValue("@receipt", newReceipt);
            command.Parameters.AddWithValue("@roomarea", newRoomArea);
            command.Parameters.AddWithValue("@contractstate", newContractState);
            command.Parameters.AddWithValue("@paymentmethod", newPaymentMethod);
            command.Parameters.AddWithValue("@loansmoney", newPoansMoney);
            command.Parameters.AddWithValue("@id", orderId);
            command.ExecuteNonQuery();

            editQtOrder.CommissionAmount = newCommissionAmount;
            editQtOrder.CustomerName = newCustomerName;
            editQtOrder.ProjectCode = newProjectCode;
            editQtOrder.RoomNumber = newRoomNumber;
            editQtOrder.ClosingTheDealMoney = newClosingTheDealMoney;
            editQtOrder.YxConsultantJobNumber = newYxConsultantJobNumber;
            editQtOrder.KyfConsultanJobNumber = newKyfConsultanJobNumber;
            editQtOrder.Zc1JobNumber = newZc1JobNumber;
            editQtOrder.Zc2JobNumber = newZc2JobNumber;
            editQtOrder.Comment = newComment;
            editQtOrder.BuyTime = newBuyTime;
            editQtOrder.CustomerPhone = newCustomerPhone;
            editQtOrder.CustomerIdCard = newCustomerIdCard;
            editQtOrder.Receipt = newReceipt;
            editQtOrder.RoomArea = newRoomArea;
            editQtOrder.ContractState = newContractState;
            editQtOrder.PaymentMethod = newPaymentMethod;
            editQtOrder.LoansMoney = newPoansMoney;
        }

        //更新订单审核信息
        public void UpdateCheckState(Int64 orderId, bool checkState, string checkJobNumber, UInt32 checkTime)
        {
            QtOrder editQtOrder = allOrderData[orderId];
            QtTask qtTask = QtMgr.Instance().AllQtTask[editQtOrder.QtKey];
            if (qtTask.Closing)
            {
                throw new ConditionCheckException(string.Format("订单[{0}]所属的QT任务[{1}]已经结算，不能变更审核状态.", orderId, editQtOrder.QtKey));
            }

            if (editQtOrder.AllHYData.Count > 0)
            {
                throw new ConditionCheckException(string.Format("订单[{0}]已经有回佣了，不能变更审核状态.", orderId));
            }

            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update qttaskorder set checkstate=@checkstate,checkpersonjobnumber=@checkpersonjobnumber,checktime=@checktime where id=@id";
            command.Parameters.AddWithValue("@checkstate", checkState);
            command.Parameters.AddWithValue("@checkpersonjobnumber", checkJobNumber);
            command.Parameters.AddWithValue("@checktime", (Int32)checkTime);
            command.Parameters.AddWithValue("@id", orderId);
            command.ExecuteNonQuery();

            editQtOrder.CheckState = checkState;
            editQtOrder.CheckPersonJobNumber = checkJobNumber;
            editQtOrder.CheckTime = checkTime;
        }
    }
}
