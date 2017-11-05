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

                    SortedDictionary<string, PayData> allPay = null;
                    if (allQtPay.ContainsKey(qtKey))
                    {
                        allPay = allQtPay[qtKey];
                    } else
                    {
                        allPay = new SortedDictionary<string, PayData>();
                        allQtPay[qtKey] = allPay;
                    }

                    allPay[jobNumber] = new PayData(qtKey, jobNumber, curPay, generateTime);
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


        public void GeneratePay(
            string qtKey, 
            SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> hyPay)
        {
            if (allQtPay.ContainsKey(qtKey))
            {
                //工资已经存在了
                //删除覆盖
            }
            else
            {
                //工资不存在
                SortedDictionary<string, PayData> qtPay = new SortedDictionary<string, PayData>();
                foreach (var jobnumberItem in hyPay)
                {
                    string jobnumber = jobnumberItem.Key;
                    SortedDictionary<Int64, List<PayItem>> hyValueItem = jobnumberItem.Value;

                    //基本工资
                    double basicPay = 0;
                    foreach (var hyItem in hyValueItem)
                    {
                        foreach (var payItem in hyItem.Value)
                        {
                            basicPay += payItem.money;
                        }
                    }

                    ////查看是否有底薪工资
                    //if (dxPay.ContainsKey(jobnumber))
                    //{
                    //    //有底薪奖励
                    //    //
                    //    foreach (var dxItem in dxPay[jobnumber])
                    //    {
                    //        basicPay += dxItem.Value;
                    //    }
                    //}

                    PayData newPayData = new PayData(qtKey, jobnumber, basicPay, TimeUtil.DateTimeToTimestamp(DateTime.Now));
                    qtPay[jobnumber] = newPayData;
                }

                allQtPay[qtKey] = qtPay;
            }
        }
    }
}
