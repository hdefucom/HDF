using System;
using System.Drawing;
using XDesignerDrawer;

namespace XDesignerCommon
{
	public sealed class MathCommon
	{
		public static void RectangleClipLines(Rectangle ClipRectangle, Point[] LinesPoints)
		{
			if (ClipRectangle.IsEmpty)
			{
				throw new ArgumentException("ClipRectangle is Empty", "ClipRectangle");
			}
			if (LinesPoints == null)
			{
				throw new ArgumentNullException("LinesPoints");
			}
			if (LinesPoints.Length == 0)
			{
				throw new ArgumentException("LinesPoints is empty", "LinesPoints");
			}
			if (LinesPoints.Length % 2 != 0)
			{
				throw new ArgumentException("LinesPoints is error", "LinesPoints");
			}
			Point point = new Point(int.MinValue, int.MinValue);
			int left = ClipRectangle.Left;
			int top = ClipRectangle.Top;
			int right = ClipRectangle.Right;
			int bottom = ClipRectangle.Bottom;
			for (int i = 0; i < LinesPoints.Length; i += 2)
			{
				Point point2 = LinesPoints[i];
				Point point3 = LinesPoints[i + 1];
				bool flag = ClipRectangle.Contains(point2);
				if (point2.Equals(point3))
				{
					if (!flag)
					{
						LinesPoints[i] = point;
						LinesPoints[i + 1] = point;
					}
					continue;
				}
				bool flag2 = ClipRectangle.Contains(point3);
				if (flag && flag2)
				{
					continue;
				}
				if (point2.X == point3.X)
				{
					if (point2.X >= left && point2.X <= right)
					{
						LinesPoints[i].Y = FixToRange(point2.Y, top, bottom);
						LinesPoints[i + 1].Y = FixToRange(point3.Y, top, bottom);
					}
					else
					{
						LinesPoints[i] = point;
						LinesPoints[i + 1] = point;
					}
					continue;
				}
				if (point2.Y == point3.Y)
				{
					if (point2.Y >= top && point2.Y <= bottom)
					{
						LinesPoints[i].X = FixToRange(point2.X, left, right);
						LinesPoints[i + 1].X = FixToRange(point3.X, left, right);
					}
					else
					{
						LinesPoints[i] = point;
						LinesPoints[i + 1] = point;
					}
					continue;
				}
				double[] lineEquationParameter = GetLineEquationParameter(point2.X, point2.Y, point3.X, point3.Y);
				double num = lineEquationParameter[0];
				double num2 = lineEquationParameter[1];
				if (point2.X < left)
				{
					point2.X = left;
					point2.Y = (int)(num * (double)point2.X + num2);
				}
				else if (point2.X > right)
				{
					point2.X = right;
					point2.Y = (int)(num * (double)point2.X + num2);
				}
				if (point2.Y < top)
				{
					point2.Y = top;
					point2.X = (int)(((double)point2.Y - num2) / num);
				}
				else if (point2.Y > bottom)
				{
					point2.Y = bottom;
					point2.X = (int)(((double)point2.Y - num2) / num);
				}
				if (point3.X < left)
				{
					point3.X = left;
					point3.Y = (int)(num * (double)point3.X + num2);
				}
				else if (point3.X > right)
				{
					point3.X = right;
					point3.Y = (int)(num * (double)point3.X + num2);
				}
				if (point3.Y < top)
				{
					point3.Y = top;
					point3.X = (int)(((double)point3.Y - num2) / num);
				}
				else if (point3.Y > bottom)
				{
					point3.Y = bottom;
					point3.X = (int)(((double)point3.Y - num2) / num);
				}
				bool flag3 = false;
				if (point2.X >= left && point2.X <= right && point2.Y >= top && point2.Y <= bottom && point3.X >= left && point3.X <= right && point3.Y >= top && point3.Y <= bottom)
				{
					flag3 = true;
				}
				if (flag3)
				{
					LinesPoints[i] = point2;
					LinesPoints[i + 1] = point3;
				}
				else
				{
					LinesPoints[i] = point;
					LinesPoints[i + 1] = point;
				}
			}
		}

