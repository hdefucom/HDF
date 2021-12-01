using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass144
	{
		public static string smethod_0(string string_0)
		{
			string str = ".dclic";
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), string_0 + str);
		}
	}
}
