using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass617
	{
		private class Class254 : GInterface51
		{
			public virtual int imethod_0(object object_0, object object_1)
			{
				return ((GClass640)object_1).method_1() - ((GClass640)object_0).method_1();
			}
		}

		private const int int_0 = 2;

		protected internal const int int_1 = 3;

		protected internal const int int_2 = 57;

		private const int int_3 = 8;

		private GClass679 gclass679_0;

		private ArrayList arrayList_0;

		private bool bool_0;

		private int[] int_4;

		private GInterface53 ginterface53_0;

		protected internal virtual GClass679 vmethod_0()
		{
			return gclass679_0;
		}

		protected internal virtual ArrayList vmethod_1()
		{
			return arrayList_0;
		}

		private int[] method_0()
		{
			int_4[0] = 0;
			int_4[1] = 0;
			int_4[2] = 0;
			int_4[3] = 0;
			int_4[4] = 0;
			return int_4;
		}

		public GClass617(GClass679 gclass679_1)
			: this(gclass679_1, null)
		{
		}

		public GClass617(GClass679 gclass679_1, GInterface53 ginterface53_1)
		{
			gclass679_0 = gclass679_1;
			arrayList_0 = ArrayList.Synchronized(new ArrayList(10));
			int_4 = new int[5];
			ginterface53_0 = ginterface53_1;
		}

		internal virtual GClass680 vmethod_2(Hashtable hashtable_0)
		{
			bool flag = hashtable_0?.ContainsKey(GClass633.gclass633_3) ?? false;
			int num = gclass679_0.method_1();
			int num2 = gclass679_0.method_0();
			int num3 = 3 * num / 228;
			if (num3 < 3 || flag)
			{
				num3 = 3;
			}
			bool flag2 = false;
			int[] array = new int[5];
			for (int i = num3 - 1; i < num; i += num3)
			{
				if (flag2)
				{
					break;
				}
				array[0] = 0;
				array[1] = 0;
				array[2] = 0;
				array[3] = 0;
				array[4] = 0;
				int num4 = 0;
				for (int j = 0; j < num2; j++)
				{
					if (gclass679_0.method_3(j, i))
					{
						if ((num4 & 1) == 1)
						{
							num4++;
						}
						array[num4]++;
					}
					else if ((num4 & 1) == 0)
					{
						if (num4 == 4)
						{
							if (smethod_1(array))
							{
								if (vmethod_3(array, i, j))
								{
									num3 = 2;
									if (bool_0)
									{
										flag2 = method_4();
									}
									else
									{
										int num5 = method_3();
										if (num5 > array[2])
										{
											i += num5 - array[2] - num3;
											j = num2 - 1;
										}
									}
								}
								else
								{
									do
									{
										j++;
									}
									while (j < num2 && !gclass679_0.method_3(j, i));
									j--;
								}
								num4 = 0;
								array[0] = 0;
								array[1] = 0;
								array[2] = 0;
								array[3] = 0;
								array[4] = 0;
							}
							else
							{
								array[0] = array[2];
								array[1] = array[3];
								array[2] = array[4];
								array[3] = 1;
								array[4] = 0;
								num4 = 3;
							}
						}
						else
						{
							array[++num4]++;
						}
					}
					else
					{
						array[num4]++;
					}
				}
				if (smethod_1(array) && vmethod_3(array, i, num2))
				{
					num3 = array[0];
					if (bool_0)
					{
						flag2 = method_4();
					}
				}
			}
			GClass640[] array2 = method_5();
			GClass639.smethod_0(array2);
			return new GClass680(array2);
		}

		private static float smethod_0(int[] int_5, int int_6)
		{
			return (float)(int_6 - int_5[4] - int_5[3]) - (float)int_5[2] / 2f;
		}

		protected internal static bool smethod_1(int[] int_5)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num2 < 5)
				{
					int num3 = int_5[num2];
					if (num3 == 0)
					{
						break;
					}
					num += num3;
					num2++;
					continue;
				}
				if (num < 7)
				{
					return false;
				}
				int num4 = (num << 8) / 7;
				int num5 = num4 / 2;
				return Math.Abs(num4 - (int_5[0] << 8)) < num5 && Math.Abs(num4 - (int_5[1] << 8)) < num5 && Math.Abs(3 * num4 - (int_5[2] << 8)) < 3 * num5 && Math.Abs(num4 - (int_5[3] << 8)) < num5 && Math.Abs(num4 - (int_5[4] << 8)) < num5;
			}
			return false;
		}

		private float method_1(int int_5, int int_6, int int_7, int int_8)
		{
			GClass679 gClass = gclass679_0;
			int num = gClass.method_1();
			int[] array = method_0();
			int num2 = int_5;
			while (num2 >= 0 && gClass.method_3(int_6, num2))
			{
				array[2]++;
				num2--;
			}
			if (num2 < 0)
			{
				return float.NaN;
			}
			while (num2 >= 0 && !gClass.method_3(int_6, num2) && array[1] <= int_7)
			{
				array[1]++;
				num2--;
			}
			if (num2 < 0 || array[1] > int_7)
			{
				return float.NaN;
			}
			while (num2 >= 0 && gClass.method_3(int_6, num2) && array[0] <= int_7)
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
				array[2]++;
			}
			if (num2 == num)
			{
				return float.NaN;
			}
			for (; num2 < num && !gClass.method_3(int_6, num2); num2++)
			{
				if (array[3] >= int_7)
				{
					break;
				}
				array[3]++;
			}
			if (num2 == num || array[3] >= int_7)
			{
				return float.NaN;
			}
			for (; num2 < num && gClass.method_3(int_6, num2); num2++)
			{
				if (array[4] >= int_7)
				{
					break;
				}
				array[4]++;
			}
			if (array[4] >= int_7)
			{
				return float.NaN;
			}
			int num3 = array[0] + array[1] + array[2] + array[3] + array[4];
			if (5 * Math.Abs(num3 - int_8) >= 2 * int_8)
			{
				return float.NaN;
			}
			return smethod_1(array) ? smethod_0(array, num2) : float.NaN;
		}

		private float method_2(int int_5, int int_6, int int_7, int int_8)
		{
			GClass679 gClass = gclass679_0;
			int num = gClass.method_0();
			int[] array = method_0();
			int num2 = int_5;
			while (num2 >= 0 && gClass.method_3(num2, int_6))
			{
				array[2]++;
				num2--;
			}
			if (num2 < 0)
			{
				return float.NaN;
			}
			while (num2 >= 0 && !gClass.method_3(num2, int_6) && array[1] <= int_7)
			{
				array[1]++;
				num2--;
			}
			if (num2 < 0 || array[1] > int_7)
			{
				return float.NaN;
			}
			while (num2 >= 0 && gClass.method_3(num2, int_6) && array[0] <= int_7)
			{
				array[0]++;
				num2--;
			}
			if (array[0] > int_7)
			{
				return float.NaN;
			}
			for (num2 = int_5 + 1; num2 < num && gClass.method_3(num2, int_6); num2++)
			{
				array[2]++;
			}
			if (num2 == num)
			{
				return float.NaN;
			}
			for (; num2 < num && !gClass.method_3(num2, int_6); num2++)
			{
				if (array[3] >= int_7)
				{
					break;
				}
				array[3]++;
			}
			if (num2 == num || array[3] >= int_7)
			{
				return float.NaN;
			}
			for (; num2 < num && gClass.method_3(num2, int_6); num2++)
			{
				if (array[4] >= int_7)
				{
					break;
				}
				array[4]++;
			}
			if (array[4] >= int_7)
			{
				return float.NaN;
			}
			int num3 = array[0] + array[1] + array[2] + array[3] + array[4];
			if (5 * Math.Abs(num3 - int_8) >= int_8)
			{
				return float.NaN;
			}
			return smethod_1(array) ? smethod_0(array, num2) : float.NaN;
		}

		protected internal virtual bool vmethod_3(int[] int_5, int int_6, int int_7)
		{
			int num = int_5[0] + int_5[1] + int_5[2] + int_5[3] + int_5[4];
			float num2 = smethod_0(int_5, int_7);
			float num3 = method_1(int_6, (int)num2, int_5[2], num);
			if (!float.IsNaN(num3))
			{
				num2 = method_2((int)num2, (int)num3, int_5[2], num);
				if (!float.IsNaN(num2))
				{
					float num4 = (float)num / 7f;
					bool flag = false;
					int count = arrayList_0.Count;
					for (int i = 0; i < count; i++)
					{
						GClass640 gClass = (GClass640)arrayList_0[i];
						if (gClass.method_3(num4, num3, num2))
						{
							gClass.method_2();
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						GClass639 gClass2 = new GClass640(num2, num3, num4);
						arrayList_0.Add(gClass2);
						if (ginterface53_0 != null)
						{
							ginterface53_0.imethod_0(gClass2);
						}
					}
					return true;
				}
			}
			return false;
		}

		private int method_3()
		{
			int count = arrayList_0.Count;
			if (count <= 1)
			{
				return 0;
			}
			GClass640 gClass = null;
			int num = 0;
			GClass640 gClass2;
			while (true)
			{
				if (num < count)
				{
					gClass2 = (GClass640)arrayList_0[num];
					if (gClass2.method_1() >= 2)
					{
						if (gClass != null)
						{
							break;
						}
						gClass = gClass2;
					}
					num++;
					continue;
				}
				return 0;
			}
			bool_0 = true;
			return (int)(Math.Abs(gClass.vmethod_0() - gClass2.vmethod_0()) - Math.Abs(gClass.vmethod_1() - gClass2.vmethod_1())) / 2;
		}

		private bool method_4()
		{
			int num = 0;
			float num2 = 0f;
			int count = arrayList_0.Count;
			for (int i = 0; i < count; i++)
			{
				GClass640 gClass = (GClass640)arrayList_0[i];
				if (gClass.method_1() >= 2)
				{
					num++;
					num2 += gClass.method_0();
				}
			}
			if (num < 3)
			{
				return false;
			}
			float num3 = num2 / (float)count;
			float num4 = 0f;
			for (int i = 0; i < count; i++)
			{
				GClass640 gClass = (GClass640)arrayList_0[i];
				num4 += Math.Abs(gClass.method_0() - num3);
			}
			return num4 <= 0.05f * num2;
		}

		private GClass640[] method_5()
		{
			int count = arrayList_0.Count;
			if (count < 3)
			{
				throw GException25.smethod_0();
			}
			if (count > 3)
			{
				float num = 0f;
				for (int i = 0; i < count; i++)
				{
					num += ((GClass640)arrayList_0[i]).method_0();
				}
				float num2 = num / (float)count;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					if (arrayList_0.Count <= 3)
					{
						break;
					}
					GClass640 gClass = (GClass640)arrayList_0[i];
					if (Math.Abs(gClass.method_0() - num2) > 0.2f * num2)
					{
						arrayList_0.RemoveAt(i);
						i--;
					}
				}
			}
			if (arrayList_0.Count > 3)
			{
				GClass654.smethod_0(arrayList_0, new Class254());
				GClass634.smethod_12(arrayList_0, 3);
			}
			return new GClass640[3]
			{
				(GClass640)arrayList_0[0],
				(GClass640)arrayList_0[1],
				(GClass640)arrayList_0[2]
			};
		}
	}
}
