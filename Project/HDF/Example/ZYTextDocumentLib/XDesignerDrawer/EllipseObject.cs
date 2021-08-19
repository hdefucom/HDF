using System;
using System.Drawing;

namespace XDesignerDrawer
{
	public class EllipseObject
	{
		private RectangleF myBounds = RectangleF.Empty;

		private PointF myCenter = PointF.Empty;

		public RectangleF Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
				myBounds = value;
				UpdateSate();
			}
		}

		public PointF Center => myCenter;

		public float Semimajor => (float)((double)myBounds.Width / 2.0);

		public float SemiMinor => (float)((double)myBounds.Height / 2.0);

		public EllipseObject()
		{
		}

		public EllipseObject(RectangleF bounds)
		{
			myBounds = bounds;
			UpdateSate();
		}

		public EllipseObject(Rectangle bounds)
		{
			myBounds = new RectangleF(bounds.Left, bounds.Top, bounds.Width, bounds.Height);
			UpdateSate();
		}

		public void Offset(float dx, float dy)
		{
			myBounds.Offset(dx, dy);
			UpdateSate();
		}

		private void UpdateSate()
		{
			myCenter = new PointF(myBounds.Left + myBounds.Width / 2f, myBounds.Top + myBounds.Height / 2f);
		}

		public PointF PeripheraPoint(double angle)
		{
			double num = angle * Math.PI / 180.0;
			double num2 = (double)myCenter.X + (double)myBounds.Width * Math.Cos(num) / 2.0;
			double num3 = (double)myCenter.Y + (double)myBounds.Height * Math.Sin(num) / 2.0;
			return new PointF((float)num2, (float)num3);
		}

		public PointF PeripheraPoint2(double angle)
		{
			double num = angle * Math.PI / 180.0;
			double ellipseRadius = GetEllipseRadius(angle);
			double num2 = (double)myCenter.X + ellipseRadius * Math.Cos(num);
			double num3 = (double)myCenter.Y + ellipseRadius * Math.Sin(num);
			return new PointF((float)num2, (float)num3);
		}

		public float CompressAngle(float angle)
		{
			if (myBounds.Width == myBounds.Height)
			{
				return angle;
			}
			double x = (double)myBounds.Width * Math.Cos((double)angle * Math.PI / 180.0);
			double y = (double)myBounds.Height * Math.Sin((double)angle * Math.PI / 180.0);
			float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
			if (num < 0f)
			{
				num += 360f;
			}
			return num;
		}

		public float UnCompressAngle(float angle)
		{
			if (myBounds.Width == myBounds.Height)
			{
				return angle;
			}
			double x = (double)myBounds.Height * Math.Cos((double)angle * Math.PI / 180.0);
			double y = (double)myBounds.Height * Math.Sin((double)angle * Math.PI / 180.0);
			float num = (float)(Math.Atan2(y, x) * 180.0 / Math.PI);
			if (num < 0f)
			{
				num += 360f;
			}
			return num;
		}

		public bool Contains(double x, double y)
		{
			double num = x - (double)myBounds.Left - (double)(myBounds.Width / 2f);
			double num2 = y - (double)myBounds.Top - (double)(myBounds.Height / 2f);
			double num3 = Math.Atan2(y, x);
			if (num3 < 0.0)
			{
				num3 += Math.PI * 2.0;
			}
			double num4 = Math.Sqrt(num2 * num2 + num * num);
			return GetEllipseRadius(num3) > num4;
		}

		public bool Contains(double x, double y, float StartAngle, float SweepAngle)
		{
			double num = x - (double)myBounds.Left - (double)(myBounds.Width / 2f);
			double num2 = y - (double)myBounds.Top - (double)(myBounds.Height / 2f);
			double num3 = Math.Atan2(num2, num);
			if (num3 < 0.0)
			{
				num3 += Math.PI * 2.0;
			}
			double num4 = num3 * 180.0 / Math.PI;
			float num5 = StartAngle + SweepAngle;
			if ((num4 >= (double)StartAngle && num4 <= (double)num5) || (num5 > 360f && num4 + 360.0 <= (double)num5))
			{
				double num6 = Math.Sqrt(num2 * num2 + num * num);
				return GetEllipseRadius(num4) > num6;
			}
			return false;
		}

		public double GetEllipseRadius(double angle)
		{
			angle = angle * Math.PI / 180.0;
			double num = myBounds.Width / 2f;
			double num2 = myBounds.Height / 2f;
			double num3 = num * num;
			double num4 = num2 * num2;
			double num5 = Math.Cos(angle);
			double num6 = Math.Sin(angle);
			return num * num2 / Math.Sqrt(num4 * num5 * num5 + num3 * num6 * num6);
		}

		public void Draw(Graphics g, Pen pen, Brush brush)
		{
			if (g != null && (pen != null || brush != null))
			{
				if (brush != null)
				{
					g.FillEllipse(brush, myBounds);
				}
				if (pen != null)
				{
					g.DrawEllipse(pen, myBounds);
				}
			}
		}

		public void Draw(Graphics g, Pen pen, Brush brush, float StartAngle, float SweepAngle)
		{
			if (g != null && (pen != null || brush != null))
			{
				if (brush != null)
				{
					g.FillPie(brush, myBounds.Left, myBounds.Top, myBounds.Width, myBounds.Height, StartAngle, SweepAngle);
				}
				if (pen != null)
				{
					g.DrawPie(pen, myBounds.Left, myBounds.Top, myBounds.Width, myBounds.Height, StartAngle, SweepAngle);
				}
			}
		}
	}
}
