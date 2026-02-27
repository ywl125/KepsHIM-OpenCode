using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;  // Stopwatch 
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KepsHIM
{
    public partial class FrmMain : Form, IDisposable
    {
        #region 字段
        private bool _hasShownDisconnectMsg = false;
        private bool _isConnected = false;
        private System.Windows.Forms.Timer _timer;
        private readonly object _connectionLock = new object();
        private readonly object _uiUpdateLock = new object();
        private bool _disposed = false;
        private UcRun _ucRunInstance;  // 保存唯一的运行页面实例
        private UcServo _ucServoInstance;  // 保存唯一的伺服页面实例
        private UcLog _ucLogInstance;
        private UcParam _ucParamInstance;//保存唯一的参数页面实例
        private UcFlyCapture _ucFlyCaptureInstance;
        #endregion

        #region 构造和析构
        public FrmMain()
        {
            InitializeComponent();

            GlobalAxisManager.Load();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.LastIp))
            {
                txtIp.Text = Properties.Settings.Default.LastIp;
            }
            else
            {
                txtIp.Text = "192.168.0.11";
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // 释放托管资源
                    _timer?.Stop();
                    _timer?.Dispose();
                }

                _disposed = true;
            }
            base.Dispose(disposing);
        }
        #endregion

        #region UI导航方法
        /// <summary>
        /// 切换右侧页面
        /// </summary>
        /// <param name="page">要显示的用户控件</param>
        private void ShowPage(UserControl page)
        {
            if (page == null) return;

            try
            {
                     // 清空现有控件
                 pnlMain.Controls.Clear();
            
                     // 设置填充模式
                page.Dock = DockStyle.Fill;
            
                // 添加新控件
                pnlMain.Controls.Add(page);

                // 如果是 UcRun，强制刷新（如果其他页面也需要状态保持，这里也可以添加）
                if (page is UcRun ucRun)
                {
                    ucRun.RefreshAll();
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error($"切换页面时发生错误: {ex.Message}");
                MessageBox.Show($"切换页面时发生错误: {ex.Message}", "错误", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 页面切换事件
        private void btnRun_Click(object sender, EventArgs e)
        {
            
            ///////////////////////////
            try
            {
                if (_ucRunInstance == null)
                {
                    // 第一次才创建
                    _ucRunInstance = new UcRun();
                }

                ShowPage(_ucRunInstance);  // 总是显示同一个实例

                // 强制刷新一次（保险）
                _ucRunInstance.RefreshAll();

                // 确保 Timer 在运行
                if (!_ucRunInstance.timerRefresh.Enabled)
                {
                    _ucRunInstance.timerRefresh.Interval = 500;
                    _ucRunInstance.timerRefresh.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载运行页面失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnServo_Click(object sender, EventArgs e)
        {
            if (_ucServoInstance == null)
            {
                _ucServoInstance = new UcServo();
            }

            ShowPage(_ucServoInstance);  // 显示同一个实例

            // 强制刷新一次
            _ucServoInstance.RefreshAxisParamUI();
        }

        private void btnIO_Click(object sender, EventArgs e)
        {
            try
            {
                ShowPage(new UcIO());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载IO页面失败: {ex.Message}", "错误", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCylinder_Click(object sender, EventArgs e)
        {
            try
            {

                ShowPage(new UcCylinder());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载气缸页面失败: {ex.Message}", "错误", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnParam_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ucParamInstance == null)
                {
                    _ucParamInstance = new UcParam();//唯一实例
                                                     // 显示参数设置页面                    
                }

                ShowPage(_ucParamInstance);

            }


            catch (Exception ex)
            {
                LogManager.Instance.Error($"加载参数设置页面失败: {ex.Message}");
                MessageBox.Show($"加载参数设置页面失败: {ex.Message}", "错误",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFlyCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ucFlyCaptureInstance == null)
                {
                    _ucFlyCaptureInstance = new UcFlyCapture();
                }
                ShowPage(_ucFlyCaptureInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载飞拍模块失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 连接管理
        private async void btnInit_Click(object sender, EventArgs e)
        {
            bool shouldProceed = false;
            lock (_connectionLock)
            {
                if (!_isConnected)
                {
                    shouldProceed = true;
                }
            }

            if (!shouldProceed)
            {
                MessageBox.Show("板卡已经连接，请勿重复操作！", "提示", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 验证IP地址
            string ip = txtIp.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                LogManager.Instance.Warning("请输入正确的IP地址！");
                MessageBox.Show("请输入正确的IP地址！", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 禁用按钮防止重复点击
            btnInit.Enabled = false;
            lblStatus.Text = "正在连接...";

            try
            {
                // 异步连接
                bool connectResult = await ConnectToDeviceAsync(ip);
            
                if (connectResult)
                {
                    // <<<=== 修改：等待总线初始化（最多等待5秒）
                    // 用户反馈：多次点击才正常，需延时等待初始化完成
                    LogManager.Instance.Info("正在等待板卡总线初始化...");
                    lblStatus.Text = "等待总线初始化...";
                    
                    int busStatus = -1;
                    // 循环检查10次，每次500ms，共5秒
                    for (int i = 0; i < 10; i++) 
                    {
                        busStatus = MotionService.Instance.GetBusInitStatus();
                        
                        if (busStatus == 1) 
                        {
                            // 初始化成功
                            break; 
                        }
                        
                        if (busStatus == 0) 
                        {
                            // 初始化明确失败
                            break; 
                        }
                        
                        // Status = -1 (初始化中)，继续等待
                        await Task.Delay(500);
                    }

                    string busMsg = "未知";
                    
                    if (busStatus == 1)
                    {
                        busMsg = "OK";
                        LogManager.Instance.Info("检测到板卡总线已初始化成功");
                    }
                    else if (busStatus == 0)
                    {
                        busMsg = "Fail";
                        LogManager.Instance.Error("检测到板卡总线初始化失败！");
                        if (MessageBox.Show("板卡总线初始化失败 (Bus_InitStatus=0)，是否继续初始化轴参数？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            UpdateConnectionStatus(false, "总线初始化失败", Color.Orange);
                            return;
                        }
                    }
                    else
                    {
                        busMsg = "Timeout";
                        LogManager.Instance.Warning($"板卡总线初始化超时或状态未知 (Status={busStatus})");
                        if (MessageBox.Show($"总线初始化超时 (Status={busStatus})，可能需要更多时间或重启板卡。\n是否强行继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                             UpdateConnectionStatus(false, "总线初始化超时", Color.Orange);
                             return;
                        }
                    }

                    // 初始化轴
                    bool initResult = await InitializeAxesAsync();
                
                    if (initResult)
                    {
                        UpdateConnectionStatus(true, $"{ip} 连接成功 (总线:{busMsg})", Color.Green);
                        MessageBox.Show($"板卡连接及初始化完成！\n总线状态: {busMsg}", "成功", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        LogManager.Instance.Warning("轴初始化失败，请检查配置");
                        UpdateConnectionStatus(false, "轴初始化失败", Color.Red);
                        MessageBox.Show("轴初始化失败，请检查配置", "错误", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
                else
                {
                    LogManager.Instance.Warning("板卡连接失败！请检查IP和网线...");
                    UpdateConnectionStatus(false, "连接失败", Color.Red);
                    MessageBox.Show("板卡连接失败！请检查IP和网线...", "错误", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            finally
            {
                // 重新启用按钮
                btnInit.Enabled = true;
            }
        }

        /// <summary>
        /// 异步连接设备
        /// </summary>
        private async Task<bool> ConnectToDeviceAsync(string ip)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return MotionService.Instance.Connect(ip);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"连接设备异常: {ex.Message}");
                    LogManager.Instance.Error(ex.Message);
                    return false;
                }
            });
        }



        /// <summary>
        /// 异步初始化轴
        /// </summary>
        private async Task<bool> InitializeAxesAsync()
        {
            return await Task.Run(() =>
            {
                try
                {
                    MotionService.Instance.InitAllAxes();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"初始化轴异常: {ex.Message}");
                    LogManager.Instance.Error(ex.Message);
                    return false;
                }
            });
        }

        /// <summary>
        /// 更新连接状态显示
        /// </summary>
        private void UpdateConnectionStatus(bool isConnected, string message, Color color)
        {
            lock (_uiUpdateLock)
            {
                _isConnected = isConnected;
                lblStatus.Text = message;
                lblStatus.ForeColor = color;
            }
        }
    #endregion

    #region 定时器相关
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                // 默认显示运行界面
                btnRun.PerformClick();

                // 初始化定时器
                InitializeTimer();

                lblDateTime.Text = "正在加载时间...";

                // <<<=== 新增：启动时提示用户需回零
                lblStatus.Text = "程序初始化，请复位！";
                lblStatus.ForeColor = Color.Orange;
                // 全局订阅日志（启动错也显示）
               // LogManager.Instance.OnLogAdded += OnGlobalLogReceived;
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error($"窗体加载失败: {ex.Message}");
                MessageBox.Show($"窗体加载失败: {ex.Message}", "错误", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 检查加载是否成功
            if (GlobalAxisManager.Axes == null || GlobalAxisManager.Axes.Count == 0)
            {
                LogManager.Instance.Error("轴参数加载失败，使用默认参数");
                MessageBox.Show("轴参数加载失败，使用默认参数");
            }
            else
            {
                lblStatus.Text = "轴参数加载成功";
            }

           
        }



        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer
            {
                Interval = 500 // 500ms更新一次
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
         }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {   
                // 更新时间
                lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // 检查连接状态
                CheckConnectionStatus();
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error($"定时器异常: {ex.Message}");
                Debug.WriteLine($"定时器异常: {ex.Message}");
            }
        }

        /// <summary>
    /// 检查连接状态
    /// </summary>
        private void CheckConnectionStatus()
        {
            bool isConnectedCopy;
            lock (_uiUpdateLock)
            {
                isConnectedCopy = _isConnected;
            }

            if (!isConnectedCopy) return;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool readSuccess = false;
            float testPos = 0;

            // 安全检查轴配置
            if (GlobalAxisManager.Axes != null && GlobalAxisManager.Axes.Count > 0)
            {
                var firstAxis = GlobalAxisManager.Axes[0];
                readSuccess = MotionService.Instance.GetCurrentPos(firstAxis, out testPos);
            }

            stopwatch.Stop();

            // 检查是否超时或读取失败（超时判定改为2秒更合理）
            if (stopwatch.ElapsedMilliseconds > 2000 || !readSuccess)
            {
                HandleDisconnection();
            }
            else
            {
                // 重置断开消息标志
                _hasShownDisconnectMsg = false;

                // 更新连接状态
                UpdateConnectionStatus(
                    true, 
                    MotionService.Instance.ConnectionMessage, 
                    Color.Green
                );
            }
        }

        /// <summary>
        /// 处理断开连接
        /// </summary>
        private void HandleDisconnection()
        {
            // 断开服务
            MotionService.Instance.Disconnect();
            MotionService.Instance.ConnectionMessage = "已断开";

            // 更新状态
            UpdateConnectionStatus(false, "板卡已断开（超时或断电）", Color.Red);

            // 显示警告消息（仅一次）
            if (!_hasShownDisconnectMsg)
            {
                _hasShownDisconnectMsg = true;
                MessageBox.Show("检测到板卡断开或响应超时！请检查电源和网线后重新连接", 
                "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    #endregion

    #region 窗体事件
        private void FrmMain_Shown(object sender, EventArgs e)
    {
        // 确保运行界面显示
        btnRun.PerformClick();
    }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡");
                return;
            }

            int axisNumber = 0;  // 你想操作的轴号，可以从下拉框或变量取

            bool success = MotionService.Instance.start_Vmove(axisNumber, 1);  // 正向连续运动

            if (success)
            {
                lblStatus.Text = $"轴 {axisNumber} 开始正向连续运动";
            }
            else
            {
                MessageBox.Show($"轴 {axisNumber} 启动失败（可能未连接或配置缺失）");
                LogManager.Instance.Error($"轴 {axisNumber} 启动失败（可能未连接或配置缺失）");
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        Close();
        }

    

    
        #endregion

        private void btnStop_Click(object sender, EventArgs e)
        {
            MotionService.Instance.stop_Vmove(0);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            MessageBox.Show("复位功能待实现", "提示",
          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }

           

            // <<<=== 修改：加 Axes null 检查
            if (MotionService.Instance.IsConnected && GlobalAxisManager.Axes != null && GlobalAxisManager.Axes.Count > 0)
            {
                foreach (var axis in GlobalAxisManager.Axes)
                {
                    MotionService.Instance.JogStop(axis.AxisIndex);
                }
            }

            try
            {
                MotionService.Instance.Disconnect();
            }
            catch
            {

            } // 忽略

        }
            

           

        public void btnLog_Click(object sender, EventArgs e)
        {
            if (_ucLogInstance == null)
            {
                _ucLogInstance = new UcLog();
            }

            ShowPage(_ucLogInstance);

        }

       
    }

}