using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass565 : GClass564
	{
		private byte[] byte_0;

		public override int BlockSize
		{
			get
			{
				return 8;
			}
			set
			{
				int num = 8;
				if (value != 8)
				{
					throw new CryptographicException("Block size is invalid");
				}
			}
		}

		public override byte[] Key
		{
			get
			{
				if (byte_0 == null)
				{
					GenerateKey();
				}
				return (byte[])byte_0.Clone();
			}
			set
			{
				int num = 15;
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != 12)
				{
					throw new CryptographicException("Key size is illegal");
				}
				byte_0 = (byte[])value.Clone();
			}
		}

		public override KeySizes[] LegalBlockSizes => new KeySizes[1]
		{
			new KeySizes(8, 8, 0)
		};

		public override KeySizes[] LegalKeySizes => new KeySizes[1]
		{
			new KeySizes(96, 96, 0)
		};

		public override void GenerateIV()
		{
		}

		public override void GenerateKey()
		{
			byte_0 = new byte[12];
			Random random = new Random();
			random.NextBytes(byte_0);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			byte_0 = rgbKey;
			return new Class218(Key);
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			byte_0 = rgbKey;
			return new Class219(Key);
		}
	}
}
