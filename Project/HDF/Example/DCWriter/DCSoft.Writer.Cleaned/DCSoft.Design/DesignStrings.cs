using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Design
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class DesignStrings
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
				int num = 8;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Design.DesignStrings", typeof(DesignStrings).Assembly);
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
		///         查找类似 Web服务页面文件(*.asmx)|*.asmx 的本地化字符串。
		///       </summary>
		internal static string ASMXFileFilter => ResourceManager.GetString("ASMXFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 选择Web服务页面 的本地化字符串。
		///       </summary>
		internal static string ASMXURLPickerCaption => ResourceManager.GetString("ASMXURLPickerCaption", cultureInfo_0);

		/// <summary>
		///         查找类似 ASP.NET页面文件(*.aspx)|*.aspx 的本地化字符串。
		///       </summary>
		internal static string ASPXFileFilter => ResourceManager.GetString("ASPXFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 选择ASP.NET页面 的本地化字符串。
		///       </summary>
		internal static string ASPXURLPickerCaption => ResourceManager.GetString("ASPXURLPickerCaption", cultureInfo_0);

		/// <summary>
		///         查找类似 {0}个类型 的本地化字符串。
		///       </summary>
		internal static string AssemblyContent_Types => ResourceManager.GetString("AssemblyContent_Types", cultureInfo_0);

		/// <summary>
		///         查找类似 .NET程序集文件(*.dll;*.exe)|*.dll;*.exe 的本地化字符串。
		///       </summary>
		internal static string AssemblyFilter => ResourceManager.GetString("AssemblyFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 数据库结构 的本地化字符串。
		///       </summary>
		internal static string DataBaseSchema => ResourceManager.GetString("DataBaseSchema", cultureInfo_0);

		/// <summary>
		///         查找类似 正在加载... 的本地化字符串。
		///       </summary>
		internal static string Loading => ResourceManager.GetString("Loading", cultureInfo_0);

		/// <summary>
		///         查找类似 [共{0}张表，{1}个字段] 的本地化字符串。
		///       </summary>
		internal static string Total_Tables_Fields => ResourceManager.GetString("Total_Tables_Fields", cultureInfo_0);

		internal DesignStrings()
		{
		}
	}
}
