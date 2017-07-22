using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXB.Data
{
    class QtOrder
    {
        private Int64 orderId;  //开单的ID
        private UInt32 generateTime;    //生成日期
        private string roomNumber;      //房号
        private string projectName;     //所属的项目名称
        private double commissionAmount;   //佣金总额

        private string yxConsultantJobNumber;        //营销顾问
        private Int64 yxQtDepartmentId;     //营销顾问所属的QT部门
        private double yxAchievements;      //本单业绩

        private string kyfConsultanJobNumbert;       //客源方顾问
        private Int64 kyfQtDepartmentId;    //客源方所属的QT部门
        private double kyfAchievements;     //客源方的业绩

        private string zhuchang1JobNumber;           //驻场1
        private Int64 zc1QtDepartmentId;    //驻场1的QT部门ID
        private string zhuchang2JobNumber;           //驻场2
        private Int64 zc2QtDepartmentId;    //驻场2的QT部门ID

        private string commend;             //备注

        private bool checkState;                 //审核状态
        private string checkPersonJobNumber;              //审核人
        private UInt32 checkTime;                //审核日期


        private string entryPersonJobNumber;                 //录入人


        private string customerName;                //客户名称
        private UInt32 buyTime;                     //购买日期
        private string customerPhone;               //客户联系电话
        private string customerIdCard;              //客户端的身份证

        private string receipt;                     //收据
        private double roomArea;                    //面积
        private double closingTheDealMoney;         //成交总价
        private string contractState;               //合同状态
        private string paymentMethod;               //付款方式
        private double loansMoney;                  //贷款金额

        private string qtKey;                       //所属的QT任务
    }
}
