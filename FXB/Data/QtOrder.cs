﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Common;
namespace FXB.Data
{
    public class QtJob
    {
        private SortedDictionary<string, Int32> jobs;

        public SortedDictionary<string, Int32> Jobs
        {
            get { return jobs; }
        }

        public QtJob()
        {
            jobs = new SortedDictionary<string, Int32>();
        }

        public QtJob Clone()
        {
            QtJob newQtJob = new QtJob();
            foreach (var item in jobs)
            {
                newQtJob.Jobs[item.Key] = item.Value; 
            }

            return newQtJob;
        }


        public bool Exist(string job)
        {
            return jobs.ContainsKey(job);
        }

        public Int32 GetProp(string job)
        {
            return jobs[job];
        }

        public void SetProp(string job, Int32 newProp)
        {
            if (!jobs.ContainsKey(job))
            {
                throw new CrashException("不能修改比例,指定的业务顾问不存在," + job);
            }

            jobs[job] = newProp;

        }



        public void Add(string job, Int32 prop)
        {
            if (jobs.ContainsKey(job))
            {
                throw new CrashException("重复添加");
            }

            jobs[job] = prop;
        }
        public void Remove(string job)
        {
            jobs.Remove(job);
        }

        public string Encode()
        {
            int len = jobs.Count();
            string [] items = new string[len];
            int index = 0;
            foreach (var item in jobs)
            {
                string kv = string.Format("{0}:{1}", item.Key, item.Value);
                items[index++] = kv;
            }

            return string.Join("|", items);
        }


        //jobnumber1:pro1-jobnumber2:pro2
        public QtJob(string rawStr, bool kyf)
        {
            jobs = new SortedDictionary<string, Int32>();
            if (-1 == rawStr.IndexOf(":"))
            {
                //老版的jobnumber
                if (kyf)
                {
                    jobs[rawStr] = 9000;         //900/1000
                }
                else
                {
                    jobs[rawStr] = 10000;
                }
            }
            else
            {
                //新版的
                try
                {
                    string[] jps = rawStr.Split('|');
                    foreach(string jp in jps)
                    {
                        string[] items = jp.Split(':');
                        if (items.Count<string>() != 2 )
                        {
                            throw new Exception(string.Format("yxJob format error, {0}", rawStr));
                        }

                        string jobnumber = items[0];
                        string strProp = items[1];          //千分比
                        Int32 intProp = Convert.ToInt32(strProp);

                        if (jobs.ContainsKey(jobnumber))
                        {
                            throw new Exception(string.Format("yxJob format error, {0}", rawStr));
                        }

                        jobs[jobnumber] = intProp; 
                    }

                    if (!Check(kyf))
                    {
                        //检测错误
                        throw new Exception(string.Format("yxJob format error, {0}", rawStr));
                    }
                }
                catch (Exception e)
                {
                    throw new CrashException(e.Message);
                }

            }
        }

        public bool Check(bool kyf)
        {
            Int32 totoal = 0;
            foreach (var item in jobs)
            {
                totoal += item.Value;
            }

            if (kyf)
            {
                return totoal == 9000;
            }
            else
            {
                return totoal == 10000;
            }
        }
    }

    public class QtOrder
    {
        private Int64 orderId;                  //开单的ID

        private UInt32 generateTime;            //生成日期
        private double commissionAmount;        //佣金总额


        private string customerName;            //客户名称
        private string projectCode;             //所属的项目
        private string roomNumber;              //房号
        private double closingTheDealMoney;     //成交总价



//        private string yxConsultantJobNumber;
        private QtJob yxJobNumber;               //营销顾问
//        private Int64 yxQtDepartmentId;             //营销顾问所属的QT部门
//        private string yxLevelName;                 //营销顾问的职级
        private string kyfConsultanJobNumber;       //客源方顾问
//        private Int64 kyfQtDepartmentId;            //客源方所属的QT部门

        private string zc1JobNumber;                 //驻场1
//        private Int64 zc1QtDepartmentId;            //驻场1的QT部门ID
        private string zc2JobNumber;                 //驻场2
//        private Int64 zc2QtDepartmentId;            //驻场2的QT部门ID



        private bool checkState;                    //审核状态
        private string checkPersonJobNumber;        //审核人
        private UInt32 checkTime;                   //审核日期

        private TDData returnData;                  //退单数据

        private string entryPersonJobNumber;        //录入人

        private string comment;                     //备注

