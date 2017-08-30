using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Data;
using FXB.DataManager;
using FXB.Common;
using System.Data.SqlClient;
using System.Data;
namespace FXB.DataManager
{
    public class DbQtTaskIndex
    {
        private string qtKey;
        private bool closing;
        private Int64 rootqtDepartmentid;

        public string QtKey 
        { 
            get { return qtKey; } 
        }

        public bool Closing
        {
            get { return closing; }
        }

        public Int64 RootqtDepartmentId
        {
            get { return rootqtDepartmentid; }
        }
        public DbQtTaskIndex(string tmpQtKey, bool tmpClosing, Int64 tmpRootqtDepartmentid)
        {
            qtKey = tmpQtKey;
            closing = tmpClosing;
            rootqtDepartmentid = tmpRootqtDepartmentid;

        }
    }

    public class DbQtTaskDepartment 
    {
        private Int64 qtDepartmentId;
        private QtLevel qtLevel;
        private string ownerJobNumber;
        private string qtDepartmentName;
        private Int64 parentDepartmentId;
        private double needCompleteTaskAmount;
        private double alreadyCompleteTaskAmount;

        public Int64 QtDepartmentId
        {
            get { return qtDepartmentId; }
        }

        public QtLevel QtLevel
        {
            get { return qtLevel; }
        }

        public string OwnerJobNumber
        {
            get { return ownerJobNumber; }
        }

        public string QtDepartmentName
        {
            get { return qtDepartmentName; }
        }

        public Int64 ParentDepartmentId
        {
            get { return parentDepartmentId; }
        }

        public double NeedCompleteTaskAmount
        {
            get { return needCompleteTaskAmount; }
        }

        public double AlreadyCompleteTaskAmount
        {
            get { return alreadyCompleteTaskAmount; }
        }
        public DbQtTaskDepartment(
            Int64 tmpQtDepartmentId, 
            QtLevel tmpQtLevel, 
            string tmpOwnerJobNumber, 
            string tmpQtDepartmentName, 
            Int64 tmpParentDepartmentId, 
            double tmpNeedCompleteTaskAmount,
            double tmpAlreadyCompleteTaskAmount)
        {
            qtDepartmentId = tmpQtDepartmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            qtDepartmentName = tmpQtDepartmentName;
            parentDepartmentId = tmpParentDepartmentId;
            needCompleteTaskAmount = tmpNeedCompleteTaskAmount;
            alreadyCompleteTaskAmount = tmpAlreadyCompleteTaskAmount;
        }
    }

    public class DbQtTaskEmployee
    {
        private string jobNumber;
        private string jobGradeName;
        private Int64 departmentId;
        private QtLevel qtLevel;
        private bool isOwner;

        public string JobNumber
        {
            get { return jobNumber; }
        }

        public string JobGradeName
        {
            get { return jobGradeName; }
        }

        public Int64 DepartmentId
        {
            get { return departmentId; }
        }

        public QtLevel QtLevel
        {
            get { return qtLevel; }
        }

        public bool IsOwner
        {
            get { return isOwner; }
        }
        public DbQtTaskEmployee(string tmpJobNumber, string tmpJobGradeName, Int64 tmpDepartmentId, QtLevel tmpQtLevel, bool tmpIsOwner)
        {
            jobNumber = tmpJobNumber;
            jobGradeName = tmpJobGradeName;
            departmentId = tmpDepartmentId;
            qtLevel = tmpQtLevel;
            isOwner = tmpIsOwner;
        }
    }

    public class DbQtTaskOrder
    {
        private Int64 id;
        private UInt32 generateTime;
        private double commissionAmount;            //佣金总额
        private string customerName;                //用户名字
        private string projectCode;                 //所属的项目
        private string roomNumber;                  //房号
        private double closingTheDealmoney;         //成交总价

        private string yxConsultantJobnumber;       //营销顾问的ID
        private Int64 yxQtDepartmentId;             //营销顾问所属的部门ID
        private string kyfConsultanJobnumber;       //客源方的ID
        private Int64 kyfQtDepartmentId;            //客源方的部门ID
        private string zc1JobNumber;                //驻场1的ID
        private Int64 zc1QtDepartmentId;            //驻场1的部门ID
        private string zc2JobNumber;                //驻场2的ID
        private Int64 zc2QtDepartmentId;            //驻场2的部门ID

