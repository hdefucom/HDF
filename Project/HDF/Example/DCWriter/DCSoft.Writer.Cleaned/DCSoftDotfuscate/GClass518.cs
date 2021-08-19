using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass518
	{
		private GClass509 gclass509_0 = null;

		private GClass504 gclass504_0 = null;

		public GClass518(string string_0, GClass504 gclass504_1)
		{
			gclass509_0 = new GClass509(string_0);
			gclass504_0 = gclass504_1;
		}

		public GClass518(GClass509 gclass509_1, GClass504 gclass504_1)
		{
			gclass509_0 = gclass509_1;
			gclass504_0 = gclass504_1;
		}

		public GClass509 method_0()
		{
			return gclass509_0;
		}

		public GClass504 method_1()
		{
			return gclass504_0;
		}

		public void method_2(StreamWriter streamWriter_0)
		{
			int num = 15;
			if (gclass509_0 != null && gclass504_0 != null)
			{
				gclass509_0.vmethod_0(streamWriter_0);
				streamWriter_0.Write(" ");
				gclass504_0.vmethod_0(streamWriter_0);
			}
		}
	}
}
