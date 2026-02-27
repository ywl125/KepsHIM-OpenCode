using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KepsHIM.Models;

namespace KepsHIM
{
    /// <summary>
    /// 日志管理器（单例，扩展性强）
    /// 支持：级别过滤、异步写、轮转、缓冲
    /// </summary>
    public class LogManager
    {
        private static readonly LogManager _instance = new LogManager();
        public static LogManager Instance => _instance;

        // 日志事件：新日志广播
        public event Action<LogEntry> OnLogAdded;

        // 配置（可自定义）
        public LogLevel MinLogLevel { get; set; } = LogLevel.Info;  // 最小记录级别（Debug 以下不记）
        private readonly ConcurrentQueue<LogEntry> _logQueue = new ConcurrentQueue<LogEntry>();  // 缓冲队列
        private readonly object _queueLock = new object();  // 替换 _isProcessingQueue，使用更安全的锁

        // 文件路径
        private readonly string _logPath = Path.Combine(Application.StartupPath, "Logs", "app.log");
        private const long MaxFileSize = 10 * 1024 * 1024;  // 10MB 轮转

        private LogManager()
        {
            // 创建目录
            string dir = Path.GetDirectoryName(_logPath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            // 启动异步处理队列
            Task.Run(ProcessQueueAsync);
        }

        // 记录日志
        public void Debug(string message) => LogIfLevel(LogLevel.Debug, message);
        public void Info(string message) => LogIfLevel(LogLevel.Info, message);
        public void Warning(string message) => LogIfLevel(LogLevel.Warning, message);
        public void Error(string message) => LogIfLevel(LogLevel.Error, message);
        public void Fatal(string message) => LogIfLevel(LogLevel.Fatal, message);

        private void LogIfLevel(LogLevel level, string message)
        {
            if (level < MinLogLevel) return;  // 过滤低级别

            LogEntry entry = new LogEntry(level, message);

            // 控制台输出（调试用）
            Console.WriteLine(entry.ToString());

            // 广播事件
            OnLogAdded?.Invoke(entry);

            // 加到缓冲队列（异步写文件）
            _logQueue.Enqueue(entry);
        }

        // 异步处理队列（写文件 + 轮转）
        private async Task ProcessQueueAsync()
        {
            while (true)
            {
                if (_logQueue.IsEmpty)
                {
                    await Task.Delay(100);  // 空闲等
                    continue;
                }

                // 使用锁防止多线程同时处理
                lock (_queueLock)
                {
                    if (_logQueue.IsEmpty) continue;  // 双重检查

                    CheckFileSizeAndRotate();  // 轮转检查

                    // 使用 using 确保资源正确释放
                    using (StreamWriter writer = new StreamWriter(_logPath, true))
                    {
                        while (_logQueue.TryDequeue(out LogEntry entry))
                        {
                            writer.WriteLine(entry.ToString());
                        }
                    }
                }
            }
        }

        // 文件轮转（大小超限新文件）
        private void CheckFileSizeAndRotate()
        {
            try
            {
                if (File.Exists(_logPath) && new FileInfo(_logPath).Length > MaxFileSize)
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string archivePath = _logPath + "." + timestamp + ".archive";
                    File.Move(_logPath, archivePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"日志轮转失败: {ex.Message}");
            }
        }
    }
}