        private bool checkState;                    //
        private string checkPersonJobnumber;
        private UInt32 checkTime;

        private bool ifChargeback;
        private string cbJobnumber;                  //
        private UInt32 cbTime;

        private string entryPersonJobnumber;

        private string comment;
        private UInt32 buyTime;
        private string customerPhone;
        private string customerIdCard;
        private string receipt;
        private double roomArea;
        private string contractState;
        private string paymentMethod;
        private double loansMoney;

        private bool isReceiveReward;                   //是否接受过回佣奖励(第一笔回佣来的时候发放)

        public Int64 Id
        {
            get { return id; }
        }

        public UInt32 GenerateTime
        {
            get { return generateTime; }
        }

        public double CommissionAmount
        {
            get { return commissionAmount; }
        }

        public string CustomerName
        {
            get { return customerName; }
        }

        public string ProjectCode
        {
            get { return projectCode; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
        }

        public double ClosingTheDealmoney
        {
            get { return closingTheDealmoney; }
        }

        public string YxConsultantJobnumber
        {
            get { return yxConsultantJobnumber; }
        }

        public Int64 YxQtDepartmentId
        {
            get { return yxQtDepartmentId; }
        }

        public string KyfConsultanJobnumber
        {
            get { return kyfConsultanJobnumber; }
        }

        public Int64 KyfQtDepartmentId
        {
            get { return kyfQtDepartmentId; }
        }

        public string Zc1JobNumber
        {
            get { return zc1JobNumber; }
        }

        public Int64 Zc1QtDepartmentId
        {
            get { return zc1QtDepartmentId; }
        }

        public string Zc2JobNumber
        {
            get { return zc2JobNumber; }
        }

        public Int64 Zc2QtDepartmentId
        {
            get { return zc2QtDepartmentId; }
        }

        public bool CheckState
        {
            get { return checkState; }
        }

        public string CheckPersonJobnumber
        {
            get { return checkPersonJobnumber; }
        }

        public UInt32 CheckTime
        {
            get { return checkTime; }
        }

        public bool IfChargeback
        {
            get { return ifChargeback; }
        }

        public string CbJobnumber
        {
            get { return cbJobnumber; }
        }

        public UInt32 CbTime
        {
            get { return cbTime; }
        }

        public string EntryPersonJobnumber
        {
            get { return entryPersonJobnumber; }
        }

        public string Comment
        {
            get { return comment; }
        }

        public UInt32 BuyTime
        {
            get { return buyTime; }
        }

        public string CustomerPhone
        {
            get { return customerPhone; }
        }

        public string CustomerIdCard
        {
            get { return customerIdCard; }
        }

        public string Receipt
        {
            get { return receipt; }
        }

        public double RoomArea
        {
            get { return roomArea; }
        }

        public string ContractState
        {
            get { return contractState; }
        }

        public string PaymentMethod
        {
            get { return paymentMethod; }
        }


        public double LoansMoney
        {
            get { return loansMoney; }
        }

        public bool IsReceiveReward
        {
            get { return isReceiveReward; }
        }

        public DbQtTaskOrder(
            Int64 tmpId,
            UInt32 tmpGenerateTime,
            double tmpCommissionAmount,
            string tmpCustomerName,
            string tmpProjectCode,
            string tmpRoomNumber,
            double tmpClosingTheDealmoney,

            string tmpYxConsultantJobnumber,
            Int64 tmpYxQtDepartmentId,             
            string tmpKyfConsultanJobnumber,       
            Int64 tmpKyfQtDepartmentId,            
            string tmpZc1JobNumber,                
            Int64 tmpZc1QtDepartmentId,            
            string tmpZc2JobNumber,                
            Int64 tmpZc2QtDepartmentId,    
        
            bool tmpCheckState,
            string tmpCheckPersonJobnumber,
            UInt32 tmpCheckTime,

            bool tmpIfChargeback,
            string tmpCbJobnumber,
            UInt32 tmpCbTime,

            string tmpEntryPersonJobnumber,

            string tmpComment,
            UInt32 tmpBuyTime,
            string tmpCustomerPhone,
            string tmpCustomerIdCard,
            string tmpReceipt,
            double tmpRoomArea,
            string tmpContractState,
            string tmpPaymentMethod,
            double tmploansMoney,

            bool tmpIsReceiveReward
            )
        {
            id = tmpId;
            generateTime = tmpGenerateTime;
            commissionAmount = tmpCommissionAmount;        
            customerName = tmpCustomerName;
            projectCode = tmpProjectCode;                 
            roomNumber = tmpRoomNumber;
            closingTheDealmoney = tmpClosingTheDealmoney;

            yxConsultantJobnumber = tmpYxConsultantJobnumber;
            yxQtDepartmentId = tmpYxQtDepartmentId;             
            kyfConsultanJobnumber = tmpKyfConsultanJobnumber;       
            kyfQtDepartmentId = tmpKyfQtDepartmentId;
            zc1JobNumber = tmpZc1JobNumber;
            zc1QtDepartmentId = tmpZc1QtDepartmentId;            
            zc2JobNumber = tmpZc2JobNumber;                
            zc2QtDepartmentId = tmpZc2QtDepartmentId;            

            checkState = tmpCheckState;                    
            checkPersonJobnumber = tmpCheckPersonJobnumber;
            checkTime = tmpCheckTime;

            ifChargeback = tmpIfChargeback;
            cbJobnumber = tmpCbJobnumber;
            cbTime = tmpCbTime;

            entryPersonJobnumber = tmpEntryPersonJobnumber;

            comment = tmpComment;
            buyTime = tmpBuyTime;
            customerPhone = tmpCustomerPhone;
            customerIdCard = tmpCustomerIdCard;
            receipt = tmpReceipt;
            roomArea = tmpRoomArea;
            contractState = tmpContractState;
            paymentMethod = tmpPaymentMethod;
            loansMoney = tmploansMoney;

            isReceiveReward = tmpIsReceiveReward;
        }

    }

