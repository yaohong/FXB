using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FXB.Common
{
    class SqlMgr
    {
        private static SqlMgr ins;
        private string dbIp;
        private UInt16 dbPort;
        private string dbAcc;
        private string dbPwd;
        private string dbName;
        private SqlMgr()
        {
            dbIp = "127.0.0.1";
            dbPort = 3306;
            dbAcc = "yaohong";
            dbPwd = "231344781";
            dbName = "MFXB";
        }

        public static SqlMgr Instance()
        {
            if (ins == null)
            {
                ins = new SqlMgr();
            }

            return ins;
        }

        public void Init()
        {
            string connectStr = "user id=yaohong;password=yaohong19861005;database=MFXB;Server=YAOHONG-PC\\YAOHONG;Connect Timeout=5";
            SqlConnection cl = new SqlConnection(connectStr);
            try
            {
                cl.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cl;

                command.CommandType = CommandType.Text;
                command.CommandText = "select * from  department";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Int64 id = reader.GetInt64(0);
                    Int64 nid = reader.GetInt64(1);
                    string name = reader.GetString(2);
                    string owner = reader.GetString(3);
                    Int32 qtLevel = reader.GetInt32(4);
                }
            }
            catch (Exception e )
            {
                string msg = e.Message;
                return;
            }
            
            
        }
    }
}
