using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public struct GStruct9
	{
		public GEnum46 genum46_0;

		public GDelegate11 gdelegate11_0;

		public int int_0;

		public int int_1;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		private IntPtr intptr_4;

		private IntPtr intptr_5;

		public void method_0(string string_0)
		{
			if (string_0 == null)
			{
				intptr_4 = IntPtr.Zero;
			}
			else
			{
				intptr_4 = Marshal.StringToHGlobalAnsi(string_0);
			}
		}

		public void method_1(string string_0)
		{
			if (string_0 == null)
			{
				intptr_5 = IntPtr.Zero;
			}
			else
			{
				intptr_5 = Marshal.StringToHGlobalAnsi(string_0);
			}
		}
	}
}
