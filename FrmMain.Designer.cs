namespace KepsHIM
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.pBLogo = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnFlyCapture = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnIO = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnParam = new System.Windows.Forms.Button();
            this.btnServo = new System.Windows.Forms.Button();
            this.btnCylinder = new System.Windows.Forms.Button();
            this.btnStation = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblboardstaut = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).BeginInit();
            this.pnlNav.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.lblDateTime);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.pBLogo);
            this.pnlHeader.Controls.Add(this.lblSystemName);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1440, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1341, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(32, 32);
            this.btnMinimize.TabIndex = 15;
            this.btnMinimize.Tag = "";
            this.btnMinimize.Text = "     ";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(1162, 41);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(176, 31);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "时间载入中......";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1401, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(387, 30);
            this.lblUser.MinimumSize = new System.Drawing.Size(320, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(320, 30);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "操作员 1008";
            // 
            // pBLogo
            // 
            this.pBLogo.Image = ((System.Drawing.Image)(resources.GetObject("pBLogo.Image")));
            this.pBLogo.Location = new System.Drawing.Point(3, 21);
            this.pBLogo.Name = "pBLogo";
            this.pBLogo.Size = new System.Drawing.Size(70, 50);
            this.pBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBLogo.TabIndex = 1;
            this.pBLogo.TabStop = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Location = new System.Drawing.Point(80, 21);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(268, 52);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "KepsHMI1.0";
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.pnlNav.Controls.Add(this.btnFlyCapture);
            this.pnlNav.Controls.Add(this.txtIp);
            this.pnlNav.Controls.Add(this.btnOther);
            this.pnlNav.Controls.Add(this.btnIO);
            this.pnlNav.Controls.Add(this.btnLog);
            this.pnlNav.Controls.Add(this.btnParam);
            this.pnlNav.Controls.Add(this.btnServo);
            this.pnlNav.Controls.Add(this.btnCylinder);
            this.pnlNav.Controls.Add(this.btnStation);
            this.pnlNav.Controls.Add(this.btnRun);
            this.pnlNav.Location = new System.Drawing.Point(0, 80);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(220, 710);
            this.pnlNav.TabIndex = 3;
            // 
            // btnFlyCapture
            // 
            this.btnFlyCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlyCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnFlyCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlyCapture.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnFlyCapture.ForeColor = System.Drawing.Color.White;
            this.btnFlyCapture.Location = new System.Drawing.Point(20, 517);
            this.btnFlyCapture.Name = "btnFlyCapture";
            this.btnFlyCapture.Size = new System.Drawing.Size(180, 50);
            this.btnFlyCapture.TabIndex = 10;
            this.btnFlyCapture.Text = "飞拍功能";
            this.btnFlyCapture.UseVisualStyleBackColor = true;
            this.btnFlyCapture.Click += new System.EventHandler(this.btnFlyCapture_Click);
            // 
            // txtIp
            // 
            this.txtIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.txtIp.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.txtIp.ForeColor = System.Drawing.Color.White;
            this.txtIp.Location = new System.Drawing.Point(20, 625);
            this.txtIp.Name = "txtIp";
            this.txtIp.ReadOnly = true;
            this.txtIp.Size = new System.Drawing.Size(180, 42);
            this.txtIp.TabIndex = 9;
            // 
            // btnOther
            // 
            this.btnOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOther.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnOther.ForeColor = System.Drawing.Color.White;
            this.btnOther.Location = new System.Drawing.Point(20, 450);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(180, 50);
            this.btnOther.TabIndex = 7;
            this.btnOther.Text = "其他功能";
            this.btnOther.UseVisualStyleBackColor = true;
            // 
            // btnIO
            // 
            this.btnIO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIO.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnIO.ForeColor = System.Drawing.Color.White;
            this.btnIO.Location = new System.Drawing.Point(20, 390);
            this.btnIO.Name = "btnIO";
            this.btnIO.Size = new System.Drawing.Size(180, 50);
            this.btnIO.TabIndex = 6;
            this.btnIO.Text = "I/O监控";
            this.btnIO.UseVisualStyleBackColor = true;
            this.btnIO.Click += new System.EventHandler(this.btnIO_Click);
            // 
            // btnLog
            // 
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.Location = new System.Drawing.Point(20, 330);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(180, 50);
            this.btnLog.TabIndex = 5;
            this.btnLog.Text = "日志记录";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnParam
            // 
            this.btnParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParam.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnParam.ForeColor = System.Drawing.Color.White;
            this.btnParam.Location = new System.Drawing.Point(20, 270);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(180, 50);
            this.btnParam.TabIndex = 4;
            this.btnParam.Text = "参数设置";
            this.btnParam.UseVisualStyleBackColor = true;
            this.btnParam.Click += new System.EventHandler(this.btnParam_Click);
            // 
            // btnServo
            // 
            this.btnServo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnServo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServo.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnServo.ForeColor = System.Drawing.Color.White;
            this.btnServo.Location = new System.Drawing.Point(20, 210);
            this.btnServo.Name = "btnServo";
            this.btnServo.Size = new System.Drawing.Size(180, 50);
            this.btnServo.TabIndex = 3;
            this.btnServo.Text = "伺服手动";
            this.btnServo.UseVisualStyleBackColor = true;
            this.btnServo.Click += new System.EventHandler(this.btnServo_Click);
            // 
            // btnCylinder
            // 
            this.btnCylinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCylinder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnCylinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCylinder.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnCylinder.ForeColor = System.Drawing.Color.White;
            this.btnCylinder.Location = new System.Drawing.Point(20, 150);
            this.btnCylinder.Name = "btnCylinder";
            this.btnCylinder.Size = new System.Drawing.Size(180, 50);
            this.btnCylinder.TabIndex = 2;
            this.btnCylinder.Text = "气缸手动";
            this.btnCylinder.UseVisualStyleBackColor = true;
            this.btnCylinder.Click += new System.EventHandler(this.btnCylinder_Click);
            // 
            // btnStation
            // 
            this.btnStation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStation.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnStation.ForeColor = System.Drawing.Color.White;
            this.btnStation.Location = new System.Drawing.Point(20, 90);
            this.btnStation.Name = "btnStation";
            this.btnStation.Size = new System.Drawing.Size(180, 50);
            this.btnStation.TabIndex = 1;
            this.btnStation.Text = "工位手动";
            this.btnStation.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(20, 30);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(180, 50);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "主界面";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.pnlMain.Location = new System.Drawing.Point(220, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1220, 710);
            this.pnlMain.TabIndex = 4;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(36)))), ((int)(((byte)(90)))));
            this.pnlBottom.Controls.Add(this.btnInit);
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.btnStop);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Location = new System.Drawing.Point(220, 789);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1220, 110);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnInit
            // 
            this.btnInit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnInit.ForeColor = System.Drawing.Color.White;
            this.btnInit.Location = new System.Drawing.Point(780, 30);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(180, 60);
            this.btnInit.TabIndex = 12;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(580, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 60);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "复    位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(380, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(180, 60);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "停    止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(180, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 60);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "启    动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(13, 840);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 33);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "未连接";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblboardstaut
            // 
            this.lblboardstaut.AutoSize = true;
            this.lblboardstaut.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblboardstaut.ForeColor = System.Drawing.Color.White;
            this.lblboardstaut.Location = new System.Drawing.Point(12, 795);
            this.lblboardstaut.Name = "lblboardstaut";
            this.lblboardstaut.Size = new System.Drawing.Size(145, 30);
            this.lblboardstaut.TabIndex = 13;
            this.lblboardstaut.Text = "板卡连接状态";
            this.lblboardstaut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(122)))));
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.lblboardstaut);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlNav);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KepsHMI1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).EndInit();
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.PictureBox pBLogo;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Button btnCylinder;
        private System.Windows.Forms.Button btnStation;
        private System.Windows.Forms.Button btnIO;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.Button btnServo;
        private System.Windows.Forms.Button btnFlyCapture;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblboardstaut;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        
    }
}

