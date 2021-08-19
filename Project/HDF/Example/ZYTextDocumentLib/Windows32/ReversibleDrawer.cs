using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public class ReversibleDrawer : DeviceContextBase
	{
		private enum DCRasterOperations
		{
			R2_BLACK = 1,
			R2_NOTMERGEPEN = 2,
			R2_MASKNOTPEN = 3,
			R2_NOTCOPYPEN = 4,
			R2_MASKPENNOT = 5,
			R2_NOT = 6,
			R2_XORPEN = 7,
			R2_NOTMASKPEN = 8,
			R2_MASKPEN = 9,
			R2_NOTXORPEN = 10,
			R2_NOP = 11,
			R2_MERGENOTPEN = 12,
			R2_COPYPEN = 13,
			R2_MERGEPENNOT = 14,
			R2_MERGEPEN = 0xF,
			R2_WHITE = 0x10,
			R2_LAST = 0x10
		}

		private struct RECT
		{
			public int left;

			public int top;

			public int right;

			public int bottom;
		}

		private int intLineWidth = 1;

		private int intOldReversible = 0;

		private GDIPen myPen = new GDIPen(Color.Black);

		public int LineWidth
		{
			get
			{
				return intLineWidth;
			}
			set
			{
				if (intLineWidth != value && value > 0)
				{
					intLineWidth = value;
					myPen.Dispose();
					myPen = new GDIPen(intLineWidth, Color.Black);
				}
			}
		}

		public PenStyle PenStyle
		{
			get
			{
				return myPen.Style;
			}
			set
			{
				myPen.Style = value;
			}
		}

		public Color PenColor
		{
			get
			{
				return myPen.Color;
			}
			set
			{
				myPen.Color = value;
			}
		}

		public static ReversibleDrawer FromHwnd(IntPtr hwnd)
		{
			ReversibleDrawer reversibleDrawer = new ReversibleDrawer();
			reversibleDrawer.InitFromHWnd(hwnd);
			return reversibleDrawer;
		}

		public static ReversibleDrawer FromHDC(IntPtr hdc)
		{
			ReversibleDrawer reversibleDrawer = new ReversibleDrawer();
			reversibleDrawer.InitFromHDC(hdc);
			return reversibleDrawer;
		}

		public static ReversibleDrawer FromScreen()
		{
			ReversibleDrawer reversibleDrawer = new ReversibleDrawer();
			reversibleDrawer.InitFromHWnd(new IntPtr(0));
			return reversibleDrawer;
		}

		private ReversibleDrawer()
		{
		}

		public ReversibleDrawer(Graphics g)
		{
			InitFromGraphics(g);
		}

		public void BeginReversible()
		{
			intOldReversible = SetROP2(intHDC, 6);
		}

		public void EndReversible()
		{
			SetROP2(intHDC, intOldReversible);
		}

		public void DrawLine(int x1, int y1, int x2, int y2)
		{
			int drawMode = SetROP2(intHDC, 6);
			myPen.DrawLine(intHDC, x1, y1, x2, y2);
			SetROP2(intHDC, drawMode);
		}

		public void DrawLines(Point[] ps)
		{
			int drawMode = SetROP2(intHDC, 6);
			myPen.DrawLines(intHDC, ps);
			SetROP2(intHDC, drawMode);
		}

		public void DrawLine(Point p1, Point p2)
		{
			DrawLine(p1.X, p1.Y, p2.X, p2.Y);
		}

		public void DrawRectangle(int left, int top, int width, int height)
		{
			int drawMode = SetROP2(intHDC, 7);
			IntPtr obj = SelectObject(StockObject.NULL_BRUSH);
			IntPtr obj2 = SelectObject(myPen.Handle);
			Rectangle(intHDC, left, top, left + width, top + height);
			SelectObject(obj);
			SelectObject(obj2);
			SetROP2(intHDC, drawMode);
		}

		public void DrawRectangle(Rectangle rect)
		{
			DrawRectangle(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void FillRectangle(int left, int top, int width, int height)
		{
			RECT vRect = default(RECT);
			vRect.left = left;
			vRect.top = top;
			vRect.right = left + width;
			vRect.bottom = top + height;
			InvertRect(intHDC, ref vRect);
		}

		public void FillRectangle(Rectangle rect)
		{
			FillRectangle(rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public override void Dispose()
		{
			base.Dispose();
			if (myPen != null)
			{
				myPen.Dispose();
				myPen = null;
			}
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetROP2(IntPtr hDC, int DrawMode);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr hDC, int X, int Y);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr hDC, int X, int Y, int lpPoint);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern int InvertRect(IntPtr hdc, ref RECT vRect);
	}
}
