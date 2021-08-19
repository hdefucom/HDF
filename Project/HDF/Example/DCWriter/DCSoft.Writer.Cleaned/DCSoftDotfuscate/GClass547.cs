using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass547
	{
		public const int int_0 = 51;

		[Obsolete("Use VersionMadeBy instead")]
		public const int int_1 = 51;

		public const int int_2 = 50;

		[Obsolete("Use VersionStrongEncryption instead")]
		public const int int_3 = 50;

		public const int int_4 = 51;

		public const int int_5 = 45;

		public const int int_6 = 30;

		[Obsolete("Use LocalHeaderBaseSize instead")]
		public const int int_7 = 30;

		public const int int_8 = 24;

		public const int int_9 = 16;

		[Obsolete("Use DataDescriptorSize instead")]
		public const int int_10 = 16;

		public const int int_11 = 46;

		[Obsolete("Use CentralHeaderBaseSize instead")]
		public const int int_12 = 46;

		public const int int_13 = 22;

		[Obsolete("Use EndOfCentralRecordBaseSize instead")]
		public const int int_14 = 22;

		public const int int_15 = 12;

		[Obsolete("Use CryptoHeaderSize instead")]
		public const int int_16 = 12;

		public const int int_17 = 67324752;

		[Obsolete("Use LocalHeaderSignature instead")]
		public const int int_18 = 67324752;

		public const int int_19 = 134695760;

		[Obsolete("Use SpanningSignature instead")]
		public const int int_20 = 134695760;

		public const int int_21 = 808471376;

		[Obsolete("Use SpanningTempSignature instead")]
		public const int int_22 = 808471376;

		public const int int_23 = 134695760;

		[Obsolete("Use DataDescriptorSignature instead")]
		public const int int_24 = 134695760;

		[Obsolete("Use CentralHeaderSignature instead")]
		public const int int_25 = 33639248;

		public const int int_26 = 33639248;

		public const int int_27 = 101075792;

		[Obsolete("Use Zip64CentralFileHeaderSignature instead")]
		public const int int_28 = 101075792;

		public const int int_29 = 117853008;

		public const int int_30 = 117853008;

		public const int int_31 = 84233040;

		[Obsolete("Use CentralHeaderDigitalSignaure instead")]
		public const int int_32 = 84233040;

		public const int int_33 = 101010256;

		[Obsolete("Use EndOfCentralDirectorySignature instead")]
		public const int int_34 = 101010256;

		private static int int_35 = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;

		public static int smethod_0()
		{
			return int_35;
		}

		public static void smethod_1(int int_36)
		{
			int_35 = int_36;
		}

		public static string smethod_2(byte[] byte_0, int int_36)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			return Encoding.GetEncoding(smethod_0()).GetString(byte_0, 0, int_36);
		}

		public static string smethod_3(byte[] byte_0)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			return smethod_2(byte_0, byte_0.Length);
		}

		public static string smethod_4(int int_36, byte[] byte_0, int int_37)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			if ((int_36 & 0x800) != 0)
			{
				return Encoding.UTF8.GetString(byte_0, 0, int_37);
			}
			return smethod_2(byte_0, int_37);
		}

		public static string smethod_5(int int_36, byte[] byte_0)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			if ((int_36 & 0x800) != 0)
			{
				return Encoding.UTF8.GetString(byte_0, 0, byte_0.Length);
			}
			return smethod_2(byte_0, byte_0.Length);
		}

		public static byte[] smethod_6(string string_0)
		{
			if (string_0 == null)
			{
				return new byte[0];
			}
			return Encoding.GetEncoding(smethod_0()).GetBytes(string_0);
		}

		public static byte[] smethod_7(int int_36, string string_0)
		{
			if (string_0 == null)
			{
				return new byte[0];
			}
			if ((int_36 & 0x800) != 0)
			{
				return Encoding.UTF8.GetBytes(string_0);
			}
			return smethod_6(string_0);
		}

		private GClass547()
		{
		}
	}
}
