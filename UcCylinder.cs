using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KepsHIM
{
    public partial class UcCylinder : UserControl
    {
        // 气缸输出口定义
        private const int CYLINDER1_DO = 1;   // 输出口2：气缸1 (DO2, 索引1)
        private const int CYLINDER2_DO = 2;   // 输出口3：气缸2 (DO3, 索引2)

        public UcCylinder()
        {
            InitializeComponent();
            
            // 绑定 VisibleChanged 事件
            this.VisibleChanged += UcCylinder_VisibleChanged;
            
            // 立即启动定时器并刷新状态（如果已显示）
            if (this.Visible && tmrCylinder != null)
            {
                tmrCylinder.Start();
                RefreshCylinderStatus();
            }
        }

        // 定时器刷新状态
        private void tmrCylinder_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine($"[Cylinder] tmrCylinder_Tick called at {DateTime.Now:HH:mm:ss.fff}");
            RefreshCylinderStatus();
        }

        private void RefreshCylinderStatus()
        {
            Debug.WriteLine($"[Cylinder] RefreshCylinderStatus called at {DateTime.Now:HH:mm:ss.fff}");
            
            // 更新连接状态
            if (!MotionService.Instance.IsConnected)
            {
                lblStatus.Text = "状态: 未连接板卡";
                lblStatus.ForeColor = Color.Yellow;
                lblCylinder1State.Text = "气缸1状态: 未知";
                lblCylinder2State.Text = "气缸2状态: 未知";

                // 禁用所有按钮
                btnCylinder1On.Enabled = false;
                btnCylinder1Off.Enabled = false;
                btnCylinder2On.Enabled = false;
                btnCylinder2Off.Enabled = false;
                btnAllStop.Enabled = false;
                return;
            }

            lblStatus.Text = "状态: 已连接";
            lblStatus.ForeColor = Color.LimeGreen;

            // 启用所有按钮
            btnCylinder1On.Enabled = true;
            btnCylinder1Off.Enabled = true;
            btnCylinder2On.Enabled = true;
            btnCylinder2Off.Enabled = true;
            btnAllStop.Enabled = true;

            // 读取气缸1状态
            bool cylinder1State = false;
            if (MotionService.Instance.GetDOBool(CYLINDER1_DO, out cylinder1State))
            {
                Debug.WriteLine($"[Cylinder] Cylinder1 DO{CYLINDER1_DO} state: {cylinder1State}");
                lblCylinder1State.Text = $"气缸1状态: {(cylinder1State ? "伸出" : "缩回")}";
                lblCylinder1State.ForeColor = cylinder1State ? Color.LimeGreen : Color.LightGray;
            }
            else
            {
                Debug.WriteLine($"[Cylinder] Failed to read Cylinder1 DO{CYLINDER1_DO}");
            }

            // 读取气缸2状态
            bool cylinder2State = false;
            if (MotionService.Instance.GetDOBool(CYLINDER2_DO, out cylinder2State))
            {
                Debug.WriteLine($"[Cylinder] Cylinder2 DO{CYLINDER2_DO} state: {cylinder2State}");
                lblCylinder2State.Text = $"气缸2状态: {(cylinder2State ? "伸出" : "缩回")}";
                lblCylinder2State.ForeColor = cylinder2State ? Color.LimeGreen : Color.LightGray;
            }
            else
            {
                Debug.WriteLine($"[Cylinder] Failed to read Cylinder2 DO{CYLINDER2_DO}");
            }
        }

        // 气缸1伸出
        private void btnCylinder1On_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                //MessageBox.Show("请先连接板卡");
                return;
            }

            bool success = MotionService.Instance.SetDO(CYLINDER1_DO, 1);
            if (success)
            {
                // 短暂延时后刷新状态
                System.Threading.Thread.Sleep(50);
                RefreshCylinderStatus();
            }
            else
            {
                MessageBox.Show("气缸1伸出控制失败");
            }
        }

        // 气缸1缩回
        private void btnCylinder1Off_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("请先连接板卡");
                return;
            }

            bool success = MotionService.Instance.SetDO(CYLINDER1_DO, 0);
            if (success)
            {
                System.Threading.Thread.Sleep(50);
                RefreshCylinderStatus();
            }
            else
            {
                MessageBox.Show("气缸1缩回控制失败");
            }
        }

        // 气缸2伸出
        private void btnCylinder2On_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("请先连接板卡");
                return;
            }

            bool success = MotionService.Instance.SetDO(CYLINDER2_DO, 1);
            if (success)
            {
                System.Threading.Thread.Sleep(50);
                RefreshCylinderStatus();
            }
            else
            {
                MessageBox.Show("气缸2伸出控制失败");
            }
        }

        // 气缸2缩回
        private void btnCylinder2Off_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("请先连接板卡");
                return;
            }

            bool success = MotionService.Instance.SetDO(CYLINDER2_DO, 0);
            if (success)
            {
                System.Threading.Thread.Sleep(50);
                RefreshCylinderStatus();
            }
            else
            {
                MessageBox.Show("气缸2缩回控制失败");
            }
        }

        // 全部停止
        private void btnAllStop_Click(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("请先连接板卡");
                return;
            }

            bool success1 = MotionService.Instance.SetDO(CYLINDER1_DO, 0);
            bool success2 = MotionService.Instance.SetDO(CYLINDER2_DO, 0);

            if (success1 && success2)
            {
                System.Threading.Thread.Sleep(50);
                RefreshCylinderStatus();
            }
            else
            {
                MessageBox.Show("停止控制失败");
            }
        }

        // 界面显示/隐藏时控制定时器
        private void UcCylinder_VisibleChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"[Cylinder] VisibleChanged: Visible={this.Visible} at {DateTime.Now:HH:mm:ss.fff}");
            
            if (this.Visible)
            {
                tmrCylinder.Start();  // 界面显示时启动定时器
                RefreshCylinderStatus(); // 立即刷新一次
            }
            else
            {
                tmrCylinder.Stop();   // 界面隐藏时停止定时器
            }
        }

       
    }
}
