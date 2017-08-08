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
    public partial class DepartmentOperDlg : Form
    {
        private EditMode mode;
        private DepartmentData selectDepartment;
        private Int64 newDepartmentId;
        public DepartmentOperDlg(EditMode tmpMode, DepartmentData tmpSelectDepartment)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            mode = tmpMode;
            selectDepartment = tmpSelectDepartment;

            newDepartmentId = 0;
        }

        public Int64 NewDepartmentId
        {
            get { return newDepartmentId; }
        }

        private void DepartmentOperDlg_Load(object sender, EventArgs e)
        {
            if (mode == EditMode.EM_ADD)
            {
                AddInit();
            } 
            else
            {
                EditInit();
            } 
            
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

        private void AddClick()
        {
            if (shangjiIdEdit.Text == "" || shangjiBumenEdit.Text == "")
            {
                MessageBox.Show("上级部门信息不能为空");
                return;
            }

            if (bumenNameEdit.Text == "")
            {
                MessageBox.Show("部门名字不能为空");
                return;
            }
            DialogResult result = MessageBox.Show(string.Format("当前QT等级设置为:{0},设置之后不能修改.", qtLevelSelect.Text), "警告", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }

            QtLevel qtLevel = QtUtil.GetQTLevel(qtLevelSelect.Text);
            try
            {
                DepartmentData newDepartmentData = DepartmentDataMgr.Instance().AddNewDepartment(selectDepartment, bumenNameEdit.Text, bumenzhuguanEdit.Text, qtLevel);
                this.DialogResult = DialogResult.OK;
                newDepartmentId = newDepartmentData.Id;
                Close();
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

        private void EditClick()
        {
            if (bumenNameEdit.Text == "")
            {
                MessageBox.Show("部门名字不能为空");
                return;
            }

            string newBumenName = bumenNameEdit.Text;
            string newBumenOwner = bumenzhuguanEdit.Text;

            if (newBumenName != selectDepartment.Name || newBumenOwner != selectDepartment.OwnerJobNumber)
            {
                try
                {
                    DepartmentDataMgr.Instance().ModifyDepartment(selectDepartment.Id, newBumenName, newBumenOwner);
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
                    Application.Exit();
                }
                
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DepartmentOperDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            selectDepartment = null;
        }

        private void departmentSelectBtn_Click(object sender, EventArgs e)
        {
            //
            if (mode == EditMode.EM_EDIT)
            {
                //只有添加模式才能选择上级
                return;
            }
            DepartmentSelectDlg dlg = new DepartmentSelectDlg();
            if (DialogResult.OK != dlg.ShowDialog())
            {
                return;
            }
            if (dlg.SelectDepartment != null)
            {
                if (dlg.SelectDepartment.IsMaxLayer())
                {
                    MessageBox.Show("只能有四层部门");
                    dlg.SelectDepartment = null;
                    return;
                }

                if (dlg.SelectDepartment.QTLevel == QtLevel.ZhuchangZhuguan)
                {
                    MessageBox.Show("驻场只能有三层部门");
                    dlg.SelectDepartment = null;
                    return;
                }

                selectDepartment = dlg.SelectDepartment;
                dlg.SelectDepartment = null;

                AddInit();
            }
        }

        private void AddInit()
        {
            qtLevelSelect.Items.Clear();
            this.Text = "添加部门";
            if (selectDepartment != null)
            {
                shangjiBumenEdit.Text = selectDepartment.Name;
                shangjiIdEdit.Text = selectDepartment.Id.ToString();
                if (selectDepartment.QTLevel != QtLevel.None)
                {
                    if (selectDepartment.Layer == 0)
                    {
                        //父节点是根节点
                        MessageBox.Show("部门关系错误0");
                        Application.Exit();

                    }
                    else if (selectDepartment.Layer == 1)
                    {
                        //父节点是总监级别,只能设置能大主管或者驻场总监
                        if (selectDepartment.QTLevel == QtLevel.Majordomo)
                        {
                            qtLevelSelect.Items.Insert(0, QtString.LargeCharge);
                        }
                        else if (selectDepartment.QTLevel == QtLevel.ZhuchangZongjian)
                        {
                            qtLevelSelect.Items.Insert(0, QtString.ZhuchangZhuguan);
                        }
                        else
                        {
                            MessageBox.Show("部门关系错误1");
                            Application.Exit();
                        }
                        
                    }
                    else if (selectDepartment.Layer == 2)
                    {
                        //父节点是大主管级别或者驻场主管
                        if (selectDepartment.QTLevel == QtLevel.LargeCharge)
                        {
                            qtLevelSelect.Items.Insert(0, QtString.SmallCharge);
                        } 
                        else
                        {
                            MessageBox.Show("部门关系错误2");
                            Application.Exit();
                        }
                        
                    }
                    else
                    {
                        //不会走到这个分支
                        MessageBox.Show("部门关系错误3");
                        Application.Exit();
                    }
                }
                else
                {
                    //父节点没有QT级别
                    if (selectDepartment.Layer == 0)
                    {
                        //父节点是根节点,可以选择总结级别和没有QT级别和驻场总监
                        qtLevelSelect.Items.Insert(0, QtString.None);
                        qtLevelSelect.Items.Insert(1, QtString.Majordomo);
                        qtLevelSelect.Items.Insert(1, QtString.ZhuchangZongjian);
                    }
                    else
                    {
                        //子节点不能设置QT级别
                        qtLevelSelect.Items.Insert(0, QtString.None);
                    }
                }
            }
            else
            {
                QtUtil.SetComboxValue(qtLevelSelect, CbSetMode.CBSM_Department);
            }

            qtLevelSelect.SelectedIndex = 0;
        }


        void EditInit()
        {
            departmentSelectBtn.Enabled = false;
            qtLevelSelect.Enabled = false;


            //获取选择部门的上级部门
            if (selectDepartment.SuperiorId == 0)
            {
                //根目录了
                shangjiIdEdit.Text = "";
                shangjiBumenEdit.Text = "";
            }
            else
            {
                DepartmentData parentDepartment = DepartmentDataMgr.Instance().AllDepartmentData[selectDepartment.SuperiorId];
                shangjiIdEdit.Text = parentDepartment.Id.ToString();
                shangjiBumenEdit.Text = parentDepartment.Name;
            }

            bumenNameEdit.Text = selectDepartment.Name;
            bumenzhuguanEdit.Text = selectDepartment.OwnerJobNumber;


            qtLevelSelect.Items.Clear();
            qtLevelSelect.Items.Insert(0, QtUtil.GetQTLevelString(selectDepartment.QTLevel));
            qtLevelSelect.SelectedIndex = 0;
        }
    }
}
