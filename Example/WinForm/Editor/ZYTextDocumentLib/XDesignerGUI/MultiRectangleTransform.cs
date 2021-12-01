using System;
using System.Collections;
using System.Drawing;

namespace XDesignerGUI
{
	public class MultiRectangleTransform : TransformBase, ICollection, IEnumerable
	{
		protected ArrayList myItems = new ArrayList();

		protected double dblRate = 1.0;

		protected Point mySourceOffsetBack = Point.Empty;

		protected SimpleRectangleTransform myCurrentItem = null;

		public double Rate
		{
			get
			{
				return dblRate;
			}
			set
			{
				dblRate = value;
			}
		}

		public Rectangle SourceBounds
		{
			get
			{
				Rectangle rectangle = Rectangle.Empty;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
						rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(rectangle, simpleRectangleTransform.SourceRect) : simpleRectangleTransform.SourceRect);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return rectangle;
			}
		}

		public Rectangle DescBounds
		{
			get
			{
				Rectangle rectangle = Rectangle.Empty;
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
						rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(rectangle, simpleRectangleTransform.DescRect) : simpleRectangleTransform.DescRect);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return rectangle;
			}
		}

		public SimpleRectangleTransform this[int index] => (SimpleRectangleTransform)myItems[index];

		public SimpleRectangleTransform this[Rectangle rect]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
						if (simpleRectangleTransform.SourceRect.Equals(rect))
						{
							return simpleRectangleTransform;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		public SimpleRectangleTransform this[int x, int y]
		{
			get
			{
				IEnumerator enumerator = GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
						if (simpleRectangleTransform.SourceRect.Contains(x, y) && simpleRectangleTransform.Enable)
						{
							return simpleRectangleTransform;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return null;
			}
		}

		public SimpleRectangleTransform this[Point p] => this[p.X, p.Y];

		public SimpleRectangleTransform CurrentItem => myCurrentItem;

		public bool IsSynchronized => myItems.IsSynchronized;

		public int Count => myItems.Count;

		public object SyncRoot => myItems.SyncRoot;

		public void OffsetSource(int dx, int dy, bool Remark)
		{
			if (Remark)
			{
				mySourceOffsetBack.Offset(dx, dy);
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					Rectangle sourceRect = simpleRectangleTransform.SourceRect;
					sourceRect.Offset(dx, dy);
					simpleRectangleTransform.SourceRect = sourceRect;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void ClearSourceOffset()
		{
			if (!mySourceOffsetBack.IsEmpty)
			{
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
							Rectangle sourceRect = simpleRectangleTransform.SourceRect;
							sourceRect.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);
							simpleRectangleTransform.SourceRect = sourceRect;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			mySourceOffsetBack = Point.Empty;
		}

		public int Add(SimpleRectangleTransform item)
		{
			return myItems.Add(item);
		}

		public SimpleRectangleTransform Add(Rectangle SourceRect, Rectangle DescRect)
		{
			SimpleRectangleTransform simpleRectangleTransform = new SimpleRectangleTransform(SourceRect, DescRect);
			myItems.Add(simpleRectangleTransform);
			return simpleRectangleTransform;
		}

		public SimpleRectangleTransform Add(int SourceLeft, int SourceTop, int SourceWidth, int SourceHeight, int DescLeft, int DescTop, int DescWidth, int DescHeight)
		{
			SimpleRectangleTransform simpleRectangleTransform = new SimpleRectangleTransform(new Rectangle(SourceLeft, SourceTop, SourceWidth, SourceHeight), new Rectangle(DescLeft, DescTop, DescWidth, DescHeight));
			myItems.Add(simpleRectangleTransform);
			return simpleRectangleTransform;
		}

		public override bool ContainsSourcePoint(int x, int y)
		{
			return this[x, y] != null;
		}

		public bool Contains(Point p)
		{
			return this[p.X, p.Y] != null;
		}

		public int TransformY(int y)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.Enable)
					{
						Rectangle sourceRect = simpleRectangleTransform.SourceRect;
						if (y >= sourceRect.Top && y <= sourceRect.Bottom)
						{
							return simpleRectangleTransform.TransformPoint(sourceRect.Left, y).Y;
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return y;
		}

		public int UnTransformY(int y)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.Enable)
					{
						Rectangle descRect = simpleRectangleTransform.DescRect;
						if (y >= descRect.Top && y <= descRect.Bottom)
						{
							return simpleRectangleTransform.UnTransformPoint(simpleRectangleTransform.DescRect.Left, y).Y;
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return 0;
		}

		public Point Transform(Point p)
		{
			return TransformPoint(p.X, p.Y);
		}

		public override Point TransformPoint(int x, int y)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.Enable && simpleRectangleTransform.SourceRect.Contains(x, y))
					{
						return simpleRectangleTransform.TransformPoint(x, y);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return Point.Empty;
		}

		public override Size TransformSize(int w, int h)
		{
			return new Size((int)((double)w * dblRate), (int)((double)h * dblRate));
		}

		public override Size TransformSize(Size vSize)
		{
			return new Size((int)((double)vSize.Width * dblRate), (int)((double)vSize.Height * dblRate));
		}

		public override SizeF TransformSizeF(float w, float h)
		{
			return new SizeF((float)((double)w * dblRate), (float)((double)h * dblRate));
		}

		public override SizeF TransformSizeF(SizeF vSize)
		{
			return new SizeF((float)((double)vSize.Width * dblRate), (float)((double)vSize.Height * dblRate));
		}

		public override Point UnTransformPoint(int x, int y)
		{
			Point result = Point.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.Enable && simpleRectangleTransform.DescRect.Contains(x, y))
					{
						result = simpleRectangleTransform.UnTransformPoint(x, y);
						return result;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}

		public override PointF TransformPointF(float x, float y)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.SourceRectF.Contains(x, y) && simpleRectangleTransform.Enable)
					{
						return simpleRectangleTransform.TransformPointF(x, y);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return new PointF(x, y);
		}

		public override PointF UnTransformPointF(float x, float y)
		{
			PointF result = PointF.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform simpleRectangleTransform = (SimpleRectangleTransform)enumerator.Current;
					if (simpleRectangleTransform.DescRectF.Contains(x, y) && simpleRectangleTransform.Enable)
					{
						result = simpleRectangleTransform.UnTransformPointF(x, y);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}

		public override Size UnTransformSize(int w, int h)
		{
			return new Size((int)((double)w / dblRate), (int)((double)h / dblRate));
		}

		public override Size UnTransformSize(Size vSize)
		{
			return new Size((int)((double)vSize.Width / dblRate), (int)((double)vSize.Height / dblRate));
		}

		public override SizeF UnTransformSizeF(float w, float h)
		{
			return new SizeF((float)((double)w / dblRate), (float)((double)h / dblRate));
		}

		public override SizeF UnTransformSizeF(SizeF vSize)
		{
			return new SizeF((float)((double)vSize.Width / dblRate), (float)((double)vSize.Height / dblRate));
		}

		public void Clear()
		{
			myItems.Clear();
		}

		public void CopyTo(Array array, int index)
		{
			myItems.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return myItems.GetEnumerator();
		}
	}
}
