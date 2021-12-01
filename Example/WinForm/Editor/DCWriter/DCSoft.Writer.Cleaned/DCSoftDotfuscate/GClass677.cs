using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass677
	{
		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		private float float_4;

		private float float_5;

		private float float_6;

		private float float_7;

		private float float_8;

		private GClass677(float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15, float float_16, float float_17)
		{
			float_0 = float_9;
			float_1 = float_12;
			float_2 = float_15;
			float_3 = float_10;
			float_4 = float_13;
			float_5 = float_16;
			float_6 = float_11;
			float_7 = float_14;
			float_8 = float_17;
		}

		public static GClass677 smethod_0(float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15, float float_16, float float_17, float float_18, float float_19, float float_20, float float_21, float float_22, float float_23, float float_24)
		{
			GClass677 gclass677_ = smethod_2(float_9, float_10, float_11, float_12, float_13, float_14, float_15, float_16);
			GClass677 gClass = smethod_1(float_17, float_18, float_19, float_20, float_21, float_22, float_23, float_24);
			return gClass.method_3(gclass677_);
		}

		public void method_0(float[] float_9)
		{
			int num = float_9.Length;
			float num2 = float_0;
			float num3 = float_1;
			float num4 = float_2;
			float num5 = float_3;
			float num6 = float_4;
			float num7 = float_5;
			float num8 = float_6;
			float num9 = float_7;
			float num10 = float_8;
			for (int i = 0; i < num; i += 2)
			{
				float num11 = float_9[i];
				float num12 = float_9[i + 1];
				float num13 = num4 * num11 + num7 * num12 + num10;
				float_9[i] = (num2 * num11 + num5 * num12 + num8) / num13;
				float_9[i + 1] = (num3 * num11 + num6 * num12 + num9) / num13;
			}
		}

		public void method_1(float[] float_9, float[] float_10)
		{
			int num = float_9.Length;
			for (int i = 0; i < num; i++)
			{
				float num2 = float_9[i];
				float num3 = float_10[i];
				float num4 = float_2 * num2 + float_5 * num3 + float_8;
				float_9[i] = (float_0 * num2 + float_3 * num3 + float_6) / num4;
				float_10[i] = (float_1 * num2 + float_4 * num3 + float_7) / num4;
			}
		}

		public static GClass677 smethod_1(float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15, float float_16)
		{
			float num = float_16 - float_14;
			float num2 = float_10 - float_12 + float_14 - float_16;
			if (num == 0f && num2 == 0f)
			{
				return new GClass677(float_11 - float_9, float_13 - float_11, float_9, float_12 - float_10, float_14 - float_12, float_10, 0f, 0f, 1f);
			}
			float num3 = float_11 - float_13;
			float num4 = float_15 - float_13;
			float num5 = float_9 - float_11 + float_13 - float_15;
			float num6 = float_12 - float_14;
			float num7 = num3 * num - num4 * num6;
			float num8 = (num5 * num - num4 * num2) / num7;
			float num9 = (num3 * num2 - num5 * num6) / num7;
			return new GClass677(float_11 - float_9 + num8 * float_11, float_15 - float_9 + num9 * float_15, float_9, float_12 - float_10 + num8 * float_12, float_16 - float_10 + num9 * float_16, float_10, num8, num9, 1f);
		}

		public static GClass677 smethod_2(float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15, float float_16)
		{
			return smethod_1(float_9, float_10, float_11, float_12, float_13, float_14, float_15, float_16).method_2();
		}

		internal GClass677 method_2()
		{
			return new GClass677(float_4 * float_8 - float_5 * float_7, float_5 * float_6 - float_3 * float_8, float_3 * float_7 - float_4 * float_6, float_2 * float_7 - float_1 * float_8, float_0 * float_8 - float_2 * float_6, float_1 * float_6 - float_0 * float_7, float_1 * float_5 - float_2 * float_4, float_2 * float_3 - float_0 * float_5, float_0 * float_4 - float_1 * float_3);
		}

		internal GClass677 method_3(GClass677 gclass677_0)
		{
			return new GClass677(float_0 * gclass677_0.float_0 + float_3 * gclass677_0.float_1 + float_6 * gclass677_0.float_2, float_0 * gclass677_0.float_3 + float_3 * gclass677_0.float_4 + float_6 * gclass677_0.float_5, float_0 * gclass677_0.float_6 + float_3 * gclass677_0.float_7 + float_6 * gclass677_0.float_8, float_1 * gclass677_0.float_0 + float_4 * gclass677_0.float_1 + float_7 * gclass677_0.float_2, float_1 * gclass677_0.float_3 + float_4 * gclass677_0.float_4 + float_7 * gclass677_0.float_5, float_1 * gclass677_0.float_6 + float_4 * gclass677_0.float_7 + float_7 * gclass677_0.float_8, float_2 * gclass677_0.float_0 + float_5 * gclass677_0.float_1 + float_8 * gclass677_0.float_2, float_2 * gclass677_0.float_3 + float_5 * gclass677_0.float_4 + float_8 * gclass677_0.float_5, float_2 * gclass677_0.float_6 + float_5 * gclass677_0.float_7 + float_8 * gclass677_0.float_8);
		}
	}
}
