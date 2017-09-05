namespace FXB.Dialog
{
    partial class ViewHYDlg
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
            this.hyIDEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hyAmountEdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hyTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.jiesuanCb = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.ywyEdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ywyGZEdi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.kyfEdi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.kyfGZEdi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lable10 = new System.Windows.Forms.Label();
            this.checkJobNumberEdi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkTimeEdi = new System.Windows.Forms.TextBox();
            this.checkBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.checkStateEdi = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "回佣ID:";
            // 
            // hyIDEdi
            // 
            this.hyIDEdi.Location = new System.Drawing.Point(86, 17);
            this.hyIDEdi.Name = "hyIDEdi";
            this.hyIDEdi.Size = new System.Drawing.Size(289, 21);
            this.hyIDEdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "回佣金额:";
            // 
            // hyAmountEdi
            // 
            this.hyAmountEdi.Location = new System.Drawing.Point(86, 44);
            this.hyAmountEdi.Name = "hyAmountEdi";
            this.hyAmountEdi.Size = new System.Drawing.Size(289, 21);
            this.hyAmountEdi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "回佣时间:";
            // 
            // hyTime
            // 
            this.hyTime.Location = new System.Drawing.Point(86, 71);
            this.hyTime.Name = "hyTime";
            this.hyTime.Size = new System.Drawing.Size(289, 21);
            this.hyTime.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "是否结算:";
            // 
            // jiesuanCb
            // 
            this.jiesuanCb.AutoSize = true;
            this.jiesuanCb.Location = new System.Drawing.Point(86, 102);
            this.jiesuanCb.Name = "jiesuanCb";
            this.jiesuanCb.Size = new System.Drawing.Size(198, 16);
            this.jiesuanCb.TabIndex = 7;
            this.jiesuanCb.Text = "选择为结算,没有选择为没有结算";
            this.jiesuanCb.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(35, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 275);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkStateEdi);
            this.tabPage1.Controls.Add(this.exitBtn);
            this.tabPage1.Controls.Add(this.checkBtn);
            this.tabPage1.Controls.Add(this.checkTimeEdi);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.checkJobNumberEdi);
            this.tabPage1.Controls.Add(this.lable10);
            this.tabPage1.Controls.Add(this.hyIDEdi);
            this.tabPage1.Controls.Add(this.jiesuanCb);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.hyTime);
            this.tabPage1.Controls.Add(this.hyAmountEdi);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "回佣信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.kyfGZEdi);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.kyfEdi);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ywyGZEdi);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.ywyEdi);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "预发工资";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "业务员:";
            // 
            // ywyEdi
            // 
            this.ywyEdi.Location = new System.Drawing.Point(68, 15);
            this.ywyEdi.Name = "ywyEdi";
            this.ywyEdi.Size = new System.Drawing.Size(122, 21);
            this.ywyEdi.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "预发工资:";
            // 
            // ywyGZEdi
            // 
            this.ywyGZEdi.Location = new System.Drawing.Point(272, 15);
            this.ywyGZEdi.Name = "ywyGZEdi";
            this.ywyGZEdi.Size = new System.Drawing.Size(122, 21);
            this.ywyGZEdi.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "客源方:";
            // 
            // kyfEdi
            // 
            this.kyfEdi.Location = new System.Drawing.Point(68, 43);
            this.kyfEdi.Name = "kyfEdi";
            this.kyfEdi.Size = new System.Drawing.Size(122, 21);
            this.kyfEdi.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "预发工资:";
            // 
            // kyfGZEdi
            // 
            this.kyfGZEdi.Location = new System.Drawing.Point(272, 43);
            this.kyfGZEdi.Name = "kyfGZEdi";
            this.kyfGZEdi.Size = new System.Drawing.Size(122, 21);
            this.kyfGZEdi.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "审核状态:";
            // 
            // lable10
            // 
            this.lable10.AutoSize = true;
            this.lable10.Location = new System.Drawing.Point(33, 160);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(47, 12);
            this.lable10.TabIndex = 2;
            this.lable10.Text = "审核人:";
            // 
            // checkJobNumberEdi
            // 
            this.checkJobNumberEdi.Location = new System.Drawing.Point(86, 151);
            this.checkJobNumberEdi.Name = "checkJobNumberEdi";
            this.checkJobNumberEdi.Size = new System.Drawing.Size(289, 21);
            this.checkJobNumberEdi.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "审核时间:";
            // 
            // checkTimeEdi
            // 
            this.checkTimeEdi.Location = new System.Drawing.Point(86, 178);
            this.checkTimeEdi.Name = "checkTimeEdi";
            this.checkTimeEdi.Size = new System.Drawing.Size(289, 21);
            this.checkTimeEdi.TabIndex = 11;
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(86, 205);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(49, 23);
            this.checkBtn.TabIndex = 12;
            this.checkBtn.Text = "审核";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(326, 205);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(49, 23);
            this.exitBtn.TabIndex = 14;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // checkStateEdi
            // 
            this.checkStateEdi.Location = new System.Drawing.Point(86, 124);
            this.checkStateEdi.Name = "checkStateEdi";
            this.checkStateEdi.Size = new System.Drawing.Size(289, 21);
            this.checkStateEdi.TabIndex = 15;
            // 
            // ViewHYDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 317);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewHYDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看回佣";
            this.Load += new System.EventHandler(this.ViewHYDlg_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hyIDEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hyAmountEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hyTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox jiesuanCb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ywyEdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ywyGZEdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kyfEdi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox kyfGZEdi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lable10;
        private System.Windows.Forms.TextBox checkJobNumberEdi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox checkTimeEdi;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox checkStateEdi;
    }
}