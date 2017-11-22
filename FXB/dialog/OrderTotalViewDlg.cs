using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FXB.DataManager;
using FXB.Data;
using FXB.Common;

namespace FXB.Dialog
{
    public partial class OrderTotalViewDlg : Form
    {
        public OrderTotalViewDlg()
        {
            InitializeComponent();
        }

        private void OrderTotalViewDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            foreach (var item in QtMgr.Instance().AllQtTask)
            {

                qtSelect.Items.Add(item.Key);
            }

            SetDataGridViewColumn();
        }


        private void SetDataGridViewColumn()
        {

            DataGridViewTextBoxColumn xiangmumingcheng = new DataGridViewTextBoxColumn();
            xiangmumingcheng.Name = "xiangmumingcheng";
            xiangmumingcheng.HeaderText = "项目名称";
            xiangmumingcheng.Width = 100;
            myDataGridView1.Columns.Add(xiangmumingcheng);

            DataGridViewTextBoxColumn fanghao = new DataGridViewTextBoxColumn();
            fanghao.Name = "fanghao";
            fanghao.HeaderText = "房号";
            fanghao.Width = 100;
            myDataGridView1.Columns.Add(fanghao);

            DataGridViewTextBoxColumn kehuxingming = new DataGridViewTextBoxColumn();
            kehuxingming.Name = "kehuxingming";
            kehuxingming.HeaderText = "客户姓名";
            kehuxingming.Width = 100;
            myDataGridView1.Columns.Add(kehuxingming);

            DataGridViewTextBoxColumn chengjiaoriqi = new DataGridViewTextBoxColumn();
            chengjiaoriqi.Name = "chengjiaoriqi";
            chengjiaoriqi.HeaderText = "成交日期";
            chengjiaoriqi.Width = 100;
            myDataGridView1.Columns.Add(chengjiaoriqi);

            DataGridViewTextBoxColumn chengjiaojiage = new DataGridViewTextBoxColumn();
            chengjiaojiage.Name = "chengjiaojiage";
            chengjiaojiage.HeaderText = "成交价格";
            chengjiaojiage.Width = 100;
            myDataGridView1.Columns.Add(chengjiaojiage);

            DataGridViewTextBoxColumn zongyongjin = new DataGridViewTextBoxColumn();
            zongyongjin.Name = "zongyongjin";
            zongyongjin.HeaderText = "总佣金";
            zongyongjin.Width = 100;
            myDataGridView1.Columns.Add(zongyongjin);

            DataGridViewTextBoxColumn chaifenbili = new DataGridViewTextBoxColumn();
            chaifenbili.Name = "chaifenbili";
            chaifenbili.HeaderText = "拆分比例";
            chaifenbili.Width = 100;
            myDataGridView1.Columns.Add(chaifenbili);

            DataGridViewTextBoxColumn leixing = new DataGridViewTextBoxColumn();
            leixing.Name = "leixing";
            leixing.HeaderText = "类型";
            leixing.Width = 100;
            myDataGridView1.Columns.Add(leixing);

            DataGridViewTextBoxColumn yewuyuanbumen = new DataGridViewTextBoxColumn();
            yewuyuanbumen.Name = "yewuyuanbumen";
            yewuyuanbumen.HeaderText = "业务员部门";
            yewuyuanbumen.Width = 100;
            myDataGridView1.Columns.Add(yewuyuanbumen);

            DataGridViewTextBoxColumn yewuyuanxingming = new DataGridViewTextBoxColumn();
            yewuyuanxingming.Name = "yewuyuanxingming";
            yewuyuanxingming.HeaderText = "业务员姓名";
            yewuyuanxingming.Width = 100;
            myDataGridView1.Columns.Add(yewuyuanxingming);

            DataGridViewTextBoxColumn yewuyuanzhiji = new DataGridViewTextBoxColumn();
            yewuyuanzhiji.Name = "yewuyuanzhiji";
            yewuyuanzhiji.HeaderText = "业务员职级";
            yewuyuanzhiji.Width = 100;
            myDataGridView1.Columns.Add(yewuyuanzhiji);


            DataGridViewTextBoxColumn xiaozhuguanxingming = new DataGridViewTextBoxColumn();
            xiaozhuguanxingming.Name = "xiaozhuguanxingming";
            xiaozhuguanxingming.HeaderText = "小主管姓名";
            xiaozhuguanxingming.Width = 100;
            myDataGridView1.Columns.Add(xiaozhuguanxingming);

            DataGridViewTextBoxColumn xiaozhuguanzhiji= new DataGridViewTextBoxColumn();
            xiaozhuguanzhiji.Name = "xiaozhuguanzhiji";
            xiaozhuguanzhiji.HeaderText = "小主管职级";
            xiaozhuguanzhiji.Width = 100;
            myDataGridView1.Columns.Add(xiaozhuguanzhiji);

            DataGridViewTextBoxColumn dazhuguanxingming = new DataGridViewTextBoxColumn();
            dazhuguanxingming.Name = "dazhuguanxingming";
            dazhuguanxingming.HeaderText = "大主管姓名";
            dazhuguanxingming.Width = 100;
            myDataGridView1.Columns.Add(dazhuguanxingming);

            DataGridViewTextBoxColumn dazhuguanzhiji = new DataGridViewTextBoxColumn();
            dazhuguanzhiji.Name = "dazhuguanzhiji";
            dazhuguanzhiji.HeaderText = "大主管职级";
            dazhuguanzhiji.Width = 100;
            myDataGridView1.Columns.Add(dazhuguanzhiji);

            DataGridViewTextBoxColumn zongjianxingming = new DataGridViewTextBoxColumn();
            zongjianxingming.Name = "zongjianxingming";
            zongjianxingming.HeaderText = "总监姓名";
            zongjianxingming.Width = 100;
            myDataGridView1.Columns.Add(zongjianxingming);

            DataGridViewTextBoxColumn zhuchangyuan = new DataGridViewTextBoxColumn();
            zhuchangyuan.Name = "zhuchangyuan";
            zhuchangyuan.HeaderText = "驻场员";
            zhuchangyuan.Width = 100;
            myDataGridView1.Columns.Add(zhuchangyuan);

            DataGridViewTextBoxColumn zhuchangzhuguan = new DataGridViewTextBoxColumn();
            zhuchangzhuguan.Name = "zhuchangzhuguan";
            zhuchangzhuguan.HeaderText = "驻场主管";
            zhuchangzhuguan.Width = 100;
            myDataGridView1.Columns.Add(zhuchangzhuguan);

            DataGridViewTextBoxColumn zhuchangzongjian = new DataGridViewTextBoxColumn();
            zhuchangzongjian.Name = "zhuchangzongjian";
            zhuchangzongjian.HeaderText = "驻场总监";
            zhuchangzongjian.Width = 100;
            myDataGridView1.Columns.Add(zhuchangzongjian);

            DataGridViewTextBoxColumn beizhu = new DataGridViewTextBoxColumn();
            beizhu.Name = "beizhu";
            beizhu.HeaderText = "备注";
            beizhu.Width = 300;
            myDataGridView1.Columns.Add(beizhu);
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExcelUtil.ExportData(myDataGridView1);
        }

