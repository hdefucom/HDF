using System.Globalization;
using System.Resources;

namespace DCSoftDotfuscate
{
	internal class Class149
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		internal Class149()
		{
		}

		internal static ResourceManager smethod_0()
		{
			int num = 15;
			if (object.ReferenceEquals(resourceManager_0, null))
			{
				ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.MyLicense.SoftDog.SoftDogResource", typeof(Class149).Assembly);
			}
			return resourceManager_0;
		}

		internal static CultureInfo smethod_1()
		{
			return cultureInfo_0;
		}

		internal static void smethod_2(CultureInfo cultureInfo_1)
		{
			cultureInfo_0 = cultureInfo_1;
		}

		internal static string smethod_3()
		{
			return smethod_0().GetString("NoValidateDog", cultureInfo_0);
		}

		internal static string smethod_4()
		{
			return smethod_0().GetString("YT88Code46", cultureInfo_0);
		}

		internal static string smethod_5()
		{
			return smethod_0().GetString("YT88Code47", cultureInfo_0);
		}

		internal static string smethod_6()
		{
			return smethod_0().GetString("YT88Code81", cultureInfo_0);
		}

		internal static string smethod_7()
		{
			return smethod_0().GetString("YT88Code82", cultureInfo_0);
		}

		internal static string smethod_8()
		{
			return smethod_0().GetString("YT88Code83", cultureInfo_0);
		}

		internal static string smethod_9()
		{
			return smethod_0().GetString("YT88Code88", cultureInfo_0);
		}

		internal static string smethod_10()
		{
			return smethod_0().GetString("YT88Code92", cultureInfo_0);
		}

		internal static string smethod_11()
		{
			return smethod_0().GetString("YT88Code93", cultureInfo_0);
		}

		internal static string smethod_12()
		{
			return smethod_0().GetString("YT88Code94", cultureInfo_0);
		}
	}
}
