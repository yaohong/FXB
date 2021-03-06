﻿using System;
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

        public void AddNewImportSalaryToDb(string qtKey)
        {
            if (!allSingleImportSalary.ContainsKey(qtKey))
            {
                throw new CrashException(string.Format("指定的导入工资[{0}]不存在", qtKey));
            }

            SingleImportSalary single = allSingleImportSalary[qtKey];

            SqlTransaction sqlTran = null; 
            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();

                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                command.Parameters.Clear();
                foreach (var item in single.AllImportSalaryData)
                {
                    ImportSalaryData salayData = item.Value;
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO importsalary(
                                            jobnumber,
                                            qtkey,
                                            dixinjishu,
                                            qitabuzhu,
                                            jixintianshu,
                                            shijia,
                                            bingjia,
                                            shijidixin,
                                            jianglidixin,
                                            duankoubuzhu,
                                            gonglinggongzi,
                                            tuidankoubuzhu,
                                            jiangongzhuang,
                                            jiangongpailingdai,
                                            jiangongjijin,
                                            jianshebao,
                                            qitakoukuan,
                                            gongzizonge,
                                            beizhu
                                            ) VALUES (
                                            @jobnumber, 
                                            @qtkey, 
                                            @dixinjishu, 
                                            @qitabuzhu, 
                                            @jixintianshu, 
                                            @shijia, 
                                            @bingjia,
                                            @shijidixin,
                                            @jianglidixin,
                                            @duankoubuzhu,
                                            @gonglinggongzi,
                                            @tuidankoubuzhu,
                                            @jiangongzhuang,
                                            @jiangongpailingdai,
                                            @jiangongjijin,
                                            @jianshebao,
                                            @qitakoukuan,
                                            @gongzizonge,
                                            @beizhu)";
                    command.Parameters.AddWithValue("@jobnumber", salayData.Jobnumber);
                    command.Parameters.AddWithValue("@qtkey", salayData.QtKey);
                    command.Parameters.AddWithValue("@dixinjishu", salayData.dixinjishu);
                    command.Parameters.AddWithValue("@qitabuzhu", salayData.qitabuzhu);
                    command.Parameters.AddWithValue("@jixintianshu", salayData.jixintianshu);
                    command.Parameters.AddWithValue("@shijia", salayData.shijia);
                    command.Parameters.AddWithValue("@bingjia", salayData.bingjia);
                    command.Parameters.AddWithValue("@shijidixin", salayData.shijidixin);
                    command.Parameters.AddWithValue("@jianglidixin", salayData.jianglidixin);
                    command.Parameters.AddWithValue("@duankoubuzhu", salayData.duankoubuzhu);
                    command.Parameters.AddWithValue("@gonglinggongzi", salayData.gonglinggongzi);
                    command.Parameters.AddWithValue("@tuidankoubuzhu", salayData.tuidankoubuzhu);
                    command.Parameters.AddWithValue("@jiangongzhuang", salayData.decGongzhuang);
                    command.Parameters.AddWithValue("@jiangongpailingdai", salayData.decGongpailingdai);
                    command.Parameters.AddWithValue("@jiangongjijin", salayData.decGongjijin);
                    command.Parameters.AddWithValue("@jianshebao", salayData.decShebao);
                    command.Parameters.AddWithValue("@qitakoukuan", salayData.otherkoukuan);
                    command.Parameters.AddWithValue("@gongzizonge", salayData.gongzizonge);
                    command.Parameters.AddWithValue("@beizhu", salayData.beizhu);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                sqlTran.Commit();
            }
            catch (Exception e1)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(e1.Message);
            }
            
        }

        public void DeleteImportSalaryByTb(string qtKey)
        {
            if (!allSingleImportSalary.ContainsKey(qtKey))
            {
                throw new CrashException(string.Format("要删除的导入工资[{0}]不存在", qtKey));
            }

            SingleImportSalary single = allSingleImportSalary[qtKey];

            SqlTransaction sqlTran = null;

            try
            {
                sqlTran = SqlMgr.Instance().SqlConnect.BeginTransaction();
                SqlCommand command = new SqlCommand();
                command.Connection = SqlMgr.Instance().SqlConnect;
                command.Transaction = sqlTran;

                command.CommandType = CommandType.Text;
                command.CommandText = "delete from importsalary where qtkey=@qtkey";
                command.Parameters.AddWithValue("@qtkey", qtKey);
                command.ExecuteScalar();
                command.Parameters.Clear();

                sqlTran.Commit();
            }
            catch (Exception ex)
            {
                if (sqlTran != null)
                {
                    sqlTran.Rollback();
                }
                throw new CrashException(ex.Message);
            }
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
