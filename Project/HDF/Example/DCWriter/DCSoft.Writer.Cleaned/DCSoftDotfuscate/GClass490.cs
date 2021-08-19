using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass490 : GClass480
	{
		private byte[] byte_0;

		private byte[] byte_1;

		private short short_0;

		private short short_1;

		private uint uint_0;

		private uint uint_1;

		private uint uint_2;

		private uint uint_3;

		private uint uint_4;

		private ushort[] ushort_0;

		private string[] string_1;

		public GClass490(GClass478 gclass478_1)
			: base(gclass478_1)
		{
		}

		private void method_6(float float_0)
		{
			int num = 2;
			if (float_0 != 1f && float_0 != 2f && float_0 != 3f)
			{
				throw new GException16("Unknown format type of the 'post' table");
			}
		}

		private string method_7(GClass498 gclass498_0)
		{
			string text = "";
			int num = gclass498_0.method_1();
			for (int i = 0; i < num; i++)
			{
				text += (char)gclass498_0.method_0();
			}
			return text;
		}

		private void method_8(GClass498 gclass498_0, string string_2)
		{
			gclass498_0.method_16((sbyte)string_2.Length);
			for (int i = 0; i < string_2.Length; i++)
			{
				gclass498_0.method_15((byte)string_2[i]);
			}
		}

		private void method_9(GClass498 gclass498_0)
		{
			float num = method_13();
			method_6(num);
			if (num != 2f)
			{
				return;
			}
			ushort num2 = gclass498_0.method_2();
			ushort_0 = new ushort[num2];
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				ushort_0[i] = gclass498_0.method_2();
				if (ushort_0[i] > 257)
				{
					num3++;
				}
			}
			string_1 = new string[num3];
			for (int i = 0; i < num3; i++)
			{
				string_1[i] = method_7(gclass498_0);
			}
		}

		private void method_10(GClass498 gclass498_0)
		{
			float num = method_13();
			method_6(num);
			if (num == 2f)
			{
				gclass498_0.method_17((ushort)ushort_0.Length);
				for (int i = 0; i < ushort_0.Length; i++)
				{
					gclass498_0.method_17(ushort_0[i]);
				}
				for (int i = 0; i < string_1.Length; i++)
				{
					method_8(gclass498_0, string_1[i]);
				}
			}
		}

		private int method_11()
		{
			float num = method_13();
			method_6(num);
			if (num == 2f)
			{
				int num2 = 0;
				num2 = 2;
				num2 = 2 + ushort_0.Length * 2;
				for (int i = 0; i < string_1.Length; i++)
				{
					num2 += string_1[i].Length + 1;
				}
				return num2;
			}
			return 0;
		}

		protected override void vmethod_0(GClass498 gclass498_0)
		{
			byte_0 = gclass498_0.method_11(4);
			byte_1 = gclass498_0.method_11(4);
			short_0 = gclass498_0.method_8();
			short_1 = gclass498_0.method_8();
			uint_0 = gclass498_0.method_4();
			uint_1 = gclass498_0.method_4();
			uint_2 = gclass498_0.method_4();
			uint_3 = gclass498_0.method_4();
			uint_4 = gclass498_0.method_4();
			method_9(gclass498_0);
		}

		protected override void vmethod_1(GClass498 gclass498_0)
		{
			gclass498_0.method_13(byte_0);
			gclass498_0.method_13(byte_1);
			gclass498_0.method_22(short_0);
			gclass498_0.method_22(short_1);
			gclass498_0.method_19(uint_0);
			gclass498_0.method_19(uint_1);
			gclass498_0.method_19(uint_2);
			gclass498_0.method_19(uint_3);
			gclass498_0.method_19(uint_4);
			method_10(gclass498_0);
		}

		protected override void vmethod_2(GClass480 gclass480_0, GClass479 gclass479_0)
		{
			GClass490 gClass = gclass480_0 as GClass490;
			byte_0 = new byte[4]
			{
				0,
				3,
				0,
				0
			};
			byte_1 = new byte[gClass.byte_1.Length];
			gClass.byte_1.CopyTo(byte_1, 0);
			short_0 = gClass.short_0;
			short_1 = gClass.short_1;
			uint_0 = gClass.uint_0;
			uint_1 = gClass.uint_1;
			uint_2 = gClass.uint_2;
			uint_3 = gClass.uint_3;
			uint_4 = gClass.uint_4;
		}

		protected internal override string vmethod_3()
		{
			return "post";
		}

		public float method_12()
		{
			return GClass498.smethod_0(byte_1);
		}

		public float method_13()
		{
			return GClass498.smethod_0(byte_0);
		}

		public override int vmethod_4()
		{
			return 32 + method_11();
		}
	}
}
