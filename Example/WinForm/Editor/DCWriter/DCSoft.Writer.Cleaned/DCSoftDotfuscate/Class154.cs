using System;
using System.IO;
using System.Text;

namespace DCSoftDotfuscate
{
	internal class Class154
	{
		public static string smethod_0()
		{
			string text = Class155.smethod_11();
			if (text != null)
			{
				return Convert.ToString(1) + text;
			}
			return null;
		}

		public static GEnum21 smethod_1()
		{
			if (Class155.smethod_10())
			{
				return GEnum21.const_1;
			}
			return GEnum21.const_0;
		}

		public static bool smethod_2(string string_0)
		{
			return Class155.smethod_9(string_0);
		}

		public static bool smethod_3(string string_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			BitConverter.GetBytes((short)bytes.Length);
			memoryStream.Write(bytes, 0, bytes.Length);
			byte[] byte_ = memoryStream.ToArray();
			return Class155.smethod_13(byte_);
		}

		public static string smethod_4(string string_0, string string_1)
		{
			byte[] array = Class155.smethod_14(string_0, string_1);
			if (array != null)
			{
				return Encoding.UTF8.GetString(array);
			}
			return null;
		}
	}
}
