using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace KepsHIM.Models
{
    #region 日志级别枚举

    /// <summary>
    /// 日志级别
    /// </summary>
    public enum LogLevel
    {
        Debug,   // 调试信息
        Info,    // 正常信息
        Warning, // 警告
        Error,   // 错误
        Fatal    // 致命错误
    }

    #endregion

    #region 日志数据模型

    /// <summary>
    /// 单条日志
    /// </summary>
    public class LogEntry
    {
        public DateTime Timestamp { get; } = DateTime.Now;
        public LogLevel Level { get; }
        public string Message { get; }

        public LogEntry(LogLevel level, string message, DateTime? timestamp = null)
        {
            Level = level;
            Message = message;
            Timestamp = timestamp ?? DateTime.Now;
        }

        public LogEntry(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }

        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] {Message}";
        }
    }

    #endregion

    #region 日志解析扩展

    /// <summary>
    /// LogEntry 扩展方法：从字符串解析日志
    /// </summary>
    public static class LogEntryExtensions
    {
        private static readonly Regex LogRegex = new Regex(
            @"\[(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})\] \[(?<level>\w+)\] (?<message>.+)",
            RegexOptions.Compiled);

        /// <summary>
        /// 尝试解析一行日志字符串
        /// </summary>
        public static bool TryParse(this string line, out LogEntry entry)
        {
            entry = null;

            if (string.IsNullOrWhiteSpace(line))
                return false;

            try
            {
                line = line.Trim();
                Match match = LogRegex.Match(line);
                if (!match.Success)
                    return false;

                string tsStr = match.Groups["timestamp"].Value;
                if (!DateTime.TryParseExact(tsStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime timestamp))
                    return false;

                string levelStr = match.Groups["level"].Value;
                if (!Enum.TryParse<LogLevel>(levelStr, true, out LogLevel level))
                    level = LogLevel.Info;

                string message = match.Groups["message"].Value;
                entry = new LogEntry(level, message, timestamp);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    #endregion
}
