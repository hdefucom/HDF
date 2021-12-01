using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass16
	{
		private class Class42 : IWin32Window
		{
			public IntPtr intptr_0 = IntPtr.Zero;

			public IntPtr Handle => intptr_0;
		}

		private enum Enum3
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 0x20,
			const_4 = 0x40,
			const_5 = 0x80
		}

		private struct Struct2
		{
			public int int_0;

			public Struct4 struct4_0;

			public Struct3 struct3_0;
		}

		private struct Struct3
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;
		}

		private struct Struct4
		{
			public int int_0;

			public int int_1;
		}

		public const int int_0 = 1;

		public const int int_1 = 2;

		public const int int_2 = 3;

		public const int int_3 = 4;

		public const int int_4 = 5;

		public const int int_5 = 6;

		public const int int_6 = 7;

		public const int int_7 = 8;

		public const int int_8 = 9;

		public const int int_9 = 10;

		public const int int_10 = 11;

		public const int int_11 = 12;

		public const int int_12 = 13;

		public const int int_13 = 14;

		public const int int_14 = 641;

		public const int int_15 = 642;

		public const int int_16 = 643;

		public const int int_17 = 644;

		public const int int_18 = 645;

		public const int int_19 = 646;

		public const int int_20 = 648;

		public const int int_21 = 656;

		public const int int_22 = 657;

		private int int_23 = int.MinValue;

		private int int_24 = int.MinValue;

		private IWin32Window iwin32Window_0 = null;

		public GClass16(int int_25)
		{
			iwin32Window_0 = new Class42
			{
				intptr_0 = new IntPtr(int_25)
			};
		}

		public GClass16(IntPtr intptr_0)
		{
			iwin32Window_0 = new Class42
			{
				intptr_0 = intptr_0
			};
		}

		public GClass16(IWin32Window iwin32Window_1)
		{
			iwin32Window_0 = iwin32Window_1;
		}

		public bool IsImmOpen()
		{
			int num = ImmGetContext(iwin32Window_0.Handle);
			if (num == 0)
			{
				return false;
			}
			bool result = ImmGetOpenStatus(num);
			ImmReleaseContext(iwin32Window_0.Handle, num);
			return result;
		}

		public void method_0(Point point_0)
		{
			SetImmPos(point_0.X, point_0.Y);
		}

		public void SetImmPos(int int_25, int int_26)
		{
			int num = ImmGetContext(iwin32Window_0.Handle);
			if (num != 0)
			{
				Struct2 struct2_ = default(Struct2);
				struct2_.struct4_0.int_0 = int_25;
				struct2_.struct4_0.int_1 = int_26;
				struct2_.int_0 = 2;
				ImmSetCompositionWindow(num, ref struct2_);
				Marshal.GetLastWin32Error();
				ImmReleaseContext(iwin32Window_0.Handle, num);
			}
		}

		public bool BackConversionStatus()
		{
			int num = ImmGetContext(iwin32Window_0.Handle);
			if (num != 0)
			{
				bool result = ImmGetConversionStatus(num, ref int_23, ref int_24);
				ImmReleaseContext(iwin32Window_0.Handle, num);
				return result;
			}
			int_24 = int.MinValue;
			int_23 = int.MinValue;
			return false;
		}

		public bool RestoreConversionStatus()
		{
			if (int_23 != int.MinValue)
			{
				int num = ImmGetContext(iwin32Window_0.Handle);
				if (num != 0)
				{
					int int_ = 0;
					int int_2 = 0;
					ImmGetConversionStatus(num, ref int_, ref int_2);
					ImmSetConversionStatus(num, int_23, int_24);
					ImmReleaseContext(iwin32Window_0.Handle, num);
					return true;
				}
			}
			return false;
		}

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmGetConversionStatus(int int_25, ref int int_26, ref int int_27);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmSetConversionStatus(int int_25, int int_26, int int_27);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern int ImmCreateContext();

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmDestroyContext(int int_25);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmSetStatusWindowPos(int int_25, ref Struct4 struct4_0);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern int ImmGetContext(IntPtr intptr_0);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmReleaseContext(IntPtr intptr_0, int int_25);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmGetOpenStatus(int int_25);

		[DllImport("imm32.dll", CharSet = CharSet.Auto)]
		private static extern bool ImmSetCompositionWindow(int int_25, ref Struct2 struct2_0);
	}
}
