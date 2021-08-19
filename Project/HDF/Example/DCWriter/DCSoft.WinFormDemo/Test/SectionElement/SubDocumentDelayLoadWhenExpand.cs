using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.SectionElement
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class SubDocumentDelayLoadWhenExpand : UserControl
    {
        public SubDocumentDelayLoadWhenExpand()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            //myWriterControl.ViewMode = DCSoft.Printing.PageViewMode.Normal;
            myWriterControl.EventReadFileContent += new WriterReadFileContentEventHandler(myWriterControl_EventReadFileContent);
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\延迟加载内容.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }

        }

        /// <summary>
        /// 加载文档内容
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventReadFileContent(object eventSender, WriterReadFileContentEventArgs args)
        {
            if (System.IO.File.Exists(args.FileName))
            {
                byte[] bs = System.IO.File.ReadAllBytes(args.FileName);
                args.ResultBinary = bs;
                args.Handled = true;
                args.SpecifyTitle = System.IO.Path.GetFileNameWithoutExtension(args.FileName);
                 
                //MessageBox.Show("成功的加载文件 " + args.FileName);
            }
        }
         

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.myWriterControl.Document.Body.Elements.Clear();
            this.myWriterControl.DocumentOptions.BehaviorOptions.EnableCollapseSection = true;
            string[] fileNames = System.IO.Directory.GetFiles(System.IO.Path.Combine(Application.StartupPath, "DemoFile2"), "*.xml");
            foreach (string fileName in fileNames)
            {
                XTextSubDocumentElement subDoc = new XTextSubDocumentElement();
                subDoc.FileFormat = "xml";
                subDoc.FileName = fileName;
                subDoc.EnableCollapse = true;
                subDoc.IsCollapsed = true;
                subDoc.DelayLoadWhenExpand = true;
                subDoc.Title = "未加载:" + System.IO.Path.GetFileNameWithoutExtension(fileName);
                myWriterControl.Document.Body.AppendChildElement(subDoc);
            }
            myWriterControl.RefreshDocument();
        }

        /// <summary>
        /// 设置标准的展开收缩图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStandIcon_Click(object sender, EventArgs e)
        {
            myWriterControl.SetDomImage(DCStdImageKey.Expand, null);
            myWriterControl.SetDomImage(DCStdImageKey.Collapse, null);
            //myWriterControl.Invalidate(true);
        }

        /// <summary>
        /// 设置自定义展开收缩图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomIcon_Click(object sender, EventArgs e)
        {
            myWriterControl.SetDomImage(DCStdImageKey.Collapse, ( Bitmap ) this.imageList1.Images[0]);
            myWriterControl.SetDomImage(DCStdImageKey.Expand, ( Bitmap ) this.imageList1.Images[1]);
            //myWriterControl.Invalidate(true);
        }

    }
}