using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.WinForms.Controls
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[CompilerGenerated]
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class DCColorPlateResource
	{
		private static ResourceManager resourceManager_0;

		private static CultureInfo cultureInfo_0;

		/// <summary>
		///         返回此类使用的缓存的 ResourceManager 实例。
		///       </summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				int num = 11;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.WinForms.Controls.DCColorPlateResource", typeof(DCColorPlateResource).Assembly);
				}
				return resourceManager_0;
			}
		}

		/// <summary>
		///         使用此强类型资源类，为所有资源查找
		///         重写当前线程的 CurrentUICulture 属性。
		///       </summary>
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

		/// <summary>
		///         查找类似 自动颜色 的本地化字符串。
		///       </summary>
		internal static string AutoColor => ResourceManager.GetString("AutoColor", cultureInfo_0);

		/// <summary>
		///         查找类似 更多颜色... 的本地化字符串。
		///       </summary>
		internal static string MoreColors => ResourceManager.GetString("MoreColors", cultureInfo_0);

		internal static Bitmap palette
		{
			get
			{
				object @object = ResourceManager.GetObject("palette", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找类似 标准颜色 的本地化字符串。
		///       </summary>
		internal static string StandardColors => ResourceManager.GetString("StandardColors", cultureInfo_0);

		/// <summary>
		///         查找类似 主题颜色 的本地化字符串。
		///       </summary>
		internal static string ThemeColors => ResourceManager.GetString("ThemeColors", cultureInfo_0);

		/// <summary>
		///         查找类似 主题颜色 的本地化字符串。
		///       </summary>
		internal static string TransparentColor => ResourceManager.GetString("TransparentColor", cultureInfo_0);

		internal DCColorPlateResource()
		{
		}
	}
}
