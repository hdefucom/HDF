using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass515 : GClass504
	{
		private GClass514 gclass514_0 = new GClass514();

		private MemoryStream memoryStream_0 = new MemoryStream();

		private bool bool_0 = false;

		public void method_8(string string_0)
		{
			StreamWriter streamWriter = new StreamWriter(memoryStream_0, Encoding.GetEncoding(936));
			streamWriter.Write(string_0);
			streamWriter.Flush();
		}

		public void method_9(string string_0)
		{
			method_8(string_0 + "\r\n");
		}

		public void method_10(byte byte_0)
		{
			memoryStream_0.WriteByte(byte_0);
		}

		public void method_11(byte[] byte_0)
		{
			memoryStream_0.Write(byte_0, 0, byte_0.Length);
		}

		public GClass514 method_12()
		{
			return gclass514_0;
		}

		public MemoryStream method_13()
		{
			return memoryStream_0;
		}

		public bool method_14()
		{
			return bool_0;
		}

		public void method_15(bool bool_1)
		{
			bool_0 = bool_1;
		}

		private void method_16()
		{
			int num = 10;
			gclass514_0.method_10("Length", (int)memoryStream_0.Length);
			if (bool_0)
			{
				gclass514_0.method_10("Length1", (int)memoryStream_0.Length);
			}
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			method_16();
			gclass514_0.vmethod_0(streamWriter_0);
			streamWriter_0.WriteLine();
			streamWriter_0.WriteLine("stream");
			streamWriter_0.Flush();
			memoryStream_0.WriteTo(streamWriter_0.BaseStream);
			streamWriter_0.WriteLine();
			streamWriter_0.Write("endstream");
		}

		public override void Dispose()
		{
			base.Dispose();
			if (memoryStream_0 != null)
			{
				memoryStream_0.Dispose();
				memoryStream_0 = null;
			}
		}
	}
}