        private void InquertBtn_Click(object sender, EventArgs e)
        {
            if (-1 == qtSelect.SelectedIndex)
            {
                return;
            }

            EmployeeData curEmployee = AuthMgr.Instance().CurLoginEmployee;
            string curJob = curEmployee.JobNumber;



            string qtKey = qtSelect.SelectedItem as string;
            QtTask qtTask = QtMgr.Instance().AllQtTask[qtKey];

            if (!qtTask.Closing)
            {
                MessageBox.Show("没有生成QT提成");
                return;
            }


            ShowQuery(qtTask);
        }


        void ShowQuery(QtTask qtTask)
        {
            myDataGridView1.Rows.Clear();



            foreach (var item in qtTask.AllQtOrder)
            {
                QtOrder order = item.Value;

                if (order.ReturnData.IsReturn)
                {
                    //所属的订单已经退单了
                    continue;
                }

                foreach (var jobItem in order.YxJob.Jobs)
                {
                    string jobnumber = jobItem.Key;
                    Int32 prop = jobItem.Value;

                    UpdateRow(qtTask, order, jobnumber, prop, "业务员");


                }

                if (order.KyfConsultanJobNumber != "")
                {
                    UpdateRow(qtTask, order, order.KyfConsultanJobNumber, 1000, "客源方");
                }

            }

        }

