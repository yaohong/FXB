using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FXB.Data;
using FXB.DataManager;
using FXB.Common;
namespace FXB.DataManager
{
    public class PayDataMgr
    {
        private static PayDataMgr ins;
        private SortedDictionary<string, SortedDictionary<string, PayData>> allQtPay;

        public SortedDictionary<string, SortedDictionary<string, PayData>> AllQtPay
        {
            get { return allQtPay; }
        }
        private PayDataMgr()
        {
            allQtPay = new SortedDictionary<string, SortedDictionary<string, PayData>>();
        }

        public static PayDataMgr Instance()
        {
            if (ins == null)
            {
                ins = new PayDataMgr();
            }

            return ins;
        }


        public void Load()
        {
            allQtPay.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from qtpay";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string qtKey = reader.GetString(0);
                    string jobNumber = reader.GetString(1);
                    double curPay = reader.GetDouble(2);
                    UInt32 generateTime = (UInt32)reader.GetInt32(3);
                    double oldPay = reader.GetDouble(4);
                    UInt32 oldGenerateTime = (UInt32)reader.GetInt32(5);

                    SortedDictionary<string, PayData> allPay = null;
                    if (allQtPay.ContainsKey(qtKey))
                    {
                        allPay = allQtPay[qtKey];
                    } else
                    {
                        allPay = new SortedDictionary<string, PayData>();
                        allQtPay[qtKey] = allPay;
                    }

                    allPay[jobNumber] = new PayData(qtKey, jobNumber, curPay, generateTime, oldPay, oldGenerateTime);
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
