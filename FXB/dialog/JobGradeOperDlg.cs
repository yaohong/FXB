using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FXB.Data;
using FXB.DataManager;
using FXB.Common;
namespace FXB.Dialog
{
    public partial class JobGradeOperDlg : Form
    {
        private EditMode mode;
        private JobGradeData jobGradeData;

        private string newLevelName = "";

        public string NewLevelName
        {
            get { return newLevelName; }
        }

        public JobGradeOperDlg()
        {
            InitializeComponent();

            mode = EditMode.EM_ADD;
        }

        public JobGradeOperDlg(JobGradeData tmpGradeData)
        {
            InitializeComponent();
            jobGradeData = tmpGradeData;
            mode = EditMode.EM_EDIT;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (mode == EditMode.EM_ADD)
            {
                AddClick();
            }
            else
            {
                EditClick();
            }
        }

        private void dixinEdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\b')
            {
                if((e.KeyChar<'0')||(e.KeyChar>'9'))
                {
                    e.Handled = true;
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void JobGradeOperDlg_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            zhijiEdi.Enabled = false;

            zhijiEdi.Text = jobGradeData.LevelName;
            xulieEdi.Text = jobGradeData.XuLie;
            dixinEdi.Text = jobGradeData.BaseSalary.ToString();
            beizhuEdi.Text = jobGradeData.Comment;
        }


        private void AddClick()
        {
            if (zhijiEdi.Text == "")
            {
                MessageBox.Show("职级不能为空");
                return;
            }

            if (xulieEdi.Text == "")
            {
                MessageBox.Show("序列不能为空");
                return;
            }

            if (dixinEdi.Text == "")
            {
                dixinEdi.Text = "0";
            }

            //检测职级是否重复
            

            try
            {
                Int32 intDixin = Convert.ToInt32(dixinEdi.Text);
                JobGradeDataMgr.Instance().AddNewJobGrade(zhijiEdi.Text, xulieEdi.Text, intDixin, beizhuEdi.Text);
                newLevelName = zhijiEdi.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ConditionCheckException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                System.Environment.Exit(0);
            }
        }

        private void EditClick()
        {
            if (zhijiEdi.Text == "")
            {
                MessageBox.Show("职级不能为空");
                return;
            }

            if (xulieEdi.Text == "")
            {
                MessageBox.Show("序列不能为空");
                return;
            }

            if (dixinEdi.Text == "")
            {
                MessageBox.Show("底薪不能为空");
                return;
            }

            if (xulieEdi.Text != jobGradeData.XuLie ||
                dixinEdi.Text != jobGradeData.BaseSalary.ToString()||
                beizhuEdi.Text != jobGradeData.Comment)
            {
                //發生變更了
                try
                {
                    JobGradeDataMgr.Instance().ModifyJobGrade(jobGradeData.LevelName, xulieEdi.Text, Convert.ToInt32(dixinEdi.Text), beizhuEdi.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (ConditionCheckException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    System.Environment.Exit(0); 
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }


        }

        private void JobGradeOperDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            jobGradeData = null;
        }
    }
}
