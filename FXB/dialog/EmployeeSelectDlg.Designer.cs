namespace FXB.Dialog
{
    partial class EmployeeSelectDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myGroupBox1 = new FXB.MyControl.MyGroupBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.inquireBtn = new System.Windows.Forms.Button();
            this.paramEdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.myTreeView1 = new FXB.MyControl.MyTreeView();
            this.dataGridView1 = new FXB.MyControl.MyDataGridView();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.exitBtn);
            this.myGroupBox1.Controls.Add(this.inquireBtn);
            this.myGroupBox1.Controls.Add(this.paramEdi);
            this.myGroupBox1.Controls.Add(this.label1);
            this.myGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(393, 50);
            this.myGroupBox1.TabIndex = 0;
            this.myGroupBox1.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(301, 17);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // inquireBtn
            // 
            this.inquireBtn.Location = new System.Drawing.Point(220, 17);
            this.inquireBtn.Name = "inquireBtn";
            this.inquireBtn.Size = new System.Drawing.Size(75, 23);
            this.inquireBtn.TabIndex = 2;
            this.inquireBtn.Text = "查询数据";
            this.inquireBtn.UseVisualStyleBackColor = true;
            this.inquireBtn.Click += new System.EventHandler(this.inquireBtn_Click);
            // 
            // paramEdi
            // 
            this.paramEdi.Location = new System.Drawing.Point(72, 18);
            this.paramEdi.Name = "paramEdi";
            this.paramEdi.Size = new System.Drawing.Size(142, 21);
            this.paramEdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询参数:";
            // 
            // myTreeView1
            // 
            this.myTreeView1.Location = new System.Drawing.Point(13, 69);
            this.myTreeView1.Name = "myTreeView1";
            this.myTreeView1.Size = new System.Drawing.Size(182, 502);
            this.myTreeView1.TabIndex = 1;
            this.myTreeView1.Click += new System.EventHandler(this.myTreeView1_Click);
            this.myTreeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myTreeView1_MouseDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(201, 69);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(736, 502);
            this.dataGridView1.TabIndex = 2;
            // 
            // EmployeeSelectDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 583);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.myTreeView1);
            this.Controls.Add(this.myGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeSelectDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工选择";
            this.Load += new System.EventHandler(this.EmployeeSelectDlg_Load);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.MyGroupBox myGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paramEdi;
        private System.Windows.Forms.Button inquireBtn;
        private System.Windows.Forms.Button exitBtn;
        private MyControl.MyTreeView myTreeView1;
        private MyControl.MyDataGridView dataGridView1;
    }
}