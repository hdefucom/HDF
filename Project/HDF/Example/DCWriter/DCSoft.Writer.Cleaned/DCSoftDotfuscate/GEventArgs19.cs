using System;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GEventArgs19 : EventArgs
	{
		private string string_0;

		private byte[] byte_0;

		public GEventArgs19(string string_1)
		{
			string_0 = string_1;
		}

		public GEventArgs19(string string_1, byte[] byte_1)
		{
			string_0 = string_1;
			byte_0 = byte_1;
		}

		public string method_0()
		{
			return string_0;
		}

		public byte[] method_1()
		{
			return byte_0;
		}

		public void method_2(byte[] byte_1)
		{
			byte_0 = byte_1;
		}
	}
}
