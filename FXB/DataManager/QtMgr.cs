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
            SqlDataReader qtHYReader = null;
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
                SortedDictionary<string, SortedDictionary<Int64, QtDepartment>> dbAllQtTaskDepartment = new SortedDictionary<string, SortedDictionary<Int64, QtDepartment>>();
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

                    SortedDictionary<Int64, QtDepartment> allDepartment;
                    if (dbAllQtTaskDepartment.ContainsKey(qtKey))
                    {
                        allDepartment = dbAllQtTaskDepartment[qtKey];
                    } 
                    else
                    {
                        dbAllQtTaskDepartment[qtKey] = new SortedDictionary<Int64, QtDepartment>();
                        allDepartment = dbAllQtTaskDepartment[qtKey];
                    }

                    if (allDepartment.ContainsKey(qtdepartmentid))
                    {
                        throw new CrashException("QT部门ID重复");
                    }

                    allDepartment[qtdepartmentid] = new QtDepartment(qtdepartmentid, qtLevel, ownerJobNumber, qtdepartmentname, parentQtDepartmentId, needCompleteTaskAmount, alreadycompletetaskamount);
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
                SortedDictionary<string, SortedDictionary<string, QtEmployee>> dbAllQtTaskEmployee = new SortedDictionary<string, SortedDictionary<string, QtEmployee>>();
                while (qtEmployeeReader.Read())
                {
                    string jobNumber = qtEmployeeReader.GetString(0);
                    string jobGradeName = qtEmployeeReader.GetString(1);
                    Int64 qtdepartmentid = qtEmployeeReader.GetInt64(2);
                    QtLevel qtLevel = (QtLevel)qtEmployeeReader.GetInt32(3);
                    bool isOwner = qtEmployeeReader.GetBoolean(4);
                    string qtKey = qtEmployeeReader.GetString(5);

                    SortedDictionary<string, QtEmployee> allEmployee;
                    if (dbAllQtTaskEmployee.ContainsKey(qtKey))
                    {
                        allEmployee = dbAllQtTaskEmployee[qtKey];
                    }
                    else
                    {
                        dbAllQtTaskEmployee[qtKey] = new SortedDictionary<string, QtEmployee>();
                        allEmployee = dbAllQtTaskEmployee[qtKey];
                    }

                    if (allEmployee.ContainsKey(jobNumber))
                    {
                        throw new CrashException("工号重复");
                    }

                    allEmployee[jobNumber] = new QtEmployee(jobNumber, jobGradeName, qtdepartmentid, qtLevel, isOwner);
                }
                qtEmployeeReader.Close();

                //加载QT订单
                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtOrderCommand = new SqlCommand();
                qtOrderCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtOrderCommand.CommandType = CommandType.Text;
                qtOrderCommand.CommandText = "select * from qttaskorder";
                qtOrderReader = qtOrderCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<Int64, QtOrder>> dbAllQtTaskOrder = new SortedDictionary<string, SortedDictionary<Int64, QtOrder>>();
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
                    //Int64 yxqtdepartmentid = qtOrderReader.GetInt64(8);
                    //string yxLevelName = qtOrderReader.GetString(9);
                    string kyfconsultanjobnumber = qtOrderReader.GetString(10);
                    //Int64 kyfqtdepartmentid = qtOrderReader.GetInt64(11);
                    string zc1jobnumber = qtOrderReader.GetString(12);
                    //Int64 zc1qtdepartmentid = qtOrderReader.GetInt64(13);
                    string zc2jobnumber = qtOrderReader.GetString(14);
                    //Int64 zc2qtdepartmentid = qtOrderReader.GetInt64(15);
                    bool checkstate = qtOrderReader.GetBoolean(16);
                    string checkpersonjobnumber = qtOrderReader.GetString(17);
                    UInt32 checktime = (UInt32)qtOrderReader.GetInt32(18);
                    //bool ifchargeback = qtOrderReader.GetBoolean(18);
                    //string cbjobnumber = qtOrderReader.GetString(19);
                    //UInt32 cbtime = (UInt32)qtOrderReader.GetInt32(20);
                    string entrypersonjobnumber = qtOrderReader.GetString(19);
                    string comment = qtOrderReader.GetString(20);
                    UInt32 buytime = (UInt32)qtOrderReader.GetInt32(21);
                    string customerphone = qtOrderReader.GetString(22);
                    string customeridcard = qtOrderReader.GetString(23);
                    string receipt = qtOrderReader.GetString(24);
                    double roomarea = qtOrderReader.GetDouble(25);
                    string contractstate = qtOrderReader.GetString(26);
                    string paymentmethod = qtOrderReader.GetString(27);
                    double loansmoney = qtOrderReader.GetDouble(28);
                    string qtkey = qtOrderReader.GetString(29);

                    SortedDictionary<Int64, QtOrder> allOrder;
                    if (dbAllQtTaskOrder.ContainsKey(qtkey))
                    {
                        allOrder = dbAllQtTaskOrder[qtkey];
                    }
                    else
                    {
                        dbAllQtTaskOrder[qtkey] = new SortedDictionary<Int64, QtOrder>();
                        allOrder = dbAllQtTaskOrder[qtkey];
                    }
                    //allOrder[id]

                    QtOrder newQtOrder = new QtOrder(
                        id, 
                        generatetime, 
                        commissionamount, 
                        customername,
                        projectcode, 
                        roomnumber, 
                        closingthedealmoney, 
                        yxconsultantjobnumber,
                        kyfconsultanjobnumber,
                        zc1jobnumber,
                        zc2jobnumber,
                        checkstate, checkpersonjobnumber,checktime, 
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
                        qtkey);
                    allOrder[id] = newQtOrder;
                    OrderMgr.Instance().AllOrderData[id] = newQtOrder;
                }
                qtOrderReader.Close();
                //////////////////////////////////////////////////////////////////////////////////////////////

                //加载回佣
                //////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand qtHYCommand = new SqlCommand();
                qtHYCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtHYCommand.CommandType = CommandType.Text;
                qtHYCommand.CommandText = "select * from qtorderhy";
                qtHYReader = qtHYCommand.ExecuteReader();

                while (qtHYReader.Read())
                {
                    Int64 hyId = qtHYReader.GetInt64(0);
                    Int64 orderId = qtHYReader.GetInt64(1);
                    double amount = qtHYReader.GetDouble(2);
                    UInt32 addtime = (UInt32)qtHYReader.GetInt32(3);
                    string entryjobnumber = qtHYReader.GetString(4);
                    bool checkstate = qtHYReader.GetBoolean(5);
                    string checkjobnumber = qtHYReader.GetString(6);
                    UInt32 checktime = (UInt32)qtHYReader.GetInt32(7);

                    HYData hyData = new HYData(hyId, orderId, amount, addtime, entryjobnumber, checkstate, checkjobnumber, checktime);
                    HYMgr.Instance().AllHYData[hyId] = hyData;
                }
                qtHYReader.Close();

                //////////////////////////////////////////////////////////////////////////////////////////////

                foreach (var item in dbAllQtTaskIndex)
                {
                    string qtKey = item.Key;
                    DbQtTaskIndex qtTaskIndexData = item.Value;

                    SortedDictionary<Int64, QtDepartment> qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    if (!dbAllQtTaskDepartment.ContainsKey(qtKey))
                    {
                        qtTaskDepartmentData = new SortedDictionary<Int64, QtDepartment>();
                    }
                    else
                    {
                        qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    }

                    SortedDictionary<string, QtEmployee> qtTaskEmployeeData;
                    if (!dbAllQtTaskEmployee.ContainsKey(qtKey))
                    {
                        qtTaskEmployeeData = new SortedDictionary<string, QtEmployee>();
                    }
                    else
                    {
                        qtTaskEmployeeData = dbAllQtTaskEmployee[qtKey];
                    }

                    SortedDictionary<Int64, QtOrder> qtTaskOrderData;
                    if (!dbAllQtTaskOrder.ContainsKey(qtKey))
                    {
                        qtTaskOrderData = new SortedDictionary<Int64, QtOrder>();
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
                System.Environment.Exit(0);
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
            QtTask selectQtTask = allQtTask[qtKey];
            if (selectQtTask.AllQtOrder.Count > 0)
            {
                //已经有开单了不能删除
                throw new ConditionCheckException(string.Format("qt任务[{0}]已经有开单了，不能删除", qtKey));
            }

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

                ////删除QT订单
                //command.CommandType = CommandType.Text;
                //command.CommandText = "delete from qttaskorder where qtkey=@qtkey";
                //command.Parameters.AddWithValue("@qtkey", qtKey);
                //command.ExecuteScalar();
                //command.Parameters.Clear();

                //删除QT数据
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from qttaskindex where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                //回佣

                sqlTran.Commit();
                allQtTask.Remove(qtKey);
                OrderMgr.Instance().RemoveOrderByQtTask(qtKey);
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


        //添加新的业务员到QtTask
        public void AddNewEmployeeToQtTask(EmployeeData employeeData, QtTask qtTask)
        {
            if (qtTask.AllQtEmployee.ContainsKey(employeeData.JobNumber))
            {
                //已经存在了
                throw new CrashException(string.Format("顾问[{0}]已经存在与QT任务[{1}]里", employeeData.JobNumber, qtTask.QtKey));
            }
            QtEmployee qtEmployee = employeeData.GenerateQtEmployee();
            qtTask.AllQtEmployee.Add(qtEmployee.JobNumber, qtEmployee);

            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = @"INSERT INTO qttaskemployee(jobnumber,jobgradename,departmentid,qtlevel,isowner,qtkey) 
                                            VALUES(@jobnumber,@jobgradename, @departmentid, @qtlevel, @isowner, @qtkey)";
                command.Parameters.AddWithValue("@jobnumber", qtEmployee.JobNumber);
                command.Parameters.AddWithValue("@jobgradename", qtEmployee.JobGradeName);
                command.Parameters.AddWithValue("@departmentid", qtEmployee.DepartmentId);
                command.Parameters.AddWithValue("@qtlevel", (Int32)qtEmployee.QtLevel);
                command.Parameters.AddWithValue("@isowner", qtEmployee.IsOwner);
                command.Parameters.AddWithValue("@qtkey", qtTask.QtKey);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                
            }
            catch (Exception ex)
            {
                throw new CrashException(ex.Message);
            }
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
