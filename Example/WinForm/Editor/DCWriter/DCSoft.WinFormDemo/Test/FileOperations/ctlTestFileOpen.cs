using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestFileOpen : UserControl
    {
        public ctlTestFileOpen()
        {
            InitializeComponent();
        }

        private void tsbFileOpen_Click(object sender, EventArgs e)
        {
            // 直接调用FileOpen命令
            myWriterControl.ExecuteCommand("FileOpen", true, null);
        }

        private void tspBtnbtnOpenSpecifyFile_Click(object sender, EventArgs e)
        {
            // 使用指定文件名调用FileOpen命令
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
        }

        private void tspBtnOpenStream_Click(object sender, EventArgs e)
        {
            // 使用文件流调用FileOpen命令
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, stream);
            }
        }

        private void tspBtnOpenTextReader_Click(object sender, EventArgs e)
        {
            // 使用文本读取器调用FileOpen命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            using (StreamReader reader = new StreamReader(
                fileName,
                Encoding.UTF8,
                true))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, reader);
            }
        }


        private void btnOpenTextReaderDir_Click(object sender, EventArgs e)
        {
            // 使用文本读取器直接打开文件
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8, true))
            {
                myWriterControl.LoadDocument(reader, "xml");
            }
        }

        private void tspBtnOpenRTF_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            // 指定文件名
            fcp.FileName = Path.Combine(Application.StartupPath, "DemoFile\\demo.rtf");
            // 指定文件格式
            fcp.Format = "rtf";
            // 调用命令
            myWriterControl.ExecuteCommand("FileOpen", false, fcp);
        }

        private void tspBtnOpenRTFStream_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令打开RTF文件
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            using (FileStream stream = new FileStream(Path.Combine(Application.StartupPath, "DemoFile\\demo.rtf"), FileMode.Open, FileAccess.Read))
            {
                // 打开文件流
                fcp.InputStream = stream;
                // 指定文件格式
                fcp.Format = "rtf";
                // 调用命令
                myWriterControl.ExecuteCommand("FileOpen", false, fcp);
            }
        }

        private void tspBtnOpenHtml_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令打开HTML文件
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            // 设置文本编码格式
            fcp.ContentEncoding = Encoding.Default;
            // 设置文件名
            fcp.FileName = Path.Combine(Application.StartupPath, "DemoFile\\demo.htm");
            using (FileStream stream = new FileStream(fcp.FileName, FileMode.Open, FileAccess.Read))
            {
                // 打开文件流
                fcp.InputStream = stream;
                // 指定文件格式
                fcp.Format = "html";
                // 调用命令
                myWriterControl.ExecuteCommand("FileOpen", false, fcp);
            }
        }

        private void tsBtnOpenURL_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令打开指定URL的HTML文件
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            // 设置文本编码格式
            fcp.ContentEncoding = Encoding.Default;
            // 设置文件名
            fcp.FileName = "http://cnblogs.com/xdesigner";
            // 指定文件格式
            fcp.Format = "html";
            // 调用命令
            myWriterControl.ExecuteCommand("FileOpen", false, fcp);
        }

        private void tspBbtnLoadReaderText_Click(object sender, EventArgs e)
        {
            // 使用文本读取器直接打开文件
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            using (StreamReader reader = new StreamReader(fileName, Encoding.UTF8, true))
            {
                myWriterControl.LoadDocument(reader, "xml");
            }
        }
    }
}
