namespace FXB.Dialog
{
    partial class DepartmentOperDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.shangjiIdEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shangjiBumenEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bumenNameEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bumenzhuguanEdit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.qtLevelSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上级ID:";
            // 
            // shangjiIdEdit
            // 
            this.shangjiIdEdit.Location = new System.Drawing.Point(96, 22);
            this.shangjiIdEdit.Name = "shangjiIdEdit";
            this.shangjiIdEdit.ReadOnly = true;
            this.shangjiIdEdit.Size = new System.Drawing.Size(114, 21);
            this.shangjiIdEdit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "上级部门:";
            // 
            // shangjiBumenEdit
            // 
            this.shangjiBumenEdit.Location = new System.Drawing.Point(96, 49);
            this.shangjiBumenEdit.Name = "shangjiBumenEdit";
            this.shangjiBumenEdit.ReadOnly = true;
            this.shangjiBumenEdit.Size = new System.Drawing.Size(114, 21);
            this.shangjiBumenEdit.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "部门名称:";
            // 
            // bumenNameEdit
            // 
            this.bumenNameEdit.Location = new System.Drawing.Point(96, 76);
            this.bumenNameEdit.Name = "bumenNameEdit";
            this.bumenNameEdit.Size = new System.Drawing.Size(114, 21);
            this.bumenNameEdit.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "部门主管:";
            // 
            // bumenzhuguanEdit
            // 
            this.bumenzhuguanEdit.Location = new System.Drawing.Point(96, 103);
            this.bumenzhuguanEdit.Name = "bumenzhuguanEdit";
            this.bumenzhuguanEdit.Size = new System.Drawing.Size(114, 21);
            this.bumenzhuguanEdit.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(57, 165);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(159, 165);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "退出";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "QT级别:";
            // 
            // qtLevelSelect
            // 
            this.qtLevelSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qtLevelSelect.FormattingEnabled = true;
            this.qtLevelSelect.Location = new System.Drawing.Point(96, 131);
            this.qtLevelSelect.Name = "qtLevelSelect";
            this.qtLevelSelect.Size = new System.Drawing.Size(114, 20);
            this.qtLevelSelect.TabIndex = 13;
            // 
            // DepartmentOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 209);
            this.Controls.Add(this.qtLevelSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bumenzhuguanEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bumenNameEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.shangjiBumenEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shangjiIdEdit);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentOperDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增部门";
            this.Load += new System.EventHandler(this.DepartmentOperDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox shangjiIdEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shangjiBumenEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bumenNameEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bumenzhuguanEdit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox qtLevelSelect;
    }
}