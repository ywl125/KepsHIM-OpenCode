namespace KepsHIM
{
    partial class UcParam
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlUcParam = new System.Windows.Forms.Panel();
            this.txtIpSet = new System.Windows.Forms.TextBox();
            this.lblBoardCardIp = new System.Windows.Forms.Label();
            this.btnBuzzer = new System.Windows.Forms.Button();
            this.btnRobotArm = new System.Windows.Forms.Button();
            this.btnVisionDebug = new System.Windows.Forms.Button();
            this.btnFlowChannelParam = new System.Windows.Forms.Button();
            this.btnProductionData = new System.Windows.Forms.Button();
            this.btnDebugPage = new System.Windows.Forms.Button();
            this.btnStationSetting = new System.Windows.Forms.Button();
            this.btnFunctionShield = new System.Windows.Forms.Button();
            this.btnTimeParam = new System.Windows.Forms.Button();
            this.btnCylinderParam = new System.Windows.Forms.Button();
            this.btnServoParam = new System.Windows.Forms.Button();
            this.lblAxisNumber = new System.Windows.Forms.Label();
            this.numAxisNumber = new System.Windows.Forms.NumericUpDown();
            this.pnlUcParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUcParam
            // 
            this.pnlUcParam.Controls.Add(this.numAxisNumber);
            this.pnlUcParam.Controls.Add(this.lblAxisNumber);
            this.pnlUcParam.Controls.Add(this.txtIpSet);
            this.pnlUcParam.Controls.Add(this.lblBoardCardIp);
            this.pnlUcParam.Controls.Add(this.btnBuzzer);
            this.pnlUcParam.Controls.Add(this.btnRobotArm);
            this.pnlUcParam.Controls.Add(this.btnVisionDebug);
            this.pnlUcParam.Controls.Add(this.btnFlowChannelParam);
            this.pnlUcParam.Controls.Add(this.btnProductionData);
            this.pnlUcParam.Controls.Add(this.btnDebugPage);
            this.pnlUcParam.Controls.Add(this.btnStationSetting);
            this.pnlUcParam.Controls.Add(this.btnFunctionShield);
            this.pnlUcParam.Controls.Add(this.btnTimeParam);
            this.pnlUcParam.Controls.Add(this.btnCylinderParam);
            this.pnlUcParam.Controls.Add(this.btnServoParam);
            this.pnlUcParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUcParam.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlUcParam.Location = new System.Drawing.Point(0, 0);
            this.pnlUcParam.Name = "pnlUcParam";
            this.pnlUcParam.Size = new System.Drawing.Size(1220, 710);
            this.pnlUcParam.TabIndex = 0;
            // 
            // txtIpSet
            // 
            this.txtIpSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIpSet.BackColor = System.Drawing.Color.White;
            this.txtIpSet.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.txtIpSet.ForeColor = System.Drawing.Color.Black;
            this.txtIpSet.Location = new System.Drawing.Point(276, 49);
            this.txtIpSet.Multiline = true;
            this.txtIpSet.Name = "txtIpSet";
            this.txtIpSet.Size = new System.Drawing.Size(200, 40);
            this.txtIpSet.TabIndex = 27;
            this.txtIpSet.Text = "192.168.1.99";
            this.txtIpSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIpSet.Leave += new System.EventHandler(this.txtIpSet_Leave);
            // 
            // lblBoardCardIp
            // 
            this.lblBoardCardIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.lblBoardCardIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoardCardIp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBoardCardIp.ForeColor = System.Drawing.Color.White;
            this.lblBoardCardIp.Location = new System.Drawing.Point(80, 44);
            this.lblBoardCardIp.Name = "lblBoardCardIp";
            this.lblBoardCardIp.Size = new System.Drawing.Size(180, 50);
            this.lblBoardCardIp.TabIndex = 26;
            this.lblBoardCardIp.Text = "板卡IP";
            this.lblBoardCardIp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuzzer
            // 
            this.btnBuzzer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnBuzzer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuzzer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnBuzzer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuzzer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnBuzzer.ForeColor = System.Drawing.Color.White;
            this.btnBuzzer.Location = new System.Drawing.Point(710, 428);
            this.btnBuzzer.Name = "btnBuzzer";
            this.btnBuzzer.Size = new System.Drawing.Size(180, 50);
            this.btnBuzzer.TabIndex = 24;
            this.btnBuzzer.Text = "蜂鸣器: 关闭";
            this.btnBuzzer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuzzer.UseVisualStyleBackColor = false;
            // 
            // btnRobotArm
            // 
            this.btnRobotArm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnRobotArm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRobotArm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnRobotArm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRobotArm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnRobotArm.ForeColor = System.Drawing.Color.White;
            this.btnRobotArm.Location = new System.Drawing.Point(710, 328);
            this.btnRobotArm.Name = "btnRobotArm";
            this.btnRobotArm.Size = new System.Drawing.Size(180, 50);
            this.btnRobotArm.TabIndex = 23;
            this.btnRobotArm.Text = "机械手";
            this.btnRobotArm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRobotArm.UseVisualStyleBackColor = false;
            // 
            // btnVisionDebug
            // 
            this.btnVisionDebug.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnVisionDebug.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisionDebug.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnVisionDebug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisionDebug.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnVisionDebug.ForeColor = System.Drawing.Color.White;
            this.btnVisionDebug.Location = new System.Drawing.Point(710, 228);
            this.btnVisionDebug.Name = "btnVisionDebug";
            this.btnVisionDebug.Size = new System.Drawing.Size(180, 50);
            this.btnVisionDebug.TabIndex = 22;
            this.btnVisionDebug.Text = "视觉调试";
            this.btnVisionDebug.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisionDebug.UseVisualStyleBackColor = false;
            // 
            // btnFlowChannelParam
            // 
            this.btnFlowChannelParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnFlowChannelParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlowChannelParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnFlowChannelParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowChannelParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnFlowChannelParam.ForeColor = System.Drawing.Color.White;
            this.btnFlowChannelParam.Location = new System.Drawing.Point(710, 128);
            this.btnFlowChannelParam.Name = "btnFlowChannelParam";
            this.btnFlowChannelParam.Size = new System.Drawing.Size(180, 50);
            this.btnFlowChannelParam.TabIndex = 21;
            this.btnFlowChannelParam.Text = "流道参数";
            this.btnFlowChannelParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlowChannelParam.UseVisualStyleBackColor = false;
            // 
            // btnProductionData
            // 
            this.btnProductionData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnProductionData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductionData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnProductionData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductionData.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnProductionData.ForeColor = System.Drawing.Color.White;
            this.btnProductionData.Location = new System.Drawing.Point(710, 28);
            this.btnProductionData.Name = "btnProductionData";
            this.btnProductionData.Size = new System.Drawing.Size(180, 50);
            this.btnProductionData.TabIndex = 20;
            this.btnProductionData.Text = "生产数据";
            this.btnProductionData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductionData.UseVisualStyleBackColor = false;
            // 
            // btnDebugPage
            // 
            this.btnDebugPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnDebugPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDebugPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnDebugPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnDebugPage.ForeColor = System.Drawing.Color.White;
            this.btnDebugPage.Location = new System.Drawing.Point(80, 528);
            this.btnDebugPage.Name = "btnDebugPage";
            this.btnDebugPage.Size = new System.Drawing.Size(180, 50);
            this.btnDebugPage.TabIndex = 18;
            this.btnDebugPage.Text = "调试页面";
            this.btnDebugPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDebugPage.UseVisualStyleBackColor = false;
            // 
            // btnStationSetting
            // 
            this.btnStationSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnStationSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStationSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnStationSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStationSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnStationSetting.ForeColor = System.Drawing.Color.White;
            this.btnStationSetting.Location = new System.Drawing.Point(80, 428);
            this.btnStationSetting.Name = "btnStationSetting";
            this.btnStationSetting.Size = new System.Drawing.Size(180, 50);
            this.btnStationSetting.TabIndex = 17;
            this.btnStationSetting.Text = "工站设置";
            this.btnStationSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStationSetting.UseVisualStyleBackColor = false;
            // 
            // btnFunctionShield
            // 
            this.btnFunctionShield.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnFunctionShield.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFunctionShield.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnFunctionShield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunctionShield.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnFunctionShield.ForeColor = System.Drawing.Color.White;
            this.btnFunctionShield.Location = new System.Drawing.Point(80, 328);
            this.btnFunctionShield.Name = "btnFunctionShield";
            this.btnFunctionShield.Size = new System.Drawing.Size(180, 50);
            this.btnFunctionShield.TabIndex = 16;
            this.btnFunctionShield.Text = "功能屏蔽";
            this.btnFunctionShield.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunctionShield.UseVisualStyleBackColor = false;
            // 
            // btnTimeParam
            // 
            this.btnTimeParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnTimeParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimeParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnTimeParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimeParam.ForeColor = System.Drawing.Color.White;
            this.btnTimeParam.Location = new System.Drawing.Point(80, 228);
            this.btnTimeParam.Name = "btnTimeParam";
            this.btnTimeParam.Size = new System.Drawing.Size(180, 50);
            this.btnTimeParam.TabIndex = 15;
            this.btnTimeParam.Text = "时间参数设置";
            this.btnTimeParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimeParam.UseVisualStyleBackColor = false;
            // 
            // btnCylinderParam
            // 
            this.btnCylinderParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnCylinderParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCylinderParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnCylinderParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCylinderParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnCylinderParam.ForeColor = System.Drawing.Color.White;
            this.btnCylinderParam.Location = new System.Drawing.Point(80, 128);
            this.btnCylinderParam.Name = "btnCylinderParam";
            this.btnCylinderParam.Size = new System.Drawing.Size(180, 50);
            this.btnCylinderParam.TabIndex = 14;
            this.btnCylinderParam.Text = "气缸参数设置";
            this.btnCylinderParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCylinderParam.UseVisualStyleBackColor = false;
            // 
            // btnServoParam
            // 
            this.btnServoParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnServoParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServoParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnServoParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServoParam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.btnServoParam.ForeColor = System.Drawing.Color.White;
            this.btnServoParam.Location = new System.Drawing.Point(960, 28);
            this.btnServoParam.Name = "btnServoParam";
            this.btnServoParam.Size = new System.Drawing.Size(180, 50);
            this.btnServoParam.TabIndex = 13;
            this.btnServoParam.Text = "伺服参数设置";
            this.btnServoParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServoParam.UseVisualStyleBackColor = false;
            // 
            // lblAxisNumber
            // 
            this.lblAxisNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.lblAxisNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAxisNumber.ForeColor = System.Drawing.Color.White;
            this.lblAxisNumber.Location = new System.Drawing.Point(710, 523);
            this.lblAxisNumber.Name = "lblAxisNumber";
            this.lblAxisNumber.Size = new System.Drawing.Size(180, 50);
            this.lblAxisNumber.TabIndex = 29;
            this.lblAxisNumber.Text = "轴数量";
            this.lblAxisNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numAxisNumber
            // 
            this.numAxisNumber.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.numAxisNumber.Location = new System.Drawing.Point(939, 528);
            this.numAxisNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAxisNumber.Name = "numAxisNumber";
            this.numAxisNumber.Size = new System.Drawing.Size(71, 42);
            this.numAxisNumber.TabIndex = 30;
            this.numAxisNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAxisNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UcParam
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.Controls.Add(this.pnlUcParam);
            this.Name = "UcParam";
            this.Size = new System.Drawing.Size(1220, 710);
            this.pnlUcParam.ResumeLayout(false);
            this.pnlUcParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAxisNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUcParam;
        private System.Windows.Forms.Button btnBuzzer;
        private System.Windows.Forms.Button btnRobotArm;
        private System.Windows.Forms.Button btnVisionDebug;
        private System.Windows.Forms.Button btnFlowChannelParam;
        private System.Windows.Forms.Button btnProductionData;
        private System.Windows.Forms.Button btnDebugPage;
        private System.Windows.Forms.Button btnStationSetting;
        private System.Windows.Forms.Button btnFunctionShield;
        private System.Windows.Forms.Button btnTimeParam;
        private System.Windows.Forms.Button btnCylinderParam;
        private System.Windows.Forms.Button btnServoParam;
        private System.Windows.Forms.Label lblBoardCardIp;
        private System.Windows.Forms.TextBox txtIpSet;
        private System.Windows.Forms.Label lblAxisNumber;
        private System.Windows.Forms.NumericUpDown numAxisNumber;
    }
}
