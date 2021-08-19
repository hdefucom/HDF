using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class268
	{
		private int int_0;

		private sbyte[] sbyte_0;

		internal int method_0()
		{
			return int_0;
		}

		internal sbyte[] method_1()
		{
			return sbyte_0;
		}

		private Class268(int int_1, sbyte[] sbyte_1)
		{
			int_0 = int_1;
			sbyte_0 = sbyte_1;
		}

		internal static Class268[] smethod_0(sbyte[] sbyte_1, GClass672 gclass672_0, GClass636 gclass636_0)
		{
			if (sbyte_1.Length != gclass672_0.method_2())
			{
				throw new ArgumentException();
			}
			GClass672.GClass673 gClass = gclass672_0.method_4(gclass636_0);
			int num = 0;
			GClass672.GClass674[] array = gClass.method_3();
			for (int i = 0; i < array.Length; i++)
			{
				num += array[i].method_0();
			}
			Class268[] array2 = new Class268[num];
			int num2 = 0;
			foreach (GClass672.GClass674 gClass2 in array)
			{
				for (int i = 0; i < gClass2.method_0(); i++)
				{
					int num3 = gClass2.method_1();
					int num4 = gClass.method_0() + num3;
					array2[num2++] = new Class268(num3, new sbyte[num4]);
				}
			}
			int num5 = array2[0].sbyte_0.Length;
			int num6;
			for (num6 = array2.Length - 1; num6 >= 0; num6--)
			{
				int num7 = array2[num6].sbyte_0.Length;
				if (num7 == num5)
				{
					break;
				}
			}
			num6++;
			int num8 = num5 - gClass.method_0();
			int num9 = 0;
			for (int i = 0; i < num8; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array2[j].sbyte_0[i] = sbyte_1[num9++];
				}
			}
			for (int j = num6; j < num2; j++)
			{
				array2[j].sbyte_0[num8] = sbyte_1[num9++];
			}
			int num10 = array2[0].sbyte_0.Length;
			for (int i = num8; i < num10; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					int num11 = (j < num6) ? i : (i + 1);
					array2[j].sbyte_0[num11] = sbyte_1[num9++];
				}
			}
			return array2;
		}
	}
}
