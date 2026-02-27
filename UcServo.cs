using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KepsHIM.Models;
using cszmcaux;

namespace KepsHIM
{
    public partial class UcServo : UserControl
    {

        private bool _isUpdatingUI = false;  // 标志：是否在更新界面（防止事件自触发）
        private AxisSetting _currentAxis; // 当前选中轴
        private List<AxisSetting> _axes = new List<AxisSetting>();

        public UcServo()
        {
            InitializeComponent();
        }

        private int _tickCount = 0; // 调试计数器

        /// <summary>
        /// Timer刷新：所有状态集中在这里（最重要！）
        /// </summary>
        private void tmrServo_Tick(object sender, EventArgs e)
        {
            try
            {
                _tickCount++;
                
                // 显示连接状态（直接读 MotionService 的文字）
                lblTip.Text = MotionService.Instance.ConnectionMessage;

                if (!MotionService.Instance.IsConnected)
                {
                    ClearAxisStatus();
                    // 调试日志：每20次记录一次未连接
                    if (_tickCount % 20 == 0) 
                    {
                        LogManager.Instance.Debug($"[UI Timer] 未连接，tick={_tickCount}");
                        Console.WriteLine("[UI Debug] Timer: Not Connected");
                    }
                    return;
                }

                if (_currentAxis == null)
                {
                    if (_tickCount % 20 == 0) 
                    {
                        LogManager.Instance.Warning($"[UI Timer] 当前轴为null，tick={_tickCount}");
                        Console.WriteLine("[UI Debug] Timer: CurrentAxis is null");
                    }
                    return;
                }

                // <<<=== 修改点2：读取最新状态（一次就够，所有显示基于这个）
                AxisStatus status = MotionService.Instance.ReadAxisStatus(_currentAxis);
                
                // 调试日志：大幅减少日志频率，只在需要调试时启用
                if (_tickCount % 100 == 0)  // 改为每100次（约20秒）记录一次
                {
                    string log = $"[UI Debug] Axis {_currentAxis.AxisIndex} Status: Enabled={status.IsEnabled}, Alarm={status.Alarm}, Home={status.Home}, PosLimit={status.PosLimit}, NegLimit={status.NegLimit}";
                    LogManager.Instance.Debug(log);
                    // 移除Console.WriteLine，避免控制台输出过多
                }

                // <<<=== 修改点3：推进回零状态（官方方法）
                MotionService.Instance.UpdateHomingState(_currentAxis);

                // 刷新所有UI
                UpdateAxisStatusUI(status);     // 灯 + 报警文字
                RefreshCurrentPosition();       // 位置文本框
                RefreshHomingTip();             // 回零提示
                UpdateJogEnableState();         // JOG按钮启用
                UpdateUIByHomingState();        // 回零时禁用按钮
                UpdateEnableUI(status);         // 使能显示
                UpdateAxisSelectUI();           // <<<=== 确保轴按钮状态实时正确
                
                // 移除UI更新完成日志，避免日志过多
            }
            catch (Exception ex)
            {
                // 捕获异常，防止Timer停止
                string errorMsg = $"[UI Error] Timer Tick Exception: {ex.Message}";
                LogManager.Instance.Error(errorMsg);
                Console.WriteLine(errorMsg);
            }
        }

