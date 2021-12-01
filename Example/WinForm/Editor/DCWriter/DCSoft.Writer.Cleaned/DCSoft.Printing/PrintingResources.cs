using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Printing
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class PrintingResources
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
				int num = 18;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Printing.PrintingResources", typeof(PrintingResources).Assembly);
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
		///         查找类似 页脚 的本地化字符串。
		///       </summary>
		internal static string Footer => ResourceManager.GetString("Footer", cultureInfo_0);

		/// <summary>
		///         查找类似 首页页脚 的本地化字符串。
		///       </summary>
		internal static string FooterForFirstPage => ResourceManager.GetString("FooterForFirstPage", cultureInfo_0);

		/// <summary>
		///         查找类似 在多栏分页显示的时候不得执行续打操作。 的本地化字符串。
		///       </summary>
		internal static string ForbitJumpPrintWhenMultiColumns => ResourceManager.GetString("ForbitJumpPrintWhenMultiColumns", cultureInfo_0);

		/// <summary>
		///         查找类似 页眉 的本地化字符串。
		///       </summary>
		internal static string Header => ResourceManager.GetString("Header", cultureInfo_0);

		/// <summary>
		///         查找类似 首页页眉 的本地化字符串。
		///       </summary>
		internal static string HeaderForFirstPage => ResourceManager.GetString("HeaderForFirstPage", cultureInfo_0);

		/// <summary>
		///         查找类似 图片文件(*.jpg,*.jpeg,*.gif,*.png)|*.jpg;*.jpeg;*.gif;*.png 的本地化字符串。
		///       </summary>
		internal static string ImageFileFilter => ResourceManager.GetString("ImageFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 上边距与下边距之和不能大于页面的高度! 的本地化字符串。
		///       </summary>
		internal static string MargeMoreThanPageHeight => ResourceManager.GetString("MargeMoreThanPageHeight", cultureInfo_0);

		/// <summary>
		///         查找类似 左边距与左边距之和不能大于页面的宽度! 的本地化字符串。
		///       </summary>
		internal static string MargeMoreThanPageWidth => ResourceManager.GetString("MargeMoreThanPageWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 没有文档 的本地化字符串。
		///       </summary>
		internal static string NoDocument => ResourceManager.GetString("NoDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 系统中未安装打印机。 的本地化字符串。
		///       </summary>
		internal static string NoPrinter => ResourceManager.GetString("NoPrinter", cultureInfo_0);

		/// <summary>
		///         查找类似 打印当前页（第{0}页） 的本地化字符串。
		///       </summary>
		internal static string PrintCurrentPage_PageIndex => ResourceManager.GetString("PrintCurrentPage_PageIndex", cultureInfo_0);

		/// <summary>
		///         查找类似 打印错误 的本地化字符串。
		///       </summary>
		internal static string PrintError => ResourceManager.GetString("PrintError", cultureInfo_0);

		/// <summary>
		///         查找类似 正在打印文档“0”的第“{1}“页。 的本地化字符串。
		///       </summary>
		internal static string PrintintPage_Name_Index => ResourceManager.GetString("PrintintPage_Name_Index", cultureInfo_0);

		/// <summary>
		///         查找类似 打印结果 的本地化字符串。
		///       </summary>
		internal static string PrintResult => ResourceManager.GetString("PrintResult", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入数字。 的本地化字符串。
		///       </summary>
		internal static string PromptInputNumer => ResourceManager.GetString("PromptInputNumer", cultureInfo_0);

		/// <summary>
		///         查找类似 请将出纸器中已打印好一面的纸取出并将其放回送纸器，然后按下“确定”，继续打印。 的本地化字符串。
		///       </summary>
		internal static string PromptManualDuplex => ResourceManager.GetString("PromptManualDuplex", cultureInfo_0);

		/// <summary>
		///         查找类似 开始打印文档“{0}”。 的本地化字符串。
		///       </summary>
		internal static string StartPrint_Name => ResourceManager.GetString("StartPrint_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string SystemAlert => ResourceManager.GetString("SystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 用户取消操作。 的本地化字符串。
		///       </summary>
		internal static string UserCancelled => ResourceManager.GetString("UserCancelled", cultureInfo_0);

		internal PrintingResources()
		{
		}
	}
}
