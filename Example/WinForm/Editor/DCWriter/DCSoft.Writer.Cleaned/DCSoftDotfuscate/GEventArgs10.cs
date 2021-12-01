using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs10 : EventArgs
	{
		private TreeView treeView_0 = null;

		private TreeNode treeNode_0 = null;

		private int int_0 = 0;

		private object object_0 = null;

		private bool bool_0 = false;

		public TreeView method_0()
		{
			return treeView_0;
		}

		public void method_1(TreeView treeView_1)
		{
			treeView_0 = treeView_1;
		}

		public TreeNode method_2()
		{
			return treeNode_0;
		}

		public void method_3(TreeNode treeNode_1)
		{
			treeNode_0 = treeNode_1;
		}

		public int method_4()
		{
			return int_0;
		}

		public void method_5(int int_1)
		{
			int_0 = int_1;
		}

		public object method_6()
		{
			return object_0;
		}

		public void method_7(object object_1)
		{
			object_0 = object_1;
		}

		public bool method_8()
		{
			return bool_0;
		}

		public void method_9(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
