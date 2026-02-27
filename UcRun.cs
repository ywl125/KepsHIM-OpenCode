using KepsHIM.Models;  // 假设你的 AxisConfig 在这里
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

namespace KepsHIM
{
    public partial class UcRun : UserControl
    {

        private const int MaxLogLines = 6;  // 最多显示8条日志（可调 3-8）
        private List<LogEntry> _recentLogs = new List<LogEntry>();  // 缓存最近日志
        private readonly DateTime _programStartTime = DateTime.Now;  // 记录本次程序启动时间

        public Timer timerRefresh;
        // 在类定义顶部添加一个字段记录当前状态（可选，用于调试或确保只调一次Start/Stop）
        // 示例：产量、周期等变量（你根据实际改）
        private int yieldCount = 0;         // 产量计数
        private DateTime cycleStartTime;    // 周期开始时间
        private bool isRunning = false;     // 是否在生产中（你实际逻辑控制）
        private bool _isLogSubscribed = false;  // 跟踪日志订阅状态

        private void ClearRecentLogs()
        {
            _recentLogs.Clear();
            rtbLog.Clear();
        }
        public UcRun()
        {
            InitializeComponent();
            ClearRecentLogs();  // <<<=== 启动时清空旧日志

            // 订阅 VisibleChanged 事件
            this.VisibleChanged += UcRun_VisibleChanged;





            //<<<=== 如果你没用设计师拖Timer，用代码new（二选一）
            timerRefresh = new Timer();
            timerRefresh.Interval = 500;
            timerRefresh.Tick += timerRefresh_Tick;

            // 初始化产量等
            yieldCount = 0;
            lblYield.Text = "0";  // 假设你有 lblYield Label

            // 安全订阅日志事件
            SubscribeToLogs();

           
            
        }
        
        // 安全订阅日志，确保只订阅一次
        private void SubscribeToLogs()
        {
            if (!_isLogSubscribed)
            {
                LogManager.Instance.OnLogAdded += OnLogReceived;
                _isLogSubscribed = true;
            }
        }
        
        // 安全取消订阅日志，确保只取消一次
        private void UnsubscribeFromLogs()
        {
            if (_isLogSubscribed)
            {
                LogManager.Instance.OnLogAdded -= OnLogReceived;
                _isLogSubscribed = false;
            }
        }

        // 销毁时停止定时器
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (timerRefresh != null)
            {
                timerRefresh.Stop();
                timerRefresh.Dispose();
            }
            // 安全取消订阅
            UnsubscribeFromLogs();
            base.OnHandleDestroyed(e);
        }


        /// <summary>
        /// 公共方法：手动刷新所有状态（主窗体调用，保险刷新）
        /// </summary>
        public void RefreshAll()
        {
          
            // 先显示连接状态（安全）
            lblStatus.Text = MotionService.Instance.ConnectionMessage;

            if (MotionService.Instance.ConnectionMessage.Contains("已连接"))
            {
                lblStatus.Text = "运行界面就绪 - " + MotionService.Instance.ConnectionMessage;
                lblStatus.ForeColor = Color.Green;
            }
            else if (MotionService.Instance.ConnectionMessage == "已断开")
            {
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "运行界面就绪 - 请先连接板卡";
                lblStatus.ForeColor = Color.Orange;
            }

            // <<<=== 加安全：只有连接时才读状态（防止卡或错）
            if (MotionService.Instance.IsConnected)
            {
                // 运动状态 - 修复：需要正确检测轴是否运动
                bool anyAxisMoving = false;
                string movingText = "";

                string alarmText = "";                  
                bool hasAlarm = false;

                // 安全检查：确保Axes不为null
                if (GlobalAxisManager.Axes != null)
                {
                    foreach (var axis in GlobalAxisManager.Axes)
                    {
                        AxisStatus st = MotionService.Instance.ReadAxisStatus(axis);

                        // 检测运动状态
                        if (st.IsMoving)
                        {
                            anyAxisMoving = true;
                            movingText += $"轴{axis.AxisIndex}运动中; ";
                        }

                        // 修复：累加报警信息，而不是覆盖
                        if (!string.IsNullOrEmpty(st.Message) && st.Message != "轴状态正常")
                        {
                            alarmText += $"轴{axis.AxisIndex}: {st.Message}; ";
                            hasAlarm = true;
                        }
                        else if (st.Alarm)
                        {
                            alarmText += $"轴{axis.AxisIndex} 报警（未知详情）; ";
                            hasAlarm = true;
                        }
                    }
                }

                // 修复：将报警显示放在循环外面，只显示一次
                if (hasAlarm)
                {
                    lblAlarm.Text = alarmText.TrimEnd(';', ' ');  // 去掉末尾多余的分号和空格
                    lblAlarm.ForeColor = Color.Red;
                    lblAlarm.BackColor = Color.LightYellow;
                }
                else
                {
                    lblAlarm.Text = "无报警";
                    lblAlarm.ForeColor = Color.Green;
                    lblAlarm.BackColor = SystemColors.Control;
                }

                if (anyAxisMoving)
                {
                    lblMoving.Text = movingText.TrimEnd(';', ' ');
                    lblMoving.BackColor = Color.LimeGreen;
                }
                else
                {
                    lblMoving.Text = "所有轴停止";
                    lblMoving.BackColor = Color.Gray;
                }

                // 位置
                var positions = MotionService.Instance.GetAllCurrentPositions();

                if (positions.TryGetValue(0, out float xPos))
                    lblPosX.Text = $"{xPos:F2}";

                if (positions.TryGetValue(1, out float yPos))
                    lblPosY.Text = $"{yPos:F2}";
                
                // 产量保持
                lblYield.Text = yieldCount.ToString();
            }
            else
            {
                // 未连接时清状态（防止旧数据）
                lblMoving.Text = "未连接";
                lblPosX.Text = "----";
                lblPosY.Text = "----";
                lblAlarm.Text = "未连接";
            }
        }

