using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace DCSoft.Writer
{
	/// <summary>
	///         一个强类型的资源类，用于查找本地化的字符串等。
	///       </summary>
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class WriterDescriptionStrings
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
				int num = 1;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterDescriptionStrings", typeof(WriterDescriptionStrings).Assembly);
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
		///         查找类似 自动创建属性值 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_AutoCreateInstanceInProperty => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_AutoCreateInstanceInProperty", cultureInfo_0);

		/// <summary>
		///         查找类似 在属性中自动创建变量对象实例，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_AutoCreateInstanceInProperty_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_AutoCreateInstanceInProperty_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动忽略最后空白页 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_AutoIgnoreLastEmptyPage => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_AutoIgnoreLastEmptyPage", cultureInfo_0);

		/// <summary>
		///         查找类似 自动忽略最后空白页，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_AutoIgnoreLastEmptyPage_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_AutoIgnoreLastEmptyPage_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义病历校验失败提示信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CustomPromptForbitCheckMRID => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CustomPromptForbitCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义的检查病历编号不通过的禁止提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，禁止执行本次操作。” 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CustomPromptForbitCheckMRID_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CustomPromptForbitCheckMRID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义病历校验警告信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CustomWarringCheckMRID => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CustomWarringCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义的检查病历编号不通过的警告提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，不建议执行本次操作，是否继续？”。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CustomWarringCheckMRID_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CustomWarringCheckMRID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 调试模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DebugMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 系统是否处于调试模式。若为true，则系统处于调试模式，系统会输出一些调试文本信息。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DebugMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DebugMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 默认输入域激活模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DefaultEditorActiveMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DefaultEditorActiveMode", cultureInfo_0);

		/// <summary>
		///         查找类似 默认的数值编辑器激活模式，默认为None。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DefaultEditorActiveMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DefaultEditorActiveMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 设计模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DesignMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DesignMode", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器是否处于设计模式。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DesignMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DesignMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 双击选择单词 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DoubleClickToSelectWord => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DoubleClickToSelectWord", cultureInfo_0);

		/// <summary>
		///         查找类似 双击选择单词 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_DoubleClickToSelectWord_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_DoubleClickToSelectWord_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 设计模式下承载控件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableControlHostAtDesignTime => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableControlHostAtDesignTime", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器在设计模式下仍然允许承载控件，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableControlHostAtDesignTime_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableControlHostAtDesignTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 允许执行内容复制 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableCopySource => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableCopySource", cultureInfo_0);

		/// <summary>
		///         查找类似 允许执行内容复制,默认true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableCopySource_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableCopySource_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用数据源绑定 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableDataBinding => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableDataBinding", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用数据源绑定，如果为false，则编辑器不执行数据源绑定。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableDataBinding_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableDataBinding_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用表达式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableExpression => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableExpression", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许表达式。如果为false，则系统不执行表达式，级联模板功能也无法运行。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableExpression_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableExpression_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 知识节点应用范围掩码 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableKBEntryRangeMask => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableKBEntryRangeMask", cultureInfo_0);

		/// <summary>
		///         查找类似 知识节点应用范围掩码 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableKBEntryRangeMask_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableKBEntryRangeMask_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用VBA脚本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableScript => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableScript", cultureInfo_0);

		/// <summary>
		///         查找类似 允许VBA宏脚本。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableScript_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableScript_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 全局违禁关键字 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ExcludeKeywords => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ExcludeKeywords", cultureInfo_0);

		/// <summary>
		///         查找类似 全局违禁关键字列表，可包含多个违禁关键字，各个关键字之间用半角逗号分开。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ExcludeKeywords_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ExcludeKeywords_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 强制自动分页 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ForceCollateWhenPrint => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ForceCollateWhenPrint", cultureInfo_0);

		/// <summary>
		///         查找类似 .NET框架的一个BUG，导致有时打印多份的时候无法自动分页，此处强制设置自动分页。而不管在打印机设置中是否使用自动分页。这是在没有修正系统BUG时的临时扑救措施。该系统BUG说明可见http://support.microsoft.com/kb/2744968。不建议设置该属性。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ForceCollateWhenPrint_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ForceCollateWhenPrint_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 数据输入框置顶 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ForcePopupFormTopMost => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ForcePopupFormTopMost", cultureInfo_0);

		/// <summary>
		///         查找类似 强制弹出式数据输入框为TopMost模式，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ForcePopupFormTopMost_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ForcePopupFormTopMost_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 校验文档MRID 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_InsertDocumentWithCheckMRID => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_InsertDocumentWithCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档内容时MRID值的检测模式。默认为None。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_InsertDocumentWithCheckMRID_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_InsertDocumentWithCheckMRID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输出背景文本到RTF中 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_OutputBackgroundTextToRTF => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_OutputBackgroundTextToRTF", cultureInfo_0);

		/// <summary>
		///         查找类似 在导出RTF文档时是否导出文本输入域的背景文本。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_OutputBackgroundTextToRTF_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_OutputBackgroundTextToRTF_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输出格式化XML 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_OutputFormatedXMLSource => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_OutputFormatedXMLSource", cultureInfo_0);

		/// <summary>
		///         查找类似 是否输出格式化的XML文本，默认为true。格式化的XML文本带有缩进控制，阅读方便，但文档比较大。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_OutputFormatedXMLSource_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_OutputFormatedXMLSource_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 能否打印 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_Printable => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_Printable", cultureInfo_0);

		/// <summary>
		///         查找类似 文档能否打印。若为false则文档不能打印。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_Printable_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_Printable_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容保护提示方式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange", cultureInfo_0);

		/// <summary>
		///         查找类似 当视图删除无法删除的内容时的提示方式，默认为Details。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 特别的调试模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 特别的调试模式，内部使用，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode_Description", cultureInfo_0);

		internal WriterDescriptionStrings()
		{
		}
	}
}
