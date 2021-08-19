using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.Writer.WinFormDemo.Test.Version
{
    public partial class Tibetan : UserControl
    {
        public Tibetan()
        {
            InitializeComponent();
            myEditControl.AllowDragContent = true;
            myEditControl.MoveFocusHotKey = MoveFocusHotKeys.Tab;
            frmTextUseCommand_Load();
        }
        private void frmTextUseCommand_Load()
        {
            DCWriterPublish.Start();
            myEditControl.Font = new Font(this.Font.Name, 12);
            myEditControl.DocumentOptions.ViewOptions.DropdownListFontName = this.Font.Name;
            // 初始化设置命令执行器
            myEditControl.CommandControler = myCommandControler;
            myCommandControler.Start();
            myEditControl.DocumentOptions = new DocumentOptions();
            // 设置为复杂留痕视图模式
            //myEditControl.ExecuteCommand(StandardCommandNames.ComplexViewMode, false, null);
            // 打开演示文档
            string fileName = System.IO.Path.Combine(Application.StartupPath, @"DemoFile\藏文演示文档.xml");
            myEditControl.LoadDocumentFromFile(fileName, null);
        }

        private void myEditControl_DocumentLoad(object eventSender, WriterEventArgs args)
        {
            myEditControl.SetDocumentParameterValue(
              "当前时间",
              DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private void myEditControl_StatusTextChanged(object eventSender, Controls.StatusTextChangedEventArgs args)
        {
            lblStatus.Text = myEditControl.StatusText;
            this.statusStrip1.Refresh();
        }

        private void myEditControl_CommandError(object eventSender, Controls.CommandErrorEventArgs args)
        {
            MessageBox.Show(
               this,
               args.CommandName + "\r\n" + args.Exception.ToString(),
               this.Text,
               MessageBoxButtons.OK,
               MessageBoxIcon.Exclamation);
        }
    }
}
