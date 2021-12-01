using Microsoft.Win32;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoftDotfuscate
{
	[ComVisible(false)]
	public sealed class GClass305
	{
		private const int int_0 = 1;

		private const int int_1 = 2;

		private const int int_2 = 4;

		private const int int_3 = 8;

		private const int int_4 = 16;

		private const int int_5 = 32;

		private const int int_6 = 64;

		private const int int_7 = 128;

		private const int int_8 = 256;

		private const int int_9 = 512;

		private const int int_10 = 1024;

		private const int int_11 = 2048;

		private const int int_12 = 4096;

		private const int int_13 = 8192;

		private const int int_14 = 16384;

		private const int int_15 = 32768;

		private const int int_16 = 65536;

		private const int int_17 = 131072;

		private const int int_18 = 262144;

		private const int int_19 = 524288;

		private const int int_20 = 1048576;

		private const int int_21 = 2097152;

		public static bool smethod_0(string string_0)
		{
			int num = 15;
			string text = new Guid(string_0).ToString("B");
			RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + text.ToUpper());
			if (registryKey != null)
			{
				registryKey.Close();
				return true;
			}
			registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\" + text.ToLower());
			if (registryKey != null)
			{
				registryKey.Close();
				return true;
			}
			return false;
		}

		private GClass305()
		{
		}

		public static void smethod_1(Type type_0, string string_0)
		{
			int num = 4;
			try
			{
				smethod_3(type_0, "t");
				bool flag = typeof(Control).IsAssignableFrom(type_0);
				string name = "CLSID\\" + type_0.GUID.ToString("B");
				using (RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(name, writable: true))
				{
					registryKey.OpenSubKey("InprocServer32", writable: true)?.SetValue(null, Environment.SystemDirectory + "\\mscoree.dll");
					if (flag)
					{
						using (registryKey.CreateSubKey("Control"))
						{
						}
					}
					using (RegistryKey registryKey3 = registryKey.CreateSubKey("MiscStatus"))
					{
						int num2 = 164241;
						if (!flag)
						{
							num2 |= 0x400;
						}
						registryKey3.SetValue("", num2.ToString(), RegistryValueKind.String);
					}
					if (!string.IsNullOrEmpty(string_0))
					{
						using (RegistryKey registryKey4 = registryKey.CreateSubKey("ToolBoxBitmap32"))
						{
							registryKey4.SetValue("", Assembly.GetExecutingAssembly().Location + ", " + string_0, RegistryValueKind.String);
						}
					}
					using (RegistryKey registryKey5 = registryKey.CreateSubKey("TypeLib"))
					{
						registryKey5.SetValue("", Marshal.GetTypeLibGuidForAssembly(type_0.Assembly).ToString("B"), RegistryValueKind.String);
					}
					using (RegistryKey registryKey6 = registryKey.CreateSubKey("Version"))
					{
						Marshal.GetTypeLibVersionForAssembly(type_0.Assembly, out int majorVersion, out int minorVersion);
						registryKey6.SetValue("", $"{majorVersion}.{minorVersion}");
					}
				}
			}
			catch (Exception exception_)
			{
				smethod_5("ComRegisterFunction failed.", type_0, exception_);
			}
		}

		public static void smethod_2(Type type_0)
		{
			int num = 8;
			try
			{
				smethod_3(type_0, "t");
				smethod_4(type_0);
				string subkey = "CLSID\\" + type_0.GUID.ToString("B");
				Registry.ClassesRoot.DeleteSubKeyTree(subkey);
			}
			catch (Exception exception_)
			{
				smethod_5("ComUnregisterFunction failed.", type_0, exception_);
			}
		}

		private static void smethod_3(Type type_0, string string_0)
		{
			int num = 4;
			if (null == type_0)
			{
				throw new ArgumentException("The CLR type must be specified.", string_0);
			}
		}

		private static void smethod_4(Type type_0)
		{
			int num = 13;
			if (!typeof(Control).IsAssignableFrom(type_0))
			{
				throw new ArgumentException("Type argument must be a Windows Forms control.");
			}
		}

		private static void smethod_5(string string_0, Type type_0, Exception exception_0)
		{
			int num = 8;
			try
			{
				if (null != type_0)
				{
					string_0 = string_0 + Environment.NewLine + $"CLR class '{type_0.FullName}'";
				}
				throw new GException15(string_0, exception_0);
			}
			catch (Exception)
			{
			}
		}
	}
}
