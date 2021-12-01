using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	internal abstract class Class231 : GClass608
	{
		internal static string smethod_15(sbyte[] sbyte_0, int int_0, int int_1, string string_0)
		{
			int num = 1;
			try
			{
				string @string = Encoding.GetEncoding(string_0).GetString(GClass634.smethod_0(sbyte_0));
				return new string(@string.ToCharArray(), int_0, int_1);
			}
			catch (IOException arg)
			{
				throw new SystemException("Platform does not support required encoding: " + arg);
			}
		}
	}
}
