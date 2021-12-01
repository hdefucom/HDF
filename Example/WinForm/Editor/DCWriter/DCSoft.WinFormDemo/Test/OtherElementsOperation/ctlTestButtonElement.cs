using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Dom;
using DCSoft.Writer;

namespace DCSoft.Writer.WinFormDemo.Test.OtherElementsOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestButtonElement : UserControl
    {
        public ctlTestButtonElement()
        {
            InitializeComponent();
        }

        private void frmTestControlHost_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
        }
        

        private void btnUserControlEvent_Click(object sender, EventArgs e)
        {
            myWriterControl.EventButtonClick += new WriterButtonClickEventHandler(myWriterControl_EventButtonClick);
        }

        void myWriterControl_EventButtonClick(object eventSender, WriterButtonClickEventArgs args)
        {
            MessageBox.Show("你点击了按钮 " + args.ButtonElement.Text);
        }

        private void btnInsertButton_Click(object sender, EventArgs e)
        {
            XTextButtonElement btn = new XTextButtonElement();
            btn.Text = "这是一个按钮";
            btn.CommandName = "cmd1";
            myWriterControl.ExecuteCommand("InsertButton", false, btn);
        }

        private void btnInsertButton2_Click(object sender, EventArgs e)
        {
            XTextButtonElement btn = new XTextButtonElement();
            btn.Text = "这又是一个按钮";
            btn.CommandName = "cmd2";
            myWriterControl.ExecuteCommand("InsertButton", false, btn);
        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            EventHandler handler1 = delegate(object sender2, EventArgs args2) 
            {
                MessageBox.Show("第二方式点击了按钮");
            };

            EventHandler handler2 = delegate(object sender2, EventArgs args2)
            {
                MessageBox.Show("第三种方式点击了按钮");
            };

            myWriterControl.SetDocumentParameterValue("cmd1", handler1);
            myWriterControl.SetDocumentParameterValue("cmd2", handler2);
        }

        private void btnDesignMode_Click(object sender, EventArgs e)
        {
            //myWriterControl.DocumentOptions.BehaviorOptions.DesignMode = btnDesignMode.Checked;
            myWriterControl.ExecuteCommand(StandardCommandNames.DesignMode, false, btnDesignMode.Checked);
        }

        private void btnInsertButtonWithScript_Click(object sender, EventArgs e)
        {
            XTextButtonElement btn = new XTextButtonElement();
            btn.Text = "带脚本的按钮";
            btn.ScriptTextForClick = "msgbox(\"脚本中显示一个消息框.\")";
            myWriterControl.ExecuteCommand("InsertButton", false, btn);
            myWriterControl.ExecuteCommand("ResetScriptEngine", false, null);
        }

        private void btnInsertImageButton_Click(object sender, EventArgs e)
        {
            XTextButtonElement btn = new XTextButtonElement();
            btn.AutoSize = true;
            string fn = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\button.png");
            if (System.IO.File.Exists(fn))
            {
                btn.LoadImageFromFile(fn);
            }
            fn = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\buttondown.png");
            if (System.IO.File.Exists(fn))
            {
                btn.LoadImageForDownFromFile(fn);
            }
            fn = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\buttonhover.png");
            if (System.IO.File.Exists(fn))
            {
                btn.LoadImageForMouseOverFromFile(fn);
            }
            btn.Text = "缺失图片";
            btn.ScriptTextForClick = "msgbox(\"这是一个图片按钮.\")";
            myWriterControl.ExecuteCommand("InsertButton", false, btn);
            myWriterControl.ExecuteCommand("ResetScriptEngine", false, null);
        }

    }
}