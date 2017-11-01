using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class ImportSalaryData
    {
        private string jobnumber;
        private string qtkey;
        public double dixinjishu;              //底薪基数
        public double qitabuzhu;               //其他补助
        public Int32 jixintianshu;             //计薪天数
        public Int32 shijia;                   //事假
        public Int32 bingjia;                  //病假

        public double shijidixin;              //实际底薪
        public double jianglidixin;            //奖励底薪
        public double duankoubuzhu;            //端口补助
        public double gonglinggongzi;          //工龄工资
        public double tuidankoubuzhu;         //退单扣补助
        public double decGongzhuang;           //减工装
        public double decGongpailingdai;       //减工牌领带
        public double decGongjijin;            //减公积金
        public double decShebao;               //减社保
        public double otherkoukuan;            //其他扣款
        public double gongzizonge;             //工资总额
        public string beizhu;                  //备注

        public ImportSalaryData(string tmpJobnumber, string tmpQtKey)
        {
            jobnumber = tmpJobnumber;
            qtkey = tmpQtKey;

        }

        public string Jobnumber
        {
            get { return jobnumber; }
        }

        public string QtKey
        {
            get { return qtkey; }
        }
    }

    public class SingleImportSalary
    {
        private string qtKey;
        private SortedDictionary<string, ImportSalaryData> allImportSalaryData;
        public SingleImportSalary(string tmpQtKey)
        {
            allImportSalaryData = new SortedDictionary<string, ImportSalaryData>();
            qtKey = tmpQtKey;
        }

        public SortedDictionary<string, ImportSalaryData> AllImportSalaryData
        {
            get { return allImportSalaryData; }
        }

        public string QtKey 
        {
            get { return qtKey;}
        }

    }
}
