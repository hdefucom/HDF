using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestCopySource : UserControl
    {
        public ctlTestCopySource()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\CopySource.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }
        }
         

    }
}