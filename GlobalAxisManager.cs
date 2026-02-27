using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using KepsHIM.Models;


namespace KepsHIM
{    /// <summary>
    /// 全局轴配置管理器
    /// 负责：加载 / 保存 / 提供轴配置
    /// </summary>
    public static class GlobalAxisManager
    {
        private static bool _isLoaded = false;  // 标志：是否已加载（防多次调用）
        private static DateTime _lastBackupTime = DateTime.MinValue;  // 上次备份时间，防止频繁备份
        private static readonly object _saveLock = new object();  // 保存操作锁，防止并发保存
        
        /// <summary>
        /// 轴数量配置 (默认4)
        /// </summary>
        public static int AxisCount { get; set; } = 4;

        /// <summary>
        /// 当前系统中所有轴的配置
        /// </summary>
        public static List<AxisSetting> Axes { get; private set; }

        private static string _configPath = Path.Combine(Application.StartupPath, "Configs", "axis_config.json");
        
        /// <summary>
        /// 程序启动时调用
        /// </summary>
        public static void Load()
        {
            if (_isLoaded) return;  // <<<=== 防重复调用

            // 步骤1：尝试加载主文件
            try
            {
                if (File.Exists(_configPath))
                {
                    string json = File.ReadAllText(_configPath);
                    
                    // 尝试解析新格式 (包含 AxisCount)
                    try 
                    {
                        var configWrapper = JsonConvert.DeserializeObject<dynamic>(json);
                        if (configWrapper.Axes != null)
                        {
                            Axes = configWrapper.Axes.ToObject<List<AxisSetting>>();
                            AxisCount = (int)configWrapper.AxisCount;
                        }
                        else
                        {
                            // 兼容旧格式 (直接是 List<AxisSetting>)
                            Axes = JsonConvert.DeserializeObject<List<AxisSetting>>(json);
                            AxisCount = Axes.Count;
                        }
                    }
                    catch
                    {
                        // 兼容旧格式
                        Axes = JsonConvert.DeserializeObject<List<AxisSetting>>(json);
                        AxisCount = Axes != null ? Axes.Count : 4;
                    }

                    if (Axes == null || Axes.Count == 0)
                    {
                        LogManager.Instance.Error("配置文件为空或无效");
                        throw new Exception("配置为空");
                    }

                    // 校验重复轴号
                    var duplicates = Axes.GroupBy(a => a.AxisIndex).Where(g => g.Count() > 1).Select(g => g.Key);
                    if (duplicates.Any())
                    {
                        LogManager.Instance.Warning("配置有重复轴号：" + string.Join(", ", duplicates));
                        throw new Exception("配置有重复轴号");
                    }

                    // 复位回零状态
                    foreach (var axis in Axes)
                    {
                        axis.IsHomed = false;
                        axis.HomingState = AxisHomingState.None;
                        axis.HomingStartTime = DateTime.MinValue;
                        axis.HasAlarm = false;
                    }

                    LogManager.Instance.Info("参数从文件加载成功");
                    _isLoaded = true;
                    return;  // 成功结束
                }
                else
                {
                    LogManager.Instance.Warning("配置文件不存在");
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error("加载主配置文件失败：" + ex.Message);
                MessageBox.Show("加载主配置文件失败：" + ex.Message);
            }

            // 步骤2：主文件失败，尝试恢复备份
            string backupPath = _configPath + ".bak";
            if (File.Exists(backupPath))
            {
                try
                {
                    File.Copy(backupPath, _configPath, true);
                    LogManager.Instance.Info("备份文件已恢复为配置文件");
                    MessageBox.Show("配置文件不存在,备份文件已恢复为配置文件");

                    // 立即重新读取恢复后的主文件
                    string json = File.ReadAllText(_configPath);
                    Axes = JsonConvert.DeserializeObject<List<AxisSetting>>(json);

                    if (Axes == null || Axes.Count == 0)
                    {
                        LogManager.Instance.Error("恢复后的配置文件为空");
                        throw new Exception("恢复后的配置为空");
                    }

                    // 校验 + 复位
                    var duplicates = Axes.GroupBy(a => a.AxisIndex).Where(g => g.Count() > 1).Select(g => g.Key);
                    if (duplicates.Any())
                    {
                        LogManager.Instance.Warning("恢复配置有重复轴号：" + string.Join(", ", duplicates));
                        throw new Exception("恢复配置有重复轴号");
                    }

                    foreach (var axis in Axes)
                    {
                        axis.IsHomed = false;
                        axis.HomingState = AxisHomingState.None;
                        axis.HomingStartTime = DateTime.MinValue;
                        axis.HasAlarm = false;
                    }

                    LogManager.Instance.Info("备份参数加载成功");
                    _isLoaded = true;
                    return;  // 恢复成功结束
                }
                catch (Exception ex)
                {
                    LogManager.Instance.Error("备份恢复失败：" + ex.Message);
                    MessageBox.Show("备份恢复失败：" + ex.Message);
                }
            }
            else
            {
                LogManager.Instance.Warning("无备份文件可用");
            }

            // 步骤3：所有尝试失败，使用默认
            LogManager.Instance.Info("使用默认参数创建轴配置");
            MessageBox.Show("使用默认参数创建轴配置");

            LoadDefault();

            // 默认后复位
            foreach (var axis in Axes)
            {
                axis.IsHomed = false;
                axis.HomingState = AxisHomingState.None;
                axis.HomingStartTime = DateTime.MinValue;
                axis.HasAlarm = false;
            }

            // <<<=== 新增：默认后自动保存生成文件
            Save();

            _isLoaded = true;

        }
        

        private static void LoadDefault()
        {
            Axes = new List<AxisSetting>();

            for (int i = 0; i < 4; i++)
            {
                Axes.Add(new AxisSetting
                {
                    AxisIndex = i,
                    DriveType = AxisDriveType.Bus, // 默认总线
                    PositionMode = AxisPositionMode.Absolute,
                    Units = 100.0f,
                    JogSpeed = 50.0f,
                    AutoSpeed = 50.0f,
                    Acc = 10.0f,
                    Dec = 10.0f,

                    // <<<=== 补齐 IO 默认 -1
                    HomeDI = -1,
                    PosLimitDI = -1,
                    NegLimitDI = -1,
                    AlarmDI = -1,

                    IsHomed = false,
                    HomingState = AxisHomingState.None,
                    HomingStartTime = DateTime.MinValue,
                    HasAlarm = false,

                    PickPos = 0.0f,
                    PlacePos = 0.0f,
                    WaitPos = 0.0f,

                    Positions = new List<AxisPositionItem>()  // 空列表
                });
            }
            LogManager.Instance.Info("已使用默认参数创建轴配置");
            MessageBox.Show("已使用默认参数创建轴配置");
            
        }
        

        ///// <summary>
        ///// 参数修改后保存
        ///// </summary>
        public static void Save()
        {
            lock (_saveLock)
            {
                try
                {
                    if (Axes == null || Axes.Count == 0)
                    {
                        LogManager.Instance.Error("轴配置为空，无法保存");
                        MessageBox.Show("轴配置为空，无法保存");
                        
                        return;
                    }

                    // 更新 AxisCount 属性以匹配实际列表长度
                    AxisCount = Axes.Count;

                    // 创建一个包装对象用于序列化，包含轴列表和总轴数
                    var configData = new 
                    {
                        AxisCount = AxisCount,
                        Axes = Axes
                    };

                    string dir = Path.GetDirectoryName(_configPath);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    // <<<=== 新增：自动备份策略（优化：每小时最多备份一次）
                    string json = JsonConvert.SerializeObject(configData, Formatting.Indented);

                    // 1. 版本备份（每小时只备份一次）
                    DateTime now = DateTime.Now;
                    if ((now - _lastBackupTime).TotalHours >= 1)
                    {
                        string timestamp = now.ToString("yyyy-MM-dd_HH-mm-ss");
                        string versionBackupPath = _configPath + "." + timestamp + ".bak";
                        File.WriteAllText(versionBackupPath, json);
                        _lastBackupTime = now;
                        
                        // 清理旧的版本备份（只保留最近10个）
                        CleanupOldBackups();
                    }

                    // 2. 标准备份（覆盖 .bak）
                    string standardBackupPath = _configPath + ".bak";
                    if (File.Exists(_configPath))
                    {
                        File.Copy(_configPath, standardBackupPath, true);
                    }
                    else
                    {
                        // 如果主文件不存在，先写备份（保险）
                        File.WriteAllText(standardBackupPath, json);
                    }

                    // 3. 写主文件
                    File.WriteAllText(_configPath, json);

                    //MessageBox.Show("参数保存成功，已自动备份（.bak + 版本备份）");
                }
                catch (Exception ex)
                {
                    LogManager.Instance.Error("保存失败：" + ex.Message);
                    MessageBox.Show("保存失败：" + ex.Message);
                    
                }
            }
        }

        /// <summary>
        /// 清理旧版本备份文件，只保留最近10个
        /// </summary>
        private static void CleanupOldBackups()
        {
            try
            {
                string dir = Path.GetDirectoryName(_configPath);
                if (string.IsNullOrEmpty(dir)) return;

                var backupFiles = Directory.GetFiles(dir, "axis_config.json.*.bak")
                    .OrderByDescending(f => File.GetCreationTime(f))
                    .Skip(10)
                    .ToList();

                foreach (var file in backupFiles)
                {
                    try
                    {
                        File.Delete(file);
                        LogManager.Instance.Debug($"已删除旧备份文件: {Path.GetFileName(file)}");
                    }
                    catch (Exception ex)
                    {
                        LogManager.Instance.Warning($"删除旧备份文件失败: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Warning($"清理旧备份时出错: {ex.Message}");
            }
        }

        public static void UpdateAxisCount(int newCount)
        {
            if (Axes == null) Axes = new List<AxisSetting>();

            if (newCount > Axes.Count)
            {
                // 增加轴：复制最后一个轴的配置或使用默认
                for (int i = Axes.Count; i < newCount; i++)
                {
                    var newAxis = new AxisSetting
                    {
                        AxisIndex = i,
                        DriveType = AxisDriveType.Bus,
                        // 复制其他默认参数...
                        Units = 100.0f,
                        JogSpeed = 50.0f,
                        AutoSpeed = 50.0f,
                        Acc = 10.0f,
                        Dec = 10.0f,
                        HomeDI = -1, PosLimitDI = -1, NegLimitDI = -1, AlarmDI = -1
                    };
                    Axes.Add(newAxis);
                }
            }
            else if (newCount < Axes.Count)
            {
                // 减少轴：移除末尾的
                int removeCount = Axes.Count - newCount;
                Axes.RemoveRange(newCount, removeCount);
            }
            
            AxisCount = newCount;
            Save(); // 立即保存更新
        }

        public static AxisSetting GetAxisByIndex(int index)
        {
            return Axes.FirstOrDefault(a => a.AxisIndex == index);
        }

       
    }
}