    class QtMgr
    {
        private static QtMgr ins;
        private SortedDictionary<string, QtTask> allQtTask;
        private QtMgr()
        {
            allQtTask = new SortedDictionary<string, QtTask>();
        }

        public static QtMgr Instance()
        {
            if (ins == null)
            {
                ins = new QtMgr();
            }

            return ins;
        }

        public void Load()
        {
            AllQtTask.Clear();
            //重新从数据库里加载
            SqlDataReader qtIndexReader = null;
            SqlDataReader qtDepartmentReader = null;
            SqlDataReader qtEmployeeReader = null;
            SqlDataReader qtOrderReader = null;
            try
            {

                //加载QTIndex
                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtIndexCommand = new SqlCommand();
                qtIndexCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtIndexCommand.CommandType = CommandType.Text;
                qtIndexCommand.CommandText = "select * from qttaskindex";
                qtIndexReader = qtIndexCommand.ExecuteReader();
                
                SortedDictionary<string, DbQtTaskIndex> dbAllQtTaskIndex = new SortedDictionary<string, DbQtTaskIndex>();
                while (qtIndexReader.Read())
                {
                    string qtkey = qtIndexReader.GetString(0);
                    bool closing = qtIndexReader.GetBoolean(1);
                    Int64 rootqtdepartmentid = qtIndexReader.GetInt64(2);

                    if (dbAllQtTaskIndex.ContainsKey(qtkey))
                    {
                        throw new CrashException("Qt任务索引重复");
                    }
                    dbAllQtTaskIndex[qtkey] = new DbQtTaskIndex(qtkey, closing, rootqtdepartmentid);
                }
                qtIndexReader.Close();
                //////////////////////////////////////////////////////////////////////////////////////////////

                //加载QT部门
                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtDepartmentCommand = new SqlCommand();
                qtDepartmentCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtDepartmentCommand.CommandType = CommandType.Text;
                qtDepartmentCommand.CommandText = "select * from qttaskdepartment";
                qtDepartmentReader = qtDepartmentCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<Int64, DbQtTaskDepartment> > dbAllQtTaskDepartment = new SortedDictionary<string, SortedDictionary<Int64, DbQtTaskDepartment> >();
                while (qtDepartmentReader.Read())
                {
                    Int64 qtdepartmentid = qtDepartmentReader.GetInt64(0);
                    QtLevel qtLevel = (QtLevel)qtDepartmentReader.GetInt32(1);
                    string ownerJobNumber = qtDepartmentReader.GetString(2);
                    string qtdepartmentname = qtDepartmentReader.GetString(3);
                    Int64 parentQtDepartmentId = qtDepartmentReader.GetInt64(4);
                    double needCompleteTaskAmount = qtDepartmentReader.GetDouble(5);
                    double alreadycompletetaskamount = qtDepartmentReader.GetDouble(6);
                    string qtKey = qtDepartmentReader.GetString(7);

                    SortedDictionary<Int64, DbQtTaskDepartment> allDepartment;
                    if (dbAllQtTaskDepartment.ContainsKey(qtKey))
                    {
                        allDepartment = dbAllQtTaskDepartment[qtKey];
                    } 
                    else
                    {
                        dbAllQtTaskDepartment[qtKey] = new SortedDictionary<Int64, DbQtTaskDepartment>();
                        allDepartment = dbAllQtTaskDepartment[qtKey];
                    }

                    if (allDepartment.ContainsKey(qtdepartmentid))
                    {
                        throw new CrashException("QT部门ID重复");
                    }

                    allDepartment[qtdepartmentid] = new DbQtTaskDepartment(qtdepartmentid, qtLevel, ownerJobNumber, qtdepartmentname, parentQtDepartmentId, needCompleteTaskAmount, alreadycompletetaskamount);
                }
                qtDepartmentReader.Close();
                //////////////////////////////////////////////////////////////////////////////////////////////

                //加载QT员工
                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtEmployeeCommand = new SqlCommand();
                qtEmployeeCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtEmployeeCommand.CommandType = CommandType.Text;
                qtEmployeeCommand.CommandText = "select * from qttaskemployee";
                qtEmployeeReader = qtEmployeeCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<string, DbQtTaskEmployee>> dbAllQtTaskEmployee = new SortedDictionary<string, SortedDictionary<string, DbQtTaskEmployee>>();
                while (qtEmployeeReader.Read())
                {
                    string jobNumber = qtEmployeeReader.GetString(0);
                    string jobGradeName = qtEmployeeReader.GetString(1);
                    Int64 qtdepartmentid = qtEmployeeReader.GetInt64(2);
                    QtLevel qtLevel = (QtLevel)qtEmployeeReader.GetInt32(3);
                    bool isOwner = qtEmployeeReader.GetBoolean(4);
                    string qtKey = qtEmployeeReader.GetString(5);

                    SortedDictionary<string, DbQtTaskEmployee> allEmployee;
                    if (dbAllQtTaskEmployee.ContainsKey(qtKey))
                    {
                        allEmployee = dbAllQtTaskEmployee[qtKey];
                    }
                    else
                    {
                        dbAllQtTaskEmployee[qtKey] = new SortedDictionary<string, DbQtTaskEmployee>();
                        allEmployee = dbAllQtTaskEmployee[qtKey];
                    }

                    if (allEmployee.ContainsKey(jobNumber))
                    {
                        throw new CrashException("工号重复");
                    }

                    allEmployee[jobNumber] = new DbQtTaskEmployee(jobNumber, jobGradeName, qtdepartmentid, qtLevel, isOwner);
                }
                qtEmployeeReader.Close();

                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtOrderCommand = new SqlCommand();
                qtOrderCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtOrderCommand.CommandType = CommandType.Text;
                qtOrderCommand.CommandText = "select * from qttaskorder";
                qtOrderReader = qtOrderCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<Int64, DbQtTaskOrder>> dbAllQtTaskOrder = new SortedDictionary<string, SortedDictionary<Int64, DbQtTaskOrder>>();
                while (qtOrderReader.Read())
                {
                    Int64 id = qtOrderReader.GetInt64(0);
                    UInt32 generatetime = (UInt32)qtOrderReader.GetInt32(1);
                    double commissionamount = qtOrderReader.GetDouble(2);
                    string customername = qtOrderReader.GetString(3);
                    string projectcode = qtOrderReader.GetString(4);
                    string roomnumber = qtOrderReader.GetString(5);
                    double closingthedealmoney = qtOrderReader.GetDouble(6);
                    string yxconsultantjobnumber = qtOrderReader.GetString(7);
                    Int64 yxqtdepartmentid = qtOrderReader.GetInt64(8);
                    string kyfconsultanjobnumber = qtOrderReader.GetString(9);
                    Int64 kyfqtdepartmentid = qtOrderReader.GetInt64(10);
                    string zc1jobnumber = qtOrderReader.GetString(11);
                    Int64 zc1qtdepartmentid = qtOrderReader.GetInt64(12);
                    string zc2jobnumber = qtOrderReader.GetString(13);
                    Int64 zc2qtdepartmentid = qtOrderReader.GetInt64(14);
                    bool checkstate = qtOrderReader.GetBoolean(15);
                    string checkpersonjobnumber = qtOrderReader.GetString(16);
                    UInt32 checktime = (UInt32)qtOrderReader.GetInt32(17);
                    bool ifchargeback = qtOrderReader.GetBoolean(18);
                    string cbjobnumber = qtOrderReader.GetString(19);
                    UInt32 cbtime = (UInt32)qtOrderReader.GetInt32(20);
                    string entrypersonjobnumber = qtOrderReader.GetString(21);
                    string comment = qtOrderReader.GetString(22);
                    UInt32 buytime = (UInt32)qtOrderReader.GetInt32(23);
                    string customerphone = qtOrderReader.GetString(24);
                    string customeridcard = qtOrderReader.GetString(25);
                    string receipt = qtOrderReader.GetString(26);
                    double roomarea = qtOrderReader.GetDouble(27);
                    string contractstate = qtOrderReader.GetString(28);
                    string paymentmethod = qtOrderReader.GetString(29);
                    double loansmoney = qtOrderReader.GetDouble(30);
                    bool isreceivereward = qtOrderReader.GetBoolean(31);
                    string qtkey = qtOrderReader.GetString(32);

                    SortedDictionary<Int64, DbQtTaskOrder> allOrder;
                    if (dbAllQtTaskOrder.ContainsKey(qtkey))
                    {
                        allOrder = dbAllQtTaskOrder[qtkey];
                    }
                    else
                    {
                        dbAllQtTaskOrder[qtkey] = new SortedDictionary<Int64, DbQtTaskOrder>();
                        allOrder = dbAllQtTaskOrder[qtkey];
                    }

                    allOrder[id] = new DbQtTaskOrder(
                        id, generatetime, commissionamount, customername,
                        projectcode, roomnumber, closingthedealmoney, yxconsultantjobnumber, 
                        yxqtdepartmentid,kyfconsultanjobnumber, kyfqtdepartmentid, zc1jobnumber, 
                        zc1qtdepartmentid, zc2jobnumber, zc2qtdepartmentid, checkstate, 
                        checkpersonjobnumber,checktime,ifchargeback, cbjobnumber, 
                        cbtime, entrypersonjobnumber, comment, buytime, 
                        customerphone, customeridcard, receipt, roomarea, 
                        contractstate, paymentmethod, loansmoney, isreceivereward);
                }
                qtOrderReader.Close();
                //////////////////////////////////////////////////////////////////////////////////////////////

                foreach (var item in dbAllQtTaskIndex)
                {
                    string qtKey = item.Key;
                    DbQtTaskIndex qtTaskIndexData = item.Value;

                    SortedDictionary<Int64, DbQtTaskDepartment> qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    if (!dbAllQtTaskDepartment.ContainsKey(qtKey))
                    {
                        qtTaskDepartmentData = new SortedDictionary<Int64, DbQtTaskDepartment>();
                    }
                    else
                    {
                        qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    }

                    SortedDictionary<string, DbQtTaskEmployee> qtTaskEmployeeData;
                    if (!dbAllQtTaskEmployee.ContainsKey(qtKey))
                    {
                        qtTaskEmployeeData = new SortedDictionary<string, DbQtTaskEmployee>();
                    }
                    else
                    {
                        qtTaskEmployeeData = dbAllQtTaskEmployee[qtKey];
                    }

                    SortedDictionary<Int64, DbQtTaskOrder> qtTaskOrderData;
                    if (!dbAllQtTaskOrder.ContainsKey(qtKey))
                    {
                        qtTaskOrderData = new SortedDictionary<Int64, DbQtTaskOrder>();
                    }
                    else
                    {
                        qtTaskOrderData = dbAllQtTaskOrder[qtKey];
                    }
                    QtTask qtTask = new QtTask(qtTaskIndexData, qtTaskDepartmentData, qtTaskEmployeeData, qtTaskOrderData);

                    allQtTask[qtKey] = qtTask;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }
            finally
            {
                if (qtIndexReader != null)
                {
                    if (!qtIndexReader.IsClosed)
                    {
                        qtIndexReader.Close();
                    }
                    
                }

                if (qtDepartmentReader != null)
                {
                    if (!qtDepartmentReader.IsClosed)
                    {
                        qtDepartmentReader.Close();
                    }

                }

                if (qtEmployeeReader != null)
                {
                    if (!qtEmployeeReader.IsClosed)
                    {
                        qtEmployeeReader.Close();
                    }

                }

                if (qtOrderReader != null)
                {
                    if (!qtOrderReader.IsClosed)
                    {
                        qtOrderReader.Close();
                    }

                }
            }
        }


        public QtTask AddNewQtTask(string qtKey)
        {
            //添加新的QT任务
            //如果QT任务存在,并且任务下有开单了。则禁止重新生成
            if (allQtTask.ContainsKey(qtKey))
            {
                throw new ConditionCheckException("QT任务已经存在");
            }

            QtTask newQtTask = new QtTask(qtKey);
            //数据序列化到DB
            SqlTransaction sqlTran = null; 
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO qttaskindex(qtkey,closing,rootqtdepartmentid) VALUES(@qtkey, @closing, @rootqtdepartmentid)";
                command.Parameters.AddWithValue("@qtkey", newQtTask.QtKey);
                command.Parameters.AddWithValue("@closing", newQtTask.Closing);
                command.Parameters.AddWithValue("@rootqtdepartmentid", newQtTask.RootQtDepartment.Id);
                command.ExecuteNonQuery();
                Console.WriteLine("insert qtindex success");

                command.Parameters.Clear();
                foreach (var item in newQtTask.AllQtDepartment)
                {
                    QtDepartment qtDepartment = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO qttaskdepartment(
                                            qtdepartmentid,
                                            qtlevel,
                                            ownerjobnumber,
                                            qtdepartmentname,
                                            parentdepartmentid,
                                            needcompletetaskamount,
                                            alreadycompletetaskamount,
                                            qtkey) VALUES (
                                            @qtdepartmentid, 
                                            @qtlevel, 
                                            @ownerjobnumber, 
                                            @qtdepartmentname, 
                                            @parentdepartmentid, 
                                            @needcompletetaskamount, 
                                            @alreadycompletetaskamount,
                                            @qtkey)";
                    command.Parameters.AddWithValue("@qtdepartmentid", qtDepartment.Id);
                    command.Parameters.AddWithValue("@qtlevel", (Int32)qtDepartment.QtLevel);
                    command.Parameters.AddWithValue("@ownerjobnumber", qtDepartment.OwnerJobNumber);
                    command.Parameters.AddWithValue("@qtdepartmentname", qtDepartment.DepartmentName);
                    command.Parameters.AddWithValue("@parentdepartmentid", qtDepartment.ParentDepartmentId);
                    command.Parameters.AddWithValue("@needcompletetaskamount", qtDepartment.NeedCompleteTaskAmount);
                    command.Parameters.AddWithValue("@alreadycompletetaskamount", qtDepartment.AlreadyCompleteTaskAmount);
                    command.Parameters.AddWithValue("@qtkey", newQtTask.QtKey);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                Console.WriteLine("insert qtdepartment success");

                command.Parameters.Clear();
                foreach (var item in newQtTask.AllQtEmployee)
                {
                    QtEmployee qtEmployee = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO qttaskemployee(jobnumber,jobgradename,departmentid,qtlevel,isowner,qtkey) 
                                            VALUES(@jobnumber,@jobgradename, @departmentid, @qtlevel, @isowner, @qtkey)";
                    command.Parameters.AddWithValue("@jobnumber", qtEmployee.JobNumber);
                    command.Parameters.AddWithValue("@jobgradename", qtEmployee.JobGradeName);
                    command.Parameters.AddWithValue("@departmentid", qtEmployee.DepartmentId);
                    command.Parameters.AddWithValue("@qtlevel", (Int32)qtEmployee.QtLevel);
                    command.Parameters.AddWithValue("@isowner", qtEmployee.IsOwner);
                    command.Parameters.AddWithValue("@qtkey", newQtTask.QtKey);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }

                sqlTran.Commit();
                allQtTask[newQtTask.QtKey] = newQtTask;
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }

            return newQtTask;
        }

        public void RemoveQtTask(string qtKey)
        {
            SqlTransaction sqlTran = null; 
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                //删除QT部门
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskdepartment where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                //删除QT员工
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskemployee where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                //删除QT订单
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskorder where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                //删除QT数据
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskindex where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                //回佣
                //开单

                sqlTran.Commit();
                allQtTask.Remove(qtKey);
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
            Int64 yxQtDepartmentId,         //营销顾问所属的部门ID
            string kyfConsultanJobNumber,  //客源方顾问
            Int64 kyfQtDepartmentId,        //客源方的部门ID
            string zc1JobNumber,            //驻场1
            Int64 zc1QtDepartmentId,        //驻场1的部门ID
            string zc2JobNumber,            //驻场2
            Int64 zc2QtDepartmentId,        //驻场2的部门ID

            bool checkState,                //审核状态
            string checkPersonJobNumber,    //审核人
            UInt32 checkTime,               //审核时间

            bool ifchargeback,                   //是否退单
            string cbJobNumber,                  //退单人
            UInt32 cbTime,                       //退单时间

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

            bool isReceiveReward,           //是否领取开单奖励
            string qtKey                    //所属的QT任务
            )
        {
            if (!allQtTask.ContainsKey(qtKey))
            {
                throw new ConditionCheckException("QT任务不存在");
            }


            if (allQtTask[qtKey].Closing)
            {
                throw new ConditionCheckException("提成已经生成，本月不能在开单了");
            }

            QtTask qtTask = allQtTask[qtKey];
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
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
                                        kyfconsultanjobnumber,
                                        kyfqtdepartmentid,
                                        zc1jobnumber,
                                        zc1qtdepartmentid,
                                        zc2jobnumber,
                                        zc2qtdepartmentid,
                                        checkstate,
                                        checkpersonjobnumber,
                                        checktime,
                                        ifchargeback,
                                        cbjobnumber,
                                        cbtime,
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
                                        isreceivereward,
                                        qtkey) output inserted.Id VALUES(
                                        @generatetime,
                                        @commissionamount,
                                        @customername,
                                        @projectcode,
                                        @roomnumber,
                                        @closingthedealmoney,
                                        @yxconsultantjobnumber,
                                        @yxqtdepartmentid,
                                        @kyfconsultanjobnumber,
                                        @kyfqtdepartmentid,
                                        @zc1jobnumber,
                                        @zc1qtdepartmentid,
                                        @zc2jobnumber,
                                        @zc2qtdepartmentid,
                                        @checkstate,
                                        @checkpersonjobnumber,
                                        @checktime,
                                        @ifchargeback,
                                        @cbjobnumber,
                                        @cbtime,
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
                                        @isreceivereward,
                                        @qtkey);select @@identity";
            command.Parameters.AddWithValue("@generatetime", (Int32)generateTime);
            command.Parameters.AddWithValue("@commissionamount", commissionAmount);
            command.Parameters.AddWithValue("@customername", customerName);
            command.Parameters.AddWithValue("@projectcode", projectCode);
            command.Parameters.AddWithValue("@roomnumber", roomNumber);
            command.Parameters.AddWithValue("@closingthedealmoney", closingTheDealMoney);
            command.Parameters.AddWithValue("@yxconsultantjobnumber", yxConsultantJobNumber);
            command.Parameters.AddWithValue("@yxqtdepartmentid", yxQtDepartmentId);
            command.Parameters.AddWithValue("@kyfconsultanjobnumber", kyfConsultanJobNumber);
            command.Parameters.AddWithValue("@kyfqtdepartmentid", kyfQtDepartmentId);
            command.Parameters.AddWithValue("@zc1jobnumber", zc1JobNumber);
            command.Parameters.AddWithValue("@zc1qtdepartmentid", zc1QtDepartmentId);
            command.Parameters.AddWithValue("@zc2jobnumber", zc2JobNumber);
            command.Parameters.AddWithValue("@zc2qtdepartmentid", zc2QtDepartmentId);
            command.Parameters.AddWithValue("@checkstate", checkState);
            command.Parameters.AddWithValue("@checkpersonjobnumber", checkPersonJobNumber);
            command.Parameters.AddWithValue("@checktime", (Int32)checkTime);

            command.Parameters.AddWithValue("@ifchargeback", ifchargeback);
            command.Parameters.AddWithValue("@cbjobnumber", cbJobNumber);
            command.Parameters.AddWithValue("@cbtime", (Int32)cbTime);

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
            command.Parameters.AddWithValue("@isreceivereward", isReceiveReward);
            command.Parameters.AddWithValue("@qtkey", qtKey);
            Int64 orderId = (Int64)command.ExecuteScalar();

            QtOrder newQtOrder = new QtOrder(
                orderId, generateTime, commissionAmount, customerName,
                projectCode, roomNumber, closingTheDealMoney, yxConsultantJobNumber,
                yxQtDepartmentId, kyfConsultanJobNumber, kyfQtDepartmentId, zc1JobNumber,
                zc1QtDepartmentId, zc2JobNumber, zc2QtDepartmentId, checkState,
                checkPersonJobNumber, checkTime, ifchargeback, cbJobNumber,
                cbTime, entryPersonJobNumber, comment, buyTime,
                customerPhone, customerIdCard, receipt, roomArea,
                contractState, paymentMethod, loansMoney, isReceiveReward, qtKey);
            qtTask.AllQtOrder[orderId] = newQtOrder;
            return newQtOrder;
        }

