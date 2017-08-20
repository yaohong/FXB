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
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from qttaskindex";
                reader = command.ExecuteReader();
                while (reader.Read())
                {

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

        public SortedDictionary<string, QtTask> AllQtTask
        {
            get { return allQtTask; }
        }
    }
}
