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
        private Int64 parentDepartmentId;
        private float needCompleteTaskAmount;

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

        public Int64 ParentDepartmentId
        {
            get { return parentDepartmentId; }
        }

        public float NeedCompleteTaskAmount
        {
            get { return needCompleteTaskAmount; }
        }
        public DbQtTaskDepartment(Int64 tmpQtDepartmentId, QtLevel tmpQtLevel, string tmpOwnerJobNumber, Int64 tmpParentDepartmentId, float tmpNeedCompleteTaskAmount)
        {
            qtDepartmentId = tmpQtDepartmentId;
            qtLevel = tmpQtLevel;
            ownerJobNumber = tmpOwnerJobNumber;
            parentDepartmentId = tmpParentDepartmentId;
            needCompleteTaskAmount = tmpNeedCompleteTaskAmount;
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
                qtDepartmentCommand.CommandText = "select * from qttaskdata";
                qtDepartmentReader = qtDepartmentCommand.ExecuteReader();
                SortedDictionary<string, SortedDictionary<Int64, DbQtTaskDepartment> > dbAllQtTaskDepartment = new SortedDictionary<string, SortedDictionary<Int64, DbQtTaskDepartment> >();
                while (qtDepartmentReader.Read())
                {
                    Int64 qtdepartmentid = qtDepartmentReader.GetInt64(0);
                    QtLevel qtLevel = (QtLevel)qtDepartmentReader.GetInt32(1);
                    string ownerJobNumber = qtDepartmentReader.GetString(2);
                    Int64 parentQtDepartmentId = qtDepartmentReader.GetInt64(3);
                    float needCompleteTaskAmount = qtDepartmentReader.GetFloat(4);
                    string qtKey = qtDepartmentReader.GetString(5);

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

                    allDepartment[qtdepartmentid] = new DbQtTaskDepartment(qtdepartmentid, qtLevel, ownerJobNumber, parentQtDepartmentId, needCompleteTaskAmount);
                }
                qtDepartmentReader.Close();


                foreach (var item in dbAllQtTaskIndex)
                {
                    string qtKey = item.Key;
                    DbQtTaskIndex qtTaskIndexData = item.Value;

                    SortedDictionary<Int64, DbQtTaskDepartment> qtTaskDepartmentData = dbAllQtTaskDepartment[qtKey];
                    QtTask qtTask = new QtTask(qtTaskIndexData, qtTaskDepartmentData);

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

                foreach (var item in newQtTask.AllQtDepartment)
                {
                    QtDepartment qtDepartment = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO qttaskdata(qtdepartmentid,qtlevel,ownerjobnumber,parentdepartmentid,needcompletetaskamount,qtkey) 
                                            VALUES(@qtdepartmentid, @qtlevel, @ownerjobnumber, @parentdepartmentid, @needcompletetaskamount, @qtkey)";
                    command.Parameters.AddWithValue("@qtdepartmentid", qtDepartment.Id);
                    command.Parameters.AddWithValue("@qtlevel", (Int32)qtDepartment.QtLevel);
                    command.Parameters.AddWithValue("@ownerjobnumber", qtDepartment.OwnerJobNumber);
                    command.Parameters.AddWithValue("@parentdepartmentid", qtDepartment.ParentDepartmentId);
                    command.Parameters.AddWithValue("@needcompletetaskamount", qtDepartment.NeedCompleteTaskAmount);
                    command.Parameters.AddWithValue("@qtkey", newQtTask.QtKey);
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("insert qtdepartment success");

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
    }
}