        //生成QT提成
        public void CalcQtCommission(string qtKey)
        {
            if (!allQtTask.ContainsKey(qtKey))
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]不存在", qtKey));
            }
            QtTask qtTask = allQtTask[qtKey];
            qtTask.CalcQtCommission();

            SqlTransaction sqlTran = null; 
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;
                command.CommandType = CommandType.Text;
                command.CommandText = "update qttaskindex set closing=@closing where qtkey=@qtkey";
                command.Parameters.AddWithValue("@closing", qtTask.Closing);
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteNonQuery();

                command.Parameters.Clear();

                foreach (var item in qtTask.AllQtDepartment)
                {
                    QtDepartment qtDepartment = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update qttaskdepartment set alreadycompletetaskamount=@alreadycompletetaskamount where qtkey=@qtkey and qtdepartmentid=@qtdepartmentid";
                    command.Parameters.AddWithValue("@alreadycompletetaskamount", qtDepartment.AlreadyCompleteTaskAmount);
                    command.Parameters.AddWithValue("@qtkey", qtKey);
                    command.Parameters.AddWithValue("@qtdepartmentid", item.Key);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                sqlTran.Commit();
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

        //清除QT提成
        public void ClearQtCommission(string qtKey)
        {
            if (!allQtTask.ContainsKey(qtKey))
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]不存在", qtKey));
            }

