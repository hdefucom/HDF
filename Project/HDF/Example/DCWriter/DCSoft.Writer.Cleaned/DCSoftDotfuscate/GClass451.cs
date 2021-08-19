using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass451 : GClass450
	{
		private float float_0 = 0f;

		private float float_1 = 0f;

		private float float_2 = 0f;

		private float float_3 = 0f;

		public float method_0()
		{
			return float_0;
		}

		public void method_1(float float_4)
		{
			float_0 = float_4;
		}

		public float method_2()
		{
			return float_1;
		}

		public void method_3(float float_4)
		{
			float_1 = float_4;
		}

		public float method_4()
		{
			return float_2;
		}

		public void method_5(float float_4)
		{
			float_2 = float_4;
		}

		public float method_6()
		{
			return float_3;
		}

		public void method_7(float float_4)
		{
			float_3 = float_4;
		}

		public override RectangleF vmethod_3()
		{
			return new RectangleF(Math.Min(method_0(), method_2()), Math.Min(method_4(), method_6()), Math.Abs(method_0() - method_2()), Math.Abs(method_4() - method_6()));
		}

		public override void vmethod_4(RectangleF rectangleF_0)
		{
		}

		public override void vmethod_2(GEventArgs14 geventArgs14_0)
		{
			Pen pen = geventArgs14_0.method_2().method_15();
			if (pen != null)
			{
				geventArgs14_0.method_0().vmethod_5(pen, method_0(), method_4(), method_2(), method_6());
				pen.Dispose();
			}
			if (geventArgs14_0.method_3().method_0())
			{
				GClass521 gClass = vmethod_7(geventArgs14_0.method_3());
				if (gClass != null)
				{
					GClass528.smethod_1(gClass, geventArgs14_0);
				}
			}
		}
	}
}
