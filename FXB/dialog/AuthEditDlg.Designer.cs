namespace FXB.Dialog
{
    partial class AuthEditDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewLevelCb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.prohibitCb = new System.Windows.Forms.CheckBox();
            this.resertPwdBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pwdEdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.zhijieEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bumenEdi = new System.Windows.Forms.TextBox();
            this.nameEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gonghaoEdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jobMenuCb = new System.Windows.Forms.CheckBox();
            this.jobLevelMenuCb = new System.Windows.Forms.CheckBox();
            this.projectMenuCb = new System.Windows.Forms.CheckBox();
            this.userAuthMenuCb = new System.Windows.Forms.CheckBox();
            this.refreshMenuCb = new System.Windows.Forms.CheckBox();
            this.kaidanMenuCb = new System.Windows.Forms.CheckBox();
            this.huyongMenuCb = new System.Windows.Forms.CheckBox();
            this.tuidanMenuCb = new System.Windows.Forms.CheckBox();
            this.dxluruMenuCb = new System.Windows.Forms.CheckBox();
            this.generateDxMenuCb = new System.Windows.Forms.CheckBox();
            this.qtTaskMenuCb = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewLevelCb
            // 
            this.viewLevelCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewLevelCb.FormattingEnabled = true;
            this.viewLevelCb.Location = new System.Drawing.Point(121, 212);
            this.viewLevelCb.Name = "viewLevelCb";
            this.viewLevelCb.Size = new System.Drawing.Size(261, 20);
            this.viewLevelCb.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "数据权限:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "禁止登陆:";
            // 
            // prohibitCb
            // 
            this.prohibitCb.AutoSize = true;
            this.prohibitCb.Location = new System.Drawing.Point(121, 190);
            this.prohibitCb.Name = "prohibitCb";
            this.prohibitCb.Size = new System.Drawing.Size(210, 16);
            this.prohibitCb.TabIndex = 12;
            this.prohibitCb.Text = "勾选为禁止登陆,不勾选为允许登陆";
            this.prohibitCb.UseVisualStyleBackColor = true;
            // 
            // resertPwdBtn
            // 
            this.resertPwdBtn.Location = new System.Drawing.Point(121, 161);
            this.resertPwdBtn.Name = "resertPwdBtn";
            this.resertPwdBtn.Size = new System.Drawing.Size(261, 23);
            this.resertPwdBtn.TabIndex = 11;
            this.resertPwdBtn.Text = "重置密码为123";
            this.resertPwdBtn.UseVisualStyleBackColor = true;
            this.resertPwdBtn.Click += new System.EventHandler(this.resertPwdBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "重置密码:";
            // 
            // pwdEdi
            // 
            this.pwdEdi.Location = new System.Drawing.Point(121, 133);
            this.pwdEdi.Name = "pwdEdi";
            this.pwdEdi.ReadOnly = true;
            this.pwdEdi.Size = new System.Drawing.Size(261, 21);
            this.pwdEdi.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "密码:";
            // 
            // zhijieEdi
            // 
            this.zhijieEdi.Location = new System.Drawing.Point(121, 105);
            this.zhijieEdi.Name = "zhijieEdi";
            this.zhijieEdi.ReadOnly = true;
            this.zhijieEdi.Size = new System.Drawing.Size(261, 21);
            this.zhijieEdi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "职级:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "所属部门:";
            // 
            // bumenEdi
            // 
            this.bumenEdi.Location = new System.Drawing.Point(121, 78);
            this.bumenEdi.Name = "bumenEdi";
            this.bumenEdi.ReadOnly = true;
            this.bumenEdi.Size = new System.Drawing.Size(261, 21);
            this.bumenEdi.TabIndex = 4;
            // 
            // nameEdi
            // 
            this.nameEdi.Location = new System.Drawing.Point(121, 50);
            this.nameEdi.Name = "nameEdi";
            this.nameEdi.ReadOnly = true;
            this.nameEdi.Size = new System.Drawing.Size(261, 21);
            this.nameEdi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "员工姓名:";
            // 
            // gonghaoEdi
            // 
            this.gonghaoEdi.Location = new System.Drawing.Point(121, 22);
            this.gonghaoEdi.Name = "gonghaoEdi";
            this.gonghaoEdi.ReadOnly = true;
            this.gonghaoEdi.Size = new System.Drawing.Size(261, 21);
            this.gonghaoEdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工工号:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(25, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 297);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bumenEdi);
            this.tabPage2.Controls.Add(this.viewLevelCb);
            this.tabPage2.Controls.Add(this.zhijieEdi);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.pwdEdi);
            this.tabPage2.Controls.Add(this.gonghaoEdi);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.prohibitCb);
            this.tabPage2.Controls.Add(this.nameEdi);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.resertPwdBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户权限";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.qtTaskMenuCb);
            this.tabPage3.Controls.Add(this.generateDxMenuCb);
            this.tabPage3.Controls.Add(this.dxluruMenuCb);
            this.tabPage3.Controls.Add(this.tuidanMenuCb);
            this.tabPage3.Controls.Add(this.huyongMenuCb);
            this.tabPage3.Controls.Add(this.kaidanMenuCb);
            this.tabPage3.Controls.Add(this.refreshMenuCb);
            this.tabPage3.Controls.Add(this.userAuthMenuCb);
            this.tabPage3.Controls.Add(this.projectMenuCb);
            this.tabPage3.Controls.Add(this.jobLevelMenuCb);
            this.tabPage3.Controls.Add(this.jobMenuCb);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(457, 271);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "菜单权限";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jobMenuCb
            // 
            this.jobMenuCb.AutoSize = true;
            this.jobMenuCb.Location = new System.Drawing.Point(22, 15);
            this.jobMenuCb.Name = "jobMenuCb";
            this.jobMenuCb.Size = new System.Drawing.Size(72, 16);
            this.jobMenuCb.TabIndex = 0;
            this.jobMenuCb.Text = "员工档案";
            this.jobMenuCb.UseVisualStyleBackColor = true;
            // 
            // jobLevelMenuCb
            // 
            this.jobLevelMenuCb.AutoSize = true;
            this.jobLevelMenuCb.Location = new System.Drawing.Point(22, 37);
            this.jobLevelMenuCb.Name = "jobLevelMenuCb";
            this.jobLevelMenuCb.Size = new System.Drawing.Size(72, 16);
            this.jobLevelMenuCb.TabIndex = 1;
            this.jobLevelMenuCb.Text = "职级档案";
            this.jobLevelMenuCb.UseVisualStyleBackColor = true;
            // 
            // projectMenuCb
            // 
            this.projectMenuCb.AutoSize = true;
            this.projectMenuCb.Location = new System.Drawing.Point(22, 59);
            this.projectMenuCb.Name = "projectMenuCb";
            this.projectMenuCb.Size = new System.Drawing.Size(72, 16);
            this.projectMenuCb.TabIndex = 2;
            this.projectMenuCb.Text = "项目档案";
            this.projectMenuCb.UseVisualStyleBackColor = true;
            // 
            // userAuthMenuCb
            // 
            this.userAuthMenuCb.AutoSize = true;
            this.userAuthMenuCb.Location = new System.Drawing.Point(22, 81);
            this.userAuthMenuCb.Name = "userAuthMenuCb";
            this.userAuthMenuCb.Size = new System.Drawing.Size(72, 16);
            this.userAuthMenuCb.TabIndex = 3;
            this.userAuthMenuCb.Text = "用户权限";
            this.userAuthMenuCb.UseVisualStyleBackColor = true;
            // 
            // refreshMenuCb
            // 
            this.refreshMenuCb.AutoSize = true;
            this.refreshMenuCb.Location = new System.Drawing.Point(22, 104);
            this.refreshMenuCb.Name = "refreshMenuCb";
            this.refreshMenuCb.Size = new System.Drawing.Size(72, 16);
            this.refreshMenuCb.TabIndex = 4;
            this.refreshMenuCb.Text = "刷新数据";
            this.refreshMenuCb.UseVisualStyleBackColor = true;
            // 
            // kaidanMenuCb
            // 
            this.kaidanMenuCb.AutoSize = true;
            this.kaidanMenuCb.Location = new System.Drawing.Point(22, 126);
            this.kaidanMenuCb.Name = "kaidanMenuCb";
            this.kaidanMenuCb.Size = new System.Drawing.Size(72, 16);
            this.kaidanMenuCb.TabIndex = 5;
            this.kaidanMenuCb.Text = "开单录入";
            this.kaidanMenuCb.UseVisualStyleBackColor = true;
            // 
            // huyongMenuCb
            // 
            this.huyongMenuCb.AutoSize = true;
            this.huyongMenuCb.Location = new System.Drawing.Point(22, 148);
            this.huyongMenuCb.Name = "huyongMenuCb";
            this.huyongMenuCb.Size = new System.Drawing.Size(72, 16);
            this.huyongMenuCb.TabIndex = 6;
            this.huyongMenuCb.Text = "回佣录入";
            this.huyongMenuCb.UseVisualStyleBackColor = true;
            // 
            // tuidanMenuCb
            // 
            this.tuidanMenuCb.AutoSize = true;
            this.tuidanMenuCb.Location = new System.Drawing.Point(22, 170);
            this.tuidanMenuCb.Name = "tuidanMenuCb";
            this.tuidanMenuCb.Size = new System.Drawing.Size(72, 16);
            this.tuidanMenuCb.TabIndex = 7;
            this.tuidanMenuCb.Text = "退单录入";
            this.tuidanMenuCb.UseVisualStyleBackColor = true;
            // 
            // dxluruMenuCb
            // 
            this.dxluruMenuCb.AutoSize = true;
            this.dxluruMenuCb.Location = new System.Drawing.Point(22, 193);
            this.dxluruMenuCb.Name = "dxluruMenuCb";
            this.dxluruMenuCb.Size = new System.Drawing.Size(72, 16);
            this.dxluruMenuCb.TabIndex = 8;
            this.dxluruMenuCb.Text = "底薪录入";
            this.dxluruMenuCb.UseVisualStyleBackColor = true;
            // 
            // generateDxMenuCb
            // 
            this.generateDxMenuCb.AutoSize = true;
            this.generateDxMenuCb.Location = new System.Drawing.Point(22, 216);
            this.generateDxMenuCb.Name = "generateDxMenuCb";
            this.generateDxMenuCb.Size = new System.Drawing.Size(96, 16);
            this.generateDxMenuCb.TabIndex = 9;
            this.generateDxMenuCb.Text = "生成底薪副本";
            this.generateDxMenuCb.UseVisualStyleBackColor = true;
            // 
            // qtTaskMenuCb
            // 
            this.qtTaskMenuCb.AutoSize = true;
            this.qtTaskMenuCb.Location = new System.Drawing.Point(133, 15);
            this.qtTaskMenuCb.Name = "qtTaskMenuCb";
            this.qtTaskMenuCb.Size = new System.Drawing.Size(60, 16);
            this.qtTaskMenuCb.TabIndex = 10;
            this.qtTaskMenuCb.Text = "QT任务";
            this.qtTaskMenuCb.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(321, 341);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(415, 341);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // AuthEditDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 383);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthEditDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户权限编辑";
            this.Load += new System.EventHandler(this.AuthEditDlg_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gonghaoEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameEdi;
        private System.Windows.Forms.TextBox bumenEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zhijieEdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pwdEdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button resertPwdBtn;
        private System.Windows.Forms.CheckBox prohibitCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox viewLevelCb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox jobMenuCb;
        private System.Windows.Forms.CheckBox jobLevelMenuCb;
        private System.Windows.Forms.CheckBox projectMenuCb;
        private System.Windows.Forms.CheckBox userAuthMenuCb;
        private System.Windows.Forms.CheckBox refreshMenuCb;
        private System.Windows.Forms.CheckBox kaidanMenuCb;
        private System.Windows.Forms.CheckBox huyongMenuCb;
        private System.Windows.Forms.CheckBox tuidanMenuCb;
        private System.Windows.Forms.CheckBox dxluruMenuCb;
        private System.Windows.Forms.CheckBox generateDxMenuCb;
        private System.Windows.Forms.CheckBox qtTaskMenuCb;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}