using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Drawing
{
	/// <summary>
	///       DrawerUtil 的摘要说明。
	///       </summary>
	[ComVisible(false)]
	public sealed class DrawerUtil
	{
		private static Pen mySelectionPen = null;

		private static Pen myCurrentSelectionPen = null;

		public static void DrawUnderLine(DCGraphics dcgraphics_0, TextUnderlineStyle style, Color color_0, float float_0, float float_1, float float_2, float float_3, float distance)
		{
			switch (style)
			{
			case TextUnderlineStyle.None:
				break;
			case TextUnderlineStyle.Single:
				dcgraphics_0.DrawLine(color_0, float_0, float_1, float_2, float_3);
				break;
			case TextUnderlineStyle.Thick:
			{
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.Width = GraphicsUnitConvert.Convert(2f, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				dcgraphics_0.DrawLine(xPenStyle, float_0, float_1, float_2, float_3);
				break;
			}
			case TextUnderlineStyle.Dash:
			{
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.DashStyle = DashStyle.Dash;
				dcgraphics_0.DrawLine(xPenStyle, float_0, float_1, float_2, float_3);
				break;
			}
			case TextUnderlineStyle.Dot:
			{
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.DashStyle = DashStyle.Dot;
				dcgraphics_0.DrawLine(xPenStyle, float_0, float_1, float_2, float_3);
				break;
			}
			case TextUnderlineStyle.DashDot:
			{
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.DashStyle = DashStyle.DashDot;
				dcgraphics_0.DrawLine(xPenStyle, float_0, float_1, float_2, float_3);
				break;
			}
			case TextUnderlineStyle.DashDotDot:
			{
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.DashStyle = DashStyle.DashDotDot;
				dcgraphics_0.DrawLine(xPenStyle, float_0, float_1, float_2, float_3);
				break;
			}
			case TextUnderlineStyle.Double:
				dcgraphics_0.DrawLine(color_0, float_0, float_1, float_2, float_3);
				dcgraphics_0.DrawLine(color_0, float_0, float_1 + distance, float_2, float_3 + distance);
				break;
			case TextUnderlineStyle.Wavy:
			{
				List<PointF> list = CreateWavyPoints(float_0, float_1, float_2, float_3, distance);
				dcgraphics_0.DrawLines(color_0, list.ToArray());
				break;
			}
			case TextUnderlineStyle.WavyDouble:
			{
				List<PointF> list = CreateWavyPoints(float_0, float_1, float_2, float_3, distance);
				dcgraphics_0.DrawLines(color_0, list.ToArray());
				list = CreateWavyPoints(float_0, float_1 + distance, float_2, float_3 + distance, distance);
				dcgraphics_0.DrawLines(color_0, list.ToArray());
				break;
			}
			case TextUnderlineStyle.WavyHeavy:
			{
				List<PointF> list = CreateWavyPoints(float_0, float_1, float_2, float_3, distance);
				XPenStyle xPenStyle = new XPenStyle(color_0);
				xPenStyle.Width = GraphicsUnitConvert.Convert(2f, GraphicsUnit.Pixel, dcgraphics_0.PageUnit);
				dcgraphics_0.DrawLines(xPenStyle, list.ToArray());
				break;
			}
			}
		}

		private static List<PointF> CreateWavyPoints(float float_0, float float_1, float float_2, float float_3, float size)
		{
			bool flag = false;
			List<PointF> list = new List<PointF>();
			if (float_0 > float_2)
			{
				float num = float_2;
				float_2 = float_0;
				float_0 = num;
			}
			if (float_1 > float_3)
			{
				float num = float_3;
				float_3 = float_1;
				float_1 = num;
			}
			float num2 = Math.Abs(size);
			if (float_1 == float_3)
			{
				double num3 = Math.Abs(Math.IEEERemainder(float_0, size) / (double)size);
				if (num3 < 0.5)
				{
					flag = !flag;
				}
				for (float num4 = float_0; num4 <= float_2; num4 += num2)
				{
					if (flag = !flag)
					{
						list.Add(new PointF(num4, float_1));
					}
					else
					{
						list.Add(new PointF(num4, float_1 + size));
					}
				}
			}
			else if (float_0 == float_2)
			{
				for (float num4 = float_1; num4 <= float_3; num4 += num2)
				{
					if (flag = !flag)
					{
						list.Add(new PointF(float_0, num4));
					}
					else
					{
						list.Add(new PointF(float_0 + size, num4));
					}
				}
			}
			return list;
		}

		/// <summary>
		///       创建控件内容位图对象
		///       </summary>
		/// <param name="ctl">控件对象</param>
		/// <param name="fastMode">快速模式</param>
		/// <returns>生成的位图对象</returns>
		public static Bitmap CreateControlContentBmp(Control control_0, bool fastMode)
		{
			int num = 4;
			if (control_0 == null)
			{
				throw new ArgumentNullException("ctl");
			}
			if (control_0.IsDisposed)
			{
				throw new ObjectDisposedException("ctl");
			}
			if (!control_0.IsHandleCreated)
			{
				return null;
			}
			Bitmap bitmap = new Bitmap(control_0.ClientSize.Width, control_0.ClientSize.Height);
			if (fastMode && control_0.Visible)
			{
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					Point upperLeftSource = control_0.PointToScreen(new Point(0, 0));
					graphics.CopyFromScreen(upperLeftSource, new Point(0, 0), control_0.ClientSize);
				}
			}
			else
			{
				control_0.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
			}
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, Color.Gray)))
				{
					graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);
				}
			}
			return bitmap;
		}

		/// <summary>
		///       创建空白图片
		///       </summary>
		/// <param name="color">颜色值</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>创建的空白图片</returns>
		public static Bitmap CreateBlankBmp(Color color, int width, int height)
		{
			int num = 4;
			if (width <= 0)
			{
				throw new ArgumentOutOfRangeException("width=" + width);
			}
			if (height <= 0)
			{
				throw new ArgumentOutOfRangeException("height=" + height);
			}
			Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(color);
			}
			return bitmap;
		}

		public static RectangleF DrawImageCenterAutoZoom(Graphics graphics_0, RectangleF bounds, Image image_0)
		{
			int num = 8;
			if (graphics_0 == null)
			{
				throw new ArgumentNullException("g");
			}
			if (bounds.IsEmpty)
			{
				return RectangleF.Empty;
			}
			if (image_0 == null)
			{
				throw new ArgumentNullException("img");
			}
			SizeF size = new SizeF(image_0.Width, image_0.Height);
			size = GraphicsUnitConvert.Convert(size, GraphicsUnit.Pixel, graphics_0.PageUnit);
			if (size.Width <= bounds.Width && size.Height <= bounds.Height)
			{
				Rectangle rectangle = new Rectangle((int)(bounds.Left + (bounds.Width - size.Width) / 2f), (int)(bounds.Top + (bounds.Height - size.Height) / 2f), (int)size.Width, (int)size.Height);
				graphics_0.DrawImageUnscaled(image_0, rectangle);
				return rectangle;
			}
			float num2;
			RectangleF rectangleF;
			if (size.Width / size.Height > bounds.Width / bounds.Height)
			{
				num2 = bounds.Width / size.Width;
				rectangleF = new RectangleF(bounds.Left, bounds.Top + (bounds.Height - size.Height * num2) / 2f, bounds.Width, size.Height * num2);
				graphics_0.DrawImage(image_0, rectangleF);
				return rectangleF;
			}
			num2 = bounds.Height / size.Height;
			rectangleF = new RectangleF(bounds.Left + (bounds.Width - size.Width * num2) / 2f, bounds.Top, size.Width * num2, bounds.Height);
			graphics_0.DrawImage(image_0, rectangleF);
			return rectangleF;
		}

		/// <summary>
		///       判断是否为页眉页脚样式
		///       </summary>
		/// <param name="style">
		/// </param>
		/// <returns>
		/// </returns>
		public static bool IsHeaderFooter(PageContentPartyStyle style)
		{
			return style == PageContentPartyStyle.Header || style == PageContentPartyStyle.HeaderForFirstPage || style == PageContentPartyStyle.Footer || style == PageContentPartyStyle.FooterForFirstPage;
		}

		/// <summary>
		///       绘制调试用的矩形
		///       </summary>
		/// <param name="g">画布对象</param>
		/// <param name="rect">边界</param>
		/// <param name="color">画笔颜色</param>
		public static void DrawDebugRectangle(Graphics graphics_0, RectangleF rect, Color color)
		{
			using (Pen pen = new Pen(color))
			{
				graphics_0.DrawRectangle(pen, rect.Left, rect.Top, rect.Width, rect.Height);
				graphics_0.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Bottom);
				graphics_0.DrawLine(pen, rect.Right, rect.Top, rect.Left, rect.Bottom);
			}
		}

		/// <summary>
		///       设置字符串格式为多行文本
		///       </summary>
		/// <param name="format">字符串格式化对象</param>
		/// <param name="multiLine">是否多行文本</param>
		public static void SetMultiLine(StringFormat format, bool multiLine)
		{
			int num = 8;
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			if (multiLine)
			{
				format.FormatFlags &= ~StringFormatFlags.NoWrap;
			}
			else
			{
				format.FormatFlags |= StringFormatFlags.NoWrap;
			}
		}

		public static void DrawImage(DCGraphics dcgraphics_0, Image image_0, RectangleF bounds, RectangleF clipRectangle)
		{
			RectangleF rectangleF = RectangleF.Intersect(bounds, clipRectangle);
			PointF location = rectangleF.Location;
			rectangleF.X -= bounds.X;
			rectangleF.Y -= bounds.Y;
			RectangleF rectangleF2 = new RectangleF(0f, 0f, image_0.Width, image_0.Height);
			RectangleF sourceRect = new RectangleF((float)Math.Round(rectangleF2.Width * rectangleF.X / bounds.Width, 3), (float)Math.Round(rectangleF2.Height * rectangleF.Y / bounds.Height, 3), (float)Math.Round(rectangleF2.Width * rectangleF.Width / bounds.Width, 3), (float)Math.Round(rectangleF2.Height * rectangleF.Height / bounds.Height, 3));
			rectangleF.Location = location;
			if (sourceRect.Left == 0f && sourceRect.Top == 0f && sourceRect.Width == (float)image_0.Width && sourceRect.Height == (float)image_0.Height)
			{
				dcgraphics_0.DrawImage(image_0, rectangleF);
			}
			else
			{
				dcgraphics_0.DrawImage(image_0, rectangleF, sourceRect, GraphicsUnit.Pixel);
			}
		}

		public static Pen GetSelectionPen(float width, bool IsCurrent)
		{
			if (IsCurrent)
			{
				if (myCurrentSelectionPen == null || myCurrentSelectionPen.Width != width)
				{
					if (myCurrentSelectionPen != null)
					{
						myCurrentSelectionPen.Dispose();
					}
					HatchBrush brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Blue, Color.Transparent);
					myCurrentSelectionPen = new Pen(brush, width);
				}
				return myCurrentSelectionPen;
			}
			if (mySelectionPen == null || mySelectionPen.Width != width)
			{
				if (mySelectionPen != null)
				{
					mySelectionPen.Dispose();
				}
				HatchBrush brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Black, Color.Transparent);
				mySelectionPen = new Pen(brush, width);
			}
			return mySelectionPen;
		}

		public static Pen CreateSelectionPen(float width, bool IsCurrent)
		{
			HatchBrush brush;
			if (IsCurrent)
			{
				brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Blue, Color.Transparent);
				return new Pen(brush, width);
			}
			brush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Black, Color.Transparent);
			return new Pen(brush, width);
		}

		public static void DrawImageUnscaledNearestNeighbor(Graphics graphics_0, Image image_0, RectangleF bounds, ContentAlignment align)
		{
			RectangleF rectangleF = RectangleCommon.AlignRect(bounds, GraphicsUnitConvert.Convert(image_0.Width, GraphicsUnit.Pixel, graphics_0.PageUnit), GraphicsUnitConvert.Convert(image_0.Height, GraphicsUnit.Pixel, graphics_0.PageUnit), align);
			InterpolationMode interpolationMode = graphics_0.InterpolationMode;
			PixelOffsetMode pixelOffsetMode = graphics_0.PixelOffsetMode;
			graphics_0.InterpolationMode = InterpolationMode.NearestNeighbor;
			graphics_0.PixelOffsetMode = PixelOffsetMode.Half;
			graphics_0.DrawImageUnscaled(image_0, (int)rectangleF.Left, (int)rectangleF.Top);
			graphics_0.InterpolationMode = interpolationMode;
			graphics_0.PixelOffsetMode = pixelOffsetMode;
		}

		public static void DrawImageUnscaledNearestNeighbor(DCGraphics dcgraphics_0, Image image_0, RectangleF bounds, ContentAlignment align)
		{
			RectangleF rectangleF = RectangleCommon.AlignRect(bounds, GraphicsUnitConvert.Convert(image_0.Width, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), GraphicsUnitConvert.Convert(image_0.Height, GraphicsUnit.Pixel, dcgraphics_0.PageUnit), align);
			InterpolationMode interpolationMode = dcgraphics_0.InterpolationMode;
			PixelOffsetMode pixelOffsetMode = dcgraphics_0.PixelOffsetMode;
			dcgraphics_0.InterpolationMode = InterpolationMode.NearestNeighbor;
			dcgraphics_0.PixelOffsetMode = PixelOffsetMode.Half;
			dcgraphics_0.DrawImageUnscaled(image_0, (int)rectangleF.Left, (int)rectangleF.Top);
			dcgraphics_0.InterpolationMode = interpolationMode;
			dcgraphics_0.PixelOffsetMode = pixelOffsetMode;
		}

		public static void DrawImageUnscaledNearestNeighbor(DCGraphics dcgraphics_0, Image image_0, int int_0, int int_1)
		{
			InterpolationMode interpolationMode = dcgraphics_0.InterpolationMode;
			PixelOffsetMode pixelOffsetMode = dcgraphics_0.PixelOffsetMode;
			dcgraphics_0.InterpolationMode = InterpolationMode.NearestNeighbor;
			dcgraphics_0.PixelOffsetMode = PixelOffsetMode.Half;
			dcgraphics_0.DrawImageUnscaled(image_0, int_0, int_1);
			dcgraphics_0.InterpolationMode = interpolationMode;
			dcgraphics_0.PixelOffsetMode = pixelOffsetMode;
		}

		public static void DrawImageNearestNeighbor(DCGraphics dcgraphics_0, Image image_0, RectangleF bounds)
		{
			InterpolationMode interpolationMode = dcgraphics_0.InterpolationMode;
			PixelOffsetMode pixelOffsetMode = dcgraphics_0.PixelOffsetMode;
			dcgraphics_0.InterpolationMode = InterpolationMode.NearestNeighbor;
			dcgraphics_0.PixelOffsetMode = PixelOffsetMode.Half;
			dcgraphics_0.DrawImage(image_0, bounds, new Rectangle(0, 0, image_0.Width, image_0.Height), GraphicsUnit.Pixel);
			dcgraphics_0.InterpolationMode = interpolationMode;
			dcgraphics_0.PixelOffsetMode = pixelOffsetMode;
		}

		public static GraphicsPath CreateRoundRectangle(RectangleF rect, float radio)
		{
			return ShapeDrawer.CreateRoundRectanglePath(rect, radio);
		}

		public static void SetStringFormatAlignment(StringFormat format, ContentAlignment alignment)
		{
			int num = 11;
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			switch (alignment)
			{
			case ContentAlignment.MiddleCenter:
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Center;
				break;
			case ContentAlignment.MiddleLeft:
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Center;
				break;
			case ContentAlignment.TopLeft:
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Near;
				break;
			case ContentAlignment.TopCenter:
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Near;
				break;
			case ContentAlignment.TopRight:
				format.Alignment = StringAlignment.Far;
				format.LineAlignment = StringAlignment.Near;
				break;
			case ContentAlignment.BottomLeft:
				format.Alignment = StringAlignment.Near;
				format.LineAlignment = StringAlignment.Far;
				break;
			case ContentAlignment.MiddleRight:
				format.Alignment = StringAlignment.Far;
				format.LineAlignment = StringAlignment.Center;
				break;
			case ContentAlignment.BottomRight:
				format.Alignment = StringAlignment.Far;
				format.LineAlignment = StringAlignment.Far;
				break;
			case ContentAlignment.BottomCenter:
				format.Alignment = StringAlignment.Center;
				format.LineAlignment = StringAlignment.Far;
				break;
			}
		}

		/// <summary>
		///       修正剪切矩形
		///       </summary>
		/// <param name="g">
		/// </param>
		/// <param name="left">
		/// </param>
		/// <param name="top">
		/// </param>
		/// <param name="width">
		/// </param>
		/// <param name="height">
		/// </param>
		/// <returns>
		/// </returns>
		public static RectangleF FixClipBounds(Graphics graphics_0, float left, float float_0, float width, float height)
		{
			GraphicsUnit pageUnit = graphics_0.PageUnit;
			double num = graphics_0.DpiX;
			double num2 = graphics_0.DpiY;
			switch (pageUnit)
			{
			case GraphicsUnit.Point:
				num = 72.0;
				num2 = 72.0;
				break;
			case GraphicsUnit.Inch:
				num = 1.0;
				num2 = 1.0;
				break;
			case GraphicsUnit.Document:
				num = 300.0;
				num2 = 300.0;
				break;
			case GraphicsUnit.Millimeter:
				num = 25.4;
				num2 = 25.4;
				break;
			}
			num /= (double)graphics_0.DpiX;
			num2 /= (double)graphics_0.DpiY;
			double num3 = Math.Ceiling((double)left / num) * num;
			double num4 = Math.Ceiling((double)float_0 / num2) * num2;
			double num5 = Math.Ceiling((double)width / num) * num;
			double num6 = Math.Ceiling((double)height / num2) * num2;
			if (num3 > (double)left)
			{
				num3 -= num;
				if (num5 < (double)width)
				{
					num5 += num;
				}
				num5 += num;
			}
			if (num4 > (double)float_0)
			{
				num4 = (double)float_0 - num2;
				if (num6 < (double)height)
				{
					num6 += num2;
				}
				num6 += num2;
			}
			return new RectangleF((float)num3, (float)num4, (float)num5, (float)num6);
		}

		/// <summary>
		///       旋转画布
		///       </summary>
		/// <param name="g">画布对象</param>
		/// <param name="Bounds">区域</param>
		/// <param name="Angle">旋转角度</param>
		/// <returns>旋转后的矩阵对象</returns>
		public static Matrix RotateGraphics(Graphics graphics_0, Rectangle Bounds, float Angle)
		{
			Matrix transform = graphics_0.Transform;
			Matrix matrix = transform.Clone();
			Point point = new Point(Bounds.Left + Bounds.Width / 2, Bounds.Top + Bounds.Height / 2);
			matrix.RotateAt(Angle, new PointF(point.X, point.Y));
			graphics_0.Transform = matrix;
			return transform;
		}

		/// <summary>
		///       交换矩阵
		///       </summary>
		/// <param name="g">
		/// </param>
		/// <param name="m">
		/// </param>
		/// <returns>
		/// </returns>
		public static Matrix SwapMatrix(Graphics graphics_0, Matrix matrix_0)
		{
			Matrix transform = graphics_0.Transform;
			graphics_0.Transform = matrix_0;
			return transform;
		}

		/// <summary>
		///       进行矩形区域4个顶点的坐标转换
		///       </summary>
		/// <param name="m">
		/// </param>
		/// <param name="rect">
		/// </param>
		/// <returns>
		/// </returns>
		public static PointF[] TransformRectangle(Matrix matrix_0, RectangleF rect)
		{
			PointF[] array = new PointF[5]
			{
				new PointF(rect.Left, rect.Top),
				new PointF(rect.Right, rect.Top),
				new PointF(rect.Right, rect.Bottom),
				new PointF(rect.Left, rect.Bottom),
				new PointF(rect.Left, rect.Top)
			};
			matrix_0.TransformPoints(array);
			return array;
		}

		private DrawerUtil()
		{
		}
	}
}
