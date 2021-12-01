using DCSoft.Drawing;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass503
	{
		public static void smethod_0(DCGraphics dcgraphics_0, RectangleF rectangleF_0, Color color_0, RectangleSlantSplitStyle rectangleSlantSplitStyle_0)
		{
			if (rectangleF_0.IsEmpty)
			{
				return;
			}
			PointF[] array = smethod_2(rectangleF_0, rectangleSlantSplitStyle_0);
			if (array != null)
			{
				for (int i = 0; i < array.Length; i += 2)
				{
					dcgraphics_0.DrawLine(color_0, array[i], array[i + 1]);
				}
			}
		}

		public static void smethod_1(DCGraphics dcgraphics_0, RectangleF rectangleF_0, XPenStyle xpenStyle_0, RectangleSlantSplitStyle rectangleSlantSplitStyle_0)
		{
			int num = 18;
			if (rectangleF_0.IsEmpty)
			{
				return;
			}
			if (xpenStyle_0 == null)
			{
				throw new ArgumentNullException("p");
			}
			PointF[] array = smethod_2(rectangleF_0, rectangleSlantSplitStyle_0);
			if (array != null)
			{
				for (int i = 0; i < array.Length; i += 2)
				{
					dcgraphics_0.DrawLine(xpenStyle_0, array[i], array[i + 1]);
				}
			}
		}

		public static PointF[] smethod_2(RectangleF rectangleF_0, RectangleSlantSplitStyle rectangleSlantSplitStyle_0)
		{
			switch (rectangleSlantSplitStyle_0)
			{
			default:
				return null;
			case RectangleSlantSplitStyle.None:
				return null;
			case RectangleSlantSplitStyle.TopLeftOneLine:
				return new PointF[2]
				{
					new PointF(rectangleF_0.Left, rectangleF_0.Top),
					new PointF(rectangleF_0.Right, rectangleF_0.Bottom)
				};
			case RectangleSlantSplitStyle.TopLeftTwoLines:
				return new PointF[4]
				{
					new PointF(rectangleF_0.Left, rectangleF_0.Top),
					new PointF(rectangleF_0.Right, rectangleF_0.Top + rectangleF_0.Height * 0.6f),
					new PointF(rectangleF_0.Left, rectangleF_0.Top),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.7f, rectangleF_0.Bottom)
				};
			case RectangleSlantSplitStyle.TopRightOneLine:
				return new PointF[2]
				{
					new PointF(rectangleF_0.Right, rectangleF_0.Top),
					new PointF(rectangleF_0.Left, rectangleF_0.Bottom)
				};
			case RectangleSlantSplitStyle.TopRightTwoLines:
				return new PointF[4]
				{
					new PointF(rectangleF_0.Right, rectangleF_0.Top),
					new PointF(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height * 0.6f),
					new PointF(rectangleF_0.Right, rectangleF_0.Top),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.3f, rectangleF_0.Bottom)
				};
			case RectangleSlantSplitStyle.BottomRightOneLine:
				return new PointF[2]
				{
					new PointF(rectangleF_0.Right, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Left, rectangleF_0.Top)
				};
			case RectangleSlantSplitStyle.BottomRigthTwoLines:
				return new PointF[4]
				{
					new PointF(rectangleF_0.Right, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.4f, rectangleF_0.Top),
					new PointF(rectangleF_0.Right, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Left, rectangleF_0.Top + rectangleF_0.Height * 0.6f)
				};
			case RectangleSlantSplitStyle.BottomLeftOneLine:
				return new PointF[2]
				{
					new PointF(rectangleF_0.Left, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Right, rectangleF_0.Top)
				};
			case RectangleSlantSplitStyle.BottomLeftTwoLines:
				return new PointF[4]
				{
					new PointF(rectangleF_0.Left, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Right, rectangleF_0.Top + rectangleF_0.Height * 0.4f),
					new PointF(rectangleF_0.Left, rectangleF_0.Bottom),
					new PointF(rectangleF_0.Left + rectangleF_0.Width * 0.7f, rectangleF_0.Top)
				};
			}
		}
	}
}
