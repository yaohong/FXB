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
    public class TDMgr
    {
        private static TDMgr ins;
        //private SortedSet<Int64> allTDData;
        //public SortedSet<Int64> AllTDData
        //{
        //    get { return allTDData; }
        //}
        private TDMgr()
        {
            //allTDData = new SortedSet<Int64>();
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
                    //allTDData.Add(orderid);
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
        
        public void UpdateState(Int64 tdId, bool isreturn, string jobnumer, UInt32 time)
        {
            QtOrder qtOrder = OrderMgr.Instance().AllOrderData[tdId];
            TDData tdData = qtOrder.ReturnData;
            if (tdData.IsReturn == isreturn)
            {
                return;
            }

            //QtTask qtTask = QtMgr.Instance().AllQtTask[qtOrder.QtKey];
            //if (isreturn && qtOrder.CheckState && qtTask.Closing)
            //{
            //    if (DialogResult.OK != MessageBox.Show("订单所属的QT任务已经结算,如果退单，提成需要被重新计算", "警告", MessageBoxButtons.OKCancel))
            //    {
            //        return;
            //    }

            //    QtMgr.Instance().ClearQtCommission(qtOrder.QtKey);
            //}



            SqlCommand command = new SqlCommand();
            command.Connection = SqlMgr.Instance().SqlConnect;
            command.CommandType = CommandType.Text;
            command.CommandText = "update qtordertd set isreturn=@isreturn,returnjobnumber=@returnjobnumber,returntime=@returntime where orderid=@orderid";
            command.Parameters.AddWithValue("@isreturn", isreturn);
            command.Parameters.AddWithValue("@returnjobnumber", jobnumer);
            command.Parameters.AddWithValue("@returntime", (Int32)time);
            command.Parameters.AddWithValue("@orderid", tdId);
            command.ExecuteNonQuery();

            tdData.IsReturn = isreturn;
            tdData.ReturnJobnumber = jobnumer;
            tdData.ReturnTime = time;
        }
    }
}
