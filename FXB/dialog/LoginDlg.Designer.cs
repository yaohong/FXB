﻿namespace FXB.Dialog
{
    partial class LoginDlg
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
            this.label2 = new System.Windows.Forms.Label();
            this.jobnumberEdi = new System.Windows.Forms.TextBox();
            this.passwordEdi = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            // 
            // jobnumberEdi
            // 
            this.jobnumberEdi.Location = new System.Drawing.Point(68, 31);
            this.jobnumberEdi.Name = "jobnumberEdi";
            this.jobnumberEdi.Size = new System.Drawing.Size(168, 21);
            this.jobnumberEdi.TabIndex = 2;
            // 
            // passwordEdi
            // 
            this.passwordEdi.Location = new System.Drawing.Point(68, 67);
            this.passwordEdi.Name = "passwordEdi";
            this.passwordEdi.PasswordChar = '*';
            this.passwordEdi.Size = new System.Drawing.Size(168, 21);
            this.passwordEdi.TabIndex = 3;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(68, 117);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "登录";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(161, 117);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // LoginDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 160);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordEdi);
            this.Controls.Add(this.jobnumberEdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jobnumberEdi;
        private System.Windows.Forms.TextBox passwordEdi;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}