        private UInt32 buyTime;                     //购买日期
        private string customerPhone;               //客户联系电话
        private string customerIdCard;              //客户端的身份证
        private string receipt;                     //收据
        private double roomArea;                    //面积
        private string contractState;               //合同状态
        private string paymentMethod;               //付款方式
        private double loansMoney;                  //贷款金额

        private string qtKey;                       //所属的QT任务

        private SortedDictionary<Int64, HYData> allHYData;     //回佣数据

        public double CalcMonthHyWhenCheck(string qtKey)
        {
            string[] ym = qtKey.Split('-');

            Int32 qtYear = Convert.ToInt32(ym[0]);
            Int32 qtMonth = Convert.ToInt32(ym[1]);
            double totoal = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                DateTime hyDateTime = TimeUtil.TimestampToDateTime(data.AddTime);
                if (data.CheckState)
                {
                    if (hyDateTime.Month == qtMonth && hyDateTime.Year == qtYear)
                    {
                        //不是计算工资的年和月份
                        totoal += data.Amount;
                    }
                }
            }


            return totoal;
        }

        public double CalcMonthShuifeishouxufeiWhenCheck(string qtKey)
        {
            string[] ym = qtKey.Split('-');

            Int32 qtYear = Convert.ToInt32(ym[0]);
            Int32 qtMonth = Convert.ToInt32(ym[1]);
            double totoal = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                DateTime hyDateTime = TimeUtil.TimestampToDateTime(data.AddTime);
                if (data.CheckState)
                {
                    if (hyDateTime.Month == qtMonth && hyDateTime.Year == qtYear)
                    {
                        //不是计算工资的年和月份
                        totoal += (data.Shuifei + data.Shouxufei);
                    }
                }
            }


