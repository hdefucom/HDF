using DCSoft.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass452 : GClass450
	{
		private RectangleF rectangleF_0 = RectangleF.Empty;

		private string string_0 = null;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		public override RectangleF vmethod_3()
		{
			return rectangleF_0;
		}

		public override void vmethod_4(RectangleF rectangleF_1)
		{
			rectangleF_0 = rectangleF_1;
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public override bool vmethod_0(float float_0, float float_1)
		{
			return rectangleF_0.Contains(float_0, float_1);
		}

		public override bool vmethod_1(RectangleF rectangleF_1)
		{
			return rectangleF_0.IntersectsWith(rectangleF_1);
		}

		public override GClass521 vmethod_7(GClass449 gclass449_0)
		{
			GClass521 gClass = null;
			return GClass528.smethod_0(rectangleF_0, gclass449_0, method_2(), method_4(), method_6(), 1);
		}

		public bool method_2()
		{
			return bool_0;
		}

		public void method_3(bool bool_3)
		{
			bool_0 = bool_3;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_3)
		{
			bool_1 = bool_3;
		}

		public bool method_6()
		{
			return bool_2;
		}

		public void method_7(bool bool_3)
		{
			bool_2 = bool_3;
		}

		public override void vmethod_2(GEventArgs14 geventArgs14_0)
		{
			Brush brush = geventArgs14_0.method_2().method_6();
			if (brush != null)
			{
				if (geventArgs14_0.method_2().RoundRadio > 0f)
				{
					using (GraphicsPath graphicsPath_ = DrawerUtil.CreateRoundRectangle(vmethod_3(), geventArgs14_0.method_2().RoundRadio))
					{
						geventArgs14_0.method_0().vmethod_3(brush, graphicsPath_);
					}
				}
				else
				{
					RectangleF rectangleF = RectangleF.Intersect(rectangleF_0, geventArgs14_0.method_1());
					if (!rectangleF.IsEmpty)
					{
						geventArgs14_0.method_0().vmethod_2(brush, rectangleF);
					}
				}
				brush.Dispose();
			}
			if (!string.IsNullOrEmpty(method_0()))
			{
				using (StringFormat stringFormat_ = geventArgs14_0.method_2().method_13())
				{
					using (SolidBrush brush_ = new SolidBrush(geventArgs14_0.method_2().Color))
					{
						geventArgs14_0.method_0().vmethod_7(method_0(), geventArgs14_0.method_2().Font.Value, brush_, vmethod_3(), stringFormat_);
					}
				}
			}
			if (rectangleF_0.IntersectsWith(geventArgs14_0.method_1()))
			{
				Pen pen = geventArgs14_0.method_2().method_15();
				if (pen != null)
				{
					if (geventArgs14_0.method_2().RoundRadio > 0f)
					{
						using (GraphicsPath graphicsPath_ = DrawerUtil.CreateRoundRectangle(vmethod_3(), geventArgs14_0.method_2().RoundRadio))
						{
							geventArgs14_0.method_0().vmethod_1(pen, graphicsPath_);
						}
					}
					else
					{
						geventArgs14_0.method_0().vmethod_0(pen, rectangleF_0);
					}
					pen.Dispose();
				}
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
