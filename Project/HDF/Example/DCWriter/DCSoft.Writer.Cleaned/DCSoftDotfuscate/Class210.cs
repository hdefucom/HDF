using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	internal class Class210
	{
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		public static extern uint GetFontData(IntPtr intptr_0, uint uint_0, uint uint_1, byte[] byte_0, uint uint_2);
	}
}
