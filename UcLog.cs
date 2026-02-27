using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KepsHIM.Models;
using static KepsHIM.Models.LogEntryExtensions;  // <<<=== 新增：using static 后可用 line.TryParse

namespace KepsHIM
{
    public partial class UcLog : UserControl
    {
        private List<LogEntry> _allLogs = new List<LogEntry>();

        public UcLog()
        {
            InitializeComponent();

            // 订阅日志（进入页面开始收集）
            LogManager.Instance.OnLogAdded += OnLogAdded;

            // 初始加载历史日志（从文件读）
            LoadHistoryLogs();

            cmbFilter.SelectedIndexChanged += (s, e) => RefreshLogDisplay();
            btnRefresh.Click += (s, e) => RefreshLogDisplay();
        }

        private void OnLogAdded(LogEntry entry)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<LogEntry>(OnLogAdded), entry);
                return;
            }

            // 新日志插到最前（最新在上）
            _allLogs.Insert(0, entry);

            // 检查当前过滤器是否匹配新日志
            bool isVisible = true;
            if (cmbFilter.SelectedItem != null)
            {
                string filter = cmbFilter.SelectedItem.ToString();
                if (filter == "今天" && entry.Timestamp.Date != DateTime.Today) isVisible = false;
                else if (filter == "本周") 
                {
                    var weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    if (entry.Timestamp < weekStart) isVisible = false;
                }
                else if (filter == "本月" && (entry.Timestamp.Month != DateTime.Now.Month || entry.Timestamp.Year != DateTime.Now.Year)) isVisible = false;
            }

            if (isVisible)
            {
                // 优化刷新：只在顶部插入
                try
                {
                    rtbFullLog.Select(0, 0);
                    rtbFullLog.SelectionColor = GetContrastColor(entry.Level, rtbFullLog.BackColor);
                    rtbFullLog.SelectedText = entry.ToString() + Environment.NewLine;
                    rtbFullLog.SelectionColor = rtbFullLog.ForeColor; // Reset
                    rtbFullLog.ScrollToCaret();
                }
                catch
                {
                    RefreshLogDisplay(); // 失败则全刷
                }
            }
        }

        private void LoadHistoryLogs()
        {
            string logPath = Path.Combine(Application.StartupPath, "Logs", "app.log");
            if (File.Exists(logPath))
            {
                string[] lines = File.ReadAllLines(logPath);
                foreach (string line in lines.Reverse())  // 逆序读（新在上）
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;  // 跳过空行
                    // <<<=== 修改：用扩展方法解析
                    if (line.TryParse(out LogEntry entry))  // 简洁调用
                    {
                        _allLogs.Add(entry);
                    }
                }
            }

            RefreshLogDisplay();
        }

        private void RefreshLogDisplay()
        {
            rtbFullLog.Clear();

            var filtered = _allLogs.AsEnumerable();

            switch (cmbFilter.SelectedItem?.ToString())
            {
                case "今天":
                    filtered = filtered.Where(l => l.Timestamp.Date == DateTime.Today);
                    break;
                case "本周":
                    var weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    filtered = filtered.Where(l => l.Timestamp >= weekStart);
                    break;
                case "本月":
                    filtered = filtered.Where(l => l.Timestamp.Month == DateTime.Now.Month && l.Timestamp.Year == DateTime.Now.Year);
                    break;
            }

            // 获取背景色，确保文字颜色与背景色有良好对比度
            Color backgroundColor = rtbFullLog.BackColor;

            foreach (var entry in filtered.OrderByDescending(l => l.Timestamp))
            {
                // 先记录当前文本长度，用于准确计算选择范围
                int currentLength = rtbFullLog.TextLength;
                
                // 追加日志行
                string logLine = entry.ToString() + Environment.NewLine;
                rtbFullLog.AppendText(logLine);

                // 根据日志级别和背景色智能设置颜色
                Color color = GetContrastColor(entry.Level, backgroundColor);
                
                // 设置整行文字颜色
                rtbFullLog.Select(currentLength, entry.ToString().Length);
                rtbFullLog.SelectionColor = color;
            }

            // <<<=== 修改：自动滚到顶
            rtbFullLog.SelectionStart = 0;
            rtbFullLog.ScrollToCaret(); // 自动滚到选择位置
        }
        
        // 确保文字颜色与背景色有良好对比度
        private Color GetContrastColor(LogLevel level, Color backgroundColor)
        {
            // 计算背景色的亮度
            double backgroundLuminance = (backgroundColor.R * 0.299 + backgroundColor.G * 0.587 + backgroundColor.B * 0.114) / 255;
            
            // 默认颜色映射
            Color defaultColor;
            switch (level)
            {
                case LogLevel.Debug:
                    defaultColor = Color.Gray;
                    break;
                case LogLevel.Info:
                    defaultColor = Color.Black;
                    break;
                case LogLevel.Warning:
                    defaultColor = Color.Orange;
                    break;
                case LogLevel.Error:
                    defaultColor = Color.Red;
                    break;
                case LogLevel.Fatal:
                    defaultColor = Color.DarkRed;
                    break;
                default:
                    defaultColor = Color.Black;
                    break;
            }
            
            // 如果背景色是浅色，使用默认颜色（通常较深）
            if (backgroundLuminance > 0.5)
            {
                return defaultColor;
            }
            else
            {
                // 深色背景，使用较亮的对比色
                switch (level)
                {
                    case LogLevel.Debug:
                        return Color.LightGray;
                    case LogLevel.Info:
                        return Color.White;
                    case LogLevel.Warning:
                        return Color.Yellow;
                    case LogLevel.Error:
                        return Color.LightCoral;
                    case LogLevel.Fatal:
                        return Color.LightCoral;
                    default:
                        return Color.White;
                }
            }
        }

        // 离开页面取消订阅（省资源）
        protected override void OnLeave(EventArgs e)
        {
            LogManager.Instance.OnLogAdded -= OnLogAdded;
            base.OnLeave(e);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            // 确认防止误操作
            if (MessageBox.Show("确认清除所有日志？\n（内存和文件日志都会清空，不可恢复）",
                "确认清除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // 清内存日志
                _allLogs.Clear();
                rtbFullLog.Clear();

                // 清文件日志
                string logPath = Path.Combine(Application.StartupPath, "Logs", "app.log");
                if (File.Exists(logPath))
                {
                    File.WriteAllText(logPath, "");  // 清空文件
                }
                LogManager.Instance.Info("日志已清除");
                RefreshLogDisplay();
                //lblTip.Text = "日志已清除";  // 如果有 lblTip

            }

        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            sfd.FileName = "log_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 导出当前显示日志（rtbFullLog.Text）
                    File.WriteAllText(sfd.FileName, rtbFullLog.Text);
                    MessageBox.Show("导出成功：" + sfd.FileName);
                    LogManager.Instance.Info("日志已导出：" + sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败：" + ex.Message);
                }
            }
        }
    }

   
}