            return totoal;
        }

        //计算累计回佣(已审核)
        public double CalcAllHyWhenCheck()
        {
            double total = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                if (data.CheckState)
                {
                    total += data.Amount;
                }
            }

            return total;
        }

        public double CalcAllHyWhenNoCheck()
        {
            double total = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                if (!data.CheckState)
                {
                    total += data.Amount;
                }
            }

            return total;
        }

        public double CalcAllShouxufei()
        {
            double total = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                if (data.CheckState)
                {
                    total += data.Shouxufei;
                }
            }

            return total;
        }

        public double CalcAllShuifei()
        {
            double total = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                if (data.CheckState)
                {
                    total += data.Shuifei;
                }
            }

            return total;
        }

        //计算有效回佣(减去手续费和税费的回佣)
        public double CalcYouxiaohuiyong()
        {
            double total = 0;
            foreach (var item in allHYData)
            {
                HYData data = item.Value;
                if (data.CheckState)
                {
                    total += (data.Amount - data.Shouxufei - data.Shuifei);
                }
            }

            return total;
        }

        public SortedDictionary<Int64, HYData> AllHYData
        {
            get { return allHYData; }
        }
        public Int64 Id
        {
            get { return orderId; }
        }
        public string QtKey
        {
            get { return qtKey; }
        }

        public UInt32 GenerateTime
        {
            get { return generateTime; }
        }

        public double CommissionAmount
        {
            get { return commissionAmount; }
            set { commissionAmount = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public double ClosingTheDealMoney
        {
            get { return closingTheDealMoney; }
            set { closingTheDealMoney = value; }
        }

        public QtJob YxJob
        {
            get { return yxJobNumber; }
            set { yxJobNumber = value; }
        }

        //public Int64 YxQtDepartmentId
        //{
        //    get { return yxQtDepartmentId; }
        //    set { yxQtDepartmentId = value; }
        //}

        //public string YxLevelName
        //{
        //    get { return yxLevelName; }
        //    set { yxLevelName = value; }
        //}

 

        public string KyfConsultanJobNumber
        {
            get { return kyfConsultanJobNumber; }
            set { kyfConsultanJobNumber = value; }
        }

        //public Int64 KyfQtDepartmentId
        //{
        //    get { return kyfQtDepartmentId; }
        //    set { kyfQtDepartmentId = value; }
        //}

        public string Zc1JobNumber
        {
            get { return zc1JobNumber; }
            set { zc1JobNumber = value; }
        }

        //public Int64 Zc1QtDepartmentId
        //{
        //    get { return zc1QtDepartmentId; }
        //    set { zc1QtDepartmentId = value; }
        //}

        public string Zc2JobNumber
        {
            get { return zc2JobNumber; }
            set { zc2JobNumber = value; }
        }

        //public Int64 Zc2QtDepartmentId
        //{
        //    get { return zc2QtDepartmentId; }
        //    set { zc2QtDepartmentId = value; }
        //}

        public bool CheckState
        {
            get { return checkState; }
            set { checkState = value; }
        }

        public string CheckPersonJobNumber
        {
            get { return checkPersonJobNumber; }
            set { checkPersonJobNumber = value; }
        }

        public UInt32 CheckTime
        {
            get { return checkTime; }
            set { checkTime = value; }
        }

        public TDData ReturnData
        {
            set { returnData = value; }
            get { return returnData; }
        }

        public string EntryPersonJobNumber
        {
            get { return entryPersonJobNumber; }
            set { entryPersonJobNumber = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public UInt32 BuyTime
        {
            get { return buyTime; }
            set { buyTime = value; }
        }

        public string CustomerPhone
        {
            get { return customerPhone; }
            set { customerPhone = value; }
        }

        public string CustomerIdCard
        {
            get { return customerIdCard; }
            set { customerIdCard = value; }
        }

        public string Receipt
        {
            get { return receipt; }
            set { receipt = value; }
        }

        public double RoomArea
        {
            get { return roomArea; }
            set { roomArea = value; }
        }

        public string ContractState
        {
            get { return contractState; }
            set { contractState = value; }
        }

        public string PaymentMethod
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }


        public double LoansMoney
        {
            get { return loansMoney; }
            set { loansMoney = value; }
        }

        public QtOrder(
            Int64 tmpId,
            UInt32 tmpGenerateTime,
            double tmpCommissionAmount,
            string tmpCustomerName,
            string tmpProjectCode,
            string tmpRoomNumber,
            double tmpClosingTheDealmoney,

            string rawConsultantJobnumber,
            //Int64 tmpYxQtDepartmentId,          
            //string tmpYxLevelName,

            string tmpKyfConsultanJobnumber,       
            //Int64 tmpKyfQtDepartmentId,            
            string tmpZc1JobNumber,                
            //Int64 tmpZc1QtDepartmentId,            
            string tmpZc2JobNumber,                
            //Int64 tmpZc2QtDepartmentId,    
        
            bool tmpCheckState,
            string tmpCheckPersonJobnumber,
            UInt32 tmpCheckTime,

            string tmpEntryPersonJobnumber,

            string tmpComment,
            UInt32 tmpBuyTime,
            string tmpCustomerPhone,
            string tmpCustomerIdCard,
            string tmpReceipt,
            double tmpRoomArea,
            string tmpContractState,
            string tmpPaymentMethod,
            double tmploansMoney,

            string tmpQtKey)
        {
            orderId = tmpId;
            generateTime = tmpGenerateTime;
            commissionAmount = tmpCommissionAmount;
            customerName = tmpCustomerName;
            projectCode = tmpProjectCode;
            roomNumber = tmpRoomNumber;
            closingTheDealMoney = tmpClosingTheDealmoney;

            yxJobNumber = new QtJob(rawConsultantJobnumber, tmpKyfConsultanJobnumber != "");
            //yxQtDepartmentId = tmpYxQtDepartmentId;
            //YxLevelName = tmpYxLevelName;

            kyfConsultanJobNumber = tmpKyfConsultanJobnumber;
            //kyfQtDepartmentId = tmpKyfQtDepartmentId;
            zc1JobNumber = tmpZc1JobNumber;
            //zc1QtDepartmentId = tmpZc1QtDepartmentId;
            zc2JobNumber = tmpZc2JobNumber;
            //zc2QtDepartmentId = tmpZc2QtDepartmentId;

            checkState = tmpCheckState;
            checkPersonJobNumber = tmpCheckPersonJobnumber;
            checkTime = tmpCheckTime;

            entryPersonJobNumber = tmpEntryPersonJobnumber;

            comment = tmpComment;
            buyTime = tmpBuyTime;
            customerPhone = tmpCustomerPhone;
            customerIdCard = tmpCustomerIdCard;
            receipt = tmpReceipt;
            roomArea = tmpRoomArea;
            contractState = tmpContractState;
            paymentMethod = tmpPaymentMethod;
            loansMoney = tmploansMoney;

            qtKey = tmpQtKey;

            allHYData = new SortedDictionary<Int64, HYData>();
        }
    }
}
