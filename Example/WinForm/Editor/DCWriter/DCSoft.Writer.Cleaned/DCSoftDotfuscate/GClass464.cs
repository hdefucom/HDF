using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass464 : GClass459
	{
		private GClass460 gclass460_0;

		private GClass515 gclass515_0;

		public GClass464(GClass460 gclass460_1)
		{
			gclass460_0 = gclass460_1;
			if (gclass460_1 is GClass462)
			{
				gclass515_0 = new GClass515();
				gclass515_0.method_1(GEnum89.const_1);
				gclass515_0.method_15(bool_1: true);
			}
		}

		protected internal GClass478 method_4()
		{
			return method_6().method_6();
		}

		protected internal GClass476 method_5()
		{
			return method_6().method_4();
		}

		public GClass460 method_6()
		{
			return gclass460_0;
		}

		private byte[] method_7(byte[] byte_0, int int_0)
		{
			int_0--;
			if (int_0 < 0 || int_0 >= byte_0.Length * 8)
			{
				return byte_0;
			}
			int num = int_0 / 8;
			int num2 = int_0 % 8;
			byte b = (byte)(1 << num2);
			byte_0[num] |= b;
			return byte_0;
		}

		private int method_8()
		{
			byte[] array = new byte[4];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0;
			}
			array = method_7(array, 6);
			if (method_4().method_17().method_6().byte_3 == 9)
			{
				array = method_7(array, 1);
			}
			if (method_4().method_17().method_6().byte_1 != 11 && method_4().method_17().method_6().byte_1 != 12 && method_4().method_17().method_6().byte_1 != 13)
			{
				array = method_7(array, 2);
			}
			if (method_4().method_17().method_6().byte_0 == 3)
			{
				array = method_7(array, 4);
			}
			return BitConverter.ToInt32(array, 0);
		}

		protected override void vmethod_1(StreamWriter streamWriter_0)
		{
			if (gclass515_0 != null)
			{
				gclass515_0.method_6(streamWriter_0);
			}
		}

		protected override void vmethod_0(GClass540 gclass540_0)
		{
			if (gclass515_0 != null)
			{
				gclass540_0.method_2(gclass515_0);
			}
		}

		public override void vmethod_2()
		{
			int num = 10;
			if (gclass460_0 == null)
			{
				return;
			}
			method_3().method_9("Type", "FontDescriptor");
			method_3().method_9("FontName", method_6().vmethod_5());
			method_3().method_10("Ascent", (int)Math.Round((float)method_4().method_14().method_6() * method_5().method_2()));
			method_3().method_10("CapHeight", 500);
			method_3().method_10("Descent", (int)Math.Round((float)method_4().method_14().method_7() * method_5().method_2()));
			method_3().method_10("Flags", method_8());
			int int_ = (int)Math.Round((float)method_4().method_12().method_8() * method_5().method_2());
			int int_2 = (int)Math.Round((float)method_4().method_12().method_9() * method_5().method_2());
			int int_3 = (int)Math.Round((float)method_4().method_12().method_10() * method_5().method_2());
			int int_4 = (int)Math.Round((float)method_4().method_12().method_11() * method_5().method_2());
			method_3().method_8("FontBBox", new GClass516(int_, int_2, int_3, int_4));
			method_3().method_10("ItalicAngle", (int)method_4().method_16().method_12());
			method_3().method_10("StemV", 0);
			if (gclass515_0 != null)
			{
				if (!method_4().method_24())
				{
					throw new GException18("The current font can't be embedded");
				}
				method_3().method_8("FontFile2", gclass515_0);
				method_5().method_9(gclass515_0.method_13());
			}
		}
	}
}
