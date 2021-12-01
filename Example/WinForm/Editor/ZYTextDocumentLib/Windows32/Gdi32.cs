using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public class Gdi32
	{
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Arc(int hdc, int LeftRect, int TopRect, int RightRect, int BottomRect, int XStartArc, int YStartArc, int XEndArc, int YEndArc);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CombineRgn(int dest, int src1, int src2, int flags);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CreateRectRgnIndirect(ref RECT rect);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClipBox(int hDC, ref RECT rectBox);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CreatePen(int PenStyle, int Width, int Color);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SelectClipRgn(int hDC, int hRgn);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CreateBrushIndirect(ref LOGBRUSH brush);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool PatBlt(int hDC, int x, int y, int width, int height, uint flags);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int DeleteObject(int hObject);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool DeleteDC(int hDC);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SelectObject(int hDC, int hObject);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CreateCompatibleDC(int hDC);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GdiFlush();

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetDeviceCaps(int hDC, int index);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetPixel(int hDC, int x, int y);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SetROP2(int hDC, int DrawMode);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetROP2(int hDC);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool LineTo(int hDC, int X, int Y);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool MoveToEx(int hDC, int X, int Y, int lpPoint);

		public static int GetScreenPixel(int x, int y)
		{
			int dC = User32.GetDC(0);
			int pixel = GetPixel(dC, x, y);
			User32.ReleaseDC(0, dC);
			return pixel;
		}

		public static int GetScreenPixel(Point p)
		{
			int dC = User32.GetDC(0);
			int pixel = GetPixel(dC, p.X, p.Y);
			User32.ReleaseDC(0, dC);
			return pixel;
		}
	}
}
