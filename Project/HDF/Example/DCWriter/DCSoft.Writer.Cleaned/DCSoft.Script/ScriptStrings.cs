using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Script
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class ScriptStrings
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
				int num = 13;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Script.ScriptStrings", typeof(ScriptStrings).Assembly);
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
		///         查找类似 分析出VB脚本方法“{0}”。 的本地化字符串。
		///       </summary>
		internal static string AnalyseVBMethod_Name => ResourceManager.GetString("AnalyseVBMethod_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 .NET程序集文件(*.exe,*.dll)|*.dll;*.exe 的本地化字符串。
		///       </summary>
		internal static string AssemblyFileFilter => ResourceManager.GetString("AssemblyFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 清空VB脚本引擎。 的本地化字符串。
		///       </summary>
		internal static string ClearVBAEngine => ResourceManager.GetString("ClearVBAEngine", cultureInfo_0);

		/// <summary>
		///         查找类似 关闭VB脚本引擎。 的本地化字符串。
		///       </summary>
		internal static string CloseVBAEngine => ResourceManager.GetString("CloseVBAEngine", cultureInfo_0);

		/// <summary>
		///         查找类似 编译错误“{0}”。 的本地化字符串。
		///       </summary>
		internal static string CompileError_Message => ResourceManager.GetString("CompileError_Message", cultureInfo_0);

		/// <summary>
		///         查找类似 动态编译结果 的本地化字符串。
		///       </summary>
		internal static string DymamicCompilerResult => ResourceManager.GetString("DymamicCompilerResult", cultureInfo_0);

		/// <summary>
		///         查找类似 错误 的本地化字符串。
		///       </summary>
		internal static string Error => ResourceManager.GetString("Error", cultureInfo_0);

		/// <summary>
		///         查找类似 方法 的本地化字符串。
		///       </summary>
		internal static string Method => ResourceManager.GetString("Method", cultureInfo_0);

		/// <summary>
		///         查找类似 没有发生任何脚本错误。 的本地化字符串。
		///       </summary>
		internal static string NoScriptError => ResourceManager.GetString("NoScriptError", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持的“{0}”语言 的本地化字符串。
		///       </summary>
		internal static string NotSupportLanguage_Language => ResourceManager.GetString("NotSupportLanguage_Language", cultureInfo_0);

		/// <summary>
		///         查找类似 引用 的本地化字符串。
		///       </summary>
		internal static string Reference => ResourceManager.GetString("Reference", cultureInfo_0);

		/// <summary>
		///         查找类似 返回类型 的本地化字符串。
		///       </summary>
		internal static string ReturnType => ResourceManager.GetString("ReturnType", cultureInfo_0);

		/// <summary>
		///         查找类似 运行时错误“{0}”。 的本地化字符串。
		///       </summary>
		internal static string RuntimeError_Message => ResourceManager.GetString("RuntimeError_Message", cultureInfo_0);

		/// <summary>
		///         查找类似 脚本 的本地化字符串。
		///       </summary>
		internal static string Script => ResourceManager.GetString("Script", cultureInfo_0);

		/// <summary>
		///         查找类似 警告：显式加载程序集”{0}“。 的本地化字符串。
		///       </summary>
		internal static string ScriptAsmResolveWarring_Msg => ResourceManager.GetString("ScriptAsmResolveWarring_Msg", cultureInfo_0);

		/// <summary>
		///         查找类似 开始动态编译 的本地化字符串。
		///       </summary>
		internal static string StartDynamicCompile => ResourceManager.GetString("StartDynamicCompile", cultureInfo_0);

		/// <summary>
		///         查找类似 时间 的本地化字符串。
		///       </summary>
		internal static string Time => ResourceManager.GetString("Time", cultureInfo_0);

		/// <summary>
		///         查找类似 引用{0}个程序集，包含{1}个名称空间。 的本地化字符串。
		///       </summary>
		internal static string VBAOptionString_RefCount_NSCount => ResourceManager.GetString("VBAOptionString_RefCount_NSCount", cultureInfo_0);

		/// <summary>
		///         查找类似 运行VB脚本方法“{0}”时发生错误“{1}”！ 的本地化字符串。
		///       </summary>
		internal static string VBARuntimeError_Method_Message => ResourceManager.GetString("VBARuntimeError_Method_Message", cultureInfo_0);

		/// <summary>
		///         查找类似 警告 的本地化字符串。
		///       </summary>
		internal static string Warring => ResourceManager.GetString("Warring", cultureInfo_0);

		internal ScriptStrings()
		{
		}
	}
}
