using System.Drawing;

namespace XDesignerGUI
{
	public class SimpleRectangleTransform : TransformBase
	{
		private bool bolEnable = true;

		private bool bolVisible = true;

		private object objTag = null;

		private int intPageIndex = 0;

		private int intFlag2 = 0;

		private int intFlag3 = 0;

		protected RectangleF mySourceRect = RectangleF.Empty;

		protected RectangleF myDescRect = RectangleF.Empty;

		public bool Enable
		{
			get
			{
				return bolEnable;
			}
			set
			{
				bolEnable = value;
			}
		}

		public bool Visible
		{
			get
			{
				return bolVisible;
			}
			set
			{
				bolVisible = value;
			}
		}

		public object Tag
		{
			get
			{
				return objTag;
			}
			set
			{
				objTag = value;
			}
		}

		public int PageIndex
		{
			get
			{
				return intPageIndex;
			}
			set
			{
				intPageIndex = value;
			}
		}

		public int Flag2
		{
			get
			{
				return intFlag2;
			}
			set
			{
				intFlag2 = value;
			}
		}

		public int Flag3
		{
			get
			{
				return intFlag3;
			}
			set
			{
				intFlag3 = value;
			}
		}

		public RectangleF SourceRectF
		{
			get
			{
				return mySourceRect;
			}
			set
			{
				mySourceRect = value;
			}
		}

		public Rectangle SourceRect
		{
			get
			{
				return new Rectangle((int)mySourceRect.Left, (int)mySourceRect.Top, (int)mySourceRect.Width, (int)mySourceRect.Height);
			}
			set
			{
				mySourceRect = new RectangleF(value.Left, value.Top, value.Width, value.Height);
			}
		}

		public RectangleF DescRectF
		{
			get
			{
				return myDescRect;
			}
			set
			{
				myDescRect = value;
			}
		}

		public Rectangle DescRect
		{
			get
			{
				return new Rectangle((int)myDescRect.Left, (int)myDescRect.Top, (int)myDescRect.Width, (int)myDescRect.Height);
			}
			set
			{
				myDescRect = new RectangleF(value.Left, value.Top, value.Width, value.Height);
			}
		}

		public Point OffsetPosition => new Point((int)(myDescRect.Left - mySourceRect.Left), (int)(myDescRect.Top - mySourceRect.Top));

		public PointF OffsetPositionF => new PointF(myDescRect.Left - mySourceRect.Left, myDescRect.Top - mySourceRect.Top);

		public float XZoomRate
		{
			get
			{
				float width = myDescRect.Width;
				return width / mySourceRect.Width;
			}
		}

		public float YZoomRate
		{
			get
			{
				float height = myDescRect.Height;
				return height / mySourceRect.Height;
			}
		}

		public SimpleRectangleTransform()
		{
		}

		public SimpleRectangleTransform(RectangleF vSourceRect, RectangleF vDescRect)
		{
			mySourceRect = vSourceRect;
			myDescRect = vDescRect;
		}

		public override bool ContainsSourcePoint(int x, int y)
		{
			return mySourceRect.Contains(x, y);
		}

		public override Point TransformPoint(int x, int y)
		{
			PointF pointF = TransformPointF(x, y);
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		public override PointF TransformPointF(float x, float y)
		{
			x -= mySourceRect.Left;
			y -= mySourceRect.Top;
			if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0f)
			{
				x = x * myDescRect.Width / mySourceRect.Width;
			}
			if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0f)
			{
				y = y * myDescRect.Height / mySourceRect.Height;
			}
			return new PointF(x + (float)DescRect.Left, y + (float)DescRect.Top);
		}

		public override Size TransformSize(int w, int h)
		{
			if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0f)
			{
				w = (int)((float)w * myDescRect.Width / mySourceRect.Width);
			}
			if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0f)
			{
				h = (int)((float)h * myDescRect.Height / mySourceRect.Height);
			}
			return new Size(w, h);
		}

		public override SizeF TransformSizeF(float w, float h)
		{
			if (mySourceRect.Width != myDescRect.Width && mySourceRect.Width != 0f)
			{
				w = w * myDescRect.Width / mySourceRect.Width;
			}
			if (mySourceRect.Height != myDescRect.Height && mySourceRect.Height != 0f)
			{
				h = h * myDescRect.Height / mySourceRect.Height;
			}
			return new SizeF(w, h);
		}

		public override Point UnTransformPoint(Point p)
		{
			PointF pointF = UnTransformPointF(p.X, p.Y);
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		public override Point UnTransformPoint(int x, int y)
		{
			PointF pointF = UnTransformPointF(x, y);
			return new Point((int)pointF.X, (int)pointF.Y);
		}

		public override PointF UnTransformPointF(float x, float y)
		{
			x -= (float)DescRect.Left;
			y -= (float)DescRect.Top;
			if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0f)
			{
				x = x * mySourceRect.Width / myDescRect.Width;
			}
			if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0f)
			{
				y = y * mySourceRect.Height / myDescRect.Height;
			}
			return new PointF(x + (float)SourceRect.Left, y + (float)SourceRect.Top);
		}

		public override Size UnTransformSize(int w, int h)
		{
			if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0f)
			{
				w = (int)((float)w * mySourceRect.Width / myDescRect.Width);
			}
			if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0f)
			{
				h = (int)((float)h * mySourceRect.Height / myDescRect.Height);
			}
			return new Size(w, h);
		}

		public override SizeF UnTransformSizeF(float w, float h)
		{
			if (mySourceRect.Width != myDescRect.Width && myDescRect.Width != 0f)
			{
				w = w * mySourceRect.Width / myDescRect.Width;
			}
			if (mySourceRect.Height != myDescRect.Height && myDescRect.Height != 0f)
			{
				h = h * mySourceRect.Height / myDescRect.Height;
			}
			return new SizeF(w, h);
		}
	}
}
