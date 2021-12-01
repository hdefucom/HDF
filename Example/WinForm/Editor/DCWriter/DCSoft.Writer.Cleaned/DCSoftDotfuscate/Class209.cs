using System;
using System.Drawing;

namespace DCSoftDotfuscate
{
	internal class Class209
	{
		private static float float_0 = 1f;

		private static void smethod_0(float float_1, float float_2)
		{
			float_0 = float_2 / float_1;
		}

		private static float smethod_1(float float_1)
		{
			return float_1 * float_0;
		}

		private static int smethod_2(int int_0)
		{
			return Convert.ToInt32((float)int_0 * float_0);
		}

		public static Rectangle smethod_3(Rectangle rectangle_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_10(rectangle_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static Size smethod_4(Size size_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_11(size_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static Point smethod_5(Point point_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_12(point_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static RectangleF smethod_6(RectangleF rectangleF_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_13(rectangleF_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static SizeF smethod_7(SizeF sizeF_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_14(sizeF_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static PointF smethod_8(PointF pointF_0, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_15(pointF_0, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static float smethod_9(float float_1, GraphicsUnit graphicsUnit_0, GraphicsUnit graphicsUnit_1)
		{
			return smethod_16(float_1, Class208.smethod_0(graphicsUnit_0), Class208.smethod_0(graphicsUnit_1));
		}

		public static Rectangle smethod_10(Rectangle rectangle_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return Rectangle.FromLTRB(smethod_2(rectangle_0.Left), smethod_2(rectangle_0.Top), smethod_2(rectangle_0.Right), smethod_2(rectangle_0.Bottom));
		}

		public static Size smethod_11(Size size_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return new Size(smethod_2(size_0.Width), smethod_2(size_0.Height));
		}

		public static Point smethod_12(Point point_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return new Point(smethod_2(point_0.X), smethod_2(point_0.Y));
		}

		public static RectangleF smethod_13(RectangleF rectangleF_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return RectangleF.FromLTRB(smethod_1(rectangleF_0.Left), smethod_1(rectangleF_0.Top), smethod_1(rectangleF_0.Right), smethod_1(rectangleF_0.Bottom));
		}

		public static SizeF smethod_14(SizeF sizeF_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return new SizeF(smethod_1(sizeF_0.Width), smethod_1(sizeF_0.Height));
		}

		public static PointF smethod_15(PointF pointF_0, float float_1, float float_2)
		{
			smethod_0(float_1, float_2);
			return new PointF(smethod_1(pointF_0.X), smethod_1(pointF_0.Y));
		}

		public static float smethod_16(float float_1, float float_2, float float_3)
		{
			smethod_0(float_2, float_3);
			return smethod_1(float_1);
		}

		public static RectangleF smethod_17(RectangleF rectangleF_0)
		{
			return smethod_13(rectangleF_0, Class208.float_4, Class208.float_2);
		}

		public static SizeF smethod_18(SizeF sizeF_0)
		{
			return smethod_14(sizeF_0, Class208.float_4, Class208.float_2);
		}

		public static PointF smethod_19(PointF pointF_0)
		{
			return smethod_15(pointF_0, Class208.float_4, Class208.float_2);
		}

		public static float smethod_20(float float_1)
		{
			return smethod_16(float_1, Class208.float_4, Class208.float_2);
		}

		public static RectangleF smethod_21(RectangleF rectangleF_0)
		{
			return smethod_13(rectangleF_0, Class208.float_2, Class208.float_4);
		}

		public static SizeF smethod_22(SizeF sizeF_0)
		{
			return smethod_14(sizeF_0, Class208.float_2, Class208.float_4);
		}

		public static PointF smethod_23(PointF pointF_0)
		{
			return smethod_15(pointF_0, Class208.float_2, Class208.float_4);
		}

		public static float smethod_24(float float_1)
		{
			return smethod_16(float_1, Class208.float_2, Class208.float_4);
		}
	}
}
