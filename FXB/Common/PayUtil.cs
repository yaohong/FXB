using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FXB.Data;
using FXB.DataManager;
namespace FXB.Common
{

    public class HYCount
    {
        public List<Int64> oldHyId;
        public List<Int64> curHyId;
        public string levelName;
        public HYCount(string tmpLevelName)
        {
            oldHyId = new List<Int64>();
            curHyId = new List<Int64>();

            levelName = tmpLevelName;
        }
    }

    public enum PayType
    {
        PT_COMMISSION_PAY = 0,          //提成工资
        PT_LEVEL_COMMISSION_PAY = 1,    //级别提成工资
        PT_LEVEL_PAY = 2                //级别工资
    }
    public class PayItem
    {

        public PayType type;
        public double money;
        public PayItem(PayType pt, double tmpMoney)
        {
            type = pt;
            money = tmpMoney;
        }
    }
    
    public class PayUtil
    {
        public static void GeneratePay(
            string qtKey,                                                               //月份
            ref SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> hyPay,        //回佣的工资 工号=>(回佣id=>获取的提成)
            ref SortedDictionary<string, SortedDictionary<string, double>> dxPay        //奖励底薪  工号=>(QTKey=>奖励底薪)
            )
        {

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];
            if (!qtTask.Closing)
            {
                throw new ConditionCheckException(string.Format("QT任务[{0}]没有生成提成，不能计算工资", qtKey));
            }

            string[] ym = qtKey.Split('-');

            Int32 qtYear = Convert.ToInt32(ym[0]);
            Int32 qtMonth = Convert.ToInt32(ym[1]);

            //查找当月回佣
            List<HYData> validAllHy = new List<HYData>();
            SortedDictionary<string, SortedDictionary<string, HYCount>> curStatHy = new SortedDictionary<string, SortedDictionary<string, HYCount>>();
            foreach (var hyItem in HYMgr.Instance().AllHYData)
            {
                HYData hyData = hyItem.Value;
                if (!hyData.CheckState)
                {
                    //没有审核
                    continue;
                }

                //是当月的回佣
                QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];
                if (order.ReturnData.IsReturn)
                {
                    //所属的订单已经退单了
                    continue;
                }

                //查看HY的添加时间
                DateTime dateTime = TimeUtil.TimestampToDateTime(hyData.AddTime);
                if (dateTime.Month != qtMonth || dateTime.Year != qtYear)
                {
                    //不当月的回佣
                    continue;
                }



                SortedDictionary<string, HYCount> jobItem = null;
                if (curStatHy.ContainsKey(order.YxConsultantJobNumber))
                {
                    jobItem = curStatHy[order.YxConsultantJobNumber];
                }
                else
                {
                    jobItem = new SortedDictionary<string, HYCount>();
                    curStatHy[order.YxConsultantJobNumber] = jobItem;
                }

                if (!jobItem.ContainsKey(order.QtKey))
                {
                    jobItem[order.QtKey] = new HYCount(order.YxLevelName);
                }
                validAllHy.Add(hyData);
            }

            //计算这个月要发放的奖励底薪
            foreach (var hyItem in HYMgr.Instance().AllHYData)
            {
                HYData hyData = hyItem.Value;
                if (!hyData.CheckState)
                {
                    //没有审核
                    continue;
                }

                QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];

                if (order.ReturnData.IsReturn)
                {
                    //所属的订单已经退单了
                    continue;
                }

                if (!curStatHy.ContainsKey(order.YxConsultantJobNumber))
                {
                    continue;
                }


                SortedDictionary<string, HYCount> jobItem = curStatHy[order.YxConsultantJobNumber];
                if (!jobItem.ContainsKey(order.QtKey))
                {
                    continue;
                }

