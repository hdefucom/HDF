using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal sealed class Class253 : GClass617
	{
		private class Class274 : GInterface51
		{
			public int imethod_0(object object_0, object object_1)
			{
				float num = ((GClass640)object_1).method_0() - ((GClass640)object_0).method_0();
				return ((double)num < 0.0) ? (-1) : (((double)num > 0.0) ? 1 : 0);
			}
		}

		private const float float_0 = 180f;

		private const float float_1 = 9f;

		private const float float_2 = 0.05f;

		private const float float_3 = 0.5f;

		private static readonly GClass680[] gclass680_0 = new GClass680[0];

		internal Class253(GClass679 gclass679_1)
			: base(gclass679_1)
		{
		}

		internal Class253(GClass679 gclass679_1, GInterface53 ginterface53_1)
			: base(gclass679_1, ginterface53_1)
		{
		}

		private GClass640[][] method_6()
		{
			ArrayList arrayList = vmethod_1();
			int count = arrayList.Count;
			if (count < 3)
			{
				throw GException25.smethod_0();
			}
			if (count == 3)
			{
				return new GClass640[1][]
				{
					new GClass640[3]
					{
						(GClass640)arrayList[0],
						(GClass640)arrayList[1],
						(GClass640)arrayList[2]
					}
				};
			}
			GClass654.smethod_0(arrayList, new Class274());
			ArrayList arrayList2 = ArrayList.Synchronized(new ArrayList(10));
			for (int i = 0; i < count - 2; i++)
			{
				GClass640 gClass = (GClass640)arrayList[i];
				if (gClass == null)
				{
					continue;
				}
				for (int j = i + 1; j < count - 1; j++)
				{
					GClass640 gClass2 = (GClass640)arrayList[j];
					if (gClass2 == null)
					{
						continue;
					}
					float num = (gClass.method_0() - gClass2.method_0()) / Math.Min(gClass.method_0(), gClass2.method_0());
					float num2 = Math.Abs(gClass.method_0() - gClass2.method_0());
					if (num2 > 0.5f && num >= 0.05f)
					{
						break;
					}
					for (int k = j + 1; k < count; k++)
					{
						GClass640 gClass3 = (GClass640)arrayList[k];
						if (gClass3 == null)
						{
							continue;
						}
						float num3 = (gClass2.method_0() - gClass3.method_0()) / Math.Min(gClass2.method_0(), gClass3.method_0());
						float num4 = Math.Abs(gClass2.method_0() - gClass3.method_0());
						if (num4 > 0.5f && num3 >= 0.05f)
						{
							break;
						}
						GClass640[] array = new GClass640[3]
						{
							gClass,
							gClass2,
							gClass3
						};
						GClass639.smethod_0(array);
						GClass680 gClass4 = new GClass680(array);
						float num5 = GClass639.smethod_1(gClass4.method_1(), gClass4.method_0());
						float num6 = GClass639.smethod_1(gClass4.method_2(), gClass4.method_0());
						float num7 = GClass639.smethod_1(gClass4.method_1(), gClass4.method_2());
						float num8 = (num5 + num7) / gClass.method_0() / 2f;
						if (num8 > 180f || num8 < 9f)
						{
							continue;
						}
						float num9 = Math.Abs((num5 - num7) / Math.Min(num5, num7));
						if (!(num9 >= 0.1f))
						{
							float num10 = (float)Math.Sqrt(num5 * num5 + num7 * num7);
							float num11 = Math.Abs((num6 - num10) / Math.Min(num6, num10));
							if (!(num11 >= 0.1f))
							{
								arrayList2.Add(array);
							}
						}
					}
				}
			}
			if (arrayList2.Count != 0)
			{
				GClass640[][] array2 = new GClass640[arrayList2.Count][];
				for (int l = 0; l < arrayList2.Count; l++)
				{
					array2[l] = (GClass640[])arrayList2[l];
				}
				return array2;
			}
			throw GException25.smethod_0();
		}

		public GClass680[] method_7(Hashtable hashtable_0)
		{
			bool flag = hashtable_0?.ContainsKey(GClass633.gclass633_3) ?? false;
			GClass679 gClass = vmethod_0();
			int num = gClass.method_1();
			int num2 = gClass.method_0();
			int num3 = (int)((float)num / 228f * 3f);
			if (num3 < 3 || flag)
			{
				num3 = 3;
			}
			int[] array = new int[5];
			for (int i = num3 - 1; i < num; i += num3)
			{
				array[0] = 0;
				array[1] = 0;
				array[2] = 0;
				array[3] = 0;
				array[4] = 0;
				int num4 = 0;
				for (int j = 0; j < num2; j++)
				{
					if (gClass.method_3(j, i))
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
							if (GClass617.smethod_1(array))
							{
								if (!vmethod_3(array, i, j))
								{
									do
									{
										j++;
									}
									while (j < num2 && !gClass.method_3(j, i));
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
				if (GClass617.smethod_1(array))
				{
					vmethod_3(array, i, num2);
				}
			}
			GClass640[][] array2 = method_6();
			ArrayList arrayList = ArrayList.Synchronized(new ArrayList(10));
			foreach (GClass640[] array3 in array2)
			{
				GClass639.smethod_0(array3);
				arrayList.Add(new GClass680(array3));
			}
			if (arrayList.Count == 0)
			{
				return gclass680_0;
			}
			GClass680[] array4 = new GClass680[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				array4[i] = (GClass680)arrayList[i];
			}
			return array4;
		}
	}
}
