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
    public partial class ctlTestAutoTranslate : UserControl
    {
        public ctlTestAutoTranslate()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }


        private void btnNoTranslate_Click(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateDescString = null;
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateSourceString = null;
        }

        private void btnTranslateNum_Click(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateSourceString = "０１２３４５６７８９。＋－";
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateDescString = "0123456789.+-";
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateDescString = null;
            myWriterControl.DocumentOptions.BehaviorOptions.AutoTranslateSourceString = null;
            this.myWriterControl.EventBeforeUIKeyboardInputString += new WriterBeforeUIKeyboardInputStringEventHandler(myWriterControl_EventBeforeUIKeyboardInputString);
        }

        void myWriterControl_EventBeforeUIKeyboardInputString(
            object eventSender, 
            WriterBeforeUIKeyboardInputStringEventArgs args)
        {
            switch (args.InputString)
            {
                case " " : args.OutputString = "&nbsp;"; break;
                case "<" : args.OutputString = "&lt;";break;
                case ">" : args.OutputString = "&gt;";break;
                case "\"": args.OutputString = "&quot;";break;
                case "'" : args.OutputString = "&qpos;";break;
                case "袁永福": args.OutputString = "袁永福到此一游"; break;
            }
        }
    }
}