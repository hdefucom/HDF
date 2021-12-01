using DCSoft.Drawing;
using DCSoft.Writer.Extension.Medical;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass24
	{
		private int int_0 = -1;

		private XFontValue xfontValue_0 = new XFontValue();

		private Color color_0 = Color.Black;

		private string string_0 = null;

		private string string_1 = null;

		private string string_2 = null;

		private string string_3 = null;

		private string string_4 = null;

		private string string_5 = null;

		private string string_6 = null;

		private string string_7 = null;

		private string string_8 = null;

		private string string_9 = null;

		private string string_10 = null;

		private string string_11 = null;

		private string string_12 = null;

		private string string_13 = null;

		private string string_14 = null;

		private string string_15 = null;

		private string string_16 = null;

		private string string_17 = null;

		private string string_18 = null;

		private string string_19 = null;

		private string string_20 = null;

		private string string_21 = null;

		private string string_22 = null;

		private string string_23 = null;

		private string string_24 = null;

		private string string_25 = null;

		private string string_26 = null;

		private string string_27 = null;

		private string string_28 = null;

		private string string_29 = null;

		private string string_30 = null;

		private string string_31 = null;

		private MedicalExpressionStyle medicalExpressionStyle_0 = MedicalExpressionStyle.FourValues;

		private static DrawStringFormatExt drawStringFormatExt_0 = null;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
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

		public void method_5(Color color_1)
		{
			color_0 = color_1;
		}

		public void method_6(string[] string_32)
		{
			if (string_32 != null)
			{
				if (string_32.Length > 0)
				{
					method_8(string_32[0]);
				}
				if (string_32.Length > 1)
				{
					method_10(string_32[1]);
				}
				if (string_32.Length > 2)
				{
					method_12(string_32[2]);
				}
				if (string_32.Length > 3)
				{
					method_14(string_32[3]);
				}
				if (string_32.Length > 4)
				{
					method_16(string_32[4]);
				}
				if (string_32.Length > 5)
				{
					method_18(string_32[5]);
				}
				if (string_32.Length > 6)
				{
					method_20(string_32[6]);
				}
				if (string_32.Length > 7)
				{
					method_22(string_32[7]);
				}
				if (string_32.Length > 8)
				{
					method_24(string_32[8]);
				}
			}
		}

		public string method_7()
		{
			return string_0;
		}

		public void method_8(string string_32)
		{
			string_0 = string_32;
		}

		public string method_9()
		{
			return string_1;
		}

		public void method_10(string string_32)
		{
			string_1 = string_32;
		}

		public string method_11()
		{
			return string_2;
		}

		public void method_12(string string_32)
		{
			string_2 = string_32;
		}

		public string method_13()
		{
			return string_3;
		}

		public void method_14(string string_32)
		{
			string_3 = string_32;
		}

		public string method_15()
		{
			return string_4;
		}

		public void method_16(string string_32)
		{
			string_4 = string_32;
		}

		public string method_17()
		{
			return string_5;
		}

		public void method_18(string string_32)
		{
			string_5 = string_32;
		}

		public string method_19()
		{
			return string_6;
		}

		public void method_20(string string_32)
		{
			string_6 = string_32;
		}

		public string method_21()
		{
			return string_7;
		}

		public void method_22(string string_32)
		{
			string_7 = string_32;
		}

		public string method_23()
		{
			return string_8;
		}

		public void method_24(string string_32)
		{
			string_8 = string_32;
		}

		public string method_25()
		{
			return string_9;
		}

		public void method_26(string string_32)
		{
			string_9 = string_32;
		}

		public string method_27()
		{
			return string_10;
		}

		public void method_28(string string_32)
		{
			string_10 = string_32;
		}

		public string method_29()
		{
			return string_11;
		}

		public void method_30(string string_32)
		{
			string_11 = string_32;
		}

		public string method_31()
		{
			return string_12;
		}

		public void method_32(string string_32)
		{
			string_12 = string_32;
		}

		public string method_33()
		{
			return string_13;
		}

		public void method_34(string string_32)
		{
			string_13 = string_32;
		}

		public string method_35()
		{
			return string_14;
		}

		public void method_36(string string_32)
		{
			string_14 = string_32;
		}

		public string method_37()
		{
			return string_15;
		}

		public void method_38(string string_32)
		{
			string_15 = string_32;
		}

		public string method_39()
		{
			return string_16;
		}

		public void method_40(string string_32)
		{
			string_16 = string_32;
		}

		public string method_41()
		{
			return string_17;
		}

		public void method_42(string string_32)
		{
			string_17 = string_32;
		}

		public string method_43()
		{
			return string_18;
		}

		public void method_44(string string_32)
		{
			string_18 = string_32;
		}

		public string method_45()
		{
			return string_19;
		}

		public void method_46(string string_32)
		{
			string_19 = string_32;
		}

		public string method_47()
		{
			return string_20;
		}

		public void method_48(string string_32)
		{
			string_20 = string_32;
		}

		public string method_49()
		{
			return string_21;
		}

		public void method_50(string string_32)
		{
			string_21 = string_32;
		}

		public string method_51()
		{
			return string_22;
		}

		public void method_52(string string_32)
		{
			string_22 = string_32;
		}

		public string method_53()
		{
			return string_23;
		}

		public void method_54(string string_32)
		{
			string_23 = string_32;
		}

		public string method_55()
		{
			return string_24;
		}

		public void method_56(string string_32)
		{
			string_24 = string_32;
		}

		public string method_57()
		{
			return string_25;
		}

		public void method_58(string string_32)
		{
			string_25 = string_32;
		}

		public string method_59()
		{
			return string_26;
		}

		public void method_60(string string_32)
		{
			string_26 = string_32;
		}

		public string method_61()
		{
			return string_27;
		}

		public void method_62(string string_32)
		{
			string_27 = string_32;
		}

		public string method_63()
		{
			return string_28;
		}

		public void method_64(string string_32)
		{
			string_28 = string_32;
		}

		public string method_65()
		{
			return string_29;
		}

		public void method_66(string string_32)
		{
			string_29 = string_32;
		}

		public string method_67()
		{
			return string_30;
		}

		public void method_68(string string_32)
		{
			string_30 = string_32;
		}

		public string method_69()
		{
			return string_31;
		}

		public void method_70(string string_32)
		{
			string_31 = string_32;
		}

		public MedicalExpressionStyle method_71()
		{
			return medicalExpressionStyle_0;
		}

		public void method_72(MedicalExpressionStyle medicalExpressionStyle_1)
		{
			medicalExpressionStyle_0 = medicalExpressionStyle_1;
		}

		public SizeF method_73(DCGraphics dcgraphics_0)
		{
			return method_75(dcgraphics_0, RectangleF.Empty, bool_0: true);
		}

		public void method_74(DCGraphics dcgraphics_0, RectangleF rectangleF_0)
		{
			method_75(dcgraphics_0, rectangleF_0, bool_0: false);
		}

		private SizeF method_75(DCGraphics dcgraphics_0, RectangleF rectangleF_0, bool bool_0)
		{
			int num = 15;
			float num2 = (float)GraphicsUnitConvert.Convert(1.0, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			PointF pointF2;
			if (method_71() == MedicalExpressionStyle.FourValues)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top + num2 * 2f, Math.Max(sizeF2.Width, sizeF3.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Bottom - sizeF3.Height, Math.Max(sizeF2.Width, sizeF3.Width), sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Right - sizeF4.Width, rectangleF.Top, sizeF4.Width, rectangleF.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + sizeF.Width, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Right - sizeF4.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.FourValues1)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF.Width) / 2f, rectangleF.Top + (rectangleF.Height / 2f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF2.Width) / 2f, rectangleF.Top + (rectangleF.Height / 2f - sizeF2.Height) / 2f, sizeF2.Width, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF3.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF3.Height) / 2f, sizeF3.Width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF4.Width) / 2f, rectangleF.Top + rectangleF.Height / 2f + (rectangleF.Height / 2f - sizeF4.Height) / 2f, sizeF4.Width, sizeF4.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top, rectangleF.Left + rectangleF.Width / 2f, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.FourValues2)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left + (rectangleF.Width / 2f - sizeF.Width) / 2f, rectangleF.Top + rectangleF.Height / 5f * 2f, sizeF.Width, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + (rectangleF.Width - sizeF2.Width) / 2f, rectangleF.Top + 5f, sizeF2.Width, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + rectangleF.Width / 2f + (rectangleF.Width / 2f - sizeF3.Width) / 2f, rectangleF.Top + rectangleF.Height / 5f * 2f, sizeF3.Width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left + (rectangleF.Width - sizeF4.Width) / 2f, rectangleF.Top + rectangleF.Height - sizeF4.Height, sizeF4.Width, sizeF4.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left, rectangleF.Top, rectangleF.Left + rectangleF.Width, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + rectangleF.Width, rectangleF.Top, rectangleF.Left, rectangleF.Top + rectangleF.Height);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.ThreeValues)
			{
				SizeF sizeF = method_76(method_7() + "/", dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
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
				dcgraphics_0.DrawString(method_7() + "/", method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, sizeF.Width, rectangleF.Height), smethod_0());
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Top + num2 * 2f, Math.Max(sizeF2.Width, sizeF3.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + sizeF.Width, rectangleF.Bottom - sizeF3.Height, Math.Max(sizeF2.Width, sizeF3.Width), sizeF3.Height), smethod_0());
				}
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + sizeF.Width, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + sizeF.Width + Math.Max(sizeF2.Width, sizeF3.Width), rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.Pupil)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
				SizeF sizeF5 = method_76(method_15(), dcgraphics_0);
				SizeF sizeF6 = method_76(method_17(), dcgraphics_0);
				SizeF sizeF7 = method_76(method_19(), dcgraphics_0);
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width) + sizeF4.Width, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), rectangleF.Top, sizeF4.Width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_15()))
				{
					dcgraphics_0.DrawString(method_15(), method_2(), method_4(), new RectangleF(rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width) + sizeF4.Width, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_17()))
				{
					dcgraphics_0.DrawString(method_17(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Bottom - sizeF6.Height, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF6.Width), sizeF6.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_19()))
				{
					dcgraphics_0.DrawString(method_19(), method_2(), method_4(), new RectangleF(rectangleF.Left + sizeF4.Width + Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), rectangleF.Bottom - sizeF7.Height, Math.Max(Math.Max(sizeF2.Width, sizeF5.Width), sizeF7.Width), sizeF7.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.LightPositioning)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
				SizeF sizeF5 = method_76(method_15(), dcgraphics_0);
				SizeF sizeF6 = method_76(method_17(), dcgraphics_0);
				SizeF sizeF7 = method_76(method_19(), dcgraphics_0);
				SizeF sizeF8 = method_76(method_21(), dcgraphics_0);
				SizeF sizeF9 = method_76(method_23(), dcgraphics_0);
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num6, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Top, width, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_15()))
				{
					dcgraphics_0.DrawString(method_15(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num6, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_17()))
				{
					dcgraphics_0.DrawString(method_17(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Top, width, rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_19()))
				{
					dcgraphics_0.DrawString(method_19(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Bottom - sizeF7.Height, num5, sizeF7.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_21()))
				{
					dcgraphics_0.DrawString(method_21(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Bottom - sizeF8.Height, num6, sizeF8.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_23()))
				{
					dcgraphics_0.DrawString(method_23(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 + num6, rectangleF.Bottom - sizeF9.Height, width, sizeF9.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.FetalHeart)
			{
				SizeF sizeF = method_76(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_76(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_76(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_76(method_13(), dcgraphics_0);
				SizeF sizeF5 = method_76(method_15(), dcgraphics_0);
				SizeF sizeF6 = method_76(method_17(), dcgraphics_0);
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
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Left + 10f, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + 10f + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), rectangleF.Top + rectangleF.Height / 2f, rectangleF.Right - 10f - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_4(), rectangleF.Right - 10f, rectangleF.Top + rectangleF.Height / 2f, rectangleF.Right, rectangleF.Top + rectangleF.Height / 2f);
				dcgraphics_0.DrawLine(method_4(), (rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width) + rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width)) / 2f, rectangleF.Top, (rectangleF.Left + Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width) + rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width)) / 2f, rectangleF.Top + rectangleF.Height);
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left + 10f, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + 10f, rectangleF.Top, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Top, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), rectangleF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_15()))
				{
					dcgraphics_0.DrawString(method_15(), method_2(), method_4(), new RectangleF(rectangleF.Left + 10f, rectangleF.Bottom - sizeF5.Height, Math.Max(Math.Max(sizeF.Width, sizeF3.Width), sizeF5.Width), sizeF5.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_17()))
				{
					dcgraphics_0.DrawString(method_17(), method_2(), method_4(), new RectangleF(rectangleF.Right - Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width) - 10f, rectangleF.Bottom - sizeF6.Height, Math.Max(Math.Max(sizeF2.Width, sizeF4.Width), sizeF6.Width), sizeF6.Height), smethod_0());
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.PermanentTeethBitmap)
			{
				SizeF sizeF = method_77(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_77(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_77(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_77(method_13(), dcgraphics_0);
				SizeF sizeF5 = method_77(method_15(), dcgraphics_0);
				SizeF sizeF6 = method_77(method_17(), dcgraphics_0);
				SizeF sizeF7 = method_77(method_19(), dcgraphics_0);
				SizeF sizeF8 = method_77(method_21(), dcgraphics_0);
				SizeF sizeF9 = method_77(method_23(), dcgraphics_0);
				SizeF sizeF10 = method_77(method_25(), dcgraphics_0);
				SizeF sizeF11 = method_77(method_27(), dcgraphics_0);
				SizeF sizeF12 = method_77(method_29(), dcgraphics_0);
				SizeF sizeF13 = method_77(method_31(), dcgraphics_0);
				SizeF sizeF14 = method_77(method_33(), dcgraphics_0);
				SizeF sizeF15 = method_77(method_35(), dcgraphics_0);
				SizeF sizeF16 = method_77(method_37(), dcgraphics_0);
				SizeF sizeF17 = method_77(method_39(), dcgraphics_0);
				SizeF sizeF18 = method_77(method_41(), dcgraphics_0);
				SizeF sizeF19 = method_77(method_43(), dcgraphics_0);
				SizeF sizeF20 = method_77(method_45(), dcgraphics_0);
				SizeF sizeF21 = method_77(method_47(), dcgraphics_0);
				SizeF sizeF22 = method_77(method_49(), dcgraphics_0);
				SizeF sizeF23 = method_77(method_51(), dcgraphics_0);
				SizeF sizeF24 = method_77(method_53(), dcgraphics_0);
				SizeF sizeF25 = method_77(method_55(), dcgraphics_0);
				SizeF sizeF26 = method_77(method_57(), dcgraphics_0);
				SizeF sizeF27 = method_77(method_59(), dcgraphics_0);
				SizeF sizeF28 = method_77(method_61(), dcgraphics_0);
				SizeF sizeF29 = method_77(method_63(), dcgraphics_0);
				SizeF sizeF30 = method_77(method_65(), dcgraphics_0);
				SizeF sizeF31 = method_77(method_67(), dcgraphics_0);
				SizeF sizeF32 = method_77(method_69(), dcgraphics_0);
				List<float> list = new List<float>();
				list.Add(sizeF.Width);
				list.Add(sizeF2.Width);
				list.Add(sizeF3.Width);
				list.Add(sizeF4.Width);
				list.Add(sizeF15.Width);
				list.Add(sizeF6.Width);
				list.Add(sizeF7.Width);
				list.Add(sizeF8.Width);
				list.Add(sizeF9.Width);
				list.Add(sizeF10.Width);
				list.Add(sizeF11.Width);
				list.Add(sizeF12.Width);
				list.Add(sizeF13.Width);
				list.Add(sizeF14.Width);
				list.Add(sizeF15.Width);
				list.Add(sizeF16.Width);
				list.Add(sizeF17.Width);
				list.Add(sizeF18.Width);
				list.Add(sizeF19.Width);
				list.Add(sizeF20.Width);
				list.Add(sizeF21.Width);
				list.Add(sizeF22.Width);
				list.Add(sizeF23.Width);
				list.Add(sizeF24.Width);
				list.Add(sizeF25.Width);
				list.Add(sizeF26.Width);
				list.Add(sizeF27.Width);
				list.Add(sizeF28.Width);
				list.Add(sizeF29.Width);
				list.Add(sizeF30.Width);
				list.Add(sizeF31.Width);
				list.Add(sizeF32.Width);
				List<float> list_ = list;
				float num5 = method_78(list_);
				List<float> list2 = new List<float>();
				list2.Add(sizeF.Height);
				list2.Add(sizeF2.Height);
				list2.Add(sizeF3.Height);
				list2.Add(sizeF4.Height);
				list2.Add(sizeF15.Height);
				list2.Add(sizeF6.Height);
				list2.Add(sizeF7.Height);
				list2.Add(sizeF8.Height);
				list2.Add(sizeF9.Height);
				list2.Add(sizeF10.Height);
				list2.Add(sizeF11.Height);
				list2.Add(sizeF12.Height);
				list2.Add(sizeF13.Height);
				list2.Add(sizeF14.Height);
				list2.Add(sizeF15.Height);
				list2.Add(sizeF16.Height);
				list2.Add(sizeF17.Height);
				list2.Add(sizeF18.Height);
				list2.Add(sizeF19.Height);
				list2.Add(sizeF20.Height);
				list2.Add(sizeF21.Height);
				list2.Add(sizeF22.Height);
				list2.Add(sizeF23.Height);
				list2.Add(sizeF24.Height);
				list2.Add(sizeF25.Height);
				list2.Add(sizeF26.Height);
				list2.Add(sizeF27.Height);
				list2.Add(sizeF28.Height);
				list2.Add(sizeF29.Height);
				list2.Add(sizeF30.Height);
				list2.Add(sizeF31.Height);
				list2.Add(sizeF32.Height);
				List<float> list_2 = list2;
				float num7 = method_78(list_2);
				SizeF empty = SizeF.Empty;
				empty.Width = num5 * 16.01f;
				empty.Height = num7 * 2.01f;
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, sizeF.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num5, sizeF2.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 2f, rectangleF.Top, num5, sizeF3.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 3f, rectangleF.Top, num5, sizeF4.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_15()))
				{
					dcgraphics_0.DrawString(method_15(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 4f, rectangleF.Top, num5, sizeF5.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_17()))
				{
					dcgraphics_0.DrawString(method_17(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 5f, rectangleF.Top, num5, sizeF6.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_19()))
				{
					dcgraphics_0.DrawString(method_19(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 6f, rectangleF.Top, num5, sizeF7.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_21()))
				{
					dcgraphics_0.DrawString(method_21(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 7f, rectangleF.Top, num5, sizeF8.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_23()))
				{
					dcgraphics_0.DrawString(method_23(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 8f, rectangleF.Top, num5, sizeF9.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_25()))
				{
					dcgraphics_0.DrawString(method_25(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 9f, rectangleF.Top, num5, sizeF10.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_27()))
				{
					dcgraphics_0.DrawString(method_27(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 10f, rectangleF.Top, num5, sizeF11.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_29()))
				{
					dcgraphics_0.DrawString(method_29(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 11f, rectangleF.Top, num5, sizeF12.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_31()))
				{
					dcgraphics_0.DrawString(method_31(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 12f, rectangleF.Top, num5, sizeF13.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_33()))
				{
					dcgraphics_0.DrawString(method_33(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 13f, rectangleF.Top, num5, sizeF14.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_35()))
				{
					dcgraphics_0.DrawString(method_35(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 14f, rectangleF.Top, num5, sizeF15.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_37()))
				{
					dcgraphics_0.DrawString(method_37(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 15f, rectangleF.Top, num5, sizeF16.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_39()))
				{
					dcgraphics_0.DrawString(method_39(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top + sizeF17.Height, num5, sizeF17.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_41()))
				{
					dcgraphics_0.DrawString(method_41(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Top + sizeF18.Height, num5, sizeF18.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_43()))
				{
					dcgraphics_0.DrawString(method_43(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 2f, rectangleF.Top + sizeF19.Height, num5, sizeF19.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_45()))
				{
					dcgraphics_0.DrawString(method_45(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 3f, rectangleF.Top + sizeF20.Height, num5, sizeF20.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_47()))
				{
					dcgraphics_0.DrawString(method_47(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 4f, rectangleF.Top + sizeF21.Height, num5, sizeF21.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_49()))
				{
					dcgraphics_0.DrawString(method_49(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 5f, rectangleF.Top + sizeF22.Height, num5, sizeF22.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_51()))
				{
					dcgraphics_0.DrawString(method_51(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 6f, rectangleF.Top + sizeF23.Height, num5, sizeF23.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_53()))
				{
					dcgraphics_0.DrawString(method_53(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 7f, rectangleF.Top + sizeF24.Height, num5, sizeF24.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_55()))
				{
					dcgraphics_0.DrawString(method_55(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 8f, rectangleF.Top + sizeF25.Height, num5, sizeF25.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_57()))
				{
					dcgraphics_0.DrawString(method_57(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 9f, rectangleF.Top + sizeF26.Height, num5, sizeF26.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_59()))
				{
					dcgraphics_0.DrawString(method_59(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 10f, rectangleF.Top + sizeF27.Height, num5, sizeF27.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_61()))
				{
					dcgraphics_0.DrawString(method_61(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 11f, rectangleF.Top + sizeF28.Height, num5, sizeF28.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_63()))
				{
					dcgraphics_0.DrawString(method_63(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 12f, rectangleF.Top + sizeF29.Height, num5, sizeF29.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_65()))
				{
					dcgraphics_0.DrawString(method_65(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 13f, rectangleF.Top + sizeF30.Height, num5, sizeF30.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_67()))
				{
					dcgraphics_0.DrawString(method_67(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 14f, rectangleF.Top + sizeF31.Height, num5, sizeF31.Height), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_69()))
				{
					dcgraphics_0.DrawString(method_69(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 15f, rectangleF.Top + sizeF32.Height, num5, sizeF32.Height), smethod_0());
				}
				if (num5 > 0f && num7 > 0f)
				{
					dcgraphics_0.DrawLine(method_4(), rectangleF.Left + num5 * 8f, rectangleF.Top, rectangleF.Left + num5 * 8f, rectangleF.Top + num7 * 2f);
					dcgraphics_0.DrawLine(method_4(), rectangleF.Left, rectangleF.Top + num7, rectangleF.Left + num5 * 16f, rectangleF.Top + num7);
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.DeciduousTeech)
			{
				SizeF sizeF = method_77(method_7(), dcgraphics_0);
				SizeF sizeF2 = method_77(method_9(), dcgraphics_0);
				SizeF sizeF3 = method_77(method_11(), dcgraphics_0);
				SizeF sizeF4 = method_77(method_13(), dcgraphics_0);
				SizeF sizeF5 = method_77(method_15(), dcgraphics_0);
				SizeF sizeF6 = method_77(method_17(), dcgraphics_0);
				SizeF sizeF7 = method_77(method_19(), dcgraphics_0);
				SizeF sizeF8 = method_77(method_21(), dcgraphics_0);
				SizeF sizeF9 = method_77(method_23(), dcgraphics_0);
				SizeF sizeF10 = method_77(method_25(), dcgraphics_0);
				SizeF sizeF11 = method_77(method_27(), dcgraphics_0);
				SizeF sizeF12 = method_77(method_29(), dcgraphics_0);
				SizeF sizeF13 = method_77(method_31(), dcgraphics_0);
				SizeF sizeF14 = method_77(method_33(), dcgraphics_0);
				SizeF sizeF15 = method_77(method_35(), dcgraphics_0);
				SizeF sizeF16 = method_77(method_37(), dcgraphics_0);
				SizeF sizeF17 = method_77(method_39(), dcgraphics_0);
				SizeF sizeF18 = method_77(method_41(), dcgraphics_0);
				SizeF sizeF19 = method_77(method_43(), dcgraphics_0);
				SizeF sizeF20 = method_77(method_45(), dcgraphics_0);
				List<float> list3 = new List<float>();
				list3.Add(sizeF.Width);
				list3.Add(sizeF2.Width);
				list3.Add(sizeF3.Width);
				list3.Add(sizeF4.Width);
				list3.Add(sizeF15.Width);
				list3.Add(sizeF6.Width);
				list3.Add(sizeF7.Width);
				list3.Add(sizeF8.Width);
				list3.Add(sizeF9.Width);
				list3.Add(sizeF10.Width);
				list3.Add(sizeF11.Width);
				list3.Add(sizeF12.Width);
				list3.Add(sizeF13.Width);
				list3.Add(sizeF14.Width);
				list3.Add(sizeF15.Width);
				list3.Add(sizeF16.Width);
				list3.Add(sizeF17.Width);
				list3.Add(sizeF18.Width);
				list3.Add(sizeF19.Width);
				list3.Add(sizeF20.Width);
				List<float> list_ = list3;
				float num5 = method_78(list_);
				List<float> list4 = new List<float>();
				list4.Add(sizeF.Height);
				list4.Add(sizeF2.Height);
				list4.Add(sizeF3.Height);
				list4.Add(sizeF4.Height);
				list4.Add(sizeF15.Height);
				list4.Add(sizeF6.Height);
				list4.Add(sizeF7.Height);
				list4.Add(sizeF8.Height);
				list4.Add(sizeF9.Height);
				list4.Add(sizeF10.Height);
				list4.Add(sizeF11.Height);
				list4.Add(sizeF12.Height);
				list4.Add(sizeF13.Height);
				list4.Add(sizeF14.Height);
				list4.Add(sizeF15.Height);
				list4.Add(sizeF16.Height);
				list4.Add(sizeF17.Height);
				list4.Add(sizeF18.Height);
				list4.Add(sizeF19.Height);
				list4.Add(sizeF20.Height);
				List<float> list_2 = list4;
				float num7 = method_78(list_2);
				SizeF empty = SizeF.Empty;
				empty.Width = num5 * 10.01f;
				empty.Height = num7 * 2.01f;
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					dcgraphics_0.DrawString(method_7(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_9()))
				{
					dcgraphics_0.DrawString(method_9(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_11()))
				{
					dcgraphics_0.DrawString(method_11(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 2f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_13()))
				{
					dcgraphics_0.DrawString(method_13(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 3f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_15()))
				{
					dcgraphics_0.DrawString(method_15(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 4f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_17()))
				{
					dcgraphics_0.DrawString(method_17(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 5f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_19()))
				{
					dcgraphics_0.DrawString(method_19(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 6f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_21()))
				{
					dcgraphics_0.DrawString(method_21(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 7f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_23()))
				{
					dcgraphics_0.DrawString(method_23(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 8f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_25()))
				{
					dcgraphics_0.DrawString(method_25(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 9f, rectangleF.Top, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_27()))
				{
					dcgraphics_0.DrawString(method_27(), method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_29()))
				{
					dcgraphics_0.DrawString(method_29(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 1f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_31()))
				{
					dcgraphics_0.DrawString(method_31(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 2f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_33()))
				{
					dcgraphics_0.DrawString(method_33(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 3f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_35()))
				{
					dcgraphics_0.DrawString(method_35(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 4f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_37()))
				{
					dcgraphics_0.DrawString(method_37(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 5f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_39()))
				{
					dcgraphics_0.DrawString(method_39(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 6f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_41()))
				{
					dcgraphics_0.DrawString(method_41(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 7f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_43()))
				{
					dcgraphics_0.DrawString(method_43(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 8f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (!string.IsNullOrEmpty(method_45()))
				{
					dcgraphics_0.DrawString(method_45(), method_2(), method_4(), new RectangleF(rectangleF.Left + num5 * 9f, rectangleF.Top + num7, num5, num7), smethod_0());
				}
				if (num5 > 0f && num7 > 0f)
				{
					dcgraphics_0.DrawLine(method_4(), rectangleF.Left + num5 * 5f, rectangleF.Top, rectangleF.Left + num5 * 5f, rectangleF.Top + num7 * 2f);
					dcgraphics_0.DrawLine(method_4(), rectangleF.Left, rectangleF.Top + num7, rectangleF.Left + num5 * 10f, rectangleF.Top + num7);
				}
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			if (method_71() == MedicalExpressionStyle.PainIndex)
			{
				float num5 = 15f;
				float num7 = 50f;
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
				if (!string.IsNullOrEmpty(method_7()))
				{
					int result = 0;
					if (int.TryParse(method_7(), out result))
					{
						dcgraphics_0.DrawString("▲", method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top + 50f, 105f + num5 * (float)result * 2f, 50f), smethod_0());
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
					dcgraphics_0.DrawString(array5[i], method_2(), method_4(), new RectangleF(rectangleF.Left, rectangleF.Top + 80f, 100f + num5 * 20f * (float)i, 70f), smethod_0());
				}
				for (int j = 0; j <= 100; j++)
				{
					switch (j % 10)
					{
					case 0:
						dcgraphics_0.DrawLine(method_4(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 20f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 80f);
						break;
					case 5:
						dcgraphics_0.DrawLine(method_4(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 20f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 50f);
						break;
					case 1:
					case 2:
					case 3:
					case 4:
					case 6:
					case 7:
					case 8:
					case 9:
						dcgraphics_0.DrawLine(method_4(), rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 35f, rectangleF.Left + num5 * (float)j + 50f, rectangleF.Top + 50f);
						break;
					}
				}
				dcgraphics_0.DrawLine(method_4(), rectangleF.Left + 50f, rectangleF.Top + num7, rectangleF.Left + 1550f, rectangleF.Top + num7);
				dcgraphics_0.Restore(graphicsState_);
				if ((empty2.Width < empty.Width || empty2.Height < empty.Height) && flag)
				{
					return empty2;
				}
				return empty;
			}
			return SizeF.Empty;
		}

		private SizeF method_76(string string_32, DCGraphics dcgraphics_0)
		{
			SizeF empty = SizeF.Empty;
			empty = ((string_32 != null && string_32.Length != 0) ? dcgraphics_0.MeasureString(string_32, method_2(), 100000, smethod_0()) : new SizeF(GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), dcgraphics_0.GetFontHeight(method_2())));
			empty.Height = dcgraphics_0.GetFontHeight(method_2()) + (float)GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			return empty;
		}

		private SizeF method_77(string string_32, DCGraphics dcgraphics_0)
		{
			SizeF empty = SizeF.Empty;
			empty = ((string_32 != null && string_32.Length != 0) ? dcgraphics_0.MeasureString(string_32, method_2(), 100000, smethod_0()) : new SizeF(GraphicsUnitConvert.Convert(10, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), dcgraphics_0.GetFontHeight(method_2())));
			empty.Height = dcgraphics_0.GetFontHeight(method_2()) + (float)GraphicsUnitConvert.Convert(4, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
			return empty;
		}

		public float method_78(List<float> list_0)
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
	}
}
