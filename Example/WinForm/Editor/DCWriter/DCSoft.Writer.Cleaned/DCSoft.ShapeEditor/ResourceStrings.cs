using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.ShapeEditor
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class ResourceStrings
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
				int num = 3;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.ShapeEditor.ResourceStrings", typeof(ResourceStrings).Assembly);
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
		///         查找类似 空白=Disabled;触觉减退=BackImage1;触觉消失=BackImage2;触觉过敏或异常=BackImage3;痛觉减退=BackImage4;痛觉消失=BackImage5;痛觉过敏或异常=BackImage6;震动觉减退或异常=BackImage7;位置觉减退或消失=BackImage8;浅感觉全部消失=BackImage9;深浅感觉全部消失=BackImage10;I度=BackImage11;II度=BackImage12;深II度=BackImage13;III三度=Black 的本地化字符串。
		///       </summary>
		internal static string DefaultBackgroundMenuItemSettingString => ResourceManager.GetString("DefaultBackgroundMenuItemSettingString", cultureInfo_0);

		/// <summary>
		///         查找类似 粗细:{0} 的本地化字符串。
		///       </summary>
		internal static string LineWidth_Width => ResourceManager.GetString("LineWidth_Width", cultureInfo_0);

		/// <summary>
		///         查找类似 文本标签 的本地化字符串。
		///       </summary>
		internal static string NewLabelText => ResourceManager.GetString("NewLabelText", cultureInfo_0);

		/// <summary>
		///         查找类似 没有任何文档。 的本地化字符串。
		///       </summary>
		internal static string NoDocument => ResourceManager.GetString("NoDocument", cultureInfo_0);

		internal ResourceStrings()
		{
		}
	}
}
