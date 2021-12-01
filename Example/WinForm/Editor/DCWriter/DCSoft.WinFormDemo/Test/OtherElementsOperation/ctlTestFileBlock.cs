using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestFileBlock : UserControl
    {
        public ctlTestFileBlock()
        {
            InitializeComponent();
        }

        private void frmTestFileBlock_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EventReadFileContent += new WriterReadFileContentEventHandler(
                myWriterControl_EventReadFileContent);
            //myWriterControl.AppHost.FileSystems["dbfile"] = new EMR.EMRFileSystem();
            string dir = Path.Combine(Application.StartupPath, "DemoFile2");
            if (Directory.Exists(dir))
            {
                foreach (string fileName in Directory.GetFiles(dir, "*.xml"))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = Path.GetFileNameWithoutExtension(fileName);
                    menuItem.Tag = fileName;
                    menuItem.Click += new EventHandler(menuItem_Click);
                    this.btnInsertDemoFile.DropDownItems.Add(menuItem);
                }
            }
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string fileName = ( string ) item.Tag;
            XTextFileBlockElement block = new XTextFileBlockElement();
            block.ContentSource = new FileContentSource();
            block.ContentSource.FileName = fileName;
            block.Text = item.Text;
            myWriterControl.ExecuteCommand("InsertFileBlock", false, block);
        }

        void myWriterControl_EventReadFileContent(object eventSender, WriterReadFileContentEventArgs args)
        {
            if (args.FileSystemName == "dbfile")
            {
                args.ResultBinary = Utils.ReadTemplate(args);
                args.Handled = true;
            }
        }

        private void btnInsertFileBlock_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML,RTF,HTML,TXT文件|*.xml;*.rtf;*.htm;*.html;*.txt";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string fileName = dlg.FileName;
                    string ext = System.IO.Path.GetExtension(fileName);
                    XTextFileBlockElement block = new XTextFileBlockElement();
                    block.ContentSource = new FileContentSource();
                    block.ContentSource.FileName = fileName;
                    block.Text = System.IO.Path.GetFileName(fileName);
                    if (ext != null)
                    {
                        // 根据文件扩展名设置文件内容格式
                        ext = ext.Trim().ToLower();
                        switch (ext)
                        {
                            case ".xml":
                                block.ContentSource.Format = "xml";
                                break;
                            case ".rtf":
                                block.ContentSource.Format = "rtf";
                                break;
                            case ".htm":
                                block.ContentSource.Format = "html";
                                break;
                            case ".html":
                                block.ContentSource.Format = "html";
                                break;
                            case ".txt":
                                block.ContentSource.Format = "text";
                                break;
                        }
                    }
                    myWriterControl.ExecuteCommand("InsertFileBlock", false, block);
                }
            }
        }

        private void btnInsertFileBlock2_Click(object sender, EventArgs e)
        {
            XTextFileBlockElement block = new XTextFileBlockElement();
            block.Text = "插入的文件块";
            block.ContentSource = new FileContentSource();
            block.ContentSource.FileSystemName = "dbfile";
            block.ContentSource.FileName = "0000000016";
            myWriterControl.ExecuteCommand("InsertFileBlock", false, block);
        }
    }
}