		public static int FixToRange(int vValue, int min, int max)
		{
			if (vValue < min)
			{
				return min;
			}
			if (vValue > max)
			{
				return max;
			}
			return vValue;
		}

		public static int[] IntersectRange(int a1, int b1, int a2, int b2)
		{
			int num = 0;
			if (a1 > b1)
			{
				num = a1;
				a1 = b1;
				b1 = num;
			}
			if (a2 > b2)
			{
				num = a2;
				a2 = b2;
				b2 = num;
			}
			int num2 = Math.Max(a1, a2);
			int num3 = Math.Min(b1, b2);
			if (num2 >= num3)
			{
				return new int[2]
				{
					num2,
					num3
				};
			}
			return null;
		}

		public static bool IntersectWithRange(int a1, int b1, int a2, int b2)
		{
			int num = 0;
			if (a1 > b1)
			{
				num = a1;
				a1 = b1;
				b1 = num;
			}
			if (a2 > b2)
			{
				num = a2;
				a2 = b2;
				b2 = num;
			}
			int num2 = Math.Max(a1, a2);
			int num3 = Math.Min(b1, b2);
			if (num2 >= num3)
			{
				return true;
			}
			return false;
		}

		public static int[] BubbleSort(int[] Values)
		{
			int num = Values.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = i;
			}
			int num2 = 0;
			int num3 = num;
			while (num3 > 0)
			{
				int num4 = num3 - 1;
				num3 = 0;
				for (int j = 0; j < num4; j++)
				{
					if (Values[array[j]] > Values[array[j + 1]])
					{
						num2 = array[j];
						array[j] = array[j + 1];
						array[j + 1] = num2;
						num3 = j;
					}
				}
			}
			return array;
		}

		public static int GetNearestPoint(Point o, Point[] ps, int Direction)
		{
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			int num3 = -1;
			for (int i = 0; i < ps.Length; i++)
			{
				Point point = ps[i];
				if (point.X == o.X && point.Y == o.Y)
				{
					continue;
				}
				double num4 = Angle(o.X, o.Y, point.X, point.Y);
				bool flag = false;
				int value = 0;
				int num5 = 0;
				num5 = (point.X - o.X) * (point.X - o.X) + (point.Y - o.Y) * (point.Y - o.Y);
				switch (Direction)
				{
				case 0:
					flag = (num4 <= 45.0 || num4 >= 315.0);
					value = point.X - o.X;
					break;
				case 1:
					flag = (num4 >= 45.0 && num4 <= 135.0);
					value = point.Y - o.Y;
					break;
				case 2:
					flag = (num4 >= 135.0 && num4 <= 225.0);
					value = point.X - o.X;
					break;
				case 3:
					flag = (num4 >= 225.0 && num4 <= 315.0);
					value = point.Y - o.Y;
					break;
				}
				if (flag)
				{
					value = Math.Abs(value);
					if (value <= num && (value < num || num5 < num2))
					{
						num = value;
						num2 = num5;
						num3 = i;
					}
				}
			}
			if (num3 == -1)
			{
				for (int i = 0; i < ps.Length; i++)
				{
					Point point = ps[i];
					if (point.X == o.X && point.Y == o.Y)
					{
						continue;
					}
					int value = -1;
					switch (Direction)
					{
					case 0:
						if (point.X > o.X)
						{
							value = point.X - o.X;
						}
						break;
					case 1:
						if (point.Y > o.Y)
						{
							value = point.Y - o.Y;
						}
						break;
					case 2:
						if (point.X < o.X)
						{
							value = o.X - point.X;
						}
						break;
					case 3:
						if (point.Y < o.Y)
						{
							value = o.Y - point.Y;
						}
						break;
					}
					if (value > 0 && value < num)
					{
						num = value;
						num3 = i;
					}
				}
			}
			return num3;
		}

		public static Point[] GetPiePoints(RectangleF bounds, double StartAngle, double EndAngle, int PointCount)
		{
			if (PointCount < 3)
			{
				return null;
			}
			Point[] array = new Point[PointCount];
			EllipseObject ellipseObject = new EllipseObject(bounds);
			double num = (EndAngle - StartAngle) / (double)(PointCount - 1);
			for (int i = 0; i < PointCount; i++)
			{
				double angle = StartAngle + num * (double)i;
				PointF pointF = ellipseObject.PeripheraPoint2(angle);
				array[i].X = (int)pointF.X;
				array[i].Y = (int)pointF.Y;
			}
			return array;
		}

