using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class MathCommon
	{
		public static void smethod_0(Matrix matrix_0, PointF[] pointF_0)
		{
			if (matrix_0 == null || pointF_0 == null)
			{
				return;
			}
			float[] elements = matrix_0.Elements;
			if (elements[0] != 1f || elements[1] != 0f || elements[2] != 0f || elements[3] != 1f || elements[4] != 0f || elements[5] != 0f)
			{
				for (int i = 0; i < pointF_0.Length; i++)
				{
					float x = pointF_0[i].X;
					float y = pointF_0[i].Y;
					x -= elements[4];
					y -= elements[5];
					x /= elements[0];
					y /= elements[0];
					pointF_0[i].X = x;
					pointF_0[i].Y = y;
				}
			}
		}

		public static double smethod_1(double double_0, double double_1)
		{
			if (double_1 == 0.0)
			{
				return double_0;
			}
			int num = (int)(double_0 / double_1);
			return (double)num * double_1;
		}

		public static float smethod_2(float float_0, float float_1)
		{
			if (float_1 == 0f)
			{
				return float_0;
			}
			int num = (int)(float_0 / float_1);
			return (float)num * float_1;
		}

		public static int[] smethod_3(int int_0)
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= int_0; i++)
			{
				if (int_0 % i == 0)
				{
					list.Add(i);
				}
			}
			return list.ToArray();
		}

		public static SizeF smethod_4(SizeF sizeF_0, SizeF sizeF_1, bool bool_0)
		{
			if (sizeF_1.Width <= 0f || sizeF_1.Height <= 0f)
			{
				if (sizeF_1.Width <= 0f)
				{
					sizeF_1.Width = Math.Min(sizeF_0.Width, sizeF_1.Width);
				}
				if (sizeF_1.Height <= 0f)
				{
					sizeF_1.Height = Math.Min(sizeF_0.Height, sizeF_1.Height);
				}
				return sizeF_1;
			}
			if (sizeF_1.Width > sizeF_0.Width || sizeF_1.Height > sizeF_0.Height)
			{
				if (bool_0)
				{
					double num = Math.Min(sizeF_0.Width / sizeF_1.Width, sizeF_0.Height / sizeF_1.Height);
					return new SizeF((float)((double)sizeF_1.Width * num), (float)((double)sizeF_1.Height * num));
				}
				return new SizeF(Math.Min(sizeF_1.Width, sizeF_0.Width), Math.Min(sizeF_1.Height, sizeF_0.Height));
			}
			return sizeF_1;
		}

		public static ArrayList smethod_5(bool[] bool_0, PointF[] pointF_0)
		{
			int num = 9;
			if (bool_0 == null || bool_0.Length <= 1)
			{
				throw new ArgumentNullException("Links");
			}
			if (pointF_0 == null || pointF_0.Length <= 1)
			{
				throw new ArgumentNullException("points");
			}
			if (bool_0.Length != pointF_0.Length)
			{
				throw new ArgumentException("Array length error.");
			}
			ArrayList arrayList = new ArrayList();
			int num2 = bool_0.Length;
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Add(pointF_0[0]);
			bool flag = true;
			for (int i = 0; i < num2; i++)
			{
				bool flag2 = bool_0[i];
				if (flag != flag2)
				{
					if (arrayList2.Count > 1)
					{
						arrayList.Add(arrayList2);
						arrayList2 = new ArrayList();
					}
					else
					{
						arrayList2.Clear();
					}
					arrayList2.Add(pointF_0[i]);
				}
				if (flag2)
				{
					arrayList2.Add(pointF_0[(i + 1) % num2]);
				}
				flag = flag2;
			}
			if (arrayList2.Count > 1)
			{
				arrayList.Add(arrayList2);
			}
			for (int i = 0; i < arrayList.Count; i++)
			{
				arrayList2 = (ArrayList)arrayList[i];
				arrayList[i] = (PointF[])arrayList2.ToArray(typeof(PointF));
			}
			return arrayList;
		}

		public static Point[] smethod_6(int int_0, int int_1, int int_2, int int_3, int int_4)
		{
			int num = 0;
			int num2 = 0;
			if (int_0 == int_2)
			{
				num = int_4;
			}
			else if (int_1 == int_3)
			{
				num2 = int_4;
			}
			else
			{
				double d = (double)(int_3 - int_1) / (double)(int_2 - int_0);
				double num3 = Math.Atan(d);
				num3 += Math.PI / 2.0;
				num2 = (int)(Math.Sin(num3) * (double)int_4);
				num = (int)(Math.Cos(num3) * (double)int_4);
			}
			return new Point[4]
			{
				new Point(int_0 - num, int_1 - num2),
				new Point(int_0 + num, int_1 + num2),
				new Point(int_2 + num, int_3 + num2),
				new Point(int_2 - num, int_3 - num2)
			};
		}

		public static Point[] smethod_7(Rectangle rectangle_0, Rectangle rectangle_1)
		{
			Point point = new Point(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			Point point2 = new Point(rectangle_1.Left + rectangle_1.Width / 2, rectangle_1.Top + rectangle_1.Height / 2);
			Point[] array = new Point[4]
			{
				new Point(point.X, rectangle_0.Top),
				new Point(rectangle_0.Right, point.Y),
				new Point(point.X, rectangle_0.Bottom),
				new Point(rectangle_0.X, point.Y)
			};
			Point[] array2 = new Point[4]
			{
				new Point(point2.X, rectangle_1.Top),
				new Point(rectangle_1.Right, point2.Y),
				new Point(point2.X, rectangle_1.Bottom),
				new Point(rectangle_1.X, point2.Y)
			};
			int num = -1;
			Point point3 = Point.Empty;
			Point point4 = Point.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				Point point5 = array[i];
				for (int j = 0; j < array2.Length; j++)
				{
					Point point6 = array2[j];
					int num2 = (point5.X - point6.X) * (point5.X - point6.X) + (point5.Y - point6.Y) * (point5.Y - point6.Y);
					if (num == -1 || num > num2)
					{
						num = num2;
						point3 = point5;
						point4 = point6;
					}
				}
			}
			return new Point[2]
			{
				point3,
				point4
			};
		}

		public static double smethod_8(double double_0, double double_1, double double_2)
		{
			if (double.IsNaN(double_0) || double.IsNaN(double_1) || double.IsNaN(double_2))
			{
				return 0.0;
			}
			if (double_0 <= double_1)
			{
				return 0.0;
			}
			if (double_2 <= double_1)
			{
				return 0.0;
			}
			if (double_2 >= double_0)
			{
				return 1.0;
			}
			return (double_2 - double_1) / (double_0 - double_1);
		}

		public static void RectangleClipLines(Rectangle rectangle_0, Point[] point_0)
		{
			int num = 13;
			if (rectangle_0.IsEmpty)
			{
				throw new ArgumentException("ClipRectangle is Empty", "ClipRectangle");
			}
			if (point_0 == null)
			{
				throw new ArgumentNullException("LinesPoints");
			}
			if (point_0.Length == 0)
			{
				throw new ArgumentException("LinesPoints is empty", "LinesPoints");
			}
			if (point_0.Length % 2 != 0)
			{
				throw new ArgumentException("LinesPoints is error", "LinesPoints");
			}
			Point point = new Point(int.MinValue, int.MinValue);
			int left = rectangle_0.Left;
			int top = rectangle_0.Top;
			int right = rectangle_0.Right;
			int bottom = rectangle_0.Bottom;
			for (int i = 0; i < point_0.Length; i += 2)
			{
				Point point2 = point_0[i];
				Point point3 = point_0[i + 1];
				bool flag = rectangle_0.Contains(point2);
				if (point2.Equals(point3))
				{
					if (!flag)
					{
						point_0[i] = point;
						point_0[i + 1] = point;
					}
					continue;
				}
				bool flag2 = rectangle_0.Contains(point3);
				if (flag && flag2)
				{
					continue;
				}
				if (point2.X == point3.X)
				{
					if (point2.X >= left && point2.X <= right)
					{
						point_0[i].Y = FixToRange(point2.Y, top, bottom);
						point_0[i + 1].Y = FixToRange(point3.Y, top, bottom);
					}
					else
					{
						point_0[i] = point;
						point_0[i + 1] = point;
					}
					continue;
				}
				if (point2.Y == point3.Y)
				{
					if (point2.Y >= top && point2.Y <= bottom)
					{
						point_0[i].X = FixToRange(point2.X, left, right);
						point_0[i + 1].X = FixToRange(point3.X, left, right);
					}
					else
					{
						point_0[i] = point;
						point_0[i + 1] = point;
					}
					continue;
				}
				double[] array = GetLineEquationParameter(point2.X, point2.Y, point3.X, point3.Y);
				double num2 = array[0];
				double num3 = array[1];
				if (point2.X < left)
				{
					point2.X = left;
					point2.Y = (int)(num2 * (double)point2.X + num3);
				}
				else if (point2.X > right)
				{
					point2.X = right;
					point2.Y = (int)(num2 * (double)point2.X + num3);
				}
				if (point2.Y < top)
				{
					point2.Y = top;
					point2.X = (int)(((double)point2.Y - num3) / num2);
				}
				else if (point2.Y > bottom)
				{
					point2.Y = bottom;
					point2.X = (int)(((double)point2.Y - num3) / num2);
				}
				if (point3.X < left)
				{
					point3.X = left;
					point3.Y = (int)(num2 * (double)point3.X + num3);
				}
				else if (point3.X > right)
				{
					point3.X = right;
					point3.Y = (int)(num2 * (double)point3.X + num3);
				}
				if (point3.Y < top)
				{
					point3.Y = top;
					point3.X = (int)(((double)point3.Y - num3) / num2);
				}
				else if (point3.Y > bottom)
				{
					point3.Y = bottom;
					point3.X = (int)(((double)point3.Y - num3) / num2);
				}
				bool flag3 = false;
				if (point2.X >= left && point2.X <= right && point2.Y >= top && point2.Y <= bottom && point3.X >= left && point3.X <= right && point3.Y >= top && point3.Y <= bottom)
				{
					flag3 = true;
				}
				if (flag3)
				{
					point_0[i] = point2;
					point_0[i + 1] = point3;
				}
				else
				{
					point_0[i] = point;
					point_0[i + 1] = point;
				}
			}
		}

		public static int FixToRange(int int_0, int int_1, int int_2)
		{
			if (int_0 < int_1)
			{
				return int_1;
			}
			if (int_0 > int_2)
			{
				return int_2;
			}
			return int_0;
		}

		public static int[] smethod_11(int int_0, int int_1, int int_2, int int_3)
		{
			int num = 0;
			if (int_0 > int_1)
			{
				num = int_0;
				int_0 = int_1;
				int_1 = num;
			}
			if (int_2 > int_3)
			{
				num = int_2;
				int_2 = int_3;
				int_3 = num;
			}
			int num2 = Math.Max(int_0, int_2);
			int num3 = Math.Min(int_1, int_3);
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

		public static bool smethod_12(int int_0, int int_1, int int_2, int int_3)
		{
			int num = 0;
			if (int_0 > int_1)
			{
				num = int_0;
				int_0 = int_1;
				int_1 = num;
			}
			if (int_2 > int_3)
			{
				num = int_2;
				int_2 = int_3;
				int_3 = num;
			}
			int num2 = Math.Max(int_0, int_2);
			int num3 = Math.Min(int_1, int_3);
			if (num2 >= num3)
			{
				return true;
			}
			return false;
		}

		public static int smethod_13(Point point_0, Point[] point_1, int int_0)
		{
			int num = int.MaxValue;
			int num2 = int.MaxValue;
			int num3 = -1;
			for (int i = 0; i < point_1.Length; i++)
			{
				Point point = point_1[i];
				if (point.X == point_0.X && point.Y == point_0.Y)
				{
					continue;
				}
				double num4 = smethod_23(point_0.X, point_0.Y, point.X, point.Y);
				bool flag = false;
				int value = 0;
				int num5 = 0;
				num5 = (point.X - point_0.X) * (point.X - point_0.X) + (point.Y - point_0.Y) * (point.Y - point_0.Y);
				switch (int_0)
				{
				case 0:
					flag = (num4 <= 45.0 || num4 >= 315.0);
					value = point.X - point_0.X;
					break;
				case 1:
					flag = (num4 >= 45.0 && num4 <= 135.0);
					value = point.Y - point_0.Y;
					break;
				case 2:
					flag = (num4 >= 135.0 && num4 <= 225.0);
					value = point.X - point_0.X;
					break;
				case 3:
					flag = (num4 >= 225.0 && num4 <= 315.0);
					value = point.Y - point_0.Y;
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
				for (int i = 0; i < point_1.Length; i++)
				{
					Point point = point_1[i];
					if (point.X == point_0.X && point.Y == point_0.Y)
					{
						continue;
					}
					int value = -1;
					switch (int_0)
					{
					case 0:
						if (point.X > point_0.X)
						{
							value = point.X - point_0.X;
						}
						break;
					case 1:
						if (point.Y > point_0.Y)
						{
							value = point.Y - point_0.Y;
						}
						break;
					case 2:
						if (point.X < point_0.X)
						{
							value = point_0.X - point.X;
						}
						break;
					case 3:
						if (point.Y < point_0.Y)
						{
							value = point_0.Y - point.Y;
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

		public static int smethod_14(int int_0, int int_1, int int_2, int int_3)
		{
			if (int_0 == int_2)
			{
				return Math.Abs(int_1 - int_3);
			}
			if (int_1 == int_3)
			{
				return Math.Abs(int_0 - int_2);
			}
			return (int)Math.Sqrt((int_0 - int_2) * (int_0 - int_2) + (int_1 - int_3) * (int_1 - int_3));
		}

		public static int smethod_15(int int_0, int int_1, int int_2)
		{
			if (int_0 > int_1)
			{
				int_0 = int_1;
			}
			if (int_0 < int_2)
			{
				int_0 = int_2;
			}
			return int_0;
		}

		public static int[] smethod_16(int[] int_0, int int_1, int int_2, StringAlignment stringAlignment_0, bool bool_0)
		{
			switch (stringAlignment_0)
			{
			case StringAlignment.Near:
				return smethod_17(int_0, int_1, int_2, 0, bool_0);
			case StringAlignment.Center:
				return smethod_17(int_0, int_1, int_2, 1, bool_0);
			case StringAlignment.Far:
				return smethod_17(int_0, int_1, int_2, 2, bool_0);
			default:
				return null;
			}
		}

		public static int[] smethod_17(int[] int_0, int int_1, int int_2, int int_3, bool bool_0)
		{
			if (int_0.Length == 0)
			{
				return null;
			}
			int[] array = new int[int_0.Length];
			if (int_0.Length == 1)
			{
				switch (int_3)
				{
				case 0:
					array[0] = 0;
					break;
				case 1:
					array[0] = (int_2 - int_0[0]) / 2;
					break;
				case 2:
					array[0] = int_2 - int_0[0];
					break;
				case 3:
					array[0] = (int_2 - int_0[0]) / 2;
					break;
				}
				return array;
			}
			int num = 0;
			for (int i = 0; i < int_0.Length; i++)
			{
				num = num + int_0[i] + int_1;
			}
			num -= int_1;
			int num2 = 0;
			switch (int_3)
			{
			case 0:
				num2 = 0;
				break;
			case 1:
				num2 = ((!bool_0) ? ((int_2 - num) / 2) : 0);
				break;
			case 2:
				num2 = ((!bool_0) ? (int_2 - num) : 0);
				break;
			case 3:
				num2 = 0;
				bool_0 = true;
				break;
			}
			for (int i = 0; i < int_0.Length; i++)
			{
				array[i] = num2;
				num2 = num2 + int_0[i] + int_1;
			}
			if (bool_0)
			{
				int num3 = int_2 - num;
				if (num3 > 0)
				{
					int num4 = (int)Math.Ceiling((double)num3 / (double)(int_0.Length - 1));
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

		public static Color smethod_18(int int_0)
		{
			return Color.FromArgb((int_0 & 0xFF0000) >> 16, (int_0 & 0xFF00) >> 8, int_0 & 0xFF);
		}

		public static int smethod_19(Color color_0)
		{
			return color_0.ToArgb() & 0xFFFFFF;
		}

		public static double smethod_20(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, bool bool_0)
		{
			if (double_0 == double_2 && double_1 == double_3)
			{
				return -1.0;
			}
			double num = Math.Sqrt((double_4 - double_0) * (double_4 - double_0) + (double_5 - double_1) * (double_5 - double_1));
			double num2 = Math.Sqrt((double_4 - double_2) * (double_4 - double_2) + (double_5 - double_3) * (double_5 - double_3));
			double num3 = double_0 + (double_2 - double_0) * num / (num + num2);
			double num4 = double_1 + (double_3 - double_1) * num / (num + num2);
			if (bool_0)
			{
				if (double_0 != double_2)
				{
					if ((num3 - double_0) * (num3 - double_2) >= 0.0)
					{
						return -1.0;
					}
				}
				else if ((num4 - double_1) * (num4 - double_3) >= 0.0)
				{
					return -1.0;
				}
			}
			return Math.Sqrt((double_4 - num3) * (double_4 - num3) + (double_5 - num4) * (double_5 - num4));
		}

		public static int smethod_21(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6)
		{
			double num = double_0 + double_2;
			double num2 = double_1 + double_3;
			if (double_4 >= double_0 && double_4 <= num)
			{
				if (Math.Abs(double_4 - double_0) <= double_6)
				{
					return 3;
				}
				if (Math.Abs(double_4 - num) <= double_6)
				{
					return 1;
				}
			}
			if (double_5 >= double_1 && double_5 <= num2)
			{
				if (Math.Abs(double_5 - double_1) <= double_6)
				{
					return 0;
				}
				if (Math.Abs(double_5 - num2) <= double_6)
				{
					return 2;
				}
			}
			return -1;
		}

		public static int smethod_22(int[] int_0, int int_1, bool bool_0)
		{
			if (int_0 != null)
			{
				int num = 0;
				int num2 = int_0.Length - 1;
				if (int_0.Length < 10 || !bool_0)
				{
					for (int i = num; i <= num2; i++)
					{
						if (int_1 == int_0[i])
						{
							return i;
						}
					}
				}
				else
				{
					int num3 = 0;
					int num4 = num2 - num;
					while (num4 > 10)
					{
						num3 = num + num4 / 2;
						if (int_0[num3] != int_1)
						{
							if (int_0[num3] > int_1)
							{
								num2 = num3;
							}
							else
							{
								num = num3;
							}
							num4 = num2 - num;
							continue;
						}
						return num3;
					}
					for (int i = num; i <= num2; i++)
					{
						if (int_1 == int_0[i])
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		public static double smethod_23(double double_0, double double_1, double double_2, double double_3)
		{
			if (double_0 == double_2)
			{
				if (double_3 >= double_1)
				{
					return 90.0;
				}
				return 270.0;
			}
			double num = Math.Atan((double_3 - double_1) / (double_2 - double_0));
			num = 180.0 * num / Math.PI;
			if (double_2 >= double_0)
			{
				if (double_3 >= double_1)
				{
					return num;
				}
				return num + 360.0;
			}
			return num + 180.0;
		}

		public static int smethod_24(int int_0, int int_1, bool bool_0)
		{
			int num = 1 >> int_1;
			int_0 = ((!bool_0) ? (int_0 & ~num) : (int_0 | num));
			return int_0;
		}

		public static int smethod_25(int int_0, int int_1, bool bool_0)
		{
			return bool_0 ? (int_0 | int_1) : (int_0 & ~int_1);
		}

		public static bool smethod_26(int int_0, int int_1)
		{
			return (int_0 & int_1) == int_1;
		}

		public static bool smethod_27(int int_0, int int_1, int int_2)
		{
			if (int_0 < int_1)
			{
				return int_2 >= int_0 && int_2 <= int_1;
			}
			return int_2 >= int_1 && int_2 <= int_0;
		}

		public static bool smethod_28(double double_0, double double_1, double double_2)
		{
			if (double_0 < double_1)
			{
				return double_2 >= double_0 && double_2 <= double_1;
			}
			return double_2 >= double_1 && double_2 <= double_0;
		}

		public static Point smethod_29(Point point_0, Point point_1, double double_0)
		{
			if (point_0.X == point_1.X && point_0.Y == point_1.Y)
			{
				return point_1;
			}
			double d = (point_1.X - point_0.X) * (point_1.X - point_0.X) + (point_1.Y - point_0.Y) * (point_1.Y - point_0.Y);
			d = Math.Sqrt(d);
			double num = Math.Atan2(point_1.Y - point_0.Y, point_1.X - point_0.X);
			num -= double_0;
			Point empty = Point.Empty;
			empty.X = (int)((double)point_0.X + d * Math.Cos(num));
			empty.Y = (int)((double)point_0.Y + d * Math.Sin(num));
			return empty;
		}

		public static PointF smethod_30(PointF pointF_0, PointF pointF_1, double double_0)
		{
			if (pointF_0.X == pointF_1.X && pointF_0.Y == pointF_1.Y)
			{
				return pointF_1;
			}
			double d = (pointF_1.X - pointF_0.X) * (pointF_1.X - pointF_0.X) + (pointF_1.Y - pointF_0.Y) * (pointF_1.Y - pointF_0.Y);
			d = Math.Sqrt(d);
			double num = Math.Atan2(pointF_1.Y - pointF_0.Y, pointF_1.X - pointF_0.X);
			num -= double_0;
			PointF empty = PointF.Empty;
			empty.X = (float)((double)pointF_0.X + d * Math.Cos(num));
			empty.Y = (float)((double)pointF_0.Y + d * Math.Sin(num));
			return empty;
		}

		public static Point[] smethod_31(Rectangle rectangle_0, int int_0, int int_1, int int_2, int int_3)
		{
			ArrayList arrayList = new ArrayList();
			Point[] array = new Point[5]
			{
				new Point(rectangle_0.Left, rectangle_0.Top),
				new Point(rectangle_0.Right, rectangle_0.Top),
				new Point(rectangle_0.Right, rectangle_0.Bottom),
				new Point(rectangle_0.Left, rectangle_0.Bottom),
				new Point(rectangle_0.Left, rectangle_0.Top)
			};
			for (int i = 0; i <= array.Length - 2; i++)
			{
				Point point = smethod_36(array[i].X, array[i].Y, array[i + 1].X, array[i + 1].Y, int_0, int_1, int_2, int_3, bool_0: false);
				if (point.X != int.MaxValue && point.Y != int.MinValue)
				{
					arrayList.Add(point);
				}
			}
			return (Point[])arrayList.ToArray(typeof(Point));
		}

		public static bool smethod_32(Rectangle rectangle_0, int int_0, int int_1, int int_2, int int_3)
		{
			if (rectangle_0.Contains(int_0, int_1))
			{
				return true;
			}
			if (rectangle_0.Contains(int_2, int_3))
			{
				return true;
			}
			if (smethod_33(int_0, int_1, int_2, int_3, rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Top))
			{
				return true;
			}
			if (smethod_33(int_0, int_1, int_2, int_3, rectangle_0.Right, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom))
			{
				return true;
			}
			if (smethod_33(int_0, int_1, int_2, int_3, rectangle_0.Right, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Bottom))
			{
				return true;
			}
			if (smethod_33(int_0, int_1, int_2, int_3, rectangle_0.Left, rectangle_0.Bottom, rectangle_0.Left, rectangle_0.Top))
			{
				return true;
			}
			return false;
		}

		public static bool smethod_33(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7)
		{
			Point point = smethod_36(int_0, int_1, int_2, int_3, int_4, int_5, int_6, int_7, bool_0: false);
			if (point.X == int.MinValue && point.Y == int.MinValue)
			{
				return false;
			}
			return true;
		}

		public static bool smethod_34(int int_0, int int_1, int int_2, int int_3)
		{
			if (int_0 <= int_3 && int_2 <= int_1)
			{
				return true;
			}
			return false;
		}

		public static double[] GetLineEquationParameter(double double_0, double double_1, double double_2, double double_3)
		{
			int num = 19;
			if (double.IsNaN(double_0))
			{
				throw new ArgumentException("x1 is Nan");
			}
			if (double.IsNaN(double_1))
			{
				throw new ArgumentException("y1 is Nan");
			}
			if (double.IsNaN(double_2))
			{
				throw new ArgumentException("x2 is Nan");
			}
			if (double.IsNaN(double_3))
			{
				throw new ArgumentException("y2 is Nan");
			}
			if (double_0 != double_2)
			{
				double num2 = (double_3 - double_1) / (double_2 - double_0);
				double num3 = double_1 - num2 * double_0;
				return new double[2]
				{
					num2,
					num3
				};
			}
			return null;
		}

		public static Point smethod_36(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, bool bool_0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			if (int_0 != int_2)
			{
				num3 = (double)(int_3 - int_1) / (double)(int_2 - int_0);
				num5 = (double)int_1 - num3 * (double)int_0;
			}
			if (int_4 != int_6)
			{
				num4 = (double)(int_7 - int_5) / (double)(int_6 - int_4);
				num6 = (double)int_5 - num4 * (double)int_4;
			}
			if (int_0 == int_2)
			{
				if (int_4 == int_6)
				{
					if (int_0 == int_4)
					{
						if (bool_0)
						{
							if (smethod_34(int_1, int_3, int_5, int_7))
							{
								return new Point(int.MaxValue, int.MaxValue);
							}
							return new Point(int.MinValue, int.MinValue);
						}
						return new Point(int.MaxValue, int.MaxValue);
					}
					return new Point(int.MinValue, int.MinValue);
				}
				num = int_0;
				num2 = num4 * num + num6;
			}
			else if (int_4 == int_6)
			{
				num = int_4;
				num2 = num3 * num + num5;
			}
			else
			{
				if (num3 == num4)
				{
					if (num5 == num6)
					{
						if (bool_0)
						{
							if (smethod_34(int_0, int_2, int_4, int_6))
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
			if (!bool_0)
			{
				if (smethod_28(int_0, int_2, num) && smethod_28(int_4, int_6, num) && smethod_28(int_1, int_3, num2) && smethod_28(int_5, int_7, num2))
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
