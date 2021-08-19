using DCSoft.Design;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs5 : EventArgs
	{
		private DCTypeInfo dctypeInfo_0 = null;

		private DCMemberInfo dcmemberInfo_0 = null;

		private bool bool_0 = true;

		private Color color_0 = Color.Empty;

		private Color color_1 = Color.Empty;

		private bool bool_1 = false;

		private string string_0 = null;

		public GEventArgs5()
		{
		}

		public GEventArgs5(DCTypeInfo dctypeInfo_1)
		{
			dctypeInfo_0 = dctypeInfo_1;
		}

		public GEventArgs5(DCTypeInfo dctypeInfo_1, DCMemberInfo dcmemberInfo_1)
		{
			dctypeInfo_0 = dctypeInfo_1;
			dcmemberInfo_0 = dcmemberInfo_1;
		}

		public DCTypeInfo method_0()
		{
			return dctypeInfo_0;
		}

		public void method_1(DCTypeInfo dctypeInfo_1)
		{
			dctypeInfo_0 = dctypeInfo_1;
		}

		public DCMemberInfo method_2()
		{
			return dcmemberInfo_0;
		}

		public void method_3(DCMemberInfo dcmemberInfo_1)
		{
			dcmemberInfo_0 = dcmemberInfo_1;
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_8()
		{
			return color_1;
		}

		public void method_9(Color color_2)
		{
			color_1 = color_2;
		}

		public bool method_10()
		{
			return bool_1;
		}

		public void method_11(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public string method_12()
		{
			return string_0;
		}

		public void method_13(string string_1)
		{
			string_0 = string_1;
		}

		public void method_14(TreeNode treeNode_0)
		{
			if (treeNode_0 != null)
			{
				if (method_6().A != 0)
				{
					treeNode_0.ForeColor = method_6();
				}
				if (method_8().A != 0)
				{
					treeNode_0.BackColor = method_8();
				}
				if (method_10())
				{
					treeNode_0.NodeFont = new Font(Control.DefaultFont, FontStyle.Bold);
				}
				if (!string.IsNullOrEmpty(method_12()))
				{
					treeNode_0.Text = method_12();
				}
			}
		}
	}
}
