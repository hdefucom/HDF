using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass643 : GClass642
	{
		private const int int_0 = 5;

		private static readonly int int_1 = 3;

		private static readonly int int_2 = 32;

		private sbyte[] sbyte_0 = null;

		private int[] int_3 = null;

		public override GClass679 vmethod_1()
		{
			GClass605 gClass = vmethod_0();
			int num = gClass.vmethod_1();
			int num2 = gClass.vmethod_2();
			GClass679 gClass2 = new GClass679(num, num2);
			method_0(num);
			int[] array = int_3;
			sbyte[] array2;
			for (int i = 1; i < 5; i++)
			{
				int num3 = num2 * i / 5;
				array2 = gClass.vmethod_5(num3, sbyte_0);
				int num4 = (num << 2) / 5;
				for (int j = num / 5; j < num4; j++)
				{
					int num5 = array2[j] & 0xFF;
					array[num5 >> int_1]++;
				}
			}
			int num6 = smethod_0(array);
			array2 = gClass.vmethod_0();
			for (int i = 0; i < num2; i++)
			{
				int num7 = i * num;
				for (int j = 0; j < num; j++)
				{
					int num5 = array2[num7 + j] & 0xFF;
					if (num5 < num6)
					{
						gClass2.method_4(j, i);
					}
				}
			}
			return gClass2;
		}

		public GClass643(GClass605 gclass605_1)
			: base(gclass605_1)
		{
		}

		public override GClass659 vmethod_2(int int_4, GClass659 gclass659_0)
		{
			GClass605 gClass = vmethod_0();
			int num = gClass.vmethod_1();
			if (gclass659_0 == null || gclass659_0.method_0() < num)
			{
				gclass659_0 = new GClass659(num);
			}
			else
			{
				gclass659_0.method_5();
			}
			method_0(num);
			sbyte[] array = gClass.vmethod_5(int_4, sbyte_0);
			int[] array2 = int_3;
			for (int i = 0; i < num; i++)
			{
				int num2 = array[i] & 0xFF;
				array2[num2 >> int_1]++;
			}
			int num3 = smethod_0(array2);
			int num4 = array[0] & 0xFF;
			int num5 = array[1] & 0xFF;
			for (int i = 1; i < num - 1; i++)
			{
				int num6 = array[i + 1] & 0xFF;
				int num7 = (num5 << 2) - num4 - num6 >> 1;
				if (num7 < num3)
				{
					gclass659_0.method_2(i);
				}
				num4 = num5;
				num5 = num6;
			}
			return gclass659_0;
		}

		public override GClass642 vmethod_3(GClass605 gclass605_1)
		{
			return new GClass643(gclass605_1);
		}

		private void method_0(int int_4)
		{
			if (sbyte_0 == null || sbyte_0.Length < int_4)
			{
				sbyte_0 = new sbyte[int_4];
			}
			if (int_3 == null)
			{
				int_3 = new int[int_2];
				return;
			}
			for (int i = 0; i < int_2; i++)
			{
				int_3[i] = 0;
			}
		}

		private static int smethod_0(int[] int_4)
		{
			int num = int_4.Length;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < num; i++)
			{
				if (int_4[i] > num4)
				{
					num3 = i;
					num4 = int_4[i];
				}
				if (int_4[i] > num2)
				{
					num2 = int_4[i];
				}
			}
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < num; i++)
			{
				int num7 = i - num3;
				int num8 = int_4[i] * num7 * num7;
				if (num8 > num6)
				{
					num5 = i;
					num6 = num8;
				}
			}
			if (num3 > num5)
			{
				int num9 = num3;
				num3 = num5;
				num5 = num9;
			}
			if (num5 - num3 <= num >> 4)
			{
				throw GException25.smethod_0();
			}
			int num10 = num5 - 1;
			int num11 = -1;
			for (int i = num5 - 1; i > num3; i--)
			{
				int num12 = i - num3;
				int num8 = num12 * num12 * (num5 - i) * (num2 - int_4[i]);
				if (num8 > num11)
				{
					num10 = i;
					num11 = num8;
				}
			}
			return num10 << int_1;
		}
	}
}
