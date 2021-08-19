using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs13 : EventArgs
	{
		private int int_0 = 0;

		private int int_1 = 0;

		private string string_0 = null;

		private bool bool_0 = false;

		public GEventArgs13(int int_2, int int_3, string string_1)
		{
			int_0 = int_2;
			int_1 = int_3;
			string_0 = string_1;
		}

		public int method_0()
		{
			return int_0;
		}

		public int method_1()
		{
			return int_1;
		}

		public string method_2()
		{
			return string_0;
		}

		public bool method_3()
		{
			return bool_0;
		}

		public void method_4(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
