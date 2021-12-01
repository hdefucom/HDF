using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass259
	{
		public static int smethod_0(Color color_0)
		{
			return (color_0.B << 16) | (color_0.G << 8) | color_0.R;
		}

		public static Color smethod_1(int int_0)
		{
			int blue = (int_0 >> 16) & 0xFF;
			int green = (int_0 >> 8) & 0xFF;
			int red = int_0 & 0xFF;
			return Color.FromArgb(red, green, blue);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool ScaleViewportExtEx(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool ScaleWindowExtEx(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool OffsetViewportOrgEx(int int_0, int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool OffsetWindowOrgEx(int int_0, int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Arc(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CombineRgn(int int_0, int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int CreateRectRgnIndirect(ref GStruct14 gstruct14_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetClipBox(int int_0, ref GStruct14 gstruct14_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreatePen(int int_0, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SelectClipRgn(int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateBrushIndirect(ref GStruct19 gstruct19_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateSolidBrush(int int_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool PatBlt(int int_0, int int_1, int int_2, int int_3, int int_4, uint uint_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int DeleteObject(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateDC(string string_0, string string_1, int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool DeleteDC(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GdiFlush();

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetDeviceCaps(IntPtr intptr_0, int int_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetPixel(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SetPixel(IntPtr intptr_0, int int_0, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int SetROP2(IntPtr intptr_0, int int_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern int GetROP2(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool LineTo(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool MoveToEx(IntPtr intptr_0, int int_0, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool Rectangle(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		public static extern bool RoundRect(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

		[DllImport("gdi32")]
		public static extern bool TextOutA(IntPtr intptr_0, int int_0, int int_1, string string_0, int int_2);

		[DllImport("gdi32")]
		public static extern bool ExtTextOutA(IntPtr intptr_0, int int_0, int int_1, uint uint_0, int int_2, string string_0, uint uint_1, int int_3);

		[DllImport("gdi32")]
		public static extern bool Polygon(IntPtr intptr_0, GStruct15[] gstruct15_0, int int_0);

		[DllImport("gdi32")]
		public static extern int SetPolyFillMode(IntPtr intptr_0, int int_0);

		[DllImport("gdi32")]
		public static extern bool GetTextMetricsA(IntPtr intptr_0, out GStruct12 gstruct12_0);

		[DllImport("gdi32")]
		public static extern int GetTextExtentPoint32A(IntPtr intptr_0, string string_0, int int_0, ref GStruct16 gstruct16_0);

		[DllImport("gdi32")]
		public static extern int GetStockObject(GEnum41 genum41_0);

		[DllImport("gdi32")]
		public static extern int SetBkMode(IntPtr intptr_0, GEnum42 genum42_0);

		[DllImport("gdi32")]
		public static extern bool Pie(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7);

		[DllImport("gdi32")]
		public static extern int SetTextColor(IntPtr intptr_0, int int_0);

		[DllImport("gdi32")]
		public static extern int SetBkColor(IntPtr intptr_0, int int_0);

		[DllImport("gdi32")]
		public static extern int CreatePatternBrush(IntPtr intptr_0);

		[DllImport("gdi32")]
		public static extern int CreateBitmap(int int_0, int int_1, uint uint_0, uint uint_1, byte[] byte_0);

		[DllImport("gdi32")]
		public static extern int CreateRectRgn(int int_0, int int_1, int int_2, int int_3);

		[DllImport("gdi32")]
		public static extern int CombineRgn(int int_0, int int_1, int int_2, GEnum39 genum39_0);

		[DllImport("gdi32")]
		public static extern int ExtSelectClipRgn(IntPtr intptr_0, int int_0, GEnum39 genum39_0);

		[DllImport("gdi32")]
		public static extern int GetClipRgn(IntPtr intptr_0, int int_0);

		[DllImport("gdi32")]
		public static extern int OffsetRgn(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("gdi32")]
		public static extern int GetObject(IntPtr intptr_0, int int_0, out GStruct10 gstruct10_0);

		[DllImport("gdi32")]
		public static extern int CreateFontIndirectA(ref GStruct10 gstruct10_0);

		[DllImport("gdi32")]
		public static extern int CreateDIBSection(int int_0, [In] [MarshalAs(UnmanagedType.LPStruct)] GClass270 gclass270_0, GEnum33 genum33_0, out int int_1, int int_2, uint uint_0);

		[DllImport("gdi32")]
		public static extern int BitBlt(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, IntPtr intptr_1, int int_4, int int_5, int int_6);

		[DllImport("gdi32")]
		public static extern int SetDIBitsToDevice(IntPtr intptr_0, int int_0, int int_1, uint uint_0, uint uint_1, int int_2, int int_3, uint uint_2, uint uint_3, ref byte byte_0, GClass270 gclass270_0, uint uint_4);

		[DllImport("kernel32")]
		public static extern int GlobalLock(int int_0);

		[DllImport("kernel32")]
		public static extern bool GlobalUnlock(int int_0);

		[DllImport("gdi32")]
		public static extern int SaveDC(IntPtr intptr_0);

		[DllImport("gdi32")]
		public static extern bool RestoreDC(IntPtr intptr_0, int int_0);

		[DllImport("gdi32")]
		public static extern int ExtCreateRegion(int int_0, uint uint_0, ref byte byte_0);

		[DllImport("gdi32")]
		public static extern uint GetRegionData(IntPtr intptr_0, uint uint_0, ref byte byte_0);

		[DllImport("gdi32")]
		public static extern int GetBkColor(IntPtr intptr_0);

		public static int smethod_2(int int_0, int int_1)
		{
			IntPtr dC = GClass262.GetDC(IntPtr.Zero);
			int pixel = GetPixel(dC, int_0, int_1);
			GClass262.ReleaseDC(IntPtr.Zero, dC);
			return pixel;
		}

		public static int smethod_3(Point point_0)
		{
			IntPtr dC = GClass262.GetDC(IntPtr.Zero);
			int pixel = GetPixel(dC, point_0.X, point_0.Y);
			GClass262.ReleaseDC(IntPtr.Zero, dC);
			return pixel;
		}
	}
}
