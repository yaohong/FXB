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
    // insert into auth(pwd, opermask, prohibit,ifowner,viewlevel, jobnumber) select '123456',0, 0, 0,2, gonghao from employee
    class AuthMgr
    {
        private static AuthMgr ins;
        private EmployeeData curLoginEmployee = null;
        public EmployeeData CurLoginEmployee
        {
            get { return curLoginEmployee; }
            set { curLoginEmployee = value; }
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

        public void Load()
        {
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from auth";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string jobnumber = reader.GetString(0);
                    string pwd = reader.GetString(1);
                    Int64 opermask = reader.GetInt64(2);
                    bool prohibit = reader.GetBoolean(3);
                    bool ifowner = reader.GetBoolean(4);
                    Int32 viewlevel = reader.GetInt32(5);

                    AuthData authData = new AuthData(jobnumber, pwd, opermask, prohibit, ifowner, viewlevel);
                    EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[jobnumber];
                    employeeData.AuthData = authData;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Exit();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

            }

        }

        public void ChangePassword(string jobNumber, string newPwd)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update auth set pwd=@pwd where jobnumber=@jobnumber";
            command.Parameters.AddWithValue("@pwd", newPwd);
            command.Parameters.AddWithValue("@jobnumber", jobNumber);
            command.ExecuteScalar();
        }

        public void ChangeAuthAttr(string jobNumber, Int64 operMake, bool prohibit, Int32 viewLevel)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update auth set opermask=@opermask,prohibit=@prohibit,viewlevel=@viewlevel where jobnumber=@jobnumber";
            command.Parameters.AddWithValue("@opermask", operMake);
            command.Parameters.AddWithValue("@prohibit", prohibit);
            command.Parameters.AddWithValue("@viewlevel", viewLevel);
            command.Parameters.AddWithValue("@jobnumber", jobNumber);
            command.ExecuteScalar();
        }

    }
}
