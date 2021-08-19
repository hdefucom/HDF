using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.MyLicense
{
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class LicenseStrings
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 14;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.MyLicense.LicenseStrings", typeof(LicenseStrings).Assembly);
				}
				return resourceManager_0;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return cultureInfo_0;
			}
			set
			{
				cultureInfo_0 = value;
			}
		}

		internal static string InvalidateApplicationID => ResourceManager.GetString("InvalidateApplicationID", cultureInfo_0);

		internal static string InvalidateCheckFlag => ResourceManager.GetString("InvalidateCheckFlag", cultureInfo_0);

		internal static string InvalidateDesignerEndDate => ResourceManager.GetString("InvalidateDesignerEndDate", cultureInfo_0);

		internal static string InvalidateDog => ResourceManager.GetString("InvalidateDog", cultureInfo_0);

		internal static string InvalidateEndDate => ResourceManager.GetString("InvalidateEndDate", cultureInfo_0);

		internal static string InvalidateFlagID => ResourceManager.GetString("InvalidateFlagID", cultureInfo_0);

		internal static string InvalidateLanguage => ResourceManager.GetString("InvalidateLanguage", cultureInfo_0);

		internal static string InvalidateLicense => ResourceManager.GetString("InvalidateLicense", cultureInfo_0);

		internal static string InvalidatePassword => ResourceManager.GetString("InvalidatePassword", cultureInfo_0);

		internal static string InvalidateSystemID => ResourceManager.GetString("InvalidateSystemID", cultureInfo_0);

		internal static string Lan_AR => ResourceManager.GetString("Lan_AR", cultureInfo_0);

		internal static string Lan_BO => ResourceManager.GetString("Lan_BO", cultureInfo_0);

		internal static string Lan_ZH_CN => ResourceManager.GetString("Lan_ZH_CN", cultureInfo_0);

		internal static string Lan_ZH_TW => ResourceManager.GetString("Lan_ZH_TW", cultureInfo_0);

		internal static string LicnseTo_UserName => ResourceManager.GetString("LicnseTo_UserName", cultureInfo_0);

		internal static string UnknowUser => ResourceManager.GetString("UnknowUser", cultureInfo_0);

		internal static string UnRegister => ResourceManager.GetString("UnRegister", cultureInfo_0);

		internal LicenseStrings()
		{
		}
	}
}
