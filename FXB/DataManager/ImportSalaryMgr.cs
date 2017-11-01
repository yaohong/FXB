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
    public class ImportSalaryMgr
    {
        private static ImportSalaryMgr ins;
        private SortedDictionary<string, SingleImportSalary> allSingleImportSalary;
        private ImportSalaryMgr()
        {
            allSingleImportSalary = new SortedDictionary<string, SingleImportSalary>();
        }

        public static ImportSalaryMgr Instance()
        {
            if (ins == null)
            {
                ins = new ImportSalaryMgr();
            }

            return ins;
        }

        public SortedDictionary<string, SingleImportSalary> AllImportSalary
        {
            get { return allSingleImportSalary; }
        }

        public void Load()
        {
            allSingleImportSalary.Clear();
            //重新从数据库里加载
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from importsalary";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string jobNumber = reader.GetString(0);
                    string qtkey = reader.GetString(1);
                    double dixinjishu = reader.GetDouble(2);
                    double qitabuzhu = reader.GetDouble(3);
                    Int32 jixintianshu = reader.GetInt32(4);
                    Int32 shijia = reader.GetInt32(5);
                    Int32 bingjia = reader.GetInt32(6);
                    double shixjdixin = reader.GetDouble(7);
                    double jianglidixin = reader.GetDouble(8);
                    double duankoubuzhu = reader.GetDouble(9);
                    double gonglinggongzi = reader.GetDouble(10);
                    double tuidankoubuzhu = reader.GetDouble(11);
                    double jiangongzhuang = reader.GetDouble(12);
                    double jiangongpailingdai = reader.GetDouble(13);
                    double jiangongjijin = reader.GetDouble(14);
                    double jianshebao = reader.GetDouble(15);
                    double qitakoukuan = reader.GetDouble(16);
                    double gongzizonge = reader.GetDouble(17);
                    string beizhu = reader.GetString(18);

                    ImportSalaryData isData = new ImportSalaryData(jobNumber, qtkey);
                    isData.dixinjishu = dixinjishu;
                    isData.qitabuzhu = qitabuzhu;
                    isData.jixintianshu = jixintianshu;
                    isData.shijia = shijia;
                    isData.bingjia = bingjia;
                    isData.shijidixin = shixjdixin;
                    isData.jianglidixin = jianglidixin;
                    isData.duankoubuzhu = duankoubuzhu;
                    isData.gonglinggongzi = gonglinggongzi;
                    isData.tuidankoubuzhu = tuidankoubuzhu;
                    isData.decGongzhuang = jiangongzhuang;
                    isData.decGongpailingdai = jiangongpailingdai;
                    isData.decGongjijin = jiangongjijin;
                    isData.decShebao = jianshebao;
                    isData.otherkoukuan = qitakoukuan;
                    isData.gongzizonge = gongzizonge;
                    isData.beizhu = beizhu;

                    SingleImportSalary single;
                    if (!allSingleImportSalary.ContainsKey(qtkey))
                    {
                        single = new SingleImportSalary(qtkey);
                        allSingleImportSalary[qtkey] = single;
                    }
                    else
                    {
                        single = allSingleImportSalary[qtkey];
                    }

                    single.AllImportSalaryData[jobNumber] = isData;
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
