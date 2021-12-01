using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows32
{
	public abstract class GDIObject : IDisposable
	{
		protected IntPtr intHandle = IntPtr.Zero;

		public IntPtr Handle => intHandle;

		public virtual void Dispose()
		{
			if (intHandle.ToInt32() != 0)
			{
				DeleteObject(intHandle);
				intHandle = IntPtr.Zero;
			}
		}

		public IntPtr SelectTo(IntPtr hdc)
		{
			return SelectObject(hdc, intHandle);
		}

		public IntPtr SelectTo(int hdc)
		{
			return SelectObject(new IntPtr(hdc), intHandle);
		}

		public bool UnSelect(IntPtr hdc, IntPtr handle)
		{
			IntPtr value = SelectObject(hdc, handle);
			return value == intHandle;
		}

		public bool UnSelect(int hdc, IntPtr handle)
		{
			IntPtr value = SelectObject(new IntPtr(hdc), handle);
			return value == intHandle;
		}

		protected int ColorToInt(Color color)
		{
			return (color.B << 16) | (color.G << 8) | color.R;
		}

		protected Color IntToColor(int color)
		{
			int blue = (color >> 16) & 0xFF;
			int green = (color >> 8) & 0xFF;
			int red = color & 0xFF;
			return Color.FromArgb(red, green, blue);
		}

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern int DeleteObject(IntPtr hObject);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
	}
}