                HYCount hyCount = jobItem[order.QtKey];
                DateTime dateTime = TimeUtil.TimestampToDateTime(hyData.AddTime);
                if (dateTime.Month == qtMonth && dateTime.Year == qtYear)
                {
                    //当月回佣
                    hyCount.curHyId.Add(hyData.OrderId);
                }
                else
                {
                    //跨月回佣
                    string[] childYM = order.QtKey.Split('-');
                    Int32 childQtYear = Convert.ToInt32(childYM[0]);
                    Int32 childQtMonth = Convert.ToInt32(childYM[1]);

                    if (((dateTime.Year > childQtYear) || (dateTime.Year == childQtYear && dateTime.Month >= childQtMonth)) &&
                        ((dateTime.Year < qtYear) || (dateTime.Year == qtYear && dateTime.Month < qtMonth)))
                    {
                        hyCount.oldHyId.Add(hyData.OrderId);
                    }
                }
            }

            foreach (var jobitem in curStatHy)
            {
                string jobnumber = jobitem.Key;
                SortedDictionary<string, HYCount> hyData = jobitem.Value;

                SortedDictionary<string, double> tmpDxMap = new SortedDictionary<string, double>();
                foreach (var hyitem in hyData)
                {
                    string jobqtkey = hyitem.Key;
                    HYCount jobHyData = hyitem.Value;

                    if (jobHyData.levelName == "Z2")
                    {
                        //一个回佣就可以了
                        if (jobHyData.oldHyId.Count == 0 && jobHyData.curHyId.Count >= 1)
                        {
                            //可以发放了
                            tmpDxMap[jobqtkey] = 1000; 
                        }
                    }
                    else if (jobHyData.levelName == "Z3")
                    {
                        //需要2个回佣就
                        if ((jobHyData.oldHyId.Count == 0 && jobHyData.curHyId.Count >= 2) || (jobHyData.oldHyId.Count == 1 && jobHyData.curHyId.Count >= 1))
                        {
                            //可以发放了
                            tmpDxMap[jobqtkey] = 1000;
                        }
                    }
                    else
                    {
                        //不做
                    }
                }
                dxPay[jobnumber] = tmpDxMap;
            }

            //查看回佣的提成
            //bool ywy = true;
            foreach(var hyData in validAllHy)
            {
                GeneratePayItem(ref hyPay, hyData);
            }
        }


        static private void GeneratePayItem(ref SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> allHyPay, HYData hyData)
        {
            QtOrder qtOrder = OrderMgr.Instance().AllOrderData[hyData.OrderId];

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtOrder.QtKey];
            //QtDepartment qtDepartment = qtTask.AllQtDepartment[qtOrder.YxQtDepartmentId];
            //自己拿20%
            double yxAmount = hyData.Amount;
            if (qtOrder.KyfConsultanJobNumber != "")
            {
                //有客源方,拿90%
                yxAmount = hyData.Amount * 0.9;
            }

            GenerateJobnumberPay(ref allHyPay, qtTask, qtOrder.YxConsultantJobNumber, qtOrder.YxQtDepartmentId, hyData.Id, yxAmount);
            if (qtOrder.KyfConsultanJobNumber != "" )
            {
                //客源方算10%
                GenerateJobnumberPay(ref allHyPay, qtTask, qtOrder.KyfConsultanJobNumber, qtOrder.KyfQtDepartmentId, hyData.Id, hyData.Amount * 0.1);
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //计算驻场
            QtLevel qtLevel = QtLevel.None;
            if (!qtTask.AllQtEmployee.ContainsKey(qtOrder.Zc1JobNumber))
            {
                qtLevel = QtLevel.ZhuchangZhuanyuan;
            } 
            else
            {
                QtEmployee qtEmployee = qtTask.AllQtEmployee[qtOrder.Zc1JobNumber];
                qtLevel = qtEmployee.QtLevel;
            }

            double zc1Prop = (qtOrder.Zc2JobNumber != "") ? 0.0035 : 0.007 ;

            //计算驻场1
            List<PayItem> zc1Pay = new List<PayItem>();
            if (qtLevel == QtLevel.ZhuchangZhuanyuan)
            {
                //驻场专员接单
                zc1Pay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * zc1Prop));
            }
            else if (qtLevel == QtLevel.ZhuchangZhuguan)
            {
                //驻场主管接单
                zc1Pay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * zc1Prop));
                zc1Pay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * 0.003));
            }
            else if (qtLevel == QtLevel.ZhuchangZongjian)
            {
                //驻场总监接单
                zc1Pay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * zc1Prop));
                zc1Pay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * 0.003));
                zc1Pay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * 0.003));
            }
            else
            {
                throw new CrashException(string.Format("驻场的的QT级别错误[{0}]", qtLevel));
            }
            AddPay(ref allHyPay, qtOrder.Zc1JobNumber, hyData.Id, zc1Pay);
            //计算驻场1的上级
            //查看驻场1缩在的部门
            QtDepartment zc1Department = qtTask.AllQtDepartment[qtOrder.Zc1QtDepartmentId];
            Int64 parentQtDepartmentId = (qtLevel == QtLevel.ZhuchangZhuanyuan) ? zc1Department.Id : zc1Department.ParentDepartmentId;
            while (true)
            {
                QtDepartment childQtDepartment = qtTask.AllQtDepartment[parentQtDepartmentId];
                if (childQtDepartment.OwnerJobNumber != "")
                {
                    List<PayItem> levelPay = new List<PayItem>();
                    levelPay.Add(new PayItem(PayType.PT_LEVEL_PAY, yxAmount * 0.003));
                    AddPay(ref allHyPay, childQtDepartment.OwnerJobNumber, hyData.Id, levelPay);

                }
                if (childQtDepartment.QtLevel == QtLevel.ZhuchangZhuguan)
                {
                    parentQtDepartmentId = childQtDepartment.ParentDepartmentId;
                }
                else if (childQtDepartment.QtLevel == QtLevel.ZhuchangZongjian)
                {
                    //结束了跳出去
                    break;
                }
                else
                {
                    //出错了
                    throw new CrashException(string.Format("驻场的组织结构错误[{0}]", childQtDepartment.QtLevel));
                }

            }

            //计算驻场2的收入
            if (qtOrder.Zc2JobNumber != "")
            {
                List<PayItem> zc2Pay = new List<PayItem>();
                zc2Pay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * 0.0035));
                AddPay(ref allHyPay, qtOrder.Zc2JobNumber, hyData.Id, zc2Pay);
            }
        }

        static private void GenerateJobnumberPay(
            ref SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> allHyPay, 
            QtTask qtTask, 
            string jobNumber, 
            Int64 yxQtDepartmentId, 
            Int64 hyId, 
            double yxAmount)
        {
            //顾问所在的部门（部门一定是QT任务里的部门）
            QtDepartment qtDepartment = qtTask.AllQtDepartment[yxQtDepartmentId];

            QtLevel qtLevel = QtLevel.None;
            if (!qtTask.AllQtEmployee.ContainsKey(jobNumber))
            {
                //不是QT任务里的人,只能是业务员
                qtLevel = QtLevel.Salesman;
            }
            else
            {
                //是QT任务里的人
                QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                qtLevel = qtEmployee.QtLevel;
            }

            List<PayItem> totalPay = new List<PayItem>();
            if (qtLevel == QtLevel.Salesman)
            {
                //业务员开的单
                totalPay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * 0.2));
            }
            else if (qtLevel == QtLevel.SmallCharge)
            {
                //小主管开的单

                //业务员提成
                totalPay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * 0.2));

                //拿小主管的级别提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                double smallChargeProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * smallChargeProp));

            }
            else if (qtLevel == QtLevel.LargeCharge)
            {
                //大主管开的单

                //业务员提成
                totalPay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * 0.2));

                //小主管的级别提成
                double smallChargeProp = CommissionUtil.GetQTSmallChargeProp();
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * smallChargeProp));

                //拿大主管的级别提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                double largeChargeProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * largeChargeProp));

            }
            else if (qtLevel == QtLevel.Majordomo)
            {
                //总监开的单

                //业务员提成
                totalPay.Add(new PayItem(PayType.PT_COMMISSION_PAY, yxAmount * 0.2));

                //小主管的级别提成
                double smallChargeProp = CommissionUtil.GetQTSmallChargeProp();
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * smallChargeProp));

                //大主管的级别提成
                double largeChargeProp = CommissionUtil.GetQtLargeChargeProp();
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * largeChargeProp));

                //拿总监的提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[jobNumber];
                double majordomoProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay.Add(new PayItem(PayType.PT_LEVEL_COMMISSION_PAY, yxAmount * majordomoProp));

            }
            else
            {
                //总经理不可能开单
                throw new CrashException(string.Format("业务员的的QT级别错误[{0}]", qtLevel));
            }

            AddPay(ref allHyPay, jobNumber, hyId, totalPay);

            //给自己的上级加钱
            Int64 parentQtDepartmentId = (qtLevel == QtLevel.Salesman) ? qtDepartment.Id : qtDepartment.ParentDepartmentId;
            while (parentQtDepartmentId != 0)
            {
                QtDepartment childQtDepartment = qtTask.AllQtDepartment[parentQtDepartmentId];
                if (childQtDepartment.OwnerJobNumber != "")
                {
                    //上级部门有主管
                    QtEmployee childQtEmployee = qtTask.AllQtEmployee[childQtDepartment.OwnerJobNumber];
                    double childPayProp = CommissionUtil.GetCommissionPropToProp(childQtDepartment, childQtEmployee);
                    List<PayItem> tmpPay = new List<PayItem>();
                    tmpPay.Add(new PayItem(PayType.PT_LEVEL_PAY, yxAmount * childPayProp));
                    AddPay(ref allHyPay, childQtDepartment.OwnerJobNumber, hyId, tmpPay);

                }
                parentQtDepartmentId = childQtDepartment.ParentDepartmentId;
            }
        }

        static private void AddPay(ref SortedDictionary<string, SortedDictionary<Int64, List<PayItem>>> allHyPay, string jobnumber, Int64 hyId, List<PayItem> pay)
        {
            SortedDictionary<Int64, List<PayItem>> hyPay = null;
            if (allHyPay.ContainsKey(jobnumber))
            {
                hyPay = allHyPay[jobnumber];
            }
            else
            {
                hyPay = new SortedDictionary<Int64, List<PayItem>>();
                allHyPay[jobnumber] = hyPay;
            }

            if (hyPay.ContainsKey(hyId))
            {
                hyPay[hyId].AddRange(pay);
            }
            else
            {
                hyPay[hyId] = pay;
            }
            
        }
    }


    

}
