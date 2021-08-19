using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.RTF
{
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class RTFResource
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 10;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.RTF.RTFResource", typeof(RTFResource).Assembly);
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

		internal static string ChildNodeInvalidate => ResourceManager.GetString("ChildNodeInvalidate", cultureInfo_0);

		internal static string GroupLevelError => ResourceManager.GetString("GroupLevelError", cultureInfo_0);

		internal static string GroupNotFinish => ResourceManager.GetString("GroupNotFinish", cultureInfo_0);

		internal static string NotImplemented => ResourceManager.GetString("NotImplemented", cultureInfo_0);

		internal RTFResource()
		{
		}
	}
}
