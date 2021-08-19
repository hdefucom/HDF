using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass286
	{
		private const string string_0 = "SOFTWARE\\Microsoft\\Internet Explorer";

		private const string string_1 = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";

		private const string string_2 = "Software\\Microsoft\\Internet Explorer";

		public static Process smethod_0(string string_3)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = smethod_2();
			processStartInfo.Arguments = "\"" + string_3 + "\"";
			return Process.Start(processStartInfo);
		}

		public static Process smethod_1(string string_3)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = smethod_2();
			processStartInfo.Arguments = "\"file://" + string_3 + "\"";
			return Process.Start(processStartInfo);
		}

		public static string smethod_2()
		{
			return smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\IEXPLORE.EXE", null);
		}

		public static string smethod_3()
		{
			return smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", "MinorVersion");
		}

		public static string smethod_4()
		{
			return smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Internet Explorer", "Build");
		}

		public static Version smethod_5()
		{
			string text = smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Internet Explorer", "Version");
			if (text == null)
			{
				return new Version();
			}
			return new Version(text);
		}

		public static string smethod_6()
		{
			return smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Internet Explorer", "Version");
		}

		public static Version smethod_7()
		{
			string text = smethod_13(Registry.LocalMachine, "SOFTWARE\\Microsoft\\Internet Explorer\\Version Vector", "VML");
			if (text == null)
			{
				return new Version();
			}
			return new Version(text);
		}

		public static string smethod_8()
		{
			return smethod_13(Registry.CurrentUser, "Software\\Microsoft\\Internet Explorer\\Main", "Local Page");
		}

		public static string smethod_9()
		{
			return smethod_13(Registry.CurrentUser, "Software\\Microsoft\\Internet Explorer\\Main", "Start Page");
		}

		public static bool smethod_10()
		{
			return smethod_13(Registry.CurrentUser, "Software\\Microsoft\\Internet Explorer\\Main", "Disable Script Debugger") == "yes";
		}

		public static string smethod_11()
		{
			return smethod_13(Registry.CurrentUser, "Software\\Microsoft\\Internet Explorer\\Main", "Window Title");
		}

		public static string[] smethod_12()
		{
			string[] array = null;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\TypedURLs");
			if (registryKey != null)
			{
				array = registryKey.GetValueNames();
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = Convert.ToString(registryKey.GetValue(array[i]));
					}
				}
				registryKey.Close();
			}
			return array;
		}

		private static string smethod_13(RegistryKey registryKey_0, string string_3, string string_4)
		{
			object obj = smethod_14(registryKey_0, string_3, string_4);
			if (obj == null)
			{
				return null;
			}
			return Convert.ToString(obj);
		}

		private static object smethod_14(RegistryKey registryKey_0, string string_3, string string_4)
		{
			RegistryKey registryKey = registryKey_0.OpenSubKey(string_3);
			if (registryKey == null)
			{
				return null;
			}
			object value = registryKey.GetValue(string_4);
			registryKey.Close();
			return value;
		}

		private GClass286()
		{
		}
	}
}