        void UpdateRow(QtTask qtTask, QtOrder qtOrder, string jobnumber, Int32 prop, string type)
        {
            int rowId = myDataGridView1.Rows.Add();
            DataGridViewRow newRow = myDataGridView1.Rows[rowId];
            {
                ProjectData projectData = ProjectDataMgr.Instance().AllProjectData[qtOrder.ProjectCode];
                newRow.Cells["xiangmumingcheng"].Value = projectData.Name;
            }
            newRow.Cells["fanghao"].Value = qtOrder.RoomNumber;
            newRow.Cells["kehuxingming"].Value = qtOrder.CustomerName;
            {
                DateTime dt = TimeUtil.TimestampToDateTime(qtOrder.GenerateTime);
                newRow.Cells["chengjiaoriqi"].Value = dt.ToLongDateString();
            }

            newRow.Cells["chengjiaojiage"].Value = DoubleUtil.Show(qtOrder.ClosingTheDealMoney);
            newRow.Cells["zongyongjin"].Value = DoubleUtil.Show(qtOrder.CommissionAmount);
            newRow.Cells["chaifenbili"].Value = string.Format("%{0}", prop / 100);
            newRow.Cells["leixing"].Value = type;

            {
                Int64 departmentId = QtTaskUtil.GetJobDepartmentIdByQtTask(qtTask, jobnumber);
                newRow.Cells["yewuyuanbumen"].Value = DepartmentUtil.GetQtDepartmentSimShowText(qtTask, departmentId);
                newRow.Cells["yewuyuanxingming"].Value = EmployeeDataMgr.Instance().AllEmployeeData[jobnumber].Name;
                newRow.Cells["yewuyuanzhiji"].Value = QtTaskUtil.GetJobLevelNameByQtTask(qtTask, jobnumber);
            }

            {   //return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
                string xiaozhuguanJob = GetXiaozhuguan(jobnumber, qtTask);
                if (xiaozhuguanJob != "")
                {
                    newRow.Cells["xiaozhuguanxingming"].Value = EmployeeDataMgr.Instance().AllEmployeeData[xiaozhuguanJob].Name;
                    newRow.Cells["xiaozhuguanzhiji"].Value = QtTaskUtil.GetJobLevelNameByQtTask(qtTask, xiaozhuguanJob);
                }
                else
                {
                    newRow.Cells["xiaozhuguanxingming"].Value = "";
                    newRow.Cells["xiaozhuguanzhiji"].Value = "";
                }
            }

            {
                string dazhuguanJob = GetDazhuguan(jobnumber, qtTask);
                if (dazhuguanJob != "")
                {
                    newRow.Cells["dazhuguanxingming"].Value = EmployeeDataMgr.Instance().AllEmployeeData[dazhuguanJob].Name;
                    newRow.Cells["dazhuguanzhiji"].Value = QtTaskUtil.GetJobLevelNameByQtTask(qtTask, dazhuguanJob);
                }
                else
                {
                    newRow.Cells["dazhuguanxingming"].Value = "";
                    newRow.Cells["dazhuguanzhiji"].Value = "";
                }
            }

            {
                string zongjianJob = GetZongjian(jobnumber, qtTask);
                newRow.Cells["zongjianxingming"].Value = EmployeeDataMgr.Instance().AllEmployeeData[zongjianJob].Name;
            }

            {
                string showZhuanyuanName = EmployeeDataMgr.Instance().AllEmployeeData[qtOrder.Zc1JobNumber].Name;
                if (qtOrder.Zc2JobNumber != "")
                {
                    string zc2Name = EmployeeDataMgr.Instance().AllEmployeeData[qtOrder.Zc2JobNumber].Name;
                    showZhuanyuanName = showZhuanyuanName + "/" + zc2Name;
                }
                newRow.Cells["zhuchangyuan"].Value = showZhuanyuanName;
            }

            {
                newRow.Cells["zhuchangzhuguan"].Value = GetZhuguanName(qtOrder.Zc1JobNumber, qtTask);
            }

            {
                newRow.Cells["zhuchangzongjian"].Value = GetZongjianName(qtOrder.Zc1JobNumber, qtTask);
            }

            newRow.Cells["beizhu"].Value = qtOrder.Comment;
            //newRow.Cells["shichuticheng"].Value = DoubleUtil.Show(basic * 0.2);

            //{
            //    newRow.Cells["xiaozhuguan"].Value = GetXiaozhuguanName(jobnumber, qtTask);
            //    double bili = GetXiaozhuguanBili(jobnumber, qtTask);
            //    newRow.Cells["xiaozhuguanbili"].Value = string.Format("%{0}", bili * 100);
            //    newRow.Cells["xiaozhuguanticheng"].Value = DoubleUtil.Show(basic * bili);
            //}

            //{
            //    newRow.Cells["dazhuguan"].Value = GetDazhuguanName(jobnumber, qtTask);
            //    double bili = GetDazhuguanBili(jobnumber, qtTask);
            //    newRow.Cells["dazhuguanbili"].Value = string.Format("%{0}", bili * 100);
            //    newRow.Cells["dazhuguanticheng"].Value = DoubleUtil.Show(basic * bili);
            //}

            //{
            //    newRow.Cells["zongjian"].Value = GetZongjianName(jobnumber, qtTask);
            //    double bili = GetZongjianBili(jobnumber, qtTask);
            //    newRow.Cells["zongjianbili"].Value = string.Format("%{0}", bili * 100);
            //    newRow.Cells["zongjianticheng"].Value = DoubleUtil.Show(basic * bili);
            //}
        }

