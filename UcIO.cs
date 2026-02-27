using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KepsHIM
{
    public partial class UcIO : UserControl
    {
        public UcIO()
        {
            InitializeComponent();
           
        }

        /// 根据板卡连接状态，启用/禁用 DO 控件
        private void UpdateDOEnableState()
        {
            bool enable = MotionService.Instance.IsConnected;

            for (int i = 0; i < 48; i++)
            {
               CheckBox chk = this.Controls.Find($"chkDO{i}", true).FirstOrDefault() as CheckBox;
               if (chk != null)
               {
                    chk.Enabled = enable;
               }
            }
        }

        
        /// <summary>
        /// 未连接时统一显示灰色
        /// </summary>
        private void ClearDI()
        {
            for (int i = 0; i < 48; i++)
            {
                Label lbl = this.Controls.Find($"lblDI{i}", true).FirstOrDefault() as Label;
                if (lbl != null)
                {
                    lbl.BackColor = Color.DarkGray;
                }
            }
        }

        private void RefreshDI()
        {
            // 1. 未连接直接不刷新（防止无效调用）
            if (!MotionService.Instance.IsConnected)
                return;

            // 2. 轮询 35 个 DI (0-34)
            for (int i = 0; i < 35; i++)
            {
                uint diValue;

                // 3. 读取单个 DI
                bool ok = MotionService.Instance.GetDI(i, out diValue);

                // 4. 找到对应的 Label
                Label lbl = this.Controls
                    .Find($"lblDI{i}", true)
                    .FirstOrDefault() as Label;

                if (lbl == null)
                    continue;

                // 5. 根据状态显示颜色
                if (ok)
                {
                    lbl.BackColor = diValue == 1
                        ? Color.LimeGreen   // 有信号
                        : Color.Gray;       // 无信号
                }
                else
                {
                    lbl.BackColor = Color.DarkGray; // 读取失败
                }
            }
        }


        private void RefreshAI()
        {
            if (!MotionService.Instance.IsConnected)
            {
                for (int i = 0; i < 2; i++)
                {
                    Label lbl = this.Controls.Find($"lblADI{i}", true).FirstOrDefault() as Label;
                    if (lbl != null)
                        lbl.Text = "----";
                }
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                float value;
                bool ok = MotionService.Instance.GetAD(i, out value);

                Label lbl = this.Controls.Find($"lblADI{i}", true).FirstOrDefault() as Label;
                if (lbl == null)
                    continue;

                lbl.Text = ok ? value.ToString("F3") : "----";
            }
        }

        private void RefreshDA()
        {
            
            float daState0;
            float daState1;
            MotionService.Instance.GetDA(0, out daState0);
            txtDAO0.Text = daState0.ToString("F3");
            MotionService.Instance.GetDA(1, out daState1);
            txtDAO1.Text = daState1.ToString("F3");
        }
        private void chkDO_CheckedChanged(object sender, EventArgs e)
        {
            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡，无法操作！");
                return;
            }

            CheckBox chk = sender as CheckBox;
            if (chk == null)
                return;

            int index = Convert.ToInt32(chk.Tag);

            uint value = chk.Checked ? 1u : 0u;
            MotionService.Instance.SetDO(index, value);
        }


        private void btnSetDA0_Click(object sender, EventArgs e)
        {
            float daValue = float.Parse(txtDAO0.Text);

            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡，无法操作！");
                return;
            }

            MotionService.Instance.SetDA(0, daValue);

        }

        private void btnSetDA1_Click(object sender, EventArgs e)
        {
            float daValue = float.Parse(txtDAO1.Text);

            if (!MotionService.Instance.IsConnected)
            {
                MessageBox.Show("未连接板卡，无法操作！");
                return;
            }

            MotionService.Instance.SetDA(1, daValue);


        }

        private void InitDOControls()
        {
            for (int i = 0; i < 48; i++)
            {
                CheckBox chk = this.Controls.Find($"chkDO{i}", true).FirstOrDefault() as CheckBox;
                if (chk != null)
                {
                    chk.Tag = i;
                    chk.CheckedChanged += chkDO_CheckedChanged;
                }
            }
        }



        private void UcIO_Load(object sender, EventArgs e)
        {
            ///tmrIO.Tick += TmrIO_Tick;    //等价于告诉系统每次执行tmrIO.Tick自动调用这个方法
            ///这是设计器里没有绑定时的做法，实际上是通过代码绑定
            ///等价于UcIO.Designer.cs的‘this.tmrIO.Tick += new System.EventHandler(this.TmrIO_Tick);’
            ///在设计器里双击timer控件事件绑定即可
            InitDOControls();
            tmrIO.Interval = 100;
            tmrIO.Start();

        }
        
        /// 界面关闭时停止刷新 IO
        
        private void UcIO_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                tmrIO.Stop();
            }
        }

        private void tmrIO_Tick(object sender, EventArgs e)
        {
            // 1. 根据连接状态启用/禁用 DO
            UpdateDOEnableState();

            // 2. 未连接，直接返回（不读 IO）
            if (!MotionService.Instance.IsConnected)
            {
                ClearDI();
                return;

            }
            // 3. 已连接才刷新 IO
            RefreshDI();
            RefreshAI();
        }
    }
}
