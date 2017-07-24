namespace FXB.Dialog
{
    partial class QtTaskOperDlg
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
            this.tableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.dataGridView1 = new FXB.MyControl.MyDataGridView();
            this.groupBox1 = new FXB.MyControl.MyGroupBox();
            this.removeQtTaskBtn = new System.Windows.Forms.Button();
            this.generateQtPushbtn = new System.Windows.Forms.Button();
            this.viewQtTaskBtn = new System.Windows.Forms.Button();
            this.qtCb = new System.Windows.Forms.ComboBox();
            this.qtTaskGenerateBtn = new System.Windows.Forms.Button();
            this.qtTaskTimeSelect = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(686, 499);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 60);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(680, 436);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeQtTaskBtn);
            this.groupBox1.Controls.Add(this.generateQtPushbtn);
            this.groupBox1.Controls.Add(this.viewQtTaskBtn);
            this.groupBox1.Controls.Add(this.qtCb);
            this.groupBox1.Controls.Add(this.qtTaskGenerateBtn);
            this.groupBox1.Controls.Add(this.qtTaskTimeSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // removeQtTaskBtn
            // 
            this.removeQtTaskBtn.Location = new System.Drawing.Point(491, 19);
            this.removeQtTaskBtn.Name = "removeQtTaskBtn";
            this.removeQtTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.removeQtTaskBtn.TabIndex = 6;
            this.removeQtTaskBtn.Text = "删除QT任务";
            this.removeQtTaskBtn.UseVisualStyleBackColor = true;
            this.removeQtTaskBtn.Click += new System.EventHandler(this.removeQtTaskBtn_Click);
            // 
            // generateQtPushbtn
            // 
            this.generateQtPushbtn.Location = new System.Drawing.Point(410, 19);
            this.generateQtPushbtn.Name = "generateQtPushbtn";
            this.generateQtPushbtn.Size = new System.Drawing.Size(75, 23);
            this.generateQtPushbtn.TabIndex = 5;
            this.generateQtPushbtn.Text = "生成QT提成";
            this.generateQtPushbtn.UseVisualStyleBackColor = true;
            this.generateQtPushbtn.Click += new System.EventHandler(this.generateQtPushbtn_Click);
            // 
            // viewQtTaskBtn
            // 
            this.viewQtTaskBtn.Location = new System.Drawing.Point(329, 19);
            this.viewQtTaskBtn.Name = "viewQtTaskBtn";
            this.viewQtTaskBtn.Size = new System.Drawing.Size(75, 23);
            this.viewQtTaskBtn.TabIndex = 3;
            this.viewQtTaskBtn.Text = "查看QT任务";
            this.viewQtTaskBtn.UseVisualStyleBackColor = true;
            this.viewQtTaskBtn.Click += new System.EventHandler(this.viewQtTaskBtn_Click);
            // 
            // qtCb
            // 
            this.qtCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qtCb.FormattingEnabled = true;
            this.qtCb.Location = new System.Drawing.Point(202, 21);
            this.qtCb.Name = "qtCb";
            this.qtCb.Size = new System.Drawing.Size(121, 20);
            this.qtCb.TabIndex = 2;
            // 
            // qtTaskGenerateBtn
            // 
            this.qtTaskGenerateBtn.Location = new System.Drawing.Point(90, 19);
            this.qtTaskGenerateBtn.Name = "qtTaskGenerateBtn";
            this.qtTaskGenerateBtn.Size = new System.Drawing.Size(75, 23);
            this.qtTaskGenerateBtn.TabIndex = 1;
            this.qtTaskGenerateBtn.Text = "生成QT任务";
            this.qtTaskGenerateBtn.UseVisualStyleBackColor = true;
            this.qtTaskGenerateBtn.Click += new System.EventHandler(this.qtTaskGenerateBtn_Click);
            // 
            // qtTaskTimeSelect
            // 
            this.qtTaskTimeSelect.Location = new System.Drawing.Point(16, 20);
            this.qtTaskTimeSelect.Name = "qtTaskTimeSelect";
            this.qtTaskTimeSelect.Size = new System.Drawing.Size(67, 21);
            this.qtTaskTimeSelect.TabIndex = 0;
            // 
            // QtTaskOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 499);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QtTaskOperDlg";
            this.Text = "QT操作";
            this.Load += new System.EventHandler(this.QtTaskOperDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FXB.MyControl.MyTableLayoutPanel tableLayoutPanel1;
        private FXB.MyControl.MyGroupBox groupBox1;
        private System.Windows.Forms.Button qtTaskGenerateBtn;
        private System.Windows.Forms.DateTimePicker qtTaskTimeSelect;
        private System.Windows.Forms.Button viewQtTaskBtn;
        private System.Windows.Forms.ComboBox qtCb;
        private FXB.MyControl.MyDataGridView dataGridView1;
        private System.Windows.Forms.Button generateQtPushbtn;
        private System.Windows.Forms.Button removeQtTaskBtn;
    }
}