using System;
using System.Drawing;

namespace XDesignerCommon
{
	public sealed class RectangleCommon
	{
		public static Rectangle GetMiddleRectangle(Rectangle rect1, Rectangle rect2, double rate)
		{
			int x = rect1.Left + (int)((double)(rect2.Left - rect1.Left) * rate);
			int y = rect1.Top + (int)((double)(rect2.Top - rect1.Top) * rate);
			int width = rect1.Width + (int)((double)(rect2.Width - rect1.Width) * rate);
			int height = rect1.Height + (int)((double)(rect2.Height - rect1.Height) * rate);
			return new Rectangle(x, y, width, height);
		}

		public static Rectangle ReSize(Rectangle rect, int dsize)
		{
			return new Rectangle(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
		}

		public static Size InnerRoteteRectangleSize(int Width, int Height, double angle)
		{
			if (Width <= 0 || Height <= 0)
			{
				return Size.Empty;
			}
			double num = Math.Atan2(Height, Width);
			double num2 = Math.Sqrt(Width * Width + Height * Height) / 2.0;
			double num3 = num2 * Math.Cos(num - angle);
			double num4 = num2 * Math.Sin(num + angle);
			double num5 = num3 * 2.0 / (double)Width;
			if (num5 < num4 * 2.0 / (double)Height)
			{
				num5 = num4 * 2.0 / (double)Height;
			}
			return new Size((int)((double)Width / num5), (int)((double)Height / num5));
		}

		public static Rectangle RotateRectangle(Point o, Rectangle rect, double angle)
		{
			Point[] array = To4Points(rect);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MathCommon.RotatePoint(o, array[i], angle);
			}
			return PointBuffer.GetBounds(array);
		}

		public static Rectangle AlignRect(Rectangle MainRect, int width, int height, int Align, int VAlign)
		{
			Rectangle result = new Rectangle(0, 0, width, height);
			switch (Align)
			{
			case 1:
				result.X = MainRect.Left;
				break;
			case 2:
				result.X = MainRect.Left + (MainRect.Width - width) / 2;
				break;
			case 3:
				result.X = MainRect.Right - width;
				break;
			}
			switch (VAlign)
			{
			case 1:
				result.Y = MainRect.Top;
				break;
			case 2:
				result.Y = MainRect.Top + (MainRect.Height - height) / 2;
				break;
			case 3:
				result.Y = MainRect.Bottom - height;
				break;
			}
			return result;
		}

