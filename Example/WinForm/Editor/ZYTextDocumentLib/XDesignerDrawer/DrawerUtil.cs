using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XDesignerCommon;

namespace XDesignerDrawer
{
	internal sealed class DrawerUtil
	{
		public static RectangleF FixClipBounds(Graphics g, float left, float top, float width, float height)
		{
			GraphicsUnit pageUnit = g.PageUnit;
			double num = g.DpiX;
			double num2 = g.DpiY;
			switch (pageUnit)
			{
			case GraphicsUnit.Document:
				num = 300.0;
				num2 = 300.0;
				break;
			case GraphicsUnit.Inch:
				num = 1.0;
				num2 = 1.0;
				break;
			case GraphicsUnit.Millimeter:
				num = 25.4;
				num2 = 25.4;
				break;
			case GraphicsUnit.Point:
				num = 72.0;
				num2 = 72.0;
				break;
			}
			num /= (double)g.DpiX;
			num2 /= (double)g.DpiY;
			double num3 = Math.Ceiling((double)left / num) * num;
			double num4 = Math.Ceiling((double)top / num2) * num2;
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
			if (num4 > (double)top)
			{
				num4 = (double)top - num2;
				if (num6 < (double)height)
				{
					num6 += num2;
				}
				num6 += num2;
			}
			return new RectangleF((float)num3, (float)num4, (float)num5, (float)num6);
		}

		public static Matrix RotateGraphics(Graphics g, Rectangle Bounds, float Angle)
		{
			Matrix transform = g.Transform;
			Matrix matrix = transform.Clone();
			Point point = RectangleCommon.Center(Bounds);
			matrix.RotateAt(Angle, new PointF(point.X, point.Y));
			g.Transform = matrix;
			return transform;
		}

		public static Matrix SwapMatrix(Graphics g, Matrix m)
		{
			Matrix transform = g.Transform;
			g.Transform = m;
			return transform;
		}

		private DrawerUtil()
		{
		}
	}
}
