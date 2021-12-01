using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass576 : GClass574
	{
		private MemoryStream memoryStream_0;

		private MemoryStream memoryStream_1;

		public GClass576()
			: base(GEnum100.const_1)
		{
		}

		public GClass576(GEnum100 genum100_1)
			: base(genum100_1)
		{
		}

		public MemoryStream method_0()
		{
			return memoryStream_1;
		}

		public override Stream imethod_1()
		{
			memoryStream_0 = new MemoryStream();
			return memoryStream_0;
		}

		public override Stream imethod_2()
		{
			int num = 9;
			if (memoryStream_0 == null)
			{
				throw new GException24("No temporary stream has been created");
			}
			memoryStream_1 = new MemoryStream(memoryStream_0.ToArray());
			return memoryStream_1;
		}

		public override Stream imethod_3(Stream stream_0)
		{
			memoryStream_0 = new MemoryStream();
			stream_0.Position = 0L;
			GClass563.smethod_2(stream_0, memoryStream_0, new byte[4096]);
			return memoryStream_0;
		}

		public override Stream imethod_4(Stream stream_0)
		{
			Stream stream;
			if (!(stream_0?.CanWrite ?? false))
			{
				stream = new MemoryStream();
				if (stream_0 != null)
				{
					stream_0.Position = 0L;
					GClass563.smethod_2(stream_0, stream, new byte[4096]);
					stream_0.Close();
				}
			}
			else
			{
				stream = stream_0;
			}
			return stream;
		}

		public override void imethod_5()
		{
			if (memoryStream_0 != null)
			{
				memoryStream_0.Close();
			}
		}
	}
}
