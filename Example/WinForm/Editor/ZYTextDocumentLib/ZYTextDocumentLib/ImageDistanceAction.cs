using System;
using System.Drawing;
using Windows32;
using ZYCommon;

namespace ZYTextDocumentLib
{
	public class ImageDistanceAction : ImageEditAction
	{
		public Point p1 = Point.Empty;

		public Point p2 = Point.Empty;

		public double XRate = 1.0;

		public double YRate = 1.0;

		public Point DrawFix = Point.Empty;

		public double Distance
		{
			get
			{
				if (XRate * YRate != 0.0)
				{
					double num = (double)(p1.X - p2.X) / XRate;
					double num2 = (double)(p1.Y - p2.Y) / YRate;
					return Math.Sqrt(num * num + num2 * num2);
				}
				return 0.0;
			}
		}

		public override Rectangle Bounds
		{
			get
			{
				return RectangleObject.GetRectangle(p1, p2);
			}
			set
			{
			}
		}

		public override string ActionName => "distance";

		public void Clear()
		{
			p1 = Point.Empty;
			p2 = Point.Empty;
		}

		public override bool Execute(Graphics g, Rectangle ClipRect)
		{
			int num = g.GetHdc().ToInt32();
			int rOP = Gdi32.GetROP2(num);
			int hObject = Gdi32.CreatePen(0, 1, 16777215);
			int hObject2 = Gdi32.SelectObject(num, hObject);
			Gdi32.SetROP2(num, 7);
			Gdi32.MoveToEx(num, p1.X + DrawFix.X, p1.Y + DrawFix.Y, 0);
			Gdi32.LineTo(num, p2.X + DrawFix.X, p2.Y + DrawFix.Y);
			if (Distance > 1.0)
			{
				double distance = Distance;
				int num2 = p2.X - p1.X;
				int num3 = p2.Y - p1.Y;
				int num4 = (int)((double)(num3 * 20) / (distance * XRate));
				int num5 = (int)((double)(num2 * 20) / (distance * YRate));
				for (double num6 = 0.0; num6 <= distance; num6 += 1.0)
				{
					double num7 = (double)(DrawFix.X + p1.X) + num6 * (double)num2 / distance;
					double num8 = (double)(DrawFix.Y + p1.Y) + num6 * (double)num3 / distance;
					Gdi32.MoveToEx(num, (int)num7, (int)num8, 0);
					Gdi32.LineTo(num, (int)num7 + num4, (int)num8 - num5);
				}
			}
			Gdi32.SelectObject(num, hObject2);
			Gdi32.DeleteObject(hObject);
			Gdi32.SetROP2(num, rOP);
			g.ReleaseHdc(new IntPtr(num));
			return true;
		}
	}
}
