using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass17
	{
		private class Class43 : IWin32Window
		{
			public IntPtr intptr_0 = IntPtr.Zero;

			public IntPtr Handle => intptr_0;
		}

		private struct Struct5
		{
			public int int_0;

			public int int_1;
		}

		private IWin32Window iwin32Window_0 = null;

		public GClass17(int int_0)
		{
			iwin32Window_0 = new Class43
			{
				intptr_0 = new IntPtr(int_0)
			};
		}

		public GClass17(IntPtr intptr_0)
		{
			iwin32Window_0 = new Class43
			{
				intptr_0 = intptr_0
			};
		}

		public GClass17(IWin32Window iwin32Window_1)
		{
			iwin32Window_0 = iwin32Window_1;
		}

		public bool Create(int hBitmap, int nWidth, int nHeight)
		{
			if (iwin32Window_0 == null)
			{
				return false;
			}
			return CreateCaret(iwin32Window_0.Handle, hBitmap, nWidth, nHeight);
		}

		public bool SetPos(int int_0, int int_1)
		{
			if (iwin32Window_0 == null)
			{
				return false;
			}
			return SetCaretPos(int_0, int_1);
		}

		public bool method_0()
		{
			return DestroyCaret();
		}

		public bool Show()
		{
			if (iwin32Window_0 == null)
			{
				return false;
			}
			return ShowCaret(iwin32Window_0.Handle);
		}

		public bool Hide()
		{
			if (iwin32Window_0 == null)
			{
				return false;
			}
			return HideCaret(iwin32Window_0.Handle);
		}

		public static Point smethod_0()
		{
			Struct5 struct5_ = default(Struct5);
			if (GetCaretPos(ref struct5_))
			{
				return new Point(struct5_.int_0, struct5_.int_1);
			}
			return Point.Empty;
		}

		[DllImport("user32.dll")]
		private static extern bool GetCaretPos(ref Struct5 struct5_0);

		[DllImport("user32.dll")]
		private static extern bool CreateCaret(IntPtr intptr_0, int int_0, int int_1, int int_2);

		[DllImport("user32.dll")]
		private static extern bool SetCaretPos(int int_0, int int_1);

		[DllImport("user32.dll")]
		private static extern bool DestroyCaret();

		[DllImport("user32.dll")]
		private static extern bool ShowCaret(IntPtr intptr_0);

		[DllImport("user32.dll")]
		private static extern bool HideCaret(IntPtr intptr_0);
	}
}
