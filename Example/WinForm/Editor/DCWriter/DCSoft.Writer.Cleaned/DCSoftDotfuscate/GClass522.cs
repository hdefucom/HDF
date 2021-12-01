using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass522
	{
		private RectangleF rectangleF_0 = RectangleF.Empty;

		private XFontValue xfontValue_0 = new XFontValue();

		private Color color_0 = SystemColors.ControlText;

		private Color color_1 = Color.Empty;

		private string string_0 = null;

		private GEnum90 genum90_0 = GEnum90.const_0;

		private bool bool_0 = true;

		private bool bool_1 = false;

		private XImageValue ximageValue_0 = null;

		private XImageValue ximageValue_1 = null;

		private XImageValue ximageValue_2 = null;

		private static Bitmap bitmap_0 = null;

		private static Bitmap bitmap_1 = null;

		private static Bitmap bitmap_2 = null;

		public RectangleF method_0()
		{
			return rectangleF_0;
		}

		public void method_1(RectangleF rectangleF_1)
		{
			rectangleF_0 = rectangleF_1;
		}

		public XFontValue method_2()
		{
			return xfontValue_0;
		}

		public void method_3(XFontValue xfontValue_1)
		{
			xfontValue_0 = xfontValue_1;
		}

		public Color method_4()
		{
			return color_0;
		}

		public void method_5(Color color_2)
		{
			color_0 = color_2;
		}

		public Color method_6()
		{
			return color_1;
		}

		public void method_7(Color color_2)
		{
			color_1 = color_2;
		}

		public string method_8()
		{
			return string_0;
		}

		public void method_9(string string_1)
		{
			string_0 = string_1;
		}

		public GEnum90 method_10()
		{
			return genum90_0;
		}

		public void method_11(GEnum90 genum90_1)
		{
			genum90_0 = genum90_1;
		}

		public bool method_12()
		{
			return bool_0;
		}

		public void method_13(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public bool method_14()
		{
			return bool_1;
		}

		public void method_15(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public XImageValue method_16()
		{
			return ximageValue_0;
		}

		public void method_17(XImageValue ximageValue_3)
		{
			ximageValue_0 = ximageValue_3;
		}

		public XImageValue method_18()
		{
			return ximageValue_1;
		}

		public void method_19(XImageValue ximageValue_3)
		{
			ximageValue_1 = ximageValue_3;
		}

		public XImageValue method_20()
		{
			return ximageValue_2;
		}

		public void method_21(XImageValue ximageValue_3)
		{
			ximageValue_2 = ximageValue_3;
		}

		public SizeF method_22(DCGraphics dcgraphics_0)
		{
			SizeF result = new SizeF(10f, 10f);
			bool flag = false;
			if (method_16() != null && method_16().HasContent)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(method_16().Width, method_16().Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				result.Width = sizeF.Width;
				result.Height = sizeF.Height;
				flag = true;
			}
			if (method_18() != null && method_18().HasContent)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(method_18().Width, method_18().Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				result.Width = Math.Max(result.Width, sizeF.Width);
				result.Height = Math.Max(result.Height, sizeF.Height);
				flag = true;
			}
			if (method_20() != null && method_20().HasContent)
			{
				SizeF sizeF = GraphicsUnitConvert.Convert(new SizeF(method_20().Width, method_20().Height), GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				result.Width = Math.Max(result.Width, sizeF.Width);
				result.Height = Math.Max(result.Height, sizeF.Height);
				flag = true;
			}
			if (!flag && !string.IsNullOrEmpty(method_8()))
			{
				SizeF sizeF = dcgraphics_0.MeasureString(method_8(), method_2());
				float val = sizeF.Width + (float)GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				result.Width = Math.Max(val, sizeF.Width);
				result.Height = sizeF.Height + (float)GraphicsUnitConvert.Convert(5, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			}
			return result;
		}

		public void method_23(DCGraphics dcgraphics_0)
		{
			XImageValue xImageValue = null;
			if (method_10() == GEnum90.const_0)
			{
				xImageValue = method_16();
			}
			else if (method_10() == GEnum90.const_2)
			{
				xImageValue = method_18();
			}
			else if (method_10() == GEnum90.const_1)
			{
				xImageValue = method_20();
			}
			if (xImageValue != null && xImageValue.HasContent)
			{
				dcgraphics_0.DrawImage(xImageValue.Value, method_0());
				return;
			}
			if (bitmap_1 == null)
			{
				bitmap_1 = DrawingResources.ButtonBackgroundDown;
				bitmap_2 = DrawingResources.ButtonBackgroundOver;
				bitmap_0 = DrawingResources.ButtonBackgroundUp;
			}
			float radio = GraphicsUnitConvert.Convert(5, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			if (method_6().A == 0)
			{
				if (method_12())
				{
					Image image_ = null;
					if (method_10() == GEnum90.const_0)
					{
						image_ = bitmap_0;
					}
					else if (method_10() == GEnum90.const_2)
					{
						image_ = bitmap_1;
					}
					else if (method_10() == GEnum90.const_1)
					{
						image_ = bitmap_2;
					}
					dcgraphics_0.FillRectangle(SystemColors.ControlLight, method_0());
					InterpolationMode interpolationMode = dcgraphics_0.InterpolationMode;
					PixelOffsetMode pixelOffsetMode = dcgraphics_0.PixelOffsetMode;
					dcgraphics_0.InterpolationMode = InterpolationMode.NearestNeighbor;
					dcgraphics_0.PixelOffsetMode = PixelOffsetMode.None;
					dcgraphics_0.DrawImage(image_, method_0());
					dcgraphics_0.PixelOffsetMode = PixelOffsetMode.Half;
					dcgraphics_0.DrawImage(image_, method_0());
					dcgraphics_0.InterpolationMode = interpolationMode;
					dcgraphics_0.PixelOffsetMode = pixelOffsetMode;
				}
				else
				{
					dcgraphics_0.FillRoundRectangle(SystemColors.Control, method_0().Left, method_0().Top, method_0().Width, method_0().Height, radio);
				}
			}
			else
			{
				dcgraphics_0.FillRoundRectangle(method_6(), method_0().Left, method_0().Top, method_0().Width, method_0().Height, radio);
			}
			Color empty = Color.Empty;
			empty = ((!method_14()) ? Color.FromArgb(112, 112, 112) : Color.FromArgb(60, 127, 177));
			dcgraphics_0.DrawRoundRectangle(new XPenStyle(empty), method_0().Left, method_0().Top, method_0().Width, method_0().Height, radio);
			if (!string.IsNullOrEmpty(method_8()))
			{
				DrawStringFormatExt drawStringFormatExt = new DrawStringFormatExt();
				drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
				drawStringFormatExt.Alignment = StringAlignment.Center;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				RectangleF bounds = method_0();
				float num = GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				bounds.Offset(num, 0f);
				bounds.Width -= num * 2f;
				SizeF sizeF = dcgraphics_0.MeasureString(method_8(), method_2(), 10000, drawStringFormatExt);
				bounds.Y = Math.Max(method_0().Top, method_0().Top + (method_0().Height - sizeF.Height) / 2f);
				bounds.Height = Math.Min(sizeF.Height + 4f, method_0().Height);
				bounds.X = Math.Max(method_0().Left, method_0().Left + (method_0().Width - sizeF.Width) / 2f);
				bounds.Width = sizeF.Width;
				drawStringFormatExt.LineAlignment = StringAlignment.Center;
				drawStringFormatExt.Font = method_2();
				drawStringFormatExt.SetBounds(bounds);
				if (!method_12())
				{
					drawStringFormatExt.Color = Color.DarkGray;
					dcgraphics_0.method_2(method_8(), drawStringFormatExt);
				}
				else
				{
					drawStringFormatExt.Color = method_4();
					dcgraphics_0.method_2(method_8(), drawStringFormatExt);
				}
			}
		}

		public static StringFormat smethod_0()
		{
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			return stringFormat;
		}

		public static DrawStringFormatExt smethod_1()
		{
			DrawStringFormatExt drawStringFormatExt = DrawStringFormatExt.GenericTypographic.Clone();
			drawStringFormatExt.FormatFlags = (StringFormatFlags.FitBlackBox | StringFormatFlags.MeasureTrailingSpaces);
			drawStringFormatExt.Alignment = StringAlignment.Center;
			drawStringFormatExt.LineAlignment = StringAlignment.Center;
			return drawStringFormatExt;
		}
	}
}
