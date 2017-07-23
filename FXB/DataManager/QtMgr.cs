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
        public DbQtTaskDepartment(Int64 tmpQtDepartmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, string tmpQtDepartmentName, Int64 tmpParentDepartmentId, double tmpNeedCompleteTaskAmount)
        {
            qtDepartmentId = tmpQtDepartmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            qtDepartmentName = tmpQtDepartmentName;
            parentDepartmentId = tmpParentDepartmentId;
            needCompleteTaskAmount = tmpNeedCompleteTaskAmount;
        }
    }

    public class DbQtTaskEmployee
    {
        private string jobNumber;
        private Int64 departmentId;
        private QtLevel qtLevel;
        private bool isOwner;

        public string JobNumber
        {
            get { return jobNumber; }
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
        public DbQtTaskEmployee(string tmpJobNumber, Int64 tmpDepartmentId, QtLevel tmpQtLevel, bool tmpIsOwner)
        {
            jobNumber = tmpJobNumber;
            departmentId = tmpDepartmentId;
            qtLevel = tmpQtLevel;
            isOwner = tmpIsOwner;
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
            try
            {

                //加载QTIndex
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
                    string qtKey = qtDepartmentReader.GetString(6);

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

                    allDepartment[qtdepartmentid] = new DbQtTaskDepartment(qtdepartmentid, qtLevel, ownerJobNumber, qtdepartmentname, parentQtDepartmentId, needCompleteTaskAmount);
                }
                qtDepartmentReader.Close();


                SqlCommand qtEmployeeCommand = new SqlCommand();
                qtEmployeeCommand.Connection = SqlMgr.Instance().SqlConnect;
                qtEmployeeCommand.CommandType = CommandType.Text;
                qtEmployeeCommand.CommandText = "select * from qttaskemployee";
                qtEmployeeReader = qtEmployeeCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<string, DbQtTaskEmployee>> dbAllQtTaskEmployee = new SortedDictionary<string, SortedDictionary<string, DbQtTaskEmployee>>();
                while (qtEmployeeReader.Read())
                {
                    string jobNumber = qtEmployeeReader.GetString(0);
                    Int64 qtdepartmentid = qtEmployeeReader.GetInt64(1);
                    QtLevel qtLevel = (QtLevel)qtEmployeeReader.GetInt32(2);
                    bool isOwner = qtEmployeeReader.GetBoolean(3);
                    string qtKey = qtEmployeeReader.GetString(4);

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

                    allEmployee[jobNumber] = new DbQtTaskEmployee(jobNumber, qtdepartmentid, qtLevel, isOwner);
                }
                qtEmployeeReader.Close();



                foreach (var item in dbAllQtTaskIndex)
                {
                    string qtKey = item.Key;
                    DbQtTaskIndex qtTaskIndexData = item.Value;

                    SortedDictionary<Int64, DbQtTaskDepartment> qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    SortedDictionary<string, DbQtTaskEmployee> qtTaskEmployeeData = dbAllQtTaskEmployee[qtKey];
                    QtTask qtTask = new QtTask(qtTaskIndexData, qtTaskDepartmentData, qtTaskEmployeeData);

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
                    command.CommandText = @"INSERT INTO qttaskdepartment(qtdepartmentid,qtlevel,ownerjobnumber,qtdepartmentname,parentdepartmentid,needcompletetaskamount,qtkey) 
                                            VALUES(@qtdepartmentid, @qtlevel, @ownerjobnumber, @qtdepartmentname, @parentdepartmentid, @needcompletetaskamount, @qtkey)";
                    command.Parameters.AddWithValue("@qtdepartmentid", qtDepartment.Id);
                    command.Parameters.AddWithValue("@qtlevel", (Int32)qtDepartment.QtLevel);
                    command.Parameters.AddWithValue("@ownerjobnumber", qtDepartment.OwnerJobNumber);
                    command.Parameters.AddWithValue("@qtdepartmentname", qtDepartment.DepartmentName);
                    command.Parameters.AddWithValue("@parentdepartmentid", qtDepartment.ParentDepartmentId);
                    command.Parameters.AddWithValue("@needcompletetaskamount", qtDepartment.NeedCompleteTaskAmount);
                    command.Parameters.AddWithValue("@qtkey", newQtTask.QtKey);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                Console.WriteLine("insert qtdepartment success");

                command.Parameters.Clear();
                foreach (var item in newQtTask.AllQtEmployee)
                {
                    QtEmployee qtDepartment = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO qttaskemployee(jobnumber,departmentid,qtlevel,isowner,qtkey) 
                                            VALUES(@jobnumber, @departmentid, @qtlevel, @isowner, @qtkey)";
                    command.Parameters.AddWithValue("@jobnumber", qtDepartment.JobNumber);
                    command.Parameters.AddWithValue("@departmentid", (Int32)qtDepartment.DepartmentId);
                    command.Parameters.AddWithValue("@qtlevel", (Int32)qtDepartment.QtLevel);
                    command.Parameters.AddWithValue("@isowner", qtDepartment.IsOwner);
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
