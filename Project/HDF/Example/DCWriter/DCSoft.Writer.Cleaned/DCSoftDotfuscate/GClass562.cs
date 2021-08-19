using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass562
	{
		public static void smethod_0(Stream stream_0, Stream stream_1, bool bool_0)
		{
			int num = 17;
			if (stream_0 == null || stream_1 == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (GStream8 gStream = new GStream8(stream_0))
				{
					gStream.method_1(bool_0);
					GClass563.smethod_2(gStream, stream_1, new byte[4096]);
				}
			}
			finally
			{
				if (bool_0)
				{
					stream_1.Close();
				}
			}
		}

		public static void smethod_1(Stream stream_0, Stream stream_1, bool bool_0, int int_0)
		{
			int num = 5;
			if (stream_0 == null || stream_1 == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (GStream10 gStream = new GStream10(stream_1, int_0))
				{
					gStream.method_1(bool_0);
					GClass563.smethod_2(stream_0, gStream, new byte[4096]);
				}
			}
			finally
			{
				if (bool_0)
				{
					stream_0.Close();
				}
			}
		}
	}
}
