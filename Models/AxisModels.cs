using System;
using System.Collections.Generic;

namespace KepsHIM.Models
{
    #region 轴相关枚举

    /// <summary>
    /// 轴驱动类型
    /// </summary>
    public enum AxisDriveType
    {
        Ordinary,  // 普通轴（脉冲/通用）
        Bus        // 总线轴（EtherCAT等）
    }

    /// <summary>
    /// 轴回零状态
    /// </summary>
    public enum AxisHomingState
    {
        None = 0,    // 未回零 / 无状态
        Start = 1,   // 下发回零指令
        Homing = 2,  // 回零进行中
        Success = 3, // 回零完成
        Failed = 4,   // 回零失败
        Aborted = 5   // 用户中断
    }

    /// <summary>
    /// 定位模式
    /// </summary>
    public enum AxisPositionMode
    {
        Absolute, // 绝对定位
        Relative  // 相对定位
    }

    #endregion

    #region 轴数据模型

    /// <summary>
    /// 轴配置参数（保存到文件）
    /// </summary>
    public class AxisSetting
    {
        // 轴基本信息
        public int AxisIndex { get; set; }
        public AxisDriveType DriveType { get; set; } = AxisDriveType.Bus;

        // 使能相关
        public int EnableDO { get; set; } = -1;
        public bool EnableHighLevel { get; set; } = true;

        // 定位模式
        public AxisPositionMode PositionMode { get; set; } = AxisPositionMode.Absolute;

        // 脉冲当量
        public float Units { get; set; } = 100;

        // 速度参数
        public float JogSpeed { get; set; } = 10;
        public float AutoSpeed { get; set; } = 50;
        public float Acc { get; set; } = 100;
        public float Dec { get; set; } = 100;

        // 限位、原点和报警 IO
        public int HomeDI { get; set; } = -1;
        public int PosLimitDI { get; set; } = -1;
        public int NegLimitDI { get; set; } = -1;
        public int AlarmDI { get; set; } = -1;

        // 报警相关
        public bool AlarmMasked { get; set; } = false;
        public bool LastAlarmState { get; set; } = false;
        public bool HasAlarm { get; set; } = false;

        // 回零参数
        public bool IsHomed { get; set; } = false;
        public float HomePos { get; set; } = 0;
        public float HomeSpeed { get; set; } = 100;
        public float HomeCreep { get; set; } = 10;
        public int HomeDir { get; set; } = -1;
        public AxisHomingState HomingState { get; set; } = AxisHomingState.None;
        public DateTime HomingStartTime { get; set; } = DateTime.MinValue;
        public int HomeMode { get; set; } = 24;

        // 位置参数
        public float PickPos { get; set; } = 0;
        public float PlacePos { get; set; } = 0;
        public float WaitPos { get; set; } = 0;

        // 逻辑状态
        public bool LogicEnabled { get; set; } = false;
        public bool IsBus { get; set; } = false;
        public bool IsSetInvertIn { get; set; } = false;

        // 定位表
        public List<AxisPositionItem> Positions { get; set; } = new List<AxisPositionItem>();

        // 当前状态
        public AxisStatus CurrentStatus { get; } = new AxisStatus();
    }

    /// <summary>
    /// 轴实时状态（只读给UI）
    /// </summary>
    public class AxisStatus
    {
        public bool IsEnabled { get; set; }
        public bool IsMoving { get; set; } = false;
        public bool Home { get; set; } = false;
        public bool PosLimit { get; set; } = false;
        public bool NegLimit { get; set; } = false;
        public bool Alarm { get; set; } = false;
        public float Position { get; set; } = 0;
        public string Message { get; set; } = "";
    }

    /// <summary>
    /// 位置点数据
    /// </summary>
    public class AxisPositionItem
    {
        public string Name { get; set; }
        public float Position { get; set; }
        public float Speed { get; set; }
    }

    #endregion
}
