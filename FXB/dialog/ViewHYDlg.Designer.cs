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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.shuifeiEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.shouxufeiEdi = new System.Windows.Forms.TextBox();
            this.checkStateEdi = new System.Windows.Forms.TextBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.checkTimeEdi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkJobNumberEdi = new System.Windows.Forms.TextBox();
            this.lable10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.label3.Location = new System.Drawing.Point(21, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "回佣时间:";
            // 
            // hyTime
            // 
            this.hyTime.Location = new System.Drawing.Point(86, 126);
            this.hyTime.Name = "hyTime";
            this.hyTime.Size = new System.Drawing.Size(289, 21);
            this.hyTime.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(35, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 310);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.saveBtn);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.shuifeiEdi);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.shouxufeiEdi);
            this.tabPage1.Controls.Add(this.checkStateEdi);
            this.tabPage1.Controls.Add(this.exitBtn);
            this.tabPage1.Controls.Add(this.checkBtn);
            this.tabPage1.Controls.Add(this.checkTimeEdi);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.checkJobNumberEdi);
            this.tabPage1.Controls.Add(this.lable10);
            this.tabPage1.Controls.Add(this.hyIDEdi);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.hyTime);
            this.tabPage1.Controls.Add(this.hyAmountEdi);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 284);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "回佣信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(243, 234);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(63, 23);
            this.saveBtn.TabIndex = 20;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "税费:";
            // 
            // shuifeiEdi
            // 
            this.shuifeiEdi.Location = new System.Drawing.Point(86, 99);
            this.shuifeiEdi.Name = "shuifeiEdi";
            this.shuifeiEdi.Size = new System.Drawing.Size(289, 21);
            this.shuifeiEdi.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "手续费:";
            // 
            // shouxufeiEdi
            // 
            this.shouxufeiEdi.Location = new System.Drawing.Point(86, 72);
            this.shouxufeiEdi.Name = "shouxufeiEdi";
            this.shouxufeiEdi.Size = new System.Drawing.Size(289, 21);
            this.shouxufeiEdi.TabIndex = 16;
            // 
            // checkStateEdi
            // 
            this.checkStateEdi.Location = new System.Drawing.Point(86, 153);
            this.checkStateEdi.Name = "checkStateEdi";
            this.checkStateEdi.Size = new System.Drawing.Size(289, 21);
            this.checkStateEdi.TabIndex = 15;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(312, 234);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(63, 23);
            this.exitBtn.TabIndex = 14;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(86, 234);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(114, 23);
            this.checkBtn.TabIndex = 12;
            this.checkBtn.Text = "审核";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // checkTimeEdi
            // 
            this.checkTimeEdi.Location = new System.Drawing.Point(86, 207);
            this.checkTimeEdi.Name = "checkTimeEdi";
            this.checkTimeEdi.Size = new System.Drawing.Size(289, 21);
            this.checkTimeEdi.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "审核时间:";
            // 
            // checkJobNumberEdi
            // 
            this.checkJobNumberEdi.Location = new System.Drawing.Point(86, 180);
            this.checkJobNumberEdi.Name = "checkJobNumberEdi";
            this.checkJobNumberEdi.Size = new System.Drawing.Size(289, 21);
            this.checkJobNumberEdi.TabIndex = 9;
            // 
            // lable10
            // 
            this.lable10.AutoSize = true;
            this.lable10.Location = new System.Drawing.Point(33, 189);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(47, 12);
            this.lable10.TabIndex = 2;
            this.lable10.Text = "审核人:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "审核状态:";
            // 
            // ViewHYDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 380);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hyIDEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hyAmountEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hyTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lable10;
        private System.Windows.Forms.TextBox checkJobNumberEdi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox checkTimeEdi;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox checkStateEdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox shouxufeiEdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox shuifeiEdi;
        private System.Windows.Forms.Button saveBtn;
    }
}