		public static int Distance(int x1, int y1, int x2, int y2)
		{
			if (x1 == x2)
			{
				return Math.Abs(y1 - y2);
			}
			if (y1 == y2)
			{
				return Math.Abs(x1 - x2);
			}
			return (int)Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
		}

		public static int FixValue(int iValue, int iMax, int iMin)
		{
			if (iValue > iMax)
			{
				iValue = iMax;
			}
			if (iValue < iMin)
			{
				iValue = iMin;
			}
			return iValue;
		}

		public static int[] CalcuteAlignPosition(int[] Widths, int Spacing, int ContentWidth, StringAlignment Align, bool SplitBlank)
		{
			switch (Align)
			{
			case StringAlignment.Near:
				return CalcuteAlignPosition(Widths, Spacing, ContentWidth, 0, SplitBlank);
			case StringAlignment.Center:
				return CalcuteAlignPosition(Widths, Spacing, ContentWidth, 1, SplitBlank);
			case StringAlignment.Far:
				return CalcuteAlignPosition(Widths, Spacing, ContentWidth, 2, SplitBlank);
			default:
				return null;
			}
		}

		public static int[] CalcuteAlignPosition(int[] Widths, int Spacing, int ContentWidth, int Align, bool SplitBlank)
		{
			if (Widths.Length == 0)
			{
				return null;
			}
			int[] array = new int[Widths.Length];
			if (Widths.Length == 1)
			{
				switch (Align)
				{
				case 0:
					array[0] = 0;
					break;
				case 1:
					array[0] = (ContentWidth - Widths[0]) / 2;
					break;
				case 2:
					array[0] = ContentWidth - Widths[0];
					break;
				case 3:
					array[0] = (ContentWidth - Widths[0]) / 2;
					break;
				}
				return array;
			}
			int num = 0;
			for (int i = 0; i < Widths.Length; i++)
			{
				num = num + Widths[i] + Spacing;
			}
			num -= Spacing;
			int num2 = 0;
			switch (Align)
			{
			case 0:
				num2 = 0;
				break;
			case 1:
				num2 = ((!SplitBlank) ? ((ContentWidth - num) / 2) : 0);
				break;
			case 2:
				num2 = ((!SplitBlank) ? (ContentWidth - num) : 0);
				break;
			case 3:
				num2 = 0;
				SplitBlank = true;
				break;
			}
			for (int i = 0; i < Widths.Length; i++)
			{
				array[i] = num2;
				num2 = num2 + Widths[i] + Spacing;
			}
			if (SplitBlank)
			{
				int num3 = ContentWidth - num;
				if (num3 > 0)
				{
					int num4 = (int)Math.Ceiling((double)num3 / (double)(Widths.Length - 1));
					int num5 = 0;
					for (int i = 0; i < array.Length; i++)
					{
						array[i] += num5;
						num5 += num4;
						if (num5 > num3)
						{
							num5 = num3;
						}
					}
				}
			}
			return array;
		}

		public static Color Int32ToColor(int intColor)
		{
			return Color.FromArgb((intColor & 0xFF0000) >> 16, (intColor & 0xFF00) >> 8, intColor & 0xFF);
		}

		public static int ColorToInt32(Color Color)
		{
			return Color.ToArgb() & 0xFFFFFF;
		}

		public static double DistanceToLine(double x1, double y1, double x2, double y2, double x, double y, bool ShortLine)
		{
			if (x1 == x2 && y1 == y2)
			{
				return -1.0;
			}
			double num = Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
			double num2 = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
			double num3 = x1 + (x2 - x1) * num / (num + num2);
			double num4 = y1 + (y2 - y1) * num / (num + num2);
			if (ShortLine)
			{
				if (x1 != x2)
				{
					if ((num3 - x1) * (num3 - x2) >= 0.0)
					{
						return -1.0;
					}
				}
				else if ((num4 - y1) * (num4 - y2) >= 0.0)
				{
					return -1.0;
				}
			}
			return Math.Sqrt((x - num3) * (x - num3) + (y - num4) * (y - num4));
		}

