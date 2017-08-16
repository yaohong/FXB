﻿using System;
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

        private void InquireBtn_Click(object sender, EventArgs e)
        {
            string a = dateTimePicker1.Text;
        }

        private void PersonnelDataDlg_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            //禁止改变窗口大小
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.DoubleBuffered = true;

            //禁止改变表格的大小
            dataGridView1.AllowUserToAddRows = false;       //不显示插入行
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            SetDataGridViewColumn();
            DepartmentDataMgr.Instance().SetTreeView(treeView1);
            EmployeeDataMgr.Instance().SetDataGridView(dataGridView1);
        }

        private void AddDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = treeView1.SelectedNode;
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

                    var allTreeNode = treeView1.Nodes.Find(newDepartmentData.SuperiorId.ToString(), true);
                    //因为ID是不重复的所以返回的是只有一个数组的元素
                    int childCount = allTreeNode.Count<TreeNode>();
                    if (childCount != 1)
                    {
                        MessageBox.Show("部门关系发生异常，请重新启动程序");
                        Application.Exit();
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
            EmployeeOperDlg dlg = new EmployeeOperDlg();
            dlg.ShowDialog();
        }

        private void RemoveDepartmentBtn_Click(object sender, EventArgs e)
        {
            TreeNode n = treeView1.SelectedNode;
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
                Application.Exit();
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            ModifyDepartment();
        }


        private void ModifyDepartment()
        {
            TreeNode n = treeView1.SelectedNode;
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
            biyexuexiao.Width = 80;
            dataGridView1.Columns.Add(biyexuexiao);

            DataGridViewTextBoxColumn zhuanye = new DataGridViewTextBoxColumn();
            zhuanye.Name = "zhuanye";
            zhuanye.HeaderText = "专业";
            zhuanye.Width = 80;
            dataGridView1.Columns.Add(zhuanye);

            DataGridViewTextBoxColumn jjLianxiren = new DataGridViewTextBoxColumn();
            jjLianxiren.Name = "jjLianxiren";
            jjLianxiren.HeaderText = "紧急联系人";
            jjLianxiren.Width = 70;
            dataGridView1.Columns.Add(jjLianxiren);

            DataGridViewTextBoxColumn jjLianxidianhua = new DataGridViewTextBoxColumn();
            jjLianxidianhua.Name = "jjLianxidianhua";
            jjLianxidianhua.HeaderText = "紧急联系电话";
            jjLianxidianhua.Width = 80;
            dataGridView1.Columns.Add(jjLianxidianhua);

            DataGridViewTextBoxColumn jieshaoren = new DataGridViewTextBoxColumn();
            jieshaoren.Name = "jieshaoren";
            jieshaoren.HeaderText = "介绍人";
            jieshaoren.Width = 100;
            dataGridView1.Columns.Add(jieshaoren);

            DataGridViewTextBoxColumn beizhu = new DataGridViewTextBoxColumn();
            beizhu.Name = "beizhu";
            beizhu.HeaderText = "备注";
            beizhu.Width = 599;
            dataGridView1.Columns.Add(beizhu);
        }
    }
}