        /// <summary>
        /// 当这个用户控件被加载到主窗体时（显示时）启动刷新
        /// </summary>
        private void UcRun_Load(object sender, EventArgs e)
        {
            // 确保日志订阅已添加
            SubscribeToLogs();
            // 加载历史日志
            //LoadHistoryLogs();
        }
        // 在类定义顶部添加一个字段记录当前状态（可选，用于调试或确保只调一次Start/Stop）
        private bool _isTimerActive = false;

        private void UcRun_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && !_isTimerActive)
            {
                // 当控件变为可见且定时器未激活时
                timerRefresh.Start();
                _isTimerActive = true;
                // 确保日志订阅已添加
                SubscribeToLogs();
                // 加载历史日志
                LoadHistoryLogs();
            }
            else if (!this.Visible && _isTimerActive)
            {
                // 当控件变为不可见且定时器已激活时
                timerRefresh.Stop();
                _isTimerActive = false;
            }
        }

        /// <summary>
        /// 当这个用户控件被移除/隐藏时停止刷新（节省资源）
        /// </summary>
        //private void UcRun_Leave(object sender, EventArgs e)
        //{
        //    timerRefresh.Stop();
        //}

        /// <summary>
        /// 定时器每500ms执行一次：刷新所有状态
        /// </summary>
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // <<<=== 测试1：改 lblStatus 文字（看是否每500ms变）
            TimeSpan duration = DateTime.Now - _programStartTime;

            lblTest.Text = $"{duration:hh\\:mm\\:ss}";

            //// <<<=== 测试2：数字加1（保持 lblTest）
            //if (lblTest != null)
            //{
            //    int num = 0;
            //    if (int.TryParse(lblTest.Text, out num))
            //    {
            //        num++;
            //    }
            //    lblTest.Text = num.ToString();
            //}

            RefreshAll();
        }

        // <<<=== 示例：产量+1按钮（你实际用触发信号）
        private void btnProductComplete_Click(object sender, EventArgs e)
        {
            yieldCount++;
            // 开始新周期
            cycleStartTime = DateTime.Now;
            isRunning = true;
        }

        // <<<=== 示例：周期结束
        public void CycleComplete()
        {
            isRunning = false;
        }

        // 离开控件时取消日志订阅（释放资源）
        private void UcRun_Leave(object sender, EventArgs e)
        {
            // 注意：不要在这里取消订阅，因为Leave事件可能不可靠
            // 日志订阅在 OnHandleDestroyed 中处理
        }

        // 接收日志并显示
        private void OnLogReceived(LogEntry entry)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<LogEntry>(OnLogReceived), entry);
                return;
            }

            // 1. 更新缓存数据（保持最新在最前）
            _recentLogs.Insert(0, entry);
            if (_recentLogs.Count > MaxLogLines)
            {
                _recentLogs.RemoveAt(_recentLogs.Count - 1);
            }

            // 2. 优化刷新逻辑：只插入新的一行，不重绘整个控件
            // 步骤：光标移到开头 -> 设置颜色 -> 插入文本 -> 恢复颜色
            try
            {
                rtbLog.Select(0, 0); // 移动到开头
                
                // 获取颜色
                Color color = GetLogColor(entry.Level);
                
                rtbLog.SelectionColor = color; // 设置插入文本的颜色
                rtbLog.SelectedText = entry.ToString() + Environment.NewLine; // 插入文本
                
                // 恢复默认颜色（防止影响后续操作）
                rtbLog.SelectionColor = rtbLog.ForeColor;

                // 3. 移除多余的行（如果超过最大行数）
                // 注意：RichTextBox会自动处理最后的一个空行，所以行数通常是 MaxLogLines + 1
                // 简单处理：如果行数过多，直接重绘一次（偶尔重绘比每次重绘好），或者计算字符位置删除
                // 为了严格满足"不影响之前日志"，这里尝试精准删除最后一行
                if (rtbLog.Lines.Length > MaxLogLines + 1) // +1 是因为末尾可能有换行
                {
                    int lastLineIndex = rtbLog.Lines.Length - 2; // 倒数第二行（倒数第一行往往是空的）
                    if (lastLineIndex >= MaxLogLines)
                    {
                         // 找到这一行的起始位置
                         int start = rtbLog.GetFirstCharIndexFromLine(MaxLogLines);
                         if (start >= 0)
                         {
                             rtbLog.Select(start, rtbLog.TextLength - start);
                             rtbLog.SelectedText = "";
                         }
                    }
                }
            }
            catch (Exception)
            {
                 // 容错：如果局部刷新失败，回退到全量刷新
                 UpdateLogDisplay();
            }
        }

        private Color GetLogColor(LogLevel level)
        {
             switch (level)
            {
                case LogLevel.Debug: return Color.Gray;
                case LogLevel.Info: return Color.Black;
                case LogLevel.Warning: return Color.Orange;
                case LogLevel.Error: return Color.Red;
                case LogLevel.Fatal: return Color.DarkRed;
                default: return Color.Black;
            }
        }

        private void UcRun_Shown(object sender, EventArgs e)
        {
            // 加载历史日志 (根据需求修改：不显示历史日志，注释掉此行)
            // LoadHistoryLogs();
            
            // 重新订阅（防止丢失）
            LogManager.Instance.OnLogAdded -= OnLogReceived;  // 先取消，避免重复订阅
            LogManager.Instance.OnLogAdded += OnLogReceived;
        }
        
        // 加载历史日志
        private void LoadHistoryLogs()
        {
            string logPath = Path.Combine(Application.StartupPath, "Logs", "app.log");
            if (File.Exists(logPath))
            {
                try
                {
                    // 读取所有行
                    string[] lines = File.ReadAllLines(logPath);
                    _recentLogs.Clear();
                    var recentLines = File.ReadLines(logPath).Reverse().Take(MaxLogLines).ToList();
                    // 倒序遍历（从文件最后一行开始，即最新的日志）
                    // 只取最近的 MaxLogLines 条
                    int count = 0;
                    for (int i = lines.Length - 1; i >= 0; i--)
                    {
                        string line = lines[i];
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        if (line.TryParse(out LogEntry entry))
                        {
                            // 双重保险：只加载本次启动后的日志
                            if (entry.Timestamp < _programStartTime) continue;

                            _recentLogs.Add(entry); // 添加到列表（列表顺序：[最新, 次新, ... Old]）
                            count++;
                            if (count >= MaxLogLines) break;
                        }
                    }
                    
                    // 更新UI
                    UpdateLogDisplay();
                }
                catch (Exception ex)
                {
                    LogManager.Instance.Error($"加载历史日志失败: {ex.Message}");
                }
            }
        }

        // 更新日志显示
        private void UpdateLogDisplay()
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(UpdateLogDisplay));
                return;
            }

            rtbLog.Clear();

            // 获取背景色，确保文字颜色与背景色有良好对比度
            Color backgroundColor = rtbLog.BackColor;

            foreach (var log in _recentLogs)
            {
                // 先记录当前文本长度，用于计算位置
                int currentLength = rtbLog.Text.Length;

                // 追加日志行
                string logLine = log.ToString() + Environment.NewLine;
                rtbLog.AppendText(logLine);

                // 为不同日志级别设置颜色，确保与背景色对比度良好
                Color color;
                switch (log.Level)
                {
                    case LogLevel.Debug:
                        color = GetContrastColor(Color.Gray, backgroundColor);
                        break;
                    case LogLevel.Info:
                        color = GetContrastColor(Color.Black, backgroundColor);
                        break;
                    case LogLevel.Warning:
                        color = GetContrastColor(Color.Orange, backgroundColor);
                        break;
                    case LogLevel.Error:
                        color = GetContrastColor(Color.Red, backgroundColor);
                        break;
                    case LogLevel.Fatal:
                        color = GetContrastColor(Color.DarkRed, backgroundColor);
                        break;
                    default:
                        color = GetContrastColor(Color.Black, backgroundColor);
                        break;
                }

                // 设置整行文字颜色
                rtbLog.Select(currentLength, log.ToString().Length);
                rtbLog.SelectionColor = color;
            }
        }
        
        // 确保文字颜色与背景色有良好对比度
        private Color GetContrastColor(Color originalColor, Color backgroundColor)
        {
            // 计算背景色的亮度
            double backgroundLuminance = (backgroundColor.R * 0.299 + backgroundColor.G * 0.587 + backgroundColor.B * 0.114) / 255;
            
            // 如果背景色是浅色，使用原始颜色；如果是深色，使用较亮的颜色
            if (backgroundLuminance > 0.5)
            {
                // 浅色背景，使用原始颜色（通常较深）
                return originalColor;
            }
            else
            {
                // 深色背景，根据日志级别使用较亮的对比色
                switch (originalColor.Name)
                {
                    case "Gray":
                        return Color.LightGray;
                    case "Black":
                        return Color.White;
                    case "Orange":
                        return Color.Yellow;
                    case "Red":
                        return Color.LightCoral;
                    case "DarkRed":
                        return Color.LightCoral;
                    default:
                        return Color.White;
                }
            }
        }


    }
}