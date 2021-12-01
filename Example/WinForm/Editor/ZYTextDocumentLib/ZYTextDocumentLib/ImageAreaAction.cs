using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Windows32;
using XDesignerCommon;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageAreaAction : ImageEditAction
	{
		private Point[] myPoints = null;

		private double dblContainArea = 0.0;

		public Point DrawFix = Point.Empty;

		private double dblXRate = 0.0;

		private double dblYRate = 0.0;

		public double XRate
		{
			get
			{
				return dblXRate;
			}
			set
			{
				dblXRate = value;
			}
		}

		public double YRate
		{
			get
			{
				return dblYRate;
			}
			set
			{
				dblYRate = value;
			}
		}

		public Point[] Points
		{
			get
			{
				return myPoints;
			}
			set
			{
				myPoints = value;
				dblContainArea = CalcuteArea();
				myBounds = PointBuffer.GetBounds(myPoints);
			}
		}

		public override Rectangle Bounds
		{
			get
			{
				return myBounds;
			}
			set
			{
			}
		}

		public double ContainArea => dblContainArea;

		public double CalcuteArea()
		{
			if (myPoints == null || myPoints.Length < 3 || dblXRate == 0.0 || dblYRate == 0.0)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < myPoints.Length - 2; i++)
			{
				double num2 = myPoints[0].X * myPoints[i].Y;
				num2 += (double)(myPoints[i].X * myPoints[i + 1].Y);
				num2 += (double)(myPoints[i + 1].X * myPoints[0].Y);
				num2 -= (double)(myPoints[0].X * myPoints[i + 1].Y);
				num2 -= (double)(myPoints[i].X * myPoints[0].Y);
				num2 -= (double)(myPoints[i + 1].X * myPoints[i].Y);
				num += num2 / 2.0;
			}
			return Math.Abs(num / (dblXRate * dblYRate));
		}

		public Color CalcuteAvgColor(Bitmap myBMP, ProgressHandler vProgress)
		{
			int[] array = new int[3];
			if (myPoints != null && myPoints.Length > 3)
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(myPoints);
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 0;
				Rectangle a = RectangleObject.ConvertToRectangle(graphicsPath.GetBounds());
				a = Rectangle.Intersect(a, new Rectangle(0, 0, myBMP.Size.Width, myBMP.Size.Height));
				int right = a.Right;
				int bottom = a.Bottom;
				for (int i = a.Left; i < right; i++)
				{
					for (int j = a.Top; j < bottom; j++)
					{
						if (graphicsPath.IsVisible(i, j))
						{
							Color pixel = myBMP.GetPixel(i, j);
							num += (double)(int)pixel.R;
							num2 += (double)(int)pixel.G;
							num3 += (double)(int)pixel.B;
							num4++;
						}
					}
					vProgress?.Invoke(i - a.Left, right - a.Left);
				}
				if (num4 > 0)
				{
					return Color.FromArgb((int)(num / (double)num4), (int)(num2 / (double)num4), (int)(num3 / (double)num4));
				}
			}
			return Color.Black;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			if (myPoints != null && myPoints.Length > 3 && g != null)
			{
				int num = g.GetHdc().ToInt32();
				int rOP = Gdi32.GetROP2(num);
				int hObject = Gdi32.CreatePen(0, 1, 16777215);
				int hObject2 = Gdi32.SelectObject(num, hObject);
				Gdi32.SetROP2(num, 7);
				Gdi32.MoveToEx(num, myPoints[0].X + DrawFix.X, myPoints[0].Y + DrawFix.Y, 0);
				for (int i = 1; i < myPoints.Length; i++)
				{
					Gdi32.LineTo(num, myPoints[i].X + DrawFix.X, myPoints[i].Y + DrawFix.Y);
				}
				Gdi32.SelectObject(num, hObject2);
				Gdi32.DeleteObject(hObject);
				Gdi32.SetROP2(num, rOP);
				g.ReleaseHdc(new IntPtr(num));
				return true;
			}
			return false;
		}
	}
}