		public static RectangleF ToRectangleF(Rectangle rect)
		{
			return new RectangleF(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public static Rectangle ToRectangle(RectangleF rect)
		{
			return new Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height);
		}

		public static bool PaintInvalidSize(int width, int height)
		{
			if (width > 0 && height >= 0)
			{
				return true;
			}
			if (height > 0 && width >= 0)
			{
				return true;
			}
			return false;
		}

		public static Rectangle GetInnerRectangle(Rectangle rect, StringAlignment Align, StringAlignment LineAlign, Size InnerRectSize)
		{
			int num = 0;
			int num2 = 0;
			switch (Align)
			{
			case StringAlignment.Near:
				num = rect.Left;
				break;
			case StringAlignment.Center:
				num = rect.Left + (rect.Width - InnerRectSize.Width) / 2;
				break;
			default:
				num = rect.Right - InnerRectSize.Width;
				break;
			}
			switch (LineAlign)
			{
			case StringAlignment.Near:
				num2 = rect.Top;
				break;
			case StringAlignment.Center:
				num2 = rect.Top + (rect.Height - InnerRectSize.Height) / 2;
				break;
			default:
				num2 = rect.Bottom - InnerRectSize.Height;
				break;
			}
			return new Rectangle(num, num2, InnerRectSize.Width, InnerRectSize.Height);
		}

		public static Point[] To3Points(Rectangle rect)
		{
			return new Point[3]
			{
				new Point(rect.X, rect.Y),
				new Point(rect.Right, rect.Y),
				new Point(rect.Right, rect.Bottom)
			};
		}

		public static Point[] To4Points(Rectangle rect)
		{
			return new Point[4]
			{
				new Point(rect.X, rect.Y),
				new Point(rect.Right, rect.Y),
				new Point(rect.Right, rect.Bottom),
				new Point(rect.Left, rect.Bottom)
			};
		}

		public static Point[] To5Points(Rectangle rect)
		{
			Point[] array = new Point[5];
			array[0] = new Point(rect.X, rect.Y);
			array[1] = new Point(rect.Right, rect.Y);
			array[2] = new Point(rect.Right, rect.Bottom);
			array[3] = new Point(rect.Left, rect.Bottom);
			array[4] = array[0];
			return array;
		}

		public static Rectangle GetSquare(Rectangle rect)
		{
			if (rect.Width == rect.Height)
			{
				return rect;
			}
			if (rect.Width > rect.Height)
			{
				return new Rectangle(rect.Left + (rect.Width - rect.Height) / 2, rect.Top, rect.Height, rect.Height);
			}
			return new Rectangle(rect.Left, rect.Top + (rect.Height - rect.Width) / 2, rect.Width, rect.Width);
		}

		public static Point Center(Rectangle rect)
		{
			return new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
		}

		public static Rectangle Center(Rectangle rect, Size size)
		{
			return new Rectangle(rect.Left + (rect.Width - size.Width) / 2, rect.Top + (rect.Height - size.Height) / 2, size.Width, size.Height);
		}

		public static RectangleF Center(RectangleF rect, SizeF size)
		{
			return new RectangleF(rect.Left + (rect.Width - size.Width) / 2f, rect.Top + (rect.Height - size.Height) / 2f, size.Width, size.Height);
		}

		public static Rectangle SetCenter(Rectangle rect, int x, int y)
		{
			return new Rectangle(x - rect.Width / 2, y - rect.Height / 2, rect.Width, rect.Height);
		}

		public RectangleF SetCenter(RectangleF rect, float x, float y)
		{
			return new RectangleF((float)((double)x - (double)rect.Width / 2.0), (float)((double)y - (double)rect.Height / 2.0), rect.Width, rect.Height);
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

		public static int MoveXInto(int x, Rectangle Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return x;
			}
			if (x < Bounds.Left)
			{
				x = Bounds.Left;
			}
			else if (x > Bounds.Right)
			{
				x = Bounds.Right;
			}
			return x;
		}

		public static int MoveYInto(int y, Rectangle Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return y;
			}
			if (y < Bounds.Top)
			{
				y = Bounds.Top;
			}
			else if (y > Bounds.Bottom)
			{
				y = Bounds.Bottom;
			}
			return y;
		}

		public static Rectangle MoveInto(Rectangle rect, Rectangle Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return rect;
			}
			if (rect.Right > Bounds.Right)
			{
				rect.X = Bounds.Right - rect.Width;
			}
			if (rect.Bottom > Bounds.Bottom)
			{
				rect.Y = Bounds.Bottom - rect.Height;
			}
			if (rect.X < Bounds.Left)
			{
				rect.X = Bounds.Left;
			}
			if (rect.Y < Bounds.Top)
			{
				rect.Y = Bounds.Top;
			}
			return rect;
		}

		public static Point MoveInto(Point p, Rectangle Bounds)
		{
			if (!Bounds.IsEmpty)
			{
				if (p.X < Bounds.Left)
				{
					p.X = Bounds.Left;
				}
				if (p.X >= Bounds.Right)
				{
					p.X = Bounds.Right;
				}
				if (p.Y < Bounds.Top)
				{
					p.Y = Bounds.Top;
				}
				if (p.Y >= Bounds.Bottom)
				{
					p.Y = Bounds.Bottom;
				}
			}
			return p;
		}

		public static Point GetBorderPoint(int intLeft, int intTop, int intWidth, int intHeight, int iPos, int iSplit)
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

