using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass649
	{
		private static GClass649 gclass649_0 = new GClass650();

		public static GClass649 smethod_0()
		{
			return gclass649_0;
		}

		public static void smethod_1(GClass649 gclass649_1)
		{
			if (gclass649_1 == null)
			{
				throw new ArgumentException();
			}
			gclass649_0 = gclass649_1;
		}

		public abstract GClass679 vmethod_0(GClass679 gclass679_0, int int_0, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6, float float_7, float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15);

		public virtual GClass679 vmethod_1(GClass679 gclass679_0, int int_0, GClass677 gclass677_0)
		{
			throw new NotSupportedException();
		}

		protected internal static void smethod_2(GClass679 gclass679_0, float[] float_0)
		{
			int num = gclass679_0.method_0();
			int num2 = gclass679_0.method_1();
			bool flag = true;
			int num3 = 0;
			while (true)
			{
				if (num3 < float_0.Length && flag)
				{
					int num4 = (int)float_0[num3];
					int num5 = (int)float_0[num3 + 1];
					if (num4 < -1 || num4 > num || num5 < -1 || num5 > num2)
					{
						break;
					}
					flag = false;
					if (num4 == -1)
					{
						float_0[num3] = 0f;
						flag = true;
					}
					else if (num4 == num)
					{
						float_0[num3] = num - 1;
						flag = true;
					}
					if (num5 == -1)
					{
						float_0[num3 + 1] = 0f;
						flag = true;
					}
					else if (num5 == num2)
					{
						float_0[num3 + 1] = num2 - 1;
						flag = true;
					}
					num3 += 2;
					continue;
				}
				flag = true;
				num3 = float_0.Length - 2;
				while (true)
				{
					if (num3 >= 0 && flag)
					{
						int num4 = (int)float_0[num3];
						int num5 = (int)float_0[num3 + 1];
						if (num4 < -1 || num4 > num || num5 < -1 || num5 > num2)
						{
							break;
						}
						flag = false;
						if (num4 == -1)
						{
							float_0[num3] = 0f;
							flag = true;
						}
						else if (num4 == num)
						{
							float_0[num3] = num - 1;
							flag = true;
						}
						if (num5 == -1)
						{
							float_0[num3 + 1] = 0f;
							flag = true;
						}
						else if (num5 == num2)
						{
							float_0[num3 + 1] = num2 - 1;
							flag = true;
						}
						num3 -= 2;
						continue;
					}
					return;
				}
				throw GException25.smethod_0();
			}
			throw GException25.smethod_0();
		}
	}
}
