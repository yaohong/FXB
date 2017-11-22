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

    public partial class EmployeeOperDlg : Form
    {
        private EditMode mode;
        private EmployeeData employeeData = null;


        private Int64 selectDepartmentId = 0;


        private string newEmployeeId = "";

        public string NewEmployeeId
        {
            get { return newEmployeeId; }
        }
        public EmployeeOperDlg(Int64 departmentId = 0)
        {
            mode = EditMode.EM_ADD;
            selectDepartmentId = departmentId;
            InitializeComponent();
        }

        public EmployeeOperDlg(EmployeeData selectEmployeeData)
        {
            mode = EditMode.EM_EDIT;
            employeeData = selectEmployeeData;
            InitializeComponent();
        }

        private void EmployeeOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            QtUtil.SetComboxValue(qtLevelSelect, CbSetMode.CBSM_Employee);
            bumenEdit.Enabled = false;
            zhijiEdit.Enabled = false;
            jobStateCb.CheckState = CheckState.Checked;
            xingbieSelect.Items.Insert(0, "女");
            xingbieSelect.Items.Insert(1, "男");
            xingbieSelect.SelectedIndex = 0;
            if (selectDepartmentId != 0)
            {
                bumenEdit.Text = DepartmentUtil.GetDepartmentShowText(selectDepartmentId);
            }
            if (mode == EditMode.EM_ADD)
            {
                AddInit();
            }
            else
            {
                EditInit();
            }
        }

        private void AddInit()
        {

        }


        private void EditInit()
        {
            gonghaoEdit.Enabled = false;
            xingmingEdit.Enabled = false;
            gonghaoEdit.Text = employeeData.JobNumber;
            xingmingEdit.Text = employeeData.Name;
            qtLevelSelect.SelectedIndex = QtUtil.GetComboxIndex(qtLevelSelect, employeeData.QTLevel);
            bumenEdit.Text = DepartmentUtil.GetDepartmentShowText(employeeData.DepartmentId);
            isOwnerCb.CheckState = CheckBoxUtil.boolToCbState(employeeData.IsOwner);
            zhijiEdit.Text = employeeData.JobGradeName;
            dianhuaEdit.Text = employeeData.PhoneNumber;
            ruzhiTime.Value = TimeUtil.TimestampToDateTime(employeeData.EnteryTime);
            jobStateCb.CheckState = CheckBoxUtil.boolToCbState(employeeData.JobState);
            lizhiTime.Value = TimeUtil.TimestampToDateTime(employeeData.DimissionTime);
            beizhuEdit.Text = employeeData.Comment;

            shenfenzhengEdit.Text = employeeData.IdCard;
            shengriTime.Value = TimeUtil.TimestampToDateTime(employeeData.Birthday);
            xingbieSelect.SelectedIndex = employeeData.Sex ? 1 : 0;
            jiguanEdit.Text = employeeData.EthnicAndOrigin;
            juzhudizhiEdit.Text = employeeData.ResidentialAddress;
            xueliEdit.Text = employeeData.Education;
            biyexuexiaoEdit.Text = employeeData.SchoolTag;
            zhuanyeEdit.Text = employeeData.Specialities;
            jjlianxirenEdit.Text = employeeData.EmergencyContact;
            jjDianhuaEdit.Text = employeeData.EmergencyTelephoneNumber;
            jieshaorenEdit.Text = employeeData.Introducer;

            selectDepartmentId = employeeData.DepartmentId;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (gonghaoEdit.Text == "")
            {
                MessageBox.Show("工号不能为空");
                return;
            }
            if (xingmingEdit.Text == "")
            {
                MessageBox.Show("姓名不能为空");
                return;
            }
            //QT不可能为空

            //部门可以不设置

            //职级
            if (zhijiEdit.Text == "")
            {
                MessageBox.Show("职级未设置");
                return;
            }

            if (dianhuaEdit.Text == "")
            {
                MessageBox.Show("电话不能为空");
                return;
            }

            //if (shenfenzhengEdit.Text == "")
            //{
            //    MessageBox.Show("身份证不能为空");
            //    return;
            //}

            //if (xingbieSelect.SelectedIndex == -1)
            //{
            //    MessageBox.Show("性别未设置");
            //    return;
            //}

            //if (juzhudizhiEdit.Text == "")
            //{
            //    MessageBox.Show("居住地址不能为空");
            //    return;
            //}

            //if (jjlianxirenEdit.Text == "")
            //{
            //    MessageBox.Show("紧急联系人不能为空");
            //    return;
            //}

            //if (jjDianhuaEdit.Text == "")
            //{
            //    MessageBox.Show("紧急联系电话不能为空");
            //    return;
            //}


            if (mode == EditMode.EM_ADD)
            {
                AddClick();
            }
            else
            {
                EditClick();
            }
        }


        private void AddClick()
        {
            QtLevel qtLevel = QtUtil.GetQTLevel(qtLevelSelect.Text);
            //if (qtLevel != QtLevel.None && qtLevel != QtLevel.Salesman)
            //{

            //    if (QtMgr.Instance().CheckQtKey())
            //    {
            //        MessageBox.Show("QT任务已经生成,只能添加普通员工和QT业务员");
            //        return;
            //    }
            //}

            try
            {
                EmployeeData newEmployeeData = EmployeeDataMgr.Instance().AddNewEmployee(
                    gonghaoEdit.Text,
                    xingmingEdit.Text,
                    qtLevel,
                    selectDepartmentId,
                    CheckBoxUtil.cbStateToBool(isOwnerCb.CheckState),
                    zhijiEdit.Text,
                    dianhuaEdit.Text,
                    TimeUtil.DateTimeToTimestamp(ruzhiTime.Value),
                    CheckBoxUtil.cbStateToBool(jobStateCb.CheckState),
                    TimeUtil.DateTimeToTimestamp(lizhiTime.Value),
                    beizhuEdit.Text,
                    shenfenzhengEdit.Text,
                    TimeUtil.DateTimeToTimestamp(shengriTime.Value),
                    xingbieSelect.SelectedIndex == 0 ? false : true,
                    jiguanEdit.Text, 
                    juzhudizhiEdit.Text,
                    xueliEdit.Text,
                    biyexuexiaoEdit.Text,
                    zhuanyeEdit.Text,
                    jjlianxirenEdit.Text,
                    jjDianhuaEdit.Text,
                    jieshaorenEdit.Text);
                newEmployeeId = newEmployeeData.JobNumber;
                this.DialogResult = DialogResult.OK;
                Close();
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

        private void EditClick()
        {
            bool selectSex = xingbieSelect.SelectedIndex == 0 ? false : true;
            if (xingmingEdit.Text != employeeData.Name ||
                qtLevelSelect.Text != QtUtil.GetQTLevelString(employeeData.QTLevel) || 
                selectDepartmentId != employeeData.DepartmentId || 
                isOwnerCb.CheckState != CheckBoxUtil.boolToCbState(employeeData.IsOwner) ||
                zhijiEdit.Text != employeeData.JobGradeName || 
                dianhuaEdit.Text != employeeData.PhoneNumber || 
                TimeUtil.DateTimeToTimestamp(ruzhiTime.Value) != employeeData.EnteryTime || 
                jobStateCb.CheckState != CheckBoxUtil.boolToCbState(employeeData.JobState) ||
                TimeUtil.DateTimeToTimestamp(lizhiTime.Value) != employeeData.DimissionTime || 
                shenfenzhengEdit.Text != employeeData.IdCard || 
                TimeUtil.DateTimeToTimestamp(shengriTime.Value) != employeeData.Birthday ||
                selectSex != employeeData.Sex ||
                jiguanEdit.Text != employeeData.EthnicAndOrigin || 
                juzhudizhiEdit.Text != employeeData.ResidentialAddress ||
                xueliEdit.Text != employeeData.Education || 
                biyexuexiaoEdit.Text != employeeData.SchoolTag ||
                zhuanyeEdit.Text != employeeData.Specialities ||
                jjlianxirenEdit.Text != employeeData.EmergencyContact || 
                jjDianhuaEdit.Text != employeeData.EmergencyTelephoneNumber ||
                jieshaorenEdit.Text != employeeData.Introducer || 
                beizhuEdit.Text != employeeData.Comment)
            {
                QtLevel newQtLevel = QtUtil.GetQTLevel(qtLevelSelect.Text);
                //if (employeeData.QTLevel != QtLevel.None)
                //{
                //    if (employeeData.QTLevel != newQtLevel ||
                //        employeeData.DepartmentId != selectDepartmentId ||
                //        employeeData.IsOwner != CheckBoxUtil.cbStateToBool(isOwnerCb.CheckState))
                //    {

                //        if (QtMgr.Instance().CheckQtKey())
                //        {
                //            MessageBox.Show("QT任务已经生成,员工的QT相关信息不能修改");
                //            return;
                //        }
                //    }
                //}

                try
                {
                    EmployeeDataMgr.Instance().ModifyEmployee(
                        employeeData.JobNumber,
                        xingmingEdit.Text,
                        newQtLevel,
                        selectDepartmentId,
                        CheckBoxUtil.cbStateToBool(isOwnerCb.CheckState),
                        zhijiEdit.Text,
                        dianhuaEdit.Text,
                        TimeUtil.DateTimeToTimestamp(ruzhiTime.Value),
                        CheckBoxUtil.cbStateToBool(jobStateCb.CheckState),
                        TimeUtil.DateTimeToTimestamp(lizhiTime.Value),
                        beizhuEdit.Text,
                        shenfenzhengEdit.Text,
                        TimeUtil.DateTimeToTimestamp(shengriTime.Value),
                        selectSex,
                        jiguanEdit.Text,
                        juzhudizhiEdit.Text,
                        xueliEdit.Text,
                        biyexuexiaoEdit.Text,
                        zhuanyeEdit.Text,
                        jjlianxirenEdit.Text,
                        jjDianhuaEdit.Text,
                        jieshaorenEdit.Text
                        );
                    this.DialogResult = DialogResult.OK;
                    Close();
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
            else
            {
                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeOperDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeData = null;
        }

        private void selectDepartmentBtn_Click(object sender, EventArgs e)
        {
            DepartmentSelectDlg dlg = new DepartmentSelectDlg();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                selectDepartmentId = dlg.SelectDepartment.Id;
                bumenEdit.Text = DepartmentUtil.GetDepartmentShowText(selectDepartmentId);
            }
        }

        private void levelNameBtn_Click(object sender, EventArgs e)
        {
            JobGradeSelectDlg dlg = new JobGradeSelectDlg();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                zhijiEdit.Text = dlg.SelectJobGradeId;
            }
        }

    }
}
