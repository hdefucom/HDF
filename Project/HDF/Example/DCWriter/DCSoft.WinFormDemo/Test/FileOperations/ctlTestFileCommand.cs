using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Commands;
using System.IO;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestFileCommand : UserControl
    {
        public ctlTestFileCommand()
        {
            InitializeComponent();
        }


        private void myWriterControl_StatusTextChanged(object sender, EventArgs e)
        {
            this.Text = myWriterControl.StatusText;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileNew", true, null);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // 直接调用FileOpen命令
            myWriterControl.ExecuteCommand("FileOpen", true, null);
        }

        private void btnOpenSpecifyFile_Click(object sender, EventArgs e)
        {
            // 使用指定文件名调用FileOpen命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            myWriterControl.ExecuteCommand("FileOpen", false, fileName);
        }

        private void btnOpenStream_Click(object sender, EventArgs e)
        {
            // 使用文件流调用FileOpen命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            using (FileStream stream = new FileStream(
                fileName,
                FileMode.Open,
                FileAccess.Read))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, stream);
            }
        }

        private void btnOpenTextReader_Click(object sender, EventArgs e)
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
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo.xml");
            //fileName = @"D:\金山快盘\项目文件\合肥盈华软件\xml.txt.xml";
            using (StreamReader reader = new StreamReader(
                fileName,
                Encoding.UTF8,
                true))
            {
                myWriterControl.LoadDocument(reader, "xml");
            }
        }

        private void btnOpenRTF_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            // 指定文件名
            fcp.FileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\demo.rtf");
            // 指定文件格式
            fcp.Format = "rtf";
            // 调用命令
            myWriterControl.ExecuteCommand("FileOpen", false, fcp);
        }

        private void btnOpenRTFStream_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令打开RTF文件
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            using (FileStream stream = new FileStream(
                Path.Combine(Application.StartupPath, "DemoFile\\demo.rtf"),
                FileMode.Open,
                FileAccess.Read))
            {
                // 打开文件流
                fcp.InputStream = stream;
                // 指定文件格式
                fcp.Format = "rtf";
                // 调用命令
                myWriterControl.ExecuteCommand("FileOpen", false, fcp);
            }
        }

        private void btnOpenHtml_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileOpen命令打开HTML文件
            // 创建参数
            FileOpenCommandParameter fcp = new FileOpenCommandParameter();
            // 设置文本编码格式
            fcp.ContentEncoding = Encoding.Default;
            // 设置文件名
            fcp.FileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\demo.htm");
            using (FileStream stream = new FileStream(
                fcp.FileName,
                FileMode.Open,
                FileAccess.Read))
            {
                // 打开文件流
                fcp.InputStream = stream;
                // 指定文件格式
                fcp.Format = "html";
                // 调用命令
                myWriterControl.ExecuteCommand("FileOpen", false, fcp);
            }
        }


        private void btnOpenURL_Click(object sender, EventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string fileName = "d:\\a.xml";// 某个临时文件名
            //myWriterControl.ExecuteCommand("FileSave", false, fileName);
            //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            //doc.PreserveWhitespace = true;
            //doc.Load(fileName);
            //// 其他处理
            //string xmlStr = doc.InnerXml;
            //// 将xmlStr的值保存到数据库中。
            //doc.Save("d:\\b.xml");


            // 直接调用FileSave命令
            myWriterControl.ExecuteCommand("FileSave", true, null);
        }

        private void btnSaveSpecifyFile_Click(object sender, EventArgs e)
        {
            // 使用指定文件名调用FileSave命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo_Output.xml");
            myWriterControl.ExecuteCommand("FileSave", false, fileName);
        }

        private void btnSaveStream_Click(object sender, EventArgs e)
        {
            // 使用文件流调用FileSave命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo_Output.xml");
            using (FileStream stream = new FileStream(
                fileName,
                FileMode.Create,
                FileAccess.Write))
            {
                myWriterControl.ExecuteCommand("FileSave", false, stream);
            }
        }

        private void btnSaveWriter_Click(object sender, EventArgs e)
        {
            // 使用文本书写器调用FileSave命令
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\FormViewModeDemo_Output.xml");
            using (StreamWriter writer = new StreamWriter(
                fileName,
                false,
                Encoding.Default))
            {
                myWriterControl.ExecuteCommand("FileSave", false, writer);
            }
        }

        private void btnSaveRTF_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            // 指定文件名
            fcp.FileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\demo_output.rtf");
            // 指定文件格式
            fcp.Format = "rtf";
            // 调用命令
            myWriterControl.ExecuteCommand("FileSave", false, fcp);
        }

        private void btnSaveRTFStream_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            using (FileStream stream = new FileStream(
                Path.Combine(Application.StartupPath, "DemoFile\\demo_output.rtf"),
                FileMode.Create,
                FileAccess.Write))
            {
                // 打开文件流
                fcp.OutputStream = stream;
                // 指定文件格式
                fcp.Format = "rtf";
                // 调用命令
                myWriterControl.ExecuteCommand("FileSave", false, fcp);
            }
        }

        private void btnSaveHtml_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令保存HTML文件
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            // 设置文本编码格式
            fcp.ContentEncoding = Encoding.Default;
            // 设置文件名
            fcp.FileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\demo_output.htm");
            using (FileStream stream = new FileStream(
                fcp.FileName,
                FileMode.Create,
                FileAccess.Write))
            {
                // 打开文件流
                fcp.OutputStream = stream;
                // 指定文件格式
                fcp.Format = "html";
                // 调用命令
                myWriterControl.ExecuteCommand("FileSave", false, fcp);
            }
        }

        private void btnViewSource_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("ViewXMLSource", true, null);
        }

        private void btnSaveSelection_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(
                Application.StartupPath,
                "DemoFile\\selection.xml");
            object result = myWriterControl.ExecuteCommand(
                "FileSaveSelection",
                false,
                fileName);
            MessageBox.Show("操作结果:" + result);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DCSoft.Printing.PrintResult result = (DCSoft.Printing.PrintResult)myWriterControl.ExecuteCommand(
                "FilePrint", true, null);
            if (result != null)
            {
                result.ShowDialog(this);
            }
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myWriterControl.LoadDocument(dlg.FileName, "xml");
                }
            }
        }

        private void btnFilePrintPreview_Click(object sender, EventArgs e)
        {
            FilePrintPreviewCommandParameter cp = new FilePrintPreviewCommandParameter();
            cp.ZoomRate = PrintPreviewZoomRate.Zoom100;
            cp.Maximized = true;
            PrintResult result =( PrintResult ) myWriterControl.ExecuteCommand("FilePrintPreview", true, cp);
            if (result != null)
            {
                result.ShowDialog(this);
            }
        }

        private void btnPageIndexFix_Click(object sender, EventArgs e)
        {
            myWriterControl.Document.PageIndexfix = 10;
            myWriterControl.Invalidate();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.FilePrintCurrentPage, true, null);
        }

        private void btnFilePrintWidthManualDuplex_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.FilePrintWithManualDuplex, true, null);
        }

        private void btnPrintJiShu_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            for (int iCount = 0; iCount < this.myWriterControl.Pages.Count; iCount += 2)
            {
                if (str.Length > 0)
                {
                    str.Append(",");
                }
                str.Append(iCount.ToString());
            }
            myWriterControl.PrintDocumentExt(false , str.ToString());

            //FilePrintCommandParameter p = new FilePrintCommandParameter();
            //for (int iCount = 0; iCount < this.myWriterControl.Document.Pages.Count; iCount += 2)
            //{
            //    p.AddSpecifyPageIndex(iCount);
            //}
            //myWriterControl.ExecuteCommand(StandardCommandNames.FilePrint, true, p);
        }

        private void btnSetJumpPosition_Click(object sender, EventArgs e)
        {
            if (myWriterControl.LastPrintPosition > 0 )
            {
                myWriterControl.EnableJumpPrint = true;
                myWriterControl.JumpPrintPosition = myWriterControl.LastPrintPosition;
                myWriterControl.JumpPrintEndPosition = -1;
                myWriterControl.ScrollToViewPosition(myWriterControl.LastPrintPosition);
            }
        }

        private void btnCancelJumpPrint_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.JumpPrintMode, false, false);
        }

        private void btnSavePageImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "*.bmp;*.jpg;*.png|*.bmp;*.jpg;*.png";
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    myWriterControl.Document.SavePageImageFile(0, dlg.FileName);
                }
            }
        }

        private void btnSavePDF_Click(object sender, EventArgs e)
        {
            myWriterControl.Document.Save(myWriterControl.Document.FileName + ".pdf", "pdf");

            //string fileName = this.myWriterControl.Document.FileName;
            //if (System.IO.File.Exists(fileName))
            //{
            //    XTextDocument doc = new XTextDocument();
            //    doc.Load(fileName , null );
            //    //doc.SavePageImageFile(0 , fileName + ".jpg");
            //    doc.Save(fileName + ".pdf", "pdf");
            //}
        }
    }
}