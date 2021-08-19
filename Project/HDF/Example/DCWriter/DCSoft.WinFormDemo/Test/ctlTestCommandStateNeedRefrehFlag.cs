using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Data;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test
{
    [ToolboxItem(false)]
    public partial class ctlTestCommandStateNeedRefrehFlag : UserControl
    {
        public ctlTestCommandStateNeedRefrehFlag()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            // 每100毫秒触发一次
            this.myTimer.Interval = 100;
            this.myTimer.Start();
        }
         

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("FileOpen", true, null);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("Cut", true, null);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("Copy", true, null);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("Paste", true, null);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("Undo", true, null);
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.myWriterControl.ExecuteCommand("Redo", true, null);
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            if (myWriterControl.CommandStateNeedRefreshFlag)
            {
                this.myWriterControl.CommandStateNeedRefreshFlag = false;
                this.btnCopy.Enabled = this.myWriterControl.IsCommandEnabled("Copy");
                this.btnCut.Enabled = this.myWriterControl.IsCommandEnabled("Cut");
                this.btnPaste.Enabled = this.myWriterControl.IsCommandEnabled("Paste");
                this.btnUndo.Enabled = this.myWriterControl.IsCommandEnabled("Undo");
                this.btnRedo.Enabled = this.myWriterControl.IsCommandEnabled("Redo");
            }
        }
    }
}