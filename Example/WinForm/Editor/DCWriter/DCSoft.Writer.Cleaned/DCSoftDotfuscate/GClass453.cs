using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass453 : IDisposable
	{
		protected GClass504 gclass504_0;

		public GClass453(GClass504 gclass504_1)
		{
			gclass504_0 = gclass504_1;
			gclass504_0.method_1(GEnum89.const_1);
		}

		public GClass504 method_0()
		{
			return gclass504_0;
		}

		protected virtual void vmethod_0(GClass540 gclass540_0)
		{
		}

		protected virtual void vmethod_1(StreamWriter streamWriter_0)
		{
		}

		public void method_1(GClass540 gclass540_0)
		{
			gclass540_0.method_2(gclass504_0);
			vmethod_0(gclass540_0);
		}

		public void method_2(StreamWriter streamWriter_0)
		{
			gclass504_0.method_6(streamWriter_0);
			vmethod_1(streamWriter_0);
		}

		public virtual void vmethod_2()
		{
		}

		public virtual void Dispose()
		{
			if (gclass504_0 != null)
			{
				gclass504_0.Dispose();
				gclass504_0 = null;
			}
		}
	}
}
