using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public abstract class GClass564 : SymmetricAlgorithm
	{
		public static byte[] smethod_0(byte[] byte_0)
		{
			int num = 12;
			if (byte_0 == null)
			{
				throw new ArgumentNullException("seed");
			}
			if (byte_0.Length == 0)
			{
				throw new ArgumentException("Length is zero", "seed");
			}
			uint[] array = new uint[3]
			{
				305419896u,
				591751049u,
				878082192u
			};
			for (int i = 0; i < byte_0.Length; i++)
			{
				array[0] = GClass548.smethod_0(array[0], byte_0[i]);
				array[1] = array[1] + (byte)array[0];
				array[1] = array[1] * 134775813 + 1;
				array[2] = GClass548.smethod_0(array[2], (byte)(array[1] >> 24));
			}
			return new byte[12]
			{
				(byte)(array[0] & 0xFF),
				(byte)((array[0] >> 8) & 0xFF),
				(byte)((array[0] >> 16) & 0xFF),
				(byte)((array[0] >> 24) & 0xFF),
				(byte)(array[1] & 0xFF),
				(byte)((array[1] >> 8) & 0xFF),
				(byte)((array[1] >> 16) & 0xFF),
				(byte)((array[1] >> 24) & 0xFF),
				(byte)(array[2] & 0xFF),
				(byte)((array[2] >> 8) & 0xFF),
				(byte)((array[2] >> 16) & 0xFF),
				(byte)((array[2] >> 24) & 0xFF)
			};
		}
	}
}
