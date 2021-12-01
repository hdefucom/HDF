using DCSoft.RTF;
using System;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class203 : Encoding
	{
		public static Class203 class203_0 = new Class203();

		public override string GetString(byte[] bytes, int index, int count)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = Math.Min(bytes.Length - 1, index + count - 1);
			for (int i = index; i <= num; i++)
			{
				stringBuilder.Append(System.Convert.ToChar(bytes[i]));
			}
			return stringBuilder.ToString();
		}

		public override int GetByteCount(char[] chars, int index, int count)
		{
			throw new Exception(RTFResource.NotImplemented);
		}

		public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
		{
			throw new Exception(RTFResource.NotImplemented);
		}

		public override int GetCharCount(byte[] bytes, int index, int count)
		{
			throw new Exception(RTFResource.NotImplemented);
		}

		public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
		{
			throw new Exception(RTFResource.NotImplemented);
		}

		public override int GetMaxByteCount(int charCount)
		{
			throw new Exception(RTFResource.NotImplemented);
		}

		public override int GetMaxCharCount(int byteCount)
		{
			throw new Exception(RTFResource.NotImplemented);
		}
	}
}
