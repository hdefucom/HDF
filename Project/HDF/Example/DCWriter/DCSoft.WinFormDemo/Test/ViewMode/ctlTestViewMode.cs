using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DCSoft.Writer.WinFormDemo.Test.ViewMode
{
    public partial class ctlTestViewMode : UserControl
    {
        public ctlTestViewMode()
        {
            InitializeComponent();
        }

        private void ctlTestViewMode_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = myWriterCommandControler;
            myWriterControl.CommandControler.Start();
            string fileName = Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.LoadDocumentFromFile(fileName, "xml");
            }
            myWriterControl.RefreshDocument();
        }

        private void tsbJumpPrint_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.JumpPrintMode, false, null);
        }

        private void tsbShiftJumpPrint_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.OffsetJumpPrintMode, false, null);
        }

        private void tsbAutoLineWrapViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.AutoLineViewMode, false, null);
        }

        private void tsbPageViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.PageViewMode, false, null);
        }

        private void tsbNormalViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.NormalViewMode, false, null);
        }

        private void tsbCleanViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.CleanViewMode, false, null);
        }

        private void tsbComplexViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, null);
        }

        private void tsbFormViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.FormViewMode, false, null);
        }

        private void tsbReadViewMode_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand(StandardCommandNames.ReadViewMode, false, null);
        }
    }
}
