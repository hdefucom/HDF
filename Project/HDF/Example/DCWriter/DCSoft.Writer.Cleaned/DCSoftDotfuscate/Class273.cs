using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class273
	{
		private GClass679 gclass679_0;

		private ArrayList arrayList_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private float float_0;

		private int[] int_4;

		private GInterface53 ginterface53_0;

		internal Class273(GClass679 gclass679_1, int int_5, int int_6, int int_7, int int_8, float float_1, GInterface53 ginterface53_1)
		{
			gclass679_0 = gclass679_1;
			arrayList_0 = ArrayList.Synchronized(new ArrayList(5));
			int_0 = int_5;
			int_1 = int_6;
			int_2 = int_7;
			int_3 = int_8;
			float_0 = float_1;
			int_4 = new int[3];
			ginterface53_0 = ginterface53_1;
		}

		internal GClass641 method_0()
		{
			int num = int_0;
			int num2 = int_3;
			int num3 = num + int_2;
			int num4 = int_1 + (num2 >> 1);
			int[] array = new int[3];
			int num5 = 0;
			GClass641 gClass;
			while (true)
			{
				if (num5 < num2)
				{
					int num6 = num4 + (((num5 & 1) == 0) ? (num5 + 1 >> 1) : (-(num5 + 1 >> 1)));
					array[0] = 0;
					array[1] = 0;
					array[2] = 0;
					int i;
					for (i = num; i < num3 && !gclass679_0.method_3(i, num6); i++)
					{
					}
					int num7 = 0;
					for (; i < num3; i++)
					{
						if (gclass679_0.method_3(i, num6))
						{
							switch (num7)
							{
							case 1:
								array[num7]++;
								break;
							case 2:
								if (method_1(array))
								{
									gClass = method_3(array, num6, i);
									if (gClass != null)
									{
										return gClass;
									}
								}
								array[0] = array[2];
								array[1] = 1;
								array[2] = 0;
								num7 = 1;
								break;
							default:
								array[++num7]++;
								break;
							}
						}
						else
						{
							if (num7 == 1)
							{
								num7++;
							}
							array[num7]++;
						}
					}
					if (method_1(array))
					{
						gClass = method_3(array, num6, num3);
						if (gClass != null)
						{
							break;
						}
					}
					num5++;
					continue;
				}
				if (arrayList_0.Count != 0)
				{
					return (GClass641)arrayList_0[0];
				}
				throw GException25.smethod_0();
			}
			return gClass;
		}

		private static float smethod_0(int[] int_5, int int_6)
		{
			return (float)(int_6 - int_5[2]) - (float)int_5[1] / 2f;
		}

		private bool method_1(int[] int_5)
		{
			float num = float_0;
			float num2 = num / 2f;
			int num3 = 0;
			while (true)
			{
				if (num3 < 3)
				{
					if (Math.Abs(num - (float)int_5[num3]) >= num2)
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			return false;
		}

		private float method_2(int int_5, int int_6, int int_7, int int_8)
		{
			GClass679 gClass = gclass679_0;
			int num = gClass.method_1();
			int[] array = int_4;
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			int num2 = int_5;
			while (num2 >= 0 && gClass.method_3(int_6, num2) && array[1] <= int_7)
			{
				array[1]++;
				num2--;
			}
			if (num2 < 0 || array[1] > int_7)
			{
				return float.NaN;
			}
			while (num2 >= 0 && !gClass.method_3(int_6, num2) && array[0] <= int_7)
			{
				array[0]++;
				num2--;
			}
			if (array[0] > int_7)
			{
				return float.NaN;
			}
			for (num2 = int_5 + 1; num2 < num && gClass.method_3(int_6, num2); num2++)
			{
				if (array[1] > int_7)
				{
					break;
				}
				array[1]++;
			}
			if (num2 == num || array[1] > int_7)
			{
				return float.NaN;
			}
			for (; num2 < num && !gClass.method_3(int_6, num2); num2++)
			{
				if (array[2] > int_7)
				{
					break;
				}
				array[2]++;
			}
			if (array[2] > int_7)
			{
				return float.NaN;
			}
			int num3 = array[0] + array[1] + array[2];
			if (5 * Math.Abs(num3 - int_8) >= 2 * int_8)
			{
				return float.NaN;
			}
			return method_1(array) ? smethod_0(array, num2) : float.NaN;
		}

		private GClass641 method_3(int[] int_5, int int_6, int int_7)
		{
			int int_8 = int_5[0] + int_5[1] + int_5[2];
			float num = smethod_0(int_5, int_7);
			float num2 = method_2(int_6, (int)num, 2 * int_5[1], int_8);
			if (!float.IsNaN(num2))
			{
				float num3 = (float)(int_5[0] + int_5[1] + int_5[2]) / 3f;
				int count = arrayList_0.Count;
				for (int i = 0; i < count; i++)
				{
					GClass641 gClass = (GClass641)arrayList_0[i];
					if (gClass.method_0(num3, num2, num))
					{
						return new GClass641(num, num2, num3);
					}
				}
				GClass639 gClass2 = new GClass641(num, num2, num3);
				arrayList_0.Add(gClass2);
				if (ginterface53_0 != null)
				{
					ginterface53_0.imethod_0(gClass2);
				}
			}
			return null;
		}
	}
}
