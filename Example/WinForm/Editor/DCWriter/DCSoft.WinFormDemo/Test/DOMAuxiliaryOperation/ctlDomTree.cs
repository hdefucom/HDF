using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlDomTree : UserControl
    {
        public ctlDomTree()
        {
            InitializeComponent();
        }


        private void ctlDomTree_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            string fileName = System.IO.Path.Combine(Application.StartupPath, "DemoFile\\文档DOM树.xml");
            if (System.IO.File.Exists(fileName))
            {
                myWriterControl.ExecuteCommand("FileOpen", false, fileName);
            }
        }

        private void btnRefreshDOMTree_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DCSoft.Writer.Controls.DOMTreeManager man = new Writer.Controls.DOMTreeManager(this.tvwDOM);
                man.WriterControl = this.myWriterControl;
                man.Document = this.myWriterControl.Document;
                man.RefreshViewDocumentAsRoot();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            //tvwDOM.BeginUpdate();
            //tvwDOM.Nodes.Clear();
            //WriterUtils.FillDomTreeNode(
            //    tvwDOM.Nodes, 
            //    new XTextElementList(myWriterControl.Document) ,
            //    false ,
            //    true );
            //tvwDOM.EndUpdate();
        }
         
        /// <summary>
        /// 处理树状列表节点选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwDOM_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 找到节点对应的文档元素对象
            XTextElement element = e.Node.Tag as XTextElement;
            if (element != null)
            {
                // 将光标移动到文档元素对象中
                element.Focus();
                // 将焦点从树状列表控件移动到编辑器控件
                myWriterControl.Select();
                myWriterControl.Focus();
            }
        }

        /// <summary>
        /// 控件加载文档时的处理，刷新DOM树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_DocumentLoad(object sender, WriterEventArgs args)
        {
            btnRefreshDOMTree_Click(null, null);
        }

        private void btnSetJumpPrintPosition_Click(object sender, EventArgs e)
        {
            if (tvwDOM.SelectedNode != null)
            {
                XTextElement element = tvwDOM.SelectedNode.Tag as XTextElement;
                if (element != null)
                {
                    myWriterControl.SetJumpPrintPositionTo(element,true,false);
                }
            }
        }

        private void btnSetEditText_Click(object sender, EventArgs e)
        {
            if (tvwDOM.SelectedNode != null && tvwDOM.SelectedNode.Tag is XTextContainerElement)
            {
                XTextContainerElement c = (XTextContainerElement)tvwDOM.SelectedNode.Tag;
                string txt = myWriterControl.AppHost.UITools.InputBox(this, "输入文本", c.EditorTextExt);
                if (txt != null)
                {
                    c.EditorTextExt = txt;
                }
            }
        }
    }
}