		public static RectangleF ReSize(RectangleF rect, float dsize)
		{
			return new RectangleF(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
		}

		public static SizeF InnerRoteteRectangleSize(float Width, float Height, double angle)
		{
			if (Width <= 0f || Height <= 0f)
			{
				return SizeF.Empty;
			}
			double num = Math.Atan2(Height, Width);
			double num2 = Math.Sqrt(Width * Width + Height * Height) / 2.0;
			double num3 = num2 * Math.Cos(num - angle);
			double num4 = num2 * Math.Sin(num + angle);
			double num5 = num3 * 2.0 / (double)Width;
			if (num5 < num4 * 2.0 / (double)Height)
			{
				num5 = num4 * 2.0 / (double)Height;
			}
			return new SizeF((float)((double)Width / num5), (float)((double)Height / num5));
		}

		public static RectangleF RotateRectangle(PointF o, RectangleF rect, double angle)
		{
			PointF[] array = To4Points(rect);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MathCommon.RotatePoint(o, array[i], angle);
			}
			return PointBuffer.GetBounds(array);
		}

		public static RectangleF AlignRect(RectangleF MainRect, float width, float height, int Align, int VAlign)
		{
			RectangleF result = new RectangleF(0f, 0f, width, height);
			switch (Align)
			{
			case 1:
				result.X = MainRect.Left;
				break;
			case 2:
				result.X = MainRect.Left + (MainRect.Width - width) / 2f;
				break;
			case 3:
				result.X = MainRect.Right - width;
				break;
			}
			switch (VAlign)
			{
			case 1:
				result.Y = MainRect.Top;
				break;
			case 2:
				result.Y = MainRect.Top + (MainRect.Height - height) / 2f;
				break;
			case 3:
				result.Y = MainRect.Bottom - height;
				break;
			}
			return result;
		}

		public static bool PaintInvalidSize(float width, float height)
		{
			if (width > 0f && height >= 0f)
			{
				return true;
			}
			if (height > 0f && width >= 0f)
			{
				return true;
			}
			return false;
		}

		public static RectangleF GetInnerRectangle(RectangleF rect, StringAlignment Align, StringAlignment LineAlign, SizeF InnerRectSize)
		{
			float num = 0f;
			float num2 = 0f;
			switch (Align)
			{
			case StringAlignment.Near:
				num = rect.Left;
				break;
			case StringAlignment.Center:
				num = rect.Left + (rect.Width - InnerRectSize.Width) / 2f;
				break;
			default:
				num = rect.Right - InnerRectSize.Width;
				break;
			}
			switch (LineAlign)
			{
			case StringAlignment.Near:
				num2 = rect.Top;
				break;
			case StringAlignment.Center:
				num2 = rect.Top + (rect.Height - InnerRectSize.Height) / 2f;
				break;
			default:
				num2 = rect.Bottom - InnerRectSize.Height;
				break;
			}
			return new RectangleF(num, num2, InnerRectSize.Width, InnerRectSize.Height);
		}

		public static PointF[] To3Points(RectangleF rect)
		{
			return new PointF[3]
			{
				new PointF(rect.X, rect.Y),
				new PointF(rect.Right, rect.Y),
				new PointF(rect.Right, rect.Bottom)
			};
		}

		public static PointF[] To4Points(RectangleF rect)
		{
			return new PointF[4]
			{
				new PointF(rect.X, rect.Y),
				new PointF(rect.Right, rect.Y),
				new PointF(rect.Right, rect.Bottom),
				new PointF(rect.Left, rect.Bottom)
			};
		}

		public static PointF[] To5Points(RectangleF rect)
		{
			PointF[] array = new PointF[5];
			array[0] = new PointF(rect.X, rect.Y);
			array[1] = new PointF(rect.Right, rect.Y);
			array[2] = new PointF(rect.Right, rect.Bottom);
			array[3] = new PointF(rect.Left, rect.Bottom);
			array[4] = array[0];
			return array;
		}

