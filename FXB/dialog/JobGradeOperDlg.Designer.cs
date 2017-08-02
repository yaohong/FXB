namespace FXB.Dialog
{
    partial class JobGradeOperDlg
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
            this.zhijiEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xulieEdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dixinEdi = new System.Windows.Forms.TextBox();
            this.beizhuEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "职级:";
            // 
            // zhijiEdi
            // 
            this.zhijiEdi.Location = new System.Drawing.Point(91, 38);
            this.zhijiEdi.Name = "zhijiEdi";
            this.zhijiEdi.Size = new System.Drawing.Size(218, 21);
            this.zhijiEdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "所属序列:";
            // 
            // xulieEdi
            // 
            this.xulieEdi.Location = new System.Drawing.Point(91, 69);
            this.xulieEdi.Name = "xulieEdi";
            this.xulieEdi.Size = new System.Drawing.Size(218, 21);
            this.xulieEdi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "对应底薪:";
            // 
            // dixinEdi
            // 
            this.dixinEdi.Location = new System.Drawing.Point(91, 101);
            this.dixinEdi.Name = "dixinEdi";
            this.dixinEdi.Size = new System.Drawing.Size(218, 21);
            this.dixinEdi.TabIndex = 5;
            this.dixinEdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dixinEdi_KeyPress);
            // 
            // beizhuEdi
            // 
            this.beizhuEdi.Location = new System.Drawing.Point(91, 135);
            this.beizhuEdi.Multiline = true;
            this.beizhuEdi.Name = "beizhuEdi";
            this.beizhuEdi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.beizhuEdi.Size = new System.Drawing.Size(218, 112);
            this.beizhuEdi.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "备注:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(91, 277);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(234, 277);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // JobGradeOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 316);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.beizhuEdi);
            this.Controls.Add(this.dixinEdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xulieEdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zhijiEdi);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobGradeOperDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "职级编辑";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JobGradeOperDlg_FormClosed);
            this.Load += new System.EventHandler(this.JobGradeOperDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zhijiEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xulieEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dixinEdi;
        private System.Windows.Forms.TextBox beizhuEdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}