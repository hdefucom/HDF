using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass499 : GClass498
	{
		private Stream stream_0;

		public GClass499(Stream stream_1)
		{
			stream_0 = stream_1;
		}

		protected override byte vmethod_0()
		{
			return (byte)stream_0.ReadByte();
		}

		protected override void vmethod_1(byte byte_0)
		{
			stream_0.WriteByte(byte_0);
		}

		protected override void vmethod_2(int int_12)
		{
			stream_0.Seek(int_12, SeekOrigin.Begin);
		}

		public override int vmethod_3()
		{
			return (int)stream_0.Position;
		}

		public override int vmethod_4()
		{
			return (int)stream_0.Length;
		}

		public Stream method_28()
		{
			return stream_0;
		}
	}
}
