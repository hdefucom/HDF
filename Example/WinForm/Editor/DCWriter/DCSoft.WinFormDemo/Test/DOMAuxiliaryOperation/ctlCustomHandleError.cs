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

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlCustomHandleError : UserControl
    {
        public ctlCustomHandleError()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }
         

        private void btnThrowException_Click(object sender, EventArgs e)
        {
            myWriterControl.ExecuteCommand("ThrowException", false, null);
        }

        private bool _Flag = false;
        private void btnCustomHandleError_Click(object sender, EventArgs e)
        {

            if (_Flag == false )
            {
                _Flag = true;
                this.myWriterControl.EventReportError += new WriterReportErrorEventHandler(myWriterControl_EventReportError);
            }
        }

        void myWriterControl_EventReportError(object eventSender, WriterReportErrorEventArgs args)
        {
            MessageBox.Show("发生错误:" + args.Message);
            args.Handled = true;
        }
    }
}