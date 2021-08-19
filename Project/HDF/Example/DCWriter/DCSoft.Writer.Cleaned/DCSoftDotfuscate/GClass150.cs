using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass150
	{
		public static void smethod_0(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3)
		{
			IntPtr intPtr = CreatePen(0, 1, ColorTranslator.ToWin32(Color.SkyBlue));
			IntPtr dC = GetDC(intptr_0);
			if (dC != IntPtr.Zero)
			{
				IntPtr intptr_ = SelectObject(dC, intPtr);
				int int_4 = SetROP2(dC, 7);
				MoveToEx(dC, int_0, int_1, 0);
				LineTo(dC, int_2, int_3);
				SetROP2(dC, int_4);
				SelectObject(dC, intptr_);
				ReleaseDC(intptr_0, dC);
			}
			DeleteObject(intPtr);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int DeleteObject(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetDC(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreatePen(int int_0, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool LineTo(IntPtr intptr_0, int int_0, int int_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool MoveToEx(IntPtr intptr_0, int int_0, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int SetROP2(IntPtr intptr_0, int int_0);
	}
}
