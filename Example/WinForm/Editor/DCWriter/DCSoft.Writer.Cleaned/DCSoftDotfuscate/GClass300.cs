using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.WinForms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	
	[ComVisible(false)]
	public class GClass300
	{
		private Rectangle rectangle_0 = Rectangle.Empty;

		private Rectangle[] rectangle_1 = new Rectangle[8];

		public static int int_0 = 6;

		private bool bool_0 = false;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private ResizeableType resizeableType_0 = ResizeableType.WidthAndHeight;

		private bool bool_4 = true;

		private bool bool_5 = true;

		public static Color color_0 = Color.Blue;

		public static Color color_1 = Color.LightGray;

		public static Color color_2 = Color.White;

		public static Color color_3 = Color.LightGray;

		private DashStyle dashStyle_0 = DashStyle.Dash;

		public GClass300()
		{
		}

		public GClass300(Rectangle rectangle_2, bool bool_6)
		{
			rectangle_0 = rectangle_2;
			bool_0 = bool_6;
			method_17();
		}

		public ResizeableType method_0()
		{
			return resizeableType_0;
		}

		public void method_1(ResizeableType resizeableType_1)
		{
			resizeableType_0 = resizeableType_1;
		}

		public bool method_2()
		{
			return bool_3;
		}

		public void method_3(bool bool_6)
		{
			bool_3 = bool_6;
		}

		public bool method_4()
		{
			return bool_2;
		}

		public void method_5(bool bool_6)
		{
			bool_2 = bool_6;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_6)
		{
			bool_0 = bool_6;
		}

		public Rectangle method_8()
		{
			return rectangle_0;
		}

		public void method_9(Rectangle rectangle_2)
		{
			rectangle_0 = rectangle_2;
			method_17();
		}

		public Rectangle[] method_10()
		{
			return rectangle_1;
		}

		public bool method_11()
		{
			return bool_1;
		}

		public void method_12(bool bool_6)
		{
			bool_1 = bool_6;
		}

		public bool method_13()
		{
			return bool_4;
		}

		public void method_14(bool bool_6)
		{
			bool_4 = bool_6;
		}

		public bool method_15()
		{
			return bool_5;
		}

		public void method_16(bool bool_6)
		{
			bool_5 = bool_6;
		}

		public void method_17()
		{
			if (bool_0)
			{
				rectangle_1[0] = new Rectangle(rectangle_0.X, rectangle_0.Y, int_0, int_0);
				rectangle_1[1] = new Rectangle(rectangle_0.X + (rectangle_0.Width - int_0) / 2, rectangle_0.Y, int_0, int_0);
				rectangle_1[2] = new Rectangle(rectangle_0.Right - int_0, rectangle_0.Y, int_0, int_0);
				rectangle_1[3] = new Rectangle(rectangle_0.Right - int_0, rectangle_0.Y + (rectangle_0.Height - int_0) / 2, int_0, int_0);
				rectangle_1[4] = new Rectangle(rectangle_0.Right - int_0, rectangle_0.Bottom - int_0, int_0, int_0);
				rectangle_1[5] = new Rectangle(rectangle_0.X + (rectangle_0.Width - int_0) / 2, rectangle_0.Bottom - int_0, int_0, int_0);
				rectangle_1[6] = new Rectangle(rectangle_0.X, rectangle_0.Bottom - int_0, int_0, int_0);
				rectangle_1[7] = new Rectangle(rectangle_0.X, rectangle_0.Y + (rectangle_0.Height - int_0) / 2, int_0, int_0);
			}
			else
			{
				rectangle_1[0] = new Rectangle(rectangle_0.X - int_0, rectangle_0.Y - int_0, int_0, int_0);
				rectangle_1[1] = new Rectangle(rectangle_0.X + (rectangle_0.Width - int_0) / 2, rectangle_0.Y - int_0, int_0, int_0);
				rectangle_1[2] = new Rectangle(rectangle_0.Right, rectangle_0.Y - int_0, int_0, int_0);
				rectangle_1[3] = new Rectangle(rectangle_0.Right, rectangle_0.Y + (rectangle_0.Height - int_0) / 2, int_0, int_0);
				rectangle_1[4] = new Rectangle(rectangle_0.Right, rectangle_0.Bottom, int_0, int_0);
				rectangle_1[5] = new Rectangle(rectangle_0.X + (rectangle_0.Width - int_0) / 2, rectangle_0.Bottom, int_0, int_0);
				rectangle_1[6] = new Rectangle(rectangle_0.X - int_0, rectangle_0.Bottom, int_0, int_0);
				rectangle_1[7] = new Rectangle(rectangle_0.X - int_0, rectangle_0.Y + (rectangle_0.Height - int_0) / 2, int_0, int_0);
			}
		}

		public static void smethod_0(Graphics graphics_0, Rectangle rectangle_2, bool bool_6, GEnum72 genum72_0, ResizeableType resizeableType_1, bool bool_7)
		{
			smethod_1(new DCGraphics(graphics_0), rectangle_2, bool_6, genum72_0, resizeableType_1, bool_7);
		}

		public static void smethod_1(DCGraphics dcgraphics_0, Rectangle rectangle_2, bool bool_6, GEnum72 genum72_0, ResizeableType resizeableType_1, bool bool_7)
		{
			bool flag = smethod_3(genum72_0, resizeableType_1, bool_7);
			Color blue = Color.Blue;
			blue = ((!flag) ? Color.White : ((!bool_6) ? Color.Black : Color.Blue));
			dcgraphics_0.method_4(blue, rectangle_2);
			blue = ((!flag) ? Color.Black : ((!bool_6) ? Color.Blue : Color.White));
			dcgraphics_0.DrawRectangle(blue, rectangle_2.Left, rectangle_2.Top, rectangle_2.Width, rectangle_2.Height);
		}

		public static Rectangle smethod_2(Point point_0)
		{
			return new Rectangle(point_0.X - int_0 / 2, point_0.Y - int_0 / 2, int_0, int_0);
		}

		public DashStyle method_18()
		{
			return dashStyle_0;
		}

		public void method_19(DashStyle dashStyle_1)
		{
			dashStyle_0 = dashStyle_1;
		}

		public void method_20(Graphics graphics_0)
		{
			method_21(new DCGraphics(graphics_0));
		}

		public void method_21(DCGraphics dcgraphics_0)
		{
			if (dcgraphics_0 != null)
			{
				if (bool_3)
				{
					XPenStyle xPenStyle = new XPenStyle(Color.Black);
					xPenStyle.DashStyle = method_18();
					dcgraphics_0.DrawRectangle(xPenStyle, rectangle_0);
				}
				smethod_1(dcgraphics_0, rectangle_1[0], method_4(), GEnum72.const_2, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[1], method_4(), GEnum72.const_3, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[2], method_4(), GEnum72.const_4, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[3], method_4(), GEnum72.const_5, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[4], method_4(), GEnum72.const_6, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[5], method_4(), GEnum72.const_7, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[6], method_4(), GEnum72.const_8, method_0(), method_11());
				smethod_1(dcgraphics_0, rectangle_1[7], method_4(), GEnum72.const_9, method_0(), method_11());
			}
		}

		private bool method_22(GEnum72 genum72_0)
		{
			return smethod_3(genum72_0, method_0(), method_11());
		}

		private static bool smethod_3(GEnum72 genum72_0, ResizeableType resizeableType_1, bool bool_6)
		{
			switch (genum72_0)
			{
			default:
				return false;
			case GEnum72.const_1:
				return bool_6;
			case GEnum72.const_2:
				return bool_6 && resizeableType_1 == ResizeableType.WidthAndHeight;
			case GEnum72.const_3:
				return bool_6 && (resizeableType_1 == ResizeableType.WidthAndHeight || resizeableType_1 == ResizeableType.Height);
			case GEnum72.const_4:
				return bool_6 && resizeableType_1 == ResizeableType.WidthAndHeight;
			case GEnum72.const_5:
				return resizeableType_1 == ResizeableType.WidthAndHeight || resizeableType_1 == ResizeableType.Width;
			case GEnum72.const_6:
				return resizeableType_1 == ResizeableType.WidthAndHeight;
			case GEnum72.const_7:
				return resizeableType_1 == ResizeableType.Height || resizeableType_1 == ResizeableType.WidthAndHeight;
			case GEnum72.const_8:
				return bool_6 && resizeableType_1 == ResizeableType.WidthAndHeight;
			case GEnum72.const_9:
				return bool_6 && (resizeableType_1 == ResizeableType.WidthAndHeight || resizeableType_1 == ResizeableType.Width);
			}
		}

		public GEnum72 method_23(int int_1, int int_2)
		{
			if (method_0() == ResizeableType.FixSize && rectangle_0.Contains(int_1, int_2))
			{
				return GEnum72.const_1;
			}
			int num = 0;
			while (true)
			{
				if (num < 8)
				{
					if (rectangle_1[num].Contains(int_1, int_2))
					{
						break;
					}
					num++;
					continue;
				}
				if (rectangle_0.Contains(int_1, int_2) && method_11())
				{
					return GEnum72.const_1;
				}
				return GEnum72.const_0;
			}
			if (method_22((GEnum72)num))
			{
				return (GEnum72)num;
			}
			return GEnum72.const_0;
		}

		public static Rectangle smethod_4(int int_1, int int_2, GEnum72 genum72_0, Rectangle rectangle_2)
		{
			if (genum72_0 == GEnum72.const_1)
			{
				rectangle_2.Offset(int_1, int_2);
			}
			if (genum72_0 == GEnum72.const_2 || genum72_0 == GEnum72.const_9 || genum72_0 == GEnum72.const_8)
			{
				rectangle_2.Offset(int_1, 0);
				rectangle_2.Width -= int_1;
			}
			if (genum72_0 == GEnum72.const_2 || genum72_0 == GEnum72.const_3 || genum72_0 == GEnum72.const_4)
			{
				rectangle_2.Offset(0, int_2);
				rectangle_2.Height -= int_2;
			}
			if (genum72_0 == GEnum72.const_4 || genum72_0 == GEnum72.const_5 || genum72_0 == GEnum72.const_6)
			{
				rectangle_2.Width += int_1;
			}
			if (genum72_0 == GEnum72.const_6 || genum72_0 == GEnum72.const_7 || genum72_0 == GEnum72.const_8)
			{
				rectangle_2.Height += int_2;
			}
			return rectangle_2;
		}

		public static Rectangle[] smethod_5(Rectangle rectangle_2, int int_1, bool bool_6)
		{
			Rectangle[] array = new Rectangle[8];
			if (bool_6)
			{
				array[0] = new Rectangle(rectangle_2.X, rectangle_2.Y, int_1, int_1);
				array[1] = new Rectangle(rectangle_2.X + (rectangle_2.Width - int_1) / 2, rectangle_2.Y, int_1, int_1);
				array[2] = new Rectangle(rectangle_2.Right - int_1, rectangle_2.Y, int_1, int_1);
				array[3] = new Rectangle(rectangle_2.Right - int_1, rectangle_2.Y + (rectangle_2.Height - int_1) / 2, int_1, int_1);
				array[4] = new Rectangle(rectangle_2.Right - int_1, rectangle_2.Bottom - int_1, int_1, int_1);
				array[5] = new Rectangle(rectangle_2.X + (rectangle_2.Width - int_1) / 2, rectangle_2.Bottom - int_1, int_1, int_1);
				array[6] = new Rectangle(rectangle_2.X, rectangle_2.Bottom - int_1, int_1, int_1);
				array[7] = new Rectangle(rectangle_2.X, rectangle_2.Y + (rectangle_2.Height - int_1) / 2, int_1, int_1);
			}
			else
			{
				array[0] = new Rectangle(rectangle_2.X - int_1, rectangle_2.Y - int_1, int_1, int_1);
				array[1] = new Rectangle(rectangle_2.X + (rectangle_2.Width - int_1) / 2, rectangle_2.Y - int_1, int_1, int_1);
				array[2] = new Rectangle(rectangle_2.Right, rectangle_2.Y - int_1, int_1, int_1);
				array[3] = new Rectangle(rectangle_2.Right, rectangle_2.Y + (rectangle_2.Height - int_1) / 2, int_1, int_1);
				array[4] = new Rectangle(rectangle_2.Right, rectangle_2.Bottom, int_1, int_1);
				array[5] = new Rectangle(rectangle_2.X + (rectangle_2.Width - int_1) / 2, rectangle_2.Bottom, int_1, int_1);
				array[6] = new Rectangle(rectangle_2.X - int_1, rectangle_2.Bottom, int_1, int_1);
				array[7] = new Rectangle(rectangle_2.X - int_1, rectangle_2.Y + (rectangle_2.Height - int_1) / 2, int_1, int_1);
			}
			return array;
		}

		public static Cursor smethod_6(GEnum72 genum72_0)
		{
			switch (genum72_0)
			{
			default:
				return Cursors.Default;
			case GEnum72.const_1:
				return Cursors.Arrow;
			case GEnum72.const_2:
				return Cursors.SizeNWSE;
			case GEnum72.const_3:
				return Cursors.SizeNS;
			case GEnum72.const_4:
				return Cursors.SizeNESW;
			case GEnum72.const_5:
				return Cursors.SizeWE;
			case GEnum72.const_6:
				return Cursors.SizeNWSE;
			case GEnum72.const_7:
				return Cursors.SizeNS;
			case GEnum72.const_8:
				return Cursors.SizeNESW;
			case GEnum72.const_9:
				return Cursors.SizeWE;
			}
		}

		public static Point smethod_7(Rectangle rectangle_2, GEnum72 genum72_0)
		{
			int x = rectangle_2.Left;
			int y = rectangle_2.Top;
			switch (genum72_0)
			{
			case GEnum72.const_2:
				x = rectangle_2.Left;
				y = rectangle_2.Top;
				break;
			case GEnum72.const_3:
				x = rectangle_2.Left + rectangle_2.Width / 2;
				y = rectangle_2.Top;
				break;
			case GEnum72.const_4:
				x = rectangle_2.Right;
				y = rectangle_2.Top;
				break;
			case GEnum72.const_5:
				x = rectangle_2.Right;
				y = rectangle_2.Top + rectangle_2.Height / 2;
				break;
			case GEnum72.const_6:
				x = rectangle_2.Right;
				y = rectangle_2.Bottom;
				break;
			case GEnum72.const_7:
				x = rectangle_2.Left + rectangle_2.Width / 2;
				y = rectangle_2.Bottom;
				break;
			case GEnum72.const_8:
				x = rectangle_2.Left;
				y = rectangle_2.Bottom;
				break;
			case GEnum72.const_9:
				x = rectangle_2.X;
				y = rectangle_2.Top + rectangle_2.Height / 2;
				break;
			}
			return new Point(x, y);
		}
	}
}