        /// <summary>
        /// 统一刷新轴状态灯 + 报警文字（最简洁！）
        /// </summary>
        private void UpdateAxisStatusUI(AxisStatus status)
        {
            // <<<=== 新增：显示运动状态文字（醒目）
            if (status.IsMoving)
            {
                lblRun.Text = "运行中";          // 假设你有 lblRun Label
                lblRun.BackColor = Color.LimeGreen;
                lblTip.Text = "轴正在运动";
            }
            else
            {
                lblRun.Text = "停止";
                lblRun.BackColor = Color.Gray;
                // lblTip 留给其他提示
            }

            // 使能灯
            lblEnable.BackColor = status.IsEnabled ? Color.LimeGreen : Color.Gray;

            // 运动灯
            lblRun.Text = status.IsMoving ? "运行中" : "停止";
            lblRun.BackColor = status.IsMoving ? Color.LimeGreen : Color.Gray;

            // IO灯（原点/限位/报警）
            lblHome.BackColor = status.Home ? Color.LimeGreen : Color.Gray;
            lblPosLimit.BackColor = status.PosLimit ? Color.Red : Color.Gray;
            lblNegLimit.BackColor = status.NegLimit ? Color.Red : Color.Gray;
            lblAxisAlarm.BackColor = status.Alarm ? Color.Red : Color.Gray;

            // <<<=== 修改点4：报警文字统一判断（简单可靠）
            if (_currentAxis.AlarmDI < 0) // 屏蔽报警
            {
                lblTip.Text = "报警屏蔽（调试模式）";
                lblTip.ForeColor = Color.DarkOrange;
            }
            else if (status.Alarm)
            {
                lblTip.Text = "轴报警！";
                lblTip.ForeColor = Color.Red;
            }
            else
            {
                lblTip.Text = "轴状态正常";
                lblTip.ForeColor = Color.Green;
            }

            // 未回零绝对定位警告
            if (_currentAxis.PositionMode == AxisPositionMode.Absolute && !_currentAxis.IsHomed)
            {
                lblTip.Text = "⚠ 未回零，绝对定位不可用";
            }

            // 新增：用详细消息更新 lblTip（假设 lblStatus 是 lblTip）
            lblStatus.Text = status.Message;
            lblStatus.ForeColor = status.Alarm ? Color.Red : Color.Green;
        }

        /// <summary>
        /// 刷新当前位置（用新方法，单位正确）
        /// </summary>
        private void RefreshCurrentPosition()
        {
            if (MotionService.Instance.GetCurrentPos(_currentAxis, out float pos))
            {
                txtCurPos.Text = pos.ToString("F3");
            }
            else
            {
                txtCurPos.Text = "----";
            }
        }

        /// <summary>
        /// 回零提示文字
        /// </summary>
        private void RefreshHomingTip()
        {
            switch (_currentAxis.HomingState)
            {
                case AxisHomingState.None:
                    lblTip.Text = "未回零";
                    lblTip.ForeColor = Color.Red;
                    break;
                case AxisHomingState.Homing:
                    lblTip.Text = "回零中...";
                    lblTip.ForeColor = Color.Orange;
                    break;
                case AxisHomingState.Success:
                    lblTip.Text = "回零完成";
                    lblTip.ForeColor = Color.Green;
                    break;
                case AxisHomingState.Failed:
                    lblTip.Text = "回零失败";
                    lblTip.ForeColor = Color.Red;
                    break;
            }
        }

        /// <summary>
        /// 回零时禁用JOG和回零按钮
        /// </summary>
        private void UpdateUIByHomingState()
        {
            bool homing = _currentAxis.HomingState == AxisHomingState.Homing;
            btnJogNeg.Enabled = !homing;
            btnJogPos.Enabled = !homing;
            btnHome.Enabled = !homing;
        }

        /// <summary>
        /// 使能显示
        /// </summary>
        private void UpdateEnableUI(AxisStatus status)
        {
            // 移除 EnsureServoEnableButton();

            // 更新标签状态
            lblEnable.Text = status.IsEnabled ? "使能" : "未使能";
            lblEnable.BackColor = status.IsEnabled ? Color.LimeGreen : Color.Gray;
            
            // 更新按钮文字，方便操作
            if (btnServoEnable != null)
            {
                btnServoEnable.Text = status.IsEnabled ? "关闭使能" : "开启使能";
                btnServoEnable.BackColor = status.IsEnabled ? Color.LightCoral : Color.LightGreen;
            }
        }

        /// <summary>
        /// JOG按钮启用（只在连接时）
        /// </summary>
        private void UpdateJogEnableState()
        {
            bool connected = MotionService.Instance.IsConnected;
            btnJogPos.Enabled = connected;
            btnJogNeg.Enabled = connected;
            btnHome.Enabled = connected;
        }

