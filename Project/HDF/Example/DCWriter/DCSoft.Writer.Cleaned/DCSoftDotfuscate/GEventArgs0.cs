using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs0 : EventArgs
	{
		private string string_0 = null;

		private GClass55 gclass55_0 = null;

		private object object_0;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public GClass55 method_2()
		{
			return gclass55_0;
		}

		public void method_3(GClass55 gclass55_1)
		{
			gclass55_0 = gclass55_1;
		}

		public object method_4()
		{
			return object_0;
		}

		public void method_5(object object_1)
		{
			object_0 = object_1;
		}
	}
}
