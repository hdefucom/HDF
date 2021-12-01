using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer.Controls;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlTestWriterControlExt : UserControl
    {
        public ctlTestWriterControlExt()
        {
            InitializeComponent();
            myWriterControlExt.SelectionChanged +=new WriterEventHandler(myWriterControlExt_SelectionChanged); 
        }

        void myWriterControlExt_SelectionChanged(object eventSender, WriterEventArgs args)
        {
            this.Text = myWriterControlExt.PositionInfoText;
        }
         

        private void myWriterControlExt_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = myWriterControlExt.StatusText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myWriterControlExt.ExecuteCommand("FileOpen", true, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(
                Application.StartupPath,
                @"EMR\TemplateDocument\InpatientInfo.xml");
            if (System.IO.File.Exists(fileName))
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(fileName);
                myWriterControlExt.FormView = Writer.Controls.FormViewMode.Strict;
                myWriterControlExt.XMLText = doc.DocumentElement.OuterXml;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 设置编辑器控件自动显示用户修改痕迹列表，当文档中有修改痕迹信息，
            // 则显示列表,否则隐藏列表。
            myWriterControlExt.TrackListVisible = FunctionControlVisibility.Auto;
            // 隐藏用户修改痕迹列表，即使文档中存在修改痕迹信息。
            myWriterControlExt.TrackListVisible = FunctionControlVisibility.Hide;
            // 一直显示用户修改痕迹列表，即使文档中没有修改痕迹信息。
            myWriterControlExt.TrackListVisible = FunctionControlVisibility.Visible;
            // 设置编辑器控件自动显示导航树，当文档中有文档导航信息
            // 则显示导航树，否则隐藏导航树。
            myWriterControlExt.NavigateTreeVisible = FunctionControlVisibility.Auto;
            // 隐藏导航树，即使文档中有文档导航信息也不显示。
            myWriterControlExt.NavigateTreeVisible = FunctionControlVisibility.Hide;
            // 一直显示导航树，即使文档中没有导航信息
            myWriterControlExt.NavigateTreeVisible = FunctionControlVisibility.Visible;
        }

        private void myWriterControlExt_Load(object sender, EventArgs e)
        {
            string filename = System.IO.Path.Combine(Application.StartupPath, @"DemoFile\FormViewModeDemo.xml");
            myWriterControlExt.ExecuteCommand("FileOpen", false, filename);
        }
    }
}
