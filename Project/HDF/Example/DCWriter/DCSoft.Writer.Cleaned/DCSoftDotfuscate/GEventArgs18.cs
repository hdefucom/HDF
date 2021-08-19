using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs18 : EventArgs
	{
		private string string_0;

		private Exception exception_0;

		private bool bool_0;

		public string Name => string_0;

		public GEventArgs18(string string_1, Exception exception_1)
		{
			string_0 = string_1;
			exception_0 = exception_1;
			bool_0 = true;
		}

		public Exception method_0()
		{
			return exception_0;
		}

		public bool method_1()
		{
			return bool_0;
		}

		public void method_2(bool bool_1)
		{
			bool_0 = bool_1;
		}
	}
}
