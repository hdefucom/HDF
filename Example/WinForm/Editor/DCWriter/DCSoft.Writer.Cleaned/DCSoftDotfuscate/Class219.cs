using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal class Class219 : Class217, ICryptoTransform
	{
		public int InputBlockSize => 1;

		public int OutputBlockSize => 1;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		internal Class219(byte[] byte_0)
		{
			method_1(byte_0);
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] array = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = inputOffset; i < inputOffset + inputCount; i++)
			{
				byte b = (byte)(inputBuffer[i] ^ method_0());
				outputBuffer[outputOffset++] = b;
				method_2(b);
			}
			return inputCount;
		}

		public void Dispose()
		{
			method_3();
		}
	}
}
