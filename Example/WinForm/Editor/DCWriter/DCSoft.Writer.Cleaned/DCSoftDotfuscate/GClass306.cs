using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass306
	{
		private TreeView treeView_0 = null;

		private object object_0 = null;

		private int int_0 = 0;

		private Stack<TreeNode> stack_0 = new Stack<TreeNode>();

		public GDelegate17 gdelegate17_0 = null;

		public GClass306()
		{
		}

		public GClass306(TreeView treeView_1)
		{
			method_1(treeView_1);
		}

		public TreeView method_0()
		{
			return treeView_0;
		}

		public void method_1(TreeView treeView_1)
		{
			treeView_0 = treeView_1;
		}

		public object method_2()
		{
			return object_0;
		}

		public void method_3(object object_1)
		{
			object_0 = object_1;
		}

		public void method_4()
		{
			stack_0.Clear();
		}

		public TreeNode method_5(object object_1)
		{
			stack_0.Clear();
			if (method_0().Nodes.Count > 0)
			{
				stack_0.Push(method_0().Nodes[0]);
				return method_7();
			}
			return null;
		}

		public TreeNode method_6()
		{
			if (stack_0.Count > 0)
			{
				if (stack_0.Peek() != method_0().SelectedNode)
				{
					List<TreeNode> list = new List<TreeNode>();
					for (TreeNode treeNode = method_0().SelectedNode; treeNode != null; treeNode = treeNode.Parent)
					{
						list.Add(treeNode);
					}
					for (int num = list.Count - 1; num >= 0; num--)
					{
						stack_0.Push(list[num]);
					}
				}
				else
				{
					TreeNode treeNode = stack_0.Peek();
					if (treeNode.Nodes.Count > 0)
					{
						treeNode = treeNode.FirstNode;
					}
					else
					{
						TreeNode treeNode2 = treeNode;
						while (treeNode2 != null)
						{
							if (treeNode2.NextNode == null)
							{
								treeNode2 = treeNode2.Parent;
								continue;
							}
							treeNode = treeNode2.NextNode;
							break;
						}
					}
					if (treeNode == null)
					{
						return null;
					}
					stack_0.Clear();
					List<TreeNode> list = new List<TreeNode>();
					while (treeNode != null)
					{
						list.Add(treeNode);
						treeNode = treeNode.Parent;
					}
					for (int num = list.Count - 1; num >= 0; num--)
					{
						stack_0.Push(list[num]);
					}
				}
			}
			return method_7();
		}

		private TreeNode method_7()
		{
			TreeNode treeNode;
			while (true)
			{
				if (stack_0.Count > 0)
				{
					treeNode = stack_0.Peek();
					if (vmethod_0(treeNode, int_0))
					{
						break;
					}
					TreeNode firstNode = treeNode.FirstNode;
					if (firstNode != null)
					{
						stack_0.Push(firstNode);
						continue;
					}
					while (stack_0.Count > 0)
					{
						TreeNode treeNode2 = stack_0.Pop();
						TreeNode nextNode = treeNode2.NextNode;
						if (nextNode != null)
						{
							stack_0.Push(nextNode);
							break;
						}
					}
					continue;
				}
				return null;
			}
			return treeNode;
		}

		public int method_8()
		{
			return int_0;
		}

		public void method_9(int int_1)
		{
			int_0 = int_1;
		}

		public virtual bool vmethod_0(TreeNode treeNode_0, int int_1)
		{
			if (gdelegate17_0 != null)
			{
				GEventArgs10 gEventArgs = new GEventArgs10();
				gEventArgs.method_1(method_0());
				gEventArgs.method_3(treeNode_0);
				gEventArgs.method_5(int_1);
				gEventArgs.method_7(object_0);
				gdelegate17_0(this, gEventArgs);
				return gEventArgs.method_8();
			}
			return true;
		}
	}
}
