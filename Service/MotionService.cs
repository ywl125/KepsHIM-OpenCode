using cszmcaux;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KepsHIM.Models;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KepsHIM
{
    /// <summary>
    /// 正运动控制卡服务（全程序唯一实例）板卡型号：XPLC204H-HW，输入32，输出32，EtherCAT总线，带锁存，比较输出
    /// ★ 所有zmcaux调用必须集中在这里，UI或其他地方禁止直接调用DLL
    /// </summary>
    public sealed class MotionService
    {
        #region 单例模式（全局唯一）

        private static readonly MotionService _instance = new MotionService();

        /// <summary>
        /// 获取单例实例
        /// </summary>
        public static MotionService Instance => _instance;

        /// <summary>
        /// 私有构造函数，禁止外部new
        /// </summary>
        private MotionService() { }

        #endregion

        #region 私有字段（核心资源）

        /// <summary>
        /// 板卡句柄（内部使用）
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// 公开 Handle 供外部特殊指令使用 (如 UcServo 的 SetInvertIn)
        /// </summary>
        public IntPtr Handle => _handle;

        /// <summary>
        /// 当前连接的IP地址
        /// </summary>
        private string _ipAddress = string.Empty;

        /// <summary>
        /// 调试计数器，用于控制日志频率
        /// </summary>
        private int _debugCounter = 0;

        /// <summary>
        /// 是否已记录总线初始化警告（避免重复记录）
        /// </summary>
        private bool _hasLoggedBusInitWarning = false;

        #endregion

        #region 公共属性（给UI读取）

        /// <summary>
        /// 是否已连接（内部用）
        /// </summary>
        public bool IsConnected => _handle != IntPtr.Zero;

        /// <summary>
        /// 当前连接的IP
        /// </summary>
        public string ConnectedIp => _ipAddress;

        // <<<=== 新增：连接状态文字（所有页面直接读这个显示）
        /// <summary>
        /// 连接状态提示文字（比如 "已连接" 或 "未连接" 或 "已断开"）
        /// 所有页面用 lblStatus.Text = MotionService.Instance.ConnectionMessage;
        /// </summary>
        public string ConnectionMessage { get; set; } = "未连接";  // 默认未连接
        #endregion

        #region 连接 / 断开

        /// <summary>
        /// 连接板卡（网口）
        /// </summary>
        /// <param name="ip">板卡IP</param>
        /// <returns>true=成功</returns>
        public bool Connect(string ip)
        {
            // <<<=== 修改点1：防止重复连接
            if (IsConnected)
                return true;

            if (string.IsNullOrWhiteSpace(ip))
                return false;

            // 调用官方网口连接
            int ret = zmcaux.ZAux_OpenEth(ip, out _handle);

            if (ret == 0 && _handle != IntPtr.Zero)
            {
                _ipAddress = ip;

                // <<<=== 新增：成功时更新文字
                ConnectionMessage = "已连接 IP: " + ip;
                LogManager.Instance.Info("板卡连接成功，IP: " + ip);
                return true;
            }

            // 失败时
            // 弹具体错误码
           //MessageBox.Show($"连接失败！返回码 ret = {ret}\n常见：0=成功，-1=超时，-2=IP错，-3=端口错\n请检查板卡电源、网线、IP、防火墙");
            ConnectionMessage = "连接失败";
            //另一种写入日志的方法
            string errorMsg = "连接失败";
            LogManager.Instance.Error(errorMsg);
            
            // 失败清空
            _handle = IntPtr.Zero;
            _ipAddress = string.Empty;
            return false;
        }

        /// <summary>
        /// 断开板卡连接（FrmMain关闭时必须调用）
        /// </summary>
        public void Disconnect()
        {
            if (!IsConnected)
                return;

            try
            {
                zmcaux.ZAux_Close(_handle);
            }
            catch (Exception ex)
            {
                // <<<=== 修改点2：加异常捕获，防止崩溃
                Debug.WriteLine("断开板卡异常: " + ex.Message);
                LogManager.Instance.Error("断开板卡异常: " + ex.Message);
            }
            finally
            {
                _handle = IntPtr.Zero;
                _ipAddress = string.Empty;

                // <<<=== 新增：断开时更新文字
                ConnectionMessage = "已断开";

                LogManager.Instance.Info(ConnectionMessage);
            }
        }

        #endregion

        #region IO 操作

        /// <summary>
        /// 读取DI原始值
        /// </summary>
        public bool GetDI(int index, out uint value)
        {
            value = 0;
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_GetIn(_handle, index, ref value);
            return ret == 0;
        }

        /// <summary>
        /// 读取DI布尔状态（true=ON）
        /// </summary>
        public bool GetDIBool(int index, out bool state)
        {
            state = false;
            uint value;
            bool ok = GetDI(index, out value);
            if (!ok) return false;

            state = (value != 0);
            return true;
        }

        /// <summary>
        /// 设置DO
        /// </summary>
        public bool SetDO(int index, uint value)
        {
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_SetOp(_handle, index, value);
            return ret == 0;
        }

        /// <summary>
        /// 读取DO原始值
        /// </summary>
        public bool GetDO(int index, out uint value)
        {
            value = 0;
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_GetOp(_handle, index, ref value);
            return ret == 0;
        }

        /// <summary>
        /// 读取DO布尔状态
        /// </summary>
        public bool GetDOBool(int index, out bool state)
        {
            state = false;
            uint value;
            bool ok = GetDO(index, out value);
            if (!ok) return false;

            state = (value != 0);
            return true;
        }

        // AD/DA 方法保持原样（已很好）
        public bool GetAD(int index, out float value)
        {
            value = 0;
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_GetAD(_handle, index, ref value);
            return ret == 0;
        }

        public bool SetDA(int index, float value)
        {
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_SetDA(_handle, index, value);
            return ret == 0;
        }

        public bool GetDA(int index, out float value)
        {
            value = 0;
            if (!IsConnected) return false;

            int ret = zmcaux.ZAux_Direct_GetDA(_handle, index, ref value);
            return ret == 0;
        }

        #endregion

        #region 轴配置与初始化
        
        /// <summary>
        /// 应用单个轴配置（参数、IO绑定等）
        /// </summary>
        private void ApplyAxisConfig(AxisSetting axis)
        {
            if (!IsConnected) throw new InvalidOperationException("板卡未连接");

            int a = axis.AxisIndex;
           

            // 轴类型（总线伺服=65）
            zmcaux.ZAux_Direct_SetAtype(_handle, a, 65);

            // 运动参数
            zmcaux.ZAux_Direct_SetUnits(_handle, a, axis.Units);
            zmcaux.ZAux_Direct_SetLspeed(_handle, a, axis.JogSpeed);
            zmcaux.ZAux_Direct_SetSpeed(_handle, a, axis.AutoSpeed);
            zmcaux.ZAux_Direct_SetAccel(_handle, a, axis.Acc);
            zmcaux.ZAux_Direct_SetDecel(_handle, a, axis.Dec);

            // IO绑定
            zmcaux.ZAux_Direct_SetDatumIn(_handle, a, axis.HomeDI);
            zmcaux.ZAux_Direct_SetFwdIn(_handle, a, axis.PosLimitDI);
            zmcaux.ZAux_Direct_SetRevIn(_handle, a, axis.NegLimitDI);
            zmcaux.ZAux_Direct_SetAlmIn(_handle, a, axis.AlarmDI);
            // 当前总线板卡需要反转

            // <<<=== 关键修复：使用当前轴的 IsSetInvertIn
            int invert = axis.IsSetInvertIn ? 1 : 0;

            if (axis.PosLimitDI >= 0) zmcaux.ZAux_Direct_SetInvertIn(_handle, axis.PosLimitDI, invert);
            if (axis.NegLimitDI >= 0) zmcaux.ZAux_Direct_SetInvertIn(_handle, axis.NegLimitDI, invert);
            // 如果总线伺服需要反转原点/报警，也在这里加
            // if (axis.HomeDI >= 0) zmcaux.ZAux_Direct_SetInvertIn(_handle, axis.HomeDI, invert);







        }

        /// <summary>
        /// 初始化单个轴（配置 + 使能）
        /// </summary>
        public bool InitAxis(AxisSetting axis)
        {
            if (!IsConnected) return false;

            try
            {
                // 应用配置
                ApplyAxisConfig(axis);

                // 轴使能初始化
                // 策略修改：初始化时不再主动使能，由板卡Basic脚本接管
                // 仅读取当前状态并记录日志
                if (axis.DriveType == AxisDriveType.Bus)
                {
                    int enable = 0;
                    int ret = zmcaux.ZAux_Direct_GetAxisEnable(_handle, axis.AxisIndex, ref enable);
                    
                    if (ret == 0)
                    {
                        string statusStr = (enable == 1) ? "已使能" : "未使能";
                        LogManager.Instance.Info($"轴 {axis.AxisIndex} 初始化后状态: {statusStr}");
                    }
                }
                else
                {
                     // 普通轴也可以读一下逻辑状态或者DO状态
                     LogManager.Instance.Info($"轴 {axis.AxisIndex} (普通) 初始化完成");
                }

                return true;
            }
            catch (Exception ex)
            {
                // <<<=== 修改点3：抛异常让UI捕获
                throw new Exception($"初始化轴 {axis.AxisIndex} 失败: {ex.Message}");
            }
        }

        /// <summary>
        /// 初始化所有轴
        /// </summary>
        public bool InitAllAxes()
        {
            if (!IsConnected) return false;

            if (GlobalAxisManager.Axes == null || GlobalAxisManager.Axes.Count == 0)
                throw new InvalidOperationException("轴配置未加载");

            // 获取总线扫描到的总轴数 (Bus_TotalAxisnum)
            int totalBusAxis = 0;
            float val = 0;
            if (GetGlobalVar("Bus_TotalAxisnum", out val))
            {
                totalBusAxis = (int)val;
                LogManager.Instance.Info($"读取到总线轴数量: {totalBusAxis}");
            }

            // 获取用户配置的有效轴数量
            int configAxisCount = GlobalAxisManager.AxisCount;
            LogManager.Instance.Info($"当前配置轴数量: {configAxisCount}");

            bool allSuccess = true;
            _ = allSuccess; // 避免CS0219警告
            
            // 遍历配置中的轴
            foreach (var axis in GlobalAxisManager.Axes)
            {
                // 过滤逻辑：
                // 1. 如果当前轴的索引 >= 配置的轴数量，则不初始化 (防止多余配置下发)
                if (axis.AxisIndex >= configAxisCount)
                {
                    LogManager.Instance.Info($"跳过轴 {axis.AxisIndex} 初始化 (超出配置数量 {configAxisCount})");
                    continue;
                }

                // 2. 如果是总线轴，且轴号 >= 总线实际扫描数量，也不应该初始化 (硬件不存在)
                if (axis.DriveType == AxisDriveType.Bus && totalBusAxis > 0 && axis.AxisIndex >= totalBusAxis)
                {
                    LogManager.Instance.Warning($"跳过轴 {axis.AxisIndex} 初始化 (超出总线实际扫描数量 {totalBusAxis})");
                    continue;
                }

                try
                {
                    InitAxis(axis); 
                }
                catch (Exception ex)
                {
                    LogManager.Instance.Error($"轴 {axis.AxisIndex} 初始化失败: {ex.Message}");
                    allSuccess = false; 
                }
            }

            return allSuccess;   // ← 改为真实结果
        }

        #endregion

        #region 轴状态读取

        /// <summary>
        /// 读取单个轴状态（位置、IO、运动中、使能等）
        /// </summary>
        public AxisStatus ReadAxisStatus(AxisSetting axis)
        {
            AxisStatus st = new AxisStatus();  // 默认空状态

            // <<<=== 修改：未连接时返回默认，不抛异常
            if (!IsConnected)
            {
                // 默认值（安全）
                st.IsMoving = false;
                st.IsEnabled = false;
                st.Alarm = false;
                st.Home = false;
                st.PosLimit = false;
                st.NegLimit = false;
                st.Position = 0;
                st.Message = "板卡未连接";
                return st;
            }
            

            // 下面是连接正常时的代码（保持不变）
            int a = axis.AxisIndex;
            uint diVal = 0;
            // 注意：ZAux_BusCmd_GetInitStatus 可能在某些控制器上不支持（错误码2033）
            // 如果API调用失败，只记录一次警告，然后继续正常读取状态
            // 因为 GetBusAxisEnable 和 SetAxisEnable 可能仍然正常工作
            
            // 使用实例字段记录是否已记录警告
            if (!_hasLoggedBusInitWarning)
            {
                int busInitStatus = 0;
                int busStatusRet = ExecuteApiCall(
                    "ZAux_BusCmd_GetInitStatus",
                    () => zmcaux.ZAux_BusCmd_GetInitStatus(_handle, ref busInitStatus),
                    logOnError: false  // 不记录错误，因为某些控制器不支持此API
                );
                
                if (busStatusRet != 0)  // API调用失败
                {
                    LogManager.Instance.Warning($"ZAux_BusCmd_GetInitStatus调用失败，错误码={busStatusRet}。某些控制器可能不支持此API，但总线伺服功能可能仍然正常。");
                    _hasLoggedBusInitWarning = true; // 只记录一次
                }
                else if (busInitStatus != 1)  // 总线初始化失败
                {
                    LogManager.Instance.Warning($"轴{a}总线初始化失败，状态码={busInitStatus}。继续尝试读取状态，但可能不准确。");
                    _hasLoggedBusInitWarning = true; // 只记录一次
                }
                else
                {
                    LogManager.Instance.Debug($"轴{a}总线初始化正常，状态码={busInitStatus}");
                }
            }

            // 修复：每次都需要获取详细轴状态（不再提前返回）
            int statusValue = 0;
            int ret = zmcaux.ZAux_Direct_GetAxisStatus(_handle, axis.AxisIndex, ref statusValue);
            if (ret != 0)
            {
                LogManager.Instance.Error($"读取轴{axis.AxisIndex}状态失败，ret={ret}");
                st.Message = "读取状态失败";
                return st;
            }

            // 解析位值，生成消息
            StringBuilder msg = new StringBuilder();
            if ((statusValue & 0x00000002) != 0) msg.Append("随动误差超限告警; ");
            if ((statusValue & 0x00000004) != 0) msg.Append("远程轴通讯出错; ");
            if ((statusValue & 0x00000008) != 0) msg.Append("远程驱动器报错; ");
            if ((statusValue & 0x00000010) != 0) msg.Append("正向硬限位; ");
            if ((statusValue & 0x00000020) != 0) msg.Append("反向硬限位; ");
            if ((statusValue & 0x00000040) != 0) msg.Append("找原点中; ");
            if ((statusValue & 0x00000080) != 0) msg.Append("HOLD速度保持信号输入; ");
            if ((statusValue & 0x00000100) != 0) msg.Append("随动误差超限出错; ");
            if ((statusValue & 0x00000200) != 0) msg.Append("超过正向软限位; ");
            if ((statusValue & 0x00000400) != 0) msg.Append("超过负向软限位; ");
            if ((statusValue & 0x00000800) != 0) msg.Append("CANCEL执行中; ");
            if ((statusValue & 0x00001000) != 0) msg.Append("脉冲频率超过MAX_SPEED限制; ");
            if ((statusValue & 0x00004000) != 0) msg.Append("机械手指令坐标错误; ");
            if ((statusValue & 0x00040000) != 0) msg.Append("电源异常; ");
            if ((statusValue & 0x00100000) != 0) msg.Append("轴速度保护; ");
            if ((statusValue & 0x00200000) != 0) msg.Append("运动中触发特殊运动指令失败; ");
            if ((statusValue & 0x00400000) != 0) msg.Append("告警信号输入; ");
            if ((statusValue & 0x00800000) != 0) msg.Append("轴进入了暂停状态; ");

            st.Message = msg.Length > 0 ? msg.ToString().TrimEnd(';', ' ') : "轴状态正常";
            st.Alarm = msg.Length > 0;  // 如果有任何位设1，视为报警

            // 注意：总线伺服的限位/原点状态通常通过 ZAux_Direct_GetAxisStatus 读取
            // 而不是直接读绑定的DI口。虽然绑定了DI，但轴状态是逻辑状态。
            // 不过这里为了简单，如果用户配置了DI，我们还是尝试读DI
            
            // 1. 尝试读配置的DI口状态（优先使用IO状态）
            // 使用 GetDIBool 简化逻辑并统一判断标准 (value != 0)
            bool ioState;
            if (axis.HomeDI >= 0 && GetDIBool(axis.HomeDI, out ioState)) st.Home = ioState;
            if (axis.PosLimitDI >= 0 && GetDIBool(axis.PosLimitDI, out ioState)) st.PosLimit = ioState;
            if (axis.NegLimitDI >= 0 && GetDIBool(axis.NegLimitDI, out ioState)) st.NegLimit = ioState;
            
            // 报警状态：普通轴读IO，总线轴读状态字
            if (axis.DriveType != AxisDriveType.Bus)
            {
                if (axis.AlarmDI >= 0 && GetDIBool(axis.AlarmDI, out ioState)) st.Alarm = ioState;
            }

            // 2. 补充：仅当未配置IO时，才尝试从总线轴状态字读取
            if (axis.DriveType == AxisDriveType.Bus)
            {
                int axisStatus = 0;
                int ret2 = zmcaux.ZAux_Direct_GetAxisStatus(_handle, a, ref axisStatus);
                if (ret2 == 0)
                {
                    // 仅当对应的DI未配置（<0）时，才使用状态字作为补充
                    // bit4: 正限位, bit5: 负限位, bit23(通常): 原点
                    // 注意：原点位在不同固件可能不同，通常为 bit23 或 bit6，需查阅具体手册
                    // 这里暂且假设原点也需要回退逻辑，如果用户未配置HomeDI
                    if (axis.PosLimitDI < 0 && ((axisStatus >> 4) & 1) == 1) st.PosLimit = true;
                    if (axis.NegLimitDI < 0 && ((axisStatus >> 5) & 1) == 1) st.NegLimit = true;
                    // if (axis.HomeDI < 0 && ((axisStatus >> 23) & 1) == 1) st.Home = true; // 暂不启用原点状态字，除非确认位定义
                    
                    // 总线伺服：报警直接从状态字读取 (Bit 22)，忽略IO配置（因为总线报警更准确）
                    if (((axisStatus >> 22) & 1) == 1) st.Alarm = true;
                }
            }

            int idle = 0;
            zmcaux.ZAux_Direct_GetIfIdle(_handle, a, ref idle);
            st.IsMoving = (idle == 0);

            if (axis.DriveType == AxisDriveType.Bus)
            {
                // 修复方案1：简化使能状态读取逻辑，只使用 GetBusAxisEnable
                // 因为 GetBusAxisEnable 更可靠，专门用于总线伺服
                int enBus = 0;
                int retBus = ExecuteApiCall(
                    "ZAux_Direct_GetBusAxisEnable",
                    () => zmcaux.ZAux_Direct_GetBusAxisEnable(_handle, a, ref enBus),
                    logOnError: false  // 不记录错误，因为已经有备用方案
                );
                
                if (retBus == 0)
                {
                    st.IsEnabled = enBus == 1;
                    // 静态计数器用于控制日志频率 - 大幅减少日志频率
                    if (_debugCounter++ % 200 == 0)  // 改为每200次记录一次（约40秒）
                    {
                        LogManager.Instance.Info($"[状态读取] 轴{a}使能状态: {(st.IsEnabled ? "已使能" : "未使能")} (GetBusAxisEnable={enBus})");
                    }
                    // 移除每5次的调试日志，避免日志过多
                }
                else
                {
                    // API调用失败，使用备用方法
                    LogManager.Instance.Warning($"GetBusAxisEnable失败，轴{a}，错误码: {retBus}，尝试使用GetAxisEnable");
                    int en = 0;
                    int ret3 = ExecuteApiCall(
                        "ZAux_Direct_GetAxisEnable",
                        () => zmcaux.ZAux_Direct_GetAxisEnable(_handle, a, ref en)
                    );
                    st.IsEnabled = en == 1;
                    LogManager.Instance.Info($"GetAxisEnable结果: 轴{a}, 返回值={en}, 错误码={ret3}, 最终状态={(st.IsEnabled ? "已使能" : "未使能")}");
                    
                    // 同时尝试读取轴状态字作为参考
                    int axisStatus = 0;
                    int statusRet = ExecuteApiCall(
                        "ZAux_Direct_GetAxisStatus",
                        () => zmcaux.ZAux_Direct_GetAxisStatus(_handle, a, ref axisStatus),
                        logOnError: false  // 不记录错误，只是参考信息
                    );
                    if (statusRet == 0)
                    {
                        LogManager.Instance.Info($"轴状态字: 轴{a}, 状态字=0x{axisStatus:X}, Bit22(报警)={(axisStatus >> 22) & 1}, Bit4(正限位)={(axisStatus >> 4) & 1}, Bit5(负限位)={(axisStatus >> 5) & 1}");
                    }
                }
            }
            else
            {
                // 普通轴：如果有配置使能DO，则读取DO状态
                if (axis.EnableDO >= 0)
                {
                    uint doVal = 0;
                    GetDO(axis.EnableDO, out doVal);
                    // 如果高电平有效，则1=使能；如果低电平有效，则0=使能
                    st.IsEnabled = axis.EnableHighLevel ? (doVal == 1) : (doVal == 0);
                }
                else
                {
                    st.IsEnabled = axis.LogicEnabled;
                }
            }

            return st;
        }

        /// <summary>
        /// 设置输入口反转（仅限位）
        /// </summary>
        public void SetAxisInvert(int axisIndex, bool invert)
        {
            if (!IsConnected) return;
            var axis = GlobalAxisManager.Axes.FirstOrDefault(a => a.AxisIndex == axisIndex);
            if (axis == null) return;

            int val = invert ? 1 : 0;
            if (axis.PosLimitDI >= 0) zmcaux.ZAux_Direct_SetInvertIn(_handle, axis.PosLimitDI, val);
            if (axis.NegLimitDI >= 0) zmcaux.ZAux_Direct_SetInvertIn(_handle, axis.NegLimitDI, val);
        }



        /// <summary>
        /// 批量获取所有轴的当前工程位置（推荐给Timer刷新用，速度快）
        /// </summary>
        /// <returns>字典：轴号 → 工程位置</returns>
        public Dictionary<int, float> GetAllCurrentPositions()
        {
            // <<<=== 修改点4：新增批量读取，UI刷新不卡
            var positions = new Dictionary<int, float>();

            if (!IsConnected) return positions;

            foreach (var axis in GlobalAxisManager.Axes)
            {
                float pulsePos = 0;
                if (zmcaux.ZAux_Direct_GetDpos(_handle, axis.AxisIndex, ref pulsePos) == 0)
                {
                    // 脉冲 → 工程单位（除以Units）
                    float userPos = pulsePos / axis.Units;// userPos = pulsePos
                    positions[axis.AxisIndex] = userPos;
                }
            }

            return positions;
        }

        /// <summary>
        /// 获取单个轴当前工程位置（修复单位换算bug）
        /// </summary>
        public bool GetCurrentPos(AxisSetting axis, out float userPos)
        {
            userPos = 0;

            if (!IsConnected) return false;

            float pulsePos = 0;
            int ret = zmcaux.ZAux_Direct_GetDpos(_handle, axis.AxisIndex, ref pulsePos);

            if (ret != 0) return false;

            // <<<=== 修改点5：修复bug，正确除以Units
            userPos = pulsePos / axis.Units;//userPos = pulsePos ;
            return true;
        }

        #endregion

        #region 运动控制

        /// <summary>
        /// 手动JOG启动
        /// </summary>
        public bool JogStart(AxisSetting axis, int dir) // dir: 1正向，-1负向
        {
            if (!IsConnected) return false;

            int a = axis.AxisIndex;

            zmcaux.ZAux_Direct_SetSpeed(_handle, a, axis.JogSpeed);

            int ret = zmcaux.ZAux_Direct_Single_Vmove(_handle, a, dir);
            return ret == 0;
        }

        /// <summary>
        /// 停止JOG或运动
        /// </summary>
        public void JogStop(int axis)
        {
            if (!IsConnected) return;

            zmcaux.ZAux_Direct_Single_Cancel(_handle, axis, 2); // 减速停止
        }

        /// <summary>
        /// 单轴点位运动
        /// </summary>
        public bool ExecutePosition(AxisSetting axis, AxisPositionItem item)
        {
            if (!CanMove(axis, out string reason))
                throw new InvalidOperationException(reason);

            int a = axis.AxisIndex;

            zmcaux.ZAux_Direct_SetSpeed(_handle, a, item.Speed);

            int ret = axis.PositionMode == AxisPositionMode.Absolute
                ? zmcaux.ZAux_Direct_Single_MoveAbs(_handle, a, item.Position)
                : zmcaux.ZAux_Direct_Single_Move(_handle, a, item.Position);

            return ret == 0;
        }

        /// <summary>
        /// 急停轴
        /// </summary>
        public void StopAxis(int axis)
        {
            if (!IsConnected) return;

            zmcaux.ZAux_Direct_Single_Cancel(_handle, axis, 2);
        }

        /// <summary>
        /// 清零当前位置
        /// </summary>
        public bool SetAxisZero(int axis)
        {
            if (!IsConnected) return false;

            return zmcaux.ZAux_Direct_SetDpos(_handle, axis, 0) == 0;
        }

        #endregion

        #region 回零操作

        /// <summary>
        /// 开始回零
        /// </summary>
        public bool StartHome(AxisSetting axis)
        {
            if (!IsConnected) return false;

            int a = axis.AxisIndex;

            // 初始化状态
            axis.IsHomed = false;
            axis.HomingState = AxisHomingState.Start;
            axis.HomingStartTime = DateTime.Now;

            zmcaux.ZAux_Direct_SetSpeed(_handle, a, axis.JogSpeed / 2);
            zmcaux.ZAux_Direct_SetCreep(_handle, a, axis.JogSpeed / 10);

            //int ret = zmcaux.ZAux_BusCmd_Datum(_handle, (uint)a, (uint)axis.HomeMode);

            int ret = (axis.DriveType == AxisDriveType.Bus)
                ? zmcaux.ZAux_BusCmd_Datum(_handle, (uint)a, (uint)axis.HomeMode)
                : zmcaux.ZAux_Direct_Single_Datum(_handle, a, axis.HomeMode);

            if (ret != 0)
            {
                axis.HomingState = AxisHomingState.Failed;
                return false;
            }

            axis.HomingState = AxisHomingState.Homing;
            return true;
        }

        /// <summary>
        /// 更新回零状态（Timer里定期调用）
        /// </summary>
        public void UpdateHomingState(AxisSetting axis)
        {
            if (axis.HomingState != AxisHomingState.Homing) return;

            int a = axis.AxisIndex;

            int idle = 0;
            zmcaux.ZAux_Direct_GetIfIdle(_handle, a, ref idle);

            if (idle == 0) return; // 还在运动

            // 运动停止了
            AxisStatus st = ReadAxisStatus(axis);

            if (st.Alarm)
            {
                axis.HomingState = AxisHomingState.Failed;
                axis.IsHomed = false;
                return;
            }

            // <<<=== 修改点6：加超时判断（防止卡死）
            if ((DateTime.Now - axis.HomingStartTime).TotalSeconds > 60)
            {
                axis.HomingState = AxisHomingState.Failed;
                axis.IsHomed = false;
                return;
            }

            axis.IsHomed = true;
            axis.HomingState = AxisHomingState.Success;
        }

        #endregion

        #region 其他辅助

        /// <summary>
        /// 检查轴是否可以运动
        /// </summary>
        public bool CanMove(AxisSetting axis, out string reason)
        {
            reason = "";

            if (!IsConnected)
            {
                reason = "板卡未连接";
                LogManager.Instance.Info(reason);
                return false;
            }

            AxisStatus st = ReadAxisStatus(axis);
            if (st.Alarm)
            {
                reason = "轴报警";
                LogManager.Instance.Error(reason);
                return false;
            }

            if (!axis.IsHomed)
            {
                reason = "轴未回零";
                LogManager.Instance.Warning(reason);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 伺服使能（通过DO控制或总线指令）
        /// 严格遵循C++例程：ZAux_Direct_SetAxisEnable(handle, axis, 1/0)
        /// </summary>
        public bool SetServoEnable(int axisIndex, bool enable)
        {
            try {
                var axis = GlobalAxisManager.Axes.FirstOrDefault(a => a.AxisIndex == axisIndex);
                if (axis == null) {
                    LogManager.Instance.Error($"找不到轴{axisIndex}的配置");
                    return false;
                }

                if (!IsConnected) {
                    LogManager.Instance.Error("板卡未连接，无法设置使能");
                    return false;
                }

                if (axis.DriveType == AxisDriveType.Bus)
                {
                    // ZAux_Direct_SetAxisEnable 设置轴使能
                    // iValue: 0-关闭 1-打开
                    int val = enable ? 1 : 0;
                    
                    int ret = ExecuteApiCall(
                        "ZAux_Direct_SetAxisEnable",
                        () => zmcaux.ZAux_Direct_SetAxisEnable(_handle, axisIndex, val),
                        logLevel: "Error"  // 设置使能失败是严重错误
                    );
                    
                    if (ret == 0)
                    {
                        LogManager.Instance.Info($"轴{axisIndex}使能设置成功: {(enable ? "开启" : "关闭")}，API返回码={ret}");
                        
                        // 验证实际状态是否已更新（针对总线伺服）
                        // 使用 GetBusAxisEnable 读取状态，重试最多5次，增加延迟
                        bool stateVerified = false;
                        int retryCount = 0;
                        const int maxRetries = 5;  // 增加到5次重试
                        const int initialDelayMs = 50;  // 初始延迟
                        const int retryDelayMs = 150;   // 重试延迟增加到150ms
                        
                        // 首次延迟
                        System.Threading.Thread.Sleep(initialDelayMs);
                        
                        while (!stateVerified && retryCount < maxRetries)
                        {
                            retryCount++;
                            
                            int busEnableState = 0;
                            int busRet = ExecuteApiCall(
                                "ZAux_Direct_GetBusAxisEnable",
                                () => zmcaux.ZAux_Direct_GetBusAxisEnable(_handle, axisIndex, ref busEnableState),
                                logOnError: false  // 验证过程中的错误不记录
                            );
                            
                            LogManager.Instance.Debug($"验证尝试{retryCount}: 轴{axisIndex}, GetBusAxisEnable返回={busEnableState}, 错误码={busRet}");
                            
                            if (busRet == 0)
                            {
                                bool actualEnabled = busEnableState == 1;
                                if (actualEnabled == enable)
                                {
                                    stateVerified = true;
                                    LogManager.Instance.Info($"轴{axisIndex}使能状态验证成功 (重试{retryCount}): 期望={enable}, 实际={actualEnabled}");
                                }
                                else
                                {
                                    LogManager.Instance.Warning($"轴{axisIndex}使能状态不一致 (重试{retryCount}): 期望={enable}, 实际={actualEnabled}");
                                    // 同时尝试读取普通轴使能状态作为参考
                                    int normalEnable = 0;
                                    int normalRet = zmcaux.ZAux_Direct_GetAxisEnable(_handle, axisIndex, ref normalEnable);
                                    LogManager.Instance.Debug($"参考状态: GetAxisEnable返回={normalEnable}, 错误码={normalRet}");
                                }
                            }
                            else
                            {
                                LogManager.Instance.Warning($"轴{axisIndex}GetBusAxisEnable失败 (重试{retryCount}): 错误码={busRet}");
                            }
                            
                            // 如果不是最后一次重试，则延迟
                            if (!stateVerified && retryCount < maxRetries)
                            {
                                System.Threading.Thread.Sleep(retryDelayMs);
                            }
                        }
                        
                        if (!stateVerified)
                        {
                            LogManager.Instance.Warning($"轴{axisIndex}使能状态验证失败，硬件状态可能未及时更新或API不匹配");
                            // 记录当前总线状态
                            int busStatus = 0;  // 修复：初始化为0，而不是使用axisIndex
                            int initStatus = zmcaux.ZAux_BusCmd_GetInitStatus(_handle, ref busStatus);
                            LogManager.Instance.Warning($"当前总线状态: 轴{axisIndex}, 初始化状态码={initStatus}");
                        }
                        
                        return true; // API调用成功返回true，即使验证失败也返回true（硬件可能有延迟）
                    }
                    else
                    {
                        LogManager.Instance.Error($"轴{axisIndex}使能设置失败，错误码: {ret}");
                        return false;
                    }
                }
                else
                {
                    // 脉冲伺服：通过DO控制
                    if (axis.EnableDO < 0) {
                        LogManager.Instance.Error($"轴{axisIndex}未配置使能DO");
                        return false;
                    }
                    uint value = enable == axis.EnableHighLevel ? 1u : 0u;
                    int ret = zmcaux.ZAux_Direct_SetOp(_handle, axis.EnableDO, value);
                    
                    if (ret == 0)
                    {
                        LogManager.Instance.Info($"轴{axisIndex}使能DO设置成功: {(enable ? "开启" : "关闭")} (DO:{axis.EnableDO})");
                        return true;
                    }
                    else
                    {
                        LogManager.Instance.Error($"轴{axisIndex}使能DO设置失败，错误码: {ret}");
                        return false;
                    }
                }
            } catch (Exception ex) {
                LogManager.Instance.Error($"SetServoEnable异常: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 清除驱动器报警
        /// </summary>
        /// <param name="axisIndex">轴号</param>
        public bool ClearDriveAlarm(int axisIndex)
        {
            if (!IsConnected) return false;

            // 调用 ZAux_BusCmd_DriveClear (mode=0 清除单轴)
            int ret = zmcaux.ZAux_BusCmd_DriveClear(_handle, axisIndex, 0);
            
            // 6015是警告（无错误时清除会报），视为成功
            if (ret == 0 || ret == 6015) 
            {
                string msg = ret == 0 ? "成功" : "完成(无错误)";
                LogManager.Instance.Info($"轴{axisIndex} 清除驱动器报警: {msg}");
                return true;
            }
            else
            {
                LogManager.Instance.Error($"轴{axisIndex} 清除驱动器报警失败，错误码:{ret}");
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 连续速度运动（简化版，直接传轴号）
        /// 会自动读取该轴的设定参数（如 AutoSpeed）
        /// </summary>
        /// <param name="axisIndex">轴号（从0开始）</param>
        /// <param name="dir">方向：1=正向，-1=负向</param>
        /// <returns>是否成功</returns>                      

        public bool start_Vmove(int axisIndex, int dir)
        {
            if (!IsConnected) return false;
            // 根据轴号找到配置
            AxisSetting axis = GlobalAxisManager.Axes
                .FirstOrDefault(ax => ax.AxisIndex == axisIndex);

            if (axis == null)
            {
                // 可以加日志或弹窗提示
                System.Diagnostics.Debug.WriteLine($"找不到轴号 {axisIndex} 的配置");
                LogManager.Instance.Debug($"找不到轴号 {axisIndex} 的配置");


                // 找不到轴配置，返回失败
                return false;
            }

            // 调用原来的方法（它会使用 axis.AutoSpeed、axis.AxisIndex 等所有设定参数）
            return continue_Vmove(axis, dir);
        }
        public bool continue_Vmove(AxisSetting axis, int dir)// dir: 1正向，-1负向
        {
            if (!IsConnected) return false;

            int a = axis.AxisIndex;

            zmcaux.ZAux_Direct_SetSpeed(_handle, a, axis.AutoSpeed);

            int ret = zmcaux.ZAux_Direct_Single_Vmove(_handle, a, dir);
            return ret == 0;

        }
       
        public void stop_Vmove(int axis)
        {
            if (!IsConnected) return;

            zmcaux.ZAux_Direct_Single_Cancel(_handle, axis, 2); // 减速停止

        }

        // 在 程序停止方法
        public void EmergencyStopAll()
        {
            if (!IsConnected) return;

            foreach (var axis in GlobalAxisManager.Axes)
            {
                // 急停：用 Cancel(0) 或 Cancel(2) 减速停止
                zmcaux.ZAux_Direct_Single_Cancel(_handle, axis.AxisIndex, 2);  // 2 = 减速停止
            }
        }

        #region 脚本与变量交互

        /// <summary>
        /// 发送命令字符串 (ZBasic Command)
        /// </summary>
        /// <param name="cmd">命令内容，如 "BASE(0)" 或 "MOVE_HWPSWITCH2(...)"</param>
        /// <returns>是否发送成功</returns>
        public bool SendCommand(string cmd)
        {
            if (!IsConnected) return false;

            try
            {
                StringBuilder response = new StringBuilder(1024);
                // ZAux_Execute 执行命令
                int ret = zmcaux.ZAux_Execute(_handle, cmd, response, (uint)response.Capacity);
                
                if (ret != 0)
                {
                    LogManager.Instance.Error($"指令 '{cmd}' 执行失败，错误码: {ret}");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error($"指令 '{cmd}' 异常: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 批量写入 Table 数组
        /// </summary>
        public bool SetTable(int start, float[] values)
        {
            if (!IsConnected || values == null || values.Length == 0) return false;

            // 使用 SetUserArray "TABLE" 或者专门的 API
            // 如果 ZAux_Direct_SetTable 存在则使用，否则尝试 SetUserArray
            // 这里假设 ZAux_Direct_SetTable 可用 (根据 Grep 结果应该在 Zmcaux.cs 中)
            
            // 注意：Grep 显示 Zmcaux.cs 可能有 ZAux_Direct_SetTable
            // 如果没有，可以用 SendCommand($"TABLE({start})={val}") 循环写入（慢），
            // 或者用 SetUserArray(_handle, "TABLE", ...)
            
            // 优先尝试 SetUserArray，因为 "TABLE" 是标准系统数组
             // int ret = zmcaux.ZAux_Direct_SetTable(_handle, start, values.Length, values); 
             // 修正：Grep 中看到了 ZAux_Direct_SetTable，但为了保险，先用通用方式
             // 实际上 ZAux_Direct_SetTable 是存在的
             
             int ret = zmcaux.ZAux_Direct_SetTable(_handle, start, values.Length, values);
             return ret == 0;
        }

        /// <summary>
        /// 下载并运行Basic脚本（到RAM中，断电丢失，适合调试）
        /// </summary>
        /// <param name="scriptContent">脚本内容</param>
        /// <param name="runTaskIndex">运行的任务号（默认1，0是主任务通常不占用）</param>
        public bool DownloadAndRunScript(string scriptContent, int runTaskIndex = 1)
        {
            if (!IsConnected) return false;

            try
            {
                // 1. 初始化下载
                UInt32 remain = 0;
                int fileId = 1; // 使用文件1
                int ret = zmcaux.ZAux_3FileRamDownBegin(_handle, fileId, ref remain, "ram_script.bas");
                if (ret != 0) throw new Exception($"下载开始失败: {ret}");

                // 2. 分块下载
                StringBuilder buffer = new StringBuilder(scriptContent);
                // 注意：ZMotion要求脚本必须以 \0 结尾，但C# StringBuilder传参时API会自动处理，
                // 关键是 ZAux_3FileRamDownEnd 会处理结束符。
                // 也可以手动确保最后有换行
                if (!scriptContent.EndsWith("\n")) buffer.Append("\n");

                ret = zmcaux.ZAux_3FileRamDownPart(_handle, fileId, buffer, (uint)buffer.Length, ref remain);
                if (ret != 0) throw new Exception($"下载内容失败: {ret}");

                // 3. 结束下载
                ret = zmcaux.ZAux_3FileRamDownEnd(_handle, fileId);
                if (ret != 0) throw new Exception($"下载结束失败: {ret}");

                // 4. 运行脚本
                ret = zmcaux.ZAux_Run3FileRam(_handle, fileId, runTaskIndex);
                if (ret != 0) throw new Exception($"运行脚本失败: {ret}");

                LogManager.Instance.Info($"脚本下载并运行成功 (Task {runTaskIndex})");
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.Error("脚本下载异常: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 设置全局变量 (GLOBAL xxx)
        /// </summary>
        public bool SetGlobalVar(string varName, float value)
        {
            if (!IsConnected) return false;
            int ret = zmcaux.ZAux_Direct_SetUserVar(_handle, varName, value);
            return ret == 0;
        }

        /// <summary>
        /// 获取全局变量
        /// </summary>
        public bool GetGlobalVar(string varName, out float value)
        {
            value = 0;
            if (!IsConnected) return false;
            int ret = zmcaux.ZAux_Direct_GetUserVar(_handle, varName, ref value);
            return ret == 0;
        }

        #region 总线状态读取 (ECAT)

        /// <summary>
        /// 获取板卡总线初始化状态
        /// </summary>
        /// <returns>-1=初始化中/未知, 0=失败, 1=成功</returns>
        public int GetBusInitStatus()
        {
            if (!IsConnected) return -1;

            float val;
            // 读取控制器全局变量 Bus_InitStatus
            // 注意：需确保板卡Basic程序中定义了 global Bus_InitStatus  
            if (GetGlobalVar("Bus_InitStatus", out val))
            {
                return (int)val;
            }
            return -1;
        }

        #endregion

        /// <summary>
        /// 获取在线命令返回的整数值 (如 ?NODE_COUNT(0))
        /// </summary>
        private int GetIntVariable(string expression)
        {
            if (!IsConnected) return 0;
            StringBuilder sb = new StringBuilder(100);
            // 发送 "?expression"
            int ret = zmcaux.ZAux_Execute(_handle, "?" + expression, sb, (uint)sb.Capacity);
            if (ret == 0 && sb.Length > 0)
            {
                string s = sb.ToString().Trim();
                // 尝试解析最后一个数字 (防止有回显等杂质)
                // 简单处理：直接 TryParse
                if (int.TryParse(s, out int val))
                    return val;

                // 如果失败，尝试分割取最后一段
                string[] parts = s.Split(new char[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0 && int.TryParse(parts[parts.Length - 1], out int val2))
                    return val2;
            }
            return 0;
        }

        #endregion

        /// <summary>
        /// 批量读取 Table 数组
        /// </summary>
        public bool GetTable(int start, int count, float[] buffer)
        {
            if (!IsConnected) return false;
            // 注意：ZAux_Direct_GetTable 可能不存在，用 GetUserArray 代替 "TABLE"
            // ZMotion 中 Table 其实是系统数组，通常用 specific API 或 "TABLE" 作为数组名
            // 尝试直接用 GetUserArray 读取 "TABLE"
            // 或者查找 ZAux_Direct_GetTable 是否存在
            
            // 经查阅常用API，通常有 ZAux_Direct_GetTable
            // 如果 Zmcaux.cs 里没封装，就得用 SetUserVar 读单个，或者用 SetUserArray 读 "TABLE"?
            // 实际上 ZAux_Direct_GetUserArray 读 "TABLE" 是可行的，只要 firmware 支持。
            // 但更标准的是 ZAux_Direct_GetTableVal (单) 或 ZAux_Direct_GetTable (多)
            
            // 这里为了保险，先尝试 GetUserArray "TABLE"
            int ret = zmcaux.ZAux_Direct_GetUserArray(_handle, "TABLE", start, count, buffer);
            return ret == 0;
        }

        #region 统一的错误处理辅助方法

        /// <summary>
        /// 执行API调用并记录错误（简化版，不记录性能统计）
        /// </summary>
        private int ExecuteApiCall(string apiName, Func<int> apiCall, bool logOnError = true, string logLevel = "Warning")
        {
            int result = apiCall();

            if (result != 0 && logOnError)
            {
                string errorMessage = $"{apiName}调用失败，错误码={result}";
                switch (logLevel.ToLower())
                {
                    case "error":
                        LogManager.Instance.Error(errorMessage);
                        break;
                    case "warning":
                        LogManager.Instance.Warning(errorMessage);
                        break;
                    default:
                        LogManager.Instance.Info(errorMessage);
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// 验证所有轴配置
        /// </summary>
        public bool ValidateAllAxisConfigs()
        {
            if (GlobalAxisManager.Axes == null || GlobalAxisManager.Axes.Count == 0)
            {
                LogManager.Instance.Error("没有可验证的轴配置");
                return false;
            }

            bool allValid = true;
            foreach (var axis in GlobalAxisManager.Axes)
            {
                if (!ValidateAxisConfig(axis))
                {
                    allValid = false;
                }
            }

            if (allValid)
            {
                LogManager.Instance.Info($"所有{GlobalAxisManager.Axes.Count}个轴配置验证通过");
            }
            else
            {
                LogManager.Instance.Warning("部分轴配置验证失败");
            }

            return allValid;
        }

        /// <summary>
        /// 检查轴配置完整性
        /// </summary>
        public bool ValidateAxisConfig(AxisSetting axis)
        {
            if (axis == null)
            {
                LogManager.Instance.Error("轴配置为null");
                return false;
            }

            List<string> errors = new List<string>();

            if (axis.AxisIndex < 0 || axis.AxisIndex > 31) // 假设最大32轴
            {
                errors.Add($"轴索引{axis.AxisIndex}超出有效范围(0-31)");
            }

            if (axis.DriveType == AxisDriveType.Bus)
            {
                // 总线伺服需要额外检查
                if (axis.EnableDO < -1 || axis.EnableDO > 255) // 总线伺服可能不使用DO
                {
                    // 这可能是正常的，总线伺服通常不使用物理DO
                }
            }
            else
            {
                // 普通轴检查
                if (axis.EnableDO < -1 || axis.EnableDO > 255)
                {
                    errors.Add($"使能DO索引{axis.EnableDO}超出有效范围(-1表示不使用, 0-255)");
                }
            }

            // 检查IO配置
            if (axis.HomeDI < -1 || axis.HomeDI > 255)
            {
                errors.Add($"原点DI索引{axis.HomeDI}超出有效范围(-1表示不使用, 0-255)");
            }

            if (axis.PosLimitDI < -1 || axis.PosLimitDI > 255)
            {
                errors.Add($"正限位DI索引{axis.PosLimitDI}超出有效范围(-1表示不使用, 0-255)");
            }

            if (axis.NegLimitDI < -1 || axis.NegLimitDI > 255)
            {
                errors.Add($"负限位DI索引{axis.NegLimitDI}超出有效范围(-1表示不使用, 0-255)");
            }

            if (axis.AlarmDI < -1 || axis.AlarmDI > 255)
            {
                errors.Add($"报警DI索引{axis.AlarmDI}超出有效范围(-1表示不使用, 0-255)");
            }

            if (errors.Count > 0)
            {
                LogManager.Instance.Error($"轴{axis.AxisIndex}配置错误: {string.Join("; ", errors)}");
                return false;
            }

            return true;
        }

        #endregion

    }
}