using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class250
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

		private Class250(int int_1, sbyte[] sbyte_1)
		{
			int_0 = int_1;
			sbyte_0 = sbyte_1;
		}

		internal static Class250[] smethod_0(sbyte[] sbyte_1, GClass676 gclass676_0)
		{
			GClass676.Class269 @class = gclass676_0.method_6();
			int num = 0;
			GClass676.Class270[] array = @class.method_1();
			for (int i = 0; i < array.Length; i++)
			{
				num += array[i].method_0();
			}
			Class250[] array2 = new Class250[num];
			int num2 = 0;
			foreach (GClass676.Class270 class2 in array)
			{
				for (int i = 0; i < class2.method_0(); i++)
				{
					int num3 = class2.method_1();
					int num4 = @class.method_0() + num3;
					array2[num2++] = new Class250(num3, new sbyte[num4]);
				}
			}
			int num5 = array2[0].sbyte_0.Length;
			int num6 = num5 - @class.method_0();
			int num7 = num6 - 1;
			int num8 = 0;
			for (int i = 0; i < num7; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					array2[j].sbyte_0[i] = sbyte_1[num8++];
				}
			}
			bool flag;
			int num9 = (flag = (gclass676_0.method_0() == 24)) ? 8 : num2;
			for (int j = 0; j < num9; j++)
			{
				array2[j].sbyte_0[num6 - 1] = sbyte_1[num8++];
			}
			int num10 = array2[0].sbyte_0.Length;
			for (int i = num6; i < num10; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					int num11 = (!flag || j <= 7) ? i : (i - 1);
					array2[j].sbyte_0[num11] = sbyte_1[num8++];
				}
			}
			if (num8 != sbyte_1.Length)
			{
				throw new ArgumentException();
			}
			return array2;
		}
	}
}
