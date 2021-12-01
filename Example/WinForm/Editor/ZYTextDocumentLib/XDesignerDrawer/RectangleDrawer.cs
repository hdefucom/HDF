using System;
using System.Drawing;

namespace XDesignerDrawer
{
	public class RectangleDrawer : IDisposable
	{
		private Rectangle myBounds = Rectangle.Empty;

		private Pen myBorderPen = null;

		private bool bolIsDrawBorder = true;

		private Brush myFillBrush = null;

		private bool bolIsFill = true;

		public Rectangle Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
				myBounds = value;
			}
		}

		public Pen BorderPen
		{
			get
			{
				return myBorderPen;
			}
			set
			{
				myBorderPen = value;
			}
		}

		public bool IsDrawBorder
		{
			get
			{
				return bolIsDrawBorder;
			}
			set
			{
				bolIsDrawBorder = value;
			}
		}

		public Brush FillBrush
		{
			get
			{
				return myFillBrush;
			}
			set
			{
				myFillBrush = value;
			}
		}

		public bool IsFill
		{
			get
			{
				return bolIsFill;
			}
			set
			{
				bolIsFill = value;
			}
		}

		public bool CanDraw
		{
			get
			{
				if (myBounds.IsEmpty)
				{
					return false;
				}
				if (IsDrawBorder && myBorderPen != null)
				{
					return true;
				}
				if (IsFill && myFillBrush != null)
				{
					return true;
				}
				return false;
			}
		}

		public static bool DrawRectangle(Graphics g, Pen BorderPen, Brush FillBrush, Rectangle Bounds, Rectangle ClipRectangle, bool ForceDrawBorder)
		{
			Rectangle empty = Rectangle.Empty;
			empty = ((!ClipRectangle.IsEmpty) ? Rectangle.Intersect(Bounds, ClipRectangle) : Bounds);
			if (empty.IsEmpty)
			{
				return false;
			}
			if (FillBrush != null)
			{
				g.FillRectangle(FillBrush, empty);
			}
			if (BorderPen != null)
			{
				empty = new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width - (int)Math.Ceiling((double)BorderPen.Width / 2.0), Bounds.Height - (int)Math.Ceiling((double)BorderPen.Width / 2.0));
				if (ForceDrawBorder || ClipRectangle.IsEmpty)
				{
					g.DrawRectangle(BorderPen, empty);
				}
				else if (empty.IntersectsWith(ClipRectangle))
				{
					g.DrawRectangle(BorderPen, empty);
				}
			}
			return true;
		}

		public RectangleDrawer()
		{
		}

		public RectangleDrawer(Rectangle bounds, Color BorderColor, Color FillColor)
		{
			myBounds = bounds;
			if (BorderColor.A != 0)
			{
				myBorderPen = new Pen(BorderColor, 1f);
			}
			if (FillColor.A != 0)
			{
				myFillBrush = new SolidBrush(FillColor);
			}
		}

		public bool Draw(Graphics g, Rectangle ClipRectangle)
		{
			if (g == null)
			{
				throw new ArgumentNullException("g");
			}
			Pen borderPen = null;
			if (bolIsDrawBorder)
			{
				borderPen = myBorderPen;
			}
			Brush fillBrush = null;
			if (bolIsFill)
			{
				fillBrush = myFillBrush;
			}
			return DrawRectangle(g, borderPen, fillBrush, myBounds, ClipRectangle, ForceDrawBorder: true);
		}

		public void Dispose()
		{
			if (myBorderPen != null)
			{
				myBorderPen.Dispose();
				myBorderPen = null;
			}
			if (myFillBrush != null)
			{
				myFillBrush.Dispose();
				myFillBrush = null;
			}
		}
	}
}
