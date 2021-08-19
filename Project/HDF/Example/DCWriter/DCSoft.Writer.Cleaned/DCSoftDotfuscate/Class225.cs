using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class225 : ICryptoTransform
	{
		private const int int_0 = 2;

		private const int int_1 = 1000;

		private const int int_2 = 16;

		private int int_3;

		private ICryptoTransform icryptoTransform_0;

		private readonly byte[] byte_0;

		private byte[] byte_1;

		private int int_4;

		private byte[] byte_2;

		private HMACSHA1 hmacsha1_0;

		private bool bool_0;

		private bool bool_1;

		public int InputBlockSize => int_3;

		public int OutputBlockSize => int_3;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public Class225(string string_0, byte[] byte_3, int int_5, bool bool_2)
		{
			int num = 18;
			
			if (int_5 != 16 && int_5 != 32)
			{
				throw new Exception("Invalid blocksize " + int_5 + ". Must be 16 or 32.");
			}
			if (byte_3.Length != int_5 / 2)
			{
				throw new Exception("Invalid salt len. Must be " + int_5 / 2 + " for blocksize " + int_5);
			}
			int_3 = int_5;
			byte_1 = new byte[int_3];
			int_4 = 16;
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(string_0, byte_3, 1000);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.ECB
			};
			byte_0 = new byte[int_3];
			byte[] bytes = rfc2898DeriveBytes.GetBytes(int_3);
			byte[] bytes2 = rfc2898DeriveBytes.GetBytes(int_3);
			icryptoTransform_0 = rijndaelManaged.CreateEncryptor(bytes, bytes2);
			byte_2 = rfc2898DeriveBytes.GetBytes(2);
			hmacsha1_0 = new HMACSHA1(bytes2);
			bool_1 = bool_2;
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			if (!bool_1)
			{
				hmacsha1_0.TransformBlock(inputBuffer, inputOffset, inputCount, inputBuffer, inputOffset);
			}
			for (int i = 0; i < inputCount; i++)
			{
				if (int_4 == 16)
				{
					int num = 0;
					while (++byte_0[num] == 0)
					{
						num++;
					}
					icryptoTransform_0.TransformBlock(byte_0, 0, int_3, byte_1, 0);
					int_4 = 0;
				}
				outputBuffer[i + outputOffset] = (byte)(inputBuffer[i + inputOffset] ^ byte_1[int_4++]);
			}
			if (bool_1)
			{
				hmacsha1_0.TransformBlock(outputBuffer, outputOffset, inputCount, outputBuffer, outputOffset);
			}
			return inputCount;
		}

		public byte[] method_0()
		{
			return byte_2;
		}

		public byte[] method_1()
		{
			if (!bool_0)
			{
				byte[] inputBuffer = new byte[0];
				hmacsha1_0.TransformFinalBlock(inputBuffer, 0, 0);
				bool_0 = true;
			}
			return hmacsha1_0.Hash;
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			throw new NotImplementedException("ZipAESTransform.TransformFinalBlock");
		}

		public void Dispose()
		{
			icryptoTransform_0.Dispose();
		}
	}
}
