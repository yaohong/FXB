using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Common;
using FXB.Data;
using FXB.DataManager;

namespace FXB.Dialog
{
    public partial class PersonnelDataDlg : Form, DBUpdateInterface
    {
        public PersonnelDataDlg()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();
        }


        private bool jobNumberOrNameInquire(BasicDataInterface bd)
        {
            EmployeeData data = bd as EmployeeData;
            if (gonghaoEdi.Text != "")
            {
                if (data.JobNumber.IndexOf(gonghaoEdi.Text) == -1 &&
                    data.Name.IndexOf(gonghaoEdi.Text) == -1)
                {
                    return false;
                }

            }

            if (jobStateCb.SelectedIndex != 0)
            {
                if (jobStateCb.SelectedIndex == 1 && !data.JobState)
                {
                    return false;
                }

                if (jobStateCb.SelectedIndex == 2 && data.JobState)
                {
                    return false;
                }
            }

            if (ruzhiCb.CheckState == CheckState.Checked)
            {
                //入职时间做为查询条件了
                UInt32 minTime = TimeUtil.DateTimeToTimestamp(ruzhiMinTime.Value);
                UInt32 maxTime = TimeUtil.DateTimeToTimestamp(ruzhiMaxTime.Value);
                if (data.EnteryTime < minTime || data.EnteryTime > maxTime)
                {
                    return false;
                }
            }


            if (lizhiCb.CheckState == CheckState.Checked)
            {
                //入职时间做为查询条件了
                UInt32 minTime = TimeUtil.DateTimeToTimestamp(lizhiMinTime.Value);
                UInt32 maxTime = TimeUtil.DateTimeToTimestamp(lizhiMaxTime.Value);
                if (data.DimissionTime < minTime || data.DimissionTime > maxTime)
                {
                    return false;
                }
            }

            TreeNode selectNode = departmentTreeView.SelectedNode;
            if (selectNode != null)
            {
                Int64 departmentId =  Convert.ToInt64(selectNode.Name);
                if (!DepartmentUtil.FindEmployeeByDepartment(departmentId, data.JobNumber))
                {
                    return false;
                }

            }

            return true;
        }
        private void InquireBtn_Click(object sender, EventArgs e)
        {

            EmployeeDataMgr.Instance().SetDataGridView(dataGridView1, jobNumberOrNameInquire);
        }

