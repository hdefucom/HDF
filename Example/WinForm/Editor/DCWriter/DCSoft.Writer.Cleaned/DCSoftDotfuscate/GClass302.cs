using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass302
	{
		private class Class184
		{
			public int int_0 = 0;

			public int int_1 = 0;

			public int int_2 = 0;
		}

		private static GClass302 gclass302_0 = new GClass302();

		private List<Class184> list_0 = new List<Class184>();

		public static GClass302 smethod_0()
		{
			return gclass302_0;
		}

		public int method_0()
		{
			return list_0.Count;
		}

		public void method_1()
		{
			list_0.Clear();
		}

		public int method_2(int int_0, int int_1)
		{
			return method_3(int_0, int_1, Environment.TickCount);
		}

		public int method_3(int int_0, int int_1, int int_2)
		{
			Class184 @class = new Class184();
			@class.int_0 = int_0;
			@class.int_1 = int_1;
			@class.int_2 = Environment.TickCount;
			if (list_0.Count == 0)
			{
				list_0.Add(@class);
			}
			else
			{
				Class184 class2 = list_0[list_0.Count - 1];
				Size doubleClickSize = SystemInformation.DoubleClickSize;
				if (Math.Abs(@class.int_0 - class2.int_0) <= doubleClickSize.Width && Math.Abs(@class.int_1 - class2.int_1) <= doubleClickSize.Height && @class.int_2 - class2.int_2 <= SystemInformation.DoubleClickTime)
				{
					list_0.Add(@class);
					return list_0.Count;
				}
				list_0.Clear();
				list_0.Add(@class);
			}
			return list_0.Count;
		}
	}
}
