using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass541
	{
		private bool bool_0;

		private GClass504 gclass504_0;

		public GClass541(GClass504 gclass504_1)
		{
			bool_0 = (gclass504_1 == null);
			gclass504_0 = gclass504_1;
		}

		private string method_0()
		{
			int num = 4;
			return bool_0 ? "f" : "n";
		}

		private long method_1()
		{
			return (bool_0 || gclass504_0 == null) ? 0L : gclass504_0.method_5();
		}

		private int method_2()
		{
			return (bool_0 || gclass504_0 == null) ? 65535 : gclass504_0.method_4();
		}

		public void method_3(StreamWriter streamWriter_0)
		{
			streamWriter_0.Write(method_1().ToString("D10") + " " + method_2().ToString("D5") + " " + method_0());
		}

		public bool method_4()
		{
			return bool_0;
		}

		public void method_5(bool bool_1)
		{
			if (bool_1 != bool_0)
			{
				bool_0 = bool_1;
			}
		}

		public GClass504 method_6()
		{
			return gclass504_0;
		}
	}
}