        /// <summary>
        /// 未连接时清空显示
        /// </summary>
        private void ClearAxisStatus()
        {
            txtCurPos.Text = "----";
            lblHome.BackColor = Color.Gray;
            lblPosLimit.BackColor = Color.Gray;
            lblNegLimit.BackColor = Color.Gray;
            lblAxisAlarm.BackColor = Color.Gray;
            lblEnable.BackColor = Color.Gray;
            lblRun.BackColor = Color.Gray;
        }

        /// <summary>
        /// 页面加载：初始化一切
        /// </summary>
        private void UcServo_Load(object sender, EventArgs e)
        {
            LogManager.Instance.Info("UcServo_Load: 开始初始化伺服界面");
            
            // 加载轴配置
            _axes = GlobalAxisManager.Axes;
            if (_axes == null || _axes.Count == 0)
            {
                LogManager.Instance.Warning("UcServo_Load: 未加载轴配置");
                MessageBox.Show("未加载轴配置");
                return;
            }

            LogManager.Instance.Info($"UcServo_Load: 加载了{_axes.Count}个轴配置");

            // 默认选第一轴
            _currentAxis = _axes[0];
            LogManager.Instance.Info($"UcServo_Load: 当前选中轴{_currentAxis.AxisIndex}, DriveType={_currentAxis.DriveType}");

            // <<<=== 1. 设置默认选中总线伺服 (根据用户需求)
            chkBusServo.Checked = true;
            if (_currentAxis != null) _currentAxis.DriveType = AxisDriveType.Bus;

            UpdateAxisSelectUI();
            RefreshAxisParamUI();
            RefreshPositionTable();

            // 动态绑定轴按钮（只绑一次）
            foreach (Control c in pnlAxisSelect.Controls)
            {
                if (c is Button btn)
                {
                    btn.Click += btnAxis_Click; // 统一事件
                }
            }

            // JOG鼠标事件
            btnJogNeg.MouseDown += (s, args) => StartJog(-1);
            btnJogNeg.MouseUp += (s, args) => MotionService.Instance.JogStop(_currentAxis.AxisIndex);
            btnJogPos.MouseDown += (s, args) => StartJog(1);
            btnJogPos.MouseUp += (s, args) => MotionService.Instance.JogStop(_currentAxis.AxisIndex);

            // 启动Timer（200ms间隔）
            tmrServo.Interval = 200;
            tmrServo.Start();
            LogManager.Instance.Info($"UcServo_Load: 定时器已启动，间隔={tmrServo.Interval}ms");
            
            // 立即执行一次UI刷新，避免等待第一个Timer tick
            tmrServo_Tick(null, EventArgs.Empty);
        }

        /// <summary>
        /// 页面隐藏时停止Timer（节省资源）
        /// </summary>
        private void UcServo_Leave(object sender, EventArgs e)
        {
            tmrServo.Stop();
        }

        /// <summary>
        /// 轴选择按钮
        /// </summary>
        private void btnAxis_Click(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;

            // 从按钮名或Tag取轴号（你原来的代码用Name，这里改得更稳）
            string name = btn.Name.Replace("btnAxis", "");
            if (!int.TryParse(name, out int axisIndex)) return;

            _currentAxis = _axes.FirstOrDefault(a => a.AxisIndex == axisIndex);
            if (_currentAxis == null) return;

            UpdateAxisSelectUI();
            RefreshAxisParamUI();
            RefreshPositionTable();
            lblTip.Text = $"当前轴：Axis {_currentAxis.AxisIndex}";
        }

