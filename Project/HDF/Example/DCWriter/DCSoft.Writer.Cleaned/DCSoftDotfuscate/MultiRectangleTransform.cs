using DCSoft.Common;
using DCSoft.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[DefaultMember("Item")]
	[DebuggerTypeProxy(typeof(ListDebugView))]
	[DebuggerDisplay("Count={ Count }")]
	[ComVisible(false)]
	public class MultiRectangleTransform : TransformBase, ICollection
	{
		protected List<SimpleRectangleTransform> list_0 = new List<SimpleRectangleTransform>();

		private static int int_0 = 0;

		private int int_1 = 0;

		private double Rate = 1.0;

		protected Point mySourceOffsetBack = Point.Empty;

		protected SimpleRectangleTransform gclass435_0 = null;

		public int Count => list_0.Count;

		public object SyncRoot => null;

		public bool IsSynchronized => false;

		public MultiRectangleTransform()
		{
			int_1 = int_0++;
		}

		public int method_0()
		{
			return int_1;
		}

		public double method_1()
		{
			return Rate;
		}

		public void method_2(double double_1)
		{
			Rate = double_1;
		}

		public void OffsetSource(int x, int y, bool bool_0)
		{
			if (x != 0 || y != 0)
			{
				if (bool_0)
				{
					mySourceOffsetBack.Offset(x, y);
				}
				{
					IEnumerator enumerator = GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
							RectangleF rectangleF_ = gClass.getSourceRectF();

							rectangleF_.Offset(x, y);

							gClass.setSourceRectF(rectangleF_);

							Rectangle rectangle_ = gClass.rectangle_0;
							rectangle_.Offset(x, y);
							gClass.rectangle_0 = rectangle_;
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
							SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
							RectangleF rectangleF_ = gClass.getSourceRectF();

							rectangleF_.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);

							gClass.setSourceRectF(rectangleF_);

							Rectangle rectangle_ = gClass.rectangle_0;
							rectangle_.Offset(-mySourceOffsetBack.X, -mySourceOffsetBack.Y);
							gClass.rectangle_0 = rectangle_;
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

		public Rectangle SourceBounds()
		{
			Rectangle rectangle = Rectangle.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(rectangle, gClass.method_21()) : gClass.method_21());
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

		public Rectangle DescBounds()
		{
			Rectangle rectangle = Rectangle.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					rectangle = ((!rectangle.IsEmpty) ? Rectangle.Union(rectangle, gClass.method_27()) : gClass.method_27());
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

		public SimpleRectangleTransform method_7(int int_2)//this[]
		{
			return list_0[int_2];
		}

		public SimpleRectangleTransform method_8(Rectangle rectangle_0)//this[]
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.method_21().Equals(rectangle_0))
					{
						return gClass;
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

		public SimpleRectangleTransform method_9(int int_2, int int_3)//this[]
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.method_21().Contains(int_2, int_3) && gClass.getEnable())
					{
						return gClass;
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

		public SimpleRectangleTransform method_10(Point point_1)//this[]
		{
			return method_9(point_1.X, point_1.Y);
		}

		public SimpleRectangleTransform method_11(float float_0, float float_1)
		{
			return method_15(float_0, float_1, bool_0: false, bool_1: false, bool_2: false);
		}

		public SimpleRectangleTransform method_12(float float_0, float float_1)
		{
			return method_15(float_0, float_1, bool_0: false, bool_1: true, bool_2: false);
		}

		public SimpleRectangleTransform method_13(float float_0, float float_1)
		{
			return method_15(float_0, float_1, bool_0: true, bool_1: false, bool_2: false);
		}

		public SimpleRectangleTransform method_14(float float_0, float float_1)
		{
			return method_15(float_0, float_1, bool_0: true, bool_1: true, bool_2: false);
		}

		public SimpleRectangleTransform method_15(float float_0, float float_1, bool bool_0, bool bool_1, bool bool_2)
		{
			if (Count == 0)
			{
				return null;
			}
			foreach (SimpleRectangleTransform item in list_0)
			{
				if (!bool_2 || item.getEnable())
				{
					if (bool_0)
					{
						if (item.getSourceRectF().Contains(float_0, float_1))
						{
							return item;
						}
					}
					else if (item.method_25().Contains(float_0, float_1))
					{
						return item;
					}
				}
			}
			if (bool_1)
			{
				float num = 0f;
				int index = 0;
				int num2 = 0;
				while (true)
				{
					if (num2 < list_0.Count)
					{
						SimpleRectangleTransform current = list_0[num2];
						if (!bool_2 || current.getEnable())
						{
							RectangleF rectangle = bool_0 ? current.getSourceRectF() : current.method_25();
							if (rectangle.Contains(float_0, float_1))
							{
								break;
							}
							float distance = RectangleCommon.GetDistance(float_0, float_1, rectangle);
							if (num2 == 0 || distance < num)
							{
								num = distance;
								index = num2;
							}
						}
						num2++;
						continue;
					}
					return list_0[index];
				}
				return list_0[num2];
			}
			return null;
		}

		public SimpleRectangleTransform method_16(float x, float y, bool bool_0, GEnum92 genum92_0, bool bool_1)
		{
			if (Count == 0)
			{
				return null;
			}
			foreach (SimpleRectangleTransform item in list_0)
			{
				if (!bool_1 || item.getEnable())
				{
					if (bool_0)
					{
						if (item.getSourceRectF().Contains(x, y))
						{
							return item;
						}
					}
					else if (item.method_25().Contains(x, y))
					{
						return item;
					}
				}
			}
			int num;
			switch (genum92_0)
			{
			case GEnum92.const_0:
				return null;
			case GEnum92.const_1:
			{
				float num2 = 0f;
				int index = 0;
				int num3 = 0;
				while (true)
				{
					if (num3 < list_0.Count)
					{
						SimpleRectangleTransform current = list_0[num3];
						if (!bool_1 || current.getEnable())
						{
							RectangleF rectangle = bool_0 ? current.getSourceRectF() : current.method_25();
							if (rectangle.Contains(x, y))
							{
								break;
							}
							float distance = RectangleCommon.GetDistance(x, y, rectangle);
							if (num3 == 0 || distance < num2)
							{
								num2 = distance;
								index = num3;
							}
						}
						num3++;
						continue;
					}
					return list_0[index];
				}
				return list_0[num3];
			}
			default:
				num = ((genum92_0 != GEnum92.const_3) ? 1 : 0);
				break;
			case GEnum92.const_2:
				num = 0;
				break;
			}
			if (num == 0)
			{
				float num2 = float.MaxValue;
				int index = 0;
				int num3 = 0;
				while (true)
				{
					if (num3 < list_0.Count)
					{
						SimpleRectangleTransform current = list_0[num3];
						if (!bool_1 || current.getEnable())
						{
							RectangleF rectangle = bool_0 ? current.getSourceRectF() : current.method_25();
							if (rectangle.Contains(x, y))
							{
								break;
							}
							float distance = float.MaxValue;
							switch (genum92_0)
							{
							case GEnum92.const_2:
								distance = y - rectangle.Bottom;
								if (distance < num2 && distance >= 0f)
								{
									num2 = distance;
									index = num3;
								}
								break;
							case GEnum92.const_3:
								distance = rectangle.Top - y;
								if (distance < num2 && distance >= 0f)
								{
									num2 = distance;
									index = num3;
								}
								break;
							}
						}
						num3++;
						continue;
					}
					return list_0[index];
				}
				return list_0[num3];
			}
			return null;
		}

		public int method_17(SimpleRectangleTransform gclass435_1)
		{
			int_1 = int_0++;
			list_0.Add(gclass435_1);
			return list_0.Count - 1;
		}

		public SimpleRectangleTransform method_18(Rectangle rectangle_0, Rectangle rectangle_1)
		{
			int_1 = int_0++;
			SimpleRectangleTransform gClass = new SimpleRectangleTransform(rectangle_0, rectangle_1);
			list_0.Add(gClass);
			return gClass;
		}

		public SimpleRectangleTransform method_19(int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8, int int_9)
		{
			int_1 = int_0++;
			SimpleRectangleTransform gClass = new SimpleRectangleTransform(new Rectangle(int_2, int_3, int_4, int_5), new Rectangle(int_6, int_7, int_8, int_9));
			list_0.Add(gClass);
			return gClass;
		}

		public override bool ContainsSourcePoint(int int_2, int int_3)
		{
			return method_9(int_2, int_3) != null;
		}

		public bool method_20(Point point_1)
		{
			return method_9(point_1.X, point_1.Y) != null;
		}

		public int TransformY(int int_2)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable())
					{
						Rectangle rectangle = gClass.method_21();
						if (int_2 >= rectangle.Top && int_2 <= rectangle.Bottom)
						{
							return gClass.TransformPoint(rectangle.Left, int_2).Y;
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
			return int_2;
		}

		public int UnTransformY(int int_2)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable())
					{
						Rectangle rectangle = gClass.method_27();
						if (int_2 >= rectangle.Top && int_2 <= rectangle.Bottom)
						{
							return gClass.UnTransformPoint(gClass.method_27().Left, int_2).Y;
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

		public Point method_23(Point point_1)
		{
			return TransformPoint(point_1.X, point_1.Y);
		}

		public override Point TransformPoint(int int_2, int int_3)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable() && gClass.method_21().Contains(int_2, int_3))
					{
						return gClass.TransformPoint(int_2, int_3);
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

		public override Size vmethod_6(int int_2, int int_3)
		{
			return new Size((int)((double)int_2 * Rate), (int)((double)int_3 * Rate));
		}

		public override Size vmethod_5(Size size_0)
		{
			return new Size((int)((double)size_0.Width * Rate), (int)((double)size_0.Height * Rate));
		}

		public override SizeF vmethod_8(float float_0, float float_1)
		{
			return new SizeF((float)((double)float_0 * Rate), (float)((double)float_1 * Rate));
		}

		public override SizeF vmethod_7(SizeF sizeF_0)
		{
			return new SizeF((float)((double)sizeF_0.Width * Rate), (float)((double)sizeF_0.Height * Rate));
		}

		public override Point UnTransformPoint(int int_2, int int_3)
		{
			Point result = Point.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable() && gClass.method_27().Contains(int_2, int_3))
					{
						result = gClass.UnTransformPoint(int_2, int_3);
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

		public override PointF TransformPointF(float float_0, float float_1)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getSourceRectF().Contains(float_0, float_1) && gClass.getEnable())
					{
						return gClass.TransformPointF(float_0, float_1);
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
			return new PointF(float_0, float_1);
		}

		public override PointF UnTransformPointF(float float_0, float float_1)
		{
			PointF result = PointF.Empty;
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.method_25().Contains(float_0, float_1) && gClass.getEnable())
					{
						result = gClass.UnTransformPointF(float_0, float_1);
						break;
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

		public override Size UnTransformSize(int int_2, int int_3)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable())
					{
						gClass.UnTransformSize(int_2, int_3);
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
			return new Size((int)((double)int_2 / Rate), (int)((double)int_3 / Rate));
		}

		public override Size UnTransformSize(Size size_0)
		{
			return UnTransformSize(size_0.Width, size_0.Height);
		}

		public override SizeF vmethod_20(float float_0, float float_1)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					SimpleRectangleTransform gClass = (SimpleRectangleTransform)enumerator.Current;
					if (gClass.getEnable())
					{
						return gClass.vmethod_20(float_0, float_1);
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
			return new SizeF((float)((double)float_0 / Rate), (float)((double)float_1 / Rate));
		}

		public override SizeF vmethod_19(SizeF sizeF_0)
		{
			return vmethod_20(sizeF_0.Width, sizeF_0.Height);
		}

		public SimpleRectangleTransform method_24()
		{
			return gclass435_0;
		}

		public void method_25()
		{
			int_1 = int_0++;
			list_0.Clear();
		}

		public void CopyTo(Array array, int index)
		{
			throw new NotSupportedException("CopyTo");
		}

		public IEnumerator GetEnumerator()
		{
			return list_0.GetEnumerator();
		}
	}
}
