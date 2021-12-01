using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	[DefaultMember("Item")]
	public class GClass485 : GClass480
	{
		private uint[] uint_0;

		public GClass485(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			uint_0 = new uint[method_5().method_13().method_6() + 1];
			for (int i = 0; i < method_5().method_13().method_6() + 1; i++)
			{
				uint_0[i] = ((method_5().method_12().method_12() == 1) ? gclass498_0.method_4() : (Convert.ToUInt32(gclass498_0.method_2()) << 1));
			}
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			for (int i = 0; i < method_5().method_13().method_6() + 1; i++)
			{
				if (method_5().method_12().method_12() == 1)
				{
					gclass498_0.method_19(uint_0[i]);
				}
				else
				{
					gclass498_0.method_17(Convert.ToUInt16(uint_0[i] >> 1));
				}
			}
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass485 gClass = gclass480_0 as GClass485;
			uint_0 = new uint[gClass.method_6()];
			uint num = 0u;
			for (int i = 0; i < method_5().method_19().method_9().Length; i++)
			{
				uint_0[i] = num;
				if (method_5().method_19().method_9()[i] != null)
				{
					num = (uint)((int)num + method_5().method_19().method_9()[i].method_4());
				}
			}
			uint_0[method_5().method_19().method_9().Length] = num;
		}

		protected internal override string vmethod_3()
		{
			return "loca";
		}

		public int method_6()
		{
			return uint_0.Length;
		}

		public uint method_7(ushort ushort_0)
		{
			return uint_0[ushort_0];
		}

		public override int vmethod_4()
		{
			int num = (method_5().method_12().method_12() == 1) ? 4 : 2;
			return num * method_6();
		}
	}
}
