using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.InputOperation
{
    [ToolboxItem(false)]
    public partial class ctlFieldContentEditEvent : UserControl
    {
        public ctlFieldContentEditEvent()
        {
            InitializeComponent();
        }


        private void ctlFieldContentEditEvent_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();

            myWriterControl.QueryListItems += new  QueryListItemsEventHandler(myWriterControl_QueryListItems);

            myWriterControl.EventBeforeFieldContentEdit += new WriterBeforeFieldContentEditEventHandler(
                myWriterControl_EventBeforeFieldContentEdit);
            myWriterControl.EventAfterFieldContentEdit += new WriterAfterFieldContentEditEventHandler(
                myWriterControl_EventAfterFieldContentEdit);

            myWriterControl.LoadDocumentFromFile(System.IO.Path.Combine(Application.StartupPath, @"EMR\TemplateDocument\InpatientInfo.xml"), null);
        }

        
        /// <summary>
        /// 用户通过数值编辑器修改输入域内容后事件
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventBeforeFieldContentEdit(object eventSender, WriterBeforeFieldContentEditEventArgs args)
        {
            AddLog("----EventBeforeFieldContentEdit事件");
            AddLog("编辑器类型:" + args.EditorTypeName);
            AddLog("输入域编号:" + args.ElementID);
            AddLog("输入域名称:" + args.ElementName);
            AddLog("旧文本:" + args.OldText + " , 新文本：" + args.NewText);
            if (args.SelectedIndexs != null)
            {
                AddLog("选择的项目序号:" + args.SelectedIndexs);
            }
            System.Random rnd = new Random();
            if (rnd.NextDouble() > 0.8)
            {
                args.Cancel = true;
                AddLog("随机的取消操作。");
                MessageBox.Show("随机的取消操作。");
            }
        }


        /// <summary>
        /// 用户通过数值编辑器修改输入域内容前事件
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventAfterFieldContentEdit(object eventSender, WriterAfterFieldContentEditEventArgs args)
        {
            AddLog("----EventAfterFieldContentEdit事件");
            AddLog("编辑器类型:" + args.EditorTypeName);
            AddLog("输入域编号:" + args.ElementID);
            AddLog("输入域名称:" + args.ElementName);
            AddLog("旧文本:" + args.OldText + " , 新文本：" + args.NewText);
        }

        private void AddLog( string txt )
        {
            txtLog.AppendText( DateTime.Now.ToString("HH:mm:ss") + ":" + txt + Environment.NewLine );
        }

        void myWriterControl_QueryListItems(object eventSender,  QueryListItemsEventArgs args)
        {
            Utils.QueryListItems(args);
        }
         

    }
}