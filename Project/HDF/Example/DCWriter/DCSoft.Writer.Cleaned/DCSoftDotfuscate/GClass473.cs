#define DEBUG
using DCSoft.Drawing;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class RectangleDrawer : IDisposable
	{
		private Rectangle rectangle_0 = Rectangle.Empty;

		private int int_0 = 0;

		private Pen pen_0 = null;

		private bool bool_0 = true;

		private Brush brush_0 = null;

		private bool bool_1 = true;

		public static bool DrawRectangle(Graphics graphics_0, Pen pen_1, Brush brush_1, Rectangle rectangle_1, int int_1, Rectangle rectangle_2, bool bool_2)
		{
			Rectangle empty = Rectangle.Empty;
			empty = ((!rectangle_2.IsEmpty) ? Rectangle.Intersect(rectangle_1, rectangle_2) : rectangle_1);
			if (empty.IsEmpty)
			{
				return false;
			}
			if (int_1 <= 0)
			{
				if (brush_1 != null)
				{
					graphics_0.FillRectangle(brush_1, empty);
				}
				if (pen_1 != null)
				{
					empty = new Rectangle(rectangle_1.Left, rectangle_1.Top, rectangle_1.Width - (int)Math.Ceiling((double)pen_1.Width / 2.0), rectangle_1.Height - (int)Math.Ceiling((double)pen_1.Width / 2.0));
					if (bool_2 || rectangle_2.IsEmpty)
					{
						graphics_0.DrawRectangle(pen_1, empty);
					}
					else if (empty.IntersectsWith(rectangle_2))
					{
						graphics_0.DrawRectangle(pen_1, empty);
					}
				}
			}
			else
			{
				if (brush_1 != null)
				{
					int num = 0;
					if (pen_1 != null)
					{
						num = (int)Math.Ceiling((double)pen_1.Width / 2.0);
					}
					using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(new RectangleF(rectangle_1.Left, rectangle_1.Top, rectangle_1.Width - num, rectangle_1.Height - num), int_1))
					{
						graphics_0.FillPath(brush_1, path);
					}
				}
				if (pen_1 != null)
				{
					using (GraphicsPath path = ShapeDrawer.CreateRoundRectanglePath(new RectangleF(rectangle_1.Left, rectangle_1.Top, rectangle_1.Width - (int)Math.Ceiling((double)pen_1.Width / 2.0), rectangle_1.Height - (int)Math.Ceiling((double)pen_1.Width / 2.0)), int_1))
					{
						if (bool_2 || rectangle_2.IsEmpty)
						{
							graphics_0.DrawPath(pen_1, path);
						}
						else if (empty.IntersectsWith(rectangle_2))
						{
							graphics_0.DrawPath(pen_1, path);
						}
					}
				}
			}
			return true;
		}

		public RectangleDrawer()
		{
		}

		public RectangleDrawer(Rectangle rectangle_1, Color color_0, Color color_1)
		{
			rectangle_0 = rectangle_1;
			if (color_0.A != 0)
			{
				pen_0 = new Pen(color_0, 1f);
			}
			if (color_1.A != 0)
			{
				brush_0 = new SolidBrush(color_1);
			}
		}

		public Rectangle method_0()
		{
			return rectangle_0;
		}

		public void method_1(Rectangle rectangle_1)
		{
			rectangle_0 = rectangle_1;
		}

		public int method_2()
		{
			return int_0;
		}

		public void method_3(int int_1)
		{
			int_0 = int_1;
		}

		public Pen method_4()
		{
			return pen_0;
		}

		public void method_5(Pen pen_1)
		{
			pen_0 = pen_1;
		}

		public bool method_6()
		{
			return bool_0;
		}

		public void method_7(bool bool_2)
		{
			bool_0 = bool_2;
		}

		public Brush method_8()
		{
			return brush_0;
		}

		public void method_9(Brush brush_1)
		{
			brush_0 = brush_1;
		}

		public bool method_10()
		{
			return bool_1;
		}

		public void method_11(bool bool_2)
		{
			bool_1 = bool_2;
		}

		public bool method_12()
		{
			if (rectangle_0.IsEmpty)
			{
				return false;
			}
			if (method_6() && pen_0 != null)
			{
				return true;
			}
			if (method_10() && brush_0 != null)
			{
				return true;
			}
			return false;
		}

		public bool method_13(Graphics graphics_0, Rectangle rectangle_1)
		{
			int num = 15;
			if (graphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			Pen pen_ = null;
			if (bool_0)
			{
				pen_ = pen_0;
			}
			Brush brush_ = null;
			if (bool_1)
			{
				brush_ = brush_0;
			}
			try
			{
				return DrawRectangle(graphics_0, pen_, brush_, rectangle_0, method_2(), rectangle_1, bool_2: true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				return false;
			}
		}

		public bool method_14(Graphics graphics_0, Rectangle rectangle_1)
		{
			int num = 10;
			if (graphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			Pen pen_ = null;
			if (bool_0)
			{
				pen_ = pen_0;
			}
			return DrawRectangle(graphics_0, pen_, null, rectangle_0, method_2(), rectangle_1, bool_2: true);
		}

		public void Dispose()
		{
			if (pen_0 != null)
			{
				pen_0.Dispose();
				pen_0 = null;
			}
			if (brush_0 != null)
			{
				brush_0.Dispose();
				brush_0 = null;
			}
		}
	}
}
