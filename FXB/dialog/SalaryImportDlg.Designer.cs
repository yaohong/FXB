namespace FXB.Dialog
{
    partial class SalaryImportDlg
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
            this.myTableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.myGroupBox1 = new FXB.MyControl.MyGroupBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.InqueryBtn = new System.Windows.Forms.Button();
            this.qtCb = new System.Windows.Forms.ComboBox();
            this.myDataGridView1 = new FXB.MyControl.MyDataGridView();
            this.myTableLayoutPanel1.SuspendLayout();
            this.myGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myTableLayoutPanel1
            // 
            this.myTableLayoutPanel1.ColumnCount = 1;
            this.myTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.myTableLayoutPanel1.Controls.Add(this.myGroupBox1, 0, 0);
            this.myTableLayoutPanel1.Controls.Add(this.myDataGridView1, 0, 1);
            this.myTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.myTableLayoutPanel1.Name = "myTableLayoutPanel1";
            this.myTableLayoutPanel1.RowCount = 2;
            this.myTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myTableLayoutPanel1.Size = new System.Drawing.Size(1008, 588);
            this.myTableLayoutPanel1.TabIndex = 0;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.DeleteBtn);
            this.myGroupBox1.Controls.Add(this.ExportBtn);
            this.myGroupBox1.Controls.Add(this.InqueryBtn);
            this.myGroupBox1.Controls.Add(this.qtCb);
            this.myGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(1002, 53);
            this.myGroupBox1.TabIndex = 1;
            this.myGroupBox1.TabStop = false;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(311, 18);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 3;
            this.DeleteBtn.Text = "删除";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(230, 18);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(75, 23);
            this.ExportBtn.TabIndex = 2;
            this.ExportBtn.Text = "导入";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // InqueryBtn
            // 
            this.InqueryBtn.Location = new System.Drawing.Point(138, 18);
            this.InqueryBtn.Name = "InqueryBtn";
            this.InqueryBtn.Size = new System.Drawing.Size(75, 23);
            this.InqueryBtn.TabIndex = 1;
            this.InqueryBtn.Text = "查询";
            this.InqueryBtn.UseVisualStyleBackColor = true;
            this.InqueryBtn.Click += new System.EventHandler(this.InqueryBtn_Click);
            // 
            // qtCb
            // 
            this.qtCb.FormattingEnabled = true;
            this.qtCb.Location = new System.Drawing.Point(11, 20);
            this.qtCb.Name = "qtCb";
            this.qtCb.Size = new System.Drawing.Size(121, 20);
            this.qtCb.TabIndex = 0;
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
            this.myDataGridView1.Size = new System.Drawing.Size(1002, 523);
            this.myDataGridView1.TabIndex = 2;
            // 
            // SalaryImportDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 588);
            this.Controls.Add(this.myTableLayoutPanel1);
            this.Name = "SalaryImportDlg";
            this.Text = "导入工资";
            this.Load += new System.EventHandler(this.SalaryImportDlg_Load);
            this.myTableLayoutPanel1.ResumeLayout(false);
            this.myGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.MyTableLayoutPanel myTableLayoutPanel1;
        private MyControl.MyGroupBox myGroupBox1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button InqueryBtn;
        private System.Windows.Forms.ComboBox qtCb;
        private MyControl.MyDataGridView myDataGridView1;

    }
}