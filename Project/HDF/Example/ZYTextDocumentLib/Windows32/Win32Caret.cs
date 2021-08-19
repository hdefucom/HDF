using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Windows32
{
	public class Win32Caret
	{
		private class Win32Handle : IWin32Window
		{
			public IntPtr handle = IntPtr.Zero;

			public IntPtr Handle => handle;
		}

		private IWin32Window myControl = null;

		public Win32Caret(int hwnd)
		{
			myControl = new Win32Handle
			{
				handle = new IntPtr(hwnd)
			};
		}

		public Win32Caret(IntPtr hwnd)
		{
			myControl = new Win32Handle
			{
				handle = hwnd
			};
		}

		public Win32Caret(IWin32Window ctl)
		{
			myControl = ctl;
		}

		public bool Create(int hBitmap, int nWidth, int nHeight)
		{
			if (myControl == null)
			{
				return false;
			}
			return CreateCaret(myControl.Handle, hBitmap, nWidth, nHeight);
		}

		public bool SetPos(int x, int y)
		{
			if (myControl == null)
			{
				return false;
			}
			return SetCaretPos(x, y);
		}

		public bool Destroy()
		{
			return DestroyCaret();
		}

		public bool Show()
		{
			if (myControl == null)
			{
				return false;
			}
			return ShowCaret(myControl.Handle);
		}

		public bool Hide()
		{
			if (myControl == null)
			{
				return false;
			}
			return HideCaret(myControl.Handle);
		}

		[DllImport("User32.dll")]
		private static extern bool CreateCaret(IntPtr hWnd, int hBitmap, int nWidth, int nHeight);

		[DllImport("User32.dll")]
		private static extern bool SetCaretPos(int x, int y);

		[DllImport("User32.dll")]
		private static extern bool DestroyCaret();

		[DllImport("User32.dll")]
		private static extern bool ShowCaret(IntPtr hWnd);

		[DllImport("User32.dll")]
		private static extern bool HideCaret(IntPtr hWnd);
	}
}