        string GetXiaozhuguan(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman)
            {
                //业务员开单
                QtDepartment parmentDepartment = qtTask.AllQtDepartment[kaidanDepartment.Id];
                replyJob = parmentDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return replyJob;
        }
        string GetDazhuguan(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return replyJob;
            
        }

        string GetZongjian(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.Salesman || kaidanEmployee.QtLevel == QtLevel.SmallCharge)
            {
                for (int i = 0; i < 2; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }

                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else if (kaidanEmployee.QtLevel == QtLevel.LargeCharge)
            {
                for (int i = 0; i < 1; i++)
                {
                    kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                }
                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return replyJob;
        }

        string GetZhuguanName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuanyuan)
            {
                //业务员开单
                QtDepartment parmentDepartment = qtTask.AllQtDepartment[kaidanDepartment.Id];
                replyJob = parmentDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
        }

        string GetZongjianName(string kaidanJob, QtTask qtTask)
        {
            QtEmployee kaidanEmployee = qtTask.AllQtEmployee[kaidanJob];
            QtDepartment kaidanDepartment = qtTask.AllQtDepartment[kaidanEmployee.DepartmentId];

            string replyJob = "";
            if (kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuanyuan || kaidanEmployee.QtLevel == QtLevel.ZhuchangZhuguan)
            {
                kaidanDepartment = qtTask.AllQtDepartment[kaidanDepartment.ParentDepartmentId];
                replyJob = kaidanDepartment.OwnerJobNumber;
            }
            else
            {
                replyJob = kaidanDepartment.OwnerJobNumber;
            }

            if (replyJob == "")
            {
                return "";
            }

            return EmployeeDataMgr.Instance().AllEmployeeData[replyJob].Name;
        }
    }
}
