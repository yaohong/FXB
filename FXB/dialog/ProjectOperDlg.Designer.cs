namespace FXB.Dialog
{
    partial class ProjectOperDlg
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
            this.codeEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameEdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addressEdi = new System.Windows.Forms.TextBox();
            this.commentEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.availableCheckBox = new System.Windows.Forms.CheckBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目编码:";
            // 
            // codeEdi
            // 
            this.codeEdi.Location = new System.Drawing.Point(91, 37);
            this.codeEdi.Name = "codeEdi";
            this.codeEdi.Size = new System.Drawing.Size(195, 21);
            this.codeEdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目名称:";
            // 
            // nameEdi
            // 
            this.nameEdi.Location = new System.Drawing.Point(92, 72);
            this.nameEdi.Name = "nameEdi";
            this.nameEdi.Size = new System.Drawing.Size(194, 21);
            this.nameEdi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "项目地址:";
            // 
            // addressEdi
            // 
            this.addressEdi.Location = new System.Drawing.Point(92, 109);
            this.addressEdi.Name = "addressEdi";
            this.addressEdi.Size = new System.Drawing.Size(194, 21);
            this.addressEdi.TabIndex = 5;
            // 
            // commentEdi
            // 
            this.commentEdi.Location = new System.Drawing.Point(92, 149);
            this.commentEdi.Multiline = true;
            this.commentEdi.Name = "commentEdi";
            this.commentEdi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentEdi.Size = new System.Drawing.Size(194, 90);
            this.commentEdi.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "备注:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "是否可用:";
            // 
            // availableCheckBox
            // 
            this.availableCheckBox.AutoSize = true;
            this.availableCheckBox.Location = new System.Drawing.Point(91, 258);
            this.availableCheckBox.Name = "availableCheckBox";
            this.availableCheckBox.Size = new System.Drawing.Size(174, 16);
            this.availableCheckBox.TabIndex = 9;
            this.availableCheckBox.Text = "勾选为可用,不勾选为不可用";
            this.availableCheckBox.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(211, 298);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(130, 298);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ProjectOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 347);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.availableCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.commentEdi);
            this.Controls.Add(this.addressEdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameEdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codeEdi);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectOperDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目信息编辑";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectOperDlg_FormClosed);
            this.Load += new System.EventHandler(this.ProjectOperDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addressEdi;
        private System.Windows.Forms.TextBox commentEdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox availableCheckBox;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}