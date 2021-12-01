using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class TransformBase
	{
		public virtual bool ContainsSourcePoint(int int_0, int int_1)
		{
			return false;
		}

		public virtual Point TransformPoint(Point point_0)
		{
			return TransformPoint(point_0.X, point_0.Y);
		}

		public virtual Point TransformPoint(int int_0, int int_1)
		{
			return Point.Empty;
		}

		public virtual PointF vmethod_3(PointF pointF_0)
		{
			return TransformPointF(pointF_0.X, pointF_0.Y);
		}

		public virtual PointF TransformPointF(float float_0, float float_1)
		{
			return PointF.Empty;
		}

		public virtual Size vmethod_5(Size size_0)
		{
			return vmethod_6(size_0.Width, size_0.Height);
		}

		public virtual Size vmethod_6(int int_0, int int_1)
		{
			return Size.Empty;
		}

		public virtual SizeF vmethod_7(SizeF sizeF_0)
		{
			return vmethod_8(sizeF_0.Width, sizeF_0.Height);
		}

		public virtual SizeF vmethod_8(float float_0, float float_1)
		{
			return SizeF.Empty;
		}

		public virtual Rectangle vmethod_9(Rectangle rectangle_0)
		{
			return new Rectangle(TransformPoint(rectangle_0.Left, rectangle_0.Top), vmethod_6(rectangle_0.Width, rectangle_0.Height));
		}

		public virtual Rectangle vmethod_10(int int_0, int int_1, int int_2, int int_3)
		{
			return new Rectangle(TransformPoint(int_0, int_1), vmethod_6(int_2, int_3));
		}

		public virtual RectangleF vmethod_11(RectangleF rectangleF_0)
		{
			return new RectangleF(TransformPointF(rectangleF_0.Left, rectangleF_0.Top), vmethod_8(rectangleF_0.Width, rectangleF_0.Height));
		}

		public virtual RectangleF vmethod_12(float float_0, float float_1, float float_2, float float_3)
		{
			return new RectangleF(TransformPointF(float_0, float_1), vmethod_8(float_2, float_3));
		}

		public virtual Point UnTransformPoint(Point point_0)
		{
			return UnTransformPoint(point_0.X, point_0.Y);
		}

		public virtual Point UnTransformPoint(int int_0, int int_1)
		{
			return Point.Empty;
		}

		public virtual PointF vmethod_15(PointF pointF_0)
		{
			return UnTransformPointF(pointF_0.X, pointF_0.Y);
		}

		public virtual PointF UnTransformPointF(float float_0, float float_1)
		{
			return PointF.Empty;
		}

		public virtual Size UnTransformSize(Size size_0)
		{
			return UnTransformSize(size_0.Width, size_0.Height);
		}

		public virtual Size UnTransformSize(int int_0, int int_1)
		{
			return Size.Empty;
		}

		public virtual SizeF vmethod_19(SizeF sizeF_0)
		{
			return vmethod_20(sizeF_0.Width, sizeF_0.Height);
		}

		public virtual SizeF vmethod_20(float float_0, float float_1)
		{
			return SizeF.Empty;
		}

		public virtual Rectangle vmethod_21(Rectangle rectangle_0)
		{
			return new Rectangle(UnTransformPoint(rectangle_0.Location), UnTransformSize(rectangle_0.Size));
		}

		public virtual Rectangle vmethod_22(int int_0, int int_1, int int_2, int int_3)
		{
			return new Rectangle(UnTransformPoint(int_0, int_1), UnTransformSize(int_2, int_3));
		}

		public virtual RectangleF vmethod_23(RectangleF rectangleF_0)
		{
			return new RectangleF(vmethod_15(rectangleF_0.Location), vmethod_19(rectangleF_0.Size));
		}

		public virtual RectangleF vmethod_24(float float_0, float float_1, float float_2, float float_3)
		{
			return new RectangleF(UnTransformPointF(float_0, float_1), vmethod_20(float_2, float_3));
		}
	}
}
