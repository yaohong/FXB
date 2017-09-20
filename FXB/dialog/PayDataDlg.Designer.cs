namespace FXB.Dialog
{
    partial class PayDataDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new FXB.MyControl.MyGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.monthSelectCb = new System.Windows.Forms.ComboBox();
            this.InquireBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.myDataGridView1 = new FXB.MyControl.MyDataGridView();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.GenerateBtn);
            this.groupBox1.Controls.Add(this.monthSelectCb);
            this.groupBox1.Controls.Add(this.InquireBtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "月份选择:";
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Location = new System.Drawing.Point(308, 19);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.GenerateBtn.TabIndex = 3;
            this.GenerateBtn.Text = "生成";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            this.GenerateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // monthSelectCb
            // 
            this.monthSelectCb.FormattingEnabled = true;
            this.monthSelectCb.Location = new System.Drawing.Point(74, 21);
            this.monthSelectCb.Name = "monthSelectCb";
            this.monthSelectCb.Size = new System.Drawing.Size(145, 20);
            this.monthSelectCb.TabIndex = 2;
            // 
            // InquireBtn
            // 
            this.InquireBtn.Location = new System.Drawing.Point(229, 19);
            this.InquireBtn.Name = "InquireBtn";
            this.InquireBtn.Size = new System.Drawing.Size(75, 23);
            this.InquireBtn.TabIndex = 1;
            this.InquireBtn.Text = "查询";
            this.InquireBtn.UseVisualStyleBackColor = true;
            this.InquireBtn.Click += new System.EventHandler(this.InquireBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.myDataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 532);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.AllowUserToResizeColumns = false;
            this.myDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.myDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.Location = new System.Drawing.Point(3, 62);
            this.myDataGridView1.MultiSelect = false;
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.myDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGridView1.Size = new System.Drawing.Size(631, 467);
            this.myDataGridView1.TabIndex = 1;
            // 
            // PayDataDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 532);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PayDataDlg";
            this.Text = "QT工资";
            this.Load += new System.EventHandler(this.PayDataDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.MyGroupBox groupBox1;
        private System.Windows.Forms.Button InquireBtn;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.ComboBox monthSelectCb;
        private MyControl.MyTableLayoutPanel tableLayoutPanel1;
        private MyControl.MyDataGridView myDataGridView1;
        private System.Windows.Forms.Label label1;
    }
}