		public static RectangleF GetSquare(RectangleF rect)
		{
			if (rect.Width == rect.Height)
			{
				return rect;
			}
			if (rect.Width > rect.Height)
			{
				return new RectangleF(rect.Left + (rect.Width - rect.Height) / 2f, rect.Top, rect.Height, rect.Height);
			}
			return new RectangleF(rect.Left, rect.Top + (rect.Height - rect.Width) / 2f, rect.Width, rect.Width);
		}

		public static PointF Center(RectangleF rect)
		{
			return new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
		}

		public static int GetAcmeIndexF(RectangleF vRect, PointF p)
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

		public static PointF GetAcmePos(RectangleF vRect, int AcmeIndex)
		{
			switch (AcmeIndex)
			{
			case 0:
				return vRect.Location;
			case 1:
				return new PointF(vRect.Right, vRect.Y);
			case 2:
				return new PointF(vRect.Right, vRect.Bottom);
			case 3:
				return new PointF(vRect.X, vRect.Bottom);
			default:
				return PointF.Empty;
			}
		}

		public static RectangleF GetRectangle(float x1, float y1, float x2, float y2)
		{
			RectangleF empty = RectangleF.Empty;
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
			if (empty.Width < 1f)
			{
				empty.Width = 1f;
			}
			if (empty.Height < 1f)
			{
				empty.Height = 1f;
			}
			return empty;
		}

		public static RectangleF GetRectangle(PointF p1, PointF p2)
		{
			return GetRectangle(p1.X, p1.Y, p2.X, p2.Y);
		}

		public static float MoveXInto(float x, RectangleF Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return x;
			}
			if (x < Bounds.Left)
			{
				x = Bounds.Left;
			}
			else if (x > Bounds.Right)
			{
				x = Bounds.Right;
			}
			return x;
		}

		public static float MoveYInto(float y, RectangleF Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return y;
			}
			if (y < Bounds.Top)
			{
				y = Bounds.Top;
			}
			else if (y > Bounds.Bottom)
			{
				y = Bounds.Bottom;
			}
			return y;
		}

		public static RectangleF MoveInto(RectangleF rect, RectangleF Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return rect;
			}
			if (rect.Right > Bounds.Right)
			{
				rect.X = Bounds.Right - rect.Width;
			}
			if (rect.Bottom > Bounds.Bottom)
			{
				rect.Y = Bounds.Bottom - rect.Height;
			}
			if (rect.X < Bounds.Left)
			{
				rect.X = Bounds.Left;
			}
			if (rect.Y < Bounds.Top)
			{
				rect.Y = Bounds.Top;
			}
			return rect;
		}

		public static PointF MoveInto(PointF p, RectangleF Bounds)
		{
			if (!Bounds.IsEmpty)
			{
				if (p.X < Bounds.Left)
				{
					p.X = Bounds.Left;
				}
				if (p.X >= Bounds.Right)
				{
					p.X = Bounds.Right;
				}
				if (p.Y < Bounds.Top)
				{
					p.Y = Bounds.Top;
				}
				if (p.Y >= Bounds.Bottom)
				{
					p.Y = Bounds.Bottom;
				}
			}
			return p;
		}

		public static PointF GetBorderPoint(float intLeft, float intTop, float intWidth, float intHeight, int iPos, int iSplit)
		{
			PointF empty = PointF.Empty;
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
				empty.X = intLeft + intWidth * (float)iPos / (float)iSplit;
				empty.Y = intTop;
			}
			else if (iPos >= iSplit && iPos < iSplit * 2)
			{
				empty.X = intLeft + intWidth;
				empty.Y = intTop + intHeight * (float)(iPos - iSplit) / (float)iSplit;
			}
			else if (iPos >= iSplit * 2 && iPos < iSplit * 3)
			{
				empty.X = intLeft + intWidth * (float)(iSplit * 3 - iPos) / (float)iSplit;
				empty.Y = intTop + intHeight;
			}
			else
			{
				empty.X = intLeft;
				empty.Y = intTop + intHeight * (float)(iSplit * 4 - iPos) / (float)iSplit;
			}
			return empty;
		}

		private RectangleCommon()
		{
		}
	}
}
