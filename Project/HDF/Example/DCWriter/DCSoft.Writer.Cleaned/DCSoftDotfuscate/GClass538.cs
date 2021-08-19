using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass538 : IDisposable
	{
		private GClass514 gclass514_0 = new GClass514();

		private GClass540 gclass540_0;

		public GClass538(GClass540 gclass540_1)
		{
			gclass540_0 = gclass540_1;
		}

		private long method_0()
		{
			return (gclass540_0 != null) ? gclass540_0.method_7() : 0L;
		}

		public void method_1(StreamWriter streamWriter_0)
		{
			streamWriter_0.WriteLine("trailer");
			gclass514_0.vmethod_0(streamWriter_0);
			streamWriter_0.WriteLine();
			streamWriter_0.WriteLine("startxref");
			streamWriter_0.WriteLine(Convert.ToString(method_0()));
			streamWriter_0.Write("%%EOF");
		}

		public GClass514 method_2()
		{
			return gclass514_0;
		}

		public GClass540 method_3()
		{
			return gclass540_0;
		}

		public void Dispose()
		{
			if (gclass514_0 != null)
			{
				gclass514_0.Dispose();
				gclass514_0 = null;
			}
			if (gclass540_0 != null)
			{
				gclass540_0.Dispose();
				gclass540_0 = null;
			}
		}
	}
}
