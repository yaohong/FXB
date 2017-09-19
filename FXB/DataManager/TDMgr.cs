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
    // insert into auth(isreturn, returnjobnumber, returntime,ischeck,checkjobnumber, checktime, orderid) select 0,'', 0, 0,'',0 gonghao from employee
    class TDMgr
    {
        private static TDMgr ins;
        private SortedSet<Int64> allTDData;
        public SortedSet<Int64> AllTDData
        {
            get { return allTDData; }
        }
        private TDMgr()
        {
            allTDData = new SortedSet<Int64>();
        }

        public static TDMgr Instance()
        {
            if (ins == null)
            {
                ins = new TDMgr();
            }

            return ins;
        }

        public void Load()
        {


            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from qtordertd";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Int64 orderid = reader.GetInt64(0);
                    bool isreturn = reader.GetBoolean(1);
                    string returnjobnumber = reader.GetString(2);
                    UInt32 returntime = (UInt32)reader.GetInt32(3);

                    TDData tdData = new TDData(orderid, isreturn, returnjobnumber, returntime);
                    QtOrder order = OrderMgr.Instance().AllOrderData[orderid];
                    order.ReturnData = tdData;
                    allTDData.Add(orderid);
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
    }
}
