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

namespace DCSoft.Writer.WinFormDemo.Test.TableOperation
{
    [ToolboxItem(false)]
    public partial class ctlTableRowHeightChangedEvent : UserControl
    {
        public ctlTableRowHeightChangedEvent()
        {
            InitializeComponent();
        }


        private void ctlDymaticListItems_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            // 绑定事件
            myWriterControl.EventTableRowHeightChanging += 
                new WriterTableRowHeightChangingEventHandler(myWriterControl_EventTableRowHeightChanging);
            myWriterControl.EventTableRowHeightChanged += 
                new WriterTableRowHeightChangedEventHandler(myWriterControl_EventTableRowHeightChanged);
        }
        /// <summary>
        /// 表格行高度正在发生改变
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventTableRowHeightChanging(
            object eventSender,
            WriterTableRowHeightChangingEventArgs args)
        {
            if (MessageBox.Show(
                this,
                "表格行高度正在发生改变，旧高度：" + args.OldHeight + " 新高度:" + args.NewHeight + ",是否继续?",
                "系统提示",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 新高度再增大100个文档单位
                args.NewHeight = args.NewHeight + 100;
                // 找到图片对象
                XTextImageElement img = args.RowElement.GetElementById("myImage") as XTextImageElement;
                if (img != null)
                {
                    // 设置图片新高度
                    img.Height = args.NewHeight ;
                    img.Width = args.NewHeight;
                    //img.UpdateSize(false );
                    //img.EditorRefreshView();
                }
            }
            else
            {
                // 取消操作
                args.Cancel = true;
            }
        }

        /// <summary>
        /// 表格行高度发生改变事件
        /// </summary>
        /// <param name="eventSender"></param>
        /// <param name="args"></param>
        void myWriterControl_EventTableRowHeightChanged(
            object eventSender, 
            WriterTableRowHeightChangedEventArgs args)
        {
            MessageBox.Show("表格行发生改变，旧高度:" + args.OldHeight + ", 新高度:" + args.NewHeight);
            
        }


        private void btnInsertTable_Click(object sender, EventArgs e)
        {
            XTextTableElement table = new XTextTableElement();
            table.Build(3, 3, 200);
            XTextImageElement img = new XTextImageElement();
            img.LoadImage(System.IO.Path.Combine(Application.StartupPath, "DemoFile\\blue96.png") , false );
            img.Width = 200;
            img.Height = 200;
            img.ID = "myImage";
            table.GetCell(0, 0, true).Elements.Insert(0, img);
            this.myWriterControl.ExecuteCommand("Table_InsertTable", false, table);
        }

        private void btnBindingEvent_Click(object sender, EventArgs e)
        {
            
        }

         
    }
}