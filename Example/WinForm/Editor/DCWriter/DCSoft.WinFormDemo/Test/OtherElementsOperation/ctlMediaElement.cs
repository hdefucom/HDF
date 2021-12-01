using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlMediaElement : UserControl
    {
        public ctlMediaElement()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }
         
        private void btnInsertMedia_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "媒体文件(*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv)|*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv|所有文件|*.*";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    this.myWriterControl.ExecuteCommand("InsertMediaElement", false, dlg.FileName);
                }
            }
        }

        private void btnInsertMedia2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "媒体文件(*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv)|*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv|所有文件|*.*";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    XTextMediaElement element = new XTextMediaElement();
                    element.FileName = dlg.FileName;
                    element.PlayerUIMode = WindowsMediaPlayerUIMode.none;
                    element.Width = 1000;
                    element.Height = 500;
                    // 不显示标准的多媒体快捷菜单
                    element.EnableMediaContextMenu = false;
                    // 循环播放
                    element.LoopPlay = true;
                    this.myWriterControl.ExecuteCommand("InsertMediaElement", false, element);
                }
            }
        }

        private void btnInsertMedia3_Click(object sender, EventArgs e)
        {
            XTextMediaElement element = new XTextMediaElement();
            element.Width = 1000;
            element.Height = 190;
            element.FileSystemName = "系统声音";
            element.FileName = "警告";
            element.LoopPlay = true;
            this.myWriterControl.ExecuteCommand("InsertMediaElement", false, element);
            // 响应事件来获得音频数据来源
            this.myWriterControl.EventBeforePlayMedia 
                += new WriterBeforePlayMediaEventHandler(myWriterControl_EventBeforePlayMedia); 
        }

        /// <summary>
        /// 响应控件的EventBeforePlayMedia事件。
        /// 开发者可以在此写代码来提供视频音频数据。比如从数据库中读取视频音频数据并保存到本地文件中。
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventBeforePlayMedia(object eventSender, WriterBeforePlayMediaEventArgs args)
        {
            if (args.FileSystemName == "系统声音")
            {
                string localFileName = System.IO.Path.Combine( Application.StartupPath , "Test") ;
                switch (args.FileName)
                {
                    case "提示":
                        localFileName = System.IO.Path.Combine(localFileName, "Windows Ballon.wav");
                        break;
                    case "警告":
                        localFileName = System.IO.Path.Combine(localFileName, "Windows Critical Stop.wav");
                        break;
                    case "错误":
                        localFileName = System.IO.Path.Combine(localFileName, "Windows Error.wav");
                        break;
                    case "关机":
                        localFileName = System.IO.Path.Combine(localFileName, "Windows Shutdown.wav");
                        break;
                    case "登录":
                        localFileName = System.IO.Path.Combine(localFileName, "Windows Logon Sound.wav");
                        break;
                }
                if (System.IO.File.Exists(localFileName))
                {
                    args.TargetFileName = localFileName;
                }
                else
                {
                    args.Cancel = true;
                }
            }
        }
    }
}