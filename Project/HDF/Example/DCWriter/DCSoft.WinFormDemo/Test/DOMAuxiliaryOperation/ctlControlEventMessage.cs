using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls ;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    /// <summary>
    /// 在一些情况下，比如Delphi XE中不能启用控件的事件，在此使用一个事件消息循环机制来
    /// 模拟控件事件的效果。
    /// </summary>
    [ToolboxItem(false)]
    public partial class ctlControlEventMessage : UserControl
    {
        public ctlControlEventMessage()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EnabledControlEvent = false;
            this.timer1.Start();
        }

        /// <summary>
        /// 一个高频定时器来执行事件消息循环处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            WriterControlEventMessage msg = this.myWriterControl.GetEventMessage();
            while (msg != null)
            {
                txtLog.AppendText(msg.ToString() + Environment.NewLine);
                msg = this.myWriterControl.GetEventMessage();
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

    }
}