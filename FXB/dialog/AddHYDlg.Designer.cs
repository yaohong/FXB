namespace FXB.Dialog
{
    partial class AddHYDlg
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
            this.hyAddTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.hyAmountEdi = new System.Windows.Forms.TextBox();
            this.addHYBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加时间:";
            // 
            // hyAddTime
            // 
            this.hyAddTime.Location = new System.Drawing.Point(91, 35);
            this.hyAddTime.Name = "hyAddTime";
            this.hyAddTime.Size = new System.Drawing.Size(170, 21);
            this.hyAddTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "回佣金额:";
            // 
            // hyAmountEdi
            // 
            this.hyAmountEdi.Location = new System.Drawing.Point(91, 62);
            this.hyAmountEdi.Name = "hyAmountEdi";
            this.hyAmountEdi.Size = new System.Drawing.Size(170, 21);
            this.hyAmountEdi.TabIndex = 3;
            // 
            // addHYBtn
            // 
            this.addHYBtn.Location = new System.Drawing.Point(91, 99);
            this.addHYBtn.Name = "addHYBtn";
            this.addHYBtn.Size = new System.Drawing.Size(75, 23);
            this.addHYBtn.TabIndex = 4;
            this.addHYBtn.Text = "添加";
            this.addHYBtn.UseVisualStyleBackColor = true;
            this.addHYBtn.Click += new System.EventHandler(this.addHYBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(186, 99);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 5;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // AddHYDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 134);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.addHYBtn);
            this.Controls.Add(this.hyAmountEdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hyAddTime);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddHYDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加回佣";
            this.Load += new System.EventHandler(this.AddHYDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker hyAddTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hyAmountEdi;
        private System.Windows.Forms.Button addHYBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}