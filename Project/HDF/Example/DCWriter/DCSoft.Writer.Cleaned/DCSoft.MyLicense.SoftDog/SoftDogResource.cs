using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.MyLicense.SoftDog
{
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class SoftDogResource
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 15;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.MyLicense.SoftDog.SoftDogResource", typeof(SoftDogResource).Assembly);
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

		internal static string NoValidateDog => ResourceManager.GetString("NoValidateDog", cultureInfo_0);

		internal static string YT88Code46 => ResourceManager.GetString("YT88Code46", cultureInfo_0);

		internal static string YT88Code47 => ResourceManager.GetString("YT88Code47", cultureInfo_0);

		internal static string YT88Code81 => ResourceManager.GetString("YT88Code81", cultureInfo_0);

		internal static string YT88Code82 => ResourceManager.GetString("YT88Code82", cultureInfo_0);

		internal static string YT88Code83 => ResourceManager.GetString("YT88Code83", cultureInfo_0);

		internal static string YT88Code88 => ResourceManager.GetString("YT88Code88", cultureInfo_0);

		internal static string YT88Code92 => ResourceManager.GetString("YT88Code92", cultureInfo_0);

		internal static string YT88Code93 => ResourceManager.GetString("YT88Code93", cultureInfo_0);

		internal static string YT88Code94 => ResourceManager.GetString("YT88Code94", cultureInfo_0);

		internal SoftDogResource()
		{
		}
	}
}
