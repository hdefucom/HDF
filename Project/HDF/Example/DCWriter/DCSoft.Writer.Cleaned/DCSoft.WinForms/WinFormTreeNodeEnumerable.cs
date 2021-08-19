using DCSoft.Common;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.WinForms
{
	/// <summary>
	///       WinForm树状列表节点遍历器
	///       </summary>
	[ComVisible(false)]
	public class WinFormTreeNodeEnumerable : TreeNodeEnumerable
	{
		public WinFormTreeNodeEnumerable(TreeNode rootNode)
			: base(rootNode)
		{
		}

		public WinFormTreeNodeEnumerable(TreeNodeCollection nodes)
			: base(nodes)
		{
		}

		public WinFormTreeNodeEnumerable(TreeView treeView_0)
			: base(treeView_0.Nodes)
		{
		}

		public override IEnumerable GetChildNodes(object instance)
		{
			return ((TreeNode)instance).Nodes;
		}

		public override object GetParent(object childNode)
		{
			return ((TreeNode)childNode).Parent;
		}
	}
}
