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
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class WriterStrings
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
				int num = 5;
				if (object.ReferenceEquals(resourceManager_0, null))
				{
					ResourceManager resourceManager = resourceManager_0 = new ResourceManager("DCSoft.Writer.WriterStrings", typeof(WriterStrings).Assembly);
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
		///          查找类似 DCWriter WEB版控件是南京都昌信息科技有限公司完全独立自主研发的新型电子医疗文书编辑器控件，并拥有全部版权。本控件完全使用C#开发，安全可靠，功能强大，性能优良。客户端无需安装任何插件，支持IE/FireFox/Chorme/Safari/UC/Opera等各种浏览器。支持在各种PC平台和移动平台上展示和编辑文档内容。
		///       &lt;br/&gt;    公司网站：http://www.dcwriter.cn，电子邮件：28348092@qq.com。 的本地化字符串。
		///        </summary>
		internal static string AboutWebControl => ResourceManager.GetString("AboutWebControl", cultureInfo_0);

		/// <summary>
		///          查找类似 &lt;br/&gt;-------- 为成功显示出控件，请按照以下方法来做:
		///       &lt;br/&gt;第一，点击[&lt;a href="@CABURL"&gt;@CABURL&lt;/a&gt;]判断能否下载CAB文件。
		///       &lt;br/&gt;第二，客户端安装.NET框架2.0SP2或更高级版本。推荐的微软.NET2.0SP2的下载页面为“http://www.microsoft.com/zh-cn/download/details.aspx?id=1639”。
		///       &lt;br/&gt;第三，设置网站为安全可信站点，并设置为允许执行ActiveX控件。步骤为：
		///       &lt;br/&gt;  打开Internet选项对话框，切换到“安全”标签页面，点击上面的“受信任的站点”，然后点击“站点”按钮，在弹出的“收信任的站点”对话框中输入WEB站点地址。
		///       &lt;br/&gt;  然后点击Internet选择对话框中的“自定义级别”按钮，显示一个对话框，在该对话框中勾选以下选项：
		///       &lt;br/&gt;  “对未标记为可安全执行脚本的ActiveX控件初始化并执行脚本/启用”，
		///       &lt;br/&gt;  “下载未签名的ActiveX控件/启用”，
		///       &lt;br/&gt;  “允许允许以前未使用的ActiveX控件而不提示/启用”，
		///        [字符串的其余部分被截断]"; 的本地化字符串。
		///        </summary>
		internal static string ActiveXSuggest => ResourceManager.GetString("ActiveXSuggest", cultureInfo_0);

		/// <summary>
		///         查找类似 服务器端会话状态超时，部分功能无效。 的本地化字符串。
		///       </summary>
		internal static string AlertSessionTimeout => ResourceManager.GetString("AlertSessionTimeout", cultureInfo_0);

		/// <summary>
		///         查找类似 已经复制到系统剪切板。 的本地化字符串。
		///       </summary>
		internal static string AlreadCopyToClipboard => ResourceManager.GetString("AlreadCopyToClipboard", cultureInfo_0);

		/// <summary>
		///         查找类似 应用程序处理中，请稍候... 的本地化字符串。
		///       </summary>
		internal static string AppProcessing => ResourceManager.GetString("AppProcessing", cultureInfo_0);

		/// <summary>
		///         查找类似 .NET程序集文件(*.dll,*.exe)|*.dll;*.exe|所有文件|*.* 的本地化字符串。
		///       </summary>
		internal static string AssemblyFileFilter => ResourceManager.GetString("AssemblyFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 浏览器不支持ActiveX控件。 的本地化字符串。
		///       </summary>
		internal static string BrowserNotSupportActiveX => ResourceManager.GetString("BrowserNotSupportActiveX", cultureInfo_0);

		/// <summary>
		///         查找类似 浏览器不支持HTML5/VIDEO元素。 的本地化字符串。
		///       </summary>
		internal static string BrowserNotSupportHtml5Video => ResourceManager.GetString("BrowserNotSupportHtml5Video", cultureInfo_0);

		/// <summary>
		///         查找类似 按钮 的本地化字符串。
		///       </summary>
		internal static string ButtonNewText => ResourceManager.GetString("ButtonNewText", cultureInfo_0);

		/// <summary>
		///         查找类似 由 的本地化字符串。
		///       </summary>
		internal static string By => ResourceManager.GetString("By", cultureInfo_0);

		/// <summary>
		///         查找类似 不能修改文档元素“{0}”。 的本地化字符串。
		///       </summary>
		internal static string CannotModifyElement_Name => ResourceManager.GetString("CannotModifyElement_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 未能找到指定的内容。 的本地化字符串。
		///       </summary>
		internal static string CannotSearchSpecifyContent => ResourceManager.GetString("CannotSearchSpecifyContent", cultureInfo_0);

		/// <summary>
		///         查找类似 输入语言： 的本地化字符串。
		///       </summary>
		internal static string CaptionInputLanguage => ResourceManager.GetString("CaptionInputLanguage", cultureInfo_0);

		/// <summary>
		///         查找类似 复选框属性 的本地化字符串。
		///       </summary>
		internal static string CheckboxProperty => ResourceManager.GetString("CheckboxProperty", cultureInfo_0);

		/// <summary>
		///         查找类似 点击加载视频或音频。 的本地化字符串。
		///       </summary>
		internal static string ClickToLoadMedia => ResourceManager.GetString("ClickToLoadMedia", cultureInfo_0);

		/// <summary>
		///         查找类似 关于... 的本地化字符串。
		///       </summary>
		internal static string Command_AboutControl => ResourceManager.GetString("Command_AboutControl", cultureInfo_0);

		/// <summary>
		///         查找类似 管理员模式 的本地化字符串。
		///       </summary>
		internal static string Command_AdministratorViewMode => ResourceManager.GetString("Command_AdministratorViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似  的本地化字符串。
		///       </summary>
		internal static string Command_AlignBottomCenter => ResourceManager.GetString("Command_AlignBottomCenter", cultureInfo_0);

		/// <summary>
		///         查找类似 居中对齐 的本地化字符串。
		///       </summary>
		internal static string Command_AlignCenter => ResourceManager.GetString("Command_AlignCenter", cultureInfo_0);

		/// <summary>
		///         查找类似 两边对齐 的本地化字符串。
		///       </summary>
		internal static string Command_AlignJustify => ResourceManager.GetString("Command_AlignJustify", cultureInfo_0);

		/// <summary>
		///         查找类似 左对齐 的本地化字符串。
		///       </summary>
		internal static string Command_AlignLeft => ResourceManager.GetString("Command_AlignLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 右对齐 的本地化字符串。
		///       </summary>
		internal static string Command_AlignRight => ResourceManager.GetString("Command_AlignRight", cultureInfo_0);

		/// <summary>
		///         查找类似 背景色 的本地化字符串。
		///       </summary>
		internal static string Command_BackColor => ResourceManager.GetString("Command_BackColor", cultureInfo_0);

		/// <summary>
		///         查找类似 退格 的本地化字符串。
		///       </summary>
		internal static string Command_Backspace => ResourceManager.GetString("Command_Backspace", cultureInfo_0);

		/// <summary>
		///         查找类似 粗体 的本地化字符串。
		///       </summary>
		internal static string Command_Bold => ResourceManager.GetString("Command_Bold", cultureInfo_0);

		/// <summary>
		///         查找类似 边框和背景样式 的本地化字符串。
		///       </summary>
		internal static string Command_BorderBackgroudFormat => ResourceManager.GetString("Command_BorderBackgroudFormat", cultureInfo_0);

		/// <summary>
		///         查找类似 圆点式列表 的本地化字符串。
		///       </summary>
		internal static string Command_BulletedList => ResourceManager.GetString("Command_BulletedList", cultureInfo_0);

		/// <summary>
		///         查找类似 整洁视图模式 的本地化字符串。
		///       </summary>
		internal static string Command_CleanViewMode => ResourceManager.GetString("Command_CleanViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 提交历史痕迹 的本地化字符串。
		///       </summary>
		internal static string Command_ClearUserTrace => ResourceManager.GetString("Command_ClearUserTrace", cultureInfo_0);

		/// <summary>
		///         查找类似 文本颜色 的本地化字符串。
		///       </summary>
		internal static string Command_Color => ResourceManager.GetString("Command_Color", cultureInfo_0);

		/// <summary>
		///         查找类似 复杂视图模式 的本地化字符串。
		///       </summary>
		internal static string Command_ComplexViewMode => ResourceManager.GetString("Command_ComplexViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域转换为文档内容 的本地化字符串。
		///       </summary>
		internal static string Command_ConvertFieldToContent => ResourceManager.GetString("Command_ConvertFieldToContent", cultureInfo_0);

		/// <summary>
		///         查找类似 文档内容转换为输入域 的本地化字符串。
		///       </summary>
		internal static string Command_ConvertToField => ResourceManager.GetString("Command_ConvertToField", cultureInfo_0);

		/// <summary>
		///         查找类似 复制 的本地化字符串。
		///       </summary>
		internal static string Command_Copy => ResourceManager.GetString("Command_Copy", cultureInfo_0);

		/// <summary>
		///         查找类似 向下滚动视图 的本地化字符串。
		///       </summary>
		internal static string Command_CtlMoveDown => ResourceManager.GetString("Command_CtlMoveDown", cultureInfo_0);

		/// <summary>
		///         查找类似 向上滚动视图 的本地化字符串。
		///       </summary>
		internal static string Command_CtlMoveUp => ResourceManager.GetString("Command_CtlMoveUp", cultureInfo_0);

		/// <summary>
		///         查找类似 剪切 的本地化字符串。
		///       </summary>
		internal static string Command_Cut => ResourceManager.GetString("Command_Cut", cultureInfo_0);

		/// <summary>
		///         查找类似 调试模式 的本地化字符串。
		///       </summary>
		internal static string Command_DebugMode => ResourceManager.GetString("Command_DebugMode", cultureInfo_0);

		/// <summary>
		///         查找类似 显示调试输出窗体 的本地化字符串。
		///       </summary>
		internal static string Command_DebugOutputWindow => ResourceManager.GetString("Command_DebugOutputWindow", cultureInfo_0);

		/// <summary>
		///         查找类似 删除 的本地化字符串。
		///       </summary>
		internal static string Command_Delete => ResourceManager.GetString("Command_Delete", cultureInfo_0);

		/// <summary>
		///         查找类似 删除域 的本地化字符串。
		///       </summary>
		internal static string Command_DeleteField => ResourceManager.GetString("Command_DeleteField", cultureInfo_0);

		/// <summary>
		///         查找类似 设计模式 的本地化字符串。
		///       </summary>
		internal static string Command_DesignMode => ResourceManager.GetString("Command_DesignMode", cultureInfo_0);

		/// <summary>
		///         查找类似 设置文档默认字体 的本地化字符串。
		///       </summary>
		internal static string Command_DocumentDefaultFont => ResourceManager.GetString("Command_DocumentDefaultFont", cultureInfo_0);

		/// <summary>
		///         查找类似 文档选项... 的本地化字符串。
		///       </summary>
		internal static string Command_DocumentOptions => ResourceManager.GetString("Command_DocumentOptions", cultureInfo_0);

		/// <summary>
		///         查找类似 文档数据校验 的本地化字符串。
		///       </summary>
		internal static string Command_DocumentValueValidate => ResourceManager.GetString("Command_DocumentValueValidate", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑文档元素值 的本地化字符串。
		///       </summary>
		internal static string Command_EditElementValue => ResourceManager.GetString("Command_EditElementValue", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑图像标注 的本地化字符串。
		///       </summary>
		internal static string Command_EditImageAdditionShape => ResourceManager.GetString("Command_EditImageAdditionShape", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑VBA脚本 的本地化字符串。
		///       </summary>
		internal static string Command_EditVBAScript => ResourceManager.GetString("Command_EditVBAScript", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑文档元素属性 的本地化字符串。
		///       </summary>
		internal static string Command_ElementProperties => ResourceManager.GetString("Command_ElementProperties", cultureInfo_0);

		/// <summary>
		///         查找类似 设置域固定宽度 的本地化字符串。
		///       </summary>
		internal static string Command_FieldSpecifyWidth => ResourceManager.GetString("Command_FieldSpecifyWidth", cultureInfo_0);

		/// <summary>
		///         查找类似 整洁打印... 的本地化字符串。
		///       </summary>
		internal static string Command_FileCleanPrint => ResourceManager.GetString("Command_FileCleanPrint", cultureInfo_0);

		/// <summary>
		///         查找类似 新建文件... 的本地化字符串。
		///       </summary>
		internal static string Command_FileNew => ResourceManager.GetString("Command_FileNew", cultureInfo_0);

		/// <summary>
		///         查找类似 打开文件... 的本地化字符串。
		///       </summary>
		internal static string Command_FileOpen => ResourceManager.GetString("Command_FileOpen", cultureInfo_0);

		/// <summary>
		///         查找类似 页面设置... 的本地化字符串。
		///       </summary>
		internal static string Command_FilePageSettings => ResourceManager.GetString("Command_FilePageSettings", cultureInfo_0);

		/// <summary>
		///         查找类似 打印... 的本地化字符串。
		///       </summary>
		internal static string Command_FilePrint => ResourceManager.GetString("Command_FilePrint", cultureInfo_0);

		/// <summary>
		///         查找类似 打印当前页 的本地化字符串。
		///       </summary>
		internal static string Command_FilePrintCurrentPage => ResourceManager.GetString("Command_FilePrintCurrentPage", cultureInfo_0);

		/// <summary>
		///         查找类似 保存文件 的本地化字符串。
		///       </summary>
		internal static string Command_FileSave => ResourceManager.GetString("Command_FileSave", cultureInfo_0);

		/// <summary>
		///         查找类似 另存为... 的本地化字符串。
		///       </summary>
		internal static string Command_FileSaveAs => ResourceManager.GetString("Command_FileSaveAs", cultureInfo_0);

		/// <summary>
		///         查找类似 段落首行缩进 的本地化字符串。
		///       </summary>
		internal static string Command_FirstLineIndent => ResourceManager.GetString("Command_FirstLineIndent", cultureInfo_0);

		/// <summary>
		///         查找类似 字体 的本地化字符串。
		///       </summary>
		internal static string Command_Font => ResourceManager.GetString("Command_Font", cultureInfo_0);

		/// <summary>
		///         查找类似 字体名称 的本地化字符串。
		///       </summary>
		internal static string Command_FontName => ResourceManager.GetString("Command_FontName", cultureInfo_0);

		/// <summary>
		///         查找类似 字体大小 的本地化字符串。
		///       </summary>
		internal static string Command_FontSize => ResourceManager.GetString("Command_FontSize", cultureInfo_0);

		/// <summary>
		///         查找类似 表单视图模式 的本地化字符串。
		///       </summary>
		internal static string Command_FormViewMode => ResourceManager.GetString("Command_FormViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 插入条码 的本地化字符串。
		///       </summary>
		internal static string Command_InsertBarcode => ResourceManager.GetString("Command_InsertBarcode", cultureInfo_0);

		/// <summary>
		///         查找类似 插入复选框 的本地化字符串。
		///       </summary>
		internal static string Command_InsertCheckBox => ResourceManager.GetString("Command_InsertCheckBox", cultureInfo_0);

		/// <summary>
		///         查找类似 插入复选框组 的本地化字符串。
		///       </summary>
		internal static string Command_InsertCheckBoxList => ResourceManager.GetString("Command_InsertCheckBoxList", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档内容链接... 的本地化字符串。
		///       </summary>
		internal static string Command_InsertContentLink => ResourceManager.GetString("Command_InsertContentLink", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档内容... 的本地化字符串。
		///       </summary>
		internal static string Command_InsertFileContent => ResourceManager.GetString("Command_InsertFileContent", cultureInfo_0);

		/// <summary>
		///         查找类似 插入HTML文档 的本地化字符串。
		///       </summary>
		internal static string Command_InsertHtml => ResourceManager.GetString("Command_InsertHtml", cultureInfo_0);

		/// <summary>
		///         查找类似 插入图片 的本地化字符串。
		///       </summary>
		internal static string Command_InsertImage => ResourceManager.GetString("Command_InsertImage", cultureInfo_0);

		/// <summary>
		///         查找类似 插入输入域 的本地化字符串。
		///       </summary>
		internal static string Command_InsertInputField => ResourceManager.GetString("Command_InsertInputField", cultureInfo_0);

		/// <summary>
		///         查找类似 插入软回车 的本地化字符串。
		///       </summary>
		internal static string Command_InsertLineBreak => ResourceManager.GetString("Command_InsertLineBreak", cultureInfo_0);

		/// <summary>
		///         查找类似 插入模式 的本地化字符串。
		///       </summary>
		internal static string Command_InsertMode => ResourceManager.GetString("Command_InsertMode", cultureInfo_0);

		/// <summary>
		///         查找类似 插入页码 的本地化字符串。
		///       </summary>
		internal static string Command_InsertPageInfo => ResourceManager.GetString("Command_InsertPageInfo", cultureInfo_0);

		/// <summary>
		///         查找类似 插入RTF文档 的本地化字符串。
		///       </summary>
		internal static string Command_InsertRTF => ResourceManager.GetString("Command_InsertRTF", cultureInfo_0);

		/// <summary>
		///         查找类似 插入纯文本 的本地化字符串。
		///       </summary>
		internal static string Command_InsertString => ResourceManager.GetString("Command_InsertString", cultureInfo_0);

		/// <summary>
		///         查找类似 插入XML文档 的本地化字符串。
		///       </summary>
		internal static string Command_InsertXML => ResourceManager.GetString("Command_InsertXML", cultureInfo_0);

		/// <summary>
		///         查找类似 斜体 的本地化字符串。
		///       </summary>
		internal static string Command_Italic => ResourceManager.GetString("Command_Italic", cultureInfo_0);

		/// <summary>
		///         查找类似 续打模式 的本地化字符串。
		///       </summary>
		internal static string Command_JumpPrintMode => ResourceManager.GetString("Command_JumpPrintMode", cultureInfo_0);

		/// <summary>
		///         查找类似 加载知识库... 的本地化字符串。
		///       </summary>
		internal static string Command_LoadKBLibrary => ResourceManager.GetString("Command_LoadKBLibrary", cultureInfo_0);

		/// <summary>
		///         查找类似 向下移动一行 的本地化字符串。
		///       </summary>
		internal static string Command_MoveDown => ResourceManager.GetString("Command_MoveDown", cultureInfo_0);

		/// <summary>
		///         查找类似 移动到行尾 的本地化字符串。
		///       </summary>
		internal static string Command_MoveEnd => ResourceManager.GetString("Command_MoveEnd", cultureInfo_0);

		/// <summary>
		///         查找类似 移动到行首 的本地化字符串。
		///       </summary>
		internal static string Command_MoveHome => ResourceManager.GetString("Command_MoveHome", cultureInfo_0);

		/// <summary>
		///         查找类似 向左移动 的本地化字符串。
		///       </summary>
		internal static string Command_MoveLeft => ResourceManager.GetString("Command_MoveLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 向下翻页 的本地化字符串。
		///       </summary>
		internal static string Command_MovePageDown => ResourceManager.GetString("Command_MovePageDown", cultureInfo_0);

		/// <summary>
		///         查找类似 向上翻页 的本地化字符串。
		///       </summary>
		internal static string Command_MovePageUp => ResourceManager.GetString("Command_MovePageUp", cultureInfo_0);

		/// <summary>
		///         查找类似 向右移动 的本地化字符串。
		///       </summary>
		internal static string Command_MoveRight => ResourceManager.GetString("Command_MoveRight", cultureInfo_0);

		/// <summary>
		///         查找类似 移动到... 的本地化字符串。
		///       </summary>
		internal static string Command_MoveTo => ResourceManager.GetString("Command_MoveTo", cultureInfo_0);

		/// <summary>
		///         查找类似 向上移动一行 的本地化字符串。
		///       </summary>
		internal static string Command_MoveUp => ResourceManager.GetString("Command_MoveUp", cultureInfo_0);

		/// <summary>
		///         查找类似 普通视图模式 的本地化字符串。
		///       </summary>
		internal static string Command_NormalViewMode => ResourceManager.GetString("Command_NormalViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 数字式列表 的本地化字符串。
		///       </summary>
		internal static string Command_NumberedList => ResourceManager.GetString("Command_NumberedList", cultureInfo_0);

		/// <summary>
		///         查找类似 打开旧格式XML文件... 的本地化字符串。
		///       </summary>
		internal static string Command_OpenOldXMLFormat => ResourceManager.GetString("Command_OpenOldXMLFormat", cultureInfo_0);

		/// <summary>
		///         查找类似 分页视图模式 的本地化字符串。
		///       </summary>
		internal static string Command_PageViewMode => ResourceManager.GetString("Command_PageViewMode", cultureInfo_0);

		/// <summary>
		///         查找类似 段落格式 的本地化字符串。
		///       </summary>
		internal static string Command_ParagraphFormat => ResourceManager.GetString("Command_ParagraphFormat", cultureInfo_0);

		/// <summary>
		///         查找类似 粘贴 的本地化字符串。
		///       </summary>
		internal static string Command_Paste => ResourceManager.GetString("Command_Paste", cultureInfo_0);

		/// <summary>
		///         查找类似 重做 的本地化字符串。
		///       </summary>
		internal static string Command_Redo => ResourceManager.GetString("Command_Redo", cultureInfo_0);

		/// <summary>
		///         查找类似 用户注册... 的本地化字符串。
		///       </summary>
		internal static string Command_Register => ResourceManager.GetString("Command_Register", cultureInfo_0);

		/// <summary>
		///         查找类似 保存知识库... 的本地化字符串。
		///       </summary>
		internal static string Command_SaveKBLibrary => ResourceManager.GetString("Command_SaveKBLibrary", cultureInfo_0);

		/// <summary>
		///         查找类似 查找和替换 的本地化字符串。
		///       </summary>
		internal static string Command_SearchReplace => ResourceManager.GetString("Command_SearchReplace", cultureInfo_0);

		/// <summary>
		///         查找类似 全选 的本地化字符串。
		///       </summary>
		internal static string Command_SelectAll => ResourceManager.GetString("Command_SelectAll", cultureInfo_0);

		/// <summary>
		///         查找类似 设置文档默认样式 的本地化字符串。
		///       </summary>
		internal static string Command_SetDefaultStyle => ResourceManager.GetString("Command_SetDefaultStyle", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向下移动一行 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveDown => ResourceManager.GetString("Command_ShiftMoveDown", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择移动到行尾 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveEnd => ResourceManager.GetString("Command_ShiftMoveEnd", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择移动到行首 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveHome => ResourceManager.GetString("Command_ShiftMoveHome", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向左移动 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveLeft => ResourceManager.GetString("Command_ShiftMoveLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向下翻页 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMovePageDown => ResourceManager.GetString("Command_ShiftMovePageDown", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向上翻页 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMovePageUp => ResourceManager.GetString("Command_ShiftMovePageUp", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向右移动 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveRight => ResourceManager.GetString("Command_ShiftMoveRight", cultureInfo_0);

		/// <summary>
		///         查找类似 带选择向上移动一行 的本地化字符串。
		///       </summary>
		internal static string Command_ShiftMoveUp => ResourceManager.GetString("Command_ShiftMoveUp", cultureInfo_0);

		/// <summary>
		///         查找类似 文档签名 的本地化字符串。
		///       </summary>
		internal static string Command_SignDocument => ResourceManager.GetString("Command_SignDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 选择性粘贴... 的本地化字符串。
		///       </summary>
		internal static string Command_SpecifyPaste => ResourceManager.GetString("Command_SpecifyPaste", cultureInfo_0);

		/// <summary>
		///         查找类似 删除线 的本地化字符串。
		///       </summary>
		internal static string Command_Strikeout => ResourceManager.GetString("Command_Strikeout", cultureInfo_0);

		/// <summary>
		///         查找类似 下标 的本地化字符串。
		///       </summary>
		internal static string Command_Subscript => ResourceManager.GetString("Command_Subscript", cultureInfo_0);

		/// <summary>
		///         查找类似 上标 的本地化字符串。
		///       </summary>
		internal static string Command_Superscript => ResourceManager.GetString("Command_Superscript", cultureInfo_0);

		/// <summary>
		///         查找类似 删除表格列 的本地化字符串。
		///       </summary>
		internal static string Command_Table_DeleteColumn => ResourceManager.GetString("Command_Table_DeleteColumn", cultureInfo_0);

		/// <summary>
		///         查找类似 删除表格行 的本地化字符串。
		///       </summary>
		internal static string Command_Table_DeleteRow => ResourceManager.GetString("Command_Table_DeleteRow", cultureInfo_0);

		/// <summary>
		///         查找类似 删除表格 的本地化字符串。
		///       </summary>
		internal static string Command_Table_DeleteTable => ResourceManager.GetString("Command_Table_DeleteTable", cultureInfo_0);

		/// <summary>
		///         查找类似 在左侧插入表格列 的本地化字符串。
		///       </summary>
		internal static string Command_Table_InsertColumnLeft => ResourceManager.GetString("Command_Table_InsertColumnLeft", cultureInfo_0);

		/// <summary>
		///         查找类似 在右侧插入表格列 的本地化字符串。
		///       </summary>
		internal static string Command_Table_InsertColumnRight => ResourceManager.GetString("Command_Table_InsertColumnRight", cultureInfo_0);

		/// <summary>
		///         查找类似 在下面插入表格行 的本地化字符串。
		///       </summary>
		internal static string Command_Table_InsertRowDown => ResourceManager.GetString("Command_Table_InsertRowDown", cultureInfo_0);

		/// <summary>
		///         查找类似 在上面插入表格行 的本地化字符串。
		///       </summary>
		internal static string Command_Table_InsertRowUP => ResourceManager.GetString("Command_Table_InsertRowUP", cultureInfo_0);

		/// <summary>
		///         查找类似 插入表格... 的本地化字符串。
		///       </summary>
		internal static string Command_Table_InsertTable => ResourceManager.GetString("Command_Table_InsertTable", cultureInfo_0);

		/// <summary>
		///         查找类似 合并单元格 的本地化字符串。
		///       </summary>
		internal static string Command_Table_MegeCell => ResourceManager.GetString("Command_Table_MegeCell", cultureInfo_0);

		/// <summary>
		///         查找类似 拆分单元格 的本地化字符串。
		///       </summary>
		internal static string Command_Table_SplitCell => ResourceManager.GetString("Command_Table_SplitCell", cultureInfo_0);

		/// <summary>
		///         查找类似 下划线 的本地化字符串。
		///       </summary>
		internal static string Command_Underline => ResourceManager.GetString("Command_Underline", cultureInfo_0);

		/// <summary>
		///         查找类似 撤销 的本地化字符串。
		///       </summary>
		internal static string Command_Undo => ResourceManager.GetString("Command_Undo", cultureInfo_0);

		/// <summary>
		///         查找类似 根据视图更新数据源 的本地化字符串。
		///       </summary>
		internal static string Command_UpdateDataSourceForView => ResourceManager.GetString("Command_UpdateDataSourceForView", cultureInfo_0);

		/// <summary>
		///         查找类似 根据数据源更新视图 的本地化字符串。
		///       </summary>
		internal static string Command_UpdateViewForDataSource => ResourceManager.GetString("Command_UpdateViewForDataSource", cultureInfo_0);

		/// <summary>
		///         查找类似 查看XML源代码 的本地化字符串。
		///       </summary>
		internal static string Command_ViewXMLSource => ResourceManager.GetString("Command_ViewXMLSource", cultureInfo_0);

		/// <summary>
		///         查找类似 字数统计 的本地化字符串。
		///       </summary>
		internal static string Command_WordCount => ResourceManager.GetString("Command_WordCount", cultureInfo_0);

		/// <summary>
		///         查找类似 系统发现在{0}自动保存的文件“{0}”内容，是否恢复？ 的本地化字符串。
		///       </summary>
		internal static string ConfirmAutoSave_Time_FileName => ResourceManager.GetString("ConfirmAutoSave_Time_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 图片文件大小 {0} 超过了 {1}，比较大了，是否压缩存储图片数据？ 如果压缩存储图片数据，则文档大小不会很大，不过会导致图片显示和打印质量下降。 的本地化字符串。
		///       </summary>
		internal static string ConfirmCompressSaveModeForImageSize_Size_MinSize => ResourceManager.GetString("ConfirmCompressSaveModeForImageSize_Size_MinSize", cultureInfo_0);

		/// <summary>
		///         查找类似 当前显示高度{0}厘米。 的本地化字符串。
		///       </summary>
		internal static string CurrentHeight_CM => ResourceManager.GetString("CurrentHeight_CM", cultureInfo_0);

		/// <summary>
		///         查找类似 DCWriter文档编辑器 的本地化字符串。
		///       </summary>
		internal static string DCWriterProductName => ResourceManager.GetString("DCWriterProductName", cultureInfo_0);

		/// <summary>
		///         查找类似 删除 的本地化字符串。
		///       </summary>
		internal static string Delete => ResourceManager.GetString("Delete", cultureInfo_0);

		/// <summary>
		///         查找类似 删除目录“{0}”。 的本地化字符串。
		///       </summary>
		internal static string DeleteDirectory_Name => ResourceManager.GetString("DeleteDirectory_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 检测到元素“{0}”有表达式“{1}”。 的本地化字符串。
		///       </summary>
		internal static string DetectValueExpression_ID_Expression => ResourceManager.GetString("DetectValueExpression_ID_Expression", cultureInfo_0);

		/// <summary>
		///         查找类似 不可用 的本地化字符串。
		///       </summary>
		internal static string Disable => ResourceManager.GetString("Disable", cultureInfo_0);

		/// <summary>
		///         查找类似 文档大纲层次 的本地化字符串。
		///       </summary>
		internal static string DocumentOutline => ResourceManager.GetString("DocumentOutline", cultureInfo_0);

		/// <summary>
		///         查找类似 元素“{0}”联动设置元素“{1}”的ContentReadonly值为“{2}”。 的本地化字符串。
		///       </summary>
		internal static string ElementIDForEditableDependent_SrcID_TargetID_Result => ResourceManager.GetString("ElementIDForEditableDependent_SrcID_TargetID_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 会计数字 的本地化字符串。
		///       </summary>
		internal static string ElementType_AccountingNumber => ResourceManager.GetString("ElementType_AccountingNumber", cultureInfo_0);

		/// <summary>
		///         查找类似 条码 的本地化字符串。
		///       </summary>
		internal static string ElementType_Barcode => ResourceManager.GetString("ElementType_Barcode", cultureInfo_0);

		/// <summary>
		///         查找类似 多媒体 的本地化字符串。
		///       </summary>
		internal static string ElementType_Media => ResourceManager.GetString("ElementType_Media", cultureInfo_0);

		/// <summary>
		///         查找类似 体温单 的本地化字符串。
		///       </summary>
		internal static string ElementType_TChart => ResourceManager.GetString("ElementType_TChart", cultureInfo_0);

		/// <summary>
		///         查找类似 二维条码 的本地化字符串。
		///       </summary>
		internal static string ElementType_TDBarcode => ResourceManager.GetString("ElementType_TDBarcode", cultureInfo_0);

		/// <summary>
		///         查找类似 可用 的本地化字符串。
		///       </summary>
		internal static string Enabled => ResourceManager.GetString("Enabled", cultureInfo_0);

		/// <summary>
		///         查找类似 处理事件“{0}”时发生脚本错误“{1}”。 的本地化字符串。
		///       </summary>
		internal static string EventScriptError_Event_Message => ResourceManager.GetString("EventScriptError_Event_Message", cultureInfo_0);

		/// <summary>
		///         查找类似 对象“{0}”触发对象“{1}”执行表达式“{2}”，结果为“{3}”。 的本地化字符串。
		///       </summary>
		internal static string ExecuteExpression_EventSource_Sender_Expression_Result => ResourceManager.GetString("ExecuteExpression_EventSource_Sender_Expression_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 对象“{0}”执行表达式“{1}”，结果为“{2}”。 的本地化字符串。
		///       </summary>
		internal static string ExecuteExpression_Sender_Expression_Result => ResourceManager.GetString("ExecuteExpression_Sender_Expression_Result", cultureInfo_0);

		/// <summary>
		///         查找类似 对象“{0}”的表达式“{1}”中的编号“{2}”未找到对应元素。 的本地化字符串。
		///       </summary>
		internal static string ExpressionMissElement_Element_Expression_ID => ResourceManager.GetString("ExpressionMissElement_Element_Expression_ID", cultureInfo_0);

		/// <summary>
		///         查找类似 对象“{0}”执行表达式时未找到目标“{1}”,取消执行。 的本地化字符串。
		///       </summary>
		internal static string ExpressionMissTarget_Source_Target => ResourceManager.GetString("ExpressionMissTarget_Source_Target", cultureInfo_0);

		/// <summary>
		///         查找类似 元素“{0}”的数值表达式“{1}”中引用了元素自己。 的本地化字符串。
		///       </summary>
		internal static string ExpressionRefSelf_ElementID_Expression => ResourceManager.GetString("ExpressionRefSelf_ElementID_Expression", cultureInfo_0);

		/// <summary>
		///         查找类似 元素“{1}”是元素"{0}"的子元素,不能执行相关的表达式。 的本地化字符串。
		///       </summary>
		internal static string ExpressionTargetInvalidteForChild_Source_Target => ResourceManager.GetString("ExpressionTargetInvalidteForChild_Source_Target", cultureInfo_0);

		/// <summary>
		///         查找类似 密码不正确，请重新输入！ 的本地化字符串。
		///       </summary>
		internal static string FailPasswordForExecuteCommand => ResourceManager.GetString("FailPasswordForExecuteCommand", cultureInfo_0);

		/// <summary>
		///         查找类似 向系统注册程序集“{0}”COM接口失败。 的本地化字符串。
		///       </summary>
		internal static string FailRegAsm_FileName => ResourceManager.GetString("FailRegAsm_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 替换操作失败，可能是被替换区域内容只读，无法修改。 的本地化字符串。
		///       </summary>
		internal static string FailReplace => ResourceManager.GetString("FailReplace", cultureInfo_0);

		/// <summary>
		///         查找类似 设置.NET框架的完全可信级别失败。 的本地化字符串。
		///       </summary>
		internal static string FailSetFullTrust => ResourceManager.GetString("FailSetFullTrust", cultureInfo_0);

		/// <summary>
		///         查找类似 设置“{0}”为可信站点的操作失败。 的本地化字符串。
		///       </summary>
		internal static string FailSetTrustSite_Url => ResourceManager.GetString("FailSetTrustSite_Url", cultureInfo_0);

		/// <summary>
		///         查找类似 容器元素{0}不能接受子元素{0}。 的本地化字符串。
		///       </summary>
		internal static string FailToAcceptChildElement_Parent_Child => ResourceManager.GetString("FailToAcceptChildElement_Parent_Child", cultureInfo_0);

		/// <summary>
		///         查找类似 注销程序集“{0}”COM接口失败。 的本地化字符串。
		///       </summary>
		internal static string FailUnRegAsm_FileName => ResourceManager.GetString("FailUnRegAsm_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 验证URL“{0}”处的文件内容失败。 的本地化字符串。
		///       </summary>
		internal static string FailValidateContent_URL => ResourceManager.GetString("FailValidateContent_URL", cultureInfo_0);

		/// <summary>
		///         查找类似 文件“{0}”不存在。 的本地化字符串。
		///       </summary>
		internal static string FileNotExist_FileName => ResourceManager.GetString("FileNotExist_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 有{0}个编译错误。 的本地化字符串。
		///       </summary>
		internal static string HasCompilerErrors_Num => ResourceManager.GetString("HasCompilerErrors_Num", cultureInfo_0);

		/// <summary>
		///         查找类似 Html文件(*.htm,*.html)|*.htm;*.html 的本地化字符串。
		///       </summary>
		internal static string HtmlFileFilter => ResourceManager.GetString("HtmlFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 图片文件(*.bmp,*.jpg,*.jpeg,*.gif,*.png,*.wmf,*.emf)|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.wmf;*.emf|所有文件|*.* 的本地化字符串。
		///       </summary>
		internal static string ImageFileFilter => ResourceManager.GetString("ImageFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 输入 的本地化字符串。
		///       </summary>
		internal static string Input => ResourceManager.GetString("Input", cultureInfo_0);

		/// <summary>
		///         查找类似 错误的命令“{0}”，系统支持类似的命令有“{1}” 的本地化字符串。
		///       </summary>
		internal static string InvalidateCommandName_Name_SimiliarNames => ResourceManager.GetString("InvalidateCommandName_Name_SimiliarNames", cultureInfo_0);

		/// <summary>
		///         查找类似 取消 的本地化字符串。
		///       </summary>
		internal static string JS_Cancel => ResourceManager.GetString("JS_Cancel", cultureInfo_0);

		/// <summary>
		///         查找类似 数据不得为空。 的本地化字符串。
		///       </summary>
		internal static string JS_CanNotEmpty => ResourceManager.GetString("JS_CanNotEmpty", cultureInfo_0);

		/// <summary>
		///         查找类似 不能在当前位置插入输入域。 的本地化字符串。
		///       </summary>
		internal static string JS_CannotInsertFieldAtCurrentPosition => ResourceManager.GetString("JS_CannotInsertFieldAtCurrentPosition", cultureInfo_0);

		/// <summary>
		///         查找类似 在当前位置不能插入图片。 的本地化字符串。
		///       </summary>
		internal static string JS_CannotInsertImageAtCurrentPosition => ResourceManager.GetString("JS_CannotInsertImageAtCurrentPosition", cultureInfo_0);

		/// <summary>
		///         查找类似 服务器会话状态超时，无法上传本地图片。 的本地化字符串。
		///       </summary>
		internal static string JS_CannotInsertImageForSessionTimeout => ResourceManager.GetString("JS_CannotInsertImageForSessionTimeout", cultureInfo_0);

		/// <summary>
		///         查找类似 对话框 的本地化字符串。
		///       </summary>
		internal static string JS_Dialog => ResourceManager.GetString("JS_Dialog", cultureInfo_0);

		/// <summary>
		///         查找类似 超过最大值： 的本地化字符串。
		///       </summary>
		internal static string JS_ExceedMaxValue => ResourceManager.GetString("JS_ExceedMaxValue", cultureInfo_0);

		/// <summary>
		///         查找类似 不能包含： 的本地化字符串。
		///       </summary>
		internal static string JS_Exclude => ResourceManager.GetString("JS_Exclude", cultureInfo_0);

		/// <summary>
		///         查找类似 违禁关键字： 的本地化字符串。
		///       </summary>
		internal static string JS_ExcludeKeyword => ResourceManager.GetString("JS_ExcludeKeyword", cultureInfo_0);

		/// <summary>
		///         查找类似 输入域被标记为不能删除。 的本地化字符串。
		///       </summary>
		internal static string JS_InputFieldMarkUnDeleted => ResourceManager.GetString("JS_InputFieldMarkUnDeleted", cultureInfo_0);

		/// <summary>
		///         查找类似 比如为时间格式。 的本地化字符串。
		///       </summary>
		internal static string JS_MustBeDate => ResourceManager.GetString("JS_MustBeDate", cultureInfo_0);

		/// <summary>
		///         查找类似 必须为整数。 的本地化字符串。
		///       </summary>
		internal static string JS_MustBeInteger => ResourceManager.GetString("JS_MustBeInteger", cultureInfo_0);

		/// <summary>
		///         查找类似 必须为数值。 的本地化字符串。
		///       </summary>
		internal static string JS_MustBeNumber => ResourceManager.GetString("JS_MustBeNumber", cultureInfo_0);

		/// <summary>
		///         查找类似 服务器控件没有设置{0}事件。 的本地化字符串。
		///       </summary>
		internal static string JS_NoServerEvent_EventName => ResourceManager.GetString("JS_NoServerEvent_EventName", cultureInfo_0);

		/// <summary>
		///         查找类似 未定义的函数： 的本地化字符串。
		///       </summary>
		internal static string JS_NotDefinedFunction => ResourceManager.GetString("JS_NotDefinedFunction", cultureInfo_0);

		/// <summary>
		///         查找类似 文本不包含在列表： 的本地化字符串。
		///       </summary>
		internal static string JS_NotInclude => ResourceManager.GetString("JS_NotInclude", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持的命令： 的本地化字符串。
		///       </summary>
		internal static string JS_NotSupportCommand => ResourceManager.GetString("JS_NotSupportCommand", cultureInfo_0);

		/// <summary>
		///         查找类似 确定 的本地化字符串。
		///       </summary>
		internal static string JS_OK => ResourceManager.GetString("JS_OK", cultureInfo_0);

		/// <summary>
		///         查找类似 文档只读。 的本地化字符串。
		///       </summary>
		internal static string JS_PromptReadonly => ResourceManager.GetString("JS_PromptReadonly", cultureInfo_0);

		/// <summary>
		///         查找类似 系统正在显示对话框，在关闭对话框前无法执行本操作。 的本地化字符串。
		///       </summary>
		internal static string JS_PromptShowingDialog => ResourceManager.GetString("JS_PromptShowingDialog", cultureInfo_0);

		/// <summary>
		///         查找类似 地址"{0}"未返回任何内容，可能是服务器被关闭了。 的本地化字符串。
		///       </summary>
		internal static string JS_ReturnNoneContent_Url => ResourceManager.GetString("JS_ReturnNoneContent_Url", cultureInfo_0);

		/// <summary>
		///         查找类似 保存文档失败。 的本地化字符串。
		///       </summary>
		internal static string JS_SaveDocumentFail => ResourceManager.GetString("JS_SaveDocumentFail", cultureInfo_0);

		/// <summary>
		///         查找类似 保存文档成功。 的本地化字符串。
		///       </summary>
		internal static string JS_SaveDocumentOK => ResourceManager.GetString("JS_SaveDocumentOK", cultureInfo_0);

		/// <summary>
		///         查找类似 编辑器控件自检错误： 的本地化字符串。
		///       </summary>
		internal static string JS_SelfCheckingError => ResourceManager.GetString("JS_SelfCheckingError", cultureInfo_0);

		/// <summary>
		///         查找类似 服务器页面地址{0}检查错误：{1}。 的本地化字符串。
		///       </summary>
		internal static string JS_ServicePageUrlCheckError_URL_MSG => ResourceManager.GetString("JS_ServicePageUrlCheckError_URL_MSG", cultureInfo_0);

		/// <summary>
		///         查找类似 控件的ServicePageURL属性为空! 的本地化字符串。
		///       </summary>
		internal static string JS_ServicePageUrlIsEmpty => ResourceManager.GetString("JS_ServicePageUrlIsEmpty", cultureInfo_0);

		/// <summary>
		///         查找类似 服务器会话超时，功能无效。请刷新整个页面再试试。 的本地化字符串。
		///       </summary>
		internal static string JS_SessionTimeout => ResourceManager.GetString("JS_SessionTimeout", cultureInfo_0);

		/// <summary>
		///         查找类似 宽度：{0}PX，高度：{1}PX。 的本地化字符串。
		///       </summary>
		internal static string JS_SizeLabel_Width_Height => ResourceManager.GetString("JS_SizeLabel_Width_Height", cultureInfo_0);

		/// <summary>
		///         查找类似 插入文档成功。 的本地化字符串。
		///       </summary>
		internal static string JS_SuccessInsertDocument => ResourceManager.GetString("JS_SuccessInsertDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 文本过长，不得超过{0}个字符。 的本地化字符串。
		///       </summary>
		internal static string JS_TextTooLong_Maxlength => ResourceManager.GetString("JS_TextTooLong_Maxlength", cultureInfo_0);

		/// <summary>
		///         查找类似 文本过短，至少要{0}个字符。 的本地化字符串。
		///       </summary>
		internal static string JS_TextTooShort_MinLength => ResourceManager.GetString("JS_TextTooShort_MinLength", cultureInfo_0);

		/// <summary>
		///         查找类似 小数位数超过上限，最多为： 的本地化字符串。
		///       </summary>
		internal static string JS_TooManyDigits => ResourceManager.GetString("JS_TooManyDigits", cultureInfo_0);

		/// <summary>
		///         查找类似 低于最小值： 的本地化字符串。
		///       </summary>
		internal static string JS_UnderMinValue => ResourceManager.GetString("JS_UnderMinValue", cultureInfo_0);

		/// <summary>
		///         查找类似 正在上传图片... 的本地化字符串。
		///       </summary>
		internal static string JS_UploadingImage => ResourceManager.GetString("JS_UploadingImage", cultureInfo_0);

		/// <summary>
		///         查找类似 共检查出{0}条数据校验错误信息: 的本地化字符串。
		///       </summary>
		internal static string JS_ValueValidateResult_ItemCount => ResourceManager.GetString("JS_ValueValidateResult_ItemCount", cultureInfo_0);

		/// <summary>
		///         查找类似 标签文本 的本地化字符串。
		///       </summary>
		internal static string LabelNewText => ResourceManager.GetString("LabelNewText", cultureInfo_0);

		/// <summary>
		///         查找类似 加载完成，共加载了{0}。 的本地化字符串。
		///       </summary>
		internal static string LoadComplete_Size => ResourceManager.GetString("LoadComplete_Size", cultureInfo_0);

		/// <summary>
		///         查找类似 正在加载文件“{0}”... 的本地化字符串。
		///       </summary>
		internal static string Loading_FileName => ResourceManager.GetString("Loading_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 正在使用“{0}”加载模板“{1}”。 的本地化字符串。
		///       </summary>
		internal static string LoadTemplate_FS_FileName => ResourceManager.GetString("LoadTemplate_FS_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 页数 的本地化字符串。
		///       </summary>
		internal static string LocalNumOfPagesText => ResourceManager.GetString("LocalNumOfPagesText", cultureInfo_0);

		/// <summary>
		///         查找类似 页码 的本地化字符串。
		///       </summary>
		internal static string LocalPageIndexText => ResourceManager.GetString("LocalPageIndexText", cultureInfo_0);

		/// <summary>
		///         查找类似 媒体文件(*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv)|*.avi;*.mp3;*.mp4;*.wav;*.wma;*.wmx;*.wmv|所有文件|*.* 的本地化字符串。
		///       </summary>
		internal static string MediaFileFilter => ResourceManager.GetString("MediaFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 保存文件 的本地化字符串。
		///       </summary>
		internal static string MenuSaveFile => ResourceManager.GetString("MenuSaveFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存第一个文档为HTML文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveFirstHTMLFile => ResourceManager.GetString("MenuSaveFirstHTMLFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存第一个文档为PDF文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveFirstPDFFile => ResourceManager.GetString("MenuSaveFirstPDFFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存第一个文档为RTF文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveFirstRTFFile => ResourceManager.GetString("MenuSaveFirstRTFFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存第一个文档为XML文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveFirstXMLFile => ResourceManager.GetString("MenuSaveFirstXMLFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存HTML文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveHTMLFile => ResourceManager.GetString("MenuSaveHTMLFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存PDF文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSavePDFFile => ResourceManager.GetString("MenuSavePDFFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存RTF文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveRTFFile => ResourceManager.GetString("MenuSaveRTFFile", cultureInfo_0);

		/// <summary>
		///         查找类似 保存XML文件... 的本地化字符串。
		///       </summary>
		internal static string MenuSaveXMLFile => ResourceManager.GetString("MenuSaveXMLFile", cultureInfo_0);

		/// <summary>
		///         查找类似 此功能模块正在开发中，尚未正式发布。 的本地化字符串。
		///       </summary>
		internal static string ModuleDeveloping => ResourceManager.GetString("ModuleDeveloping", cultureInfo_0);

		/// <summary>
		///         查找类似 无文档。 的本地化字符串。
		///       </summary>
		internal static string NoDocument => ResourceManager.GetString("NoDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 没有图片 的本地化字符串。
		///       </summary>
		internal static string NoImage => ResourceManager.GetString("NoImage", cultureInfo_0);

		/// <summary>
		///         查找类似 系统中未安装打印机。 的本地化字符串。
		///       </summary>
		internal static string NotInstallPrinter => ResourceManager.GetString("NotInstallPrinter", cultureInfo_0);

		/// <summary>
		///         查找类似 未指定文件名。 的本地化字符串。
		///       </summary>
		internal static string NotSpecifyFileName => ResourceManager.GetString("NotSpecifyFileName", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持读取“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportRead_Format => ResourceManager.GetString("NotSupportRead_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不能以文本方式读取“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportReadText_Format => ResourceManager.GetString("NotSupportReadText_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持保存“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportWrite_Format => ResourceManager.GetString("NotSupportWrite_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持以二进制模式输出“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportWriteBinary_Format => ResourceManager.GetString("NotSupportWriteBinary_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 不支持以文本模式输出“{0}”格式的文件。 的本地化字符串。
		///       </summary>
		internal static string NotSupportWriteText_Format => ResourceManager.GetString("NotSupportWriteText_Format", cultureInfo_0);

		/// <summary>
		///         查找类似 总页数 的本地化字符串。
		///       </summary>
		internal static string NumOfPagesText => ResourceManager.GetString("NumOfPagesText", cultureInfo_0);

		/// <summary>
		///         查找类似 页码 的本地化字符串。
		///       </summary>
		internal static string PageIndexText => ResourceManager.GetString("PageIndexText", cultureInfo_0);

		/// <summary>
		///         查找类似 解析元素“{0}”的表达式“{1}”时查找名称为“{2}”的元素时出现元素类型不匹配的警告。 的本地化字符串。
		///       </summary>
		internal static string ParseExpressionTypeInvalidate_ID_Expression_Item => ResourceManager.GetString("ParseExpressionTypeInvalidate_ID_Expression_Item", cultureInfo_0);

		/// <summary>
		///         查找类似 PDF文件(*.pdf)|*.pdf 的本地化字符串。
		///       </summary>
		internal static string PDFFilter => ResourceManager.GetString("PDFFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 选择自动生成的CAB文件的输出目录，程序必须有对该目录的访问权限，而且对WEB客户端能下载该目录下的文件。 的本地化字符串。
		///       </summary>
		internal static string PickCABOutputDirectory => ResourceManager.GetString("PickCABOutputDirectory", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入正确的行数。 的本地化字符串。
		///       </summary>
		internal static string PormptInvalidateRowsNum => ResourceManager.GetString("PormptInvalidateRowsNum", cultureInfo_0);

		/// <summary>
		///         查找类似 没能下载安装控件，请联系管理员来设置安全站点，允许网页使用ActiveX控件，并确认客户端安装了.NET框架。 的本地化字符串。
		///       </summary>
		internal static string PromptActiveXControlInWeb => ResourceManager.GetString("PromptActiveXControlInWeb", cultureInfo_0);

		/// <summary>
		///         查找类似 不能编辑这个文档批注，因为该批注是”{0}“创建的。 的本地化字符串。
		///       </summary>
		internal static string PromptCannotEditComment_AuthorID => ResourceManager.GetString("PromptCannotEditComment_AuthorID", cultureInfo_0);

		/// <summary>
		///         查找类似 不能打印文档。 的本地化字符串。
		///       </summary>
		internal static string PromptCannotPrintDocument => ResourceManager.GetString("PromptCannotPrintDocument", cultureInfo_0);

		/// <summary>
		///         查找类似 清理Delphi完成。 的本地化字符串。
		///       </summary>
		internal static string PromptClearDelphi => ResourceManager.GetString("PromptClearDelphi", cultureInfo_0);

		/// <summary>
		///         查找类似 程序发生错误“{0}”，对于Windows7操作系统请以管理员模式运行本程序。 的本地化字符串。
		///       </summary>
		internal static string PromptErrAndWin7_MSG => ResourceManager.GetString("PromptErrAndWin7_MSG", cultureInfo_0);

		/// <summary>
		///         查找类似 请首先执行注册COM接口来生成"{0}"文件。 的本地化字符串。
		///       </summary>
		internal static string PromptGenerateDCWriterTlb_FileName => ResourceManager.GetString("PromptGenerateDCWriterTlb_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 请输入一个URL地址。 的本地化字符串。
		///       </summary>
		internal static string PromptInputURL => ResourceManager.GetString("PromptInputURL", cultureInfo_0);

		/// <summary>
		///         查找类似 已到达文档的开始处，是否继续从结尾处搜索？ 的本地化字符串。
		///       </summary>
		internal static string PromptJumEndForSearch => ResourceManager.GetString("PromptJumEndForSearch", cultureInfo_0);

		/// <summary>
		///         查找类似 已到达文档的结尾处，是否继续从开始处搜索？ 的本地化字符串。
		///       </summary>
		internal static string PromptJumpStartForSearch => ResourceManager.GetString("PromptJumpStartForSearch", cultureInfo_0);

		/// <summary>
		///         查找类似 系统检测到有"{0}"进程在运行，执行本操作需要退出所有的"{0}"进程，请您关闭所有的"{0}"进程后点击“确定”按钮以继续执行操作；或者点击“取消”按钮而退出本次操作。 的本地化字符串。
		///       </summary>
		internal static string PromptKillProcess_Name => ResourceManager.GetString("PromptKillProcess_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 类型“{0}”未找到属性“{1}”。 的本地化字符串。
		///       </summary>
		internal static string PromptNotFoundProperty_Type_Name => ResourceManager.GetString("PromptNotFoundProperty_Type_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 未检测到系统中安装了Windows Media Player。可以设置BehaviorOptions.ActiveCheckInstallWindowsMediaPlayer值为false后再尝试操作。 的本地化字符串。
		///       </summary>
		internal static string PromptNotInstallWindowsMediaPlayer => ResourceManager.GetString("PromptNotInstallWindowsMediaPlayer", cultureInfo_0);

		/// <summary>
		///         查找类似 建议在阅读版式视图模式使用续打功能。 的本地化字符串。
		///       </summary>
		internal static string PromptReadViewModeToJumpPrint => ResourceManager.GetString("PromptReadViewModeToJumpPrint", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的替换了 {0} 处文档内容。 的本地化字符串。
		///       </summary>
		internal static string PromptReplaceAllResult_Times => ResourceManager.GetString("PromptReplaceAllResult_Times", cultureInfo_0);

		/// <summary>
		///         查找类似 文件”{0}“已经修改，尚未保存，是否保存文件？ 的本地化字符串。
		///       </summary>
		internal static string PromptSaveFile_Name => ResourceManager.GetString("PromptSaveFile_Name", cultureInfo_0);

		/// <summary>
		///         查找类似 文档内容已经改变，是否保存？ 的本地化字符串。
		///       </summary>
		internal static string QuerySave => ResourceManager.GetString("QuerySave", cultureInfo_0);

		/// <summary>
		///         查找类似 单选框属性 的本地化字符串。
		///       </summary>
		internal static string RadioboxProperty => ResourceManager.GetString("RadioboxProperty", cultureInfo_0);

		/// <summary>
		///         查找类似 只读 的本地化字符串。
		///       </summary>
		internal static string Readonly => ResourceManager.GetString("Readonly", cultureInfo_0);

		/// <summary>
		///         查找类似 本命令已经淘汰了，请使用页面设置对话框中的文档网格线功能，或者设置document.PageSettings.DocumentGridLine属性。 的本地化字符串。
		///       </summary>
		internal static string RecommentDocumentGridLine => ResourceManager.GetString("RecommentDocumentGridLine", cultureInfo_0);

		/// <summary>
		///         查找类似 必须设置WebWriterControl.ServicePageURL属性值。可以新建一个空白的ASPX页面，在Page_Load中执行代码“DCSoft.Writer.Controls.WebWriterControl.HandleServicePage(this);”，然后设置ServicePageURL属性值为该页面地址。 的本地化字符串。
		///       </summary>
		internal static string RequireServicePageURL => ResourceManager.GetString("RequireServicePageURL", cultureInfo_0);

		/// <summary>
		///         查找类似 返回空值。 的本地化字符串。
		///       </summary>
		internal static string ReturnNull => ResourceManager.GetString("ReturnNull", cultureInfo_0);

		/// <summary>
		///         查找类似 RTF文件(*.rtf)|*.rtf 的本地化字符串。
		///       </summary>
		internal static string RTFFileFilter => ResourceManager.GetString("RTFFileFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 保存完成，共保存了{0}。 的本地化字符串。
		///       </summary>
		internal static string SaveComplete_Size => ResourceManager.GetString("SaveComplete_Size", cultureInfo_0);

		/// <summary>
		///         查找类似 正在保存文件“{0}”... 的本地化字符串。
		///       </summary>
		internal static string Saving_FileName => ResourceManager.GetString("Saving_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 脚本代码编译失败。 的本地化字符串。
		///       </summary>
		internal static string ScriptCompileFail => ResourceManager.GetString("ScriptCompileFail", cultureInfo_0);

		/// <summary>
		///         查找类似 脚本代码编译成功。 的本地化字符串。
		///       </summary>
		internal static string ScriptCompileOK => ResourceManager.GetString("ScriptCompileOK", cultureInfo_0);

		/// <summary>
		///         查找类似 请选择默认打印机名称 的本地化字符串。
		///       </summary>
		internal static string SelectDefaultPrinterName => ResourceManager.GetString("SelectDefaultPrinterName", cultureInfo_0);

		/// <summary>
		///         查找类似 选择事件监视器 的本地化字符串。
		///       </summary>
		internal static string SelectEventListener => ResourceManager.GetString("SelectEventListener", cultureInfo_0);

		/// <summary>
		///         查找类似 单元格 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeCell => ResourceManager.GetString("StyleApplyRangeCell", cultureInfo_0);

		/// <summary>
		///         查找类似 文档域 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeField => ResourceManager.GetString("StyleApplyRangeField", cultureInfo_0);

		/// <summary>
		///         查找类似 段落 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeParagraph => ResourceManager.GetString("StyleApplyRangeParagraph", cultureInfo_0);

		/// <summary>
		///         查找类似 表格行 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeRow => ResourceManager.GetString("StyleApplyRangeRow", cultureInfo_0);

		/// <summary>
		///         查找类似 文档节 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeSection => ResourceManager.GetString("StyleApplyRangeSection", cultureInfo_0);

		/// <summary>
		///         查找类似 表格 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeTable => ResourceManager.GetString("StyleApplyRangeTable", cultureInfo_0);

		/// <summary>
		///         查找类似 文本 的本地化字符串。
		///       </summary>
		internal static string StyleApplyRangeText => ResourceManager.GetString("StyleApplyRangeText", cultureInfo_0);

		/// <summary>
		///         查找类似 配置“{0}”的运行环境成功。 的本地化字符串。
		///       </summary>
		internal static string SucccessSetSite_Site => ResourceManager.GetString("SucccessSetSite_Site", cultureInfo_0);

		/// <summary>
		///         查找类似 验证地址“{0}”处的程序集文件失败，可能是WEB服务器上的程序集文件不存在或无法下载或者程序集文件内容和本程序集内容不一致。 的本地化字符串。
		///       </summary>
		internal static string SuccessInvalidateFile_Url => ResourceManager.GetString("SuccessInvalidateFile_Url", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的向系统注册了程序集“{0}”的COM接口。 的本地化字符串。
		///       </summary>
		internal static string SuccessRegAsm_FileName => ResourceManager.GetString("SuccessRegAsm_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的设置了.NET框架安全性为完全信任。 的本地化字符串。
		///       </summary>
		internal static string SuccessSetFullTrust => ResourceManager.GetString("SuccessSetFullTrust", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的设置站点“{0}”为可信站点。 的本地化字符串。
		///       </summary>
		internal static string SuccessSetTrustSite_Site => ResourceManager.GetString("SuccessSetTrustSite_Site", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的向系统注销了程序集"{0}"的COM接口。 的本地化字符串。
		///       </summary>
		internal static string SuccessUnRegAsm_FileName => ResourceManager.GetString("SuccessUnRegAsm_FileName", cultureInfo_0);

		/// <summary>
		///         查找类似 成功的验证了地址“{0}”处的程序集文件。 的本地化字符串。
		///       </summary>
		internal static string SuccessValidateFile_Url => ResourceManager.GetString("SuccessValidateFile_Url", cultureInfo_0);

		/// <summary>
		///         查找类似 系统提示 的本地化字符串。
		///       </summary>
		internal static string SystemAlert => ResourceManager.GetString("SystemAlert", cultureInfo_0);

		/// <summary>
		///         查找类似 正在上传{0}，以上传{1}共{2}。 的本地化字符串。
		///       </summary>
		internal static string Uploading_Name_Size_Total => ResourceManager.GetString("Uploading_Name_Size_Total", cultureInfo_0);

		/// <summary>
		///         查找类似 用户取消操作。 的本地化字符串。
		///       </summary>
		internal static string UserCancel => ResourceManager.GetString("UserCancel", cultureInfo_0);

		/// <summary>
		///         查找类似 数据校验失败. 的本地化字符串。
		///       </summary>
		internal static string ValueValidateFail => ResourceManager.GetString("ValueValidateFail", cultureInfo_0);

		/// <summary>
		///         查找类似 数据校验成功. 的本地化字符串。
		///       </summary>
		internal static string ValueValidateOK => ResourceManager.GetString("ValueValidateOK", cultureInfo_0);

		/// <summary>
		///         查找类似 控件状态不对,可能是服务器会话超时,操作失败，可能需要刷新整个页面。 的本地化字符串。
		///       </summary>
		internal static string WebControlStateInvalidate => ResourceManager.GetString("WebControlStateInvalidate", cultureInfo_0);

		/// <summary>
		///         查找类似 XML文件|*.xml 的本地化字符串。
		///       </summary>
		internal static string XMLFilter => ResourceManager.GetString("XMLFilter", cultureInfo_0);

		/// <summary>
		///         查找类似 XML文件|*.xml 的本地化字符串。
		///       </summary>
		internal static string XMLFilter1 => ResourceManager.GetString("XMLFilter1", cultureInfo_0);

		internal WriterStrings()
		{
		}
	}
}
