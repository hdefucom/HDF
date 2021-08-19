using System.Drawing;

namespace ZYCommon
{
	public class RectangleObject
	{
		protected int intLeft = 0;

		protected int intTop = 0;

		protected int intWidth = 0;

		protected int intHeight = 0;

		public int Left
		{
			get
			{
				return intLeft;
			}
			set
			{
				intLeft = value;
			}
		}

		public int Top
		{
			get
			{
				return intTop;
			}
			set
			{
				intTop = value;
			}
		}

		public int Width
		{
			get
			{
				return intWidth;
			}
			set
			{
				intWidth = value;
			}
		}

		public int Height
		{
			get
			{
				return intHeight;
			}
			set
			{
				intHeight = value;
			}
		}

		public int Right
		{
			get
			{
				return intLeft + intWidth;
			}
			set
			{
				intLeft = value - intWidth;
			}
		}

		public int Bottom
		{
			get
			{
				return intTop + intHeight;
			}
			set
			{
				intTop = value - intHeight;
			}
		}

		public Rectangle InnerRect
		{
			get
			{
				return new Rectangle(intLeft, intTop, intWidth, intHeight);
			}
			set
			{
				intLeft = value.Left;
				intTop = value.Top;
				intWidth = value.Width;
				intHeight = value.Height;
			}
		}

		public bool isEmpty()
		{
			return intLeft == 0 && intTop == 0 && intWidth == 0 && intHeight == 0;
		}

		public void MoveTo(int x, int y)
		{
			intLeft = x;
			intTop = y;
		}

		public void MoveTo2(int x, int y)
		{
			intLeft = x - intWidth;
			intTop = y - intHeight;
		}

		public void MoveStep(int dx, int dy)
		{
			intLeft += dx;
			intTop += dy;
		}

		public void ReSize(int vWidth, int vHeight)
		{
			intWidth = vWidth;
			intHeight = vHeight;
		}

		public void SetRect(int x1, int y1, int x2, int y2)
		{
			if (x1 < x2)
			{
				intLeft = x1;
				intWidth = x2 - x1;
			}
			else
			{
				intLeft = x2;
				intWidth = x1 - x2;
			}
			if (y1 < y2)
			{
				intTop = y1;
				intHeight = y2 - y1;
			}
			else
			{
				intTop = y2;
				intHeight = y1 - y2;
			}
		}

		public static Rectangle ConvertToRectangle(RectangleF rf)
		{
			return new Rectangle((int)rf.Left, (int)rf.Top, (int)rf.Width, (int)rf.Height);
		}

		public static int GetAcmeIndex(Rectangle vRect, Point p)
		{
			if (!vRect.IsEmpty)
			{
				if (p.Y == vRect.Y)
				{
					if (p.X == vRect.X)
					{
						return 0;
					}
					if (p.X == vRect.Right)
					{
						return 1;
					}
				}
				else if (p.Y == vRect.Bottom)
				{
					if (p.X == vRect.Right)
					{
						return 2;
					}
					if (p.X == vRect.X)
					{
						return 3;
					}
				}
			}
			return -1;
		}

		public static Point GetAcmePos(Rectangle vRect, int AcmeIndex)
		{
			switch (AcmeIndex)
			{
			case 0:
				return vRect.Location;
			case 1:
				return new Point(vRect.Right, vRect.Y);
			case 2:
				return new Point(vRect.Right, vRect.Bottom);
			case 3:
				return new Point(vRect.X, vRect.Bottom);
			default:
				return Point.Empty;
			}
		}

		public static Rectangle GetRectangle(int x1, int y1, int x2, int y2)
		{
			Rectangle empty = Rectangle.Empty;
			if (x1 < x2)
			{
				empty.X = x1;
				empty.Width = x2 - x1;
			}
			else
			{
				empty.X = x2;
				empty.Width = x1 - x2;
			}
			if (y1 < y2)
			{
				empty.Y = y1;
				empty.Height = y2 - y1;
			}
			else
			{
				empty.Y = y2;
				empty.Height = y1 - y2;
			}
			if (empty.Width < 1)
			{
				empty.Width = 1;
			}
			if (empty.Height < 1)
			{
				empty.Height = 1;
			}
			return empty;
		}

		public static Rectangle GetRectangle(Point p1, Point p2)
		{
			return GetRectangle(p1.X, p1.Y, p2.X, p2.Y);
		}

		public bool Contains(Rectangle vRect)
		{
			return new Rectangle(intLeft, intTop, intWidth, intHeight).Contains(vRect);
		}

		public bool Contains(int x, int y, int vWidth, int vHeight)
		{
			Rectangle rectangle = new Rectangle(intLeft, intTop, intWidth, intHeight);
			Rectangle rect = new Rectangle(x, y, vWidth, vHeight);
			return rectangle.Contains(rect);
		}

		public bool Contains(int x, int y)
		{
			return x > intLeft && x < intLeft + intWidth && y > intTop && y < intTop + intHeight;
		}

		public bool IntersectsWith(Rectangle vRect)
		{
			return new Rectangle(intLeft, intTop, intWidth, intHeight).IntersectsWith(vRect);
		}

		public bool IntersectsWith(int x, int y, int vWidth, int vHeight)
		{
			Rectangle rectangle = new Rectangle(intLeft, intTop, intWidth, intHeight);
			Rectangle rect = new Rectangle(x, y, vWidth, vHeight);
			return rectangle.IntersectsWith(rect);
		}

		public Rectangle Intersect(Rectangle vRect)
		{
			Rectangle result = new Rectangle(intLeft, intTop, intWidth, intHeight);
			result.Intersect(vRect);
			return result;
		}

		public Rectangle Union(Rectangle vRect)
		{
			Rectangle a = new Rectangle(intLeft, intTop, intWidth, intHeight);
			return Rectangle.Union(a, vRect);
		}

		public Rectangle Union(RectangleObject vRect)
		{
			if (vRect == null)
			{
				return Rectangle.Empty;
			}
			return Rectangle.Union(b: new Rectangle(intLeft, intTop, intWidth, intHeight), a: vRect.InnerRect);
		}

		public Point GetBorderPoint(int iPos, int iSplit)
		{
			Point empty = Point.Empty;
			if (iSplit <= 0)
			{
				return empty;
			}
			iPos %= iSplit * 4;
			if (iPos < 0)
			{
				iPos += iSplit * 4;
			}
			if (iPos >= 0 && iPos < iSplit)
			{
				empty.X = intLeft + intWidth * iPos / iSplit;
				empty.Y = intTop;
			}
			else if (iPos >= iSplit && iPos < iSplit * 2)
			{
				empty.X = intLeft + intWidth;
				empty.Y = intTop + intHeight * (iPos - iSplit) / iSplit;
			}
			else if (iPos >= iSplit * 2 && iPos < iSplit * 3)
			{
				empty.X = intLeft + intWidth * (iSplit * 3 - iPos) / iSplit;
				empty.Y = intTop + intHeight;
			}
			else
			{
				empty.X = intLeft;
				empty.Y = intTop + intHeight * (iSplit * 4 - iPos) / iSplit;
			}
			return empty;
		}
	}
}
