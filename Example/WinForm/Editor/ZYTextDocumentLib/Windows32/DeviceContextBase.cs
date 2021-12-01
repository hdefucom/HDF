using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public class DeviceContextBase : IDisposable
	{
		protected IntPtr intHDC = IntPtr.Zero;

		private int InitMode = 0;

		private Graphics myGraphics = null;

		private IntPtr intHwnd = IntPtr.Zero;

		public IntPtr HDC => intHDC;

		protected void InitFromHDC(IntPtr hdc)
		{
			intHDC = hdc;
			InitMode = 0;
		}

		protected void InitFromHWnd(IntPtr hwnd)
		{
			intHwnd = hwnd;
			intHDC = GetDC(hwnd);
			InitMode = 1;
		}

		protected void InitFromGraphics(Graphics g)
		{
			intHDC = g.GetHdc();
			myGraphics = g;
			InitMode = 2;
		}

		protected void InitFromDriverName(string strDriver)
		{
			intHDC = CreateDC(strDriver, null, 0, 0);
			InitMode = 3;
		}

		protected void InitCompatibleDC(IntPtr hdc)
		{
			intHDC = CreateCompatibleDC(hdc);
			InitMode = 4;
		}

		public virtual void Dispose()
		{
			if (intHDC != IntPtr.Zero)
			{
				if (InitMode == 1)
				{
					ReleaseDC(intHwnd, intHDC);
				}
				if (InitMode == 2)
				{
					myGraphics.ReleaseHdc(intHDC);
				}
				if (InitMode == 3)
				{
					DeleteDC(intHDC);
				}
				if (InitMode == 4)
				{
					DeleteDC(intHDC);
				}
			}
			intHDC = IntPtr.Zero;
			intHwnd = IntPtr.Zero;
			InitMode = 0;
			myGraphics = null;
		}

		public IntPtr SelectObject(IntPtr obj)
		{
			return SelectObject(intHDC, obj);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern bool DeleteDC(IntPtr hDC);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("User32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateDC(string strDriver, string strDevice, int Output, int InitData);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
	}
}
