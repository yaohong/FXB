using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FXB.DataManager;
using FXB.Data;
using FXB.Common;

namespace FXB.DataManager
{
    //批量给账号添加权限的SQL语句
    // insert into auth(pwd, opermask, prohibit,ifowner, jobnumber) select '123456',0, 0, 0, gonghao from employee
    class AuthMgr
    {
        private static AuthMgr ins;
        private AuthData curLoginAuth = null;
        public AuthData CurLoginAuth
        {
            get { return curLoginAuth; }
            set { curLoginAuth = value; }
        }
        private AuthMgr()
        {
           
        }

        public static AuthMgr Instance()
        {
            if (ins == null)
            {
                ins = new AuthMgr();
            }

            return ins;
        }

        public AuthData GetAuth(string jobNumber)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from auth where jobnumber=@jobnumber";
                command.Parameters.AddWithValue("@jobnumber", jobNumber);
                reader = command.ExecuteReader();
                if (!reader.Read())
                {
                    throw new ConditionCheckException("工号不存在");
                }

                string pwd = reader.GetString(1);
                Int64 operMake = reader.GetInt64(2);
                bool prohibit = reader.GetBoolean(3);
                bool ifowner = reader.GetBoolean(4);

                AuthData loginAuth = new AuthData(jobNumber, pwd, operMake, prohibit, ifowner);
                return loginAuth;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }
        }
    }
}
