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
        private EmployeeData employeeData;


        private Int64 selectDepartmentId = 0;
        public EmployeeOperDlg()
        {
            mode = EditMode.EM_ADD;
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
            xingbieSelect.Items.Insert(0, "男");
            xingbieSelect.Items.Insert(1, "女");
            //xingbieSelect.SelectedIndex = 0;
            jobStateCb.CheckState = CheckState.Checked;
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
            gonghaoEdit.Text = employeeData.JobNumber;
            xingmingEdit.Text = employeeData.Name;
            qtLevelSelect.SelectedIndex = QtUtil.GetComboxIndex(qtLevelSelect, employeeData.QTLevel);
            bumenEdit.Text = DepartmentUtil.GetDepartmentShowText(employeeData.DepartmentId);
            zhijiEdit.Text = employeeData.JobGradeName;
            dianhuaEdit.Text = employeeData.PhoneNumber;
            ruzhiTime.Value = TimeUtil.TimestampToDatetTime(employeeData.EnteryTime);
            jobStateCb.CheckState = CheckBoxUtil.boolToCbState(employeeData.JobState);
            lizhiTime.Value = TimeUtil.TimestampToDatetTime(employeeData.DimissionTime);
            beizhuEdit.Text = employeeData.Comment;

            shenfenzhengEdit.Text = employeeData.IdCard;
            shengriTime.Value = TimeUtil.TimestampToDatetTime(employeeData.Birthday);
            xingbieSelect.SelectedIndex = employeeData.Sex ? 0 : 1;
            jiguanEdit.Text = employeeData.EthnicAndOrigin;
            juzhudizhiEdit.Text = employeeData.ResidentialAddress;
            xueliEdit.Text = employeeData.Education;
            biyexuexiaoEdit.Text = employeeData.SchoolTag;
            zhuanyeEdit.Text = employeeData.Specialities;
            jjlianxirenEdit.Text = employeeData.EmergencyContact;
            jjDianhuaEdit.Text = employeeData.EmergencyTelephoneNumber;
            jieshaorenEdit.Text = employeeData.Introducer;
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

            if (shenfenzhengEdit.Text == "")
            {
                MessageBox.Show("身份证不能为空");
                return;
            }

            if (xingbieSelect.SelectedIndex == -1)
            {
                MessageBox.Show("性别未设置");
                return;
            }

            if (juzhudizhiEdit.Text == "")
            {
                MessageBox.Show("居住地址不能为空");
                return;
            }

            if (jjlianxirenEdit.Text == "")
            {
                MessageBox.Show("紧急联系人不能为空");
                return;
            }

            if (jjDianhuaEdit.Text == "")
            {
                MessageBox.Show("紧急联系电话不能为空");
                return;
            }

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeOperDlg_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void EmployeeOperDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            employeeData = null;
        }

        private void selectDepartmentBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
