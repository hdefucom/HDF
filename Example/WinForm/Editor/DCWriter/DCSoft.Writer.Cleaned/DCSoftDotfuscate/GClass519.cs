using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass519 : IDisposable
	{
		private const int int_0 = 2;

		private const int int_1 = 2;

		private const int int_2 = 2;

		private string string_0 = Control.DefaultFont.Name;

		private PointF pointF_0 = new PointF(0f, 0f);

		private GClass539 gclass539_0;

		private GClass458 gclass458_0;

		private StreamWriter streamWriter_0;

		private SizeF sizeF_0 = SizeF.Empty;

		private bool bool_0 = true;

		private bool bool_1 = false;

		private bool bool_2;

		private GraphicsUnit graphicsUnit_0 = GraphicsUnit.Document;

		private float float_0 = Class208.smethod_0(GraphicsUnit.Document);

		private Region region_0 = new Region();

		private int int_3 = 0;

		public GClass519(string string_1)
		{
			streamWriter_0 = new StreamWriter(string_1, append: false);
			bool_2 = true;
			method_11();
		}

		public GClass519(Stream stream_0)
		{
			streamWriter_0 = new StreamWriter(stream_0);
			bool_2 = false;
			method_11();
		}

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_1)
		{
			string_0 = string_1;
		}

		public PointF method_2()
		{
			return pointF_0;
		}

		public void method_3(PointF pointF_1)
		{
			pointF_0 = pointF_1;
		}

		public Region method_4()
		{
			return region_0;
		}

		public void method_5(Region region_1)
		{
			if (region_1 != null)
			{
				region_0 = region_1;
			}
			else
			{
				region_0 = new Region();
			}
		}

		public GraphicsUnit method_6()
		{
			return graphicsUnit_0;
		}

		public void method_7(GraphicsUnit graphicsUnit_1)
		{
			graphicsUnit_0 = graphicsUnit_1;
			float_0 = Class208.smethod_0(graphicsUnit_1);
		}

		public GClass539 method_8()
		{
			return gclass539_0;
		}

		public int method_9()
		{
			return int_3;
		}

		public void method_10(int int_4)
		{
			if (int_4 >= 0)
			{
				int_3 = int_4;
			}
		}

		private void method_11()
		{
			gclass539_0 = new GClass539();
		}

		private void method_12()
		{
			int num = 16;
			if (gclass458_0 == null)
			{
				throw new GException17("The current page undefined");
			}
		}

		private float method_13(float float_1)
		{
			return Class209.smethod_16(float_1, float_0, Class208.float_5);
		}

		private SizeF method_14(SizeF sizeF_1)
		{
			return Class209.smethod_14(sizeF_1, float_0, Class208.float_5);
		}

		private PointF method_15(PointF pointF_1)
		{
			return Class209.smethod_15(pointF_1, float_0, Class208.float_5);
		}

		private PointF method_16(PointF pointF_1)
		{
			PointF empty = PointF.Empty;
			pointF_1.X = pointF_0.X + pointF_1.X;
			pointF_1.Y = pointF_0.Y + pointF_1.Y;
			pointF_1 = method_15(pointF_1);
			empty.X = pointF_1.X;
			empty.Y = sizeF_0.Height - pointF_1.Y;
			return empty;
		}

		private RectangleF method_17(RectangleF rectangleF_0)
		{
			RectangleF empty = RectangleF.Empty;
			rectangleF_0.Offset(pointF_0);
			rectangleF_0.Location = method_15(rectangleF_0.Location);
			rectangleF_0.Size = method_14(rectangleF_0.Size);
			empty = rectangleF_0;
			empty.Y = sizeF_0.Height - rectangleF_0.Y - rectangleF_0.Height;
			return empty;
		}

		private Enum27 method_18(LineCap lineCap_0)
		{
			switch (lineCap_0)
			{
			default:
				return Enum27.const_0;
			case LineCap.Square:
				return Enum27.const_2;
			case LineCap.Round:
				return Enum27.const_1;
			}
		}

		private Enum28 method_19(LineJoin lineJoin_0)
		{
			switch (lineJoin_0)
			{
			default:
				return Enum28.const_0;
			case LineJoin.Bevel:
				return Enum28.const_2;
			case LineJoin.Round:
				return Enum28.const_1;
			}
		}

		private float[] method_20(Pen pen_0, float float_1)
		{
			float[] array = new float[pen_0.DashPattern.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = pen_0.DashPattern[i];
			}
			return array;
		}

		private StringAlignment method_21(StringFormat stringFormat_0)
		{
			if (stringFormat_0.FormatFlags == StringFormatFlags.DirectionRightToLeft)
			{
				switch (stringFormat_0.Alignment)
				{
				case StringAlignment.Near:
					return StringAlignment.Far;
				case StringAlignment.Far:
					return StringAlignment.Near;
				}
			}
			return stringFormat_0.Alignment;
		}

		private bool method_22(RectangleF rectangleF_0)
		{
			return rectangleF_0 != RectangleF.Empty && rectangleF_0.X >= 0f && rectangleF_0.Y >= 0f && rectangleF_0.Width > 0f && rectangleF_0.Height > 0f;
		}

		private void method_23()
		{
			method_24(RectangleF.Empty);
		}

		private void method_24(RectangleF rectangleF_0)
		{
			RectangleF empty = RectangleF.Empty;
			empty = ((!(rectangleF_0 == RectangleF.Empty)) ? rectangleF_0 : method_61());
			if (method_22(empty))
			{
				empty = method_17(empty);
				gclass458_0.method_22(empty.X, empty.Y, empty.Width, empty.Height);
				gclass458_0.method_33();
			}
		}

		private string method_25(string string_1, float float_1)
		{
			if (string_1 == null || string_1.Length == 0)
			{
				return string_1;
			}
			float[] array = gclass458_0.method_53(string_1.ToCharArray());
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				float_1 -= array[i];
				if (!(float_1 > 0f) && stringBuilder.Length != 0)
				{
					break;
				}
				stringBuilder.Append(string_1[i]);
			}
			return method_27(stringBuilder.ToString());
		}

		private string method_26(string string_1, float float_1)
		{
			if (string_1.Length == 0)
			{
				return string_1;
			}
			if (method_40(string_1) < float_1)
			{
				return string_1;
			}
			string text = string_1;
			string text2 = "";
			int num = string_1.Length;
			int num2 = string_1.Length;
			while (num > 1 && num2 > 1)
			{
				if (method_40(text) < float_1)
				{
					num = num2 / 2;
					if (num2 % 2 != 0)
					{
						num++;
					}
					num2 /= 2;
					text += text2.Substring(0, num);
					text2 = text2.Remove(0, num);
				}
				else
				{
					num2 = num / 2;
					if (num % 2 != 0)
					{
						num2++;
					}
					num /= 2;
					text2 = text.Substring(text.Length - num2, num2) + text2;
					text = text.Remove(text.Length - num2, num2);
				}
			}
			if (method_40(text) >= float_1 && text.Length > 1)
			{
				text = text.Remove(text.Length - 1, 1);
			}
			return method_27(text);
		}

		private string method_27(string string_1)
		{
			if (int_3 > 0 && string_1.Length > int_3)
			{
				string_1 = string_1.Remove(string_1.Length - int_3, int_3);
			}
			return string_1;
		}

		private bool method_28(char char_0)
		{
			return char_0 == ' ' || char_0 == '\t';
		}

		private string method_29(string string_1, string string_2)
		{
			if (string_1.Length == 0 || string_2.Length <= string_1.Length)
			{
				return string_1;
			}
			if (method_28(string_1[string_1.Length - 1]) || method_28(string_2[string_1.Length]))
			{
				return string_1;
			}
			int num = 0;
			int num2 = string_1.Length - 1;
			while (num2 >= 0 && !method_28(string_1[num2]))
			{
				num++;
				num2--;
			}
			return (num < string_1.Length) ? string_1.Remove(string_1.Length - num, num) : string_1;
		}

		private string method_30(string string_1)
		{
			int num = 0;
			int i;
			for (i = 0; i < string_1.Length && method_28(string_1[i]); i++)
			{
				num++;
			}
			string_1 = string_1.Remove(0, num);
			num = 0;
			i = string_1.Length - 1;
			while (i >= 0 && method_28(string_1[i]))
			{
				num++;
				i--;
			}
			return string_1.Remove(string_1.Length - num, num);
		}

		private ArrayList method_31(string string_1, float float_1)
		{
			ArrayList arrayList = new ArrayList();
			string text = "";
			do
			{
				string_1 = method_30(string_1);
				text = method_25(string_1, float_1);
				text = method_29(text, string_1);
				string_1 = string_1.Remove(0, text.Length);
				arrayList.Add(method_30(text));
			}
			while (string_1 != "");
			return arrayList;
		}

		private ArrayList method_32(string[] string_1, float float_1)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < string_1.Length; i++)
			{
				arrayList.AddRange(method_31(string_1[i], float_1));
			}
			return arrayList;
		}

		private string method_33(string string_1)
		{
			return (string_1 != null) ? string_1 : "";
		}

		private Font method_34(Font font_0)
		{
			int num = 10;
			return (font_0 != null) ? font_0 : new Font("Tahoma", 8f);
		}

		private SolidBrush method_35(Brush brush_0)
		{
			return (brush_0 == null || !(brush_0 is SolidBrush)) ? (Brushes.Black as SolidBrush) : (brush_0 as SolidBrush);
		}

		private StringFormat method_36(StringFormat stringFormat_0)
		{
			return (stringFormat_0 != null) ? stringFormat_0 : StringFormat.GenericDefault;
		}

		private Pen method_37(Pen pen_0)
		{
			return (pen_0 != null) ? pen_0 : Pens.Black;
		}

		private float method_38(RectangleF rectangleF_0, float float_1, StringFormat stringFormat_0)
		{
			if (float_1 > 0f)
			{
				switch (method_21(stringFormat_0))
				{
				default:
					return rectangleF_0.Left + 2f;
				case StringAlignment.Center:
					return rectangleF_0.Left + (rectangleF_0.Width - float_1) / 2f;
				case StringAlignment.Far:
					return rectangleF_0.Right - float_1 - 2f;
				}
			}
			return rectangleF_0.Left;
		}

		private float method_39(RectangleF rectangleF_0, float float_1, float float_2, float float_3, StringFormat stringFormat_0)
		{
			if (float_1 > 0f)
			{
				switch (stringFormat_0.LineAlignment)
				{
				default:
					return rectangleF_0.Top + float_1 - float_2;
				case StringAlignment.Near:
					return rectangleF_0.Top + rectangleF_0.Height - float_2 - float_3 - 2f;
				case StringAlignment.Center:
					return rectangleF_0.Top + (rectangleF_0.Height + float_1) / 2f - float_2 - float_3;
				}
			}
			return rectangleF_0.Top;
		}

		private float method_40(string string_1)
		{
			return gclass458_0.method_54(string_1);
		}

		private void method_41(Color color_0, ArrayList arrayList_0, float float_1, RectangleF rectangleF_0)
		{
			if (arrayList_0.Count != 0 && arrayList_0.Count % 2 == 0)
			{
				gclass458_0.method_6();
				gclass458_0.method_16(color_0);
				gclass458_0.method_13(float_1);
				method_24(rectangleF_0);
				gclass458_0.method_24();
				for (int i = 0; i < arrayList_0.Count; i += 2)
				{
					gclass458_0.method_17(((PointF)arrayList_0[i]).X, ((PointF)arrayList_0[i]).Y);
					gclass458_0.method_18(((PointF)arrayList_0[i + 1]).X, ((PointF)arrayList_0[i + 1]).Y);
				}
				gclass458_0.method_25();
				gclass458_0.method_23();
				gclass458_0.method_7();
			}
		}

		private void method_42(float float_1, float float_2, float float_3, float float_4)
		{
			gclass458_0.method_17(float_1, float_2 + float_4 / 2f);
			gclass458_0.method_19(float_1, float_2 + float_4 / 2f - float_4 / 2f * 11f / 20f, float_1 + float_3 / 2f - float_3 / 2f * 11f / 20f, float_2, float_1 + float_3 / 2f, float_2);
			gclass458_0.method_19(float_1 + float_3 / 2f + float_3 / 2f * 11f / 20f, float_2, float_1 + float_3, float_2 + float_4 / 2f - float_4 / 2f * 11f / 20f, float_1 + float_3, float_2 + float_4 / 2f);
			gclass458_0.method_19(float_1 + float_3, float_2 + float_4 / 2f + float_4 / 2f * 11f / 20f, float_1 + float_3 / 2f + float_3 / 2f * 11f / 20f, float_2 + float_4, float_1 + float_3 / 2f, float_2 + float_4);
			gclass458_0.method_19(float_1 + float_3 / 2f - float_3 / 2f * 11f / 20f, float_2 + float_4, float_1, float_2 + float_4 / 2f + float_4 / 2f * 11f / 20f, float_1, float_2 + float_4 / 2f);
		}

		private void method_43(Pen pen_0)
		{
			gclass458_0.method_16(pen_0.Color);
			float num = method_13(pen_0.Width);
			gclass458_0.method_13(num);
			if (pen_0.DashStyle != 0)
			{
				gclass458_0.method_11(method_20(pen_0, num), 0);
			}
			Enum27 @enum = method_18(pen_0.StartCap);
			if (@enum != 0)
			{
				gclass458_0.method_10(@enum);
			}
			Enum28 enum2 = method_19(pen_0.LineJoin);
			if (enum2 != 0)
			{
				gclass458_0.method_12(enum2);
			}
		}

		private string method_44(string string_1)
		{
			int num = 0;
			while (num < string_1.Length)
			{
				if (string_1[num] == '\r')
				{
					string_1 = string_1.Remove(num, 1);
				}
				else
				{
					num++;
				}
			}
			return string_1;
		}

		public void method_45(Pen pen_0, RectangleF rectangleF_0)
		{
			method_12();
			if (pen_0.Color.A != 0)
			{
				rectangleF_0 = method_17(rectangleF_0);
				gclass458_0.method_6();
				method_23();
				gclass458_0.method_24();
				method_43(method_37(pen_0));
				gclass458_0.method_22(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
				gclass458_0.method_26();
				gclass458_0.method_7();
			}
		}

		public void method_46(Pen pen_0, float float_1, float float_2, float float_3, float float_4)
		{
			method_45(pen_0, new RectangleF(float_1, float_2, float_3, float_4));
		}

		public void method_47(Pen pen_0, RectangleF rectangleF_0)
		{
			method_12();
			if (pen_0.Color.A != 0)
			{
				rectangleF_0 = method_17(rectangleF_0);
				gclass458_0.method_6();
				method_23();
				gclass458_0.method_24();
				method_43(method_37(pen_0));
				method_42(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
				gclass458_0.method_26();
				gclass458_0.method_7();
			}
		}

		public void method_48(Pen pen_0, float float_1, float float_2, float float_3, float float_4)
		{
			method_47(pen_0, new RectangleF(float_1, float_2, float_3, float_4));
		}

		public void method_49(Brush brush_0, RectangleF rectangleF_0)
		{
			method_12();
			SolidBrush solidBrush = method_35(brush_0);
			if (solidBrush.Color.A != 0)
			{
				rectangleF_0 = method_17(rectangleF_0);
				gclass458_0.method_6();
				gclass458_0.method_15(solidBrush.Color);
				method_23();
				gclass458_0.method_24();
				gclass458_0.method_22(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
				gclass458_0.method_27();
				gclass458_0.method_23();
				gclass458_0.method_7();
			}
		}

		public void method_50(Brush brush_0, float float_1, float float_2, float float_3, float float_4)
		{
			method_49(brush_0, new RectangleF(float_1, float_2, float_3, float_4));
		}

		public void method_51(Brush brush_0, RectangleF rectangleF_0)
		{
			method_12();
			SolidBrush solidBrush = method_35(brush_0);
			if (solidBrush.Color.A != 0)
			{
				rectangleF_0 = method_17(rectangleF_0);
				gclass458_0.method_6();
				gclass458_0.method_15(solidBrush.Color);
				method_23();
				gclass458_0.method_24();
				method_42(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
				gclass458_0.method_27();
				gclass458_0.method_23();
				gclass458_0.method_7();
			}
		}

		public void method_52(Brush brush_0, float float_1, float float_2, float float_3, float float_4)
		{
			method_51(brush_0, new RectangleF(float_1, float_2, float_3, float_4));
		}

		public void method_53(string string_1, Font font_0, Brush brush_0, RectangleF rectangleF_0, StringFormat stringFormat_0)
		{
			method_12();
			string_1 = method_33(string_1);
			string_1 = method_44(string_1);
			font_0 = method_34(font_0);
			SolidBrush solidBrush = method_35(brush_0);
			if (solidBrush.Color.A == 0)
			{
				return;
			}
			stringFormat_0 = method_36(stringFormat_0);
			RectangleF rectangleF_ = rectangleF_0;
			rectangleF_0 = method_17(rectangleF_0);
			GClass476 gClass = gclass539_0.method_8(font_0);
			if (!gClass.method_13(string_1))
			{
				gClass = gclass539_0.method_9(method_0(), font_0.Size, font_0.Style);
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			float float_ = font_0.Size / 14f;
			gclass458_0.method_6();
			method_24(rectangleF_);
			gclass458_0.method_24();
			gclass458_0.method_35();
			gclass458_0.method_15(solidBrush.Color);
			gclass458_0.method_16(solidBrush.Color);
			gclass458_0.method_37(gClass, font_0.Size);
			string[] array = string_1.Split('\n');
			ArrayList arrayList3 = null;
			if ((stringFormat_0.FormatFlags & StringFormatFlags.NoWrap) != 0)
			{
				arrayList3 = new ArrayList();
				for (int i = 0; i < array.Length; i++)
				{
					arrayList3.Add(array[i]);
				}
			}
			else
			{
				arrayList3 = method_32(array, rectangleF_0.Width);
			}
			if (arrayList3.Count > 0)
			{
				_ = font_0.FontFamily;
				int emHeight = font_0.FontFamily.GetEmHeight(font_0.Style);
				float num = (float)font_0.FontFamily.GetLineSpacing(font_0.Style) * font_0.Size / (float)emHeight;
				float num2 = (float)((double)((float)font_0.FontFamily.GetCellAscent(font_0.Style) * font_0.Size / (float)emHeight) * 0.7);
				float num3 = (float)((double)((float)font_0.FontFamily.GetCellDescent(font_0.Style) * font_0.Size / (float)emHeight) * 0.7);
				float float_2 = num * (float)(arrayList3.Count - 1) + num2 + num3;
				float num4 = method_38(rectangleF_0, method_40((string)arrayList3[0]), stringFormat_0);
				float num5 = method_39(rectangleF_0, float_2, num2, num3, stringFormat_0);
				float num6 = 0f - (float)((double)(num2 + num3) * 0.2);
				float num7 = (float)((double)(num2 - num3) * 0.5);
				gclass458_0.method_38(num4, num5);
				gclass458_0.method_40((string)arrayList3[0]);
				if (font_0.Underline)
				{
					arrayList.Add(new PointF(num4, num5 + num6));
					arrayList.Add(new PointF(num4 + method_40((string)arrayList3[0]), num5 + num6));
				}
				if (font_0.Strikeout)
				{
					arrayList2.Add(new PointF(num4, num5 + num7));
					arrayList2.Add(new PointF(num4 + method_40((string)arrayList3[0]), num5 + num7));
				}
				float num8 = 0f;
				for (int i = 1; i < arrayList3.Count; i++)
				{
					float num9 = method_38(rectangleF_0, method_40((string)arrayList3[i]), stringFormat_0) - num4;
					gclass458_0.method_38(num9, 0f - num);
					gclass458_0.method_40((string)arrayList3[i]);
					num4 += num9;
					num8 += num;
					if (font_0.Underline)
					{
						arrayList.Add(new PointF(num4, num5 + num6 - num8));
						arrayList.Add(new PointF(num4 + method_40((string)arrayList3[i]), num5 + num6 - num8));
					}
					if (font_0.Strikeout)
					{
						arrayList2.Add(new PointF(num4, num5 + num7 - num8));
						arrayList2.Add(new PointF(num4 + method_40((string)arrayList3[i]), num5 + num7 - num8));
					}
				}
			}
			gclass458_0.method_36();
			gclass458_0.method_23();
			gclass458_0.method_7();
			method_41(solidBrush.Color, arrayList, float_, rectangleF_);
			method_41(solidBrush.Color, arrayList2, float_, rectangleF_);
		}

		public void method_54(Pen pen_0, PointF[] pointF_1)
		{
			if (pen_0 != null && pointF_1 != null && pointF_1.Length > 1)
			{
				for (int i = 0; i < pointF_1.Length - 1; i++)
				{
					method_55(pen_0, pointF_1[i], pointF_1[i + 1]);
				}
			}
		}

		public void method_55(Pen pen_0, PointF pointF_1, PointF pointF_2)
		{
			method_12();
			if (pen_0.Color.A != 0)
			{
				pointF_1 = method_16(pointF_1);
				pointF_2 = method_16(pointF_2);
				gclass458_0.method_6();
				method_23();
				gclass458_0.method_24();
				method_43(method_37(pen_0));
				gclass458_0.method_17(pointF_1.X, pointF_1.Y);
				gclass458_0.method_18(pointF_2.X, pointF_2.Y);
				gclass458_0.method_25();
				gclass458_0.method_23();
				gclass458_0.method_7();
			}
		}

		public void method_56(Pen pen_0, float float_1, float float_2, float float_3, float float_4)
		{
			method_55(pen_0, new PointF(float_1, float_2), new PointF(float_3, float_4));
		}

		public void method_57(Image image_0, RectangleF rectangleF_0)
		{
			method_58(image_0, rectangleF_0, bool_3: false);
		}

		public GClass456 method_58(Image image_0, RectangleF rectangleF_0, bool bool_3)
		{
			if (image_0 == null)
			{
				return null;
			}
			method_12();
			rectangleF_0 = method_17(rectangleF_0);
			GClass456 gClass = gclass539_0.method_11(image_0, Class209.smethod_16(rectangleF_0.Width, Class208.float_5, Class208.float_4), Class209.smethod_16(rectangleF_0.Height, Class208.float_5, Class208.float_4));
			gClass.method_6(bool_3);
			RectangleF rectangleF_ = method_61();
			if (method_22(rectangleF_))
			{
				rectangleF_ = method_17(rectangleF_);
				gclass458_0.method_52(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, rectangleF_.X, rectangleF_.Y, rectangleF_.Width, rectangleF_.Height, gClass);
			}
			else
			{
				gclass458_0.method_51(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, gClass);
			}
			return gClass;
		}

		public void method_59(SizeF sizeF_1)
		{
			int num = 3;
			if (sizeF_1.Width <= 0f)
			{
				throw new GException17("Invalid page width");
			}
			if (sizeF_1.Height <= 0f)
			{
				throw new GException17("Invalid page height");
			}
			sizeF_1 = method_14(sizeF_1);
			GClass468 gClass = null;
			if (bool_0)
			{
				gClass = (gclass539_0.method_13().method_4().method_9(0) as GClass468);
				bool_0 = false;
			}
			else
			{
				gClass = gclass539_0.method_13().method_4().method_12();
			}
			gClass.method_5(new GClass516(0, 0, (int)sizeF_1.Width, (int)sizeF_1.Height));
			sizeF_0 = sizeF_1;
			gclass458_0 = gClass.method_14();
		}

		public void method_60(float float_1, float float_2)
		{
			method_59(new SizeF(float_1, float_2));
		}

		public void Dispose()
		{
			if (!bool_1)
			{
				gclass539_0.method_5(streamWriter_0);
				if (bool_2)
				{
					streamWriter_0.Close();
				}
				else
				{
					streamWriter_0.Flush();
				}
				gclass539_0.Dispose();
				if (gclass458_0 != null)
				{
					gclass458_0.Dispose();
					gclass458_0 = null;
				}
				if (region_0 != null)
				{
					region_0.Dispose();
					region_0 = null;
				}
				bool_1 = true;
			}
		}

		public RectangleF method_61()
		{
			RectangleF result = RectangleF.Empty;
			RectangleF[] regionScans = region_0.GetRegionScans(new Matrix());
			if (regionScans.Length > 0)
			{
				result = regionScans[0];
			}
			return result;
		}
	}
}
