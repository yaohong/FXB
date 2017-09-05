using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using FXB.Data;
using FXB.DataManager;
using FXB.Common;
namespace FXB.DataManager
{
    public class DxDuplicateMgr
    {
        private static DxDuplicateMgr ins;
        private SortedDictionary<string, DxDuplicate> allDxDuplicate;
        private DxDuplicateMgr()
        {
            allDxDuplicate = new SortedDictionary<string, DxDuplicate>();
        }

        public static DxDuplicateMgr Instance()
        {
            if (ins == null)
            {
                ins = new DxDuplicateMgr();
            }

            return ins;
        }
        public SortedDictionary<string, DxDuplicate> AllDxDuplicate
        {
            get { return allDxDuplicate; }
        }

        public void Load()
        {
            allDxDuplicate.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from dxduplicate";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string jobNumber = reader.GetString(0);
                    double basicsalary = reader.GetDouble(1);
                    string dxKey = reader.GetString(2);

                    DxDuplicate dup;
                    if (!allDxDuplicate.ContainsKey(dxKey))
                    {
                        dup = new DxDuplicate(dxKey);
                        allDxDuplicate[dxKey] = dup;
                    }
                    else
                    {
                        dup = allDxDuplicate[dxKey];
                    }

                    dup.Add(jobNumber, basicsalary);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                System.Environment.Exit(0);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }
        }

        public DxDuplicate AddNewDxDuplicate(string dxKey)
        {
            //添加新的副本

            if (allDxDuplicate.ContainsKey(dxKey))
            {
                throw new ConditionCheckException(string.Format("底薪副本已经存在"));
            }
            DxDuplicate newDup = new DxDuplicate(dxKey, true);
            SqlTransaction sqlTran = null; 
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                command.CommandType = CommandType.Text;
                foreach (var item in newDup.AllDx)
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO dxduplicate(jobnumber,basicsalary,dxkey) 
                                            VALUES(@jobnumber, @basicsalary, @dxkey)";
                    command.Parameters.AddWithValue("@jobnumber", item.Key);
                    command.Parameters.AddWithValue("@basicsalary", item.Value);
                    command.Parameters.AddWithValue("@dxkey", dxKey);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                sqlTran.Commit();
                allDxDuplicate[dxKey] = newDup;
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }

            return newDup;
        }

        public void RemoveDxDuplicate(string dxKey)
        {
            SqlTransaction sqlTran = null;
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;


                command.CommandType = CommandType.Text;
                command.CommandText = "delete from dxduplicate where dxkey=@dxkey";
                command.Parameters.AddWithValue("@dxkey", dxKey);
                command.ExecuteScalar();
                command.Parameters.Clear();


                sqlTran.Commit();
                allDxDuplicate.Remove(dxKey);
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
    }
}
