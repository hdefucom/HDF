using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class WinFormsResources
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
				int num = 16;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.WinForms.WinFormsResources", typeof(WinFormsResources).Assembly);
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
		///         查找类似 当前版本是"{0}"，发现新版本"{1}"，是否更新？ 的本地化字符串。
		///       </summary>
		internal static string AlertUpdate_OldVersion_NewVersion => ResourceManager.GetString("AlertUpdate_OldVersion_NewVersion", cultureInfo_0);

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap CheckBoxChecked
		{
			get
			{
				object @object = ResourceManager.GetObject("CheckBoxChecked", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找 System.Drawing.Bitmap 类型的本地化资源。
		///       </summary>
		internal static Bitmap CheckBoxUnChecked
		{
			get
			{
				object @object = ResourceManager.GetObject("CheckBoxUnChecked", cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		/// <summary>
		///         查找类似 南京都昌信息科技有限公司 www.dcwriter.cn 的本地化字符串。
		///       </summary>
		internal static string DCName => ResourceManager.GetString("DCName", cultureInfo_0);

		/// <summary>
		///         查找类似 正在处理中... 的本地化字符串。
		///       </summary>
		internal static string DefaultWorkingMessage => ResourceManager.GetString("DefaultWorkingMessage", cultureInfo_0);

		/// <summary>
		///         查找类似 图片文件(*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp 的本地化字符串。
		///       </summary>
		internal static string ImageFilter => ResourceManager.GetString("ImageFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 正在加载数据，请稍候。。。 的本地化字符串。
		///       </summary>
		internal static string LoadingPromptText => ResourceManager.GetString("LoadingPromptText", cultureInfo_0);

		/// <summary>
		///         查找类似 已成功启动后台更新程序，请关闭本软件和所有的WEB浏览器（包括IE浏览器，360浏览器，QQ浏览器等等）后等待几分钟后重新进入。 的本地化字符串。
		///       </summary>
		internal static string PromptUpdateAssembly => ResourceManager.GetString("PromptUpdateAssembly", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string SystemAlert => ResourceManager.GetString("SystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 系统错误 的本地化字符串。
		///       </summary>
		internal static string SystemError => ResourceManager.GetString("SystemError", cultureInfo_0);

		/// <summary>
		///         查找类似 系统警告 的本地化字符串。
		///       </summary>
		internal static string SystemWarring => ResourceManager.GetString("SystemWarring", cultureInfo_0);

		internal WinFormsResources()
		{
		}
	}
}
