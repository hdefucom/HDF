using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass491 : GClass480
	{
		private const int int_0 = 8;

		private int int_1;

		private ushort ushort_0;

		private ushort ushort_1;

		private GStruct22[] gstruct22_0;

		private string[] string_1 = new string[8];

		public string FullName => string_1[4];

		public GClass491(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		private void method_6()
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (string_1[i] != null)
				{
					num++;
				}
			}
			gstruct22_0 = new GStruct22[num];
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < 8; i++)
			{
				if (string_1[i] != null)
				{
					gstruct22_0[num2].ushort_0 = 3;
					gstruct22_0[num2].ushort_1 = 1;
					gstruct22_0[num2].ushort_2 = 1033;
					gstruct22_0[num2].ushort_3 = (ushort)i;
					gstruct22_0[num2].ushort_4 = (ushort)(string_1[i].Length * 2);
					gstruct22_0[num2].ushort_5 = (ushort)num3;
					num3 += gstruct22_0[num2].ushort_4;
					num2++;
				}
			}
			ushort_0 = (ushort)gstruct22_0.Length;
			ushort_1 = (ushort)(6 + GStruct22.smethod_0() * ushort_0);
		}

		private void method_7(GClass498 gclass498_0)
		{
			for (int i = 0; i < gstruct22_0.Length; i++)
			{
				if (gstruct22_0[i].ushort_0 == 3 && gstruct22_0[i].ushort_1 == 1 && gstruct22_0[i].ushort_2 == 1033)
				{
					gclass498_0.method_27(int_1);
					gclass498_0.method_26(ushort_1);
					gclass498_0.method_26(gstruct22_0[i].ushort_5);
					if (gstruct22_0[i].ushort_3 >= 0 && gstruct22_0[i].ushort_3 <= 7)
					{
						string_1[gstruct22_0[i].ushort_3] = gclass498_0.method_12(gstruct22_0[i].ushort_4);
					}
				}
			}
		}

		private void method_8(GClass498 gclass498_0)
		{
			gstruct22_0 = new GStruct22[ushort_0];
			for (int i = 0; i < ushort_0; i++)
			{
				gstruct22_0[i].ushort_0 = gclass498_0.method_2();
				gstruct22_0[i].ushort_1 = gclass498_0.method_2();
				gstruct22_0[i].ushort_2 = gclass498_0.method_2();
				gstruct22_0[i].ushort_3 = gclass498_0.method_2();
				gstruct22_0[i].ushort_4 = gclass498_0.method_2();
				gstruct22_0[i].ushort_5 = gclass498_0.method_2();
			}
		}

		private void method_9(GClass498 gclass498_0)
		{
			for (int i = 0; i < gstruct22_0.Length; i++)
			{
				gclass498_0.method_27(int_1);
				gclass498_0.method_26(ushort_1);
				gclass498_0.method_26(gstruct22_0[i].ushort_5);
				gclass498_0.method_24(string_1[gstruct22_0[i].ushort_3]);
			}
		}

		private void method_10(GClass498 gclass498_0)
		{
			for (int i = 0; i < gstruct22_0.Length; i++)
			{
				gclass498_0.method_17(gstruct22_0[i].ushort_0);
				gclass498_0.method_17(gstruct22_0[i].ushort_1);
				gclass498_0.method_17(gstruct22_0[i].ushort_2);
				gclass498_0.method_17(gstruct22_0[i].ushort_3);
				gclass498_0.method_17(gstruct22_0[i].ushort_4);
				gclass498_0.method_17(gstruct22_0[i].ushort_5);
			}
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			int_1 = gclass498_0.vmethod_3();
			gclass498_0.method_26(2);
			ushort_0 = gclass498_0.method_2();
			ushort_1 = gclass498_0.method_2();
			method_8(gclass498_0);
			method_7(gclass498_0);
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			int_1 = gclass498_0.vmethod_3();
			gclass498_0.method_17(0);
			gclass498_0.method_17(ushort_0);
			gclass498_0.method_17(ushort_1);
			method_10(gclass498_0);
			method_9(gclass498_0);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass491 gClass = gclass480_0 as GClass491;
			string_1[1] = gclass479_0.string_0;
			string_1[2] = gClass.string_1[2];
			string_1[3] = gclass479_0.string_0;
			string_1[4] = gclass479_0.string_0;
			string_1[6] = gclass479_0.string_0;
			method_6();
		}

		protected internal override string vmethod_3()
		{
			return "name";
		}

		public override int vmethod_4()
		{
			int num = 0;
			for (int i = 0; i < 8; i++)
			{
				if (string_1[i] != null)
				{
					num += string_1[i].Length * 2;
				}
			}
			return 6 + GStruct22.smethod_0() * gstruct22_0.Length + num;
		}

		public string method_11()
		{
			return string_1[0];
		}

		public string method_12()
		{
			return string_1[1];
		}

		public string method_13()
		{
			return string_1[2];
		}

		public string method_14()
		{
			return string_1[3];
		}

		public string method_15()
		{
			return string_1[5];
		}

		public string method_16()
		{
			return string_1[6];
		}

		public string method_17()
		{
			return string_1[7];
		}
	}
}
