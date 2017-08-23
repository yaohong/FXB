namespace FXB.Dialog
{
    partial class SalaryDuplicateOperDlg
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
            this.tableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.groupBox1 = new FXB.MyControl.MyGroupBox();
            this.removeDxBtn = new System.Windows.Forms.Button();
            this.viewDxBtn = new System.Windows.Forms.Button();
            this.dxCb = new System.Windows.Forms.ComboBox();
            this.generateDxBtn = new System.Windows.Forms.Button();
            this.dxTaskTimeSelect = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new FXB.MyControl.MyDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(822, 634);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeDxBtn);
            this.groupBox1.Controls.Add(this.viewDxBtn);
            this.groupBox1.Controls.Add(this.dxCb);
            this.groupBox1.Controls.Add(this.generateDxBtn);
            this.groupBox1.Controls.Add(this.dxTaskTimeSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // removeDxBtn
            // 
            this.removeDxBtn.Location = new System.Drawing.Point(443, 18);
            this.removeDxBtn.Name = "removeDxBtn";
            this.removeDxBtn.Size = new System.Drawing.Size(75, 23);
            this.removeDxBtn.TabIndex = 4;
            this.removeDxBtn.Text = "删除副本";
            this.removeDxBtn.UseVisualStyleBackColor = true;
            this.removeDxBtn.Click += new System.EventHandler(this.removeDxBtn_Click);
            // 
            // viewDxBtn
            // 
            this.viewDxBtn.Location = new System.Drawing.Point(362, 18);
            this.viewDxBtn.Name = "viewDxBtn";
            this.viewDxBtn.Size = new System.Drawing.Size(75, 23);
            this.viewDxBtn.TabIndex = 3;
            this.viewDxBtn.Text = "查看副本";
            this.viewDxBtn.UseVisualStyleBackColor = true;
            this.viewDxBtn.Click += new System.EventHandler(this.viewDxBtn_Click);
            // 
            // dxCb
            // 
            this.dxCb.FormattingEnabled = true;
            this.dxCb.Location = new System.Drawing.Point(235, 20);
            this.dxCb.Name = "dxCb";
            this.dxCb.Size = new System.Drawing.Size(121, 20);
            this.dxCb.TabIndex = 2;
            // 
            // generateDxBtn
            // 
            this.generateDxBtn.Location = new System.Drawing.Point(87, 18);
            this.generateDxBtn.Name = "generateDxBtn";
            this.generateDxBtn.Size = new System.Drawing.Size(75, 23);
            this.generateDxBtn.TabIndex = 1;
            this.generateDxBtn.Text = "生成副本";
            this.generateDxBtn.UseVisualStyleBackColor = true;
            this.generateDxBtn.Click += new System.EventHandler(this.generateDxBtn_Click);
            // 
            // dxTaskTimeSelect
            // 
            this.dxTaskTimeSelect.Location = new System.Drawing.Point(13, 20);
            this.dxTaskTimeSelect.Name = "dxTaskTimeSelect";
            this.dxTaskTimeSelect.Size = new System.Drawing.Size(68, 21);
            this.dxTaskTimeSelect.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 64);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(816, 567);
            this.dataGridView1.TabIndex = 1;
            // 
            // SalaryDuplicateOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 634);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SalaryDuplicateOperDlg";
            this.Text = "底薪副本操作";
            this.Load += new System.EventHandler(this.SalaryDuplicateOperDlg_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FXB.MyControl.MyGroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dxTaskTimeSelect;
        private System.Windows.Forms.Button generateDxBtn;
        private System.Windows.Forms.ComboBox dxCb;
        private System.Windows.Forms.Button viewDxBtn;
        private System.Windows.Forms.Button removeDxBtn;
        private FXB.MyControl.MyTableLayoutPanel tableLayoutPanel1;
        private FXB.MyControl.MyDataGridView dataGridView1;
    }
}