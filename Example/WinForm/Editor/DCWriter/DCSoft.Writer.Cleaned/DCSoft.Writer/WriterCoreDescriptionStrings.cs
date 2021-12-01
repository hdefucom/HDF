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
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class WriterCoreDescriptionStrings
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
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterCoreDescriptionStrings", typeof(WriterCoreDescriptionStrings).Assembly);
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
		///         查找类似 不只读 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentReadonlyState_False_Description => ResourceManager.GetString("DCSoft_Writer_ContentReadonlyState_False_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 继承上级设置 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentReadonlyState_Inherit_Description => ResourceManager.GetString("DCSoft_Writer_ContentReadonlyState_Inherit_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 只读 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentReadonlyState_True_Description => ResourceManager.GetString("DCSoft_Writer_ContentReadonlyState_True_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动更新 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentUpdateState_AutoUpdate_Description => ResourceManager.GetString("DCSoft_Writer_ContentUpdateState_AutoUpdate_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 已经更新了 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentUpdateState_Updated_Description => ResourceManager.GetString("DCSoft_Writer_ContentUpdateState_Updated_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 只更新一次 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentUpdateState_UpdateOne_Description => ResourceManager.GetString("DCSoft_Writer_ContentUpdateState_UpdateOne_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 全部加密，所有内容加密 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentViewEncryptType_Both_Description => ResourceManager.GetString("DCSoft_Writer_ContentViewEncryptType_Both_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不加密 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentViewEncryptType_None_Description => ResourceManager.GetString("DCSoft_Writer_ContentViewEncryptType_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 部分加密,前面和后面一个字符不加密 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_ContentViewEncryptType_Partial_Description => ResourceManager.GetString("DCSoft_Writer_ContentViewEncryptType_Partial_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动设置可见性 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_FunctionControlVisibility_Auto_Description => ResourceManager.GetString("DCSoft_Writer_Controls_FunctionControlVisibility_Auto_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 一直隐藏 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_FunctionControlVisibility_Hide_Description => ResourceManager.GetString("DCSoft_Writer_Controls_FunctionControlVisibility_Hide_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 一直显示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_FunctionControlVisibility_Visible_Description => ResourceManager.GetString("DCSoft_Writer_Controls_FunctionControlVisibility_Visible_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 收集内容保护信息时触发的事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventCollectProtectedElements_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventCollectProtectedElements_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档内容正在改变事件，可以设置取消标记来取消内容改变操作。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventContentChanged_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventContentChanged_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容正在改变事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventContentChanging_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventContentChanging_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 结束切换输入域焦点事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventEndTabStop_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventEndTabStop_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 检测到内容收到保护时触发的事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventPromptProtectedContent_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventPromptProtectedContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 控件视图缩放事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Controls_WriterControl_EventZoomChanged_Description => ResourceManager.GetString("DCSoft_Writer_Controls_WriterControl_EventZoomChanged_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 部门科室 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Data_EntryOwnerLevel_Department_Description => ResourceManager.GetString("DCSoft_Writer_Data_EntryOwnerLevel_Department_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 拥有等级 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Data_EntryOwnerLevel_EntryOwnerLevel_Description => ResourceManager.GetString("DCSoft_Writer_Data_EntryOwnerLevel_EntryOwnerLevel_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 全局 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Data_EntryOwnerLevel_Global_Description => ResourceManager.GetString("DCSoft_Writer_Data_EntryOwnerLevel_Global_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 用户私有 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Data_EntryOwnerLevel_User_Description => ResourceManager.GetString("DCSoft_Writer_Data_EntryOwnerLevel_User_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 否 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCBooleanValue_False_Description => ResourceManager.GetString("DCSoft_Writer_DCBooleanValue_False_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 继承上级节点 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCBooleanValue_Inherit_Description => ResourceManager.GetString("DCSoft_Writer_DCBooleanValue_Inherit_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 是 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCBooleanValue_True_Description => ResourceManager.GetString("DCSoft_Writer_DCBooleanValue_True_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 总是 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCProcessStates_Always_Description => ResourceManager.GetString("DCSoft_Writer_DCProcessStates_Always_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 从不 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCProcessStates_Never_Description => ResourceManager.GetString("DCSoft_Writer_DCProcessStates_Never_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 一次性 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DCProcessStates_Once_Description => ResourceManager.GetString("DCSoft_Writer_DCProcessStates_Once_Description", cultureInfo_0);

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
		///         查找类似 副本序列化模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CloneSerialize => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CloneSerialize", cultureInfo_0);

		/// <summary>
		///         查找类似 在序列化生成XML/RTF是，采用文档的复制品进行序列化。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_CloneSerialize_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_CloneSerialize_Description", cultureInfo_0);

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
		///         查找类似 压缩用户历史信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableCompressUserHistories => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableCompressUserHistories", cultureInfo_0);

		/// <summary>
		///         查找类似 保存文档时是否压缩用户历史登录信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableCompressUserHistories_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableCompressUserHistories_Description", cultureInfo_0);

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
		///         查找类似 启用文档元素级事件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableElementEvents => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableElementEvents", cultureInfo_0);

		/// <summary>
		///         查找类似 启用文档元素级事件，如果为false，则所有的文档元素级事件无效。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_EnableElementEvents_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_EnableElementEvents_Description", cultureInfo_0);

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
		///         查找类似 插入批注时留痕 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_InsertCommentBindingUserTrack => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_InsertCommentBindingUserTrack", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档批注时是否设置用户痕迹，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_InsertCommentBindingUserTrack_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_InsertCommentBindingUserTrack_Description", cultureInfo_0);

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
		///         查找类似 强权批注操作 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PowerfulCommentCommand => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PowerfulCommentCommand", cultureInfo_0);

		/// <summary>
		///         查找类似 批注编辑操作是否是强大的。如果是强大的则不受授权控制及内容保护的限制。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PowerfulCommentCommand_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PowerfulCommentCommand_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 能否打印 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_Printable => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_Printable", cultureInfo_0);

		/// <summary>
		///         查找类似 文档能否打印。若为false则文档不能打印。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_Printable_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_Printable_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 遇到未包含系统剪切板时进行提示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange", cultureInfo_0);

		/// <summary>
		///         查找类似 遇到未包含系统剪切板时进行提示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForExcludeSystemClipboardRange_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 提示拒绝接受的数据格式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForRejectFormat => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForRejectFormat", cultureInfo_0);

		/// <summary>
		///         查找类似 提示拒绝接受的数据格式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptForRejectFormat_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptForRejectFormat_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容保护提示方式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptProtectedContent => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptProtectedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 当试图删除无法删除的内容时的提示方式，默认为Details。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_PromptProtectedContent_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_PromptProtectedContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 特别的调试模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 特别的调试模式，内部使用，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_SpecifyDebugMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 静态的自动创建属性变量 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_StaticAutoCreateInstanceInProperty => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_StaticAutoCreateInstanceInProperty", cultureInfo_0);

		/// <summary>
		///         查找类似 静态的设置在属性中自动创建变量对象实例 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_StaticAutoCreateInstanceInProperty_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_StaticAutoCreateInstanceInProperty_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 单元格操作检测距离长度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_TableCellOperationDetectDistance => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_TableCellOperationDetectDistance", cultureInfo_0);

		/// <summary>
		///         查找类似 表格单元格操作检测时使用的距离长度，单位为屏幕像素，默认为3。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_TableCellOperationDetectDistance_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_TableCellOperationDetectDistance_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 鼠标三击选取段落 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ThreeClickToSelectParagraph => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ThreeClickToSelectParagraph", cultureInfo_0);

		/// <summary>
		///         查找类似 鼠标连续三击时选取整个段落。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ThreeClickToSelectParagraph_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ThreeClickToSelectParagraph_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 删除批注时校验用户名 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ValidateUserIDWhenEditDeleteComment => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ValidateUserIDWhenEditDeleteComment", cultureInfo_0);

		/// <summary>
		///         查找类似 在删除批注时校验用户名。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_ValidateUserIDWhenEditDeleteComment_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_ValidateUserIDWhenEditDeleteComment_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 脆弱模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_WeakMode => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_WeakMode", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器处于脆弱模式时容易抛出未处理的异常，这有利于错误定位。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_WeakMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_WeakMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 WidelyRaiseFocusEvent 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_WidelyRaiseFocusEvent => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_WidelyRaiseFocusEvent", cultureInfo_0);

		/// <summary>
		///         查找类似 宽范围的触发焦点事件,都昌内部使用。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentBehaviorOptions_WidelyRaiseFocusEvent_Description => ResourceManager.GetString("DCSoft_Writer_DocumentBehaviorOptions_WidelyRaiseFocusEvent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 复制时清空输入域内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_ClearFieldValueWhenCopy => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_ClearFieldValueWhenCopy", cultureInfo_0);

		/// <summary>
		///         查找类似 在复制内容时清空输入域的内容，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_ClearFieldValueWhenCopy_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_ClearFieldValueWhenCopy_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 复制时清除边框样式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CloneWithoutElementBorderStyle => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CloneWithoutElementBorderStyle", cultureInfo_0);

		/// <summary>
		///         查找类似 复制文档时清掉文档元素的边框样式，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CloneWithoutElementBorderStyle_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CloneWithoutElementBorderStyle_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不复制逻辑删除的内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CloneWithoutLogicDeletedContent => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CloneWithoutLogicDeletedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 复制文档的时候不复制已经被逻辑删除的内容，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CloneWithoutLogicDeletedContent_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CloneWithoutLogicDeletedContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 仅以纯文本格式复制 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CopyInTextFormatOnly => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CopyInTextFormatOnly", cultureInfo_0);

		/// <summary>
		///         查找类似 复制的时候仅仅以纯文本格式进行复制。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CopyInTextFormatOnly_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CopyInTextFormatOnly_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 复制时不包含输入域结构信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CopyWithoutInputFieldStructure => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CopyWithoutInputFieldStructure", cultureInfo_0);

		/// <summary>
		///         查找类似 复制文档内容的时候不包含输入域结构信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_CopyWithoutInputFieldStructure_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_CopyWithoutInputFieldStructure_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动调整插入的图片的宽度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertImage => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertImage", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入图片时为容器元素修正图片的宽度，使得图片元素的宽度不会超过容器客户区宽度。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertImage_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertImage_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动调整插入的表格的宽度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertTable => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertTable", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入表格时为容器元素修正表格的宽度，使得表格元素的宽度不会超过容器客户区宽度，默认true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertTable_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_FixWidthWhenInsertTable_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 网格线预览文字 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_GridLinePreviewText => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_GridLinePreviewText", cultureInfo_0);

		/// <summary>
		///         查找类似 预览内容网格线功能时使用的预览文字。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_GridLinePreviewText_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_GridLinePreviewText_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 插入和删除表格列时保持表格宽度不变 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_KeepTableWidthWhenInsertDeleteColumn => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_KeepTableWidthWhenInsertDeleteColumn", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入和删除表格列时是否保持表格的总宽度不变。默认true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_KeepTableWidthWhenInsertDeleteColumn_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_KeepTableWidthWhenInsertDeleteColumn_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 Tab键来设置段落首行缩进 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_TabKeyToFirstLineIndent => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_TabKeyToFirstLineIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 是否使用Tab键来设置段落首行缩进，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_TabKeyToFirstLineIndent_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_TabKeyToFirstLineIndent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 Tab键新增表格行 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_TabKeyToInsertTableRow => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_TabKeyToInsertTableRow", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许在表格中最后一个单元格中使用Tab键来新增表格行，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_TabKeyToInsertTableRow_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_TabKeyToInsertTableRow_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档数据校验模式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_ValueValidateMode => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_ValueValidateMode", cultureInfo_0);

		/// <summary>
		///         查找类似 文档数据校验模式，默认为LostFocus。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentEditOptions_ValueValidateMode_Description => ResourceManager.GetString("DCSoft_Writer_DocumentEditOptions_ValueValidateMode_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 行为选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_BehaviorOptions => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_BehaviorOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件运行时行为方面的选项。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_BehaviorOptions_Description => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_BehaviorOptions_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_EditOptions => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_EditOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件编辑文档时的一些选项。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_EditOptions_Description => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_EditOptions_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 安全方面选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_SecurityOptions => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_SecurityOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 安全方面选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_SecurityOptions_Description => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_SecurityOptions_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 视图选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_ViewOptions => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_ViewOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 视图方面的选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_ViewOptions_Description => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_ViewOptions_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_WriterControlOptions => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_WriterControlOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentOptions_WriterControlOptions_Description => ResourceManager.GetString("DCSoft_Writer_DocumentOptions_WriterControlOptions_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 实时的数据校验 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentValueValidateMode_Dynamic_Description => ResourceManager.GetString("DCSoft_Writer_DocumentValueValidateMode_Dynamic_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 失去输入焦点时才进行数据校验 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentValueValidateMode_LostFocus_Description => ResourceManager.GetString("DCSoft_Writer_DocumentValueValidateMode_LostFocus_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 禁止数据校验 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentValueValidateMode_None_Description => ResourceManager.GetString("DCSoft_Writer_DocumentValueValidateMode_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不自动进行数据校验 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentValueValidateMode_Program_Description => ResourceManager.GetString("DCSoft_Writer_DocumentValueValidateMode_Program_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 字段域背景文本颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_BackgroundTextColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_BackgroundTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 字段域的背景文本颜色，默认为灰色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_BackgroundTextColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_BackgroundTextColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注时间格式化字符串 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_CommentDateFormatString => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_CommentDateFormatString", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注时间格式化字符串。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_CommentDateFormatString_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_CommentDateFormatString_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注字体大小 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_CommentFontSize => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_CommentFontSize", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注字体大小，默认为10. 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_CommentFontSize_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_CommentFontSize_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域默认文本颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_DefaultInputFieldTextColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_DefaultInputFieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域默认的文本颜色，默认为透明色，也就是该设置无效 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_DefaultInputFieldTextColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_DefaultInputFieldTextColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 下拉列表字体大小 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_DropdownListFontSize => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_DropdownListFontSize", cultureInfo_0);

		/// <summary>
		///         查找类似 下拉列表字体大小，默认为9. 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_DropdownListFontSize_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_DropdownListFontSize_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容加密显示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableEncryptView => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableEncryptView", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许视图加密显示，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableEncryptView_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableEncryptView_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用输入域文字颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableFieldTextColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableFieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用输入域文字颜色，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableFieldTextColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableFieldTextColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 允许从右到左排版 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableRightToLeft => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableRightToLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 允许执行从右到左排版,当允许从右到左排版时会影响一些性能。当确定不再使用从右到左的功能时，可以设置该选项为false来提高一些性能。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_EnableRightToLeft_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_EnableRightToLeft_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域默认背景色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldBackColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域的默认背景颜色，默认为浅蓝色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldBackColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldBackColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域边框竖线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldBorderColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域两侧的边框竖线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldBorderColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldBorderColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 当前输入域背景色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldFocusedBackColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldFocusedBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域获得输入焦点时的高亮度背景颜色,默认为淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldFocusedBackColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldFocusedBackColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域鼠标悬浮时背景色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldHoverBackColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldHoverBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 鼠标悬浮在文本输入域时文本输入域的高亮度背景颜色，默认为淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldHoverBackColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldHoverBackColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 数据异常输入域数据背景色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueBackColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域数据异常时的高亮度背景色，默认为全透明。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueBackColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueBackColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 数据异常输入域文本颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueForeColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueForeColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域数据异常时的高亮度文本色，默认为淡红色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueForeColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldInvalidateValueForeColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域文字颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldTextColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域文字颜色，和EnableFieldTextColor搭配使用，默认为黑色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldTextColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldTextColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域文字打印颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldTextPrintColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldTextPrintColor", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域打印时文字颜色，和EnableFieldTextColor搭配使用，默认为黑色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_FieldTextPrintColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_FieldTextPrintColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档网格线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_GridLineColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_GridLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文档网格线颜色，默认为灰色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_GridLineColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_GridLineColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 网格线样式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_GridLineStyle => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_GridLineStyle", cultureInfo_0);

		/// <summary>
		///         查找类似 文档网格线线条样式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_GridLineStyle_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_GridLineStyle_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 高亮度显示被包含的区域 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_HighlightProtectedContent => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_HighlightProtectedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 高亮度显示被包含的区域 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_HighlightProtectedContent_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_HighlightProtectedContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不打印输入域边界元素 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_IgnoreFieldBorderWhenPrint => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_IgnoreFieldBorderWhenPrint", cultureInfo_0);

		/// <summary>
		///         查找类似 打印的时候忽略掉输入域边界元素,是其不占据位置，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_IgnoreFieldBorderWhenPrint_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_IgnoreFieldBorderWhenPrint_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容排版方向 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_LayoutDirection => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_LayoutDirection", cultureInfo_0);

		/// <summary>
		///         查找类似 内容排版方向，默认为LeftToRight。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_LayoutDirection_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_LayoutDirection_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 表格列最小宽度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_MinTableColumnWidth => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_MinTableColumnWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 表格列的最小宽度，单位为1/300英寸，默认为50。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_MinTableColumnWidth_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_MinTableColumnWidth_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 单元格隐藏边框线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_NoneBorderColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_NoneBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 绘制隐藏的边框线使用的颜色。默认淡灰色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_NoneBorderColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_NoneBorderColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 常规输入域边界颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_NormalFieldBorderColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_NormalFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 常规的输入域的边界元素颜色，用户可以在常规的输入域中直接输入内容。该属性值默认为蓝色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_NormalFieldBorderColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_NormalFieldBorderColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用旧的计算空格的算法 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_OldWhitespaceWidth => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_OldWhitespaceWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用旧的计算空格的算法，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_OldWhitespaceWidth_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_OldWhitespaceWidth_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 打印输入域的背景文字 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintBackgroundText => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintBackgroundText", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时是否显示输入域的背景文字，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintBackgroundText_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintBackgroundText_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 打印网格线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintGridLine => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintGridLine", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时是否打印网格线，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintGridLine_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintGridLine_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 允许打印图片提示文本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintImageAltText => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintImageAltText", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时，若图片没有数据，是否打印图片元素的Alt提示文本，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_PrintImageAltText_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_PrintImageAltText_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 只读输入域边界颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ReadonlyFieldBorderColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ReadonlyFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 只读输入域的边界元素颜色，默认为灰色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ReadonlyFieldBorderColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ReadonlyFieldBorderColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 兼容RTF 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_RichTextBoxCompatibility => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_RichTextBoxCompatibility", cultureInfo_0);

		/// <summary>
		///         查找类似 兼容RTF文本控件模式,若为true，则使得同一个RTF文档，在本编辑器中和标准RichTextBox控件中显示的结果误差比较小。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_RichTextBoxCompatibility_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_RichTextBoxCompatibility_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度显示方式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SelectionHighlight => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SelectionHighlight", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度显示方式，默认为MaskColor方式。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SelectionHighlight_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SelectionHighlight_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度遮盖色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SelectionHightlightMaskColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SelectionHightlightMaskColor", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度遮盖色，本选项和SelectionHighlight搭配使用。默认为半透明淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SelectionHightlightMaskColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SelectionHightlightMaskColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 背景显示单元格编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowBackgroundCellID => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowBackgroundCellID", cultureInfo_0);

		/// <summary>
		///         查找类似 作为背景显示单元格编号，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowBackgroundCellID_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowBackgroundCellID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示单元格隐藏边框线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowCellNoneBorder => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowCellNoneBorder", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示表格单元格的隐藏的边框线。当为true时，若表格没有边框线，则在编辑器中也会使用NoneBorderColor选项指定的颜色显示出边框线。该设置不影响打印结果。该选项默认值为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowCellNoneBorder_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowCellNoneBorder_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示单元格表达式标记 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowExpressionFlag => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowExpressionFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 当单元格设置了表达式，则在右下角显示表达式标记，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowExpressionFlag_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowExpressionFlag_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示输入域边框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowFieldBorderElement => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowFieldBorderElement", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示输入域边框元素,默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowFieldBorderElement_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowFieldBorderElement_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示文档网格线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowGridLine => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowGridLine", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示文档网格线，默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowGridLine_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowGridLine_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示页眉下边框线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowHeaderBottomLine => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowHeaderBottomLine", cultureInfo_0);

		/// <summary>
		///         查找类似 当页眉有内容时显示页眉下边框线。若为false，则页眉和正文之间就没有分隔横线。默认值为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowHeaderBottomLine_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowHeaderBottomLine_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示行号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowLineNumber => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowLineNumber", cultureInfo_0);

		/// <summary>
		///         查找类似 在编辑器文档内容左侧显示行号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowLineNumber_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowLineNumber_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示本地化名称 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowLocalizationDisplayName => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowLocalizationDisplayName", cultureInfo_0);

		/// <summary>
		///         查找类似 在属性列表中显示本地化名称 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowLocalizationDisplayName_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowLocalizationDisplayName_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示分页线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowPageLine => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowPageLine", cultureInfo_0);

		/// <summary>
		///         查找类似 当编辑器处于普通视图模式（不分页），是否显示分页线。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowPageLine_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowPageLine_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示段落标记 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowParagraphFlag => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowParagraphFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 显示段落标记。不影响打印，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_ShowParagraphFlag_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_ShowParagraphFlag_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 指定的扩展文档网格线步长 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SpecifyExtenGridLineStep => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SpecifyExtenGridLineStep", cultureInfo_0);

		/// <summary>
		///         查找类似 指定的扩展文档网格线步长,单位为1/300英寸，小于等于0表示无效值，默认为0。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_SpecifyExtenGridLineStep_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_SpecifyExtenGridLineStep_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文字绘制质量 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_TextRenderStyle => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_TextRenderStyle", cultureInfo_0);

		/// <summary>
		///         查找类似 在绘制文字时的质量设置。默认为ClearTypeGridFit。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_TextRenderStyle_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_TextRenderStyle_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 内容受限输入域边界颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_UnEditableFieldBorderColor => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_UnEditableFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 内容不能被用户直接录入修改的输入域的边界元素颜色，默认为红色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_UnEditableFieldBorderColor_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_UnEditableFieldBorderColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用第二语言 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_UseLanguage2 => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_UseLanguage2", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用第二语言 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_DocumentViewOptions_UseLanguage2_Description => ResourceManager.GetString("DCSoft_Writer_DocumentViewOptions_UseLanguage2_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 作者 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Author => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Author", cultureInfo_0);

		/// <summary>
		///         查找类似 作者 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Author_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Author_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 作者姓名 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_AuthorName => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_AuthorName", cultureInfo_0);

		/// <summary>
		///         查找类似 作者姓名 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_AuthorName_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_AuthorName_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 作者授权等级 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_AuthorPermissionLevel => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_AuthorPermissionLevel", cultureInfo_0);

		/// <summary>
		///         查找类似 作者授权等级 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_AuthorPermissionLevel_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_AuthorPermissionLevel_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 注释 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Comment => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Comment", cultureInfo_0);

		/// <summary>
		///         查找类似 注释 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Comment_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Comment_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档创建时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_CreationTime => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_CreationTime", cultureInfo_0);

		/// <summary>
		///         查找类似 文档创建时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_CreationTime_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_CreationTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 部门编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DepartmentID => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DepartmentID", cultureInfo_0);

		/// <summary>
		///         查找类似 部门编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DepartmentID_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DepartmentID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 部门名称 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DepartmentName => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DepartmentName", cultureInfo_0);

		/// <summary>
		///         查找类似 部门名称 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DepartmentName_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DepartmentName_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 说明 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 说明 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Description_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Description_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑状态 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentEditState => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentEditState", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑状态 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentEditState_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentEditState_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文件格式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentFormat => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentFormat", cultureInfo_0);

		/// <summary>
		///         查找类似 文件格式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentFormat_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentFormat_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 操作状态 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentProcessState => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentProcessState", cultureInfo_0);

		/// <summary>
		///         查找类似 操作状态 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentProcessState_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentProcessState_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentType => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentType", cultureInfo_0);

		/// <summary>
		///         查找类似 文档类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_DocumentType_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_DocumentType_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑的分钟数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_EditMinute => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_EditMinute", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑的分钟数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_EditMinute_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_EditMinute_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域边框元素宽度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_FieldBorderElementWidth => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_FieldBorderElementWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域边框元素宽度，单位像素。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_FieldBorderElementWidth_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_FieldBorderElementWidth_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 打印任务中的高度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_HeightInPrintJob => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_HeightInPrintJob", cultureInfo_0);

		/// <summary>
		///         查找类似 打印任务中的高度 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_HeightInPrintJob_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_HeightInPrintJob_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_ID => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_ID", cultureInfo_0);

		/// <summary>
		///         查找类似 文档编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_ID_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_ID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 是否为模板类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_IsTemplate => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_IsTemplate", cultureInfo_0);

		/// <summary>
		///         查找类似 是否为模板类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_IsTemplate_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_IsTemplate_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 知识库节点过滤掩码 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_KBEntryRangeMask => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_KBEntryRangeMask", cultureInfo_0);

		/// <summary>
		///         查找类似 知识库节点过滤掩码 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_KBEntryRangeMask_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_KBEntryRangeMask_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 最后修改时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_LastModifiedTime => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_LastModifiedTime", cultureInfo_0);

		/// <summary>
		///         查找类似 最后修改时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_LastModifiedTime_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_LastModifiedTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 最后打印时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_LastPrintTime => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_LastPrintTime", cultureInfo_0);

		/// <summary>
		///         查找类似 最后打印时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_LastPrintTime_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_LastPrintTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 病历编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_MRID => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_MRID", cultureInfo_0);

		/// <summary>
		///         查找类似 病历编号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_MRID_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_MRID_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 总页数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_NumOfPage => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_NumOfPage", cultureInfo_0);

		/// <summary>
		///         查找类似 总页数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_NumOfPage_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_NumOfPage_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 操作者 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Operator => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Operator", cultureInfo_0);

		/// <summary>
		///         查找类似 操作者 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Operator_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Operator_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 能否打印 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Printable => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Printable", cultureInfo_0);

		/// <summary>
		///         查找类似 能否打印，若设置为false则该文档不能打印。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Printable_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Printable_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示页眉下面的横线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_ShowHeaderBottomLine => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_ShowHeaderBottomLine", cultureInfo_0);

		/// <summary>
		///         查找类似 显示页眉下面的横线 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_ShowHeaderBottomLine_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_ShowHeaderBottomLine_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 打印任务中的开始位置 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_StartPositionInPringJob => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_StartPositionInPringJob", cultureInfo_0);

		/// <summary>
		///         查找类似 打印任务中的开始位置 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_StartPositionInPringJob_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_StartPositionInPringJob_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 超时时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_TimeoutHours => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_TimeoutHours", cultureInfo_0);

		/// <summary>
		///         查找类似 超时时间，单位小时 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_TimeoutHours_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_TimeoutHours_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 标题 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Title => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Title", cultureInfo_0);

		/// <summary>
		///         查找类似 标题 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Title_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Title_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 是否为第二语言 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_UseLanguage2 => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_UseLanguage2", cultureInfo_0);

		/// <summary>
		///         查找类似 是否为第二语言 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_UseLanguage2_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_UseLanguage2_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 版本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Version => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Version", cultureInfo_0);

		/// <summary>
		///         查找类似 版本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_DocumentInfo_Version_Description => ResourceManager.GetString("DCSoft_Writer_Dom_DocumentInfo_Version_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 所有文档类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_All_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_All_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 单选复选框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_CheckRadioBox_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_CheckRadioBox_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Document_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Document_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档域 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Field_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Field_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 图片 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Image_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Image_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_InputField_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_InputField_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 换行符 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_LineBreak_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_LineBreak_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 无效类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_None_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 对象 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Object_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Object_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 分页符 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_PageBreak_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_PageBreak_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 段落符号 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_ParagraphFlag_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_ParagraphFlag_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 表格 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Table_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Table_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 单元格 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_TableCell_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_TableCell_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 表格列 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_TableColumn_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_TableColumn_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 表格行 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_TableRow_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_TableRow_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 纯文本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_ElementType_Text_Description => ResourceManager.GetString("DCSoft_Writer_Dom_ElementType_Text_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 所有时间 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HighlightActiveStyle_AllTime_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HighlightActiveStyle_AllTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 鼠标悬停 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HighlightActiveStyle_Hover_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HighlightActiveStyle_Hover_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 静态 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HighlightActiveStyle_Static_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HighlightActiveStyle_Static_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 自动检测 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_AutoDetect_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_AutoDetect_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 WinForm控件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_Control_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_Control_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 实现了IDocumentImage接口的对象 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_DocumentImage_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_DocumentImage_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 无效的类型 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_InvalidateType_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_InvalidateType_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 OCX控件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_OCX_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_OCX_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 WPF控件 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_HostedControlType_WPF_Description => ResourceManager.GetString("DCSoft_Writer_Dom_HostedControlType_WPF_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 日期框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_Date_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_Date_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 日期时间框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_DateTime_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_DateTime_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 精确到分的日期时间框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_DateTimeWithoutSecond_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_DateTimeWithoutSecond_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 下拉列表 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_DropdownList_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_DropdownList_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 数字框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_Numeric_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_Numeric_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 纯文本 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_Text_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_Text_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 时间框 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_InputFieldEditStyle_Time_Description => ResourceManager.GetString("DCSoft_Writer_Dom_InputFieldEditStyle_Time_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 在本文档中的文档总页数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_PageInfoValueType_LocalNumOfPages_Description => ResourceManager.GetString("DCSoft_Writer_Dom_PageInfoValueType_LocalNumOfPages_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 在本文档中的从1开始计算的页码数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_PageInfoValueType_LocalPageIndex_Description => ResourceManager.GetString("DCSoft_Writer_Dom_PageInfoValueType_LocalPageIndex_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 文档总页数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_PageInfoValueType_NumOfPages_Description => ResourceManager.GetString("DCSoft_Writer_Dom_PageInfoValueType_NumOfPages_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 从1开始计算的页码 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_PageInfoValueType_PageIndex_Description => ResourceManager.GetString("DCSoft_Writer_Dom_PageInfoValueType_PageIndex_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 完整的复制，包括输入域中的内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_TableRowCloneType_Complete_Description => ResourceManager.GetString("DCSoft_Writer_Dom_TableRowCloneType_Complete_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 复制内容，但删除输入域中的内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_TableRowCloneType_ContentWithClearField_Description => ResourceManager.GetString("DCSoft_Writer_Dom_TableRowCloneType_ContentWithClearField_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 默认方式，不复制表格内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Dom_TableRowCloneType_Default_Description => ResourceManager.GetString("DCSoft_Writer_Dom_TableRowCloneType_Default_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 默认 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_EnableState_Default_Description => ResourceManager.GetString("DCSoft_Writer_EnableState_Default_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不可用 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_EnableState_Disabled_Description => ResourceManager.GetString("DCSoft_Writer_EnableState_Disabled_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 可用 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_EnableState_Enabled_Description => ResourceManager.GetString("DCSoft_Writer_EnableState_Enabled_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 若判断不通过则禁止操作 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_InsertDocumentWithCheckMRIDType_ForbitWhenFail_Description => ResourceManager.GetString("DCSoft_Writer_InsertDocumentWithCheckMRIDType_ForbitWhenFail_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 没有设置 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_InsertDocumentWithCheckMRIDType_None_Description => ResourceManager.GetString("DCSoft_Writer_InsertDocumentWithCheckMRIDType_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 若判断不通过则禁止操作，还显示提示信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_InsertDocumentWithCheckMRIDType_PromptForbitWhenFail_Description => ResourceManager.GetString("DCSoft_Writer_InsertDocumentWithCheckMRIDType_PromptForbitWhenFail_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 若判断不通过则显示警告信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_InsertDocumentWithCheckMRIDType_WarringWhenFail_Description => ResourceManager.GetString("DCSoft_Writer_InsertDocumentWithCheckMRIDType_WarringWhenFail_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 默认 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_MoveFocusHotKeys_Default_Description => ResourceManager.GetString("DCSoft_Writer_MoveFocusHotKeys_Default_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 Enter键 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_MoveFocusHotKeys_Enter_Description => ResourceManager.GetString("DCSoft_Writer_MoveFocusHotKeys_Enter_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 移动焦点快捷键 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_MoveFocusHotKeys_MoveFocusHotKeys_Description => ResourceManager.GetString("DCSoft_Writer_MoveFocusHotKeys_MoveFocusHotKeys_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 无快捷键 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_MoveFocusHotKeys_None_Description => ResourceManager.GetString("DCSoft_Writer_MoveFocusHotKeys_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 Tab键 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_MoveFocusHotKeys_Tab_Description => ResourceManager.GetString("DCSoft_Writer_MoveFocusHotKeys_Tab_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示详细信息的提示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_PromptProtectedContentMode_Details_Description => ResourceManager.GetString("DCSoft_Writer_PromptProtectedContentMode_Details_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 不提示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_PromptProtectedContentMode_None_Description => ResourceManager.GetString("DCSoft_Writer_PromptProtectedContentMode_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 简单的提示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_PromptProtectedContentMode_Simple_Description => ResourceManager.GetString("DCSoft_Writer_PromptProtectedContentMode_Simple_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 执行逻辑删除 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_EnableLogicDelete => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_EnableLogicDelete", cultureInfo_0);

		/// <summary>
		///         查找类似 执行逻辑删除。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_EnableLogicDelete_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_EnableLogicDelete_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 启用授权控制 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_EnablePermission => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_EnablePermission", cultureInfo_0);

		/// <summary>
		///         查找类似 启用文档内容安全和权限控制。若为false则不启用，文档内容可任意编辑。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_EnablePermission_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_EnablePermission_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 强权文档签名 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_PowerfulSignDocument => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_PowerfulSignDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 使用强权文档签名。若设置为false，则高权限的用户仍然可以修改低权限签名锁定的内容。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_PowerfulSignDocument_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_PowerfulSignDocument_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 物理删除自己输入的内容 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_RealDeleteOwnerContent => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_RealDeleteOwnerContent", cultureInfo_0);

		/// <summary>
		///         查找类似 用户能物理删除自己曾经输入的内容。默认为false。例如用户“张三”曾经输入一段文字保存后在被其他高权限的用户修改掉了，然后“张三”再次登录来打开文档修改此前由本人输入的内容。若RealDeleteOwnerContent选项值为true，则此时进行的是物理删除，不会留下任何痕迹；若RealDeleteOwnerContent选项值为false，则此时进行的是逻辑删除，会留下修改痕迹。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_RealDeleteOwnerContent_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_RealDeleteOwnerContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示被逻辑删除的元素 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowLogicDeletedContent => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowLogicDeletedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 显示被逻辑删除的元素。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowLogicDeletedContent_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowLogicDeletedContent_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示授权标记 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionMark => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionMark", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示授权标记。若为true，则用蓝色下划线标记出高权限用户输入的内容，使用删除线标记出被逻辑删除的内容。默认为false。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionMark_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionMark_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 显示授权相关的提示信息 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionTip => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionTip", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示授权相关的提示信息，若为true，则在编辑器中当鼠标移动到文档内容时，会以提示文本的方式显示文档内容权限和痕迹信息。默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionTip_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_ShowPermissionTip_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 等级0的可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel0 => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel0", cultureInfo_0);

		/// <summary>
		///         查找类似 等级0的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel0_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel0_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 等级1的可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel1 => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel1", cultureInfo_0);

		/// <summary>
		///         查找类似 等级1的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel1_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel1_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 等级2的可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel2 => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel2", cultureInfo_0);

		/// <summary>
		///         查找类似 等级2的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel2_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel2_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 等级3的可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel3 => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel3", cultureInfo_0);

		/// <summary>
		///         查找类似 等级3的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel3_Description => ResourceManager.GetString("DCSoft_Writer_Security_DocumentSecurityOptions_TrackVisibleLevel3_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 反色高亮度显示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_SelectionHighlightStyle_Invert_Description => ResourceManager.GetString("DCSoft_Writer_SelectionHighlightStyle_Invert_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 使用遮盖色高亮度显示 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_SelectionHighlightStyle_MaskColor_Description => ResourceManager.GetString("DCSoft_Writer_SelectionHighlightStyle_MaskColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 无任何高亮度显示方式 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_SelectionHighlightStyle_None_Description => ResourceManager.GetString("DCSoft_Writer_SelectionHighlightStyle_None_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 背景色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_BackgroundColor => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_BackgroundColor", cultureInfo_0);

		/// <summary>
		///         查找类似 背景色，默认为透明色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_BackgroundColor_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_BackgroundColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_DeleteLineColor => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_DeleteLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线的颜色，默认为红色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_DeleteLineColor_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_DeleteLineColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线个数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_DeleteLineNum => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_DeleteLineNum", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线的个数，默认为1。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_DeleteLineNum_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_DeleteLineNum_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 配置可用 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_Enabled => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_Enabled", cultureInfo_0);

		/// <summary>
		///         查找类似 配置是否可用，默认为true。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_Enabled_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_Enabled_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线颜色 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_UnderLineColor => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_UnderLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线颜色，默认为蓝色。 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_UnderLineColor_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_UnderLineColor_Description", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线个数 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_UnderLineColorNum => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_UnderLineColorNum", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线个数，默认为1. 的本地化字符串。
		///       </summary>
		internal static string DCSoft_Writer_TrackVisibleConfig_UnderLineColorNum_Description => ResourceManager.GetString("DCSoft_Writer_TrackVisibleConfig_UnderLineColorNum_Description", cultureInfo_0);

		internal WriterCoreDescriptionStrings()
		{
		}
	}
}
