using System.Drawing;

namespace XDesignerCommon
{
	public class PointBuffer
	{
		private Point[] myPoints = new Point[16];

		private int intPointCount = 0;

		public int Count => intPointCount;

		public Point this[int index]
		{
			get
			{
				return myPoints[index];
			}
			set
			{
				myPoints[index] = value;
			}
		}

		public Point LastPoint
		{
			get
			{
				if (intPointCount > 0)
				{
					return myPoints[intPointCount - 1];
				}
				return Point.Empty;
			}
		}

		public int MaxX
		{
			get
			{
				int x = myPoints[0].X;
				for (int i = 1; i < intPointCount; i++)
				{
					if (myPoints[i].X > x)
					{
						x = myPoints[i].X;
					}
				}
				return x;
			}
		}

		public int MinX
		{
			get
			{
				int x = myPoints[0].X;
				for (int i = 1; i < intPointCount; i++)
				{
					if (myPoints[i].X < x)
					{
						x = myPoints[i].X;
					}
				}
				return x;
			}
		}

		public int MaxY
		{
			get
			{
				int y = myPoints[0].Y;
				for (int i = 1; i < intPointCount; i++)
				{
					if (myPoints[i].Y > y)
					{
						y = myPoints[i].Y;
					}
				}
				return y;
			}
		}

		public int MinY
		{
			get
			{
				int y = myPoints[0].Y;
				for (int i = 1; i < intPointCount; i++)
				{
					if (myPoints[i].Y < y)
					{
						y = myPoints[i].Y;
					}
				}
				return y;
			}
		}

		public Rectangle Bounds => GetBounds(ToPointArray());

		public void Add(Point p)
		{
			lock (this)
			{
				if (intPointCount >= myPoints.Length)
				{
					Point[] array = new Point[(int)((double)myPoints.Length * 1.5)];
					for (int i = 0; i < intPointCount; i++)
					{
						array[i] = myPoints[i];
					}
					myPoints = array;
				}
				myPoints[intPointCount] = p;
				intPointCount++;
			}
		}

		public void Offset(int dx, int dy)
		{
			for (int i = 0; i < intPointCount; i++)
			{
				myPoints[i].Offset(dx, dy);
			}
		}

		public void Offset(int index, int dx, int dy)
		{
			if (index >= 0 && index < intPointCount)
			{
				myPoints[index].Offset(dx, dy);
			}
		}

		public Point[] ToPointArray()
		{
			Point[] array = null;
			if (intPointCount > 0)
			{
				lock (this)
				{
					array = new Point[intPointCount];
					for (int i = 0; i < intPointCount; i++)
					{
						array[i] = myPoints[i];
					}
				}
			}
			return array;
		}

		public Point[] ToClosedPointArray()
		{
			Point[] array = null;
			if (intPointCount > 0)
			{
				lock (this)
				{
					bool flag = myPoints[0] != myPoints[intPointCount - 1];
					array = new Point[flag ? (intPointCount + 1) : intPointCount];
					for (int i = 0; i < intPointCount; i++)
					{
						array[i] = myPoints[i];
					}
					if (flag)
					{
						array[intPointCount] = myPoints[0];
					}
				}
			}
			return array;
		}

		public void Clear()
		{
			lock (this)
			{
				intPointCount = 0;
				myPoints = new Point[16];
			}
		}

		public static Rectangle GetBounds(Point[] ps)
		{
			if (ps != null && ps.Length > 1)
			{
				int x = ps[0].X;
				int x2 = ps[0].X;
				int y = ps[0].Y;
				int y2 = ps[0].Y;
				for (int i = 0; i < ps.Length; i++)
				{
					if (x < ps[i].X)
					{
						x = ps[i].X;
					}
					if (x2 > ps[i].X)
					{
						x2 = ps[i].X;
					}
					if (y < ps[i].Y)
					{
						y = ps[i].Y;
					}
					if (y2 > ps[i].Y)
					{
						y2 = ps[i].Y;
					}
				}
				return new Rectangle(x2, y2, x - x2, y - y2);
			}
			return Rectangle.Empty;
		}

		public static RectangleF GetBounds(PointF[] ps)
		{
			if (ps != null && ps.Length > 1)
			{
				float x = ps[0].X;
				float x2 = ps[0].X;
				float y = ps[0].Y;
				float y2 = ps[0].Y;
				for (int i = 0; i < ps.Length; i++)
				{
					if (x < ps[i].X)
					{
						x = ps[i].X;
					}
					if (x2 > ps[i].X)
					{
						x2 = ps[i].X;
					}
					if (y < ps[i].Y)
					{
						y = ps[i].Y;
					}
					if (y2 > ps[i].Y)
					{
						y2 = ps[i].Y;
					}
				}
				return new RectangleF(x2, y2, x - x2, y - y2);
			}
			return RectangleF.Empty;
		}
	}
}
