using DCSoft.Drawing;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass472
	{
		private bool bool_0 = false;

		private string string_0 = null;

		private bool bool_1 = false;

		private bool bool_2 = false;

		private string string_1 = null;

		private string string_2 = Control.DefaultFont.Name;

		private float float_0 = Control.DefaultFont.Size;

		private bool bool_3 = false;

		private Color color_0 = Color.Black;

		private Color color_1 = Color.White;

		private GEnum88 genum88_0 = GEnum88.flag_0;

		private bool bool_4 = false;

		private bool bool_5 = false;

		private bool bool_6 = false;

		public bool method_0()
		{
			return bool_0;
		}

		public void method_1(bool bool_7)
		{
			bool_0 = bool_7;
		}

		public string method_2()
		{
			return string_0;
		}

		public void method_3(string string_3)
		{
			string_0 = string_3;
		}

		public bool method_4()
		{
			return bool_1;
		}

		public void method_5(bool bool_7)
		{
			bool_1 = bool_7;
		}

		public bool method_6()
		{
			return bool_2;
		}

		public void method_7(bool bool_7)
		{
			bool_2 = bool_7;
		}

		public string method_8()
		{
			return string_1;
		}

		public void method_9(string string_3)
		{
			string_1 = string_3;
		}

		public string method_10()
		{
			return string_2;
		}

		public void method_11(string string_3)
		{
			string_2 = string_3;
		}

		public float method_12()
		{
			return float_0;
		}

		public void method_13(float float_1)
		{
			float_0 = float_1;
		}

		public bool method_14()
		{
			return bool_3;
		}

		public void method_15(bool bool_7)
		{
			bool_3 = bool_7;
		}

		public static XFontValue smethod_0()
		{
			XFontValue xFontValue = new XFontValue(Control.DefaultFont);
			xFontValue.Bold = false;
			return xFontValue;
		}

		public Color method_16()
		{
			return color_0;
		}

		public void method_17(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_18()
		{
			return color_1;
		}

		public void method_19(Color color_2)
		{
			color_1 = color_2;
		}

		public GEnum88 method_20()
		{
			return genum88_0;
		}

		public void method_21(GEnum88 genum88_1)
		{
			genum88_0 = genum88_1;
		}

		public bool method_22()
		{
			return bool_4;
		}

		public void method_23(bool bool_7)
		{
			bool_4 = bool_7;
		}

		public bool method_24()
		{
			return bool_5;
		}

		public void method_25(bool bool_7)
		{
			bool_5 = bool_7;
		}

		public SizeF method_26(Graphics graphics_0)
		{
			return method_26(graphics_0);
		}

		public SizeF method_27(DCGraphics dcgraphics_0)
		{
			if (string.IsNullOrEmpty(method_8()))
			{
				return SizeF.Empty;
			}
			using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
			{
				drawStringFormatExt.FormatFlags = StringFormatFlags.NoWrap;
				XFontValue xFontValue = new XFontValue(method_10(), method_12());
				xFontValue.Bold = method_14();
				return dcgraphics_0.MeasureString(method_8(), xFontValue, 10000, drawStringFormatExt);
			}
		}

		public void method_28(Graphics graphics_0, RectangleF rectangleF_0, bool bool_7)
		{
			method_29(new DCGraphics(graphics_0), rectangleF_0, bool_7);
		}

		public void method_29(DCGraphics dcgraphics_0, RectangleF rectangleF_0, bool bool_7)
		{
			if (!string.IsNullOrEmpty(method_8()) && method_16().A != 0 && ((method_20() & GEnum88.flag_0) != GEnum88.flag_0 || method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_0)) && ((method_20() & GEnum88.flag_1) != GEnum88.flag_1 || method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_1)) && ((method_20() & GEnum88.flag_2) != GEnum88.flag_2 || method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_2)) && ((method_20() & GEnum88.flag_3) != GEnum88.flag_3 || method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_3)) && ((method_20() & GEnum88.flag_4) != GEnum88.flag_4 || method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_4)) && (method_20() & GEnum88.flag_5) == GEnum88.flag_5 && !method_33(dcgraphics_0, rectangleF_0, bool_7, GEnum88.flag_5))
			{
			}
		}

		public WatermarkInfo method_30()
		{
			if (method_6() && method_0())
			{
				WatermarkInfo watermarkInfo = new WatermarkInfo();
				watermarkInfo.Text = method_8();
				watermarkInfo.Angle = -45f;
				watermarkInfo.Font = new XFontValue(XFontValue.DefaultFontName, 40f);
				watermarkInfo.Alpha = 40;
				watermarkInfo.Type = WatermarkType.Text;
				return watermarkInfo;
			}
			return null;
		}

		public bool method_31()
		{
			return bool_6;
		}

		public void method_32(bool bool_7)
		{
			bool_6 = bool_7;
		}

		private bool method_33(DCGraphics dcgraphics_0, RectangleF rectangleF_0, bool bool_7, GEnum88 genum88_1)
		{
			if (string.IsNullOrEmpty(method_8()))
			{
				return false;
			}
			if (method_16().A == 0)
			{
				return false;
			}
			bool result = false;
			using (DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt())
			{
				if (!method_31())
				{
					drawStringFormatExt.FormatFlags = (StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
				}
				else
				{
					drawStringFormatExt.FormatFlags = StringFormatFlags.NoClip;
				}
				if (method_6())
				{
					switch (genum88_1)
					{
					case GEnum88.flag_3:
						drawStringFormatExt.Alignment = StringAlignment.Near;
						drawStringFormatExt.LineAlignment = StringAlignment.Far;
						break;
					case GEnum88.flag_0:
						drawStringFormatExt.Alignment = StringAlignment.Near;
						drawStringFormatExt.LineAlignment = StringAlignment.Near;
						break;
					case GEnum88.flag_1:
						drawStringFormatExt.Alignment = StringAlignment.Center;
						drawStringFormatExt.LineAlignment = StringAlignment.Near;
						break;
					case GEnum88.flag_2:
						drawStringFormatExt.Alignment = StringAlignment.Far;
						drawStringFormatExt.LineAlignment = StringAlignment.Near;
						break;
					case GEnum88.flag_5:
						drawStringFormatExt.Alignment = StringAlignment.Far;
						drawStringFormatExt.LineAlignment = StringAlignment.Far;
						break;
					case GEnum88.flag_4:
						drawStringFormatExt.Alignment = StringAlignment.Center;
						drawStringFormatExt.LineAlignment = StringAlignment.Far;
						break;
					}
					result = true;
				}
				else
				{
					drawStringFormatExt.Alignment = StringAlignment.Center;
					drawStringFormatExt.LineAlignment = StringAlignment.Center;
				}
				RectangleF mainRect = rectangleF_0;
				if (bool_7)
				{
					float num = GraphicsUnitConvert.Convert(5, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
					mainRect.Inflate(0f - num, 0f - num);
				}
				XFontValue xFontValue = new XFontValue(method_10(), method_12());
				xFontValue.Bold = method_14();
				SizeF sizeF = dcgraphics_0.MeasureString(method_8(), xFontValue, (int)rectangleF_0.Width, drawStringFormatExt);
				RectangleF rect = RectangleCommon.AlignRect(mainRect, sizeF.Width, sizeF.Height, drawStringFormatExt.Alignment, drawStringFormatExt.LineAlignment);
				if (method_18().A != 0)
				{
					dcgraphics_0.FillRectangle(method_18(), rect);
				}
				dcgraphics_0.DrawString(method_8(), xFontValue, method_16(), rect, drawStringFormatExt);
				if (!method_6())
				{
					dcgraphics_0.DrawRectangle(Color.Blue, rect);
				}
			}
			return result;
		}
	}
}
