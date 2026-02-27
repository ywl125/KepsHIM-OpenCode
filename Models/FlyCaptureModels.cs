using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KepsHIM.Models
{
    public enum ProductStatus
    {
        Pending,        // 刚锁存，等待Cam0
        InspectingCam0, // 已触发Cam0，等待结果
        PassCam0,       // Cam0 OK，等待Cam1
        InspectingCam1, // 已触发Cam1，等待结果
        OK,             // 双相机均OK
        NG,             // 任意环节NG
        Unknown         // 超时或异常
    }

    public class Product
    {
        public int ID { get; set; }
        public float LatchPos { get; set; }
        public DateTime LatchTime { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Pending;
        
        // 标记是否已经安排了对应工位的动作，防止重复触发
        public bool IsCam0Scheduled { get; set; }
        public bool IsCam1Scheduled { get; set; }
        public bool IsNGBlowScheduled { get; set; }
        public bool IsOKBlowScheduled { get; set; }
        public bool IsWasteBlowScheduled { get; set; }

        public Product(int id, float pos)
        {
            ID = id;
            LatchPos = pos;
            LatchTime = DateTime.Now;
        }
    }

    public class Station
    {
        public string Name { get; set; }
        public float Offset { get; set; }
        public float Duration { get; set; }
        public int OutputIndex { get; set; }
        
        // 硬件Table相关 (仅高速通道使用)
        public int TableStartIndex { get; set; }
        public int TableSize { get; set; } = 100;
        public int CurrentWriteIndex { get; set; } = 0;

        // 是否是软件控制通道
        public bool IsSoftwareControl { get; set; } = false;

        public Station(string name, int tableStart)
        {
            Name = name;
            TableStartIndex = tableStart;
        }
    }
}
