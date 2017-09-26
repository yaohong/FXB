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
    public class PayUtil
    {
        public static void GeneratePay(
            string qtKey,                                                               //月份
            ref SortedDictionary<string, SortedDictionary<Int64, double>> hyPay,        //回佣的工资 工号=>(回佣id=>获取的提成)
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

                //查看HY的添加时间
                DateTime dateTime = TimeUtil.TimestampToDateTime(hyData.AddTime);
                if (dateTime.Month != qtMonth || dateTime.Year != qtYear)
                {
                    //不当月的回佣
                    continue;
                }

                //是当月的回佣
                QtOrder order = OrderMgr.Instance().AllOrderData[hyData.OrderId];
                if (order.ReturnData.IsReturn)
                {
                    //所属的订单已经退单了
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


        static private void GeneratePayItem(ref SortedDictionary<string, SortedDictionary<Int64, double>> allHyPay, HYData hyData)
        {
            QtOrder qtOrder = OrderMgr.Instance().AllOrderData[hyData.OrderId];

            QtTask qtTask = QtMgr.Instance().AllQtTask[qtOrder.QtKey];
            QtDepartment qtDepartment = qtTask.AllQtDepartment[qtOrder.YxQtDepartmentId];
            //自己拿20%
            double yxAmount = hyData.Amount;
            if (qtOrder.KyfConsultanJobNumber != "")
            {
                //有客源方,拿90%
                yxAmount = yxAmount * 0.9;
            }

            QtLevel qtLevel = QtLevel.None;
            if (!qtTask.AllQtEmployee.ContainsKey(qtOrder.YxConsultantJobNumber))
            {
                //不是QT任务里的人,只能是业务员
                qtLevel = QtLevel.Salesman;
            }
            else
            {
                //是QT任务里的人
                QtEmployee qtEmployee = qtTask.AllQtEmployee[qtOrder.YxConsultantJobNumber];
                qtLevel = qtEmployee.QtLevel;
            }

            double totalPay = 0;
            if (qtLevel == QtLevel.Salesman)
            {
                //业务员开的单
                totalPay = yxAmount * 0.2;
            }
            else if (qtLevel == QtLevel.SmallCharge)
            {
                //小主管开的单

                //业务员提成
                totalPay = yxAmount * 0.2;

                //拿小主管的级别提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[qtOrder.YxConsultantJobNumber];
                double smallChargeProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay += yxAmount * smallChargeProp;
            }
            else if (qtLevel == QtLevel.LargeCharge)
            {
                //大主管开的单

                //业务员提成
                totalPay = yxAmount * 0.2;

                //小主管的级别提成
                double smallChargeProp = CommissionUtil.GetQTSmallChargeProp();
                totalPay += yxAmount * smallChargeProp;

                //拿大主管的级别提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[qtOrder.YxConsultantJobNumber];
                double largeChargeProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay += yxAmount * largeChargeProp;

            }
            else if (qtLevel == QtLevel.Majordomo)
            {
                //总监开的单

                //业务员提成
                totalPay = yxAmount * 0.2;

                //小主管的级别提成
                double smallChargeProp = CommissionUtil.GetQTSmallChargeProp();
                totalPay += yxAmount * smallChargeProp;

                //大主管的级别提成
                double largeChargeProp = CommissionUtil.GetQtLargeChargeProp();
                totalPay += yxAmount * largeChargeProp;

                //拿总监的提成
                QtEmployee qtEmployee = qtTask.AllQtEmployee[qtOrder.YxConsultantJobNumber];
                double majordomoProp = CommissionUtil.GetCommissionPropToProp(qtDepartment, qtEmployee);
                totalPay += yxAmount * majordomoProp;

            } 
            else if (qtLevel == QtLevel.None)
            {
                //总经理不可能开单
                throw new CrashException("总经理不能开单");
            }

            AddPay(ref allHyPay, qtOrder.YxConsultantJobNumber, hyData.Id, totalPay);

            //给自己的上级加钱
            Int64 parentQtDepartmentId = qtDepartment.ParentDepartmentId;
            while (parentQtDepartmentId != 0)
            {
                QtDepartment childQtDepartment = qtTask.AllQtDepartment[parentQtDepartmentId];
                if (childQtDepartment.OwnerJobNumber != "")
                {
                    QtEmployee childQtEmployee = qtTask.AllQtEmployee[childQtDepartment.OwnerJobNumber];
                    double childPayProp = CommissionUtil.GetCommissionPropToProp(childQtDepartment, childQtEmployee);
                    AddPay(ref allHyPay, childQtDepartment.OwnerJobNumber, hyData.Id, yxAmount * childPayProp);

                }
                parentQtDepartmentId = childQtDepartment.ParentDepartmentId;
            }



        }

        static private void AddPay(ref SortedDictionary<string, SortedDictionary<Int64, double>> allHyPay, string jobnumber, Int64 hyId, double pay)
        {
            SortedDictionary<Int64, double> hyPay = null;
            if (allHyPay.ContainsKey(jobnumber))
            {
                hyPay = allHyPay[jobnumber];
            }
            else
            {
                hyPay = new SortedDictionary<Int64, double>();
                allHyPay[jobnumber] = hyPay;
            }

            hyPay[hyId] = pay;
        }
    }


    

}
