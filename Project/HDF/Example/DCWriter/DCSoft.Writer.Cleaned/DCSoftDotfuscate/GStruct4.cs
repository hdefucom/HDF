using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public struct GStruct4
	{
		public int int_0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
		public byte[] byte_0;
	}
}
