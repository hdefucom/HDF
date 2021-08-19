using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace DCSoftDotfuscate
{
	internal class Class151
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		internal Class151()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager smethod_0()
		{
			if (object.ReferenceEquals(resourceManager_0, null))
			{
				string baseName = "DCSoft.MyLicense.LicenseStrings";
				ResourceManager resourceManager = resourceManager_0 = new ResourceManager(baseName, typeof(Class151).Assembly);
			}
			return resourceManager_0;
		}

		internal static string smethod_1()
		{
			string name = "InvalidateApplicationID";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_2()
		{
			string name = "InvalidateCheckFlag";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_3()
		{
			string name = "InvalidateDesignerEndDate";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_4()
		{
			string name = "InvalidateDog";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_5()
		{
			string name = "InvalidateEndDate";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_6()
		{
			string name = "InvalidateFlagID";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_7()
		{
			string name = "InvalidateLanguage";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_8()
		{
			string name = "InvalidateLicense";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_9()
		{
			string name = "InvalidatePassword";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_10()
		{
			string name = "InvalidateSystemID";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_11()
		{
			string name = "Lan_AR";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_12()
		{
			string name = "Lan_BO";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_13()
		{
			string name = "Lan_ZH_CN";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_14()
		{
			string name = "Lan_ZH_TW";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_15()
		{
			string name = "LicnseTo_UserName";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_16()
		{
			string name = "UnknowUser";
			return smethod_0().GetString(name, cultureInfo_0);
		}

		internal static string smethod_17()
		{
			string name = "UnRegister";
			return smethod_0().GetString(name, cultureInfo_0);
		}
	}
}
