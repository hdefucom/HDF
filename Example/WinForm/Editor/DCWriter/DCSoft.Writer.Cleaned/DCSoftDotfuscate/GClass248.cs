using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass248 : IDisposable
	{
		protected IntPtr intptr_0 = IntPtr.Zero;

		private int int_0 = 0;

		private Graphics graphics_0 = null;

		private IntPtr intptr_1 = IntPtr.Zero;

		protected void method_0(IntPtr intptr_2)
		{
			intptr_0 = intptr_2;
			int_0 = 0;
		}

		protected void method_1(IntPtr intptr_2)
		{
			intptr_1 = intptr_2;
			intptr_0 = GetDC(intptr_2);
			int_0 = 1;
		}

		protected void method_2(Graphics graphics_1)
		{
			intptr_0 = graphics_1.GetHdc();
			graphics_0 = graphics_1;
			int_0 = 2;
		}

		protected void method_3(string string_0)
		{
			intptr_0 = CreateDC(string_0, null, 0, 0);
			int_0 = 3;
		}

		protected void method_4(IntPtr intptr_2)
		{
			intptr_0 = CreateCompatibleDC(intptr_2);
			int_0 = 4;
		}

		public IntPtr method_5()
		{
			return intptr_0;
		}

		public virtual void Dispose()
		{
			if (intptr_0 != IntPtr.Zero)
			{
				if (int_0 == 1)
				{
					ReleaseDC(intptr_1, intptr_0);
				}
				if (int_0 == 2 && graphics_0 != null)
				{
					graphics_0.ReleaseHdc(intptr_0);
					graphics_0.Flush(FlushIntention.Flush);
				}
				if (int_0 == 3)
				{
					DeleteDC(intptr_0);
				}
				if (int_0 == 4)
				{
					DeleteDC(intptr_0);
				}
			}
			intptr_0 = IntPtr.Zero;
			intptr_1 = IntPtr.Zero;
			int_0 = 0;
			graphics_0 = null;
		}

		public IntPtr method_6(IntPtr intptr_2)
		{
			return SelectObject(intptr_0, intptr_2);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool DeleteDC(IntPtr intptr_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetDC(IntPtr intptr_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateDC(string string_0, string string_1, int int_1, int int_2);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateCompatibleDC(IntPtr intptr_2);
	}
}
