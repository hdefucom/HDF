using DCSoft.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass441 : List<GClass442>
	{
		private Color color_0 = Color.White;

		private Color color_1 = Color.Black;

		private Color color_2 = Color.Black;

		private XFontValue xfontValue_0 = new XFontValue();

		public void method_0(XBrushStyleConst xbrushStyleConst_0, string string_0)
		{
			GClass442 gClass = new GClass442();
			gClass.method_1(xbrushStyleConst_0);
			gClass.method_3(string_0);
			Add(gClass);
		}

		public override string ToString()
		{
			int num = 9;
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass442 current = enumerator.Current;
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(';');
					}
					stringBuilder.Append(current.method_2() + "=" + current.method_0());
				}
			}
			return stringBuilder.ToString();
		}

		public void method_1(string string_0)
		{
			Clear();
			if (string.IsNullOrEmpty(string_0))
			{
				return;
			}
			string[] array = string_0.Split(';');
			string[] array2 = array;
			foreach (string text in array2)
			{
				int num = text.IndexOf('=');
				if (num > 0)
				{
					try
					{
						string string_ = text.Substring(0, num);
						string value = text.Substring(num + 1);
						XBrushStyleConst xbrushStyleConst_ = (XBrushStyleConst)Enum.Parse(typeof(XBrushStyleConst), value);
						GClass442 gClass = new GClass442();
						gClass.method_3(string_);
						gClass.method_1(xbrushStyleConst_);
						Add(gClass);
					}
					catch
					{
					}
				}
			}
		}

		public GClass441 method_2()
		{
			GClass441 gClass = new GClass441();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					GClass442 current = enumerator.Current;
					gClass.method_0(current.method_0(), current.method_2());
				}
			}
			return gClass;
		}

		public void method_3(ListBox listBox_0)
		{
			if (listBox_0 != null)
			{
				listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
				listBox_0.ItemHeight = method_12().Height;
				listBox_0.MeasureItem += method_5;
				listBox_0.DrawItem += method_4;
				using (Enumerator enumerator = GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						GClass442 current = enumerator.Current;
						listBox_0.Items.Add(current);
					}
				}
			}
		}

		private void method_4(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				ListBox listBox = (ListBox)sender;
				GClass442 gclass442_ = (GClass442)listBox.Items[e.Index];
				e.DrawBackground();
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					method_11(SystemColors.HighlightText);
				}
				else
				{
					method_11(SystemColors.ControlText);
				}
				method_16(e.Graphics, e.Bounds, gclass442_);
			}
		}

		private void method_5(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = method_12().Height;
			e.ItemWidth = method_12().Width;
		}

		public static void smethod_0(ListBox listBox_0, XBrushStyleConst xbrushStyleConst_0)
		{
			foreach (GClass442 item in listBox_0.Items)
			{
				if (item.method_0() == xbrushStyleConst_0)
				{
					listBox_0.SelectedItem = item;
					break;
				}
			}
		}

		public static XBrushStyleConst smethod_1(ListBox listBox_0)
		{
			GClass442 gClass = listBox_0.SelectedItem as GClass442;
			return gClass.method_0();
		}

		public Color method_6()
		{
			return color_0;
		}

		public void method_7(Color color_3)
		{
			color_0 = color_3;
		}

		public Color method_8()
		{
			return color_1;
		}

		public void method_9(Color color_3)
		{
			color_1 = color_3;
		}

		public Color method_10()
		{
			return color_2;
		}

		public void method_11(Color color_3)
		{
			color_2 = color_3;
		}

		public Size method_12()
		{
			return new Size(25, 20);
		}

		public XFontValue method_13()
		{
			return xfontValue_0;
		}

		public void method_14(XFontValue xfontValue_1)
		{
			xfontValue_0 = xfontValue_1;
		}

		public void method_15()
		{
			foreach (XBrushStyleConst value in Enum.GetValues(typeof(XBrushStyleConst)))
			{
				method_0(value, value.ToString());
			}
		}

		private void method_16(Graphics graphics_0, Rectangle rectangle_0, GClass442 gclass442_0)
		{
			int num = 1;
			if (graphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			if (gclass442_0 == null)
			{
				throw new ArgumentNullException("item");
			}
			XBrushStyle xBrushStyle = new XBrushStyle(method_6());
			xBrushStyle.Color2 = method_8();
			xBrushStyle.Style = gclass442_0.method_0();
			Rectangle rect = new Rectangle(rectangle_0.Left + 2, rectangle_0.Top + 2 + (rectangle_0.Height - method_12().Height) / 2, method_12().Width - 4, method_12().Height - 4);
			Brush brush = xBrushStyle.method_2(rectangle_0);
			if (brush != null)
			{
				graphics_0.FillRectangle(brush, rect);
				brush.Dispose();
			}
			graphics_0.DrawRectangle(Pens.Black, rect);
			if (!string.IsNullOrEmpty(gclass442_0.method_2()))
			{
				RectangleF layoutRectangle = new RectangleF(rectangle_0.Left + method_12().Width + 1, rectangle_0.Top, rectangle_0.Width - method_12().Width - 2, rectangle_0.Height);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					using (SolidBrush brush2 = new SolidBrush(method_10()))
					{
						graphics_0.DrawString(gclass442_0.method_2(), method_13().Value, brush2, layoutRectangle, stringFormat);
					}
				}
			}
		}
	}
}
