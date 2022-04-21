using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoftDotfuscate;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       知识库树状列表控件管理器
	///       </summary>
	
	
	[ComVisible(false)]
	public class KBTreeViewController
	{
		private bool _ShowLeafNode = true;

		private bool _ShowTemplateNode = true;

		private static ImageList _StdImageList = null;

		private GClass306 searcher = null;

		/// <summary>
		///       是否显示叶子节点
		///       </summary>
		public bool ShowLeafNode
		{
			get
			{
				return _ShowLeafNode;
			}
			set
			{
				_ShowLeafNode = value;
			}
		}

		/// <summary>
		///       是否显示模板节点
		///       </summary>
		public bool ShowTemplateNode
		{
			get
			{
				return _ShowTemplateNode;
			}
			set
			{
				_ShowTemplateNode = value;
			}
		}

		/// <summary>
		///       标准的图标列表
		///       </summary>
		public static ImageList StdImageList
		{
			get
			{
				if (_StdImageList == null)
				{
					_StdImageList = new ImageList();
					_StdImageList.Images.Add(WriterResources.KBListEntry);
					_StdImageList.Images.Add(WriterResources.KBTemplate);
					_StdImageList.Images.Add(WriterResources.KBBlankEntry);
					_StdImageList.Images.Add(WriterResources.KBListItem);
					_StdImageList.Images.Add(WriterResources.Bitmap_0);
				}
				return _StdImageList;
			}
		}

		/// <summary>
		///       将知识库信息填充到树状列表中
		///       </summary>
		/// <returns>树状列表控件</returns>
		public bool Fill(KBLibrary kblibrary_0, TreeView treeView_0, bool forDesigner)
		{
			int num = 17;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			if (kblibrary_0 == null)
			{
				throw new ArgumentNullException("lib");
			}
			treeView_0.BeginUpdate();
			treeView_0.Nodes.Clear();
			treeView_0.ImageList = StdImageList;
			if (kblibrary_0.KBEntries != null)
			{
				FillNodes(kblibrary_0, kblibrary_0.KBEntries, treeView_0.Nodes, forDesigner);
			}
			treeView_0.EndUpdate();
			return true;
		}

		/// <summary>
		///       更新树状节点
		///       </summary>
		/// <param name="lib">知识库对象</param>
		/// <param name="node">节点对象</param>
		/// <param name="entry">知识节点对象</param>
		/// <param name="forDesigner">是否为设计器而执行操作</param>
		public void UpdateTreeNode(KBLibrary kblibrary_0, TreeNode node, KBEntry entry, bool forDesigner)
		{
			if (kblibrary_0.UseLanguage2)
			{
				node.Text = entry.Text2;
			}
			else
			{
				node.Text = entry.Text;
			}
			node.Name = entry.ID;
			node.Tag = entry;
			node.ImageIndex = entry.StdImageIndex;
			node.SelectedImageIndex = node.ImageIndex;
			if (!forDesigner)
			{
				return;
			}
			if (!entry.Visible)
			{
				node.ForeColor = Color.DarkGray;
				return;
			}
			switch (entry.RecordState)
			{
			default:
				node.ForeColor = Color.Black;
				break;
			case DataRowState.Modified:
				node.ForeColor = Color.Blue;
				break;
			case DataRowState.Deleted:
				node.ForeColor = Color.Red;
				break;
			case DataRowState.Added:
				node.ForeColor = Color.Blue;
				break;
			}
		}

		private void FillNodes(KBLibrary kblibrary_0, KBEntryList entries, TreeNodeCollection nodes, bool forDesigner)
		{
			foreach (KBEntry entry in entries)
			{
				if ((ShowLeafNode || ((entry.Style != 0 || entry.ListItems == null || entry.ListItems.Count <= 0) && entry.Style != KBEntryStyle.ListSQL)) && (ShowTemplateNode || entry.Style != KBEntryStyle.Template))
				{
					TreeNode treeNode = new TreeNode();
					UpdateTreeNode(kblibrary_0, treeNode, entry, forDesigner);
					if (entry.SubEntries != null && entry.SubEntries.Count > 0 && entry.Style != KBEntryStyle.Template)
					{
						FillNodes(kblibrary_0, entry.SubEntries, treeNode.Nodes, forDesigner);
					}
					treeNode.SelectedImageIndex = treeNode.ImageIndex;
					nodes.Add(treeNode);
				}
			}
		}

		/// <summary>
		///       获得指定知识库节点对应的树状节点对象
		///       </summary>
		/// <param name="tvw">树状列表控件</param>
		/// <param name="entry">知识库节点对象</param>
		/// <returns>获得的树状节点对象</returns>
		public TreeNode GetNode(TreeView treeView_0, KBEntry entry)
		{
			int num = 17;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			if (entry == null)
			{
				return null;
			}
			return SubGetNode(treeView_0.Nodes, entry);
		}

		private TreeNode SubGetNode(TreeNodeCollection nodes, KBEntry entry)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Tag == entry)
				{
					return node;
				}
				TreeNode treeNode2 = SubGetNode(node.Nodes, entry);
				if (treeNode2 != null)
				{
					return treeNode2;
				}
			}
			return null;
		}

		/// <summary>
		///       搜索
		///       </summary>
		/// <param name="tvw">树状列表控件</param>
		/// <param name="sourceText">要搜索的文本</param>
		/// <returns>找到的节点对象</returns>
		public TreeNode Search(TreeView treeView_0, string sourceText)
		{
			if (sourceText == null)
			{
				return null;
			}
			sourceText = sourceText.Trim();
			if (sourceText.Length == 0)
			{
				return null;
			}
			if (searcher == null)
			{
				searcher = new GClass306(treeView_0);
				searcher.gdelegate17_0 = SearchNodeHandler;
			}
			TreeNode treeNode = null;
			if (string.Compare((string)searcher.method_2(), sourceText) == 0)
			{
				treeNode = searcher.method_6();
			}
			else
			{
				searcher.method_3(sourceText);
				searcher.method_9(0);
				treeNode = searcher.method_5(sourceText);
			}
			if (treeNode != null)
			{
				treeView_0.SelectedNode = treeNode;
				treeNode.EnsureVisible();
			}
			return treeNode;
		}

		private void SearchNodeHandler(object sender, GEventArgs10 e)
		{
			KBEntry kBEntry = (KBEntry)e.method_2().Tag;
			string text = (string)e.method_6();
			if (kBEntry.Text == text || kBEntry.Name == text)
			{
				e.method_9(bool_1: true);
			}
			else if (kBEntry.Text != null && kBEntry.Text.IndexOf(text) >= 0)
			{
				e.method_9(bool_1: true);
			}
			else if (kBEntry.Name != null && kBEntry.Name.IndexOf(text) >= 0)
			{
				e.method_9(bool_1: true);
			}
		}
	}
}
