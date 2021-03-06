﻿namespace FXB.Dialog
{
    partial class PersonnelDataDlg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rootTableLayoutPanel = new FXB.MyControl.MyTableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddDepartmentBtn = new System.Windows.Forms.Button();
            this.ModifyDepartmentBtn = new System.Windows.Forms.Button();
            this.RemoveDepartmentBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new FXB.MyControl.MyGroupBox();
            this.AddPersonnelBtn = new System.Windows.Forms.Button();
            this.gonghaoEdi = new System.Windows.Forms.TextBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.InquireBtn = new System.Windows.Forms.Button();
            this.lizhiMaxTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lizhiMinTime = new System.Windows.Forms.DateTimePicker();
            this.lizhiCb = new System.Windows.Forms.CheckBox();
            this.ruzhiMaxTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ruzhiMinTime = new System.Windows.Forms.DateTimePicker();
            this.ruzhiCb = new System.Windows.Forms.CheckBox();
            this.jobStateCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentTreeView = new FXB.MyControl.MyTreeView();
            this.dataGridView1 = new FXB.MyControl.MyDataGridView();
            this.RemovePersonnelBtn = new System.Windows.Forms.Button();
            this.rootTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rootTableLayoutPanel
            // 
            this.rootTableLayoutPanel.ColumnCount = 3;
            this.rootTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rootTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rootTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rootTableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.rootTableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this.rootTableLayoutPanel.Controls.Add(this.departmentTreeView, 0, 2);
            this.rootTableLayoutPanel.Controls.Add(this.dataGridView1, 1, 1);
            this.rootTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.rootTableLayoutPanel.Name = "rootTableLayoutPanel";
            this.rootTableLayoutPanel.RowCount = 3;
            this.rootTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rootTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rootTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rootTableLayoutPanel.Size = new System.Drawing.Size(1421, 779);
            this.rootTableLayoutPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddDepartmentBtn);
            this.panel1.Controls.Add(this.ModifyDepartmentBtn);
            this.panel1.Controls.Add(this.RemoveDepartmentBtn);
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.MaximumSize = new System.Drawing.Size(330, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 35);
            this.panel1.TabIndex = 1;
            // 
            // AddDepartmentBtn
            // 
            this.AddDepartmentBtn.Location = new System.Drawing.Point(3, 7);
            this.AddDepartmentBtn.Name = "AddDepartmentBtn";
            this.AddDepartmentBtn.Size = new System.Drawing.Size(75, 23);
            this.AddDepartmentBtn.TabIndex = 1;
            this.AddDepartmentBtn.Text = "新增部门";
            this.AddDepartmentBtn.UseVisualStyleBackColor = true;
            this.AddDepartmentBtn.Click += new System.EventHandler(this.AddDepartmentBtn_Click);
            // 
            // ModifyDepartmentBtn
            // 
            this.ModifyDepartmentBtn.Location = new System.Drawing.Point(84, 7);
            this.ModifyDepartmentBtn.Name = "ModifyDepartmentBtn";
            this.ModifyDepartmentBtn.Size = new System.Drawing.Size(75, 23);
            this.ModifyDepartmentBtn.TabIndex = 2;
            this.ModifyDepartmentBtn.Text = "修改部门";
            this.ModifyDepartmentBtn.UseVisualStyleBackColor = true;
            this.ModifyDepartmentBtn.Click += new System.EventHandler(this.ModifyDepartmentBtn_Click);
            // 
            // RemoveDepartmentBtn
            // 
            this.RemoveDepartmentBtn.Location = new System.Drawing.Point(165, 7);
            this.RemoveDepartmentBtn.Name = "RemoveDepartmentBtn";
            this.RemoveDepartmentBtn.Size = new System.Drawing.Size(75, 23);
            this.RemoveDepartmentBtn.TabIndex = 3;
            this.RemoveDepartmentBtn.Text = "删除部门";
            this.RemoveDepartmentBtn.UseVisualStyleBackColor = true;
            this.RemoveDepartmentBtn.Click += new System.EventHandler(this.RemoveDepartmentBtn_Click);
            // 
            // groupBox1
            // 
            this.rootTableLayoutPanel.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.RemovePersonnelBtn);
            this.groupBox1.Controls.Add(this.AddPersonnelBtn);
            this.groupBox1.Controls.Add(this.gonghaoEdi);
            this.groupBox1.Controls.Add(this.ExportBtn);
            this.groupBox1.Controls.Add(this.InquireBtn);
            this.groupBox1.Controls.Add(this.lizhiMaxTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lizhiMinTime);
            this.groupBox1.Controls.Add(this.lizhiCb);
            this.groupBox1.Controls.Add(this.ruzhiMaxTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ruzhiMinTime);
            this.groupBox1.Controls.Add(this.ruzhiCb);
            this.groupBox1.Controls.Add(this.jobStateCb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1415, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询参数:";
            // 
            // AddPersonnelBtn
            // 
            this.AddPersonnelBtn.Location = new System.Drawing.Point(1190, 20);
            this.AddPersonnelBtn.Name = "AddPersonnelBtn";
            this.AddPersonnelBtn.Size = new System.Drawing.Size(75, 23);
            this.AddPersonnelBtn.TabIndex = 13;
            this.AddPersonnelBtn.Text = "新增员工";
            this.AddPersonnelBtn.UseVisualStyleBackColor = true;
            this.AddPersonnelBtn.Click += new System.EventHandler(this.AddPersonnelBtn_Click);
            // 
            // gonghaoEdi
            // 
            this.gonghaoEdi.Location = new System.Drawing.Point(66, 21);
            this.gonghaoEdi.Name = "gonghaoEdi";
            this.gonghaoEdi.Size = new System.Drawing.Size(148, 21);
            this.gonghaoEdi.TabIndex = 1;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(1089, 20);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(75, 23);
            this.ExportBtn.TabIndex = 12;
            this.ExportBtn.Text = "导出数据";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // InquireBtn
            // 
            this.InquireBtn.Location = new System.Drawing.Point(1010, 20);
            this.InquireBtn.Name = "InquireBtn";
            this.InquireBtn.Size = new System.Drawing.Size(75, 23);
            this.InquireBtn.TabIndex = 11;
            this.InquireBtn.Text = "查询数据";
            this.InquireBtn.UseVisualStyleBackColor = true;
            this.InquireBtn.Click += new System.EventHandler(this.InquireBtn_Click);
            // 
            // lizhiMaxTime
            // 
            this.lizhiMaxTime.Location = new System.Drawing.Point(895, 21);
            this.lizhiMaxTime.Name = "lizhiMaxTime";
            this.lizhiMaxTime.Size = new System.Drawing.Size(101, 21);
            this.lizhiMaxTime.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(882, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "-";
            // 
            // lizhiMinTime
            // 
            this.lizhiMinTime.Location = new System.Drawing.Point(778, 21);
            this.lizhiMinTime.Name = "lizhiMinTime";
            this.lizhiMinTime.Size = new System.Drawing.Size(101, 21);
            this.lizhiMinTime.TabIndex = 8;
            // 
            // lizhiCb
            // 
            this.lizhiCb.AutoSize = true;
            this.lizhiCb.Location = new System.Drawing.Point(705, 25);
            this.lizhiCb.Name = "lizhiCb";
            this.lizhiCb.Size = new System.Drawing.Size(78, 16);
            this.lizhiCb.TabIndex = 7;
            this.lizhiCb.Text = "离职日期:";
            this.lizhiCb.UseVisualStyleBackColor = true;
            // 
            // ruzhiMaxTime
            // 
            this.ruzhiMaxTime.Location = new System.Drawing.Point(586, 21);
            this.ruzhiMaxTime.Name = "ruzhiMaxTime";
            this.ruzhiMaxTime.Size = new System.Drawing.Size(101, 21);
            this.ruzhiMaxTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(572, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // ruzhiMinTime
            // 
            this.ruzhiMinTime.Location = new System.Drawing.Point(470, 21);
            this.ruzhiMinTime.Name = "ruzhiMinTime";
            this.ruzhiMinTime.Size = new System.Drawing.Size(100, 21);
            this.ruzhiMinTime.TabIndex = 1;
            // 
            // ruzhiCb
            // 
            this.ruzhiCb.AutoSize = true;
            this.ruzhiCb.Location = new System.Drawing.Point(398, 25);
            this.ruzhiCb.Name = "ruzhiCb";
            this.ruzhiCb.Size = new System.Drawing.Size(78, 16);
            this.ruzhiCb.TabIndex = 4;
            this.ruzhiCb.Text = "入职日期:";
            this.ruzhiCb.UseVisualStyleBackColor = true;
            // 
            // jobStateCb
            // 
            this.jobStateCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jobStateCb.FormattingEnabled = true;
            this.jobStateCb.Location = new System.Drawing.Point(295, 22);
            this.jobStateCb.Name = "jobStateCb";
            this.jobStateCb.Size = new System.Drawing.Size(71, 20);
            this.jobStateCb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "在职状态:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工工号:";
            // 
            // departmentTreeView
            // 
            this.departmentTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentTreeView.Location = new System.Drawing.Point(3, 105);
            this.departmentTreeView.Name = "departmentTreeView";
            this.departmentTreeView.Size = new System.Drawing.Size(248, 671);
            this.departmentTreeView.TabIndex = 2;
            this.departmentTreeView.Click += new System.EventHandler(this.treeView1_Click);
            this.departmentTreeView.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.departmentTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.departmentTreeView_MouseDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rootTableLayoutPanel.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(257, 64);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.rootTableLayoutPanel.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1161, 712);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // RemovePersonnelBtn
            // 
            this.RemovePersonnelBtn.Location = new System.Drawing.Point(1271, 21);
            this.RemovePersonnelBtn.Name = "RemovePersonnelBtn";
            this.RemovePersonnelBtn.Size = new System.Drawing.Size(75, 23);
            this.RemovePersonnelBtn.TabIndex = 14;
            this.RemovePersonnelBtn.Text = "删除员工";
            this.RemovePersonnelBtn.UseVisualStyleBackColor = true;
            this.RemovePersonnelBtn.Click += new System.EventHandler(this.RemovePersonnelBtn_Click);
            // 
            // PersonnelDataDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 779);
            this.Controls.Add(this.rootTableLayoutPanel);
            this.Name = "PersonnelDataDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "员工资料";
            this.Load += new System.EventHandler(this.PersonnelDataDlg_Load);
            this.rootTableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FXB.MyControl.MyGroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gonghaoEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox jobStateCb;
        private System.Windows.Forms.CheckBox ruzhiCb;
        private System.Windows.Forms.DateTimePicker ruzhiMinTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker ruzhiMaxTime;
        private System.Windows.Forms.CheckBox lizhiCb;
        private System.Windows.Forms.DateTimePicker lizhiMinTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker lizhiMaxTime;
        private System.Windows.Forms.Button InquireBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button AddPersonnelBtn;
        private FXB.MyControl.MyTableLayoutPanel rootTableLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddDepartmentBtn;
        private System.Windows.Forms.Button ModifyDepartmentBtn;
        private System.Windows.Forms.Button RemoveDepartmentBtn;
        private FXB.MyControl.MyTreeView departmentTreeView;
        private FXB.MyControl.MyDataGridView dataGridView1;
        private System.Windows.Forms.Button RemovePersonnelBtn;

    }
}