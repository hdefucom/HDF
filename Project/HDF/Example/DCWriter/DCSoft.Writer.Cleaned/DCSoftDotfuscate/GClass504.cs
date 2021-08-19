using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass504 : IDisposable
	{
		protected GEnum89 genum89_0 = GEnum89.const_0;

		protected int int_0 = 0;

		protected int int_1 = 0;

		protected long long_0 = -1L;

		public GEnum89 method_0()
		{
			return genum89_0;
		}

		public void method_1(GEnum89 genum89_1)
		{
			genum89_0 = genum89_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_2)
		{
			if (int_2 >= 0)
			{
				int_0 = int_2;
			}
		}

		public int method_4()
		{
			return int_1;
		}

		public long method_5()
		{
			return long_0;
		}

		public virtual void vmethod_0(StreamWriter streamWriter_0)
		{
			int num = 16;
			if (genum89_0 == GEnum89.const_0)
			{
				vmethod_1(streamWriter_0);
			}
			else
			{
				streamWriter_0.Write("{0} {1} R", int_0, int_1);
			}
		}

		public void method_6(StreamWriter streamWriter_0)
		{
			int num = 2;
			if (genum89_0 != GEnum89.const_1)
			{
				throw new GException18("Invalid object type");
			}
			method_7(streamWriter_0);
			streamWriter_0.WriteLine("{0} {1} obj", int_0, int_1);
			vmethod_1(streamWriter_0);
			streamWriter_0.WriteLine();
			streamWriter_0.WriteLine("endobj");
		}

		public void method_7(StreamWriter streamWriter_0)
		{
			streamWriter_0.Flush();
			long_0 = streamWriter_0.BaseStream.Position;
		}

		protected abstract void vmethod_1(StreamWriter streamWriter_0);

		public virtual void Dispose()
		{
		}
	}
}
