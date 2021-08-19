using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.FileOperations
{
    [ToolboxItem(false)]
    public partial class ctlTestFileSystemEvent : UserControl
    {
        public ctlTestFileSystemEvent()
        {
            InitializeComponent();
            this.myWriterControl.EventReadFileContent += new WriterReadFileContentEventHandler(myWriterControl_EventReadFileContent);
        }

        void myWriterControl_EventReadFileContent(object eventSender, WriterReadFileContentEventArgs args)
        {
            System.IO.Stream stream = this.GetType().Assembly.GetManifestResourceStream(args.FileName);
            if (stream != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                byte[] bs = new byte[1024];
                while( true )
                {
                    int len = stream.Read(bs, 0, bs.Length);
                    if (len == 0)
                    {
                        break;
                    }
                    ms.Write(bs, 0, len);
                }
                stream.Close();
                byte[] result = ms.ToArray();
                args.ResultBinary = result;
            }
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileOpen", false, "DCSoft.Writer.WinFormDemo.DemoFile.FormViewModeDemo.xml");
        }
         

    }
}