        private void PersonnelDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //禁止改变窗口大小
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.DoubleBuffered = true;
            jobStateCb.Items.Insert(0, "所有");
            jobStateCb.Items.Insert(1, "在职");
            jobStateCb.Items.Insert(2, "离职");
            jobStateCb.SelectedIndex = 0;
            //禁止改变表格的大小
            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            SetDataGridViewColumn();
            DepartmentDataMgr.Instance().SetTreeView(departmentTreeView);
            EmployeeDataMgr.Instance().SetDataGridView(dataGridView1);
        }

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = departmentTreeView.SelectedNode;
            DepartmentData selectDepartment = null;
            if (n != null)
            {
                Int64 selectDepartmentId = Convert.ToInt64(n.Name);
                selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[selectDepartmentId];

                if (selectDepartment.IsMaxLayer())
                {
                    MessageBox.Show("只能有四层部门");
                    return;
                }

                if (selectDepartment.QTLevel == QtLevel.ZhuchangZhuguan)
                {
                    MessageBox.Show("驻场只能有三层部门");
                    return;
                }
            }
            DepartmentOperDlg dlg = new DepartmentOperDlg(EditMode.EM_ADD, selectDepartment);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //重新刷新树
                if (dlg.NewDepartmentId != 0)
                {
                    DepartmentData newDepartmentData = DepartmentDataMgr.Instance().AllDepartmentData[dlg.NewDepartmentId];

                    var allTreeNode = departmentTreeView.Nodes.Find(newDepartmentData.SuperiorId.ToString(), true);
                    //因为ID是不重复的所以返回的是只有一个数组的元素
                    int childCount = allTreeNode.Count<TreeNode>();
                    if (childCount != 1)
                    {
                        MessageBox.Show("部门关系发生异常，请重新启动程序");
                        System.Environment.Exit(0);
                    }
                    TreeNode parentNode = allTreeNode[0];
                    parentNode.Nodes.Add(newDepartmentData.Id.ToString(), newDepartmentData.Name);
                }
                //DepartmentDataMgr.Instance().SetTreeView(treeView1);
            }

        }

        private void ModifyDepartmentBtn_Click(object sender, EventArgs e)
        {

            ModifyDepartment();

        }

        public void DbRefresh()
        {

        }

        private void AddPersonnelBtn_Click(object sender, EventArgs e)
        {
            Int64 selectDepartmentId = 0;
            TreeNode n = departmentTreeView.SelectedNode;
            if (n != null)
            {
                selectDepartmentId = Convert.ToInt64(n.Name);
            }

            EmployeeOperDlg dlg = new EmployeeOperDlg(selectDepartmentId);
            if (dlg.ShowDialog()  == DialogResult.OK)
            {
                if (dlg.NewEmployeeId != "")
                {
                    EmployeeData newProjectData = EmployeeDataMgr.Instance().AllEmployeeData[dlg.NewEmployeeId];
                    int newLine = dataGridView1.Rows.Add();
                    UpdateGridViewRow(dataGridView1.Rows[newLine], newProjectData);
                }

            }
        }

        private void RemoveDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = departmentTreeView.SelectedNode;
            if (n == null)
            {
                return;
            }

            if (n.Nodes.Count != 0)
            {
                MessageBox.Show("部门还有子部门，不能删除");
                return;
            }

            Int64 departmentId = Convert.ToInt64(n.Name);
            try
            {
                DepartmentDataMgr.Instance().DeleteDepartment(departmentId);
                n.Remove();
            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Environment.Exit(0);
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
 //           ModifyDepartment();
        }


        private void ModifyDepartment()
        {
            TreeNode n = departmentTreeView.SelectedNode;
            if (n == null)
            {
                return;
            }

            Int64 selectDepartmentId = Convert.ToInt64(n.Name);
            DepartmentData selectDepartment = DepartmentDataMgr.Instance().AllDepartmentData[selectDepartmentId];
            DepartmentOperDlg dlg = new DepartmentOperDlg(EditMode.EM_EDIT, selectDepartment);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //重新刷新树
                //DepartmentDataMgr.Instance().SetTreeView(treeView1);
                //只能修改部门名字
                //n.Name = selectDepartment.Name;
                n.Text = selectDepartment.Name;
            }
        }


        private void SetDataGridViewColumn()
        {
            DataGridViewTextBoxColumn gonghao = new DataGridViewTextBoxColumn();
            gonghao.Name = "gonghao";
            gonghao.HeaderText = "工号";
            gonghao.Width = 100;
            dataGridView1.Columns.Add(gonghao);

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
            name.Name = "name";
            name.HeaderText = "姓名";
            name.Width = 70;
            dataGridView1.Columns.Add(name);

            DataGridViewTextBoxColumn qt = new DataGridViewTextBoxColumn();
            qt.Name = "qt";
            qt.HeaderText = "QT级别";
            qt.Width = 100;
            dataGridView1.Columns.Add(qt);

            DataGridViewTextBoxColumn departmentName = new DataGridViewTextBoxColumn();
            departmentName.Name = "departmentName";
            departmentName.HeaderText = "部门";
            departmentName.Width = 250;
            dataGridView1.Columns.Add(departmentName);

            DataGridViewCheckBoxColumn isOwner = new DataGridViewCheckBoxColumn();
            isOwner.Name = "isOwner";
            isOwner.HeaderText = "主管";
            isOwner.Width = 40;
            dataGridView1.Columns.Add(isOwner);


            DataGridViewTextBoxColumn zhiji = new DataGridViewTextBoxColumn();
            zhiji.Name = "zhiji";
            zhiji.HeaderText = "职级";
            zhiji.Width = 60;
            dataGridView1.Columns.Add(zhiji);

            DataGridViewTextBoxColumn dianhua = new DataGridViewTextBoxColumn();
            dianhua.Name = "dianhua";
            dianhua.HeaderText = "电话";
            dianhua.Width = 80;
            dataGridView1.Columns.Add(dianhua);

            DataGridViewTextBoxColumn ruzhiTime = new DataGridViewTextBoxColumn();
            ruzhiTime.Name = "ruzhiTime";
            ruzhiTime.HeaderText = "入职时间";
            ruzhiTime.Width = 80;
            dataGridView1.Columns.Add(ruzhiTime);

            DataGridViewCheckBoxColumn jobState = new DataGridViewCheckBoxColumn();
            jobState.Name = "jobState";
            jobState.HeaderText = "在职状态";
            jobState.Width = 60;
            dataGridView1.Columns.Add(jobState);

            DataGridViewTextBoxColumn lizhiTime = new DataGridViewTextBoxColumn();
            lizhiTime.Name = "lizhiTime";
            lizhiTime.HeaderText = "离职时间";
            lizhiTime.Width = 80;
            dataGridView1.Columns.Add(lizhiTime);

            DataGridViewTextBoxColumn shenfenzheng = new DataGridViewTextBoxColumn();
            shenfenzheng.Name = "shenfenzheng";
            shenfenzheng.HeaderText = "身份证";
            shenfenzheng.Width = 120;
            dataGridView1.Columns.Add(shenfenzheng);

            DataGridViewTextBoxColumn shengriTime = new DataGridViewTextBoxColumn();
            shengriTime.Name = "shengriTime";
            shengriTime.HeaderText = "生日";
            shengriTime.Width = 80;
            dataGridView1.Columns.Add(shengriTime);

            DataGridViewTextBoxColumn xingbie = new DataGridViewTextBoxColumn();
            xingbie.Name = "xingbie";
            xingbie.HeaderText = "性别";
            xingbie.Width = 40;

            dataGridView1.Columns.Add(xingbie);

            DataGridViewTextBoxColumn mingzujiguan = new DataGridViewTextBoxColumn();
            mingzujiguan.Name = "mingzujiguan";
            mingzujiguan.HeaderText = "名族籍贯";
            mingzujiguan.Width = 80;
            dataGridView1.Columns.Add(mingzujiguan);

            DataGridViewTextBoxColumn juzhudizhi = new DataGridViewTextBoxColumn();
            juzhudizhi.Name = "juzhudizhi";
            juzhudizhi.HeaderText = "居住地址";
            juzhudizhi.Width = 150;
            dataGridView1.Columns.Add(juzhudizhi);

            DataGridViewTextBoxColumn xueli = new DataGridViewTextBoxColumn();
            xueli.Name = "xueli";
            xueli.HeaderText = "学历";
            xueli.Width = 60;
            dataGridView1.Columns.Add(xueli);

            DataGridViewTextBoxColumn biyexuexiao = new DataGridViewTextBoxColumn();
            biyexuexiao.Name = "biyexuexiao";
            biyexuexiao.HeaderText = "毕业学校";
            biyexuexiao.Width = 100;
            dataGridView1.Columns.Add(biyexuexiao);

            DataGridViewTextBoxColumn zhuanye = new DataGridViewTextBoxColumn();
            zhuanye.Name = "zhuanye";
            zhuanye.HeaderText = "专业";
            zhuanye.Width = 110;
            dataGridView1.Columns.Add(zhuanye);

            DataGridViewTextBoxColumn jjLianxiren = new DataGridViewTextBoxColumn();
            jjLianxiren.Name = "jjLianxiren";
            jjLianxiren.HeaderText = "紧急联系人";
            jjLianxiren.Width = 110;
            dataGridView1.Columns.Add(jjLianxiren);

            DataGridViewTextBoxColumn jjLianxidianhua = new DataGridViewTextBoxColumn();
            jjLianxidianhua.Name = "jjLianxidianhua";
            jjLianxidianhua.HeaderText = "紧急联系电话";
            jjLianxidianhua.Width = 110;
            dataGridView1.Columns.Add(jjLianxidianhua);

            DataGridViewTextBoxColumn jieshaoren = new DataGridViewTextBoxColumn();
            jieshaoren.Name = "jieshaoren";
            jieshaoren.HeaderText = "介绍人";
            jieshaoren.Width = 70;
            dataGridView1.Columns.Add(jieshaoren);

            DataGridViewTextBoxColumn beizhu = new DataGridViewTextBoxColumn();
            beizhu.Name = "beizhu";
            beizhu.HeaderText = "备注";
            beizhu.Width = 599;
            dataGridView1.Columns.Add(beizhu);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)dataGridView1.SelectedRows[0].Cells["gonghao"];
            string gonghao = (string)selectCell.Value;

            EmployeeData employeeData = EmployeeDataMgr.Instance().AllEmployeeData[gonghao];
            EmployeeOperDlg dlg = new EmployeeOperDlg(employeeData);
            //JobGradeOperDlg dlg = new JobGradeOperDlg(selectData);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //更新选中的行
                UpdateGridViewRow(dataGridView1.SelectedRows[0], employeeData);
            }
        }

        private void UpdateGridViewRow(DataGridViewRow row, EmployeeData data)
        {
            row.Cells["gonghao"].Value = data.JobNumber;
            row.Cells["name"].Value = data.Name;
            row.Cells["qt"].Value = QtUtil.GetQTLevelString(data.QTLevel);
            row.Cells["departmentName"].Value = DepartmentUtil.GetDepartmentShowText(data.DepartmentId);
            row.Cells["isOwner"].Value = data.IsOwner;
            row.Cells["zhiji"].Value = data.JobGradeName;

            row.Cells["dianhua"].Value = data.PhoneNumber;
            //row.Cells["ruzhiTime"].Value = TimeUtil.TimestampToDateTime(data.EnteryTime).ToShortDateString();
            //row.Cells["jobState"].Value = data.JobState;
            //row.Cells["lizhiTime"].Value = TimeUtil.TimestampToDateTime(data.DimissionTime).ToShortDateString();

            row.Cells["jobState"].Value = data.JobState;
            row.Cells["ruzhiTime"].Value = TimeUtil.TimestampToDateTime(data.EnteryTime).ToShortDateString();
            if (!data.JobState)
            {
                row.Cells["lizhiTime"].Value = TimeUtil.TimestampToDateTime(data.DimissionTime).ToShortDateString();
            } 
            else
            {
                row.Cells["lizhiTime"].Value = "";
            }

            row.Cells["shenfenzheng"].Value = data.IdCard;
            row.Cells["shengriTime"].Value = TimeUtil.TimestampToDateTime(data.Birthday).ToShortDateString();
            row.Cells["xingbie"].Value = data.Sex ? "男" : "女";
            row.Cells["mingzujiguan"].Value = data.EthnicAndOrigin;
            row.Cells["juzhudizhi"].Value = data.ResidentialAddress;
            row.Cells["xueli"].Value = data.Education;
            row.Cells["biyexuexiao"].Value = data.SchoolTag;
            row.Cells["zhuanye"].Value = data.Specialities;
            row.Cells["jjLianxiren"].Value = data.EmergencyContact;
            row.Cells["jjLianxidianhua"].Value = data.EmergencyTelephoneNumber;
            row.Cells["jieshaoren"].Value = data.Introducer;
            row.Cells["beizhu"].Value = data.Comment;
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            Int64 s1 = TimeUtil.DateTimeToMs(DateTime.Now);
            EmployeeDataMgr.Instance().SetDataGridView(dataGridView1, jobNumberOrNameInquire);
            Int64 s2 = TimeUtil.DateTimeToMs(DateTime.Now);
            Console.WriteLine((s2-s1).ToString());
        }

        private void departmentTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null)
            {
                departmentTreeView.SelectedNode = departmentTreeView.GetNodeAt(e.X, e.Y);
            } 
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExcelUtil.ExportData(dataGridView1);
        }

        private void RemovePersonnelBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            //只能选择一行
            DataGridViewRow selectRow = dataGridView1.SelectedRows[0];
            DataGridViewTextBoxCell selectCell = (DataGridViewTextBoxCell)selectRow.Cells["gonghao"];
            string gonghao = (string)selectCell.Value;

            //检测工号是否能删除

            try
            {
                EmployeeData curEmployeeData = AuthMgr.Instance().CurLoginEmployee;
                if (curEmployeeData.JobNumber == gonghao)
                {
                    throw new ConditionCheckException(string.Format("当前登陆用户不能删除"));
                }
                foreach (var item in QtMgr.Instance().AllQtTask)
                {
                    QtTask qtTask = item.Value;
                    foreach (var orderItem in qtTask.AllQtOrder)
                    {
                        QtOrder qtOrder = orderItem.Value;
                        if (qtOrder.YxJob.Exist(gonghao))
                        {
                            throw new ConditionCheckException(string.Format("工号[{0}]在QT任务[{1}]的订单[{2}]里被指定为营销顾问，不能删除", gonghao, item.Key, orderItem.Key));
                        }

                        if (qtOrder.KyfConsultanJobNumber == gonghao)
                        {
                            throw new ConditionCheckException(string.Format("工号[{0}]在QT任务[{1}]的订单[{2}]里被指定为客源方，不能删除", gonghao, item.Key, orderItem.Key));
                        }

                        if (qtOrder.Zc1JobNumber == gonghao)
                        {
                            throw new ConditionCheckException(string.Format("工号[{0}]在QT任务[{1}]的订单[{2}]里被指定为驻场1，不能删除", gonghao, item.Key, orderItem.Key));
                        }

                        if (qtOrder.Zc2JobNumber == gonghao)
                        {
                            throw new ConditionCheckException(string.Format("工号[{0}]在QT任务[{1}]的订单[{2}]里被指定为驻场2，不能删除", gonghao, item.Key, orderItem.Key));
                        }
                    }
                }

                EmployeeDataMgr.Instance().RemoveEmployeeData(gonghao);
                dataGridView1.Rows.RemoveAt(selectRow.Index);

            }
            catch (ConditionCheckException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                System.Environment.Exit(0);
            }
        }


    }
}
