using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public class GClass363
	{
		private static Dictionary<MemberInfo, string> dictionary_0 = new Dictionary<MemberInfo, string>();

		private static Dictionary<Assembly, ResourceManager> dictionary_1 = new Dictionary<Assembly, ResourceManager>();

		private static string string_0 = "RSDescript.resx";

		public static void smethod_0()
		{
			dictionary_0.Clear();
			dictionary_1.Clear();
		}

		public static string smethod_1()
		{
			return string_0;
		}

		public static void smethod_2(string string_1)
		{
			string_0 = string_1;
		}
	}
}
