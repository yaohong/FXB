﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class HYData
    {
        private Int64 id;           //回佣ID
        private Int64 orderId;      //所属的订单ID
        private double amount;      //回佣金额
        private UInt32 addTime;     //回佣添加时间
        private string entryJobNumber;  //录入人

        private bool checkState;        //是否审核
        private string checkJobNumber;  //审核人
        private UInt32 checkTime;       //审核时间

        private bool isSettlement;          //是否结算(工资发放)

        public Int64 Id
        {
            get { return id; }
        }

        public Int64 OrderId
        {
            get { return orderId; }
        }

        public double Amount
        {
            get { return amount; }
        }

        public UInt32 AddTime
        {
            get { return addTime; }
        }

        public string EntryJobNumber
        {
            get { return entryJobNumber; }
        }

        public bool CheckState
        {
            get { return checkState; }
            set { checkState = value; }
        }

        public string CheckJobNumber
        {
            get { return checkJobNumber; }
            set { checkJobNumber = value; }
        }

        public UInt32 CheckTime
        {
            get { return checkTime; }
            set { checkTime = value; }
        }

        public bool IsSettlement
        {
            get { return isSettlement; }
        }

        public HYData(Int64 tmpId, Int64 tmpOrderId, double tmpAmount, UInt32 tmpAddTime, string tmpEntryJobNumber, bool tmpCheckState, string tmpCheckJobNumber, UInt32 tmpCheckTime, bool tmpIsSettlement)
        {
            id = tmpId;
            orderId = tmpOrderId;
            amount = tmpAmount;
            addTime = tmpAddTime;
            entryJobNumber = tmpEntryJobNumber;
            checkState = tmpCheckState;
            checkJobNumber = tmpCheckJobNumber;
            checkTime = tmpCheckTime;
            isSettlement = tmpIsSettlement;
        }



    }
}