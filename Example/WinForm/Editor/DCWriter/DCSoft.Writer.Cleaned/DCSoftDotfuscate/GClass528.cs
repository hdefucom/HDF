using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass528
	{
		public static GClass521 smethod_0(RectangleF rectangleF_0, GClass449 gclass449_0, bool bool_0, bool bool_1, bool bool_2, int int_0)
		{
			if (gclass449_0.method_2() == DragPointPositions.Inner)
			{
				rectangleF_0.Inflate((0f - gclass449_0.method_4()) / 2f, (0f - gclass449_0.method_4()) / 2f);
			}
			else if (gclass449_0.method_2() == DragPointPositions.Outer)
			{
				rectangleF_0.Inflate(gclass449_0.method_4() / 2f, gclass449_0.method_4() / 2f);
			}
			GClass521 gClass = new GClass521();
			switch (int_0)
			{
			case 1:
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Top, bool_0, 1));
				gClass.Add(new GClass520(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top, bool_0, 2));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Top, bool_0 && bool_1, 3));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Top + rectangleF_0.Height / 2f, bool_1, 4));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Bottom, bool_1 && bool_2, 5));
				gClass.Add(new GClass520(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Bottom, bool_2, 6));
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Bottom, bool_0, 7));
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f, bool_0, 8));
				break;
			case 2:
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Top, bool_0, 1));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Top, bool_0 && bool_1, 3));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Bottom, bool_1 && bool_2, 5));
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Bottom, bool_0, 7));
				break;
			case 3:
				gClass.Add(new GClass520(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Top, bool_0, 2));
				gClass.Add(new GClass520(rectangleF_0.Right, rectangleF_0.Top + rectangleF_0.Height / 2f, bool_1, 4));
				gClass.Add(new GClass520(rectangleF_0.Left + rectangleF_0.Width / 2f, rectangleF_0.Bottom, bool_2, 6));
				gClass.Add(new GClass520(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height / 2f, bool_0, 8));
				break;
			}
			return gClass;
		}

		public static void smethod_1(GClass521 gclass521_0, GEventArgs14 geventArgs14_0)
		{
			int num = 0;
			if (gclass521_0 == null)
			{
				throw new ArgumentNullException("points");
			}
			if (geventArgs14_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			foreach (GClass520 item in gclass521_0)
			{
				smethod_2(item, geventArgs14_0);
			}
		}

		public static void smethod_2(GClass520 gclass520_0, GEventArgs14 geventArgs14_0)
		{
			int num = 0;
			if (gclass520_0 == null)
			{
				throw new ArgumentNullException("point");
			}
			if (geventArgs14_0 == null)
			{
				throw new ArgumentNullException("args");
			}
			RectangleF rectangleF = new RectangleF(gclass520_0.method_0() - geventArgs14_0.method_3().method_4() / 2f, gclass520_0.method_2() - geventArgs14_0.method_3().method_4() / 2f, geventArgs14_0.method_3().method_4(), geventArgs14_0.method_3().method_4());
			if (geventArgs14_0.method_1().IntersectsWith(rectangleF))
			{
				if (gclass520_0.method_4())
				{
					geventArgs14_0.method_0().vmethod_2(Brushes.Blue, rectangleF);
					geventArgs14_0.method_0().vmethod_0(Pens.White, rectangleF);
				}
				else
				{
					geventArgs14_0.method_0().vmethod_2(Brushes.White, rectangleF);
					geventArgs14_0.method_0().vmethod_0(Pens.Black, rectangleF);
				}
			}
		}
	}
}
