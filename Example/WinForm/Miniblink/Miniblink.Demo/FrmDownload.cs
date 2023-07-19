using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Miniblink;

namespace Miniblink.Demo
{
    public partial class FrmDownload : MiniblinkForm
    {
        public FrmDownload()
        {
            InitializeComponent();
        }

        private void FrmDownload_Load(object sender, EventArgs e)
        {
            Text = "";
            View.Download += FrmDownload_Download;
            View.LoadUri("https://im.qq.com/pcqq/");
        }

        private void FrmDownload_Download(object sender, DownloadEventArgs e)
        {
            e.Progress += DownloadProgress;
            e.Finish += DownloadFinish;
            //将文件保存到指定的位置
            //如果不设置，下载的内容只会存在内存里，通过Progress事件可以获取
            e.FilePath = Guid.NewGuid() + ".exe";
            MessageBox.Show("左上角显示下载进度");
        }

        private void DownloadFinish(object sender, DownloadFinishEventArgs e)
        {
            MessageBox.Show("下载完成");
            Text = "";
        }

        private void DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            Text = $"下载中...{(int)(e.Received * 1.0 / e.Total * 100)}%";
        }
    }
}
