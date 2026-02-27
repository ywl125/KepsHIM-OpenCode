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
    public partial class UcParam : UserControl
    {
        public string txtIpParam;
       
        public UcParam()
        {
            InitializeComponent();
            
            // 初始化轴数量显示
            if (GlobalAxisManager.Axes != null)
            {
                numAxisNumber.Value = GlobalAxisManager.Axes.Count;
            }
            
            // 绑定事件
            numAxisNumber.ValueChanged += NumAxisNumber_ValueChanged;

            // 从配置文件加载 IP
            string savedIp = Properties.Settings.Default.LastIp;
            if (!string.IsNullOrEmpty(savedIp))
            {
                txtIpSet.Text = savedIp;
            }
            else
            {
                // 默认 IP
                txtIpSet.Text = "192.168.0.11";
                Properties.Settings.Default.LastIp = txtIpSet.Text;
                Properties.Settings.Default.Save();
            }
            
            txtIpParam = txtIpSet.Text;
        }

        private void txtIpSet_Leave(object sender, EventArgs e)
        {
            //将IP地址保存到程序设置
            Properties.Settings.Default.LastIp = txtIpSet.Text.Trim();
            Properties.Settings.Default.Save();

        }

        private void NumAxisNumber_ValueChanged(object sender, EventArgs e)
        {
            int newCount = (int)numAxisNumber.Value;
            GlobalAxisManager.UpdateAxisCount(newCount);
        }
    }
}
