using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs15 : EventArgs
	{
		private string string_0;

		private bool bool_0 = true;

		public string Name => string_0;

		public GEventArgs15(string string_1)
		{
			string_0 = string_1;
		}

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
