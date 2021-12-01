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
    [System.ComponentModel.ToolboxItem(false)]
    public partial class ctlPrint : UserControl
    {
        public ctlPrint()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.SetToMSWordVisualStyle();
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine( Application.StartupPath , "DemoFile2\\入院记录--广州医科大学附属第一医院入院记录.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FilePrint", true, null);
        }
         
        private void btnCleanPrint_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("FileCleanPrint", true, null);
        }

        private void btnJumpPrint_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (int.TryParse(txtPosition.Text, out v))
            {
                myWriterControl.ExtViewMode = DCSoft.Writer.Controls.WriterControlExtViewMode.JumpPrint;
                myWriterControl.JumpPrintPosition = v;
            }
        }

        private void btnJumpPrint2_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (int.TryParse(txtPosition.Text, out v))
            {
                myWriterControl.ExtViewMode =DCSoft.Writer.Controls.WriterControlExtViewMode.OffsetJumpPrint;
                myWriterControl.JumpPrintPosition = v;
            }
        }

          
    }
}