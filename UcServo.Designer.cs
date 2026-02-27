namespace KepsHIM
{
    partial class UcServo
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
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblconfig = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nudAlarmDI = new System.Windows.Forms.NumericUpDown();
            this.nudNegLimitDI = new System.Windows.Forms.NumericUpDown();
            this.nudPosLimitDI = new System.Windows.Forms.NumericUpDown();
            this.nudHomeDI = new System.Windows.Forms.NumericUpDown();
            this.btnApplyParam = new System.Windows.Forms.Button();
            this.btnLoadParam = new System.Windows.Forms.Button();
            this.btnSaveParam = new System.Windows.Forms.Button();
            this.pnlPosTable = new System.Windows.Forms.Panel();
            this.txtPosSpeed = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.txtPosName = new System.Windows.Forms.TextBox();
            this.btnAddPos_Click = new System.Windows.Forms.Button();
            this.btnDeletePos = new System.Windows.Forms.Button();
            this.btnUpdatePos = new System.Windows.Forms.Button();
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.btnClearAlarm = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkBusServo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblAutoSpeed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutoSpeed = new System.Windows.Forms.TextBox();
            this.txtCurPos = new System.Windows.Forms.TextBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.lblJogspeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJogSpeed = new System.Windows.Forms.TextBox();
            this.btnJogPos = new System.Windows.Forms.Button();
            this.btnJogNeg = new System.Windows.Forms.Button();
            this.lblCurPos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnServoEnable = new System.Windows.Forms.Button();
            this.pnlAxisStatus = new System.Windows.Forms.Panel();
            this.chkSetInvertIn = new System.Windows.Forms.CheckBox();
            this.lblEnable = new System.Windows.Forms.Label();
            this.lblRun = new System.Windows.Forms.Label();
            this.lblAxisAlarm = new System.Windows.Forms.Label();
            this.lblAxisState = new System.Windows.Forms.Label();
            this.lblPosLimit = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblNegLimit = new System.Windows.Forms.Label();
            this.pnlAxisSelect = new System.Windows.Forms.Panel();
            this.btnAxis3 = new System.Windows.Forms.Button();
            this.btnAxis2 = new System.Windows.Forms.Button();
            this.btnAxis1 = new System.Windows.Forms.Button();
            this.btnAxis0 = new System.Windows.Forms.Button();
            this.tmrServo = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNegLimitDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosLimitDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeDI)).BeginInit();
            this.pnlPosTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            this.pnlManual.SuspendLayout();
            this.pnlAxisStatus.SuspendLayout();
            this.pnlAxisSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlPosTable);
            this.pnlMain.Controls.Add(this.pnlManual);
            this.pnlMain.Controls.Add(this.pnlAxisStatus);
            this.pnlMain.Controls.Add(this.pnlAxisSelect);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1220, 710);
            this.pnlMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.panel1.Controls.Add(this.lblconfig);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.nudAlarmDI);
            this.panel1.Controls.Add(this.nudNegLimitDI);
            this.panel1.Controls.Add(this.nudPosLimitDI);
            this.panel1.Controls.Add(this.nudHomeDI);
            this.panel1.Controls.Add(this.btnApplyParam);
            this.panel1.Controls.Add(this.btnLoadParam);
            this.panel1.Controls.Add(this.btnSaveParam);
            this.panel1.Location = new System.Drawing.Point(668, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 144);
            this.panel1.TabIndex = 5;
            // 
            // lblconfig
            // 
            this.lblconfig.BackColor = System.Drawing.Color.Transparent;
            this.lblconfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblconfig.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblconfig.Location = new System.Drawing.Point(398, 96);
            this.lblconfig.Name = "lblconfig";
            this.lblconfig.Size = new System.Drawing.Size(132, 35);
            this.lblconfig.TabIndex = 32;
            this.lblconfig.Text = "--";
            this.lblconfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label14.Location = new System.Drawing.Point(418, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 54);
            this.label14.TabIndex = 38;
            this.label14.Text = "值为-1\r\n表示不使用";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label13.Location = new System.Drawing.Point(330, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 27);
            this.label13.TabIndex = 37;
            this.label13.Text = "报警DI";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label12.Location = new System.Drawing.Point(218, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 27);
            this.label12.TabIndex = 36;
            this.label12.Text = "负限位DI";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label11.Location = new System.Drawing.Point(112, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 27);
            this.label11.TabIndex = 35;
            this.label11.Text = "正限位DI";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label10.Location = new System.Drawing.Point(16, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 27);
            this.label10.TabIndex = 34;
            this.label10.Text = "原点DI";
            // 
            // nudAlarmDI
            // 
            this.nudAlarmDI.Location = new System.Drawing.Point(330, 23);
            this.nudAlarmDI.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudAlarmDI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudAlarmDI.Name = "nudAlarmDI";
            this.nudAlarmDI.Size = new System.Drawing.Size(70, 34);
            this.nudAlarmDI.TabIndex = 33;
            this.nudAlarmDI.ValueChanged += new System.EventHandler(this.nudAlarmDI_ValueChanged);
            // 
            // nudNegLimitDI
            // 
            this.nudNegLimitDI.Location = new System.Drawing.Point(227, 23);
            this.nudNegLimitDI.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudNegLimitDI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudNegLimitDI.Name = "nudNegLimitDI";
            this.nudNegLimitDI.Size = new System.Drawing.Size(70, 34);
            this.nudNegLimitDI.TabIndex = 32;
            this.nudNegLimitDI.ValueChanged += new System.EventHandler(this.nudNegLimitDI_ValueChanged);
            // 
            // nudPosLimitDI
            // 
            this.nudPosLimitDI.Location = new System.Drawing.Point(123, 23);
            this.nudPosLimitDI.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudPosLimitDI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudPosLimitDI.Name = "nudPosLimitDI";
            this.nudPosLimitDI.Size = new System.Drawing.Size(70, 34);
            this.nudPosLimitDI.TabIndex = 31;
            this.nudPosLimitDI.ValueChanged += new System.EventHandler(this.nudPosLimitDI_ValueChanged);
            // 
            // nudHomeDI
            // 
            this.nudHomeDI.Location = new System.Drawing.Point(17, 23);
            this.nudHomeDI.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudHomeDI.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudHomeDI.Name = "nudHomeDI";
            this.nudHomeDI.Size = new System.Drawing.Size(70, 34);
            this.nudHomeDI.TabIndex = 30;
            this.nudHomeDI.ValueChanged += new System.EventHandler(this.nudHomeDI_ValueChanged);
            // 
            // btnApplyParam
            // 
            this.btnApplyParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnApplyParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnApplyParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyParam.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyParam.ForeColor = System.Drawing.Color.White;
            this.btnApplyParam.Location = new System.Drawing.Point(277, 96);
            this.btnApplyParam.Name = "btnApplyParam";
            this.btnApplyParam.Size = new System.Drawing.Size(100, 35);
            this.btnApplyParam.TabIndex = 29;
            this.btnApplyParam.Tag = "btnServoOn";
            this.btnApplyParam.Text = "应用参数";
            this.btnApplyParam.UseVisualStyleBackColor = false;
            this.btnApplyParam.Click += new System.EventHandler(this.btnApplyParam_Click);
            // 
            // btnLoadParam
            // 
            this.btnLoadParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnLoadParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnLoadParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadParam.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoadParam.ForeColor = System.Drawing.Color.White;
            this.btnLoadParam.Location = new System.Drawing.Point(143, 96);
            this.btnLoadParam.Name = "btnLoadParam";
            this.btnLoadParam.Size = new System.Drawing.Size(100, 35);
            this.btnLoadParam.TabIndex = 28;
            this.btnLoadParam.Tag = "btnServoOn";
            this.btnLoadParam.Text = "加载参数";
            this.btnLoadParam.UseVisualStyleBackColor = false;
            this.btnLoadParam.Click += new System.EventHandler(this.btnLoadParam_Click);
            // 
            // btnSaveParam
            // 
            this.btnSaveParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnSaveParam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnSaveParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveParam.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveParam.ForeColor = System.Drawing.Color.White;
            this.btnSaveParam.Location = new System.Drawing.Point(10, 96);
            this.btnSaveParam.Name = "btnSaveParam";
            this.btnSaveParam.Size = new System.Drawing.Size(100, 35);
            this.btnSaveParam.TabIndex = 27;
            this.btnSaveParam.Tag = "btnServoOn";
            this.btnSaveParam.Text = "保存参数";
            this.btnSaveParam.UseVisualStyleBackColor = false;
            this.btnSaveParam.Click += new System.EventHandler(this.btnSaveParam_Click);
            // 
            // pnlPosTable
            // 
            this.pnlPosTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlPosTable.Controls.Add(this.txtPosSpeed);
            this.pnlPosTable.Controls.Add(this.txtPos);
            this.pnlPosTable.Controls.Add(this.txtPosName);
            this.pnlPosTable.Controls.Add(this.btnAddPos_Click);
            this.pnlPosTable.Controls.Add(this.btnDeletePos);
            this.pnlPosTable.Controls.Add(this.btnUpdatePos);
            this.pnlPosTable.Controls.Add(this.dgvPos);
            this.pnlPosTable.Location = new System.Drawing.Point(668, 364);
            this.pnlPosTable.Name = "pnlPosTable";
            this.pnlPosTable.Size = new System.Drawing.Size(542, 327);
            this.pnlPosTable.TabIndex = 4;
            // 
            // txtPosSpeed
            // 
            this.txtPosSpeed.Location = new System.Drawing.Point(398, 239);
            this.txtPosSpeed.Name = "txtPosSpeed";
            this.txtPosSpeed.Size = new System.Drawing.Size(100, 34);
            this.txtPosSpeed.TabIndex = 44;
            this.txtPosSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(251, 239);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(100, 34);
            this.txtPos.TabIndex = 43;
            this.txtPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPosName
            // 
            this.txtPosName.Location = new System.Drawing.Point(7, 239);
            this.txtPosName.Name = "txtPosName";
            this.txtPosName.Size = new System.Drawing.Size(100, 34);
            this.txtPosName.TabIndex = 42;
            this.txtPosName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddPos_Click
            // 
            this.btnAddPos_Click.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnAddPos_Click.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnAddPos_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPos_Click.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddPos_Click.ForeColor = System.Drawing.Color.White;
            this.btnAddPos_Click.Location = new System.Drawing.Point(10, 279);
            this.btnAddPos_Click.Name = "btnAddPos_Click";
            this.btnAddPos_Click.Size = new System.Drawing.Size(100, 35);
            this.btnAddPos_Click.TabIndex = 39;
            this.btnAddPos_Click.Tag = "";
            this.btnAddPos_Click.Text = "添加位置";
            this.btnAddPos_Click.UseVisualStyleBackColor = false;
            this.btnAddPos_Click.Click += new System.EventHandler(this.btnAddPos_Click_Click);
            // 
            // btnDeletePos
            // 
            this.btnDeletePos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnDeletePos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnDeletePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeletePos.ForeColor = System.Drawing.Color.White;
            this.btnDeletePos.Location = new System.Drawing.Point(277, 279);
            this.btnDeletePos.Name = "btnDeletePos";
            this.btnDeletePos.Size = new System.Drawing.Size(100, 35);
            this.btnDeletePos.TabIndex = 41;
            this.btnDeletePos.Tag = "";
            this.btnDeletePos.Text = "删除位置";
            this.btnDeletePos.UseVisualStyleBackColor = false;
            this.btnDeletePos.Click += new System.EventHandler(this.btnDeletePos_Click);
            // 
            // btnUpdatePos
            // 
            this.btnUpdatePos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnUpdatePos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnUpdatePos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePos.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePos.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePos.Location = new System.Drawing.Point(143, 279);
            this.btnUpdatePos.Name = "btnUpdatePos";
            this.btnUpdatePos.Size = new System.Drawing.Size(100, 35);
            this.btnUpdatePos.TabIndex = 40;
            this.btnUpdatePos.Tag = "";
            this.btnUpdatePos.Text = "保存位置";
            this.btnUpdatePos.UseVisualStyleBackColor = false;
            this.btnUpdatePos.Click += new System.EventHandler(this.btnUpdatePos_Click);
            // 
            // dgvPos
            // 
            this.dgvPos.AllowUserToAddRows = false;
            this.dgvPos.AllowUserToResizeColumns = false;
            this.dgvPos.AllowUserToResizeRows = false;
            this.dgvPos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colGo,
            this.colPose,
            this.colSpeed});
            this.dgvPos.Location = new System.Drawing.Point(0, 3);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.RowHeadersVisible = false;
            this.dgvPos.RowHeadersWidth = 62;
            this.dgvPos.RowTemplate.Height = 30;
            this.dgvPos.Size = new System.Drawing.Size(535, 225);
            this.dgvPos.TabIndex = 3;
            this.dgvPos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPos_CellContentClick);
            this.dgvPos.SelectionChanged += new System.EventHandler(this.dgvPos_SelectionChanged);
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.MinimumWidth = 8;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 120;
            // 
            // colGo
            // 
            this.colGo.HeaderText = "执行";
            this.colGo.MinimumWidth = 8;
            this.colGo.Name = "colGo";
            this.colGo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGo.Width = 120;
            // 
            // colPose
            // 
            this.colPose.HeaderText = "位置mm";
            this.colPose.MinimumWidth = 8;
            this.colPose.Name = "colPose";
            this.colPose.ReadOnly = true;
            this.colPose.Width = 140;
            // 
            // colSpeed
            // 
            this.colSpeed.HeaderText = "速度mm/s";
            this.colSpeed.MinimumWidth = 8;
            this.colSpeed.Name = "colSpeed";
            this.colSpeed.ReadOnly = true;
            this.colSpeed.Width = 150;
            // 
            // pnlManual
            // 
            this.pnlManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlManual.Controls.Add(this.lblStatus);
            this.pnlManual.Controls.Add(this.btnClearAlarm);
            this.pnlManual.Controls.Add(this.btnStop);
            this.pnlManual.Controls.Add(this.chkBusServo);
            this.pnlManual.Controls.Add(this.label2);
            this.pnlManual.Controls.Add(this.lblUnits);
            this.pnlManual.Controls.Add(this.txtUnits);
            this.pnlManual.Controls.Add(this.lblTip);
            this.pnlManual.Controls.Add(this.lblAutoSpeed);
            this.pnlManual.Controls.Add(this.label9);
            this.pnlManual.Controls.Add(this.txtAutoSpeed);
            this.pnlManual.Controls.Add(this.txtCurPos);
            this.pnlManual.Controls.Add(this.btnHome);
            this.pnlManual.Controls.Add(this.label8);
            this.pnlManual.Controls.Add(this.label7);
            this.pnlManual.Controls.Add(this.label6);
            this.pnlManual.Controls.Add(this.label5);
            this.pnlManual.Controls.Add(this.label4);
            this.pnlManual.Controls.Add(this.txtDec);
            this.pnlManual.Controls.Add(this.txtAcc);
            this.pnlManual.Controls.Add(this.lblJogspeed);
            this.pnlManual.Controls.Add(this.label3);
            this.pnlManual.Controls.Add(this.txtJogSpeed);
            this.pnlManual.Controls.Add(this.btnJogPos);
            this.pnlManual.Controls.Add(this.btnJogNeg);
            this.pnlManual.Controls.Add(this.lblCurPos);
            this.pnlManual.Controls.Add(this.label1);
            this.pnlManual.Controls.Add(this.btnServoEnable);
            this.pnlManual.Location = new System.Drawing.Point(20, 200);
            this.pnlManual.Name = "pnlManual";
            this.pnlManual.Size = new System.Drawing.Size(635, 491);
            this.pnlManual.TabIndex = 2;
            // 
            // btnClearAlarm
            // 
            this.btnClearAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnClearAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnClearAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAlarm.ForeColor = System.Drawing.Color.White;
            this.btnClearAlarm.Location = new System.Drawing.Point(291, 428);
            this.btnClearAlarm.Name = "btnClearAlarm";
            this.btnClearAlarm.Size = new System.Drawing.Size(120, 50);
            this.btnClearAlarm.TabIndex = 32;
            this.btnClearAlarm.Tag = "";
            this.btnClearAlarm.Text = "清除报警";
            this.btnClearAlarm.UseVisualStyleBackColor = false;
            this.btnClearAlarm.Click += new System.EventHandler(this.btnClearAlarm_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(152, 428);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 50);
            this.btnStop.TabIndex = 31;
            this.btnStop.Tag = "btnServoOn";
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkBusServo
            // 
            this.chkBusServo.AutoSize = true;
            this.chkBusServo.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.chkBusServo.ForeColor = System.Drawing.Color.White;
            this.chkBusServo.Location = new System.Drawing.Point(13, 11);
            this.chkBusServo.Name = "chkBusServo";
            this.chkBusServo.Size = new System.Drawing.Size(127, 34);
            this.chkBusServo.TabIndex = 29;
            this.chkBusServo.Text = "总线伺服";
            this.chkBusServo.UseVisualStyleBackColor = true;
            this.chkBusServo.CheckedChanged += new System.EventHandler(this.chkBusServo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(555, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "pls/mm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblUnits.ForeColor = System.Drawing.Color.White;
            this.lblUnits.Location = new System.Drawing.Point(318, 139);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(110, 31);
            this.lblUnits.TabIndex = 25;
            this.lblUnits.Text = "脉冲当量";
            this.lblUnits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnits
            // 
            this.txtUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnits.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.txtUnits.ForeColor = System.Drawing.Color.White;
            this.txtUnits.Location = new System.Drawing.Point(434, 128);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnits.Size = new System.Drawing.Size(120, 50);
            this.txtUnits.TabIndex = 24;
            this.txtUnits.Text = "100";
            this.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTip
            // 
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            this.lblTip.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTip.Location = new System.Drawing.Point(325, 326);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(295, 50);
            this.lblTip.TabIndex = 23;
            this.lblTip.Text = "提示";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAutoSpeed
            // 
            this.lblAutoSpeed.AutoSize = true;
            this.lblAutoSpeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblAutoSpeed.ForeColor = System.Drawing.Color.White;
            this.lblAutoSpeed.Location = new System.Drawing.Point(318, 271);
            this.lblAutoSpeed.Name = "lblAutoSpeed";
            this.lblAutoSpeed.Size = new System.Drawing.Size(110, 31);
            this.lblAutoSpeed.TabIndex = 22;
            this.lblAutoSpeed.Text = "自动速度";
            this.lblAutoSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label9.Location = new System.Drawing.Point(555, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 22);
            this.label9.TabIndex = 21;
            this.label9.Text = "mm/s";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAutoSpeed
            // 
            this.txtAutoSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.txtAutoSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutoSpeed.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.txtAutoSpeed.ForeColor = System.Drawing.Color.White;
            this.txtAutoSpeed.Location = new System.Drawing.Point(434, 260);
            this.txtAutoSpeed.Name = "txtAutoSpeed";
            this.txtAutoSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAutoSpeed.Size = new System.Drawing.Size(120, 50);
            this.txtAutoSpeed.TabIndex = 20;
            this.txtAutoSpeed.Text = "0.0";
            this.txtAutoSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCurPos
            // 
            this.txtCurPos.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtCurPos.Location = new System.Drawing.Point(194, 56);
            this.txtCurPos.Name = "txtCurPos";
            this.txtCurPos.ReadOnly = true;
            this.txtCurPos.Size = new System.Drawing.Size(100, 34);
            this.txtCurPos.TabIndex = 19;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(13, 428);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(120, 50);
            this.btnHome.TabIndex = 17;
            this.btnHome.Tag = "btnServoOn";
            this.btnHome.Text = "回原点";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Location = new System.Drawing.Point(571, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 22);
            this.label8.TabIndex = 15;
            this.label8.Text = "mm/s";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Location = new System.Drawing.Point(571, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 22);
            this.label7.TabIndex = 14;
            this.label7.Text = "mm/s";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(417, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "减速度";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(101, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 31);
            this.label5.TabIndex = 12;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(418, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "加速度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDec
            // 
            this.txtDec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.txtDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDec.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.txtDec.ForeColor = System.Drawing.Color.White;
            this.txtDec.Location = new System.Drawing.Point(496, 56);
            this.txtDec.Name = "txtDec";
            this.txtDec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDec.Size = new System.Drawing.Size(74, 50);
            this.txtDec.TabIndex = 10;
            this.txtDec.Text = "0";
            this.txtDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAcc
            // 
            this.txtAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.txtAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcc.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.txtAcc.ForeColor = System.Drawing.Color.White;
            this.txtAcc.Location = new System.Drawing.Point(496, 0);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAcc.Size = new System.Drawing.Size(74, 50);
            this.txtAcc.TabIndex = 9;
            this.txtAcc.Text = "0";
            this.txtAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblJogspeed
            // 
            this.lblJogspeed.AutoSize = true;
            this.lblJogspeed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblJogspeed.ForeColor = System.Drawing.Color.White;
            this.lblJogspeed.Location = new System.Drawing.Point(318, 205);
            this.lblJogspeed.Name = "lblJogspeed";
            this.lblJogspeed.Size = new System.Drawing.Size(110, 31);
            this.lblJogspeed.TabIndex = 8;
            this.lblJogspeed.Text = "手动速度";
            this.lblJogspeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(555, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "mm/s";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJogSpeed
            // 
            this.txtJogSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.txtJogSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJogSpeed.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.txtJogSpeed.ForeColor = System.Drawing.Color.White;
            this.txtJogSpeed.Location = new System.Drawing.Point(434, 194);
            this.txtJogSpeed.Name = "txtJogSpeed";
            this.txtJogSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJogSpeed.Size = new System.Drawing.Size(120, 50);
            this.txtJogSpeed.TabIndex = 6;
            this.txtJogSpeed.Text = "0.0";
            this.txtJogSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnJogPos
            // 
            this.btnJogPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnJogPos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnJogPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogPos.ForeColor = System.Drawing.Color.White;
            this.btnJogPos.Location = new System.Drawing.Point(174, 116);
            this.btnJogPos.Name = "btnJogPos";
            this.btnJogPos.Size = new System.Drawing.Size(120, 50);
            this.btnJogPos.TabIndex = 5;
            this.btnJogPos.Text = "JOG +";
            this.btnJogPos.UseVisualStyleBackColor = false;
            // 
            // btnJogNeg
            // 
            this.btnJogNeg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnJogNeg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnJogNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJogNeg.ForeColor = System.Drawing.Color.White;
            this.btnJogNeg.Location = new System.Drawing.Point(35, 116);
            this.btnJogNeg.Name = "btnJogNeg";
            this.btnJogNeg.Size = new System.Drawing.Size(120, 50);
            this.btnJogNeg.TabIndex = 4;
            this.btnJogNeg.Text = "JOG -";
            this.btnJogNeg.UseVisualStyleBackColor = false;
            // 
            // lblCurPos
            // 
            this.lblCurPos.AutoSize = true;
            this.lblCurPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurPos.ForeColor = System.Drawing.Color.White;
            this.lblCurPos.Location = new System.Drawing.Point(42, 55);
            this.lblCurPos.Name = "lblCurPos";
            this.lblCurPos.Size = new System.Drawing.Size(110, 31);
            this.lblCurPos.TabIndex = 3;
            this.lblCurPos.Text = "实时坐标";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(304, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "mm";
            // 
            // btnServoEnable
            // 
            this.btnServoEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnServoEnable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(254)))));
            this.btnServoEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServoEnable.ForeColor = System.Drawing.Color.White;
            this.btnServoEnable.Location = new System.Drawing.Point(152, 11);
            this.btnServoEnable.Name = "btnServoEnable";
            this.btnServoEnable.Size = new System.Drawing.Size(127, 34);
            this.btnServoEnable.TabIndex = 18;
            this.btnServoEnable.Text = "使能开关";
            this.btnServoEnable.UseVisualStyleBackColor = false;
            this.btnServoEnable.Click += new System.EventHandler(this.btnServoEnable_Click);
            // 
            // pnlAxisStatus
            // 
            this.pnlAxisStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlAxisStatus.Controls.Add(this.chkSetInvertIn);
            this.pnlAxisStatus.Controls.Add(this.lblEnable);
            this.pnlAxisStatus.Controls.Add(this.lblRun);
            this.pnlAxisStatus.Controls.Add(this.lblAxisAlarm);
            this.pnlAxisStatus.Controls.Add(this.lblAxisState);
            this.pnlAxisStatus.Controls.Add(this.lblPosLimit);
            this.pnlAxisStatus.Controls.Add(this.lblHome);
            this.pnlAxisStatus.Controls.Add(this.lblNegLimit);
            this.pnlAxisStatus.Location = new System.Drawing.Point(20, 100);
            this.pnlAxisStatus.Name = "pnlAxisStatus";
            this.pnlAxisStatus.Size = new System.Drawing.Size(1184, 80);
            this.pnlAxisStatus.TabIndex = 1;
            // 
            // chkSetInvertIn
            // 
            this.chkSetInvertIn.AutoSize = true;
            this.chkSetInvertIn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.chkSetInvertIn.ForeColor = System.Drawing.Color.White;
            this.chkSetInvertIn.Location = new System.Drawing.Point(13, 23);
            this.chkSetInvertIn.Name = "chkSetInvertIn";
            this.chkSetInvertIn.Size = new System.Drawing.Size(108, 34);
            this.chkSetInvertIn.TabIndex = 33;
            this.chkSetInvertIn.Text = "反转IO";
            this.chkSetInvertIn.UseVisualStyleBackColor = true;
            this.chkSetInvertIn.CheckedChanged += new System.EventHandler(this.chkSetInvertIn_CheckedChanged);
            // 
            // lblEnable
            // 
            this.lblEnable.BackColor = System.Drawing.Color.LightGray;
            this.lblEnable.ForeColor = System.Drawing.Color.Black;
            this.lblEnable.Location = new System.Drawing.Point(132, 15);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(100, 50);
            this.lblEnable.TabIndex = 6;
            this.lblEnable.Text = "使  能";
            this.lblEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRun
            // 
            this.lblRun.BackColor = System.Drawing.Color.LightGray;
            this.lblRun.ForeColor = System.Drawing.Color.Black;
            this.lblRun.Location = new System.Drawing.Point(910, 15);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(100, 50);
            this.lblRun.TabIndex = 5;
            this.lblRun.Text = "运行中";
            this.lblRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAxisAlarm
            // 
            this.lblAxisAlarm.BackColor = System.Drawing.Color.LightGray;
            this.lblAxisAlarm.ForeColor = System.Drawing.Color.Black;
            this.lblAxisAlarm.Location = new System.Drawing.Point(780, 15);
            this.lblAxisAlarm.Name = "lblAxisAlarm";
            this.lblAxisAlarm.Size = new System.Drawing.Size(100, 50);
            this.lblAxisAlarm.TabIndex = 4;
            this.lblAxisAlarm.Text = "轴报警";
            this.lblAxisAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAxisState
            // 
            this.lblAxisState.BackColor = System.Drawing.Color.LightGray;
            this.lblAxisState.ForeColor = System.Drawing.Color.Black;
            this.lblAxisState.Location = new System.Drawing.Point(650, 15);
            this.lblAxisState.Name = "lblAxisState";
            this.lblAxisState.Size = new System.Drawing.Size(100, 50);
            this.lblAxisState.TabIndex = 3;
            this.lblAxisState.Text = "轴状态";
            this.lblAxisState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPosLimit
            // 
            this.lblPosLimit.BackColor = System.Drawing.Color.LightGray;
            this.lblPosLimit.ForeColor = System.Drawing.Color.Black;
            this.lblPosLimit.Location = new System.Drawing.Point(520, 15);
            this.lblPosLimit.Name = "lblPosLimit";
            this.lblPosLimit.Size = new System.Drawing.Size(100, 50);
            this.lblPosLimit.TabIndex = 2;
            this.lblPosLimit.Text = "正极限";
            this.lblPosLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHome
            // 
            this.lblHome.BackColor = System.Drawing.Color.LightGray;
            this.lblHome.ForeColor = System.Drawing.Color.Black;
            this.lblHome.Location = new System.Drawing.Point(390, 15);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(100, 50);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "原点";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNegLimit
            // 
            this.lblNegLimit.BackColor = System.Drawing.Color.LightGray;
            this.lblNegLimit.ForeColor = System.Drawing.Color.Black;
            this.lblNegLimit.Location = new System.Drawing.Point(260, 15);
            this.lblNegLimit.Name = "lblNegLimit";
            this.lblNegLimit.Size = new System.Drawing.Size(100, 50);
            this.lblNegLimit.TabIndex = 0;
            this.lblNegLimit.Text = "负极限";
            this.lblNegLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAxisSelect
            // 
            this.pnlAxisSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(90)))));
            this.pnlAxisSelect.Controls.Add(this.btnAxis3);
            this.pnlAxisSelect.Controls.Add(this.btnAxis2);
            this.pnlAxisSelect.Controls.Add(this.btnAxis1);
            this.pnlAxisSelect.Controls.Add(this.btnAxis0);
            this.pnlAxisSelect.Location = new System.Drawing.Point(20, 20);
            this.pnlAxisSelect.Name = "pnlAxisSelect";
            this.pnlAxisSelect.Size = new System.Drawing.Size(1184, 60);
            this.pnlAxisSelect.TabIndex = 0;
            // 
            // btnAxis3
            // 
            this.btnAxis3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnAxis3.FlatAppearance.BorderSize = 0;
            this.btnAxis3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxis3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAxis3.ForeColor = System.Drawing.Color.White;
            this.btnAxis3.Location = new System.Drawing.Point(680, 10);
            this.btnAxis3.Name = "btnAxis3";
            this.btnAxis3.Size = new System.Drawing.Size(200, 40);
            this.btnAxis3.TabIndex = 3;
            this.btnAxis3.Tag = 3;
            this.btnAxis3.Text = "马达3";
            this.btnAxis3.UseVisualStyleBackColor = false;
            // 
            // btnAxis2
            // 
            this.btnAxis2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnAxis2.FlatAppearance.BorderSize = 0;
            this.btnAxis2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxis2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAxis2.ForeColor = System.Drawing.Color.White;
            this.btnAxis2.Location = new System.Drawing.Point(460, 10);
            this.btnAxis2.Name = "btnAxis2";
            this.btnAxis2.Size = new System.Drawing.Size(200, 40);
            this.btnAxis2.TabIndex = 2;
            this.btnAxis2.Tag = 2;
            this.btnAxis2.Text = "马达2";
            this.btnAxis2.UseVisualStyleBackColor = false;
            // 
            // btnAxis1
            // 
            this.btnAxis1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnAxis1.FlatAppearance.BorderSize = 0;
            this.btnAxis1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxis1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAxis1.ForeColor = System.Drawing.Color.White;
            this.btnAxis1.Location = new System.Drawing.Point(240, 10);
            this.btnAxis1.Name = "btnAxis1";
            this.btnAxis1.Size = new System.Drawing.Size(200, 40);
            this.btnAxis1.TabIndex = 1;
            this.btnAxis1.Tag = 1;
            this.btnAxis1.Text = "马达1";
            this.btnAxis1.UseVisualStyleBackColor = false;
            // 
            // btnAxis0
            // 
            this.btnAxis0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(90)))));
            this.btnAxis0.FlatAppearance.BorderSize = 0;
            this.btnAxis0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxis0.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.btnAxis0.ForeColor = System.Drawing.Color.White;
            this.btnAxis0.Location = new System.Drawing.Point(20, 10);
            this.btnAxis0.Name = "btnAxis0";
            this.btnAxis0.Size = new System.Drawing.Size(200, 40);
            this.btnAxis0.TabIndex = 0;
            this.btnAxis0.Tag = 0;
            this.btnAxis0.Text = "马达0";
            this.btnAxis0.UseVisualStyleBackColor = false;
            // 
            // tmrServo
            // 
            this.tmrServo.Tick += new System.EventHandler(this.tmrServo_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStatus.Location = new System.Drawing.Point(15, 326);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(295, 50);
            this.lblStatus.TabIndex = 33;
            this.lblStatus.Text = "轴状态显示";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcServo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(122)))));
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcServo";
            this.Size = new System.Drawing.Size(1220, 710);
            this.Load += new System.EventHandler(this.UcServo_Load);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlarmDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNegLimitDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosLimitDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHomeDI)).EndInit();
            this.pnlPosTable.ResumeLayout(false);
            this.pnlPosTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            this.pnlAxisStatus.ResumeLayout(false);
            this.pnlAxisStatus.PerformLayout();
            this.pnlAxisSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlAxisSelect;
        private System.Windows.Forms.Button btnAxis0;
        private System.Windows.Forms.Button btnAxis3;
        private System.Windows.Forms.Button btnAxis2;
        private System.Windows.Forms.Button btnAxis1;
        private System.Windows.Forms.Button btnServoEnable;
        private System.Windows.Forms.Panel pnlAxisStatus;
        private System.Windows.Forms.Label lblNegLimit;
        private System.Windows.Forms.Label lblAxisAlarm;
        private System.Windows.Forms.Label lblAxisState;
        private System.Windows.Forms.Label lblPosLimit;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurPos;
        private System.Windows.Forms.Button btnJogNeg;
        private System.Windows.Forms.Button btnJogPos;
        private System.Windows.Forms.TextBox txtJogSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblJogspeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.TextBox txtCurPos;
        private System.Windows.Forms.Label lblAutoSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAutoSpeed;
        private System.Windows.Forms.Panel pnlPosTable;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Timer tmrServo;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadParam;
        private System.Windows.Forms.Button btnSaveParam;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.Label lblEnable;
        private System.Windows.Forms.CheckBox chkBusServo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnApplyParam;
        private System.Windows.Forms.NumericUpDown nudHomeDI;
        private System.Windows.Forms.NumericUpDown nudAlarmDI;
        private System.Windows.Forms.NumericUpDown nudNegLimitDI;
        private System.Windows.Forms.NumericUpDown nudPosLimitDI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddPos_Click;
        private System.Windows.Forms.Button btnDeletePos;
        private System.Windows.Forms.Button btnUpdatePos;
        private System.Windows.Forms.TextBox txtPosSpeed;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.TextBox txtPosName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewButtonColumn colGo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeed;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblconfig;
        private System.Windows.Forms.Button btnClearAlarm;
        private System.Windows.Forms.CheckBox chkSetInvertIn;
        private System.Windows.Forms.Label lblStatus;
    }
}
