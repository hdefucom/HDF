using DCSoftDotfuscate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       定义矩形相关的例称模块，本对象不能实例化
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public sealed class RectangleCommon
	{
		/// <summary>
		///       缩放矩形
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <param name="x0">原点X坐标</param>
		/// <param name="y0">原点Y坐标</param>
		/// <param name="xZoomRate">X方向缩放比率</param>
		/// <param name="yZoomRate">Y方向缩放比率</param>
		/// <returns>转换后的矩形</returns>
		public static RectangleF ZoomRectangleF(RectangleF rect, float float_0, float float_1, float xZoomRate, float yZoomRate)
		{
			float num = float_0 + (rect.X - float_0) * xZoomRate;
			float num2 = float_1 + (rect.Y - float_1) * yZoomRate;
			float num3 = float_0 + (rect.Right - float_0) * xZoomRate;
			float num4 = float_1 + (rect.Bottom - float_1) * yZoomRate;
			return new RectangleF(num, num2, num3 - num, num4 - num2);
		}

		public static RectangleF[] CompressRectangles(RectangleF[] rects)
		{
			List<RectangleF> list = new List<RectangleF>();
			for (int i = 0; i < rects.Length; i++)
			{
				RectangleF rectangleF = rects[i];
				if (rectangleF.IsEmpty)
				{
					continue;
				}
				RectangleF rectangleF2 = rectangleF;
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					RectangleF rectangleF3 = list[j];
					if (!rectangleF3.Contains(rectangleF2))
					{
						if (!rectangleF2.Contains(rectangleF3))
						{
							if (rectangleF2.Top == rectangleF3.Top && rectangleF2.Height == rectangleF3.Height)
							{
								if (rectangleF2.IntersectsWith(rectangleF3) || rectangleF2.Left == rectangleF3.Right || rectangleF2.Left == rectangleF3.Right + 1f || rectangleF2.Right == rectangleF3.Left || rectangleF2.Right == rectangleF3.Left - 1f)
								{
									list[j] = RectangleF.Union(rectangleF2, rectangleF3);
									flag = false;
									break;
								}
							}
							else if (rectangleF2.Left == rectangleF3.Left && rectangleF2.Width == rectangleF3.Width && (rectangleF2.IntersectsWith(rectangleF3) || rectangleF2.Top == rectangleF3.Bottom || rectangleF2.Top == rectangleF3.Bottom + 1f || rectangleF2.Bottom == rectangleF3.Top || rectangleF2.Bottom == rectangleF3.Top - 1f))
							{
								list[j] = RectangleF.Union(rectangleF2, rectangleF3);
								flag = false;
								break;
							}
							continue;
						}
						list[j] = rectangleF2;
						flag = false;
						break;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					list.Add(rectangleF2);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		///       修改矩形
		///       </summary>
		/// <remarks>
		///       本函数支持9种修改方式
		///       0：移动矩形的左上角的位置，右下角保持不变。
		///       1：移动上边框线的位置，其他边框线位置不变。
		///       2：移动右上角的位置，左下角保持不变。
		///       3：移动右边框线的位置，其他边框线位置不变。
		///       4：移动右下角位置，左上角保持不变。
		///       5：移动下边框线的位置，其他边框线位置不变。
		///       6：移动左下角位置，右上角位置不变。
		///       7：移动左边框线位置，其他边框线位置不变。
		///       8：移动矩形位置，矩形宽度和高度不变。
		///       </remarks>
		/// <param name="rect">原始矩形</param>
		/// <param name="dx">横向偏移量</param>
		/// <param name="dy">纵向偏移量</param>
		/// <param name="controlPoint">修改方式</param>
		/// <returns>修改后的矩形</returns>
		public static Rectangle ChangeRectangle(Rectangle rect, int int_0, int int_1, int controlPoint)
		{
			if (int_0 != 0 || int_1 != 0)
			{
				switch (controlPoint)
				{
				case 0:
					rect.X += int_0;
					rect.Width -= int_0;
					rect.Y += int_1;
					rect.Height -= int_1;
					break;
				case 1:
					rect.Y += int_1;
					rect.Height -= int_1;
					break;
				case 2:
					rect.Width += int_0;
					rect.Y += int_1;
					rect.Height -= int_1;
					break;
				case 3:
					rect.Width += int_0;
					break;
				case 4:
					rect.Width += int_0;
					rect.Height += int_1;
					break;
				case 5:
					rect.Height += int_1;
					break;
				case 6:
					rect.X += int_0;
					rect.Width -= int_0;
					rect.Height += int_1;
					break;
				case 7:
					rect.X += int_0;
					rect.Width -= int_0;
					break;
				case 8:
					rect.X += int_0;
					rect.Y += int_1;
					break;
				}
			}
			return rect;
		}

		/// <summary>
		///       修改矩形
		///       </summary>
		/// <remarks>
		///       本函数支持9种修改方式
		///       0：移动矩形的左上角的位置，右下角保持不变。
		///       1：移动上边框线的位置，其他边框线位置不变。
		///       2：移动右上角的位置，左下角保持不变。
		///       3：移动右边框线的位置，其他边框线位置不变。
		///       4：移动右下角位置，左上角保持不变。
		///       5：移动下边框线的位置，其他边框线位置不变。
		///       6：移动左下角位置，右上角位置不变。
		///       7：移动左边框线位置，其他边框线位置不变。
		///       8：移动矩形位置，矩形宽度和高度不变。
		///       </remarks>
		/// <param name="rect">原始矩形</param>
		/// <param name="dx">横向偏移量</param>
		/// <param name="dy">纵向偏移量</param>
		/// <param name="controlPoint">修改方式</param>
		/// <returns>修改后的矩形</returns>
		public static RectangleF ChangeRectangle(RectangleF rect, float float_0, float float_1, int controlPoint)
		{
			if (float_0 != 0f || float_1 != 0f)
			{
				switch (controlPoint)
				{
				case 0:
					rect.X += float_0;
					rect.Width -= float_0;
					rect.Y += float_1;
					rect.Height -= float_1;
					break;
				case 1:
					rect.Y += float_1;
					rect.Height -= float_1;
					break;
				case 2:
					rect.Width += float_0;
					rect.Y += float_1;
					rect.Height -= float_1;
					break;
				case 3:
					rect.Width += float_0;
					break;
				case 4:
					rect.Width += float_0;
					rect.Height += float_1;
					break;
				case 5:
					rect.Height += float_1;
					break;
				case 6:
					rect.X += float_0;
					rect.Width -= float_0;
					rect.Height += float_1;
					break;
				case 7:
					rect.X += float_0;
					rect.Width -= float_0;
					break;
				case 8:
					rect.X += float_0;
					rect.Y += float_1;
					break;
				}
			}
			return rect;
		}

		/// <summary>
		///       获得距离指定点最近的矩形区域,各个矩形区域相互不相重
		///       </summary>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <param name="rectangles">
		/// </param>
		/// <returns>
		/// </returns>
		public static int GetNearestRectangle(float float_0, float float_1, RectangleF[] rectangles)
		{
			float num = 0f;
			int result = -1;
			int num2 = 0;
			while (true)
			{
				if (num2 < rectangles.Length)
				{
					RectangleF rectangle = rectangles[num2];
					if (rectangle.Contains(float_0, float_1))
					{
						break;
					}
					float distance = GetDistance(float_0, float_1, rectangle);
					if (num2 == 0 || distance < num)
					{
						num = distance;
						result = num2;
					}
					num2++;
					continue;
				}
				return result;
			}
			return num2;
		}

		/// <summary>
		///       获得指定点相对于指定矩形的距离
		///       </summary>
		/// <param name="x">指定点的X坐标</param>
		/// <param name="y">指定点的Y坐标</param>
		/// <param name="rectangle">矩形边框</param>
		/// <returns>距离，若小于0则点被包含在矩形区域中</returns>
		public static float GetDistance(float float_0, float float_1, RectangleF rectangle)
		{
			float result = 0f;
			switch (GetRectangleArea(rectangle, float_0, float_1))
			{
			case 0:
			{
				result = Math.Min(float_0 - rectangle.Left, rectangle.Right - float_0);
				float val = Math.Min(float_1 - rectangle.Top, rectangle.Bottom - float_1);
				result = 0f - Math.Min(result, val);
				break;
			}
			case 1:
				result = (float)Math.Sqrt((float_0 - rectangle.Left) * (float_0 - rectangle.Left) + (float_1 - rectangle.Top) * (float_1 - rectangle.Top));
				break;
			case 2:
				result = rectangle.Top - float_1;
				break;
			case 3:
				result = (float)Math.Sqrt((float_0 - rectangle.Right) * (float_0 - rectangle.Right) + (float_1 - rectangle.Top) * (float_1 - rectangle.Top));
				break;
			case 4:
				result = float_0 - rectangle.Right;
				break;
			case 5:
				result = (float)Math.Sqrt((float_0 - rectangle.Right) * (float_0 - rectangle.Right) + (float_1 - rectangle.Bottom) * (float_1 - rectangle.Bottom));
				break;
			case 6:
				result = float_1 - rectangle.Bottom;
				break;
			case 7:
				result = (float)Math.Sqrt((float_0 - rectangle.Left) * (float_0 - rectangle.Left) + (float_1 - rectangle.Bottom) * (float_1 - rectangle.Bottom));
				break;
			case 8:
				result = rectangle.Left - float_0;
				break;
			}
			return result;
		}

		/// <summary>
		///       获得指定点在指定矩形相对的区域编号
		///       </summary>
		/// <remarks>
		///
		///         1  |   2   |  3
		///       -----+=======+-------
		///            ||     ||
		///         8  ||  0  ||  4
		///            ||     ||
		///       -----+=======+-------
		///         7  |   6   |  5
		///
		///       </remarks>
		/// <param name="rectangle">
		/// </param>
		/// <param name="x">
		/// </param>
		/// <param name="y">
		/// </param>
		/// <returns>
		/// </returns>
		public static int GetRectangleArea(RectangleF rectangle, float float_0, float float_1)
		{
			if (rectangle.Contains(float_0, float_1))
			{
				return 0;
			}
			if (float_1 < rectangle.Top)
			{
				if (float_0 < rectangle.Left)
				{
					return 1;
				}
				if (float_0 < rectangle.Right)
				{
					return 2;
				}
				return 3;
			}
			if (float_1 < rectangle.Bottom)
			{
				if (float_0 < rectangle.Left)
				{
					return 8;
				}
				if (float_0 < rectangle.Right)
				{
					return 0;
				}
				return 4;
			}
			if (float_0 < rectangle.Left)
			{
				return 7;
			}
			if (float_0 < rectangle.Right)
			{
				return 6;
			}
			return 5;
		}

		/// <summary>
		///       获得两个矩形间的一个过渡矩形
		///       </summary>
		/// <param name="rect1">原始矩形</param>
		/// <param name="rect2">目标矩形</param>
		/// <param name="rate">过渡系数，若为0则返回原始矩形，若为1则返回目标矩形</param>
		/// <returns>过渡矩形</returns>
		public static Rectangle GetMiddleRectangle(Rectangle rect1, Rectangle rect2, double rate)
		{
			int x = rect1.Left + (int)((double)(rect2.Left - rect1.Left) * rate);
			int y = rect1.Top + (int)((double)(rect2.Top - rect1.Top) * rate);
			int width = rect1.Width + (int)((double)(rect2.Width - rect1.Width) * rate);
			int height = rect1.Height + (int)((double)(rect2.Height - rect1.Height) * rate);
			return new Rectangle(x, y, width, height);
		}

		/// <summary>
		///       修改矩形的宽度和高度
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <param name="dsize">大小改变量</param>
		/// <returns>获得的新矩形</returns>
		public static Rectangle ReSize(Rectangle rect, int dsize)
		{
			return new Rectangle(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
		}

		/// <summary>
		///       计算内置旋转矩形的大小
		///       </summary>
		/// <param name="Width">矩形的宽度</param>
		/// <param name="Height">矩形的高度</param>
		/// <param name="angle">旋转的角度</param>
		/// <returns>旋转后的外接矩形的大小</returns>
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

		/// <summary>
		///       逆时针旋转矩形
		///       </summary>
		/// <param name="o">原点</param>
		/// <param name="rect">旋转的矩形</param>
		/// <param name="angle">弧度</param>
		/// <returns>旋转后的矩形的四个顶点的坐标</returns>
		public static Point[] RotateRectanglePoints(Point point_0, Rectangle rect, double angle)
		{
			Point[] array = To4Points(rect);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MathCommon.smethod_29(point_0, array[i], angle);
			}
			return array;
		}

		/// <summary>
		///       逆时针旋转矩形
		///       </summary>
		/// <param name="o">原点</param>
		/// <param name="rect">旋转的矩形</param>
		/// <param name="angle">弧度</param>
		/// <returns>旋转后的矩形的四个顶点的最小外切矩形</returns>
		public static Rectangle RotateRectangle(Point point_0, Rectangle rect, double angle)
		{
			Point[] array = To4Points(rect);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MathCommon.smethod_29(point_0, array[i], angle);
			}
			return GetPointsBounds(array);
		}

		/// <summary>
		///       返回包含指定的点集合的最小外切矩形
		///       </summary>
		/// <param name="ps">点坐标数组</param>
		/// <returns>包含所有点的方框对象,若没有数据则返回空方框对象</returns>
		public static Rectangle GetPointsBounds(Point[] point_0)
		{
			if (point_0 != null && point_0.Length > 1)
			{
				int x = point_0[0].X;
				int x2 = point_0[0].X;
				int y = point_0[0].Y;
				int y2 = point_0[0].Y;
				for (int i = 0; i < point_0.Length; i++)
				{
					if (x < point_0[i].X)
					{
						x = point_0[i].X;
					}
					if (x2 > point_0[i].X)
					{
						x2 = point_0[i].X;
					}
					if (y < point_0[i].Y)
					{
						y = point_0[i].Y;
					}
					if (y2 > point_0[i].Y)
					{
						y2 = point_0[i].Y;
					}
				}
				return new Rectangle(x2, y2, x - x2, y - y2);
			}
			return Rectangle.Empty;
		}

		/// <summary>
		///       返回包含指定的点集合的最小外切矩形
		///       </summary>
		/// <param name="ps">点坐标数组</param>
		/// <returns>包含所有点的方框对象,若没有数据则返回空方框对象</returns>
		public static RectangleF GetPointsBounds(PointF[] pointF_0)
		{
			if (pointF_0 != null && pointF_0.Length > 1)
			{
				float x = pointF_0[0].X;
				float x2 = pointF_0[0].X;
				float y = pointF_0[0].Y;
				float y2 = pointF_0[0].Y;
				for (int i = 0; i < pointF_0.Length; i++)
				{
					if (x < pointF_0[i].X)
					{
						x = pointF_0[i].X;
					}
					if (x2 > pointF_0[i].X)
					{
						x2 = pointF_0[i].X;
					}
					if (y < pointF_0[i].Y)
					{
						y = pointF_0[i].Y;
					}
					if (y2 > pointF_0[i].Y)
					{
						y2 = pointF_0[i].Y;
					}
				}
				return new RectangleF(x2, y2, x - x2, y - y2);
			}
			return RectangleF.Empty;
		}

		/// <summary>
		///       进行矩形对齐操作
		///       </summary>
		/// <param name="MainRect">主矩形</param>
		/// <param name="width">要对齐的矩形的宽度</param>
		/// <param name="height">要对齐的矩形的高度</param>
		/// <param name="align">对齐方式</param>
		/// <returns>对齐操作所得的矩形</returns>
		public static Rectangle AlignRect(Rectangle MainRect, int width, int height, ContentAlignment align)
		{
			Rectangle result = new Rectangle(0, 0, width, height);
			switch (align)
			{
			case ContentAlignment.MiddleCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2;
				break;
			case ContentAlignment.MiddleLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2;
				break;
			case ContentAlignment.TopLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.TopCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.TopRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.BottomLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Bottom - result.Height;
				break;
			case ContentAlignment.MiddleRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2;
				break;
			default:
				result.X = MainRect.Left;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.BottomRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Bottom - result.Height;
				break;
			case ContentAlignment.BottomCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2;
				result.Y = MainRect.Bottom - result.Height;
				break;
			}
			return result;
		}

		/// <summary>
		///       进行矩形对齐操作
		///       </summary>
		/// <param name="MainRect">主矩形</param>
		/// <param name="width">要对齐的矩形的宽度</param>
		/// <param name="height">要对齐的矩形的高度</param>
		/// <param name="align">对齐方式</param>
		/// <returns>对齐操作所得的矩形</returns>
		public static RectangleF AlignRect(RectangleF MainRect, float width, float height, ContentAlignment align)
		{
			RectangleF result = new RectangleF(0f, 0f, width, height);
			switch (align)
			{
			case ContentAlignment.MiddleCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2f;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2f;
				break;
			case ContentAlignment.MiddleLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2f;
				break;
			case ContentAlignment.TopLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.TopCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2f;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.TopRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.BottomLeft:
				result.X = MainRect.Left;
				result.Y = MainRect.Bottom - result.Height;
				break;
			case ContentAlignment.MiddleRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Top + (MainRect.Height - result.Height) / 2f;
				break;
			default:
				result.X = MainRect.Left;
				result.Y = MainRect.Top;
				break;
			case ContentAlignment.BottomRight:
				result.X = MainRect.Right - result.Width;
				result.Y = MainRect.Bottom - result.Height;
				break;
			case ContentAlignment.BottomCenter:
				result.X = MainRect.Left + (MainRect.Width - result.Width) / 2f;
				result.Y = MainRect.Bottom - result.Height;
				break;
			}
			return result;
		}

		/// <summary>
		///       进行矩形对齐操作
		///       </summary>
		/// <param name="MainRect">主矩形</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <param name="Align">水平对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
		/// <param name="VAlign">垂直对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
		/// <returns>对齐操作产生的矩形</returns>
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

		/// <summary>
		///       将整数矩形转换为浮点数矩形
		///       </summary>
		/// <param name="rect">整数矩形对象</param>
		/// <returns>转换所得的浮点数矩形</returns>
		public static RectangleF ToRectangleF(Rectangle rect)
		{
			return new RectangleF(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		/// <summary>
		///       将浮点数矩形转换为整数矩形
		///       </summary>
		/// <param name="rect">浮点数矩形</param>
		/// <returns>转换所得的整数矩形</returns>
		public static Rectangle ToRectangle(RectangleF rect)
		{
			return new Rectangle((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height);
		}

		/// <summary>
		///       在绘图操作中判断指定的大小是否表示有效的大小
		///       </summary>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>是否表示有效大小,若为有效大小则需要进行绘制操作,否则不需要进行绘制操作</returns>
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

		/// <summary>
		///       获得内置矩形
		///       </summary>
		/// <param name="rect">外围的矩形</param>
		/// <param name="Align">水平对齐方式</param>
		/// <param name="LineAlign">垂直对齐方式</param>
		/// <param name="InnerRectSize">内置矩形的大小</param>
		/// <returns>内置矩形</returns>
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

		/// <summary>
		///       返回表示矩形左上点，右上点和右下点坐标的点结构体数组
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含3个元素的点结构体数组</returns>
		public static Point[] To3Points(Rectangle rect)
		{
			return new Point[3]
			{
				new Point(rect.X, rect.Y),
				new Point(rect.Right, rect.Y),
				new Point(rect.Right, rect.Bottom)
			};
		}

		/// <summary>
		///       返回表示矩形四个顶点坐标的点结构体数组
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含4个元素的点结构体数组</returns>
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

		/// <summary>
		///       返回表示矩形四个顶点坐标的点结构体数组,并进行闭合
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含5个元素的点结构体数组</returns>
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

		/// <summary>
		///       获得正方形
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>获得的正方形</returns>
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

		/// <summary>
		///       返回整数矩形的中心坐标
		///       </summary>
		/// <param name="rect">整数矩形对象</param>
		/// <returns>矩形中心坐标</returns>
		public static Point Center(Rectangle rect)
		{
			return new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
		}

		/// <summary>
		///       获得以指定矩形的中心为中心的指定大小的矩形对象
		///       </summary>
		/// <param name="rect">原始矩形区域</param>
		/// <param name="size">指定的矩形大小</param>
		/// <returns>获得的矩形对象</returns>
		public static Rectangle Center(Rectangle rect, Size size)
		{
			return new Rectangle(rect.Left + (rect.Width - size.Width) / 2, rect.Top + (rect.Height - size.Height) / 2, size.Width, size.Height);
		}

		/// <summary>
		///       获得以指定矩形的中心为中心的指定大小的矩形对象
		///       </summary>
		/// <param name="rect">原始矩形区域</param>
		/// <param name="size">指定的矩形大小</param>
		/// <returns>获得的矩形对象</returns>
		public static RectangleF Center(RectangleF rect, SizeF size)
		{
			return new RectangleF(rect.Left + (rect.Width - size.Width) / 2f, rect.Top + (rect.Height - size.Height) / 2f, size.Width, size.Height);
		}

		/// <summary>
		///       移动指定的矩形,使其中心为指定点
		///       </summary>
		/// <param name="rect">原始矩形区域</param>
		/// <param name="x">中心点X坐标</param>
		/// <param name="y">中心点Y坐标</param>
		/// <returns>移动后的矩形区域</returns>
		public static Rectangle SetCenter(Rectangle rect, int int_0, int int_1)
		{
			return new Rectangle(int_0 - rect.Width / 2, int_1 - rect.Height / 2, rect.Width, rect.Height);
		}

		/// <summary>
		///       移动指定的矩形,使其中心为指定点
		///       </summary>
		/// <param name="rect">原始矩形区域</param>
		/// <param name="x">中心点X坐标</param>
		/// <param name="y">中心点Y坐标</param>
		/// <returns>移动后的矩形区域</returns>
		public RectangleF SetCenter(RectangleF rect, float float_0, float float_1)
		{
			return new RectangleF((float)((double)float_0 - (double)rect.Width / 2.0), (float)((double)float_1 - (double)rect.Height / 2.0), rect.Width, rect.Height);
		}

		/// <summary>
		///       判断指定点是指定的矩形的那个顶点,返回-1:不是顶点 0:为左上点 1:右上点 2:右下点 3:左下点
		///       </summary>
		/// <param name="vRect">矩形对象</param>
		/// <param name="p">点对象</param>
		/// <returns>返回值</returns>
		public static int GetAcmeIndex(Rectangle vRect, Point point_0)
		{
			if (!vRect.IsEmpty)
			{
				if (point_0.Y == vRect.Y)
				{
					if (point_0.X == vRect.X)
					{
						return 0;
					}
					if (point_0.X == vRect.Right)
					{
						return 1;
					}
				}
				else if (point_0.Y == vRect.Bottom)
				{
					if (point_0.X == vRect.Right)
					{
						return 2;
					}
					if (point_0.X == vRect.X)
					{
						return 3;
					}
				}
			}
			return -1;
		}

		/// <summary>
		///       获得指定矩形指定顶端的坐标,矩形顶点编号为 0:为左上点 1:右上点 2:右下点 3:左下点
		///       </summary>
		/// <param name="vRect">
		/// </param>
		/// <param name="AcmeIndex">
		/// </param>
		/// <returns>
		/// </returns>
		public static Point GetAcmePos(Rectangle vRect, int AcmeIndex)
		{
			switch (AcmeIndex)
			{
			default:
				return Point.Empty;
			case 0:
				return vRect.Location;
			case 1:
				return new Point(vRect.Right, vRect.Y);
			case 2:
				return new Point(vRect.Right, vRect.Bottom);
			case 3:
				return new Point(vRect.X, vRect.Bottom);
			}
		}

		/// <summary>
		///       根据两点坐标获得方框对象
		///       </summary>
		/// <param name="x1">
		/// </param>
		/// <param name="y1">
		/// </param>
		/// <param name="x2">
		/// </param>
		/// <param name="y2">
		/// </param>
		/// <returns>
		/// </returns>
		public static Rectangle GetRectangle(int int_0, int int_1, int int_2, int int_3)
		{
			Rectangle empty = Rectangle.Empty;
			if (int_0 < int_2)
			{
				empty.X = int_0;
				empty.Width = int_2 - int_0;
			}
			else
			{
				empty.X = int_2;
				empty.Width = int_0 - int_2;
			}
			if (int_1 < int_3)
			{
				empty.Y = int_1;
				empty.Height = int_3 - int_1;
			}
			else
			{
				empty.Y = int_3;
				empty.Height = int_1 - int_3;
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

		/// <summary>
		///       根据两点坐标获得方框对象
		///       </summary>
		/// <param name="p1">第一个点的坐标</param>
		/// <param name="p2">第二个点的坐标</param>
		/// <returns>
		/// </returns>
		public static Rectangle GetRectangle(Point point_0, Point point_1)
		{
			return GetRectangle(point_0.X, point_0.Y, point_1.X, point_1.Y);
		}

		/// <summary>
		///       移动X坐标到矩形区域中
		///       </summary>
		/// <param name="x">X坐标</param>
		/// <param name="Bounds">矩形区域</param>
		/// <returns>修正后的X坐标值</returns>
		public static int MoveXInto(int int_0, Rectangle Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return int_0;
			}
			if (int_0 < Bounds.Left)
			{
				int_0 = Bounds.Left;
			}
			else if (int_0 > Bounds.Right)
			{
				int_0 = Bounds.Right;
			}
			return int_0;
		}

		/// <summary>
		///       移动Y坐标到矩形区域中
		///       </summary>
		/// <param name="y">Y坐标值</param>
		/// <param name="Bounds">矩形区域</param>
		/// <returns>修正后的Y坐标值</returns>
		public static int MoveYInto(int int_0, Rectangle Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return int_0;
			}
			if (int_0 < Bounds.Top)
			{
				int_0 = Bounds.Top;
			}
			else if (int_0 > Bounds.Bottom)
			{
				int_0 = Bounds.Bottom;
			}
			return int_0;
		}

		/// <summary>
		///       移动一个矩形,致使在指定的矩形中
		///       </summary>
		/// <param name="rect">要修正的矩形</param>
		/// <param name="Bounds">容器矩形</param>
		/// <returns>修正后的矩形</returns>
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

		/// <summary>
		///       将点移动到矩形区域中
		///       </summary>
		/// <param name="p">点坐标</param>
		/// <param name="Bounds">矩形区域</param>
		/// <returns>修正后的点坐标</returns>
		public static Point MoveInto(Point point_0, Rectangle Bounds)
		{
			if (!Bounds.IsEmpty)
			{
				if (point_0.X < Bounds.Left)
				{
					point_0.X = Bounds.Left;
				}
				if (point_0.X >= Bounds.Right)
				{
					point_0.X = Bounds.Right;
				}
				if (point_0.Y < Bounds.Top)
				{
					point_0.Y = Bounds.Top;
				}
				if (point_0.Y >= Bounds.Bottom)
				{
					point_0.Y = Bounds.Bottom;
				}
			}
			return point_0;
		}

		/// <summary>
		///       获得矩形顶点坐标
		///       </summary>
		/// <param name="intLeft">矩形左端位置</param>
		/// <param name="intTop">矩形顶端位置</param>
		/// <param name="intWidth">矩形宽度</param>
		/// <param name="intHeight">矩形高度</param>
		/// <param name="iPos">顶点序号</param>
		/// <param name="iSplit">矩形边框分割份数</param>
		/// <returns>点坐标</returns>
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

		/// <summary>
		///       修改矩形的宽度和高度
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <param name="dsize">大小改变量</param>
		/// <returns>获得的新矩形</returns>
		public static RectangleF ReSize(RectangleF rect, float dsize)
		{
			return new RectangleF(rect.Left, rect.Top, rect.Width + dsize, rect.Height + dsize);
		}

		/// <summary>
		///       计算内置旋转矩形的大小
		///       </summary>
		/// <param name="Width">矩形宽度</param>
		/// <param name="Height">矩形高度</param>
		/// <param name="angle">旋转的角度</param>
		/// <returns>
		/// </returns>
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

		/// <summary>
		///       逆时针旋转矩形
		///       </summary>
		/// <param name="o">原点</param>
		/// <param name="rect">旋转的矩形</param>
		/// <param name="angle">弧度</param>
		/// <returns>旋转后的矩形</returns>
		public static RectangleF RotateRectangle(PointF pointF_0, RectangleF rect, double angle)
		{
			PointF[] array = To4Points(rect);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = MathCommon.smethod_30(pointF_0, array[i], angle);
			}
			return GetPointsBounds(array);
		}

		public static RectangleF AlignRect(RectangleF mainRect, float width, float height, StringFormat format)
		{
			float left = mainRect.Left;
			float top = mainRect.Top;
			if (format != null)
			{
				return AlignRect(mainRect, width, height, format.Alignment, format.LineAlignment);
			}
			return new RectangleF(left, top, width, height);
		}

		public static RectangleF AlignRect(RectangleF mainRect, float width, float height, StringAlignment alignment, StringAlignment lineAlignment)
		{
			float x = mainRect.Left;
			float y = mainRect.Top;
			switch (alignment)
			{
			case StringAlignment.Near:
				x = mainRect.Left;
				break;
			case StringAlignment.Center:
				x = mainRect.Left + (mainRect.Width - width) / 2f;
				break;
			case StringAlignment.Far:
				x = mainRect.Right - width;
				break;
			}
			switch (lineAlignment)
			{
			case StringAlignment.Near:
				y = mainRect.Top;
				break;
			case StringAlignment.Center:
				y = mainRect.Top + (mainRect.Height - height) / 2f;
				break;
			case StringAlignment.Far:
				y = mainRect.Bottom - height;
				break;
			}
			return new RectangleF(x, y, width, height);
		}

		/// <summary>
		///       进行矩形对齐操作
		///       </summary>
		/// <param name="MainRect">主矩形</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <param name="Align">水平对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
		/// <param name="VAlign">垂直对齐方式 1:左对齐 2:居中对齐 3:右对齐 其他:不进行对齐操作</param>
		/// <returns>对齐操作产生的矩形</returns>
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

		/// <summary>
		///       在绘图操作中判断指定的大小是否表示有效的大小
		///       </summary>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>是否表示有效大小,若为有效大小则需要进行绘制操作,否则不需要进行绘制操作</returns>
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

		/// <summary>
		///       根据宽度高度比获得居中的内置矩形
		///       </summary>
		/// <param name="rect">矩形</param>
		/// <param name="widthHeightRate">宽度高度比</param>
		/// <returns>获得的矩形</returns>
		public static RectangleF GetInnerRectangle(RectangleF rect, float widthHeightRate)
		{
			if (rect.Width == 0f || rect.Height == 0f)
			{
				return RectangleF.Empty;
			}
			if (widthHeightRate <= 0f)
			{
				return RectangleF.Empty;
			}
			RectangleF result;
			if (widthHeightRate > rect.Width / rect.Height)
			{
				result = new RectangleF(rect.Left, rect.Top, rect.Width, rect.Width / widthHeightRate);
				result.Y = rect.Top + (rect.Height - result.Height) / 2f;
				return result;
			}
			result = new RectangleF(rect.Left, rect.Top, rect.Height * widthHeightRate, rect.Height);
			result.X = rect.Left + (rect.Width - result.Width) / 2f;
			return result;
		}

		/// <summary>
		///       获得内置矩形
		///       </summary>
		/// <param name="rect">外围的矩形</param>
		/// <param name="Align">水平对齐方式</param>
		/// <param name="LineAlign">垂直对齐方式</param>
		/// <param name="InnerRectSize">内置矩形的大小</param>
		/// <returns>内置矩形</returns>
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

		/// <summary>
		///       返回表示矩形左上点，右上点和右下点坐标的点结构体数组
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含3个元素的点结构体数组</returns>
		public static PointF[] To3Points(RectangleF rect)
		{
			return new PointF[3]
			{
				new PointF(rect.X, rect.Y),
				new PointF(rect.Right, rect.Y),
				new PointF(rect.Right, rect.Bottom)
			};
		}

		/// <summary>
		///       返回表示矩形四个顶点坐标的点结构体数组
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含4个元素的点结构体数组</returns>
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

		/// <summary>
		///       返回表示矩形四个顶点坐标的点结构体数组,并进行闭合
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>包含5个元素的点结构体数组</returns>
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

		/// <summary>
		///       获得正方形
		///       </summary>
		/// <param name="rect">矩形区域</param>
		/// <returns>正方形区域</returns>
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

		/// <summary>
		///       返回浮点数矩形中心坐标
		///       </summary>
		/// <param name="rect">浮点数矩形对象</param>
		/// <returns>矩形中心坐标</returns>
		public static PointF Center(RectangleF rect)
		{
			return new PointF(rect.Left + rect.Width / 2f, rect.Top + rect.Height / 2f);
		}

		/// <summary>
		///       判断指定点是指定的矩形的那个顶点,返回-1:不是顶点 0:为左上点 1:右上点 2:右下点 3:左下点
		///       </summary>
		/// <param name="vRect">矩形对象</param>
		/// <param name="p">点对象</param>
		/// <returns>返回值</returns>
		public static int GetAcmeIndexF(RectangleF vRect, PointF pointF_0)
		{
			if (!vRect.IsEmpty)
			{
				if (pointF_0.Y == vRect.Y)
				{
					if (pointF_0.X == vRect.X)
					{
						return 0;
					}
					if (pointF_0.X == vRect.Right)
					{
						return 1;
					}
				}
				else if (pointF_0.Y == vRect.Bottom)
				{
					if (pointF_0.X == vRect.Right)
					{
						return 2;
					}
					if (pointF_0.X == vRect.X)
					{
						return 3;
					}
				}
			}
			return -1;
		}

		/// <summary>
		///       获得指定矩形指定顶端的坐标,矩形顶点编号为 0:为左上点 1:右上点 2:右下点 3:左下点
		///       </summary>
		/// <param name="vRect">
		/// </param>
		/// <param name="AcmeIndex">
		/// </param>
		/// <returns>
		/// </returns>
		public static PointF GetAcmePos(RectangleF vRect, int AcmeIndex)
		{
			switch (AcmeIndex)
			{
			default:
				return PointF.Empty;
			case 0:
				return vRect.Location;
			case 1:
				return new PointF(vRect.Right, vRect.Y);
			case 2:
				return new PointF(vRect.Right, vRect.Bottom);
			case 3:
				return new PointF(vRect.X, vRect.Bottom);
			}
		}

		/// <summary>
		///       根据两点坐标获得方框对象
		///       </summary>
		/// <param name="x1">
		/// </param>
		/// <param name="y1">
		/// </param>
		/// <param name="x2">
		/// </param>
		/// <param name="y2">
		/// </param>
		/// <returns>
		/// </returns>
		public static RectangleF GetRectangle(float float_0, float float_1, float float_2, float float_3)
		{
			RectangleF empty = RectangleF.Empty;
			if (float_0 < float_2)
			{
				empty.X = float_0;
				empty.Width = float_2 - float_0;
			}
			else
			{
				empty.X = float_2;
				empty.Width = float_0 - float_2;
			}
			if (float_1 < float_3)
			{
				empty.Y = float_1;
				empty.Height = float_3 - float_1;
			}
			else
			{
				empty.Y = float_3;
				empty.Height = float_1 - float_3;
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

		/// <summary>
		///       根据两点坐标获得方框对象
		///       </summary>
		/// <param name="p1">第一个点的坐标</param>
		/// <param name="p2">第二个点的坐标</param>
		/// <returns>
		/// </returns>
		public static RectangleF GetRectangle(PointF pointF_0, PointF pointF_1)
		{
			return GetRectangle(pointF_0.X, pointF_0.Y, pointF_1.X, pointF_1.Y);
		}

		/// <summary>
		///       移动X坐标值到矩形中
		///       </summary>
		/// <param name="x">X坐标值</param>
		/// <param name="Bounds">矩形</param>
		/// <returns>修正后的X坐标值</returns>
		public static float MoveXInto(float float_0, RectangleF Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return float_0;
			}
			if (float_0 < Bounds.Left)
			{
				float_0 = Bounds.Left;
			}
			else if (float_0 > Bounds.Right)
			{
				float_0 = Bounds.Right;
			}
			return float_0;
		}

		/// <summary>
		///       移动Y坐标值到矩形中
		///       </summary>
		/// <param name="y">Y坐标值</param>
		/// <param name="Bounds">矩形</param>
		/// <returns>修正后的Y坐标值</returns>
		public static float MoveYInto(float float_0, RectangleF Bounds)
		{
			if (Bounds.IsEmpty)
			{
				return float_0;
			}
			if (float_0 < Bounds.Top)
			{
				float_0 = Bounds.Top;
			}
			else if (float_0 > Bounds.Bottom)
			{
				float_0 = Bounds.Bottom;
			}
			return float_0;
		}

		/// <summary>
		///       移动一个矩形,致使在指定的矩形中
		///       </summary>
		/// <param name="rect">要修正的矩形</param>
		/// <param name="Bounds">容器矩形</param>
		/// <returns>修正后的矩形</returns>
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

		/// <summary>
		///       将点移动到矩形区域中
		///       </summary>
		/// <param name="p">点坐标</param>
		/// <param name="Bounds">矩形区域</param>
		/// <returns>修正后的点坐标</returns>
		public static PointF MoveInto(PointF pointF_0, RectangleF Bounds)
		{
			if (!Bounds.IsEmpty)
			{
				if (pointF_0.X < Bounds.Left)
				{
					pointF_0.X = Bounds.Left;
				}
				if (pointF_0.X >= Bounds.Right)
				{
					pointF_0.X = Bounds.Right;
				}
				if (pointF_0.Y < Bounds.Top)
				{
					pointF_0.Y = Bounds.Top;
				}
				if (pointF_0.Y >= Bounds.Bottom)
				{
					pointF_0.Y = Bounds.Bottom;
				}
			}
			return pointF_0;
		}

		/// <summary>
		///       获得矩形顶点坐标
		///       </summary>
		/// <param name="intLeft">矩形左端位置</param>
		/// <param name="intTop">矩形顶端位置</param>
		/// <param name="intWidth">矩形宽度</param>
		/// <param name="intHeight">矩形高度</param>
		/// <param name="iPos">顶点序号</param>
		/// <param name="iSplit">矩形边框分割份数</param>
		/// <returns>点坐标</returns>
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
