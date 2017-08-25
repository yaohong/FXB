namespace FXB.Dialog
{
    partial class OrderOperDlg
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
            this.yongjinzongeEdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.orderGenerateTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.beizhuEdi = new System.Windows.Forms.TextBox();
            this.zhuchang2SelectBtn = new System.Windows.Forms.Button();
            this.zhuchang2Edi = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.zhuchang1SelectBtn = new System.Windows.Forms.Button();
            this.zhuchang1Edi = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.keyuanSelectBtn = new System.Windows.Forms.Button();
            this.keyuanEdi = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.guwenSelectBtn = new System.Windows.Forms.Button();
            this.guwenEdi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.shenheInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.shenheBtn = new System.Windows.Forms.Button();
            this.cancelShenheBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.myGroupBox1 = new FXB.MyControl.MyGroupBox();
            this.buyTime = new System.Windows.Forms.DateTimePicker();
            this.daikuanjineEdi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fukuanTypeEdi = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.hetongzhuangtaiEdi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.mianjiEdi = new System.Windows.Forms.TextBox();
            this.projectNameSelectBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.shoujuEdi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.shenfenzhengEdi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kehudianhuaEdi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cjZongjiaEdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.roomNumberEdi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.projectNameEdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kehuNameEdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.myGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yongjinzongeEdi
            // 
            this.yongjinzongeEdi.Location = new System.Drawing.Point(398, 21);
            this.yongjinzongeEdi.Name = "yongjinzongeEdi";
            this.yongjinzongeEdi.Size = new System.Drawing.Size(165, 21);
            this.yongjinzongeEdi.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "佣金总额:";
            // 
            // orderGenerateTime
            // 
            this.orderGenerateTime.Location = new System.Drawing.Point(87, 20);
            this.orderGenerateTime.Name = "orderGenerateTime";
            this.orderGenerateTime.Size = new System.Drawing.Size(165, 21);
            this.orderGenerateTime.TabIndex = 5;
            this.orderGenerateTime.ValueChanged += new System.EventHandler(this.orderGenerateTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "开单日期:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.beizhuEdi);
            this.groupBox1.Controls.Add(this.zhuchang2SelectBtn);
            this.groupBox1.Controls.Add(this.zhuchang2Edi);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.zhuchang1SelectBtn);
            this.groupBox1.Controls.Add(this.zhuchang1Edi);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.keyuanSelectBtn);
            this.groupBox1.Controls.Add(this.keyuanEdi);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.guwenSelectBtn);
            this.groupBox1.Controls.Add(this.guwenEdi);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.orderGenerateTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.yongjinzongeEdi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(31, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 211);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作人员信息";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(46, 153);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 26;
            this.label19.Text = "备注:";
            // 
            // beizhuEdi
            // 
            this.beizhuEdi.Location = new System.Drawing.Point(87, 115);
            this.beizhuEdi.Multiline = true;
            this.beizhuEdi.Name = "beizhuEdi";
            this.beizhuEdi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.beizhuEdi.Size = new System.Drawing.Size(476, 81);
            this.beizhuEdi.TabIndex = 25;
            // 
            // zhuchang2SelectBtn
            // 
            this.zhuchang2SelectBtn.Location = new System.Drawing.Point(569, 75);
            this.zhuchang2SelectBtn.Name = "zhuchang2SelectBtn";
            this.zhuchang2SelectBtn.Size = new System.Drawing.Size(39, 23);
            this.zhuchang2SelectBtn.TabIndex = 24;
            this.zhuchang2SelectBtn.Text = "..";
            this.zhuchang2SelectBtn.UseVisualStyleBackColor = true;
            this.zhuchang2SelectBtn.Click += new System.EventHandler(this.zhuchang2SelectBtn_Click);
            // 
            // zhuchang2Edi
            // 
            this.zhuchang2Edi.Location = new System.Drawing.Point(398, 76);
            this.zhuchang2Edi.Name = "zhuchang2Edi";
            this.zhuchang2Edi.Size = new System.Drawing.Size(165, 21);
            this.zhuchang2Edi.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(351, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "驻场2:";
            // 
            // zhuchang1SelectBtn
            // 
            this.zhuchang1SelectBtn.Location = new System.Drawing.Point(259, 75);
            this.zhuchang1SelectBtn.Name = "zhuchang1SelectBtn";
            this.zhuchang1SelectBtn.Size = new System.Drawing.Size(38, 23);
            this.zhuchang1SelectBtn.TabIndex = 21;
            this.zhuchang1SelectBtn.Text = "..";
            this.zhuchang1SelectBtn.UseVisualStyleBackColor = true;
            this.zhuchang1SelectBtn.Click += new System.EventHandler(this.zhuchang1SelectBtn_Click);
            // 
            // zhuchang1Edi
            // 
            this.zhuchang1Edi.Location = new System.Drawing.Point(87, 75);
            this.zhuchang1Edi.Name = "zhuchang1Edi";
            this.zhuchang1Edi.Size = new System.Drawing.Size(165, 21);
            this.zhuchang1Edi.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "驻场1:";
            // 
            // keyuanSelectBtn
            // 
            this.keyuanSelectBtn.Location = new System.Drawing.Point(569, 48);
            this.keyuanSelectBtn.Name = "keyuanSelectBtn";
            this.keyuanSelectBtn.Size = new System.Drawing.Size(39, 23);
            this.keyuanSelectBtn.TabIndex = 18;
            this.keyuanSelectBtn.Text = "..";
            this.keyuanSelectBtn.UseVisualStyleBackColor = true;
            this.keyuanSelectBtn.Click += new System.EventHandler(this.keyuanSelectBtn_Click);
            // 
            // keyuanEdi
            // 
            this.keyuanEdi.Location = new System.Drawing.Point(398, 48);
            this.keyuanEdi.Name = "keyuanEdi";
            this.keyuanEdi.Size = new System.Drawing.Size(165, 21);
            this.keyuanEdi.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(345, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "客源方:";
            // 
            // guwenSelectBtn
            // 
            this.guwenSelectBtn.Location = new System.Drawing.Point(258, 48);
            this.guwenSelectBtn.Name = "guwenSelectBtn";
            this.guwenSelectBtn.Size = new System.Drawing.Size(39, 23);
            this.guwenSelectBtn.TabIndex = 15;
            this.guwenSelectBtn.Text = "..";
            this.guwenSelectBtn.UseVisualStyleBackColor = true;
            this.guwenSelectBtn.Click += new System.EventHandler(this.guwenSelectBtn_Click);
            // 
            // guwenEdi
            // 
            this.guwenEdi.Location = new System.Drawing.Point(87, 48);
            this.guwenEdi.Name = "guwenEdi";
            this.guwenEdi.Size = new System.Drawing.Size(165, 21);
            this.guwenEdi.TabIndex = 13;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "营销顾问:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shenheInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 468);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // shenheInfo
            // 
            this.shenheInfo.Name = "shenheInfo";
            this.shenheInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // shenheBtn
            // 
            this.shenheBtn.Location = new System.Drawing.Point(118, 431);
            this.shenheBtn.Name = "shenheBtn";
            this.shenheBtn.Size = new System.Drawing.Size(75, 23);
            this.shenheBtn.TabIndex = 16;
            this.shenheBtn.Text = "审核";
            this.shenheBtn.UseVisualStyleBackColor = true;
            // 
            // cancelShenheBtn
            // 
            this.cancelShenheBtn.Location = new System.Drawing.Point(199, 431);
            this.cancelShenheBtn.Name = "cancelShenheBtn";
            this.cancelShenheBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelShenheBtn.TabIndex = 17;
            this.cancelShenheBtn.Text = "取消审核";
            this.cancelShenheBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(438, 431);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "保存";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(519, 431);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 19;
            this.exitBtn.Text = "退出";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Controls.Add(this.buyTime);
            this.myGroupBox1.Controls.Add(this.daikuanjineEdi);
            this.myGroupBox1.Controls.Add(this.label14);
            this.myGroupBox1.Controls.Add(this.fukuanTypeEdi);
            this.myGroupBox1.Controls.Add(this.label13);
            this.myGroupBox1.Controls.Add(this.hetongzhuangtaiEdi);
            this.myGroupBox1.Controls.Add(this.label12);
            this.myGroupBox1.Controls.Add(this.mianjiEdi);
            this.myGroupBox1.Controls.Add(this.projectNameSelectBtn);
            this.myGroupBox1.Controls.Add(this.label11);
            this.myGroupBox1.Controls.Add(this.shoujuEdi);
            this.myGroupBox1.Controls.Add(this.label10);
            this.myGroupBox1.Controls.Add(this.shenfenzhengEdi);
            this.myGroupBox1.Controls.Add(this.label9);
            this.myGroupBox1.Controls.Add(this.kehudianhuaEdi);
            this.myGroupBox1.Controls.Add(this.label8);
            this.myGroupBox1.Controls.Add(this.label7);
            this.myGroupBox1.Controls.Add(this.cjZongjiaEdi);
            this.myGroupBox1.Controls.Add(this.label5);
            this.myGroupBox1.Controls.Add(this.roomNumberEdi);
            this.myGroupBox1.Controls.Add(this.label4);
            this.myGroupBox1.Controls.Add(this.projectNameEdi);
            this.myGroupBox1.Controls.Add(this.label2);
            this.myGroupBox1.Controls.Add(this.kehuNameEdi);
            this.myGroupBox1.Controls.Add(this.label1);
            this.myGroupBox1.Location = new System.Drawing.Point(31, 12);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(629, 188);
            this.myGroupBox1.TabIndex = 0;
            this.myGroupBox1.TabStop = false;
            this.myGroupBox1.Text = "购买信息";
            // 
            // buyTime
            // 
            this.buyTime.Location = new System.Drawing.Point(87, 72);
            this.buyTime.Name = "buyTime";
            this.buyTime.Size = new System.Drawing.Size(165, 21);
            this.buyTime.TabIndex = 29;
            // 
            // daikuanjineEdi
            // 
            this.daikuanjineEdi.Location = new System.Drawing.Point(398, 153);
            this.daikuanjineEdi.Name = "daikuanjineEdi";
            this.daikuanjineEdi.Size = new System.Drawing.Size(165, 21);
            this.daikuanjineEdi.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(333, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 27;
            this.label14.Text = "贷款金额:";
            // 
            // fukuanTypeEdi
            // 
            this.fukuanTypeEdi.Location = new System.Drawing.Point(87, 153);
            this.fukuanTypeEdi.Name = "fukuanTypeEdi";
            this.fukuanTypeEdi.Size = new System.Drawing.Size(165, 21);
            this.fukuanTypeEdi.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "付款方式:";
            // 
            // hetongzhuangtaiEdi
            // 
            this.hetongzhuangtaiEdi.Location = new System.Drawing.Point(398, 126);
            this.hetongzhuangtaiEdi.Name = "hetongzhuangtaiEdi";
            this.hetongzhuangtaiEdi.Size = new System.Drawing.Size(165, 21);
            this.hetongzhuangtaiEdi.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(333, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "合同状态:";
            // 
            // mianjiEdi
            // 
            this.mianjiEdi.Location = new System.Drawing.Point(87, 126);
            this.mianjiEdi.Name = "mianjiEdi";
            this.mianjiEdi.Size = new System.Drawing.Size(165, 21);
            this.mianjiEdi.TabIndex = 22;
            // 
            // projectNameSelectBtn
            // 
            this.projectNameSelectBtn.Location = new System.Drawing.Point(569, 16);
            this.projectNameSelectBtn.Name = "projectNameSelectBtn";
            this.projectNameSelectBtn.Size = new System.Drawing.Size(39, 23);
            this.projectNameSelectBtn.TabIndex = 8;
            this.projectNameSelectBtn.Text = "..";
            this.projectNameSelectBtn.UseVisualStyleBackColor = true;
            this.projectNameSelectBtn.Click += new System.EventHandler(this.projectNameSelectBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "面积:";
            // 
            // shoujuEdi
            // 
            this.shoujuEdi.Location = new System.Drawing.Point(398, 99);
            this.shoujuEdi.Name = "shoujuEdi";
            this.shoujuEdi.Size = new System.Drawing.Size(165, 21);
            this.shoujuEdi.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "收据:";
            // 
            // shenfenzhengEdi
            // 
            this.shenfenzhengEdi.Location = new System.Drawing.Point(87, 99);
            this.shenfenzhengEdi.Name = "shenfenzhengEdi";
            this.shenfenzhengEdi.Size = new System.Drawing.Size(165, 21);
            this.shenfenzhengEdi.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "身份证:";
            // 
            // kehudianhuaEdi
            // 
            this.kehudianhuaEdi.Location = new System.Drawing.Point(398, 72);
            this.kehudianhuaEdi.Name = "kehudianhuaEdi";
            this.kehudianhuaEdi.Size = new System.Drawing.Size(165, 21);
            this.kehudianhuaEdi.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "联系电话:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "购买日期:";
            // 
            // cjZongjiaEdi
            // 
            this.cjZongjiaEdi.Location = new System.Drawing.Point(398, 45);
            this.cjZongjiaEdi.Name = "cjZongjiaEdi";
            this.cjZongjiaEdi.Size = new System.Drawing.Size(165, 21);
            this.cjZongjiaEdi.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "成交总价:";
            // 
            // roomNumberEdi
            // 
            this.roomNumberEdi.Location = new System.Drawing.Point(87, 45);
            this.roomNumberEdi.Name = "roomNumberEdi";
            this.roomNumberEdi.Size = new System.Drawing.Size(165, 21);
            this.roomNumberEdi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "房号:";
            // 
            // projectNameEdi
            // 
            this.projectNameEdi.Location = new System.Drawing.Point(398, 18);
            this.projectNameEdi.Name = "projectNameEdi";
            this.projectNameEdi.Size = new System.Drawing.Size(165, 21);
            this.projectNameEdi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "所属项目:";
            // 
            // kehuNameEdi
            // 
            this.kehuNameEdi.Location = new System.Drawing.Point(87, 18);
            this.kehuNameEdi.Name = "kehuNameEdi";
            this.kehuNameEdi.Size = new System.Drawing.Size(165, 21);
            this.kehuNameEdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户名称:";
            // 
            // OrderOperDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 490);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelShenheBtn);
            this.Controls.Add(this.shenheBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.myGroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderOperDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderOperDlg";
            this.Load += new System.EventHandler(this.OrderOperDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControl.MyGroupBox myGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kehuNameEdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox projectNameEdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker orderGenerateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox roomNumberEdi;
        private System.Windows.Forms.Button projectNameSelectBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cjZongjiaEdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox yongjinzongeEdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox kehudianhuaEdi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox shenfenzhengEdi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox shoujuEdi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox mianjiEdi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox hetongzhuangtaiEdi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox fukuanTypeEdi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox daikuanjineEdi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox guwenEdi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button guwenSelectBtn;
        private System.Windows.Forms.TextBox keyuanEdi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button keyuanSelectBtn;
        private System.Windows.Forms.TextBox zhuchang1Edi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button zhuchang1SelectBtn;
        private System.Windows.Forms.TextBox zhuchang2Edi;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button zhuchang2SelectBtn;
        private System.Windows.Forms.TextBox beizhuEdi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel shenheInfo;
        private System.Windows.Forms.Button shenheBtn;
        private System.Windows.Forms.Button cancelShenheBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.DateTimePicker buyTime;
    }
}