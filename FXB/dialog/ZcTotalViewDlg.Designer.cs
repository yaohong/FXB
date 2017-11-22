namespace FXB.Dialog
{
    partial class ZcTotalViewDlg
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
            this.myGroupBox1 = new FXB.MyControl.MyGroupBox();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.InquertBtn = new System.Windows.Forms.Button();
            this.qtSelect = new System.Windows.Forms.ComboBox();
            this.myTableLayoutPanel1 = new FXB.MyControl.MyTableLayoutPanel();
            this.myDataGridView1 = new FXB.MyControl.MyDataGridView();
            this.myGroupBox1.SuspendLayout();
            this.myTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.ExportBtn);
            this.myGroupBox1.Controls.Add(this.InquertBtn);
            this.myGroupBox1.Controls.Add(this.qtSelect);
            this.myGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(853, 55);
            this.myGroupBox1.TabIndex = 0;
            this.myGroupBox1.TabStop = false;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(277, 19);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(75, 23);
            this.ExportBtn.TabIndex = 2;
            this.ExportBtn.Text = "导出";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // InquertBtn
            // 
            this.InquertBtn.Location = new System.Drawing.Point(134, 19);
            this.InquertBtn.Name = "InquertBtn";
            this.InquertBtn.Size = new System.Drawing.Size(75, 23);
            this.InquertBtn.TabIndex = 1;
            this.InquertBtn.Text = "查询";
            this.InquertBtn.UseVisualStyleBackColor = true;
            this.InquertBtn.Click += new System.EventHandler(this.InquertBtn_Click);
            // 
            // qtSelect
            // 
            this.qtSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qtSelect.FormattingEnabled = true;
            this.qtSelect.Location = new System.Drawing.Point(7, 21);
            this.qtSelect.Name = "qtSelect";
            this.qtSelect.Size = new System.Drawing.Size(121, 20);
            this.qtSelect.TabIndex = 0;
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
            this.myTableLayoutPanel1.Size = new System.Drawing.Size(859, 587);
            this.myTableLayoutPanel1.TabIndex = 1;
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
            this.myDataGridView1.Location = new System.Drawing.Point(3, 64);
            this.myDataGridView1.MultiSelect = false;
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.ReadOnly = true;
            this.myDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.myDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGridView1.Size = new System.Drawing.Size(853, 520);
            this.myDataGridView1.TabIndex = 1;
            // 
            // ZcTotalViewDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 587);
            this.Controls.Add(this.myTableLayoutPanel1);
            this.Name = "ZcTotalViewDlg";
            this.Text = "驻场提成表";
            this.Load += new System.EventHandler(this.ZcTotalViewDlg_Load);
            this.myGroupBox1.ResumeLayout(false);
            this.myTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyControl.MyGroupBox myGroupBox1;
        private System.Windows.Forms.ComboBox qtSelect;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button InquertBtn;
        private MyControl.MyTableLayoutPanel myTableLayoutPanel1;
        private MyControl.MyDataGridView myDataGridView1;
    }
}