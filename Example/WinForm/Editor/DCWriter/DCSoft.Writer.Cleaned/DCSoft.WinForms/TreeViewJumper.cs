using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       树状列表跳跃者
	///       </summary>
	[ComVisible(false)]
	public class TreeViewJumper
	{
		private char _PathSpliter = '\\';

		/// <summary>
		///       各个路径之间的分隔字符串
		///       </summary>
		public char PathSpliter
		{
			get
			{
				return _PathSpliter;
			}
			set
			{
				_PathSpliter = value;
			}
		}

		private List<string> SplitPath(string fullPath)
		{
			if (string.IsNullOrEmpty(fullPath))
			{
				return null;
			}
			List<string> list = new List<string>(fullPath.Split(PathSpliter));
			for (int num = list.Count - 1; num >= 0; num--)
			{
				string text = list[num].Trim();
				if (text.Length == 0)
				{
					list.RemoveAt(num);
				}
				else
				{
					list[num] = text;
				}
			}
			return list;
		}

		/// <summary>
		///       匹配节点操作
		///       </summary>
		/// <param name="node">节点对象</param>
		/// <param name="name">当前要匹配的路径节点名称</param>
		/// <returns>是否匹配成功</returns>
		protected virtual bool MatchNode(TreeNode node, string name)
		{
			return node.Text == name;
		}

		/// <summary>
		///       在树状列表中跳跃查找节点
		///       </summary>
		/// <param name="tvw">树状列表控件</param>
		/// <param name="fullPath">跳跃路径</param>
		/// <returns>找到的节点</returns>
		public TreeNode GetNode(TreeView treeView_0, string fullPath)
		{
			int num = 3;
			if (treeView_0 == null)
			{
				throw new ArgumentNullException("tvw");
			}
			if (fullPath == null || fullPath.Length == 0)
			{
				throw new ArgumentNullException("fullPath");
			}
			List<string> list = SplitPath(fullPath);
			if (list == null || list.Count == 0)
			{
				return null;
			}
			return InnerGetNode(treeView_0.Nodes, list);
		}

		/// <summary>
		///       从指定根节点下面跳跃查找子节点，根节点不参与匹配工作。
		///       </summary>
		/// <param name="rootNode">根节点</param>
		/// <param name="fullPath">跳跃路径</param>
		/// <returns>找到的节点</returns>
		public TreeNode GetNode(TreeNode rootNode, string fullPath)
		{
			int num = 6;
			if (rootNode == null)
			{
				throw new ArgumentNullException("rootNode");
			}
			if (fullPath == null || fullPath.Length == 0)
			{
				throw new ArgumentNullException("fullPath");
			}
			List<string> list = SplitPath(fullPath);
			if (list == null || list.Count == 0)
			{
				return null;
			}
			return InnerGetNode(rootNode.Nodes, list);
		}

		private TreeNode InnerGetNode(IEnumerable nodes, List<string> items)
		{
			if (items.Count == 0)
			{
				return null;
			}
			string name = items[0];
			items.RemoveAt(0);
			foreach (TreeNode node in nodes)
			{
				if (MatchNode(node, name))
				{
					if (items.Count == 0)
					{
						return node;
					}
					return InnerGetNode(node.Nodes, items);
				}
			}
			return null;
		}
	}
}
