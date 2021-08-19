using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public class GDIPen : GDIObject
	{
		private struct POINT
		{
			public int x;

			public int y;
		}

		public static readonly GDIPen NullPen = new GDIPen(PenStyle.PS_NULL, 1, Color.Black);

		private PenStyle intStyle = PenStyle.PS_SOLID;

		private int intWidth = 1;

		private Color intColor = Color.Black;

		public PenStyle Style
		{
			get
			{
				return intStyle;
			}
			set
			{
				if (intStyle != value)
				{
					intStyle = value;
					Dispose();
					intHandle = CreatePen((int)intStyle, intWidth, ColorToInt(intColor));
				}
			}
		}

		public int Width => intWidth;

		public Color Color
		{
			get
			{
				return intColor;
			}
			set
			{
				if (intColor != value)
				{
					intColor = value;
					Dispose();
					intHandle = CreatePen((int)intStyle, intWidth, ColorToInt(intColor));
				}
			}
		}

		public GDIPen(Color color)
			: this(PenStyle.PS_SOLID, 1, color)
		{
		}

		public GDIPen(int width, Color color)
			: this(PenStyle.PS_SOLID, width, color)
		{
		}

		public GDIPen(PenStyle style, int width, Color color)
		{
			intStyle = style;
			intWidth = width;
			intColor = color;
			intHandle = CreatePen((int)intStyle, intWidth, ColorToInt(color));
		}

		public void DrawLine(IntPtr hdc, int x1, int y1, int x2, int y2)
		{
			IntPtr handle = SelectTo(hdc);
			MoveToEx(hdc, x1, y1, 0);
			LineTo(hdc, x2, y2);
			if (handle.ToInt32() != 0)
			{
				UnSelect(hdc, handle);
			}
		}

		public void DrawLines(IntPtr hdc, Point[] ps)
		{
			IntPtr handle = SelectTo(hdc);
			POINT[] array = new POINT[ps.Length];
			for (int i = 0; i < ps.Length; i++)
			{
				array[i].x = ps[i].X;
				array[i].y = ps[i].Y;
			}
			Polyline(hdc, array, array.Length);
			if (handle.ToInt32() != 0)
			{
				UnSelect(hdc, handle);
			}
		}

		public void DrawLine(IntPtr hdc, Point p1, Point p2)
		{
			DrawLine(hdc, p1.X, p1.Y, p2.X, p2.Y);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreatePen(int PenStyle, int Width, int Color);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr hDC, int X, int Y);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool Polyline(IntPtr hDC, POINT[] ps, int len);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr hDC, int X, int Y, int lpPoint);
	}
}
