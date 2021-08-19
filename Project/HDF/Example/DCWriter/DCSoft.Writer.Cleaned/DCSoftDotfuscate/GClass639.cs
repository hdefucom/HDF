using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass639
	{
		private float float_0;

		private float float_1;

		public virtual float vmethod_0()
		{
			return float_0;
		}

		public virtual float vmethod_1()
		{
			return float_1;
		}

		public GClass639(float float_2, float float_3)
		{
			float_0 = float_2;
			float_1 = float_3;
		}

		public override bool Equals(object other)
		{
			if (other is GClass639)
			{
				GClass639 gClass = (GClass639)other;
				return float_0 == gClass.float_0 && float_1 == gClass.float_1;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(25);
			stringBuilder.Append('(');
			stringBuilder.Append(float_0);
			stringBuilder.Append(',');
			stringBuilder.Append(float_1);
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}

		public static void smethod_0(GClass639[] gclass639_0)
		{
			float num = smethod_1(gclass639_0[0], gclass639_0[1]);
			float num2 = smethod_1(gclass639_0[1], gclass639_0[2]);
			float num3 = smethod_1(gclass639_0[0], gclass639_0[2]);
			GClass639 gClass;
			GClass639 gClass2;
			GClass639 gClass3;
			if (num2 >= num && num2 >= num3)
			{
				gClass = gclass639_0[0];
				gClass2 = gclass639_0[1];
				gClass3 = gclass639_0[2];
			}
			else if (num3 >= num2 && num3 >= num)
			{
				gClass = gclass639_0[1];
				gClass2 = gclass639_0[0];
				gClass3 = gclass639_0[2];
			}
			else
			{
				gClass = gclass639_0[2];
				gClass2 = gclass639_0[0];
				gClass3 = gclass639_0[1];
			}
			if (smethod_2(gClass2, gClass, gClass3) < 0f)
			{
				GClass639 gClass4 = gClass2;
				gClass2 = gClass3;
				gClass3 = gClass4;
			}
			gclass639_0[0] = gClass2;
			gclass639_0[1] = gClass;
			gclass639_0[2] = gClass3;
		}

		public static float smethod_1(GClass639 gclass639_0, GClass639 gclass639_1)
		{
			float num = gclass639_0.vmethod_0() - gclass639_1.vmethod_0();
			float num2 = gclass639_0.vmethod_1() - gclass639_1.vmethod_1();
			return (float)Math.Sqrt(num * num + num2 * num2);
		}

		private static float smethod_2(GClass639 gclass639_0, GClass639 gclass639_1, GClass639 gclass639_2)
		{
			float num = gclass639_1.float_0;
			float num2 = gclass639_1.float_1;
			return (gclass639_2.float_0 - num) * (gclass639_0.float_1 - num2) - (gclass639_2.float_1 - num2) * (gclass639_0.float_0 - num);
		}
	}
}
