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
using DCSoft.Writer.Data;

namespace DCSoft.Writer.WinFormDemo.Test.AccessControl
{
    [ToolboxItem(false)]
    public partial class ctlQueryHistoryDisplayText : UserControl
    {
        public ctlQueryHistoryDisplayText()
        {
            InitializeComponent();
        }


        private void frmFilterValue_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.ExecuteCommand("ComplexViewMode", false, true );
            this.myWriterControl.QueryUserHistoryDisplayText += new DCSoft.Writer.QueryUserHistoryDisplayTextEventHandler(this.myWriterControl_QueryUserHistoryDisplayText);
        }

        private void myWriterControl_QueryUserHistoryDisplayText(object sender, QueryUserHistoryDisplayTextEventArgs args)
        {
            string text  = "都昌公司提示：" + args.Info.Name + " 于 " + args.Info.SavedTime.ToString("yyyy-MM-dd HH:mm:ss") + " 在电脑[" + args.Info.ClientName + "]";
            if (args.ForLogicDelete)
            {
                text = text + "删除了该内容";
            }
            else
            {
                text = text + "修改了该内容";
            }
            args.Result = text;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void myWriterControl_Load(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\FormViewModeDemo.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }
        }
         
    }


}