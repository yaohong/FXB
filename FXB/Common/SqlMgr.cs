using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using FXB.DataManager;
using FXB.Data;
namespace FXB.Common
{
    class SqlMgr
    {
        private static SqlMgr ins;
        private string connectStr;
        private SqlConnection sqlConnect;
        private SqlMgr()
        {
            connectStr = "uid=yaohong;password=231344781;database=MFXB;Server=172.16.3.25;Connect Timeout=1";
            //connectStr = "uid=yaohong;password=231344781;database=MFXB;Server=61.183.235.222,1499;Connect Timeout=1";
            //connectStr = "user id=yaohong;password=231344781;database=MFXB;Server=127.0.0.1;Connect Timeout=1";
        }

        public static SqlMgr Instance()
        {
            if (ins == null)
            {
                ins = new SqlMgr();
            }

            return ins;
        }

        public SqlConnection SqlConnect
        {
            get { return sqlConnect; }
        }

        public void Init()
        {
            sqlConnect = new SqlConnection(connectStr);
            sqlConnect.Open();
        }
    }
}
