using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass281
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SystemParametersInfo(GEnum67 genum67_0, int int_0, IntPtr intptr_0, int int_1);

		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
		private static extern bool SystemParametersInfo_1(GEnum67 genum67_0, uint uint_0, ref uint uint_1, uint uint_2);

		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
		private static extern bool SystemParametersInfo_2(GEnum67 genum67_0, uint uint_0, ref bool bool_0, uint uint_1);

		public static bool smethod_0()
		{
			bool bool_ = false;
			if (SystemParametersInfo_2(GEnum67.const_34, 0u, ref bool_, 0u))
			{
				return bool_;
			}
			return false;
		}

		public static bool smethod_1()
		{
			bool bool_ = false;
			if (SystemParametersInfo_2(GEnum67.const_62, 0u, ref bool_, 0u))
			{
				return bool_;
			}
			return false;
		}

		public static int smethod_2()
		{
			uint uint_ = 0u;
			if (SystemParametersInfo_1(GEnum67.const_58, 0u, ref uint_, 0u))
			{
				return (int)uint_;
			}
			return -1;
		}
	}
}
