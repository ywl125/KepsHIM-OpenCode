namespace KepsHIM
{
    partial class UcLog
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
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rtbFullLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnExportLog = new System.Windows.Forms.Button();
            this.pnlFulllog = new System.Windows.Forms.Panel();
            this.pnlup = new System.Windows.Forms.Panel();
            this.pnlFulllog.SuspendLayout();
            this.pnlup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFilter
            // 
            this.cmbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.cmbFilter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.cmbFilter.ForeColor = System.Drawing.Color.White;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.ItemHeight = 31;
            this.cmbFilter.Items.AddRange(new object[] {
            "今天",
            "本周",
            "本月",
            "全部"});
            this.cmbFilter.Location = new System.Drawing.Point(202, 11);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(116, 39);
            this.cmbFilter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(363, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 45);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷    新";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // rtbFullLog
            // 
            this.rtbFullLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.rtbFullLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFullLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFullLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.rtbFullLog.ForeColor = System.Drawing.Color.Transparent;
            this.rtbFullLog.Location = new System.Drawing.Point(0, 0);
            this.rtbFullLog.Name = "rtbFullLog";
            this.rtbFullLog.ReadOnly = true;
            this.rtbFullLog.Size = new System.Drawing.Size(1160, 574);
            this.rtbFullLog.TabIndex = 0;
            this.rtbFullLog.Text = "";
            this.rtbFullLog.WordWrap = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(585, 8);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(180, 45);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "清    除";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnExportLog
            // 
            this.btnExportLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.btnExportLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnExportLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLog.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportLog.ForeColor = System.Drawing.Color.White;
            this.btnExportLog.Location = new System.Drawing.Point(801, 8);
            this.btnExportLog.Name = "btnExportLog";
            this.btnExportLog.Size = new System.Drawing.Size(180, 45);
            this.btnExportLog.TabIndex = 4;
            this.btnExportLog.Text = "导    出";
            this.btnExportLog.UseVisualStyleBackColor = false;
            this.btnExportLog.Click += new System.EventHandler(this.btnExportLog_Click);
            // 
            // pnlFulllog
            // 
            this.pnlFulllog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlFulllog.Controls.Add(this.rtbFullLog);
            this.pnlFulllog.Location = new System.Drawing.Point(32, 111);
            this.pnlFulllog.Name = "pnlFulllog";
            this.pnlFulllog.Size = new System.Drawing.Size(1160, 574);
            this.pnlFulllog.TabIndex = 5;
            // 
            // pnlup
            // 
            this.pnlup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlup.Controls.Add(this.btnClearLog);
            this.pnlup.Controls.Add(this.btnExportLog);
            this.pnlup.Controls.Add(this.cmbFilter);
            this.pnlup.Controls.Add(this.btnRefresh);
            this.pnlup.Location = new System.Drawing.Point(32, 26);
            this.pnlup.Name = "pnlup";
            this.pnlup.Size = new System.Drawing.Size(1160, 62);
            this.pnlup.TabIndex = 6;
            // 
            // UcLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.Controls.Add(this.pnlup);
            this.Controls.Add(this.pnlFulllog);
            this.Name = "UcLog";
            this.Size = new System.Drawing.Size(1220, 710);
            this.pnlFulllog.ResumeLayout(false);
            this.pnlup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RichTextBox rtbFullLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnExportLog;
        private System.Windows.Forms.Panel pnlFulllog;
        private System.Windows.Forms.Panel pnlup;
    }
}
