using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class GAttribute2 : Attribute
	{
		private int int_0 = -1;

		private int int_1 = -1;

		public GAttribute2(int int_2, int int_3)
		{
			int_0 = int_2;
			int_1 = int_3;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public void method_2(int int_2)
		{
			int_1 = int_2;
		}
	}
}