		public static int CloseWithBorder(double vLeft, double vTop, double vWidth, double vHeight, double x, double y, double MaxDistance)
		{
			double num = vLeft + vWidth;
			double num2 = vTop + vHeight;
			if (x >= vLeft && x <= num)
			{
				if (Math.Abs(x - vLeft) <= MaxDistance)
				{
					return 3;
				}
				if (Math.Abs(x - num) <= MaxDistance)
				{
					return 1;
				}
			}
			if (y >= vTop && y <= num2)
			{
				if (Math.Abs(y - vTop) <= MaxDistance)
				{
					return 0;
				}
				if (Math.Abs(y - num2) <= MaxDistance)
				{
					return 2;
				}
			}
			return -1;
		}

		public static int SearchInt32Array(int[] intValues, int intMatch, bool SplitSearch)
		{
			if (intValues != null)
			{
				int num = 0;
				int num2 = intValues.Length - 1;
				if (intValues.Length < 10 || !SplitSearch)
				{
					for (int i = num; i <= num2; i++)
					{
						if (intMatch == intValues[i])
						{
							return i;
						}
					}
				}
				else
				{
					int num3 = 0;
					for (int num4 = num2 - num; num4 > 10; num4 = num2 - num)
					{
						num3 = num + num4 / 2;
						if (intValues[num3] == intMatch)
						{
							return num3;
						}
						if (intValues[num3] > intMatch)
						{
							num2 = num3;
						}
						else
						{
							num = num3;
						}
					}
					for (int i = num; i <= num2; i++)
					{
						if (intMatch == intValues[i])
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		public static double Angle(double x1, double y1, double x2, double y2)
		{
			if (x1 == x2)
			{
				if (y2 >= y1)
				{
					return 90.0;
				}
				return 270.0;
			}
			double num = Math.Atan((y2 - y1) / (x2 - x1));
			num = 180.0 * num / Math.PI;
			if (x2 >= x1)
			{
				if (y2 >= y1)
				{
					return num;
				}
				return num + 360.0;
			}
			return num + 180.0;
		}

		public static int SetIntAttribute(int intAttributes, int intValue, bool bolSet)
		{
			return bolSet ? (intAttributes | intValue) : (intAttributes & ~intValue);
		}

		public static bool GetIntAttribute(int intAttributes, int intValue)
		{
			return (intAttributes & intValue) == intValue;
		}

		public static bool RangeContains(int x1, int x2, int x)
		{
			if (x1 < x2)
			{
				return x >= x1 && x <= x2;
			}
			return x >= x2 && x <= x1;
		}

		public static bool RangeContains(double x1, double x2, double x)
		{
			if (x1 < x2)
			{
				return x >= x1 && x <= x2;
			}
			return x >= x2 && x <= x1;
		}

		public static Point RotatePoint(Point o, Point p, double angle)
		{
			if (o.X == p.X && o.Y == p.Y)
			{
				return p;
			}
			double d = (p.X - o.X) * (p.X - o.X) + (p.Y - o.Y) * (p.Y - o.Y);
			d = Math.Sqrt(d);
			double num = Math.Atan2(p.Y - o.Y, p.X - o.X);
			num -= angle;
			Point empty = Point.Empty;
			empty.X = (int)((double)o.X + d * Math.Cos(num));
			empty.Y = (int)((double)o.Y + d * Math.Sin(num));
			return empty;
		}

		public static PointF RotatePoint(PointF o, PointF p, double angle)
		{
			if (o.X == p.X && o.Y == p.Y)
			{
				return p;
			}
			double d = (p.X - o.X) * (p.X - o.X) + (p.Y - o.Y) * (p.Y - o.Y);
			d = Math.Sqrt(d);
			double num = Math.Atan2(p.Y - o.Y, p.X - o.X);
			num -= angle;
			PointF empty = PointF.Empty;
			empty.X = (float)((double)o.X + d * Math.Cos(num));
			empty.Y = (float)((double)o.Y + d * Math.Sin(num));
			return empty;
		}

		public static bool LineIntersectsWith(Rectangle rect, int x1, int y1, int x2, int y2)
		{
			if (rect.Contains(x1, y1))
			{
				return true;
			}
			if (rect.Contains(x2, y2))
			{
				return true;
			}
			if (LineIntersectsWith(x1, y1, x2, y2, rect.Left, rect.Top, rect.Right, rect.Top))
			{
				return true;
			}
			if (LineIntersectsWith(x1, y1, x2, y2, rect.Right, rect.Top, rect.Right, rect.Bottom))
			{
				return true;
			}
			if (LineIntersectsWith(x1, y1, x2, y2, rect.Right, rect.Bottom, rect.Left, rect.Bottom))
			{
				return true;
			}
			if (LineIntersectsWith(x1, y1, x2, y2, rect.Left, rect.Bottom, rect.Left, rect.Top))
			{
				return true;
			}
			return false;
		}

		public static bool LineIntersectsWith(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
		{
			Point point = LineIntersectPoint(x1, y1, x2, y2, x3, y3, x4, y4, Beeline: true);
			if (point.X == int.MinValue && point.Y == int.MinValue)
			{
				return false;
			}
			return true;
		}

		public static bool RangeIntersect(int a1, int b1, int a2, int b2)
		{
			if (a1 <= b2 && a2 <= b1)
			{
				return true;
			}
			return false;
		}

		public static double[] GetLineEquationParameter(double x1, double y1, double x2, double y2)
		{
			if (double.IsNaN(x1))
			{
				throw new ArgumentException("x1 is Nan");
			}
			if (double.IsNaN(y1))
			{
				throw new ArgumentException("y1 is Nan");
			}
			if (double.IsNaN(x2))
			{
				throw new ArgumentException("x2 is Nan");
			}
			if (double.IsNaN(y2))
			{
				throw new ArgumentException("y2 is Nan");
			}
			if (x1 != x2)
			{
				double num = (y2 - y1) / (x2 - x1);
				double num2 = y1 - num * x1;
				return new double[2]
				{
					num,
					num2
				};
			}
			return null;
		}

		public static Point LineIntersectPoint(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, bool Beeline)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			if (x1 != x2)
			{
				num3 = (double)(y2 - y1) / (double)(x2 - x1);
				num5 = (double)y1 - num3 * (double)x1;
			}
			if (x3 != x4)
			{
				num4 = (double)(y4 - y3) / (double)(x4 - x3);
				num6 = (double)y3 - num4 * (double)x3;
			}
			if (x1 == x2)
			{
				if (x3 == x4)
				{
					if (x1 == x3)
					{
						if (Beeline)
						{
							if (RangeIntersect(y1, y2, y3, y4))
							{
								return new Point(int.MaxValue, int.MaxValue);
							}
							return new Point(int.MinValue, int.MinValue);
						}
						return new Point(int.MaxValue, int.MaxValue);
					}
					return new Point(int.MinValue, int.MinValue);
				}
				num = x1;
				num2 = num4 * num + num6;
			}
			else if (x3 == x4)
			{
				num = x3;
				num2 = num3 * num + num5;
			}
			else
			{
				if (num3 == num4)
				{
					if (num5 == num6)
					{
						if (Beeline)
						{
							if (RangeIntersect(x1, x2, x3, x4))
							{
								return new Point(int.MaxValue, int.MaxValue);
							}
							return new Point(int.MinValue, int.MinValue);
						}
						return new Point(int.MaxValue, int.MaxValue);
					}
					return new Point(int.MinValue, int.MinValue);
				}
				num = (num6 - num5) / (num3 - num4);
				num2 = num3 * num + num5;
			}
			if (Beeline)
			{
				if (RangeContains(x1, x2, num) && RangeContains(x3, x4, num) && RangeContains(y1, y2, num2) && RangeContains(y3, y4, num2))
				{
					return new Point((int)num, (int)num2);
				}
				return new Point(int.MinValue, int.MinValue);
			}
			return new Point((int)num, (int)num2);
		}

		private MathCommon()
		{
		}
	}
}
