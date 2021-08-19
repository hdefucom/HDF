using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DCSoft.Printing;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestPrintPreview : UserControl
    {
        public ctlTestPrintPreview()
        {
            InitializeComponent();
        }

        private void btnLoadDocument_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            myPrintPreviewControl.ClearDocument();
            AddDocument("DCSoft.Writer.WinFormDemo.Test.OldXML.xml", "OldXml");
            myPrintPreviewControl.InvalidatePreview();
            this.Cursor = Cursors.Default;
        }


        private void btnLoadMulDocument_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            myPrintPreviewControl.ClearDocument();
            AddDocument("DCSoft.Writer.WinFormDemo.Test.OldXML.xml", "OldXml");
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.FormViewModeDemo.xml", "xml");
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.demo.xml", "xml");
            System.Windows.Forms.MessageBox.Show("加载了 " + myPrintPreviewControl.TextDocuments.Count + " 个文档,准备显示.");
            myPrintPreviewControl.InvalidatePreview();
            this.Cursor = Cursors.Default;
        }


        private void btnLoadDocumentsMege_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            myPrintPreviewControl.ClearDocument();
            AddDocument("DCSoft.Writer.WinFormDemo.Test.OldXML.xml", "OldXml");
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.FormViewModeDemo.xml", "xml");
            
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.demo.xml", "xml");
            System.Windows.Forms.MessageBox.Show("加载了 " + myPrintPreviewControl.TextDocuments.Count + " 个文档,准备显示.");
            myPrintPreviewControl.InvalidatePreviewMegeDocument();
            this.Cursor = Cursors.Default;
        }


        private void btnLoadMixed_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            myPrintPreviewControl.ClearDocument();
            AddDocument("DCSoft.Writer.WinFormDemo.Test.OldXML.xml", "OldXml");
            string rootPath = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\病程记录内容");
            string fileName = Path.Combine(rootPath, "模板-病程记录.xml");
            if (File.Exists(fileName))
            {
                XTextDocument document = new XTextDocument();
                document.Load(fileName, "xml");
                foreach (string fn in Directory.GetFiles(rootPath, "病程记录*.xml"))
                {
                    document.LoadUseAppendModeFromFileName(fn, "xml");
                }
                myPrintPreviewControl.AddDocument(document);
            }
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.FormViewModeDemo.xml", "xml");
            AddDocument("DCSoft.Writer.WinFormDemo.DemoFile.demo.xml", "xml");
            System.Windows.Forms.MessageBox.Show("加载了 " + myPrintPreviewControl.TextDocuments.Count + " 个文档,准备显示.");
            myPrintPreviewControl.InvalidatePreview();
            this.Cursor = Cursors.Default;
        }
         


        private void AddDocument(string resName, string format)
        {
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resName);
            if (stream != null)
            {
                myPrintPreviewControl.AddDocument(stream, format);
                stream.Close();
            }
        }

        private void myPrintPreviewControl_PrintCompleted(object sender, EventArgs e)
        {
            XPrintDocument doc = (XPrintDocument)myPrintPreviewControl.Document;
            PrintResult result = doc.CurrentPrintResult;
            result.ShowDialog(this);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "xml文件|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    // 清空控件内容
                    myPrintPreviewControl.ClearDocument();
                    // 添加文档
                    myPrintPreviewControl.AddDocumentByUrl(dlg.FileName, "xml");
                    if (this.btnSetScript.Checked)
                    {
                        // 设置脚本 
                        string scriptText = @"
sub Document_EventBeginPrint( eventSender as Object, args as DCSoft.Writer.WriterPrintEventEventArgs )
   msgbox(#开始打印了:# & args.PrintAction.ToString() )
end sub

sub Document_EventPrintQueryPageSettings( eventSender as Object , args as DCSoft.Writer.WriterPrintQueryPageSettingsEventArgs )
   msgbox(#开始查询页面设置,页码：# & args.PageIndex )
end sub

sub Document_EventPrintPage( eventSender as Object , args as DCSoft.Writer.WriterPrintPageEventEventArgs )
   msgbox(#开始打印第# & args.PageIndex & #页的内容#)
end sub

sub Document_EventEndPrint( eventSender as Object , args as DCSoft.Writer.WriterPrintEventEventArgs )
   msgbox(#打印结束#)
end sub";
                        scriptText = scriptText.Replace('#', '"');
                        myPrintPreviewControl.TextDocument.ScriptText = scriptText;
                    }
                    // 刷新视图
                    myPrintPreviewControl.InvalidatePreview();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnShowToolbar_Click(object sender, EventArgs e)
        {
            myPrintPreviewControl.ToolbarVisible = btnShowToolbar.Checked;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            myPrintPreviewControl.ShowAbout();
        }

        private void btnGetLastPrintPosition_Click(object sender, EventArgs e)
        {
            MessageBox.Show(myPrintPreviewControl.LastPrintPosition.ToString());
        }

        private void btnSetJumpPrintPosition_Click(object sender, EventArgs e)
        {
            string txt = DCSoft.WinForms.dlgInputBox.InputBox(this, "请输入高度", null, myPrintPreviewControl.LastPrintPosition.ToString());
            if (string.IsNullOrEmpty(txt) == false)
            {
                myPrintPreviewControl.JumpPrintPosition = Convert.ToInt32(txt);
            }
        }

        private void btnPrintSpecifyPages_Click(object sender, EventArgs e)
        {
            // 获得一个随机的页码顺序字符串
            string indexs = GetConfusedIndexString(myPrintPreviewControl.TotalPages);
            MessageBox.Show("将按照随机的[" + indexs + "]页码顺序进行打印，页码从0开始计算。");
            myPrintPreviewControl.PrintDocumentExt(true, indexs );
        }

        /// <summary>
        /// 获得一个混乱序列的整数数组字符串
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private static string GetConfusedIndexString(int maxValue)
        {
            List<int> indexs = new List<int>();
            System.Random rnd = new Random();
            StringBuilder str = new StringBuilder();
            while (indexs.Count < maxValue)
            {
                int index = rnd.Next(0, maxValue );
                if (indexs.Contains(index) == false)
                {
                    indexs.Add(index);
                    if (str.Length > 0)
                    {
                        str.Append(",");
                    }
                    str.Append(index.ToString());
                }
            }//while
            string v = str.ToString();
            return v;
        }

        private void btnSetScript_Click(object sender, EventArgs e)
        {
            if (btnSetScript.Checked)
            {
                XTextDocument document = myPrintPreviewControl.TextDocument;

                if (document != null)
                {
                    string scriptText = @"
sub Document_EventBeginPrint( eventSender as Object, args as DCSoft.Writer.WriterPrintEventEventArgs )
   msgbox(#开始打印了:# & args.PrintAction.ToString() )
end sub

sub Document_EventPrintQueryPageSettings( eventSender as Object , args as DCSoft.Writer.WriterPrintQueryPageSettingsEventArgs )
   msgbox(#开始查询页面设置,页码：# & args.PageIndex )
end sub

sub Document_EventPrintPage( eventSender as Object , args as DCSoft.Writer.WriterPrintPageEventEventArgs )
   msgbox(#开始打印第# & args.PageIndex & #页的内容#)
end sub

sub Document_EventEndPrint( eventSender as Object , args as DCSoft.Writer.WriterPrintEventEventArgs )
   msgbox(#打印结束#)
end sub";
                    scriptText = scriptText.Replace('#', '"');
                    document.Options.BehaviorOptions.AutoShowScriptErrorMessage = true;
                    document.ScriptLanguage = ScriptLanguageType.VBNET;
                    document.ScriptText = scriptText;
                }
            }
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            int pageCount = this.myPrintPreviewControl.TotalPages;
            StringBuilder str = new StringBuilder();
            for (int iCount = 0; iCount < pageCount; iCount += 2)
            {
                if (str.Length > 0)
                {
                    str.Append(",");
                }
                str.Append(iCount.ToString());
            }
            this.myPrintPreviewControl.PrintDocumentExt(false, str.ToString());
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            myPrintPreviewControl.ClearDocument();
            myPrintPreviewControl.EnabledControlEvent = false;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "*.xml|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    XTextDocument doc = new XTextDocument();
                    doc.LoadFromFile(dlg.FileName, null);
                    doc.Options.ViewOptions.IgnoreFieldBorderWhenPrint = true;
                    doc.Options.ViewOptions.PrintBackgroundText = false;
                    doc.Options.ViewOptions.PreserveBackgroundTextWhenPrint = false;
                    myPrintPreviewControl.AddDocument(doc);
                    myPrintPreviewControl.InvalidatePreview();
                }
            }
        }
    }
}
