using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public static class GClass263
	{
		private static Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		public static string smethod_0(string string_0)
		{
			int num = 19;
			if (string.IsNullOrEmpty(string_0))
			{
				return null;
			}
			if (dictionary_0.ContainsKey(string_0))
			{
				return dictionary_0[string_0];
			}
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(string_0 + "\\Clsid");
			if (registryKey != null)
			{
				string text = Convert.ToString(registryKey.GetValue(""));
				registryKey.Close();
				dictionary_0[string_0] = text;
				return text;
			}
			dictionary_0[string_0] = null;
			return null;
		}
	}
}
