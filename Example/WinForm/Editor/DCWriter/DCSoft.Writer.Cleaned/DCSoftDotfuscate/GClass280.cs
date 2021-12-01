using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass280
	{
		[Flags]
		private enum Enum21
		{
			flag_0 = 0x0,
			flag_1 = 0x1,
			flag_2 = 0x2,
			flag_3 = 0x4,
			flag_4 = 0x8,
			flag_5 = 0x10,
			flag_6 = 0x40,
			flag_7 = 0x2000,
			flag_8 = 0x10000,
			flag_9 = 0x110000,
			flag_10 = 0x20000,
			flag_11 = 0x40004
		}

		[DllImport("winmm.dll", SetLastError = true)]
		private static extern bool PlaySound(string string_0, UIntPtr uintptr_0, uint uint_0);

		[DllImport("winmm.dll", SetLastError = true)]
		private static extern long mciSendString(string string_0, StringBuilder stringBuilder_0, int int_0, IntPtr intptr_0);

		[DllImport("winmm.dll")]
		private static extern long sndPlaySound(string string_0, long long_0);

		public static void smethod_0(string string_0)
		{
			PlaySound(string_0, UIntPtr.Zero, 131088u);
		}

		public static void smethod_1(string string_0)
		{
			string string_ = "open " + string_0 + " type WAVEAudio alias MyWav";
			mciSendString(string_, null, 0, IntPtr.Zero);
			mciSendString("play MyWav", null, 0, IntPtr.Zero);
		}

		public static void smethod_2(string string_0)
		{
			sndPlaySound(string_0, 0L);
		}
	}
}
