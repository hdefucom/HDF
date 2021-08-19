using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass487 : GClass480
	{
		private string string_1;

		private byte[] byte_0;

		public string Name => string_1;

		public GClass487(GClass478 gclass478_1, string string_2)
			: base(gclass478_1)
		{
			string_1 = string_2;
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(method_4().method_8());
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass487 gClass = gclass480_0 as GClass487;
			if (gClass != null)
			{
				string_1 = gClass.Name;
				if (gClass.byte_0 != null)
				{
					byte_0 = new byte[gClass.method_6().Length];
					gClass.method_6().CopyTo(byte_0, 0);
				}
				else
				{
					byte_0 = new byte[0];
				}
			}
		}

		protected internal override string vmethod_3()
		{
			return string_1;
		}

		public byte[] method_6()
		{
			return byte_0;
		}

		public override int vmethod_4()
		{
			return byte_0.Length;
		}
	}
}
