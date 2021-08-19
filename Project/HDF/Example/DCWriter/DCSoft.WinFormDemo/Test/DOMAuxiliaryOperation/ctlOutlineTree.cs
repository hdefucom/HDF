using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Commands;

namespace DCSoft.Writer.WinFormDemo.Test.DOMAuxiliaryOperation
{
    [ToolboxItem(false)]
    public partial class ctlOutlineTree : UserControl
    {
        public ctlOutlineTree()
        {
            InitializeComponent();
        }


        private void ctlDomTree_Load(object sender, EventArgs e)
        {
            myWriterControl.CommandControler = writerCommandControler1;
            myWriterControl.CommandControler.Start();
            myWriterControl.EventOutlineTreeChanged += new WriterEventHandler(myWriterControl_EventOutlineTreeChanged);
        }

        void myWriterControl_EventOutlineTreeChanged(object eventSender, WriterEventArgs args)
        {
            this.btnRefreshTree_Click(null, null);
        }
         
         
       

        /// <summary>
        /// 控件加载文档时的处理，刷新DOM树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void myWriterControl_DocumentLoad(object sender, WriterEventArgs args)
        {
            btnRefreshTree_Click(null, null);
        }
         

        private void btnRefreshTree_Click(object sender, EventArgs e)
        {
            this.tvwOutline.BeginUpdate();
            this.tvwOutline.Nodes.Clear();
            this.myWriterControl.ResetOutlineNodes();
            FillNode(this.myWriterControl.OutlineNodes, tvwOutline.Nodes);
            this.tvwOutline.EndUpdate();
        }

        private void FillNode(DocumentOutlineNodeList outlineNodes, TreeNodeCollection nodes)
        {
            foreach (DocumentOutlineNode outlineNode in outlineNodes)
            {
                if (outlineNode.Visible)
                {
                    TreeNode node = new TreeNode(outlineNode.Text);
                    node.Tag = outlineNode;
                    nodes.Add(node);
                    FillNode(outlineNode.ChildNodes, node.Nodes);
                }
            }
        }

        private bool _EventLock = false;
        /// <summary>
        /// 处理树状列表节点选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwOutline_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_EventLock == false)
            {
                _EventLock = true;
                try
                {
                    // 找到节点对应的文档元素对象
                    DocumentOutlineNode node = e.Node.Tag as DocumentOutlineNode;
                    if (node != null)
                    {
                        // 移动编辑器中的焦点
                        node.Focus();
                    }
                }
                finally
                {
                    _EventLock = false;
                }
            }
        }

        private void myWriterControl_SelectionChanged(object eventSender, WriterEventArgs args)
        {
            if (_EventLock == false)
            {
                _EventLock = true;
                try
                {
                    DocumentOutlineNode node = myWriterControl.Document.CurrentOutlineNode;
                    if (node != null)
                    {
                        TreeNode tnode = SearchNode(this.tvwOutline.Nodes, node);
                        if (tnode != null)
                        {
                            tvwOutline.SelectedNode = tnode;
                        }
                    }
                }
                finally
                {
                    _EventLock = false;
                }
            }
        }

        private TreeNode SearchNode(TreeNodeCollection nodes, DocumentOutlineNode outlineNode)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag == outlineNode)
                {
                    return node;
                }
                TreeNode node2 = SearchNode(node.Nodes, outlineNode);
                if (node2 != null)
                {
                    return node2;
                }
            }
            return null;
        }

        private void btnHeader1InVisible_Click(object sender, EventArgs e)
        {
            HeaderFormatCommandParameter p = HeaderFormatCommandParameter.CreateHeader1WithMultiNumberlist();
            p.VisibleInDirectory = false;
            myWriterControl.ExecuteCommand(StandardCommandNames.HeaderFormat, false , p);
        }
    }
}