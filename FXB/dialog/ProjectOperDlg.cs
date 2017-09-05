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
    public partial class ProjectOperDlg : Form
    {
        private EditMode mode;
        private ProjectData projectData;
        private string newCode;

        public string NewCode
        {
            get { return newCode; }
        }
        public ProjectOperDlg()
        {
            InitializeComponent();
            mode = EditMode.EM_ADD;
        }

        public ProjectOperDlg(ProjectData data)
        {
            InitializeComponent();
            projectData = data;
            mode = EditMode.EM_EDIT;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (codeEdi.Text == "")
            {
                MessageBox.Show("项目编码不能为空");
                return;
            }

            if (nameEdi.Text == "")
            {
                MessageBox.Show("项目名称不能为空");
                return;
            }

            if (addressEdi.Text == "")
            {
                MessageBox.Show("项目地址不能为空");
                return;
            }
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



            try
            {
                bool isAvailable = CheckBoxUtil.cbStateToBool(availableCheckBox.CheckState);
                ProjectDataMgr.Instance().AddNewProject(codeEdi.Text, nameEdi.Text, addressEdi.Text, commentEdi.Text, isAvailable);
                newCode = codeEdi.Text;
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

        private void EditClick()
        {

            if (nameEdi.Text != projectData.Name ||
                addressEdi.Text != projectData.Address ||
                commentEdi.Text != projectData.Comment ||
                availableCheckBox.CheckState != CheckBoxUtil.boolToCbState(projectData.IsAvailable)
                )
            {
                //發生變更了
                try
                {
                    ProjectDataMgr.Instance().ModifyProject(projectData.Code, nameEdi.Text, addressEdi.Text, commentEdi.Text, CheckBoxUtil.cbStateToBool(availableCheckBox.CheckState));
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ProjectOperDlg_Load(object sender, EventArgs e)
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
            codeEdi.Enabled = false;
            nameEdi.Enabled = false;
            codeEdi.Text = projectData.Code;
            nameEdi.Text = projectData.Name;
            addressEdi.Text = projectData.Address;
            commentEdi.Text = projectData.Comment;
            availableCheckBox.CheckState = CheckBoxUtil.boolToCbState(projectData.IsAvailable);
        }

        private void ProjectOperDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            projectData = null;
        }
    }
}
