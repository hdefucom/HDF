using DCSoft.Drawing;
using DCSoft.Writer.MedicalExpression;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass20
	{
		private MedicalExpressionValueList medicalExpressionValueList_0 = new MedicalExpressionValueList();

		private int int_0 = -1;

		private XFontValue xfontValue_0 = new XFontValue();

		private Color color_0 = Color.Black;

		private DCMedicalExpressionStyle dcmedicalExpressionStyle_0 = DCMedicalExpressionStyle.FourValues;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		private static DrawStringFormatExt drawStringFormatExt_1 = null;

		public MedicalExpressionValueList method_0()
		{
			if (medicalExpressionValueList_0 == null)
			{
				medicalExpressionValueList_0 = new MedicalExpressionValueList();
			}
			return medicalExpressionValueList_0;
		}

		public void method_1(MedicalExpressionValueList medicalExpressionValueList_1)
		{
			medicalExpressionValueList_0 = medicalExpressionValueList_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}

		public XFontValue method_4()
		{
			return xfontValue_0;
		}

		public void method_5(XFontValue xfontValue_1)
		{
			xfontValue_0 = xfontValue_1;
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_1)
		{
			color_0 = color_1;
		}

		public DCMedicalExpressionStyle method_8()
		{
			return dcmedicalExpressionStyle_0;
		}

		public void method_9(DCMedicalExpressionStyle dcmedicalExpressionStyle_1)
		{
			dcmedicalExpressionStyle_0 = dcmedicalExpressionStyle_1;
		}

		public SizeF method_10(DCGraphics dcgraphics_0)
		{
			return method_12(dcgraphics_0, RectangleF.Empty, bool_0: true);
		}

		public void method_11(DCGraphics dcgraphics_0, RectangleF rectangleF_0)
		{
			method_12(dcgraphics_0, rectangleF_0, bool_0: false);
		}

		private SizeF method_12(DCGraphics dcgraphics_0, RectangleF rectangleF_0, bool bool_0)
		{
			int num = 9;
			float num2 = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			PointF pointF2;
			if (method_8() == DCMedicalExpressionStyle.FourValues)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width) + sizeF4.Width;
				empty.Height = (sizeF2.Height + sizeF3.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top + num2 * 2f, Math.Max(sizeF2.Width, sizeF3.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Bottom - sizeF3.Height, Math.Max(sizeF2.Width, sizeF3.Width), sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Right - sizeF4.Width, rectangleF.Top, sizeF4.Width, rectangleF.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + sizeF.Width, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Right - sizeF4.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.FourValues1 || method_8() == DCMedicalExpressionStyle.FourValuesGeneral)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = Math.Max(Math.Max(sizeF.Width, sizeF2.Width), Math.Max(sizeF3.Width, sizeF4.Width)) * 2.1f;
				empty.Height = (sizeF.Height + sizeF3.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF.Width) / 2f, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF2.Width) / 2f, rectangleF.Top + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF2.Width, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF3.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF3.Height) / 2f, sizeF3.Width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF4.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF4.Height) / 2f, sizeF4.Width, sizeF4.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.FourValues2)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = Math.Max(Math.Max(sizeF.Width, sizeF3.Width), Math.Max(sizeF2.Width, sizeF4.Width)) * 3f;
				empty.Height = (sizeF2.Height + sizeF4.Height) * 1.5f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF.Width) / 2f, rectangleF.Top + rectangleF.Height / 5f * 2f, sizeF.Width, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width - sizeF2.Width) / 2f, rectangleF.Top + 5f, sizeF2.Width, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF3.Width) / 2f, rectangleF.Top + rectangleF.Height / 5f * 2f, sizeF3.Width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width - sizeF4.Width) / 2f, rectangleF.Top + rectangleF.Height - sizeF4.Height, sizeF4.Width, sizeF4.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left, rectangleF.Top, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + rectangleF.Width, rectangleF.Top, rectangleF.Left, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.ThreeValues)
			{
				SizeF sizeF = method_13(method_0().Value1 + "/", dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width);
				empty.Height = (sizeF2.Height + sizeF3.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				dcgraphics_0.DrawString(method_0().Value1 + "/", method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), smethod_0());
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top + num2 * 2f, Math.Max(sizeF2.Width, sizeF3.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Bottom - sizeF3.Height, Math.Max(sizeF2.Width, sizeF3.Width), sizeF3.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + sizeF.Width, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width), rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.Pupil)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF sizeF5 = method_13(method_0().Value5, dcgraphics_0);
				SizeF sizeF6 = method_13(method_0().Value6, dcgraphics_0);
				SizeF sizeF7 = method_13(method_0().Value7, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				float[] array = new float[7]
				{
					sizeF.Width,
					sizeF2.Width,
					sizeF3.Width,
					sizeF4.Width,
					sizeF5.Width,
					sizeF6.Width,
					sizeF7.Width
				};
				Array.Sort(array);
				empty.Width = array[array.Length - 1] * 3.01f;
				float[] array2 = new float[7]
				{
					sizeF.Height,
					sizeF2.Height,
					sizeF3.Height,
					sizeF4.Height,
					sizeF5.Height,
					sizeF6.Height,
					sizeF7.Height
				};
				Array.Sort(array2);
				empty.Height = array2[array.Length - 1] * 3.01f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width) + sizeF4.Width, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), rectangleF.Top, sizeF4.Width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value5))
				{
					dcgraphics_0.DrawString(method_0().Value5, method_4(), method_6(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width) + sizeF4.Width, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value6))
				{
					dcgraphics_0.DrawString(method_0().Value6, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Bottom - sizeF6.Height, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), sizeF6.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value7))
				{
					dcgraphics_0.DrawString(method_0().Value7, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF4.Width + Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), rectangleF.Bottom - sizeF7.Height, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), sizeF7.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.LightPositioning)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF sizeF5 = method_13(method_0().Value5, dcgraphics_0);
				SizeF sizeF6 = method_13(method_0().Value6, dcgraphics_0);
				SizeF sizeF7 = method_13(method_0().Value7, dcgraphics_0);
				SizeF sizeF8 = method_13(method_0().Value8, dcgraphics_0);
				SizeF sizeF9 = method_13(method_0().Value9, dcgraphics_0);
				float num5 = Math.Max(Math.Max(sizeF.Width, sizeF4.Width), sizeF7.Width);
				float num6 = Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF8.Width);
				float width = Math.Max(Math.Max(sizeF3.Width, sizeF6.Width), sizeF9.Width);
				SizeF empty = SizeF.Empty;
				float[] array = new float[9]
				{
					sizeF.Width,
					sizeF2.Width,
					sizeF3.Width,
					sizeF4.Width,
					sizeF5.Width,
					sizeF6.Width,
					sizeF7.Width,
					sizeF8.Width,
					sizeF9.Width
				};
				Array.Sort(array);
				empty.Width = array[array.Length - 1] * 3.01f;
				float[] array2 = new float[9]
				{
					sizeF.Height,
					sizeF2.Height,
					sizeF3.Height,
					sizeF4.Height,
					sizeF5.Height,
					sizeF6.Height,
					sizeF7.Height,
					sizeF8.Height,
					sizeF9.Height
				};
				Array.Sort(array2);
				empty.Height = array2[array.Length - 1] * 3.01f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num6, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Top, width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value5))
				{
					dcgraphics_0.DrawString(method_0().Value5, method_4(), method_6(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num6, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value6))
				{
					dcgraphics_0.DrawString(method_0().Value6, method_4(), method_6(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Top, width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value7))
				{
					dcgraphics_0.DrawString(method_0().Value7, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Bottom - sizeF7.Height, num5, sizeF7.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value8))
				{
					dcgraphics_0.DrawString(method_0().Value8, method_4(), method_6(), new RectangleF(rectangleF.Left + num5, rectangleF.Bottom - sizeF8.Height, num6, sizeF8.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value9))
				{
					dcgraphics_0.DrawString(method_0().Value9, method_4(), method_6(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Bottom - sizeF9.Height, width, sizeF9.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.FetalHeart)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF sizeF5 = method_13(method_0().Value5, dcgraphics_0);
				SizeF sizeF6 = method_13(method_0().Value6, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				float[] array3 = new float[3]
				{
					sizeF.Width,
					sizeF3.Width,
					sizeF5.Width
				};
				Array.Sort(array3);
				float[] array4 = new float[3]
				{
					sizeF2.Width,
					sizeF4.Width,
					sizeF6.Width
				};
				Array.Sort(array4);
				empty.Width = array3[array3.Length - 1] + array4[array4.Length - 1] + 40f;
				float[] array2 = new float[6]
				{
					sizeF.Height,
					sizeF2.Height,
					sizeF3.Height,
					sizeF4.Height,
					sizeF5.Height,
					sizeF6.Height
				};
				Array.Sort(array2);
				empty.Height = array2[array2.Length - 1] * 3.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				float num7 = rectangleF.Top + rectangleF.Height / 2f;
				float left = rectangleF.Left;
				float right = rectangleF.Right;
				float float_ = rectangleF.Left + 10f;
				float float_2 = rectangleF.Left + 10f + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width);
				float num8 = rectangleF.Right - 10f - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width);
				float float_3 = rectangleF.Right - 10f;
				XPenStyle xPenStyle = new XPenStyle(method_6());
				xPenStyle.Width *= 2f;
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawLine(xPenStyle, left, num7, float_, num7);
					dcgraphics_0.DrawLine(xPenStyle, float_2, num7, num8, num7);
				}
				else
				{
					dcgraphics_0.DrawLine(xPenStyle, left, num7, num8, num7);
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawLine(xPenStyle, float_3, num7, right, num7);
				}
				else
				{
					dcgraphics_0.DrawLine(xPenStyle, num8, num7, right, num7);
				}
				dcgraphics_0.DrawLine(method_6(), (rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width) + rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width)) / 2f, rectangleF.Top, (rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width) + rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width)) / 2f, rectangleF.Top + rectangleF.Height);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left + 10f, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + 10f, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value5))
				{
					dcgraphics_0.DrawString(method_0().Value5, method_4(), method_6(), new RectangleF(rectangleF.Left + 10f, rectangleF.Bottom - sizeF5.Height, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), sizeF5.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value6))
				{
					dcgraphics_0.DrawString(method_0().Value6, method_4(), method_6(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Bottom - sizeF6.Height, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), sizeF6.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.PermanentTeethBitmap)
			{
				string text = method_0().Value1 + method_0().Value2 + method_0().Value3 + method_0().Value4 + method_0().Value5 + method_0().Value6 + method_0().Value7 + method_0().Value8;
				string text2 = method_0().Value9 + method_0().Value10 + method_0().Value11 + method_0().Value12 + method_0().Value13 + method_0().Value14 + method_0().Value15 + method_0().Value16;
				string text3 = method_0().Value17 + method_0().Value18 + method_0().Value19 + method_0().Value20 + method_0().Value21 + method_0().Value22 + method_0().Value23 + method_0().Value24;
				string text4 = method_0().Value25 + method_0().Value26 + method_0().Value27 + method_0().Value28 + method_0().Value29 + method_0().Value30 + method_0().Value31 + method_0().Value32;
				float num9 = method_17(text, dcgraphics_0);
				float num10 = method_17(text2, dcgraphics_0);
				float num11 = method_17(text3, dcgraphics_0);
				float num12 = method_17(text4, dcgraphics_0);
				SizeF sizeF = method_14("A", dcgraphics_0);
				SizeF sizeF2 = method_14("A", dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = Math.Max(Math.Max(num9, num10), Math.Max(num11, num12)) * 2.2f;
				empty.Height = (sizeF.Height + sizeF2.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(text))
				{
					List<string> list = method_18(text);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item in list)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item, dcgraphics_0);
							dcgraphics_0.DrawString(item, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num9) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item, dcgraphics_0);
							dcgraphics_0.DrawString(item, method_16(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num9) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text2))
				{
					List<string> list2 = method_18(text2);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item2 in list2)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item2, dcgraphics_0);
							dcgraphics_0.DrawString(item2, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num10) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item2, dcgraphics_0);
							dcgraphics_0.DrawString(item2, method_16(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num10) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					List<string> list3 = method_18(text3);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item3 in list3)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item3, dcgraphics_0);
							dcgraphics_0.DrawString(item3, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num11) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item3, dcgraphics_0);
							dcgraphics_0.DrawString(item3, method_16(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num11) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text4))
				{
					List<string> list4 = method_18(text4);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item4 in list4)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item4, dcgraphics_0);
							dcgraphics_0.DrawString(item4, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num12) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item4, dcgraphics_0);
							dcgraphics_0.DrawString(item4, method_16(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num12) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				using (Pen pen_ = new Pen(method_6()))
				{
					dcgraphics_0.DrawLine(pen_, rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height / 2f);
				}
				using (Pen pen_ = new Pen(method_6()))
				{
					dcgraphics_0.DrawLine(pen_, rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height);
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.DeciduousTeech)
			{
				string text = method_0().Value1 + method_0().Value2 + method_0().Value3 + method_0().Value4 + method_0().Value5;
				string text2 = method_0().Value6 + method_0().Value7 + method_0().Value8 + method_0().Value9 + method_0().Value10;
				string text3 = method_0().Value11 + method_0().Value12 + method_0().Value13 + method_0().Value14 + method_0().Value15;
				string text4 = method_0().Value16 + method_0().Value17 + method_0().Value18 + method_0().Value19 + method_0().Value20;
				float num9 = method_17(text, dcgraphics_0);
				float num10 = method_17(text2, dcgraphics_0);
				float num11 = method_17(text3, dcgraphics_0);
				float num12 = method_17(text4, dcgraphics_0);
				SizeF sizeF = method_14("A", dcgraphics_0);
				SizeF sizeF2 = method_14("A", dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = Math.Max(Math.Max(num9, num10), Math.Max(num11, num12)) * 2.2f;
				empty.Height = (sizeF.Height + sizeF2.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(text))
				{
					List<string> list = method_18(text);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item5 in list)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item5, dcgraphics_0);
							dcgraphics_0.DrawString(item5, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num9) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item5, dcgraphics_0);
							dcgraphics_0.DrawString(item5, method_16(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num9) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text2))
				{
					List<string> list2 = method_18(text2);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item6 in list2)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item6, dcgraphics_0);
							dcgraphics_0.DrawString(item6, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num10) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item6, dcgraphics_0);
							dcgraphics_0.DrawString(item6, method_16(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num10) / 2f + num14, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					List<string> list3 = method_18(text3);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item7 in list3)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item7, dcgraphics_0);
							dcgraphics_0.DrawString(item7, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num11) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item7, dcgraphics_0);
							dcgraphics_0.DrawString(item7, method_16(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - num11) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				if (!string.IsNullOrEmpty(text4))
				{
					List<string> list4 = method_18(text4);
					int num13 = 0;
					float num14 = 0f;
					foreach (string item8 in list4)
					{
						num13++;
						if (num13 % 2 == 1)
						{
							SizeF sizeF10 = method_14(item8, dcgraphics_0);
							dcgraphics_0.DrawString(item8, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num12) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
						else
						{
							SizeF sizeF10 = method_15(item8, dcgraphics_0);
							dcgraphics_0.DrawString(item8, method_16(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - num12) / 2f + num14, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_1());
							num14 += sizeF10.Width;
						}
					}
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.PainIndex)
			{
				float num5 = 15f;
				float num15 = 50f;
				SizeF empty = SizeF.Empty;
				empty.Width = 1600f;
				empty.Height = 150f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					int result = 0;
					if (int.TryParse(method_0().Value1, out result))
					{
						dcgraphics_0.DrawString("▲", method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top + 50f, 105f + num5 * (float)result * 2f, 50f), smethod_0());
					}
				}
				string[] array5 = new string[11]
				{
					"0",
					"1",
					"2",
					"3",
					"4",
					"5",
					"6",
					"7",
					"8",
					"9",
					"10"
				};
				for (int i = 0; i < 11; i++)
				{
					dcgraphics_0.DrawString(array5[i], method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top + 80f, 100f + num5 * 20f * (float)i, 70f), smethod_0());
				}
				for (int j = 0; j <= 100; j++)
				{
					switch (j % 10)
					{
					case 0:
						dcgraphics_0.DrawLine(method_6(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 20f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 80f);
						break;
					case 5:
						dcgraphics_0.DrawLine(method_6(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 20f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 50f);
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 6:
					case 7:
					case 8:
					case 9:
						dcgraphics_0.DrawLine(method_6(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 35f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 50f);
						break;
					}
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + 50f, rectangleF.Top + num15, rectangleF.Left + 1550f, rectangleF.Top + num15);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.PDTeech)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF sizeF4 = method_13(method_0().Value4, dcgraphics_0);
				SizeF sizeF5 = method_13(method_0().Value5, dcgraphics_0);
				SizeF sizeF6 = method_13(method_0().Value6, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = Math.Max(Math.Max(Math.Max(sizeF.Width, sizeF2.Width), sizeF3.Width), Math.Max(Math.Max(sizeF4.Width, sizeF5.Width), sizeF6.Width)) * 3.1f;
				empty.Height = (sizeF.Height + sizeF4.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				if (!string.IsNullOrEmpty(method_0().Value1))
				{
					dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 3f - sizeF.Width) / 3f, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 3f + (rectangleF.Width / 3f - sizeF2.Width) / 3f, rectangleF.Top + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF2.Width, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 3f * 2f + (rectangleF.Width / 3f - sizeF3.Width) / 3f, rectangleF.Top + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF3.Width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value4))
				{
					dcgraphics_0.DrawString(method_0().Value4, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 3f - sizeF4.Width) / 3f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF4.Height) / 2f, sizeF4.Width, sizeF4.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value5))
				{
					dcgraphics_0.DrawString(method_0().Value5, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 3f + (rectangleF.Width / 3f - sizeF5.Width) / 3f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF5.Height) / 2f, sizeF5.Width, sizeF5.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value6))
				{
					dcgraphics_0.DrawString(method_0().Value6, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 3f * 2f + (rectangleF.Width / 3f - sizeF6.Width) / 3f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF6.Height) / 2f, sizeF6.Width, sizeF6.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + rectangleF.Width / 3f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 3f, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + rectangleF.Width / 3f * 2f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 3f * 2f, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.DiseasedTeethBotton)
			{
				SizeF sizeF = method_13(method_0().Value1, dcgraphics_0);
				SizeF sizeF2 = method_13(method_0().Value2, dcgraphics_0);
				SizeF sizeF3 = method_13(method_0().Value3, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width);
				empty.Height = (sizeF2.Height + sizeF3.Height) * 1.1f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), smethod_0());
				if (!string.IsNullOrEmpty(method_0().Value2))
				{
					dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top + num2 * 2f, Math.Max(sizeF2.Width, sizeF3.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_0().Value3))
				{
					dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Bottom - sizeF3.Height, Math.Max(sizeF2.Width, sizeF3.Width), sizeF3.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + sizeF.Width, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width), rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_8() == DCMedicalExpressionStyle.DiseasedTeethTop)
			{
				SizeF sizeF10 = method_13(method_0().Value1, dcgraphics_0);
				SizeF empty = SizeF.Empty;
				empty.Width = sizeF10.Width * 2.2f;
				empty.Height = sizeF10.Height * 2.2f;
				SizeF empty2 = SizeF.Empty;
				bool flag = false;
				bool flag2 = true;
				if (rectangleF_0.Width > 0f && rectangleF_0.Height > 0f)
				{
					empty2.Width = rectangleF_0.Width;
					empty2.Height = rectangleF_0.Height;
					if (rectangleF_0.Width > empty.Width && rectangleF_0.Height > empty.Height)
					{
						empty2.Width = empty.Width;
						empty2.Height = empty.Height;
						flag2 = false;
					}
					flag = true;
				}
				if (bool_0)
				{
					if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
					{
						return empty2;
					}
					return empty;
				}
				GraphicsState graphicsState_ = dcgraphics_0.Save();
				float num3 = 0f;
				float num4 = 0f;
				RectangleF rectangleF;
				if (flag2)
				{
					rectangleF = default(RectangleF);
					rectangleF.Width = empty.Width;
					rectangleF.Height = empty.Height;
					if (empty2.Width > empty.Width)
					{
						num3 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, 0f));
					}
					else
					{
						num3 = empty2.Width / empty.Width;
						pointF2 = (rectangleF.Location = new PointF(rectangleF_0.Left, 0f));
					}
					if (empty2.Height > empty.Height)
					{
						num4 = 1f;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f));
					}
					else
					{
						num4 = empty2.Height / empty.Height;
						pointF2 = (rectangleF.Location = new PointF(rectangleF.Location.X, rectangleF_0.Top));
					}
				}
				else
				{
					rectangleF = new RectangleF(rectangleF_0.Left + (rectangleF_0.Width - empty.Width) / 2f, rectangleF_0.Top + (rectangleF_0.Height - empty.Height) / 2f, empty.Width, empty.Height);
					num3 = 1f;
					num4 = 1f;
				}
				dcgraphics_0.TranslateTransform(rectangleF.Left * (1f - num3), rectangleF.Top * (1f - num4));
				dcgraphics_0.ScaleTransform(num3, num4);
				dcgraphics_0.DrawString(method_0().Value1, method_4(), method_6(), new RectangleF(rectangleF.Left + sizeF10.Width * 0.6f, rectangleF.Top, sizeF10.Width, sizeF10.Height), smethod_0());
				dcgraphics_0.DrawString(method_0().Value2, method_4(), method_6(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF10.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF10.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_0());
				dcgraphics_0.DrawString(method_0().Value3, method_4(), method_6(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF10.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF10.Height) / 2f, sizeF10.Width, sizeF10.Height), smethod_0());
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left, rectangleF.Top, rectangleF.Left + sizeF10.Width * 1.1f, rectangleF.Top + sizeF10.Height * 1.1f);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + sizeF10.Width * 1.1f, rectangleF.Top + sizeF10.Height * 1.1f, rectangleF.Right, rectangleF.Top);
				dcgraphics_0.DrawLine(method_6(), rectangleF.Left + sizeF10.Width * 1.1f, rectangleF.Top + sizeF10.Height * 1.1f, rectangleF.Left + sizeF10.Width * 1.1f, rectangleF.Bottom);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			return SizeF.Empty;
		}

		private SizeF method_13(string string_0, DCGraphics dcgraphics_0)
		{
			SizeF empty = SizeF.Empty;
			empty = ((string_0 == null || string_0.Length == 0) ? new SizeF(GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), dcgraphics_0.GetFontHeight(method_4())) : ((method_8() != DCMedicalExpressionStyle.DeciduousTeech && method_8() != DCMedicalExpressionStyle.PermanentTeethBitmap) ? dcgraphics_0.MeasureString(string_0, method_4(), 100000, smethod_0()) : dcgraphics_0.MeasureString(string_0, method_4(), 100000, smethod_1())));
			empty.Height = dcgraphics_0.GetFontHeight(method_4()) + (float)GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			return empty;
		}

		private SizeF method_14(string string_0, DCGraphics dcgraphics_0)
		{
			SizeF empty = SizeF.Empty;
			empty = ((string_0 == null || string_0.Length == 0) ? new SizeF(GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), dcgraphics_0.GetFontHeight(method_4())) : ((method_8() != DCMedicalExpressionStyle.DeciduousTeech && method_8() != DCMedicalExpressionStyle.PermanentTeethBitmap) ? dcgraphics_0.MeasureString(string_0, method_4(), 100000, smethod_0()) : dcgraphics_0.MeasureString(string_0, method_4(), 100000, smethod_1())));
			empty.Height = dcgraphics_0.GetFontHeight(method_4()) + (float)GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			return empty;
		}

		private SizeF method_15(string string_0, DCGraphics dcgraphics_0)
		{
			SizeF empty = SizeF.Empty;
			XFontValue xFontValue = method_4();
			float float_ = xFontValue.Size / 2f;
			XFontValue font = new XFontValue(xFontValue.Name, float_);
			empty = ((string_0 != null && string_0.Length != 0) ? dcgraphics_0.MeasureString(string_0, font, 100000, smethod_1()) : new SizeF(GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), dcgraphics_0.GetFontHeight(font)));
			empty.Height = dcgraphics_0.GetFontHeight(font) + (float)GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			return empty;
		}

		private XFontValue method_16()
		{
			float float_ = method_4().Size / 2f;
			return new XFontValue(method_4().Name, float_, FontStyle.Italic);
		}

		private float method_17(string string_0, DCGraphics dcgraphics_0)
		{
			float num = 0f;
			List<string> list = method_18(string_0);
			int num2 = 0;
			foreach (string item in list)
			{
				num = ((num2 % 2 != 0) ? (num + method_15(item, dcgraphics_0).Width) : (num + method_14(item, dcgraphics_0).Width));
				num2++;
			}
			return num;
		}

		private List<string> method_18(string string_0)
		{
			List<string> list = new List<string>();
			char[] array = string_0.ToCharArray();
			int num = 0;
			string text = "";
			char[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				char c = array2[i];
				int num2 = c;
				if ((num2 > 60 && num2 < 100 && num < 100 && num > 60) || ((num2 < 60 || num2 > 100) && (num > 100 || num < 60)))
				{
					text += c;
				}
				else if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
					text = c.ToString();
				}
				num = num2;
			}
			list.Add(text);
			return list;
		}

		public float method_19(List<float> list_0)
		{
			float num = list_0[0];
			for (int i = 1; i < list_0.Count; i++)
			{
				if (num < list_0[i])
				{
					num = list_0[i];
				}
			}
			return num;
		}

		private static DrawStringFormatExt smethod_0()
		{
			if (drawStringFormatExt_0 == null)
			{
				drawStringFormatExt_0 = new DrawStringFormatExt();
				drawStringFormatExt_0.Alignment = StringAlignment.Center;
				drawStringFormatExt_0.LineAlignment = StringAlignment.Center;
				drawStringFormatExt_0.FormatFlags = (StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
			}
			return drawStringFormatExt_0;
		}

		private static DrawStringFormatExt smethod_1()
		{
			if (drawStringFormatExt_1 == null)
			{
				drawStringFormatExt_1 = new DrawStringFormatExt();
				drawStringFormatExt_1.SetStringFormatAsGenericTypographic();
				drawStringFormatExt_1.Alignment = StringAlignment.Center;
				drawStringFormatExt_1.LineAlignment = StringAlignment.Center;
				drawStringFormatExt_1.FormatFlags = (StringFormatFlags.NoWrap | StringFormatFlags.NoClip);
			}
			return drawStringFormatExt_1;
		}
	}
}
