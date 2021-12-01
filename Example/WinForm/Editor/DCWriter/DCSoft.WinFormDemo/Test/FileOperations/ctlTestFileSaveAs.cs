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
    public partial class ctlTestFileSaveAs : UserControl
    {
        public ctlTestFileSaveAs()
        {
            InitializeComponent();
        }

        private void tspMenuItemSaveDirectly_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileSave", true, null);
        }

        private void tsapMenuItemSaveSpecifyFile_Click(object sender, EventArgs e)
        {
            // 使用指定文件名调用FileSave命令
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\SaveSpecifyFile.xml");
            myWriterControl.ExecuteCommand("FileSave", false, fileName);
        }

        private void tspMenuItemSaveStream_Click(object sender, EventArgs e)
        {
            // 使用文件流调用FileSave命令
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\SaveSpecifyFile.xml");
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                myWriterControl.ExecuteCommand("FileSave", false, stream);
            }
        }

        private void tspMenuItemSaveWriter_Click(object sender, EventArgs e)
        {
            // 使用文本书写器调用FileSave命令
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\SaveSpecifyFile.xml");
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.Default))
            {
                myWriterControl.ExecuteCommand("FileSave", false, writer);
            }
        }

        private void tspMenuItemSaveRTF_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            // 指定文件名
            fcp.FileName = Path.Combine(Application.StartupPath, "DemoFile\\demo_output.rtf");
            // 指定文件格式
            fcp.Format = "rtf";
            // 调用命令
            myWriterControl.ExecuteCommand("FileSave", false, fcp);
        }

        private void tspMenuItemSaveRTFStream_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            using (FileStream stream = new FileStream(Path.Combine(Application.StartupPath, "DemoFile\\demo_output.rtf"), FileMode.Create, FileAccess.Write))
            {
                // 打开文件流
                fcp.OutputStream = stream;
                // 指定文件格式
                fcp.Format = "rtf";
                // 调用命令
                myWriterControl.ExecuteCommand("FileSave", false, fcp);
            }
        }

        private void tspMenuItemSaveHtml_Click(object sender, EventArgs e)
        {
            // 使用参数调用FileSave命令保存HTML文件
            // 创建参数
            FileSaveCommandParameter fcp = new FileSaveCommandParameter();
            // 设置文本编码格式
            fcp.ContentEncoding = Encoding.Default;
            // 设置文件名
            fcp.FileName = Path.Combine(Application.StartupPath, "DemoFile\\demo_output.htm");
            using (FileStream stream = new FileStream(fcp.FileName, FileMode.Create, FileAccess.Write))
            {
                // 打开文件流
                fcp.OutputStream = stream;
                // 指定文件格式
                fcp.Format = "html";
                // 调用命令
                myWriterControl.ExecuteCommand("FileSave", false, fcp);
            }
        }

        private void tspMenuItemSaveSelection_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\selection.xml");
            object result = myWriterControl.ExecuteCommand("FileSaveSelection", false, fileName);
            MessageBox.Show("操作结果:" + result);
        }

        private void tspMenuItemSavePageImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "*.bmp;*.jpg;*.png|*.bmp;*.jpg;*.png";
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    //myWriterControl.Document.SavePageImageFile(0, dlg.FileName);
                    myWriterControl.SavePageImageFile(0, dlg.FileName);
                }
            }
        }

        private void tspMenuItemSavePDF_Click(object sender, EventArgs e)
        {
            string fileName = myWriterControl.Document.FileName + ".pdf";
            //myWriterControl.Document.Save(myWriterControl.Document.FileName + ".pdf", "pdf");
            using (System.IDisposable back = myWriterControl.DocumentOptions.SaveState())
            {
                myWriterControl.DocumentOptions.ViewOptions.BackgroundTextColor = Color.Transparent;
                //myWriterControl.DocumentOptions.ViewOptions.PrintBackgroundText = false;
                myWriterControl.SaveDocumentToFile( fileName , "pdf");
                //myWriterControl.Document.InvalidateHighlightInfo();
                //myWriterControl.Refresh();
            }
            MessageBox.Show("文件保存到 " + fileName);
            
        }

        private void btnSaveImagePDF_Click(object sender, EventArgs e)
        {
            string fileName = myWriterControl.Document.FileName + ".image.pdf";
            //myWriterControl.Document.Save(myWriterControl.Document.FileName + ".pdf", "pdf");
            using (System.IDisposable back = myWriterControl.DocumentOptions.SaveState())
            {
                myWriterControl.DocumentOptions.ViewOptions.BackgroundTextColor = Color.Transparent;
                //myWriterControl.DocumentOptions.ViewOptions.PrintBackgroundText = false;
                DCSoft.Writer.Serialization.ContentSerializeOptions opts = new DCSoft.Writer.Serialization.ContentSerializeOptions();
                opts.Parameters["ZoomRate"] = "2";
                myWriterControl.Document.SetSerializeOptionsOnce(opts);
                myWriterControl.SaveDocumentToFile(fileName, "image.pdf");
                //myWriterControl.Document.InvalidateHighlightInfo();
                //myWriterControl.Refresh();
            }
            MessageBox.Show("文件保存到 " + fileName);
        }

        private void mFileOpen_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileOpen", true, null);
        }
    }
}
