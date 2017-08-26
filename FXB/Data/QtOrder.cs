using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    public class QtOrder
    {
        public Int64 orderId;                  //开单的ID

        public UInt32 generateTime;            //生成日期
        public double commissionAmount;        //佣金总额


        public string customerName;            //客户名称
        public string projectName;             //所属的项目名称
        public string roomNumber;              //房号
        public double closingTheDealMoney;     //成交总价




        public string yxConsultantJobNumber;        //营销顾问
        public Int64 yxQtDepartmentId;             //营销顾问所属的QT部门
        //private double yxAchievements;              //本单业绩

        public string kyfConsultanJobNumbert;       //客源方顾问
        public Int64 kyfQtDepartmentId;            //客源方所属的QT部门
        //private double kyfAchievements;             //客源方的业绩

        public string zcJobNumber;          //驻场1
        public Int64 zc1QtDepartmentId;            //驻场1的QT部门ID
        public string zc2JobNumber;          //驻场2
        public Int64 zc2QtDepartmentId;            //驻场2的QT部门ID



        public bool checkState;                    //审核状态
        public string checkPersonJobNumber;        //审核人
        public UInt32 checkTime;                   //审核日期


        public string entryPersonJobNumber;        //录入人

        public string commend;                     //备注

        public UInt32 buyTime;                     //购买日期
        public string customerPhone;               //客户联系电话
        public string customerIdCard;              //客户端的身份证
        public string receipt;                     //收据
        public double roomArea;                    //面积
        public string contractState;               //合同状态
        public string paymentMethod;               //付款方式
        public double loansMoney;                  //贷款金额

        public string qtKey;                       //所属的QT任务
    }
}
