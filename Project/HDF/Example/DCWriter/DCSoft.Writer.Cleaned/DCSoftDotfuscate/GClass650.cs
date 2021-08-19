using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass650 : GClass649
	{
		public override GClass679 vmethod_0(GClass679 gclass679_0, int int_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15)
		{
			GClass677 gclass677_ = GClass677.smethod_0(float_0, float_1, float_2, float_3, float_4, float_5, float_6, float_7, float_8, float_9, float_10, float_11, float_12, float_13, float_14, float_15);
			return vmethod_1(gclass679_0, int_0, gclass677_);
		}

		public override GClass679 vmethod_1(GClass679 gclass679_0, int int_0, GClass677 gclass677_0)
		{
			GClass679 gClass = new GClass679(int_0);
			float[] array = new float[int_0 << 1];
			for (int i = 0; i < int_0; i++)
			{
				int num = array.Length;
				float num2 = (float)i + 0.5f;
				for (int j = 0; j < num; j += 2)
				{
					array[j] = (float)(j >> 1) + 0.5f;
					array[j + 1] = num2;
				}
				gclass677_0.method_0(array);
				GClass649.smethod_2(gclass679_0, array);
				try
				{
					for (int j = 0; j < num; j += 2)
					{
						if (gclass679_0.method_3((int)array[j], (int)array[j + 1]))
						{
							gClass.method_4(j >> 1, i);
						}
					}
				}
				catch (IndexOutOfRangeException)
				{
					throw GException25.smethod_0();
				}
			}
			return gClass;
		}
	}
}
