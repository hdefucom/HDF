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

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlZoom : UserControl
    {
        public ctlZoom()
        {
            InitializeComponent();
        }


        private void ctlZoom_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            //小伍添加的代码：自动加载一个演示文件
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            //代码结束
        }

        private void btnSetZoom_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("Zoom", false, cboZoomRate.Text);
            myWriterControl.Focus();
        }
         
    }
}