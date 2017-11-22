namespace FXB.Dialog
{
    partial class HYSalaryViewDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myTableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.myGroupBox1 = new FXB.MyControl.MyGroupBox();
            this.qtSelectCb = new System.Windows.Forms.ComboBox();
            this.InqueryBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.myDataGridView1 = new FXB.MyControl.MyDataGridView();
            this.selectJobEdi = new System.Windows.Forms.TextBox();
            this.selectBtn = new System.Windows.Forms.Button();
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
            this.myTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.myTableLayoutPanel1.Size = new System.Drawing.Size(1266, 647);
            this.myTableLayoutPanel1.TabIndex = 5;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.selectBtn);
            this.myGroupBox1.Controls.Add(this.selectJobEdi);
            this.myGroupBox1.Controls.Add(this.qtSelectCb);
            this.myGroupBox1.Controls.Add(this.InqueryBtn);
            this.myGroupBox1.Controls.Add(this.label1);
            this.myGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(1260, 57);
            this.myGroupBox1.TabIndex = 4;
            this.myGroupBox1.TabStop = false;
            // 
            // qtSelectCb
            // 
            this.qtSelectCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qtSelectCb.FormattingEnabled = true;
            this.qtSelectCb.Location = new System.Drawing.Point(73, 23);
            this.qtSelectCb.Name = "qtSelectCb";
            this.qtSelectCb.Size = new System.Drawing.Size(107, 20);
            this.qtSelectCb.TabIndex = 1;
            // 
            // InqueryBtn
            // 
            this.InqueryBtn.Location = new System.Drawing.Point(186, 21);
            this.InqueryBtn.Name = "InqueryBtn";
            this.InqueryBtn.Size = new System.Drawing.Size(75, 23);
            this.InqueryBtn.TabIndex = 0;
            this.InqueryBtn.Text = "查询";
            this.InqueryBtn.UseVisualStyleBackColor = true;
            this.InqueryBtn.Click += new System.EventHandler(this.InqueryBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "选择月份:";
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToAddRows = false;
            this.myDataGridView1.AllowUserToResizeColumns = false;
            this.myDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Beige;
            this.myDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.Location = new System.Drawing.Point(3, 66);
            this.myDataGridView1.MultiSelect = false;
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Bisque;
            this.myDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGridView1.Size = new System.Drawing.Size(1260, 578);
            this.myDataGridView1.TabIndex = 3;
            // 
            // selectJobEdi
            // 
            this.selectJobEdi.Location = new System.Drawing.Point(357, 22);
            this.selectJobEdi.Name = "selectJobEdi";
            this.selectJobEdi.ReadOnly = true;
            this.selectJobEdi.Size = new System.Drawing.Size(100, 21);
            this.selectJobEdi.TabIndex = 3;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(462, 21);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(50, 23);
            this.selectBtn.TabIndex = 4;
            this.selectBtn.Text = "...";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // HYSalaryViewDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 647);
            this.Controls.Add(this.myTableLayoutPanel1);
            this.Name = "HYSalaryViewDlg";
            this.Text = "个人业务提成明细";
            this.Load += new System.EventHandler(this.HYSalaryViewDlg_Load);
            this.myTableLayoutPanel1.ResumeLayout(false);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InqueryBtn;
        private System.Windows.Forms.ComboBox qtSelectCb;
        private System.Windows.Forms.Label label1;
        private MyControl.MyDataGridView myDataGridView1;
        private MyControl.MyGroupBox myGroupBox1;
        private MyControl.MyTableLayoutPanel myTableLayoutPanel1;
        private System.Windows.Forms.TextBox selectJobEdi;
        private System.Windows.Forms.Button selectBtn;
    }
}