            QtTask qtTask = allQtTask[qtKey];
            qtTask.ClearQtCommission();

            SqlTransaction sqlTran = null;
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;
                command.CommandType = CommandType.Text;
                command.CommandText = "update qttaskindex set closing=@closing where qtkey=@qtkey";
                command.Parameters.AddWithValue("@closing", qtTask.Closing);
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteNonQuery();

                command.Parameters.Clear();

                foreach (var item in qtTask.AllQtDepartment)
                {
                    QtDepartment qtDepartment = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update qttaskdepartment set alreadycompletetaskamount=@alreadycompletetaskamount where qtkey=@qtkey and qtdepartmentid=@qtdepartmentid";
                    command.Parameters.AddWithValue("@alreadycompletetaskamount", qtDepartment.AlreadyCompleteTaskAmount);
                    command.Parameters.AddWithValue("@qtkey", qtKey);
                    command.Parameters.AddWithValue("@qtdepartmentid", item.Key);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                sqlTran.Commit();
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

        public SortedDictionary<string, QtTask> AllQtTask
        {
            get { return allQtTask; }
        }


        public bool CheckQtKey()
        {
            string qtKey = DateTime.Now.ToString("yyyy-MM");
            if (allQtTask.ContainsKey(qtKey) && !allQtTask[qtKey].Closing)
            {
                return true;
            }

            return false;
        }
    }
}
