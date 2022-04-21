using DCSoft.Common;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       文档导航树控制器
	///       </summary>
	[ComVisible(false)]
	
	
	public class NavigateTreeViewControler
	{
		private TreeView treeView_0 = null;

		private WriterControl writerControl_0 = null;

		private bool bool_0 = false;

		private bool bool_1 = false;

		/// <summary>
		///       控件是否可见
		///       </summary>
		public bool Visible => bool_0;

		/// <summary>
		///       初始化对象
		///       </summary>
		/// <param name="tvw">树状列表控件</param>
		/// <param name="ctl">编辑器控件</param>
		public NavigateTreeViewControler(TreeView treeView_1, WriterControl writerControl_1)
		{
			treeView_0 = treeView_1;
			writerControl_0 = writerControl_1;
		}

		/// <summary>
		///       启动控制器
		///       </summary>
		/// <returns>操作是否成功</returns>
		public bool Start()
		{
			if (treeView_0 != null && writerControl_0 != null)
			{
				treeView_0.AfterSelect += treeView_0_AfterSelect;
				return true;
			}
			return false;
		}

		/// <summary>
		///       刷新控件
		///       </summary>
		/// <param name="visibility">控件可见性设置</param>
		public void Refresh(FunctionControlVisibility visibility)
		{
			bool_0 = false;
			treeView_0.Nodes.Clear();
			switch (visibility)
			{
			case FunctionControlVisibility.Auto:
				if (writerControl_0.Navigator.Nodes.Count > 0)
				{
					method_0(treeView_0.Nodes, writerControl_0.Navigator.Nodes);
					treeView_0.ExpandAll();
					bool_0 = true;
				}
				break;
			case FunctionControlVisibility.Visible:
				method_0(treeView_0.Nodes, writerControl_0.Navigator.Nodes);
				treeView_0.ExpandAll();
				bool_0 = true;
				break;
			case FunctionControlVisibility.Hide:
				bool_0 = false;
				break;
			}
		}

		/// <summary>
		///       处理编辑器控件的SelectionChanged事件
		///       </summary>
		public void HandleWriterControlSelectionChanged()
		{
			if (!bool_1)
			{
				bool_1 = true;
				try
				{
					NavigateNode currentNode = writerControl_0.Navigator.CurrentNode;
					if (currentNode != null)
					{
						method_1(treeView_0.Nodes, currentNode);
					}
				}
				finally
				{
					bool_1 = false;
				}
			}
		}

		private void treeView_0_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (writerControl_0 != null && !bool_1)
			{
				bool_1 = true;
				try
				{
					if (e.Node != null)
					{
						NavigateNode navigateNode = e.Node.Tag as NavigateNode;
						if (navigateNode != null)
						{
							writerControl_0.Navigate(navigateNode);
							writerControl_0.Focus();
						}
					}
				}
				finally
				{
					bool_1 = false;
				}
			}
		}

		private void method_0(TreeNodeCollection treeNodeCollection_0, NavigateNodeList navigateNodeList_0)
		{
			foreach (NavigateNode item in navigateNodeList_0)
			{
				TreeNode treeNode = new TreeNode(item.Text);
				treeNode.Tag = item;
				treeNodeCollection_0.Add(treeNode);
				if (item.Nodes != null && item.Nodes.Count > 0)
				{
					method_0(treeNode.Nodes, item.Nodes);
				}
			}
		}

		private bool method_1(TreeNodeCollection treeNodeCollection_0, NavigateNode navigateNode_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Tag == navigateNode_0)
				{
					treeView_0.SelectedNode = item;
					return true;
				}
				if (item.Nodes.Count > 0 && method_1(item.Nodes, navigateNode_0))
				{
					return true;
				}
			}
			return false;
		}
	}
}
