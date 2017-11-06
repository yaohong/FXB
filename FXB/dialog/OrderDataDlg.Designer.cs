namespace FXB.Dialog
{
    partial class OrderDataDlg
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
            this.myTableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.groupBox1 = new FXB.MyControl.MyGroupBox();
            this.qtCbSelect = new System.Windows.Forms.ComboBox();
            this.removeOrderBtn = new System.Windows.Forms.Button();
            this.addOrderBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.inquireBtn = new System.Windows.Forms.Button();
            this.salesmanSelectBtn = new System.Windows.Forms.Button();
            this.salesmanEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paramEdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new FXB.MyControl.MyDataGridView();
            this.noCheckCb = new System.Windows.Forms.CheckBox();
            this.myTableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myTableLayoutPanel1
            // 
            this.myTableLayoutPanel1.ColumnCount = 1;
            this.myTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.myTableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.myTableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.myTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.myTableLayoutPanel1.Name = "myTableLayoutPanel1";
            this.myTableLayoutPanel1.RowCount = 2;
            this.myTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.myTableLayoutPanel1.Size = new System.Drawing.Size(1227, 615);
            this.myTableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noCheckCb);
            this.groupBox1.Controls.Add(this.qtCbSelect);
            this.groupBox1.Controls.Add(this.removeOrderBtn);
            this.groupBox1.Controls.Add(this.addOrderBtn);
            this.groupBox1.Controls.Add(this.exportBtn);
            this.groupBox1.Controls.Add(this.inquireBtn);
            this.groupBox1.Controls.Add(this.salesmanSelectBtn);
            this.groupBox1.Controls.Add(this.salesmanEdi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.paramEdi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1221, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // qtCbSelect
            // 
            this.qtCbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qtCbSelect.FormattingEnabled = true;
            this.qtCbSelect.Location = new System.Drawing.Point(254, 16);
            this.qtCbSelect.Name = "qtCbSelect";
            this.qtCbSelect.Size = new System.Drawing.Size(134, 20);
            this.qtCbSelect.TabIndex = 13;
            // 
            // removeOrderBtn
            // 
            this.removeOrderBtn.Location = new System.Drawing.Point(1060, 14);
            this.removeOrderBtn.Name = "removeOrderBtn";
            this.removeOrderBtn.Size = new System.Drawing.Size(75, 23);
            this.removeOrderBtn.TabIndex = 12;
            this.removeOrderBtn.Text = "删除开单";
            this.removeOrderBtn.UseVisualStyleBackColor = true;
            this.removeOrderBtn.Click += new System.EventHandler(this.removeOrderBtn_Click);
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.Location = new System.Drawing.Point(982, 14);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(75, 23);
            this.addOrderBtn.TabIndex = 11;
            this.addOrderBtn.Text = "新增开单";
            this.addOrderBtn.UseVisualStyleBackColor = true;
            this.addOrderBtn.Click += new System.EventHandler(this.addOrderBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(881, 14);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 23);
            this.exportBtn.TabIndex = 10;
            this.exportBtn.Text = "导出数据";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // inquireBtn
            // 
            this.inquireBtn.Location = new System.Drawing.Point(800, 14);
            this.inquireBtn.Name = "inquireBtn";
            this.inquireBtn.Size = new System.Drawing.Size(75, 23);
            this.inquireBtn.TabIndex = 9;
            this.inquireBtn.Text = "查询数据";
            this.inquireBtn.UseVisualStyleBackColor = true;
            this.inquireBtn.Click += new System.EventHandler(this.inquireBtn_Click);
            // 
            // salesmanSelectBtn
            // 
            this.salesmanSelectBtn.Location = new System.Drawing.Point(584, 15);
            this.salesmanSelectBtn.Name = "salesmanSelectBtn";
            this.salesmanSelectBtn.Size = new System.Drawing.Size(46, 23);
            this.salesmanSelectBtn.TabIndex = 8;
            this.salesmanSelectBtn.Text = "..";
            this.salesmanSelectBtn.UseVisualStyleBackColor = true;
            this.salesmanSelectBtn.Click += new System.EventHandler(this.salesmanSelectBtn_Click);
            // 
            // salesmanEdi
            // 
            this.salesmanEdi.Location = new System.Drawing.Point(478, 16);
            this.salesmanEdi.Name = "salesmanEdi";
            this.salesmanEdi.ReadOnly = true;
            this.salesmanEdi.Size = new System.Drawing.Size(100, 21);
            this.salesmanEdi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "营销顾问:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "QT任务:";
            // 
            // paramEdi
            // 
            this.paramEdi.Location = new System.Drawing.Point(71, 16);
            this.paramEdi.Name = "paramEdi";
            this.paramEdi.Size = new System.Drawing.Size(101, 21);
            this.paramEdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询参数:";
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1221, 559);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // noCheckCb
            // 
            this.noCheckCb.AutoSize = true;
            this.noCheckCb.Location = new System.Drawing.Point(657, 20);
            this.noCheckCb.Name = "noCheckCb";
            this.noCheckCb.Size = new System.Drawing.Size(96, 16);
            this.noCheckCb.TabIndex = 14;
            this.noCheckCb.Text = "有未审核回佣";
            this.noCheckCb.UseVisualStyleBackColor = true;
            // 
            // OrderDataDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 615);
            this.Controls.Add(this.myTableLayoutPanel1);
            this.Name = "OrderDataDlg";
            this.Text = "项目开单";
            this.Load += new System.EventHandler(this.OrderDataDlg_Load);
            this.myTableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.MyGroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox paramEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox salesmanEdi;
        private System.Windows.Forms.Button salesmanSelectBtn;
        private System.Windows.Forms.Button inquireBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button addOrderBtn;
        private System.Windows.Forms.Button removeOrderBtn;
        private MyControl.MyTableLayoutPanel myTableLayoutPanel1;
        private MyControl.MyDataGridView dataGridView1;
        private System.Windows.Forms.ComboBox qtCbSelect;
        private System.Windows.Forms.CheckBox noCheckCb;
    }
}