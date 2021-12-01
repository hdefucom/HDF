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
	internal class WriterStringsCore
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
				int num = 7;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterStringsCore", typeof(WriterStringsCore).Assembly);
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
		///         查找类似 控件尚未加载，请不要在窗口或控件的构造函数中调用本功能。 的本地化字符串。
		///       </summary>
		internal static string AlertControlNotLoaded => ResourceManager.GetString("AlertControlNotLoaded", cultureInfo_0);

		/// <summary>
		///         查找类似 所有文件|*.* 的本地化字符串。
		///       </summary>
		internal static string AllFileFilter => ResourceManager.GetString("AllFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 参数“{0}”值为“{1}”，超出范围，最大值“{2}”，最小值“{3}”。 的本地化字符串。
		///       </summary>
		internal static string ArgumentOutOfRange_Name_Value_Max_Min => ResourceManager.GetString("ArgumentOutOfRange_Name_Value_Max_Min", cultureInfo_0);

		/// <summary>
		///         查找类似 .NET程序集文件(*.dll,*.exe)|*.dll;*.exe|所有文件|*.* 的本地化字符串。
		///       </summary>
		internal static string AssemblyFileFilter => ResourceManager.GetString("AssemblyFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 [程序未加密] 的本地化字符串。
		///       </summary>
		internal static string AssemblyUnObfuscation => ResourceManager.GetString("AssemblyUnObfuscation", cultureInfo_0);

		/// <summary>
		///         查找类似 参数“{0}”数据类型错误，类型“{1}”，数据"{3}"。 的本地化字符串。
		///       </summary>
		internal static string BadParameterValueType_Name_Type_Value => ResourceManager.GetString("BadParameterValueType_Name_Type_Value", cultureInfo_0);

		/// <summary>
		///         查找类似 开始读取文件“{0}”。 的本地化字符串。
		///       </summary>
		internal static string BeginReadFile_Name => ResourceManager.GetString("BeginReadFile_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 开始写文件“{0}”，数据字节长度{1}。 的本地化字符串。
		///       </summary>
		internal static string BeginWriteFile_Name_Bytes => ResourceManager.GetString("BeginWriteFile_Name_Bytes", cultureInfo_0);

		/// <summary>
		///         查找类似 在属性中自动创建变量对象实例，默认为false。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_AutoCreateInstanceInProperty => ResourceManager.GetString("BehaviorOptions_AutoCreateInstanceInProperty", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义的检查病历编号不通过的禁止提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，禁止执行本次操作。” 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_CustomPromptForbitCheckMRID => ResourceManager.GetString("BehaviorOptions_CustomPromptForbitCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 自定义的检查病历编号不通过的警告提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，不建议执行本次操作，是否继续？”。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_CustomWarringCheckMRID => ResourceManager.GetString("BehaviorOptions_CustomWarringCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 系统是否处于调试模式。若为true，则系统处于调试模式，系统会输出一些调试文本信息。默认为false。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_DebugMode => ResourceManager.GetString("BehaviorOptions_DebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 默认的数值编辑器激活模式，默认为None。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_DefaultEditorActiveMode => ResourceManager.GetString("BehaviorOptions_DefaultEditorActiveMode", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器是否处于设计模式。默认为false。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_DesignMode => ResourceManager.GetString("BehaviorOptions_DesignMode", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器在设计模式下仍然允许承载控件，默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_EnableControlHostAtDesignTime => ResourceManager.GetString("BehaviorOptions_EnableControlHostAtDesignTime", cultureInfo_0);

		/// <summary>
		///         查找类似 允许执行内容复制,默认true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_EnableCopySource => ResourceManager.GetString("BehaviorOptions_EnableCopySource", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用数据源绑定，如果为false，则编辑器不执行数据源绑定。默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_EnableDataBinding => ResourceManager.GetString("BehaviorOptions_EnableDataBinding", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许表达式。如果为false，则系统不执行表达式，级联模板功能也无法运行。默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_EnableExpression => ResourceManager.GetString("BehaviorOptions_EnableExpression", cultureInfo_0);

		/// <summary>
		///         查找类似 允许VBA宏脚本。默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_EnableScript => ResourceManager.GetString("BehaviorOptions_EnableScript", cultureInfo_0);

		/// <summary>
		///         查找类似 全文违禁关键字列表，可包含多个违禁关键字，各个关键字之间用半角逗号分开。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_ExcludeKeywords => ResourceManager.GetString("BehaviorOptions_ExcludeKeywords", cultureInfo_0);

		/// <summary>
		///         查找类似 强制弹出式数据输入框为TopMost模式，默认为false。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_ForcePopupFormTopMost => ResourceManager.GetString("BehaviorOptions_ForcePopupFormTopMost", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档内容时MRID值的检测模式。默认为None。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_InsertDocumentWithCheckMRID => ResourceManager.GetString("BehaviorOptions_InsertDocumentWithCheckMRID", cultureInfo_0);

		/// <summary>
		///         查找类似 在导出RTF文档时是否导出文本输入域的背景文本。默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_OutputBackgroundTextToRTF => ResourceManager.GetString("BehaviorOptions_OutputBackgroundTextToRTF", cultureInfo_0);

		/// <summary>
		///         查找类似 是否输出格式化的XML文本，默认为true。格式化的XML文本带有缩进控制，阅读方便，但文档比较大。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_OutputFormatedXMLSource => ResourceManager.GetString("BehaviorOptions_OutputFormatedXMLSource", cultureInfo_0);

		/// <summary>
		///         查找类似 文档能否打印。若为false则文档不能打印。默认为true。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_Printable => ResourceManager.GetString("BehaviorOptions_Printable", cultureInfo_0);

		/// <summary>
		///         查找类似 当视图删除无法删除的内容时的提示方式，默认为Details。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_PromptProtectedContent => ResourceManager.GetString("BehaviorOptions_PromptProtectedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 特别的调试模式，内部使用，默认为false。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_SpecifyDebugMode => ResourceManager.GetString("BehaviorOptions_SpecifyDebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 表格单元格操作检测时使用的距离长度，单位为屏幕像素，默认为3。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_TableCellOperationDetectDistance => ResourceManager.GetString("BehaviorOptions_TableCellOperationDetectDistance", cultureInfo_0);

		/// <summary>
		///         查找类似 表格单元格操作检测时使用的距离长度，单位为屏幕像素，默认为3。 的本地化字符串。
		///       </summary>
		internal static string BehaviorOptions_WidelyRaiseFoBehaviorOptions_TableCellOperationDetectDistance => ResourceManager.GetString("BehaviorOptions_WidelyRaiseFoBehaviorOptions_TableCellOperationDetectDistance", cultureInfo_0);

		/// <summary>
		///         查找类似 由 的本地化字符串。
		///       </summary>
		internal static string By => ResourceManager.GetString("By", cultureInfo_0);

		/// <summary>
		///         查找类似 单/复选框组“{0}”必须有勾选项。 的本地化字符串。
		///       </summary>
		internal static string CheckRequired_Name => ResourceManager.GetString("CheckRequired_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 请点击加载控件。 的本地化字符串。
		///       </summary>
		internal static string ClickToLoadControl => ResourceManager.GetString("ClickToLoadControl", cultureInfo_0);

		/// <summary>
		///         查找类似 南京都昌信息科技有限公司 提醒 的本地化字符串。
		///       </summary>
		internal static string CoreSystemAlert => ResourceManager.GetString("CoreSystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 内部版本号 的本地化字符串。
		///       </summary>
		internal static string CoreVersion => ResourceManager.GetString("CoreVersion", cultureInfo_0);

		/// <summary>
		///         查找类似 {DisplaySavedTime:yyyy-MM-dd HH:mm:ss}由{Name}创建 的本地化字符串。
		///       </summary>
		internal static string CreatorTipFormatString => ResourceManager.GetString("CreatorTipFormatString", cultureInfo_0);

		/// <summary>
		///         查找类似 按住Ctrl并鼠标单击可访问链接。 的本地化字符串。
		///       </summary>
		internal static string CtrlClickToLink => ResourceManager.GetString("CtrlClickToLink", cultureInfo_0);

		/// <summary>
		///         查找类似 本文档 的本地化字符串。
		///       </summary>
		internal static string CurrentDocument => ResourceManager.GetString("CurrentDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 南京都昌信息科技有限公司授权给“{0}”。 的本地化字符串。
		///       </summary>
		internal static string DCLicenseTo_Name => ResourceManager.GetString("DCLicenseTo_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 南京都昌科技内部测试版 的本地化字符串。
		///       </summary>
		internal static string DCSoftTestVersion => ResourceManager.GetString("DCSoftTestVersion", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string DCWriterSystemAlert => ResourceManager.GetString("DCWriterSystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 删除 的本地化字符串。
		///       </summary>
		internal static string Delete => ResourceManager.GetString("Delete", cultureInfo_0);

		/// <summary>
		///         查找类似 删除”{0}“ 的本地化字符串。
		///       </summary>
		internal static string DeleteElement_Content => ResourceManager.GetString("DeleteElement_Content", cultureInfo_0);

		/// <summary>
		///         查找类似 删除{0}个元素 的本地化字符串。
		///       </summary>
		internal static string DeleteElements_Count => ResourceManager.GetString("DeleteElements_Count", cultureInfo_0);

		/// <summary>
		///         查找类似 {DisplaySavedTime:yyyy-MM-dd HH:mm:ss}由{Name}删除 的本地化字符串。
		///       </summary>
		internal static string DeleterTipFormatString => ResourceManager.GetString("DeleterTipFormatString", cultureInfo_0);

		/// <summary>
		///         查找类似 无效 的本地化字符串。
		///       </summary>
		internal static string Disable => ResourceManager.GetString("Disable", cultureInfo_0);

		/// <summary>
		///         查找类似 批注 的本地化字符串。
		///       </summary>
		internal static string DocumentComment => ResourceManager.GetString("DocumentComment", cultureInfo_0);

		/// <summary>
		///         查找类似 文档处于设计模式 的本地化字符串。
		///       </summary>
		internal static string DocumentInDesignMode => ResourceManager.GetString("DocumentInDesignMode", cultureInfo_0);

		/// <summary>
		///         查找类似 文档大纲层次 的本地化字符串。
		///       </summary>
		internal static string DocumentOutline => ResourceManager.GetString("DocumentOutline", cultureInfo_0);

		/// <summary>
		///         查找类似 正在下载“{0}”... 的本地化字符串。
		///       </summary>
		internal static string Downloading_URL => ResourceManager.GetString("Downloading_URL", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件是只读的。 的本地化字符串。
		///       </summary>
		internal static string EditControlReadonly => ResourceManager.GetString("EditControlReadonly", cultureInfo_0);

		/// <summary>
		///         查找类似 在复制内容时清空输入域的内容，默认为false。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_ClearFieldValueWhenCopy => ResourceManager.GetString("EditOptions_ClearFieldValueWhenCopy", cultureInfo_0);

		/// <summary>
		///         查找类似 复制文档的时候不复制已经被逻辑删除的内容，默认为false。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_CloneWithoutLogicDeletedContent => ResourceManager.GetString("EditOptions_CloneWithoutLogicDeletedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入图片时为容器元素修正图片的宽度，使得图片元素的宽度不会超过容器客户区宽度。默认为true。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_FixWidthWhenInsertImage => ResourceManager.GetString("EditOptions_FixWidthWhenInsertImage", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入表格时为容器元素修正表格的宽度，使得表格元素的宽度不会超过容器客户区宽度，默认true。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_FixWidthWhenInsertTable => ResourceManager.GetString("EditOptions_FixWidthWhenInsertTable", cultureInfo_0);

		/// <summary>
		///         查找类似 预览内容网格线功能时使用的预览文字。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_GridLinePreviewText => ResourceManager.GetString("EditOptions_GridLinePreviewText", cultureInfo_0);

		/// <summary>
		///         查找类似 在插入和删除表格列时是否保持表格的总宽度不变。默认true。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_KeepTableWidthWhenInsertDeleteColumn => ResourceManager.GetString("EditOptions_KeepTableWidthWhenInsertDeleteColumn", cultureInfo_0);

		/// <summary>
		///         查找类似 是否使用Tab键来设置段落首行缩进，默认为true。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_TabKeyToFirstLineIndent => ResourceManager.GetString("EditOptions_TabKeyToFirstLineIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许在表格中最后一个单元格中使用Tab键来新增表格行，默认为true。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_TabKeyToInsertTableRow => ResourceManager.GetString("EditOptions_TabKeyToInsertTableRow", cultureInfo_0);

		/// <summary>
		///         查找类似 文档数据校验模式，默认为LostFocus。 的本地化字符串。
		///       </summary>
		internal static string EditOptions_ValueValidateMode => ResourceManager.GetString("EditOptions_ValueValidateMode", cultureInfo_0);

		/// <summary>
		///         查找类似 文档元素不属于任何一个文档。 的本地化字符串。
		///       </summary>
		internal static string ElementNoBelongToDocument => ResourceManager.GetString("ElementNoBelongToDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 条码 的本地化字符串。
		///       </summary>
		internal static string ElementType_Barcode => ResourceManager.GetString("ElementType_Barcode", cultureInfo_0);

		/// <summary>
		///         查找类似 文件块  的本地化字符串。
		///       </summary>
		internal static string ElementType_Block => ResourceManager.GetString("ElementType_Block", cultureInfo_0);

		/// <summary>
		///         查找类似 文档正文 的本地化字符串。
		///       </summary>
		internal static string ElementType_Body => ResourceManager.GetString("ElementType_Body", cultureInfo_0);

		/// <summary>
		///         查找类似 字符 的本地化字符串。
		///       </summary>
		internal static string ElementType_Char => ResourceManager.GetString("ElementType_Char", cultureInfo_0);

		/// <summary>
		///         查找类似 复选框 的本地化字符串。
		///       </summary>
		internal static string ElementType_CheckBox => ResourceManager.GetString("ElementType_CheckBox", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注 的本地化字符串。
		///       </summary>
		internal static string ElementType_Comment => ResourceManager.GetString("ElementType_Comment", cultureInfo_0);

		/// <summary>
		///         查找类似 内容链接 的本地化字符串。
		///       </summary>
		internal static string ElementType_ContentLink => ResourceManager.GetString("ElementType_ContentLink", cultureInfo_0);

		/// <summary>
		///         查找类似 控件宿主 的本地化字符串。
		///       </summary>
		internal static string ElementType_ControlHost => ResourceManager.GetString("ElementType_ControlHost", cultureInfo_0);

		/// <summary>
		///         查找类似 文档 的本地化字符串。
		///       </summary>
		internal static string ElementType_Document => ResourceManager.GetString("ElementType_Document", cultureInfo_0);

		/// <summary>
		///         查找类似 页脚 的本地化字符串。
		///       </summary>
		internal static string ElementType_Footer => ResourceManager.GetString("ElementType_Footer", cultureInfo_0);

		/// <summary>
		///         查找类似 页眉 的本地化字符串。
		///       </summary>
		internal static string ElementType_Header => ResourceManager.GetString("ElementType_Header", cultureInfo_0);

		/// <summary>
		///         查找类似 水平线 的本地化字符串。
		///       </summary>
		internal static string ElementType_HL => ResourceManager.GetString("ElementType_HL", cultureInfo_0);

		/// <summary>
		///         查找类似 图片 的本地化字符串。
		///       </summary>
		internal static string ElementType_Image => ResourceManager.GetString("ElementType_Image", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域 的本地化字符串。
		///       </summary>
		internal static string ElementType_InputField => ResourceManager.GetString("ElementType_InputField", cultureInfo_0);

		/// <summary>
		///         查找类似 文本标签 的本地化字符串。
		///       </summary>
		internal static string ElementType_Label => ResourceManager.GetString("ElementType_Label", cultureInfo_0);

		/// <summary>
		///         查找类似 断行符 的本地化字符串。
		///       </summary>
		internal static string ElementType_LineBreak => ResourceManager.GetString("ElementType_LineBreak", cultureInfo_0);

		/// <summary>
		///         查找类似 分页符 的本地化字符串。
		///       </summary>
		internal static string ElementType_PageBreak => ResourceManager.GetString("ElementType_PageBreak", cultureInfo_0);

		/// <summary>
		///         查找类似 页码 的本地化字符串。
		///       </summary>
		internal static string ElementType_PageInfo => ResourceManager.GetString("ElementType_PageInfo", cultureInfo_0);

		/// <summary>
		///         查找类似 段落符号 的本地化字符串。
		///       </summary>
		internal static string ElementType_ParagraphFlag => ResourceManager.GetString("ElementType_ParagraphFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 单选框 的本地化字符串。
		///       </summary>
		internal static string ElementType_RadioBox => ResourceManager.GetString("ElementType_RadioBox", cultureInfo_0);

		/// <summary>
		///         查找类似 锁定符 的本地化字符串。
		///       </summary>
		internal static string ElementType_Sign => ResourceManager.GetString("ElementType_Sign", cultureInfo_0);

		/// <summary>
		///         查找类似 表格 的本地化字符串。
		///       </summary>
		internal static string ElementType_Table => ResourceManager.GetString("ElementType_Table", cultureInfo_0);

		/// <summary>
		///         查找类似 单元格 的本地化字符串。
		///       </summary>
		internal static string ElementType_TableCell => ResourceManager.GetString("ElementType_TableCell", cultureInfo_0);

		/// <summary>
		///         查找类似 表格列 的本地化字符串。
		///       </summary>
		internal static string ElementType_TableColumn => ResourceManager.GetString("ElementType_TableColumn", cultureInfo_0);

		/// <summary>
		///         查找类似 表格行 的本地化字符串。
		///       </summary>
		internal static string ElementType_TableRow => ResourceManager.GetString("ElementType_TableRow", cultureInfo_0);

		/// <summary>
		///         查找类似 有效 的本地化字符串。
		///       </summary>
		internal static string Enable => ResourceManager.GetString("Enable", cultureInfo_0);

		/// <summary>
		///         查找类似 错误 的本地化字符串。
		///       </summary>
		internal static string Error => ResourceManager.GetString("Error", cultureInfo_0);

		/// <summary>
		///         查找类似 出现违禁关键字“{0}”。 的本地化字符串。
		///       </summary>
		internal static string ExcludeKeyword_Keyword => ResourceManager.GetString("ExcludeKeyword_Keyword", cultureInfo_0);

		/// <summary>
		///         查找类似 元素“{0}”响应事件“{1}”，执行脚本方法“{2}”。 的本地化字符串。
		///       </summary>
		internal static string ExecuteEventScript_Element_Event_Method => ResourceManager.GetString("ExecuteEventScript_Element_Event_Method", cultureInfo_0);

		/// <summary>
		///         查找类似 失败。 的本地化字符串。
		///       </summary>
		internal static string Fail => ResourceManager.GetString("Fail", cultureInfo_0);

		/// <summary>
		///         查找类似 文件名 的本地化字符串。
		///       </summary>
		internal static string FileName => ResourceManager.GetString("FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 DCWriter是南京都昌信息科技有限公司自主研发的专业的电子病历文档编辑器。 的本地化字符串。
		///       </summary>
		internal static string GridLinePreviewText => ResourceManager.GetString("GridLinePreviewText", cultureInfo_0);

		/// <summary>
		///         查找类似 有 {0} 个编译错误。 的本地化字符串。
		///       </summary>
		internal static string HasCompilerErrors_Num => ResourceManager.GetString("HasCompilerErrors_Num", cultureInfo_0);

		/// <summary>
		///         查找类似 页眉 的本地化字符串。
		///       </summary>
		internal static string Header => ResourceManager.GetString("Header", cultureInfo_0);

		/// <summary>
		///         查找类似 承载的控件类型名称为空。 的本地化字符串。
		///       </summary>
		internal static string HostControlTypeIsEmpty => ResourceManager.GetString("HostControlTypeIsEmpty", cultureInfo_0);

		/// <summary>
		///         查找类似 承载的控件列表 的本地化字符串。
		///       </summary>
		internal static string HostedControlList => ResourceManager.GetString("HostedControlList", cultureInfo_0);

		/// <summary>
		///         查找类似 Html文件(*.htm,*.html)|*.htm;*.html 的本地化字符串。
		///       </summary>
		internal static string HtmlFileFilter => ResourceManager.GetString("HtmlFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 发现重复的元素ID值“{0}”。 的本地化字符串。
		///       </summary>
		internal static string IDRepeat_ID => ResourceManager.GetString("IDRepeat_ID", cultureInfo_0);

		/// <summary>
		///         查找类似 图片格式的PDF文件(*.image.pdf)|*.image.pdf 的本地化字符串。
		///       </summary>
		internal static string ImagePDFFilter => ResourceManager.GetString("ImagePDFFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 输入 的本地化字符串。
		///       </summary>
		internal static string Input => ResourceManager.GetString("Input", cultureInfo_0);

		/// <summary>
		///         查找类似 插入“{0}” 的本地化字符串。
		///       </summary>
		internal static string InsertElement_Content => ResourceManager.GetString("InsertElement_Content", cultureInfo_0);

		/// <summary>
		///         查找类似 插入{0}个元素 的本地化字符串。
		///       </summary>
		internal static string InsertElements_Count => ResourceManager.GetString("InsertElements_Count", cultureInfo_0);

		/// <summary>
		///         查找类似 控件类型{0}无效，应该是{1}。 的本地化字符串。
		///       </summary>
		internal static string InvalidateControlType_Type_ExpectType => ResourceManager.GetString("InvalidateControlType_Type_ExpectType", cultureInfo_0);

		/// <summary>
		///         查找类似 未找到OCX类型“{0}”，可能没有注册该类型。 的本地化字符串。
		///       </summary>
		internal static string InvalidateOCXType_Name => ResourceManager.GetString("InvalidateOCXType_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 无效的页面设置，请仔细调整文档页面设置。 的本地化字符串。
		///       </summary>
		internal static string InvalidatePageSettings => ResourceManager.GetString("InvalidatePageSettings", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”无效。 的本地化字符串。
		///       </summary>
		internal static string InvalidateType_Name => ResourceManager.GetString("InvalidateType_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 不能跨越UI线程直接调用本方法，请调用控件的Invoke或者BeginInvok方法。 的本地化字符串。
		///       </summary>
		internal static string InvokeRequired => ResourceManager.GetString("InvokeRequired", cultureInfo_0);

		/// <summary>
		///         查找类似 有{0}个项目。 的本地化字符串。
		///       </summary>
		internal static string Items_Count => ResourceManager.GetString("Items_Count", cultureInfo_0);

		/// <summary>
		///         查找类似 受限功能 的本地化字符串。
		///       </summary>
		internal static string LimitedFunction => ResourceManager.GetString("LimitedFunction", cultureInfo_0);

		/// <summary>
		///         查找类似 第{0}页 第{1}行 第{2}列。 的本地化字符串。
		///       </summary>
		internal static string LineInfo_PageIndex_LineIndex_ColumnIndex => ResourceManager.GetString("LineInfo_PageIndex_LineIndex_ColumnIndex", cultureInfo_0);

		/// <summary>
		///         查找类似 加载完成，共加载了{0}。 的本地化字符串。
		///       </summary>
		internal static string LoadComplete_Size => ResourceManager.GetString("LoadComplete_Size", cultureInfo_0);

		/// <summary>
		///         查找类似 正在加载文件“{0}”... 的本地化字符串。
		///       </summary>
		internal static string Loading_FileName => ResourceManager.GetString("Loading_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 正在以 {1} 格式加载文件“{0}”... 的本地化字符串。
		///       </summary>
		internal static string Loading_FileName_Format => ResourceManager.GetString("Loading_FileName_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 正在恢复文档“{0}”... 的本地化字符串。
		///       </summary>
		internal static string LoadingAutoSave_FileID => ResourceManager.GetString("LoadingAutoSave_FileID", cultureInfo_0);

		/// <summary>
		///         查找类似 已经根据加密狗进行了软件注册了。 的本地化字符串。
		///       </summary>
		internal static string LoadLicenseFromDog => ResourceManager.GetString("LoadLicenseFromDog", cultureInfo_0);

		/// <summary>
		///         查找类似 使用“{0}”成功为“{1}”加载了{2}个列表项目。 的本地化字符串。
		///       </summary>
		internal static string LoadListItems_ProviderType_Name_Num => ResourceManager.GetString("LoadListItems_ProviderType_Name_Num", cultureInfo_0);

		/// <summary>
		///         查找类似 从缓存区加载列表项目，名称“{0}”，来源“{1}”。 的本地化字符串。
		///       </summary>
		internal static string LoadListItemsFromBuffer_Name_URL => ResourceManager.GetString("LoadListItemsFromBuffer_Name_URL", cultureInfo_0);

		/// <summary>
		///         查找类似 页数 的本地化字符串。
		///       </summary>
		internal static string LocalNumOfPagesText => ResourceManager.GetString("LocalNumOfPagesText", cultureInfo_0);

		/// <summary>
		///         查找类似 页码 的本地化字符串。
		///       </summary>
		internal static string LocalPageIndexText => ResourceManager.GetString("LocalPageIndexText", cultureInfo_0);

		/// <summary>
		///         查找类似 未找到类型“{0}”的成员“{1}”。 的本地化字符串。
		///       </summary>
		internal static string MemberNotFound_Type_Member => ResourceManager.GetString("MemberNotFound_Type_Member", cultureInfo_0);

		/// <summary>
		///         查找类似 WEB存档,单一文件(*.mht)|*.mht 的本地化字符串。
		///       </summary>
		internal static string MHTFileFilter => ResourceManager.GetString("MHTFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 没能找到属性“{0}”。 的本地化字符串。
		///       </summary>
		internal static string MissProperty_Name => ResourceManager.GetString("MissProperty_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”不存在属性“{1}”。 的本地化字符串。
		///       </summary>
		internal static string MissProperty_Type_Name => ResourceManager.GetString("MissProperty_Type_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”必须标记为可二进制序列化。 的本地化字符串。
		///       </summary>
		internal static string MustMarkSerializableAttribute_TypeName => ResourceManager.GetString("MustMarkSerializableAttribute_TypeName", cultureInfo_0);

		/// <summary>
		///         查找类似 需要首先设置OwnerDocument属性值。 的本地化字符串。
		///       </summary>
		internal static string NeedSetOwnerDocument => ResourceManager.GetString("NeedSetOwnerDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 没有文档。 的本地化字符串。
		///       </summary>
		internal static string NoDocument => ResourceManager.GetString("NoDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 没有图片 的本地化字符串。
		///       </summary>
		internal static string NoImage => ResourceManager.GetString("NoImage", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持以“{0}”格式进行存储。 的本地化字符串。
		///       </summary>
		internal static string NotSupportSerialize_Format => ResourceManager.GetString("NotSupportSerialize_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持以纯文本格式存储为“{0}”文件格式。 的本地化字符串。
		///       </summary>
		internal static string NotSupportSerializeText_Format => ResourceManager.GetString("NotSupportSerializeText_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持保存“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportWrite_Format => ResourceManager.GetString("NotSupportWrite_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 总页数 的本地化字符串。
		///       </summary>
		internal static string NumOfPagesText => ResourceManager.GetString("NumOfPagesText", cultureInfo_0);

		/// <summary>
		///         查找类似 打开本地文件 的本地化字符串。
		///       </summary>
		internal static string OpenLocalFile => ResourceManager.GetString("OpenLocalFile", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器行为方面的选项 的本地化字符串。
		///       </summary>
		internal static string Options_BehaviorOptions => ResourceManager.GetString("Options_BehaviorOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑方面的选项 的本地化字符串。
		///       </summary>
		internal static string Options_EditOptions => ResourceManager.GetString("Options_EditOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 安全和权限方面的设置 的本地化字符串。
		///       </summary>
		internal static string Options_SecurityOptions => ResourceManager.GetString("Options_SecurityOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 文档视图方面的选项 的本地化字符串。
		///       </summary>
		internal static string Options_ViewOptions => ResourceManager.GetString("Options_ViewOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件配置选项 的本地化字符串。
		///       </summary>
		internal static string Options_WriterControlOptions => ResourceManager.GetString("Options_WriterControlOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 文档元素尚未属于某个文档，无法执行操作。 的本地化字符串。
		///       </summary>
		internal static string OwnerDocumentNUll => ResourceManager.GetString("OwnerDocumentNUll", cultureInfo_0);

		/// <summary>
		///         查找类似 下页边距 的本地化字符串。
		///       </summary>
		internal static string PageBottomMargin => ResourceManager.GetString("PageBottomMargin", cultureInfo_0);

		/// <summary>
		///         查找类似 分页符 的本地化字符串。
		///       </summary>
		internal static string PageBreak => ResourceManager.GetString("PageBreak", cultureInfo_0);

		/// <summary>
		///         查找类似 页码 的本地化字符串。
		///       </summary>
		internal static string PageIndexText => ResourceManager.GetString("PageIndexText", cultureInfo_0);

		/// <summary>
		///         查找类似 左页边距 的本地化字符串。
		///       </summary>
		internal static string PageLeftMargin => ResourceManager.GetString("PageLeftMargin", cultureInfo_0);

		/// <summary>
		///         查找类似 右页边距 的本地化字符串。
		///       </summary>
		internal static string PageRightMargin => ResourceManager.GetString("PageRightMargin", cultureInfo_0);

		/// <summary>
		///         查找类似 上页边距 的本地化字符串。
		///       </summary>
		internal static string PageTopMargin => ResourceManager.GetString("PageTopMargin", cultureInfo_0);

		/// <summary>
		///         查找类似 首行缩进 的本地化字符串。
		///       </summary>
		internal static string ParagraphFirstLineIndent => ResourceManager.GetString("ParagraphFirstLineIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 左缩进 的本地化字符串。
		///       </summary>
		internal static string ParagraphLeftIndent => ResourceManager.GetString("ParagraphLeftIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 右缩进 的本地化字符串。
		///       </summary>
		internal static string ParagraphRightIndent => ResourceManager.GetString("ParagraphRightIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 PDF文件(*.pdf)|*.pdf 的本地化字符串。
		///       </summary>
		internal static string PDFFilter => ResourceManager.GetString("PDFFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 打印完成。 的本地化字符串。
		///       </summary>
		internal static string PrintComplete => ResourceManager.GetString("PrintComplete", cultureInfo_0);

		/// <summary>
		///         查找类似 正在打印 {0} 页... 的本地化字符串。
		///       </summary>
		internal static string PrintPage_PageIndex => ResourceManager.GetString("PrintPage_PageIndex", cultureInfo_0);

		/// <summary>
		///         查找类似 本软件已授权给“{0}”，请插入授权加密狗。若要加密狗请联系南京都昌信息科技有限公司。请不要破解盗版国产软件，支持民族产业。 的本地化字符串。
		///       </summary>
		internal static string PromptDevelopmentDog_Name => ResourceManager.GetString("PromptDevelopmentDog_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 程序禁止从外部获得数据。 的本地化字符串。
		///       </summary>
		internal static string PromptDisableOSClipboardData => ResourceManager.GetString("PromptDisableOSClipboardData", cultureInfo_0);

		/// <summary>
		///         查找类似 警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，禁止执行本次操作。 的本地化字符串。
		///       </summary>
		internal static string PromptForbitPasteMRID_ID_SourceID => ResourceManager.GetString("PromptForbitPasteMRID_ID_SourceID", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入文本 的本地化字符串。
		///       </summary>
		internal static string PromptInputText => ResourceManager.GetString("PromptInputText", cultureInfo_0);

		/// <summary>
		///         查找类似 知识库节点“{0}”无法应用于当前文档。 的本地化字符串。
		///       </summary>
		internal static string PromptInvalidateKBEntryRangeMask_Name => ResourceManager.GetString("PromptInvalidateKBEntryRangeMask_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 系统设置为粘贴或插入内容时不能接收超过{0}个字符。 的本地化字符串。
		///       </summary>
		internal static string PromptMaxTextLengthForPaste_Length => ResourceManager.GetString("PromptMaxTextLengthForPaste_Length", cultureInfo_0);

		/// <summary>
		///         查找类似 系统错误：本计算机系统没能启用MD5加密功能，导致本软件功能不可用。请设置"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\FipsAlgorithmPolicy"下的Enabled键值为0。 的本地化字符串。
		///       </summary>
		internal static string PromptMD5Enabled => ResourceManager.GetString("PromptMD5Enabled", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”未找到属性“{1}”。 的本地化字符串。
		///       </summary>
		internal static string PromptNotFontProperty_TypeName_PropertyName => ResourceManager.GetString("PromptNotFontProperty_TypeName_PropertyName", cultureInfo_0);

		/// <summary>
		///         查找类似 有内容受到保护，操作受到限制或无法执行。 的本地化字符串。
		///       </summary>
		internal static string PromptProtectedContent => ResourceManager.GetString("PromptProtectedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 请注册本软件，以更好的支持软件开发商。 的本地化字符串。
		///       </summary>
		internal static string PromptRegister => ResourceManager.GetString("PromptRegister", cultureInfo_0);

		/// <summary>
		///         查找类似 系统被设定为拒绝“{0}”格式的数据。 的本地化字符串。
		///       </summary>
		internal static string PromptRejectFormat_Format => ResourceManager.GetString("PromptRejectFormat_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 已成功启动后台更新程序，请关闭本软件等待１分钟后重新进入。 的本地化字符串。
		///       </summary>
		internal static string PromptUpdateAssembly => ResourceManager.GetString("PromptUpdateAssembly", cultureInfo_0);

		/// <summary>
		///         查找类似 属性“{0}”不能有参数。 的本地化字符串。
		///       </summary>
		internal static string PropertyCannotHasParameter_Name => ResourceManager.GetString("PropertyCannotHasParameter_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 属性“{0}”是只读的。 的本地化字符串。
		///       </summary>
		internal static string PropertyIsReadonly_Name => ResourceManager.GetString("PropertyIsReadonly_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”的属性“{1}”是只读的。 的本地化字符串。
		///       </summary>
		internal static string PropertyReadonly_Type_Name => ResourceManager.GetString("PropertyReadonly_Type_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 读取了虚拟文件系统“{0}”中的文件“{1}”，返回{2}。 的本地化字符串。
		///       </summary>
		internal static string ReadFileByFileSystem_SystemName_FileName_Result => ResourceManager.GetString("ReadFileByFileSystem_SystemName_FileName_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 以URL方式读取文件“{0}”，返回了{1}。 的本地化字符串。
		///       </summary>
		internal static string ReadFileByURL_URL_Result => ResourceManager.GetString("ReadFileByURL_URL_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 {0}类型的元素不能接受{1}类型的子元素。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyCannotAcceptElementType_ParentType_ChildType => ResourceManager.GetString("ReadonlyCannotAcceptElementType_ParentType_ChildType", cultureInfo_0);

		/// <summary>
		///         查找类似 不能删除输入域的背景文本。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyCanNotDeleteBackgroundText => ResourceManager.GetString("ReadonlyCanNotDeleteBackgroundText", cultureInfo_0);

		/// <summary>
		///         查找类似 不能删除输入域边界元素。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyCanNotDeleteBorderElement => ResourceManager.GetString("ReadonlyCanNotDeleteBorderElement", cultureInfo_0);

		/// <summary>
		///         查找类似 任何时候都不能删除最后一个段落符号。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyCanNotDeleteLastParagraphFlag => ResourceManager.GetString("ReadonlyCanNotDeleteLastParagraphFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 容器元素设置为内容只读。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyContainerReadonly => ResourceManager.GetString("ReadonlyContainerReadonly", cultureInfo_0);

		/// <summary>
		///         查找类似 内容被锁定。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyContentLocked => ResourceManager.GetString("ReadonlyContentLocked", cultureInfo_0);

		/// <summary>
		///         查找类似 由于强制设置了内容保护而导致内容只读。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyContentProtect => ResourceManager.GetString("ReadonlyContentProtect", cultureInfo_0);

		/// <summary>
		///         查找类似 元素“{0}”被标记为不能删除。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyElementMarkUndeleteable_ID => ResourceManager.GetString("ReadonlyElementMarkUndeleteable_ID", cultureInfo_0);

		/// <summary>
		///         查找类似 由于控件处于表单模式而导致文档元素只读。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyFormViewMode => ResourceManager.GetString("ReadonlyFormViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 同等级的用户内容是只读的。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyForSameLevelContent => ResourceManager.GetString("ReadonlyForSameLevelContent", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域"{0}"的内容设置为不能直接修改。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyInputFieldUserEditable_ID => ResourceManager.GetString("ReadonlyInputFieldUserEditable_ID", cultureInfo_0);

		/// <summary>
		///         查找类似 内容已经被逻辑删除了，无法再次删除。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyLogicDeleted => ResourceManager.GetString("ReadonlyLogicDeleted", cultureInfo_0);

		/// <summary>
		///         查找类似 权限等级不够，当前等级为{0}，所需等级{1}。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyLowPermissionLevel_CurLevel_NeedLevel => ResourceManager.GetString("ReadonlyLowPermissionLevel_CurLevel_NeedLevel", cultureInfo_0);

		/// <summary>
		///         查找类似 由于授权控制而导致内容只读。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyPermission => ResourceManager.GetString("ReadonlyPermission", cultureInfo_0);

		/// <summary>
		///         查找类似 在用户事件处理中设置为内容只读了。 的本地化字符串。
		///       </summary>
		internal static string ReadonlyUserEvent => ResourceManager.GetString("ReadonlyUserEvent", cultureInfo_0);

		/// <summary>
		///         查找类似 正在刷新文档批注... 的本地化字符串。
		///       </summary>
		internal static string RefreshDocumentComments => ResourceManager.GetString("RefreshDocumentComments", cultureInfo_0);

		/// <summary>
		///         查找类似 正在计算文档内容排版... 的本地化字符串。
		///       </summary>
		internal static string RefreshingDocumentLayout => ResourceManager.GetString("RefreshingDocumentLayout", cultureInfo_0);

		/// <summary>
		///         查找类似 正在计算文档元素大小... 的本地化字符串。
		///       </summary>
		internal static string RefreshingDocumentSize => ResourceManager.GetString("RefreshingDocumentSize", cultureInfo_0);

		/// <summary>
		///         查找类似 正在进行分页操作 的本地化字符串。
		///       </summary>
		internal static string RefreshingPage => ResourceManager.GetString("RefreshingPage", cultureInfo_0);

		/// <summary>
		///         查找类似 注册失败。 的本地化字符串。
		///       </summary>
		internal static string RegiserFail => ResourceManager.GetString("RegiserFail", cultureInfo_0);

		/// <summary>
		///         查找类似 注册成功。 的本地化字符串。
		///       </summary>
		internal static string RegisterOK => ResourceManager.GetString("RegisterOK", cultureInfo_0);

		/// <summary>
		///         查找类似 本软件已注册，授权给“{0}”。 的本地化字符串。
		///       </summary>
		internal static string RegisterTitle_UserName => ResourceManager.GetString("RegisterTitle_UserName", cultureInfo_0);

		/// <summary>
		///         查找类似 自助注册失败！请插入正确的加密狗，或者联系南京都昌信息技术有限公司。 的本地化字符串。
		///       </summary>
		internal static string RegisterWithBitchFail => ResourceManager.GetString("RegisterWithBitchFail", cultureInfo_0);

		/// <summary>
		///         查找类似 元素{0}重复绑定了数据源{1}。 的本地化字符串。
		///       </summary>
		internal static string RepeatDataBinging_Element_DataSource => ResourceManager.GetString("RepeatDataBinging_Element_DataSource", cultureInfo_0);

		/// <summary>
		///          查找类似 DCWriter电子病历编辑器提醒您：电脑中必须需要安装微软.NET框架2.0SP2或更高版本。
		///       DOTNET框架2.0SP2-32位安装文件下载地址：
		///       http://download.microsoft.com/download/c/6/e/c6e88215-0178-4c6c-b5f3-158ff77b1f38/NetFx20SP2_x86.exe
		///       DOTNET框架2.0SP2-64位安装文件下载地址：
		///       http://download.microsoft.com/download/c/6/e/c6e88215-0178-4c6c-b5f3-158ff77b1f38/NetFx20SP2_x64.exe 的本地化字符串。
		///        </summary>
		internal static string RequiredNET20SP2 => ResourceManager.GetString("RequiredNET20SP2", cultureInfo_0);

		/// <summary>
		///         查找类似 表格行已经在表格中了。 的本地化字符串。
		///       </summary>
		internal static string RowExistInTable => ResourceManager.GetString("RowExistInTable", cultureInfo_0);

		/// <summary>
		///         查找类似 RTF文件(*.rtf)|*.rtf 的本地化字符串。
		///       </summary>
		internal static string RTFFileFilter => ResourceManager.GetString("RTFFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 保存本地文件 的本地化字符串。
		///       </summary>
		internal static string SaveLocalFile => ResourceManager.GetString("SaveLocalFile", cultureInfo_0);

		/// <summary>
		///         查找类似 {0}个脚本项目。 的本地化字符串。
		///       </summary>
		internal static string ScriptItems_Count => ResourceManager.GetString("ScriptItems_Count", cultureInfo_0);

		/// <summary>
		///         查找类似 执行逻辑删除。默认为false。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_EnableLogicDelete => ResourceManager.GetString("SecurityOptions_EnableLogicDelete", cultureInfo_0);

		/// <summary>
		///         查找类似 启用文档内容安全和权限控制。若为false则不启用，文档内容可任意编辑。默认为false。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_EnablePermission => ResourceManager.GetString("SecurityOptions_EnablePermission", cultureInfo_0);

		/// <summary>
		///         查找类似 使用强权文档签名。若设置为false，则高权限的用户仍然可以修改低权限签名锁定的内容。默认为true。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_PowerfulSignDocument => ResourceManager.GetString("SecurityOptions_PowerfulSignDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 用户能物理删除自己曾经输入的内容。默认为false。例如用户“张三”曾经输入一段文字保存后在被其他高权限的用户修改掉了，然后“张三”再次登录来打开文档修改此前由本人输入的内容。若RealDeleteOwnerContent选项值为true，则此时进行的是物理删除，不会留下任何痕迹；若RealDeleteOwnerContent选项值为false，则此时进行的是逻辑删除，会留下修改痕迹。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_RealDeleteOwnerContent => ResourceManager.GetString("SecurityOptions_RealDeleteOwnerContent", cultureInfo_0);

		/// <summary>
		///         查找类似 显示被逻辑删除的元素。默认为false。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_ShowLogicDeletedContent => ResourceManager.GetString("SecurityOptions_ShowLogicDeletedContent", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示授权标记。若为true，则用蓝色下划线标记出高权限用户输入的内容，使用删除线标记出被逻辑删除的内容。默认为false。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_ShowPermissionMark => ResourceManager.GetString("SecurityOptions_ShowPermissionMark", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示授权相关的提示信息，若为true，则在编辑器中当鼠标移动到文档内容时，会以提示文本的方式显示文档内容权限和痕迹信息。默认为true。 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_ShowPermissionTip => ResourceManager.GetString("SecurityOptions_ShowPermissionTip", cultureInfo_0);

		/// <summary>
		///         查找类似 等级0的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_TrackVisibleLevel0 => ResourceManager.GetString("SecurityOptions_TrackVisibleLevel0", cultureInfo_0);

		/// <summary>
		///         查找类似 等级1的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_TrackVisibleLevel1 => ResourceManager.GetString("SecurityOptions_TrackVisibleLevel1", cultureInfo_0);

		/// <summary>
		///         查找类似 等级2的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_TrackVisibleLevel2 => ResourceManager.GetString("SecurityOptions_TrackVisibleLevel2", cultureInfo_0);

		/// <summary>
		///         查找类似 等级大于等于3的用户痕迹可视化选项 的本地化字符串。
		///       </summary>
		internal static string SecurityOptions_TrackVisibleLevel3 => ResourceManager.GetString("SecurityOptions_TrackVisibleLevel3", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string SystemAlert => ResourceManager.GetString("SystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string TipTitle => ResourceManager.GetString("TipTitle", cultureInfo_0);

		/// <summary>
		///         查找类似 背景色，默认为透明色。 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_BackgroundColor => ResourceManager.GetString("TrackVisibleConfig_BackgroundColor", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线的颜色，默认为红色。 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_DeleteLineColor => ResourceManager.GetString("TrackVisibleConfig_DeleteLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线的个数，默认为1。 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_DeleteLineNum => ResourceManager.GetString("TrackVisibleConfig_DeleteLineNum", cultureInfo_0);

		/// <summary>
		///         查找类似 配置是否可用，默认为true。 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_Enabled => ResourceManager.GetString("TrackVisibleConfig_Enabled", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线颜色，默认为蓝色。 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_UnderLineColor => ResourceManager.GetString("TrackVisibleConfig_UnderLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线个数，默认为1. 的本地化字符串。
		///       </summary>
		internal static string TrackVisibleConfig_UnderLineColorNum => ResourceManager.GetString("TrackVisibleConfig_UnderLineColorNum", cultureInfo_0);

		/// <summary>
		///         查找类似 TXT文件(*.txt)|*.txt 的本地化字符串。
		///       </summary>
		internal static string TXTFileFilter => ResourceManager.GetString("TXTFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 【DCWriter未注册】 的本地化字符串。
		///       </summary>
		internal static string UnRegisterFormTitlePrefix => ResourceManager.GetString("UnRegisterFormTitlePrefix", cultureInfo_0);

		/// <summary>
		///         查找类似 DCWriter文本编辑器[未注册]第[%pageindex%]页共[%pagecount%]页 的本地化字符串。
		///       </summary>
		internal static string UnRegisterPageTitle => ResourceManager.GetString("UnRegisterPageTitle", cultureInfo_0);

		/// <summary>
		///         查找类似 本软件未注册。 的本地化字符串。
		///       </summary>
		internal static string UnRegisterTitle => ResourceManager.GetString("UnRegisterTitle", cultureInfo_0);

		/// <summary>
		///         查找类似 用户处理了读文件"{0}"的事件，返回了{1}。 的本地化字符串。
		///       </summary>
		internal static string UserHandleReadFileEvent_FileName_Result => ResourceManager.GetString("UserHandleReadFileEvent_FileName_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 用户处理了写文件的事件，返回了{0}。 的本地化字符串。
		///       </summary>
		internal static string UserHandleWriteFileEvent_Result => ResourceManager.GetString("UserHandleWriteFileEvent_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 数据校验错误 的本地化字符串。
		///       </summary>
		internal static string ValueInvalidate => ResourceManager.GetString("ValueInvalidate", cultureInfo_0);

		/// <summary>
		///         查找类似 对象“{0}”内容为“{1}”，数据校验错误“{2}”。 的本地化字符串。
		///       </summary>
		internal static string ValueInvalidate_Source_Value_Result => ResourceManager.GetString("ValueInvalidate_Source_Value_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 版本 的本地化字符串。
		///       </summary>
		internal static string Version => ResourceManager.GetString("Version", cultureInfo_0);

		/// <summary>
		///         查找类似 字段域的背景文本颜色，默认为灰色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_BackgroundTextColor => ResourceManager.GetString("ViewOptions_BackgroundTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注时间格式化字符串。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_CommentDateFormatString => ResourceManager.GetString("ViewOptions_CommentDateFormatString", cultureInfo_0);

		/// <summary>
		///         查找类似 文档批注字体大小，默认为10. 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_CommentFontSize => ResourceManager.GetString("ViewOptions_CommentFontSize", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域默认的文本颜色，默认为透明色，也就是该设置无效 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_DefaultInputFieldTextColor => ResourceManager.GetString("ViewOptions_DefaultInputFieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 下拉列表字体大小，默认为9. 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_DropdownListFontSize => ResourceManager.GetString("ViewOptions_DropdownListFontSize", cultureInfo_0);

		/// <summary>
		///         查找类似 是否允许视图加密显示，默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_EnableEncryptView => ResourceManager.GetString("ViewOptions_EnableEncryptView", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用输入域文字颜色，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_EnableFieldTextColor => ResourceManager.GetString("ViewOptions_EnableFieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 允许执行从右到左排版,当允许从右到左排版时会影响一些性能。当确定不再使用从右到左的功能时，可以设置该选项为false来提高一些性能。默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_EnableRightToLeft => ResourceManager.GetString("ViewOptions_EnableRightToLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域的默认背景颜色，默认为浅蓝色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldBackColor => ResourceManager.GetString("ViewOptions_FieldBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域获得输入焦点时的高亮度背景颜色,默认为淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldFocusedBackColor => ResourceManager.GetString("ViewOptions_FieldFocusedBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 鼠标悬浮在文本输入域时文本输入域的高亮度背景颜色，默认为淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldHoverBackColor => ResourceManager.GetString("ViewOptions_FieldHoverBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域数据异常时的高亮度背景色，默认为全透明。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldInvalidateValueBackColor => ResourceManager.GetString("ViewOptions_FieldInvalidateValueBackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文本输入域数据异常时的高亮度文本色，默认为淡红色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldInvalidateValueForeColor => ResourceManager.GetString("ViewOptions_FieldInvalidateValueForeColor", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域文字颜色，和EnableFieldTextColor搭配使用，默认为黑色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_FieldTextColor => ResourceManager.GetString("ViewOptions_FieldTextColor", cultureInfo_0);

		/// <summary>
		///         查找类似 文档网格线颜色，默认为灰色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_GridLineColor => ResourceManager.GetString("ViewOptions_GridLineColor", cultureInfo_0);

		/// <summary>
		///         查找类似 打印的时候忽略掉输入域边界元素,是其不占据位置，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_IgnoreFieldBorderWhenPrint => ResourceManager.GetString("ViewOptions_IgnoreFieldBorderWhenPrint", cultureInfo_0);

		/// <summary>
		///         查找类似 内容排版方向，默认为LeftToRight。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_LayoutDirection => ResourceManager.GetString("ViewOptions_LayoutDirection", cultureInfo_0);

		/// <summary>
		///         查找类似 表格列的最小宽度，单位为1/300英寸，默认为50。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_MinTableColumnWidth => ResourceManager.GetString("ViewOptions_MinTableColumnWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 绘制隐藏的边框线使用的颜色。默认淡灰色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_NoneBorderColor => ResourceManager.GetString("ViewOptions_NoneBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 常规的输入域的边界元素颜色，用户可以在常规的输入域中直接输入内容。该属性值默认为蓝色 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_NormalFieldBorderColor => ResourceManager.GetString("ViewOptions_NormalFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 是否启用旧的计算空格的算法，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_OldWhitespaceWidth => ResourceManager.GetString("ViewOptions_OldWhitespaceWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时是否显示输入域的背景文字，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_PrintBackgroundText => ResourceManager.GetString("ViewOptions_PrintBackgroundText", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时是否打印网格线，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_PrintGridLine => ResourceManager.GetString("ViewOptions_PrintGridLine", cultureInfo_0);

		/// <summary>
		///         查找类似 打印时，若图片没有数据，是否打印图片元素的Alt提示文本，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_PrintImageAltText => ResourceManager.GetString("ViewOptions_PrintImageAltText", cultureInfo_0);

		/// <summary>
		///         查找类似 只读输入域的边界元素颜色，默认为灰色 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ReadonlyFieldBorderColor => ResourceManager.GetString("ViewOptions_ReadonlyFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 兼容RTF文本控件模式,若为true，则使得同一个RTF文档，在本编辑器中和标准RichTextBox控件中显示的结果误差比较小。默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_RichTextBoxCompatibility => ResourceManager.GetString("ViewOptions_RichTextBoxCompatibility", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度显示方式，默认为MaskColor方式。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_SelectionHighlight => ResourceManager.GetString("ViewOptions_SelectionHighlight", cultureInfo_0);

		/// <summary>
		///         查找类似 选择区域高亮度遮盖色，本选项和SelectionHighlight搭配使用。默认为半透明淡蓝色。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_SelectionHightlightMaskColor => ResourceManager.GetString("ViewOptions_SelectionHightlightMaskColor", cultureInfo_0);

		/// <summary>
		///         查找类似 作为背景显示单元格编号，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowBackgroundCellID => ResourceManager.GetString("ViewOptions_ShowBackgroundCellID", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示表格单元格的隐藏的边框线默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowCellNoneBorder => ResourceManager.GetString("ViewOptions_ShowCellNoneBorder", cultureInfo_0);

		/// <summary>
		///         查找类似 当单元格设置了表达式，则在右下角显示表达式标记，默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowExpressionFlag => ResourceManager.GetString("ViewOptions_ShowExpressionFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示输入域边框元素,默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowFieldBorderElement => ResourceManager.GetString("ViewOptions_ShowFieldBorderElement", cultureInfo_0);

		/// <summary>
		///         查找类似 是否显示文档网格线，默认为false。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowGridLine => ResourceManager.GetString("ViewOptions_ShowGridLine", cultureInfo_0);

		/// <summary>
		///         查找类似 当页眉有内容时显示页眉下边框线。若为false，则页眉和正文之间就没有分隔横线。默认值为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowHeaderBottomLine => ResourceManager.GetString("ViewOptions_ShowHeaderBottomLine", cultureInfo_0);

		/// <summary>
		///         查找类似 当编辑器处于普通视图模式（不分页），是否显示分页线。默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowPageLine => ResourceManager.GetString("ViewOptions_ShowPageLine", cultureInfo_0);

		/// <summary>
		///         查找类似 显示段落标记。不影响打印，默认为true。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_ShowParagraphFlag => ResourceManager.GetString("ViewOptions_ShowParagraphFlag", cultureInfo_0);

		/// <summary>
		///         查找类似 指定的扩展文档网格线步长,单位为1/300英寸，小于等于0表示无效值，默认为0。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_SpecifyExtenGridLineStep => ResourceManager.GetString("ViewOptions_SpecifyExtenGridLineStep", cultureInfo_0);

		/// <summary>
		///         查找类似 在绘制文字时的质量设置。默认为ClearTypeGridFit。 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_TextRenderStyle => ResourceManager.GetString("ViewOptions_TextRenderStyle", cultureInfo_0);

		/// <summary>
		///         查找类似 内容不能被用户直接录入修改的输入域的边界元素颜色，默认为红色 的本地化字符串。
		///       </summary>
		internal static string ViewOptions_UnEditableFieldBorderColor => ResourceManager.GetString("ViewOptions_UnEditableFieldBorderColor", cultureInfo_0);

		/// <summary>
		///         查找类似 警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，不建议执行本次操作，是否继续？ 的本地化字符串。
		///       </summary>
		internal static string WarringPasteMRID_ID_SourceID => ResourceManager.GetString("WarringPasteMRID_ID_SourceID", cultureInfo_0);

		/// <summary>
		///         查找类似 复制到何处？ 的本地化字符串。
		///       </summary>
		internal static string WhereToCopy => ResourceManager.GetString("WhereToCopy", cultureInfo_0);

		/// <summary>
		///         查找类似 移动到何处？ 的本地化字符串。
		///       </summary>
		internal static string WhereToMove => ResourceManager.GetString("WhereToMove", cultureInfo_0);

		/// <summary>
		///         查找类似 输出到虚拟文件系统“{0}”中的文件“{1}”，返回{2}。 的本地化字符串。
		///       </summary>
		internal static string WriteFileByFileSystem_SystemName_FileName_Result => ResourceManager.GetString("WriteFileByFileSystem_SystemName_FileName_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 以URL方式写文件"{0}",返回了{1}。 的本地化字符串。
		///       </summary>
		internal static string WriteFileByURL_URL_Result => ResourceManager.GetString("WriteFileByURL_URL_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件已经被销毁了。 的本地化字符串。
		///       </summary>
		internal static string WriterControlDisposed => ResourceManager.GetString("WriterControlDisposed", cultureInfo_0);

		/// <summary>
		///         查找类似 XML文件|*.xml 的本地化字符串。
		///       </summary>
		internal static string XMLFilter => ResourceManager.GetString("XMLFilter", cultureInfo_0);

		internal WriterStringsCore()
		{
		}
	}
}
