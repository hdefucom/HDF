using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass307
	{
		public void method_0()
		{
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern bool TerminateProcess(IntPtr intptr_0, int int_0);
	}
}
