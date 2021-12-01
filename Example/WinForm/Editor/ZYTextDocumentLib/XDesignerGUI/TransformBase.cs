using System.Drawing;

namespace XDesignerGUI
{
	public abstract class TransformBase
	{
		public virtual bool ContainsSourcePoint(int x, int y)
		{
			return false;
		}

		public virtual Point TransformPoint(Point p)
		{
			return TransformPoint(p.X, p.Y);
		}

		public virtual Point TransformPoint(int x, int y)
		{
			return Point.Empty;
		}

		public virtual PointF TransformPointF(PointF p)
		{
			return TransformPointF(p.X, p.Y);
		}

		public virtual PointF TransformPointF(float x, float y)
		{
			return PointF.Empty;
		}

		public virtual Size TransformSize(Size vSize)
		{
			return TransformSize(vSize.Width, vSize.Height);
		}

		public virtual Size TransformSize(int w, int h)
		{
			return Size.Empty;
		}

		public virtual SizeF TransformSizeF(SizeF vSize)
		{
			return TransformSizeF(vSize.Width, vSize.Height);
		}

		public virtual SizeF TransformSizeF(float w, float h)
		{
			return SizeF.Empty;
		}

		public virtual Rectangle TransformRectangle(Rectangle rect)
		{
			return new Rectangle(TransformPoint(rect.Left, rect.Top), TransformSize(rect.Width, rect.Height));
		}

		public virtual Rectangle TransformRectangle(int left, int top, int width, int height)
		{
			return new Rectangle(TransformPoint(left, top), TransformSize(width, height));
		}

		public virtual RectangleF TransformRectangleF(RectangleF rect)
		{
			return new RectangleF(TransformPointF(rect.Left, rect.Top), TransformSizeF(rect.Width, rect.Height));
		}

		public virtual RectangleF TransformRectangleF(float left, float top, float width, float height)
		{
			return new RectangleF(TransformPointF(left, top), TransformSizeF(width, height));
		}

		public virtual Point UnTransformPoint(Point p)
		{
			return UnTransformPoint(p.X, p.Y);
		}

		public virtual Point UnTransformPoint(int x, int y)
		{
			return Point.Empty;
		}

		public virtual PointF UnTransformPointF(PointF p)
		{
			return UnTransformPointF(p.X, p.Y);
		}

		public virtual PointF UnTransformPointF(float x, float y)
		{
			return PointF.Empty;
		}

		public virtual Size UnTransformSize(Size vSize)
		{
			return UnTransformSize(vSize.Width, vSize.Height);
		}

		public virtual Size UnTransformSize(int w, int h)
		{
			return Size.Empty;
		}

		public virtual SizeF UnTransformSizeF(SizeF vSize)
		{
			return UnTransformSizeF(vSize.Width, vSize.Height);
		}

		public virtual SizeF UnTransformSizeF(float w, float h)
		{
			return SizeF.Empty;
		}

		public virtual Rectangle UnTransformRectangle(Rectangle rect)
		{
			return new Rectangle(UnTransformPoint(rect.Location), UnTransformSize(rect.Size));
		}

		public virtual Rectangle UnTransformRectangle(int left, int top, int width, int height)
		{
			return new Rectangle(UnTransformPoint(left, top), UnTransformSize(width, height));
		}

		public virtual RectangleF UnTransformRectangleF(RectangleF rect)
		{
			return new RectangleF(UnTransformPointF(rect.Location), UnTransformSizeF(rect.Size));
		}

		public virtual RectangleF UnTransformRectangleF(float left, float top, float width, float height)
		{
			return new RectangleF(UnTransformPointF(left, top), UnTransformSizeF(width, height));
		}
	}
}