        /// <summary>
        /// 更新轴选择按钮颜色
        /// </summary>
        private void UpdateAxisSelectUI()
        {
            // 1. 获取当前有效轴数
            int validCount = GlobalAxisManager.AxisCount;

            foreach (Control c in pnlAxisSelect.Controls)
            {
                if (c is Button btn)
                {
                    string name = btn.Name.Replace("btnAxis", "");
                    if (int.TryParse(name, out int index))
                    {
                        // 2. 判断按钮是否应该可见
                        if (index < validCount)
                        {
                            btn.Visible = true;
                            btn.Enabled = true;
                            // 高亮选中轴
                            btn.BackColor = (_currentAxis.AxisIndex == index) ? Color.DodgerBlue : Color.Gray;
                        }
                        else
                        {
                            // 超出配置的轴，隐藏且不可点
                            btn.Visible = false;
                            btn.Enabled = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 刷新参数显示
        /// </summary>
        public void RefreshAxisParamUI()
        {
            if (_currentAxis == null) return;
            _isUpdatingUI = true;  // <<<=== 新增：开始更新，禁止事件写回

            txtUnits.Text = _currentAxis.Units.ToString("F3");
            txtJogSpeed.Text = _currentAxis.JogSpeed.ToString("F3");
            txtAutoSpeed.Text = _currentAxis.AutoSpeed.ToString("F3");
            txtAcc.Text = _currentAxis.Acc.ToString("F3");
            txtDec.Text = _currentAxis.Dec.ToString("F3");


            nudHomeDI.Value = Math.Max(nudHomeDI.Minimum, Math.Min(nudHomeDI.Maximum, _currentAxis.HomeDI));
            nudPosLimitDI.Value = Math.Max(nudPosLimitDI.Minimum, Math.Min(nudPosLimitDI.Maximum, _currentAxis.PosLimitDI));
            nudNegLimitDI.Value = Math.Max(nudNegLimitDI.Minimum, Math.Min(nudNegLimitDI.Maximum, _currentAxis.NegLimitDI));
            nudAlarmDI.Value = Math.Max(nudAlarmDI.Minimum, Math.Min(nudAlarmDI.Maximum, _currentAxis.AlarmDI));

            _isUpdatingUI = false;  // <<<=== 新增：结束更新，恢复事件
        }

        /// <summary>
        /// 参数改动时写回AxisConfig（安全解析）
        /// </summary>
        private void SaveParamFromUI()
        {
            if (_currentAxis == null) return;

            if (float.TryParse(txtUnits.Text, out float v)) _currentAxis.Units = v;
            if (float.TryParse(txtJogSpeed.Text, out v)) _currentAxis.JogSpeed = v;
            if (float.TryParse(txtAutoSpeed.Text, out v)) _currentAxis.AutoSpeed = v;
            if (float.TryParse(txtAcc.Text, out v)) _currentAxis.Acc = v;
            if (float.TryParse(txtDec.Text, out v)) _currentAxis.Dec = v;

            _currentAxis.HomeDI = (int)nudHomeDI.Value;
            _currentAxis.PosLimitDI = (int)nudPosLimitDI.Value;
            _currentAxis.NegLimitDI = (int)nudNegLimitDI.Value;
            _currentAxis.AlarmDI = (int)nudAlarmDI.Value;
        }

        // 文本框失去焦点时保存（MouseLeave或Leave事件）
        private void txtUnits_Leave(object sender, EventArgs e) => SaveParamFromUI();
        private void txtJogSpeed_Leave(object sender, EventArgs e) => SaveParamFromUI();
        private void txtAutoSpeed_Leave(object sender, EventArgs e) => SaveParamFromUI();
        private void txtAcc_Leave(object sender, EventArgs e) => SaveParamFromUI();
        private void txtDec_Leave(object sender, EventArgs e) => SaveParamFromUI();

        // NumericUpDown改动立即保存
        private void nudHomeDI_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingUI) return;  // <<<=== 新增：更新界面时跳过
            if (_currentAxis == null) return;

            // <<<=== 新增：立即写回当前轴
            _currentAxis.HomeDI = (int)nudHomeDI.Value;

        }

        private void nudPosLimitDI_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingUI) return;  // <<<=== 新增：更新界面时跳过
            if (_currentAxis == null) return;
            _currentAxis.PosLimitDI = (int)nudPosLimitDI.Value;

        }
        private void nudNegLimitDI_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingUI) return;  // <<<=== 新增：更新界面时跳过
            if (_currentAxis == null) return;
            _currentAxis.NegLimitDI = (int)nudNegLimitDI.Value;

        }
        private void nudAlarmDI_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdatingUI) return;  // <<<=== 新增：更新界面时跳过
            if (_currentAxis == null) return;
            _currentAxis.AlarmDI = (int)nudAlarmDI.Value;

        }



        /// <summary>
        /// 应用参数到板卡
        /// </summary>
        private void btnApplyParam_Click(object sender, EventArgs e)
        {


            SaveParamFromUI(); // 先保存UI改动
            try
            {
                MotionService.Instance.InitAxis(_currentAxis); // 只应用当前轴
                lblconfig.Text = $"轴{_currentAxis.AxisIndex} 参数已应用";
            }
            catch (Exception ex)
            {
                MessageBox.Show("应用失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 保存参数到文件
        /// </summary>
        private void btnSaveParam_Click(object sender, EventArgs e)
        {
            if (_currentAxis == null) return;

            SaveParamFromUI();
            GlobalAxisManager.Save();
            lblconfig.Text = "参数已保存到文件";
            RefreshAxisParamUI();  // 保存后立即刷新界面
        }

        /// <summary>
        /// JOG启动
        /// </summary>
        private void StartJog(int dir)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡");
                return;
            }

            // 获取当前轴状态（统一从 MotionService 获取）
            AxisStatus st = MotionService.Instance.ReadAxisStatus(_currentAxis);
            if (!st.IsEnabled)
            {
                MessageBox.Show("轴未使能");
                return;
            }

            // 下发JOG
            MotionService.Instance.JogStart(_currentAxis, dir);
        }

        /// <summary>
        /// 回零按钮
        /// </summary>
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡");
                return;
            }

            MotionService.Instance.StartHome(_currentAxis);
            lblTip.Text = "开始回零...";
        }

        /// <summary>
        /// 急停
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            MotionService.Instance.StopAxis(_currentAxis.AxisIndex);
        }

        /// <summary>
        /// 刷新定位表
        /// </summary>
        private void RefreshPositionTable()
        {
            dgvPos.Rows.Clear();
            if (_currentAxis == null) return;

            // <<<=== 新增：Positions null 时创建空列表
            if (_currentAxis.Positions == null)
                _currentAxis.Positions = new List<AxisPositionItem>();

            foreach (var pos in _currentAxis.Positions)
            {
                int row = dgvPos.Rows.Add();
                dgvPos.Rows[row].Cells["colName"].Value = pos.Name;
                dgvPos.Rows[row].Cells["colPose"].Value = pos.Position;
                dgvPos.Rows[row].Cells["colSpeed"].Value = pos.Speed;
                dgvPos.Rows[row].Tag = pos;
            }
        }

        /// <summary>
        /// 定位执行
        /// </summary>
        private void dgvPos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvPos.Columns[e.ColumnIndex].Name != "colGo") return;

            var item = dgvPos.Rows[e.RowIndex].Tag as AxisPositionItem;
            if (item == null) return;

            if (!MotionService.Instance.CanMove(_currentAxis, out string reason))
            {
                MessageBox.Show(reason);
                return;
            }

            try
            {
                MotionService.Instance.ExecutePosition(_currentAxis, item);
                lblTip.Text = $"执行定位：{item.Name}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("定位失败：" + ex.Message);
            }
        }

        // 定位表增删改（保持原逻辑，加安全）
        private void btnAddPos_Click_Click(object sender, EventArgs e)
        {
            if (_currentAxis == null) return;
            if (!float.TryParse(txtPos.Text, out float position) || !float.TryParse(txtPosSpeed.Text, out float speed)) return;

            var item = new AxisPositionItem
            {
                Name = txtPosName.Text.Trim(),
                Position = position,
                Speed = speed
            };

            _currentAxis.Positions.Add(item);
            RefreshPositionTable();
        }

        private void btnUpdatePos_Click(object sender, EventArgs e)
        {
            if (dgvPos.CurrentRow?.Tag is AxisPositionItem item)
            {
                if (!float.TryParse(txtPos.Text, out float position) || !float.TryParse(txtPosSpeed.Text, out float speed)) return;

                item.Name = txtPosName.Text.Trim();
                item.Position = position;
                item.Speed = speed;
                RefreshPositionTable();
            }
        }

        private void btnDeletePos_Click(object sender, EventArgs e)
        {
            if (dgvPos.CurrentRow?.Tag is AxisPositionItem item)
            {
                if (MessageBox.Show("确认删除？", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _currentAxis.Positions.Remove(item);
                    RefreshPositionTable();
                }
            }
        }

        private void dgvPos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPos.CurrentRow?.Tag is AxisPositionItem item)
            {
                txtPosName.Text = item.Name;
                txtPos.Text = item.Position.ToString("F3");
                txtPosSpeed.Text = item.Speed.ToString("F3");
            }
        }

        // private System.Windows.Forms.Button btnServoEnable; // 移除这行，避免遮蔽 Designer 成员

        /// <summary>
        /// 确保 btnServoEnable 实例存在（防止 Designer 中丢失）
        /// </summary>
        private void EnsureServoEnableButton()
        {
             // 移除此方法，信任 Designer 的 btnServoEnable
        }

        /// <summary>
        /// 使能开关按钮点击事件
        /// </summary>
        private async void btnServoEnable_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("板卡未连接", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 读取当前状态
            AxisStatus currentStatus = MotionService.Instance.ReadAxisStatus(_currentAxis);
            bool targetState = !currentStatus.IsEnabled;

            // 显示操作确认
            string message = $"确定要{(targetState ? "开启" : "关闭")}轴{_currentAxis.AxisIndex}的使能吗？";
            if (MessageBox.Show(message, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 执行操作
            bool success = MotionService.Instance.SetServoEnable(_currentAxis.AxisIndex, targetState);

            if (success)
            {
                // 状态验证：重试最多3次，每次100ms延迟
                // 总线伺服可能需要更长时间更新状态
                bool stateVerified = false;
                int retryCount = 0;
                const int maxRetries = 3;
                const int retryDelayMs = 100;
                
                while (!stateVerified && retryCount < maxRetries)
                {
                    await Task.Delay(retryDelayMs);
                    retryCount++;
                    
                    AxisStatus newStatus = MotionService.Instance.ReadAxisStatus(_currentAxis);
                    
                    if (newStatus.IsEnabled == targetState)
                    {
                        stateVerified = true;
                        lblTip.Text = $"使能{(targetState ? "开启" : "关闭")}成功 (重试{retryCount})";
                        lblTip.ForeColor = Color.Green;
                        LogManager.Instance.Debug($"使能状态验证成功: 轴{_currentAxis.AxisIndex}, 期望={targetState}, 重试次数={retryCount}");
                    }
                    else
                    {
                        LogManager.Instance.Debug($"使能状态验证中: 轴{_currentAxis.AxisIndex}, 期望={targetState}, 实际={newStatus.IsEnabled}, 重试{retryCount}/{maxRetries}");
                    }
                }
                
                if (!stateVerified)
                {
                    // 最终检查
                    AxisStatus finalStatus = MotionService.Instance.ReadAxisStatus(_currentAxis);
                    lblTip.Text = "状态未更新，请检查硬件";
                    lblTip.ForeColor = Color.Orange;
                    LogManager.Instance.Warning($"使能状态不一致: 轴{_currentAxis.AxisIndex}, 期望={targetState}, 实际={finalStatus.IsEnabled}, 重试次数={retryCount}");
                }
            }
            else
            {
                MessageBox.Show("使能设置失败，请检查日志", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadParam_Click(object sender, EventArgs e)
        {
            try
            {
                // 调用全局加载（从 axis_config.json 读所有轴配置）
                GlobalAxisManager.Load();

                // 更新本地 _axes 列表
                _axes = GlobalAxisManager.Axes;

                // 如果当前轴还存在，重新取最新的配置
                if (_currentAxis != null)
                {
                    int currentIndex = _currentAxis.AxisIndex;
                    _currentAxis = GlobalAxisManager.GetAxisByIndex(currentIndex);
                }

                // 刷新界面参数显示
                RefreshAxisParamUI();
                RefreshPositionTable();  // 如果有定位表，也刷新

                // 成功提示
                lblconfig.Text = "参数已从配置文件加载";
                lblconfig.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                // 失败时提示
                MessageBox.Show("加载参数失败：" + ex.Message);
                lblconfig.Text = "加载失败";
                lblconfig.ForeColor = Color.Red;
            }

        }

        private void btnClearAlarm_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡");
                return;
            }

            // 调用 MotionService 清除报警方法
            bool success = MotionService.Instance.ClearDriveAlarm(_currentAxis.AxisIndex);

            if (success)
            {
                lblTip.Text = "清除报警指令已发送";
            }
            else
            {
                MessageBox.Show("清除报警失败，请查看日志");
            }
        }

        // <<<=== 新增：总线伺服勾选事件，刷新使能状态
        private void chkBusServo_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentAxis == null) return;

            _currentAxis.DriveType = chkBusServo.Checked ? AxisDriveType.Bus : AxisDriveType.Ordinary;

            // 切换模式后，立即读取一次使能状态更新 chkEnable (如果是总线，状态来自板卡)
            if (MotionService.Instance.IsConnected)
            {
                // 仅刷新状态，不做额外动作
                MotionService.Instance.ReadAxisStatus(_currentAxis);
            }
        }
        
        private void chkSetInvertIn_CheckedChanged(object sender, EventArgs e)
        {
            if (_currentAxis == null) return;
            _currentAxis.IsSetInvertIn = chkSetInvertIn.Checked;   // 先更新模型

            // 调用 MotionService 设置反转

            MotionService.Instance.SetAxisInvert(_currentAxis.AxisIndex, chkSetInvertIn.Checked);
        }

        /// <summary>
        /// 调试方法：显示详细的使能状态信息
        /// 使用方法：在需要的地方调用 DebugServoEnableStatus()
        /// </summary>
        private void DebugServoEnableStatus()
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡", "调试信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"当前轴: {_currentAxis?.AxisIndex ?? -1}");
            sb.AppendLine($"轴类型: {_currentAxis?.DriveType}");
            sb.AppendLine($"连接状态: {MotionService.Instance.IsConnected}");
            
            if (_currentAxis != null)
            {
                // 读取使能状态
                int en1 = 0, en2 = 0;
                try
                {
                    zmcaux.ZAux_Direct_GetAxisEnable(MotionService.Instance.Handle, _currentAxis.AxisIndex, ref en1);
                    zmcaux.ZAux_Direct_GetBusAxisEnable(MotionService.Instance.Handle, _currentAxis.AxisIndex, ref en2);
                    
                    sb.AppendLine($"GetAxisEnable 返回值: {en1}");
                    sb.AppendLine($"GetBusAxisEnable 返回值: {en2}");
                    sb.AppendLine($"状态一致性: {(en1 == en2 ? "一致" : "不一致")}");
                    
                    // 读取当前UI显示的状态
                    AxisStatus status = MotionService.Instance.ReadAxisStatus(_currentAxis);
                    sb.AppendLine($"UI显示状态: {status.IsEnabled}");
                    sb.AppendLine($"报警状态: {status.Alarm}");
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"读取状态异常: {ex.Message}");
                }
            }
            
            MessageBox.Show(sb.ToString(), "调试信息 - 使能状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}