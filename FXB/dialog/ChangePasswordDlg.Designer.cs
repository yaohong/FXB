namespace FXB.Dialog
{
    partial class ChangePasswordDlg
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
            this.oldPwdEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newPwdEdi = new System.Windows.Forms.TextBox();
            this.newPwdEdi1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码:";
            // 
            // oldPwdEdi
            // 
            this.oldPwdEdi.Location = new System.Drawing.Point(80, 26);
            this.oldPwdEdi.Name = "oldPwdEdi";
            this.oldPwdEdi.PasswordChar = '*';
            this.oldPwdEdi.Size = new System.Drawing.Size(159, 21);
            this.oldPwdEdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "新密码:";
            // 
            // newPwdEdi
            // 
            this.newPwdEdi.Location = new System.Drawing.Point(80, 54);
            this.newPwdEdi.Name = "newPwdEdi";
            this.newPwdEdi.PasswordChar = '*';
            this.newPwdEdi.Size = new System.Drawing.Size(159, 21);
            this.newPwdEdi.TabIndex = 3;
            // 
            // newPwdEdi1
            // 
            this.newPwdEdi1.Location = new System.Drawing.Point(80, 82);
            this.newPwdEdi1.Name = "newPwdEdi1";
            this.newPwdEdi1.PasswordChar = '*';
            this.newPwdEdi1.Size = new System.Drawing.Size(159, 21);
            this.newPwdEdi1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "确认密码:";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(80, 110);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "确认";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(161, 110);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(78, 23);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "退出";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // ChangePasswordDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 155);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newPwdEdi1);
            this.Controls.Add(this.newPwdEdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldPwdEdi);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.ChangePasswordDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldPwdEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPwdEdi;
        private System.Windows.Forms.TextBox newPwdEdi1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}