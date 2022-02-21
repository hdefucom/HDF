using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       标准功能命令名称
	///       </summary>
	/// <remarks>编写 袁永福</remarks>
	
	[ComVisible(false)]
	[DocumentComment]
	public class StandardCommandNames
	{
		public const string GCCollect = "GCCollect";

		public const string InsertNewMedicalExpression = "InsertNewMedicalExpression";

		public const string ElementPropertyExpressions = "ElementPropertyExpressions";

		public const string SpecifyPageIndex = "SpecifyPageIndex";

		public const string ShowSystemLog = "ShowSystemLog";

		public const string GlobalDebugInfo = "GlobalDebugInfo";

		public const string GenerateCABFile = "GenerateCABFile";

		public const string HeaderFormat = "HeaderFormat";

		public const string InsertDirectoryField = "InsertDirectoryField";

		public const string UpdateDirectoryField = "UpdateDirectoryField";

		public const string Header1 = "Header1";

		public const string Header2 = "Header2";

		public const string Header3 = "Header3";

		public const string Header4 = "Header4";

		public const string Header5 = "Header5";

		public const string Header6 = "Header6";

		public const string Header1WithMultiNumberlist = "Header1WithMultiNumberlist";

		public const string Header2WithMultiNumberlist = "Header2WithMultiNumberlist";

		public const string Header3WithMultiNumberlist = "Header3WithMultiNumberlist";

		public const string Header4WithMultiNumberlist = "Header4WithMultiNumberlist";

		public const string Header5WithMultiNumberlist = "Header5WithMultiNumberlist";

		public const string Header6WithMultiNumberlist = "Header6WithMultiNumberlist";

		/// <summary>
		///       保存控件的截屏图片
		///       </summary>
		public const string SaveControlSnapshot = "SaveControlSnapshot";

		/// <summary>
		///       为调试而保存文件
		///       </summary>
		public const string DebugSaveFile = "DebugSaveFile";

		/// <summary>
		///       为调试而加载文件
		///       </summary>
		public const string DebugLoadFile = "DebugLoadFile";

		/// <summary>
		///       测试基础打印功能
		///       </summary>
		public const string TestPrint = "TestPrint";

		/// <summary>
		///       隐藏被标记为自动隐藏的元素
		///       </summary>
		public const string HideElementMarkAutoHide = "HideElementMarkAutoHide";

		/// <summary>
		///       显示被标记为自动隐藏的元素
		///       </summary>
		public const string ShowElementMarkAutoHide = "ShowElementMarkAutoHide";

		public const string ModuleData = "Data";

		public const string GenerateCreateInstanceCode = "GenerateCreateInstanceCode";

		/// <summary>
		///       文档信息
		///       </summary>
		public const string DocumentInfo = "DocumentInfo";

		/// <summary>
		///       文件功能模块名称
		///       </summary>
		public const string ModuleFile = "File";

		/// <summary>
		///       设置默认打印机名称
		///       </summary>
		public const string SetDefaultPrinterName = "SetDefaultPrinterName";

		/// <summary>
		///       打开文件
		///       </summary>
		public const string FileOpen = "FileOpen";

		/// <summary>
		///       重新加载当前文件
		///       </summary>
		public const string FileReload = "FileReload";

		/// <summary>
		///       准备关闭编辑器
		///       </summary>
		public const string FileQueryExit = "FileQueryExit";

		/// <summary>
		///       打开旧格式的XML文档
		///       </summary>
		public const string FileOpenOldXMLFormat = "FileOpenOldXMLFormat";

		/// <summary>
		///       打开指定URL路径的文档
		///       </summary>
		public const string FileOpenUrl = "FileOpenUrl";

		/// <summary>
		///       从字符串加载文件
		///       </summary>
		public const string FileOpenString = "FileOpenString";

		/// <summary>
		///       新建文件
		///       </summary>
		public const string FileNew = "FileNew";

		/// <summary>
		///       保存文件
		///       </summary>
		public const string FileSave = "FileSave";

		/// <summary>
		///       只保存文档中被选择的内容
		///       </summary>
		public const string FileSaveSelection = "FileSaveSelection";

		/// <summary>
		///       文件另存为
		///       </summary>
		public const string FileSaveAs = "FileSaveAs";

		/// <summary>
		///       调试模式的文件另存为
		///       </summary>
		public const string FileSaveAsInDebugMode = "FileSaveAsInDebugMode";

		/// <summary>
		///       只打印文档中呗选择的内容
		///       </summary>
		public const string FilePrintSelection = "FilePrintSelection";

		/// <summary>
		///       打印整个文档
		///       </summary>
		public const string FilePrint = "FilePrint";

		/// <summary>
		///       手动双面打印
		///       </summary>
		public const string FilePrintWithManualDuplex = "FilePrintWithManualDuplex";

		/// <summary>
		///       整洁打印,不打印修改痕迹和标记。
		///       </summary>
		public const string FileCleanPrint = "FileCleanPrint";

		/// <summary>
		///       打印当前页
		///       </summary>
		public const string FilePrintCurrentPage = "FilePrintCurrentPage";

		/// <summary>
		///       打印预览
		///       </summary>
		public const string FilePrintPreview = "FilePrintPreview";

		/// <summary>
		///       文档页面设置
		///       </summary>
		public const string FilePageSettings = "FilePageSettings";

		/// <summary>
		///       获得文件XML代码
		///       </summary>
		public const string ViewXMLSource = "ViewXMLSource";

		/// <summary>
		///       进行HTML预览
		///       </summary>
		public const string HtmlPreview = "HtmlPreview";

		/// <summary>
		///       调用记事本查看文件XML代码
		///       </summary>
		public const string ViewXMLSourceWithNotePad = "ViewXMLSourceWithNotePad";

		/// <summary>
		///       获得文档中被选择部分的内容文本值
		///       </summary>
		public const string GetSelectionContentText = "GetSelectionContentText";

		/// <summary>
		///       获得文档中表示用户痕迹列表的XML字符串
		///       </summary>
		public const string GetUserTrackInfosXMLString = "GetUserTrackInfosXMLString";

		/// <summary>
		///       注册
		///       </summary>
		public const string Register = "Register";

		/// <summary>
		///       根据母狗注册开发版授权
		///       </summary>
		public const string RegisterWithBitch = "RegisterWithBitch";

		/// <summary>
		///       加载知识库文件
		///       </summary>
		public const string LoadKBLibrary = "LoadKBLibrary";

		/// <summary>
		///       加载知识库而且不进行过滤
		///       </summary>
		public const string LoadKBLibraryWithoutFilter = "LoadKBLibraryWithoutFilter";

		/// <summary>
		///       保存知识库文件
		///       </summary>
		public const string SaveKBLibrary = "SaveKBLibrary";

		/// <summary>
		///       清空缓存的数据
		///       </summary>
		public const string ClearBuffer = "ClearBuffer";

		/// <summary>
		///       编辑器控件属性
		///       </summary>
		public const string WriterControlProperties = "WriterControlProperties";

		/// <summary>
		///       文档选项
		///       </summary>
		public const string DocumentOptions = "DocumentOptions";

		public const string DeveloperTools = "DeveloperTools";

		public const string DocumentContentStyles = "DocumentContentStyles";

		/// <summary>
		///       设置文档的默认字体
		///       </summary>
		public const string DocumentDefaultFont = "DocumentDefaultFont";

		/// <summary>
		///       根据数据源更新文档视图
		///       </summary>
		public const string UpdateViewForDataSource = "UpdateViewForDataSource";

		/// <summary>
		///       读取文档视图，更新数据源
		///       </summary>
		public const string UpdateDataSourceForView = "UpdateDataSourceForView";

		/// <summary>
		///       浏览功能模块名称
		///       </summary>
		public const string ModuleBrowse = "Browse";

		public const string RefreshDocument = "RefreshDocument";

		public const string Focus = "Focus";

		/// <summary>
		///       打开文件所在目录
		///       </summary>
		public const string OpenFileDirectory = "OpenFileDirectory";

		/// <summary>
		///       从左到右排版
		///       </summary>
		public const string LeftToRight = "LeftToRight";

		/// <summary>
		///       从右到左排版
		///       </summary>
		public const string RightToLeft = "RightToLeft";

		/// <summary>
		///       文档网格线
		///       </summary>
		public const string DocumentGridLine = "DocumentGridLine";

		public const string DocumentGridLineNew = "DocumentGridLineNew";

		public const string DocumentGridLineVisible = "DocumentGridLineVisible";

		public const string HeaderBottomLineVisible = "HeaderBottomLineVisible";

		/// <summary>
		///       编辑器命令列表
		///       </summary>
		public const string WriterCommandList = "WriterCommandList";

		/// <summary>
		///       运行环境配置
		///       </summary>
		public const string EnvironmentConfig = "EnvironmentConfig";

		/// <summary>
		///       使用一个数据源描述信息插入输入域
		///       </summary>
		public const string InsertInputFieldWithDataSourceDescriptor = "InsertInputFieldWithDataSourceDescriptor";

		/// <summary>
		///       显示调试输出窗口
		///       </summary>
		public const string DebugOutputWindow = "DebugOutputWindow";

		/// <summary>
		///       管理员视图模式
		///       </summary>
		public const string AdministratorViewMode = "AdministratorViewMode";

		/// <summary>
		///       后台运行模式
		///       </summary>
		public const string BackgroundMode = "BackgroundMode";

		/// <summary>
		///       设置为自动登录
		///       </summary>
		public const string SetAutoLogin = "SetAutoLogin";

		/// <summary>
		///       设置自动登录的用户信息
		///       </summary>
		public const string SetUserInfo = "SetUserInfo";

		/// <summary>
		///       显示关于控件对话框
		///       </summary>
		public const string AboutControl = "AboutControl";

		/// <summary>
		///       创建C#的对象实例
		///       </summary>
		public const string CreateInstance = "CreateInstance";

		/// <summary>
		///       添加服务功能对象
		///       </summary>
		public const string AddService = "AddService";

		/// <summary>
		///       自动换行视图模式
		///       </summary>
		public const string AutoLineViewMode = "AutoLineViewMode";

		/// <summary>
		///       续打模式
		///       </summary>
		public const string JumpPrintMode = "JumpPrintMode";

		/// <summary>
		///       偏移续打模式
		///       </summary>
		public const string OffsetJumpPrintMode = "OffsetJumpPrintMode";

		/// <summary>
		///       根据文档选择区域来设置续打状态
		///       </summary>
		public const string JumpPrintModeBySelection = "JumpPrintModeBySelection";

		/// <summary>
		///       根据子文档节的状态来设置续打状态
		///       </summary>
		public const string JumpPrintModeBySubDocument = "JumpPrintModeBySubDocument";

		/// <summary>
		///       区域选择视图模式
		///       </summary>
		public const string BoundsSelectionViewMode = "BoundsSelectionViewMode";

		/// <summary>
		///       退出续打模式，清除续打位置
		///       </summary>
		public const string ClearJumpPrintMode = "ClearJumpPrintMode";

		/// <summary>
		///       页面视图方式
		///       </summary>
		public const string PageViewMode = "PageViewMode";

		/// <summary>
		///       常规视图方式
		///       </summary>
		public const string NormalViewMode = "NormalViewMode";

		/// <summary>
		///       常规居中视图方式
		///       </summary>
		public const string NormalCenterViewMode = "NormalCenterViewMode";

		/// <summary>
		///       阅读版式视图方式
		///       </summary>
		public const string ReadViewMode = "ReadViewMode";

		/// <summary>
		///       显示背景单元格编号
		///       </summary>
		public const string ShowBackgroundCellID = "ShowBackgroundCellID";

		/// <summary>
		///       显示文档元素扩展文本
		///       </summary>
		public const string ShowAdornText = "ShowAdornText";

		/// <summary>
		///       显示表单按钮
		///       </summary>
		public const string ShowFormButton = "ShowFormButton";

		/// <summary>
		///       隐藏表单按钮
		///       </summary>
		public const string HiddenFormButton = "HiddenFormButton";

		/// <summary>
		///       显示标尺
		///       </summary>
		public const string RuleVisible = "RuleVisible";

		/// <summary>
		///       表单视图方式
		///       </summary>
		public const string FormViewMode = "FormViewMode";

		/// <summary>
		///       整洁视图模式
		///       </summary>
		public const string CleanViewMode = "CleanViewMode";

		/// <summary>
		///       复合视图模式
		///       </summary>
		public const string ComplexViewMode = "ComplexViewMode";

		/// <summary>
		///       放大,Core模块用到该命令。
		///       </summary>
		public const string ZoomIn = "ZoomIn";

		/// <summary>
		///       缩小,Core模块用到该命令。
		///       </summary>
		public const string ZoomOut = "ZoomOut";

		/// <summary>
		///       设置缩放
		///       </summary>
		public const string Zoom = "Zoom";

		/// <summary>
		///       设置原始显示比例
		///       </summary>
		public const string ZoomReset = "ZoomReset";

		/// <summary>
		///       自动缩放
		///       </summary>
		public const string ZoomAuto = "ZoomAuto";

		/// <summary>
		///       调试模式
		///       </summary>
		public const string DebugMode = "DebugMode";

		/// <summary>
		///       设计模式
		///       </summary>
		public const string DesignMode = "DesignMode";

		/// <summary>
		///       重置VBA脚本引擎
		///       </summary>
		public const string ResetScriptEngine = "ResetScriptEngine";

		/// <summary>
		///       搜索,暂不支持
		///       </summary>
		public const string Search = "Search";

		/// <summary>
		///       搜索和替换
		///       </summary>
		public const string SearchReplace = "SearchReplace";

		/// <summary>
		///       移动插入点的位置
		///       </summary>
		public const string MoveTo = "MoveTo";

		/// <summary>
		///       移动插入点到指定的位置
		///       </summary>
		public const string MoveToPosition = "MoveToPosition";

		/// <summary>
		///       移动插入点到指定页面
		///       </summary>
		public const string MoveToPage = "MoveToPage";

		/// <summary>
		///       向上翻页
		///       </summary>
		public const string MovePageUp = "MovePageUp";

		/// <summary>
		///       向下翻页
		///       </summary>
		public const string MovePageDown = "MovePageDown";

		/// <summary>
		///       向上移动一行
		///       </summary>
		public const string MoveUp = "MoveUp";

		/// <summary>
		///       向下移动一行
		///       </summary>
		public const string MoveDown = "MoveDown";

		/// <summary>
		///       向左移动一列
		///       </summary>
		public const string MoveLeft = "MoveLeft";

		/// <summary>
		///       向右移动一列
		///       </summary>
		public const string MoveRight = "MoveRight";

		/// <summary>
		///       移动到行首
		///       </summary>
		public const string MoveHome = "MoveHome";

		/// <summary>
		///       移动到行尾
		///       </summary>
		public const string MoveEnd = "MoveEnd";

		/// <summary>
		///       带选择的向上翻页
		///       </summary>
		public const string ShiftMovePageUp = "ShiftMovePageUp";

		/// <summary>
		///       带选择的向下翻页
		///       </summary>
		public const string ShiftMovePageDown = "ShiftMovePageDown";

		/// <summary>
		///       带选择的向上移动一行
		///       </summary>
		public const string ShiftMoveUp = "ShiftMoveUp";

		/// <summary>
		///       带选择的向下移动一行
		///       </summary>
		public const string ShiftMoveDown = "ShiftMoveDown";

		/// <summary>
		///       带选择的向左移动一列
		///       </summary>
		public const string ShiftMoveLeft = "ShiftMoveLeft";

		/// <summary>
		///       带选择的向右移动一列
		///       </summary>
		public const string ShiftMoveRight = "ShiftMoveRight";

		/// <summary>
		///       带选择的移动到行首
		///       </summary>
		public const string ShiftMoveHome = "ShiftMoveHome";

		/// <summary>
		///       带选择的移动到行尾
		///       </summary>
		public const string ShiftMoveEnd = "ShiftMoveEnd";

		/// <summary>
		///       让页面向上滚动一行而不改变插入点的位置
		///       </summary>
		public const string CtlMoveUp = "CtlMoveUp";

		/// <summary>
		///       让页面向下滚动一行而不改变插入点的位置
		///       </summary>
		public const string CtlMoveDown = "CtlMoveDown";

		/// <summary>
		///       全选
		///       </summary>
		public const string SelectAll = "SelectAll";

		/// <summary>
		///       字数统计
		///       </summary>
		public const string WordCount = "WordCount";

		/// <summary>
		///       选中光标所在的当前行
		///       </summary>
		public const string SelectLine = "SelectLine";

		/// <summary>
		///       编辑功能模块名称
		///       </summary>
		public const string ModuleEdit = "Edit";

		/// <summary>
		///       将文档内容转换为一个输入域
		///       </summary>
		public const string ConvertContentToField = "ConvertContentToField";

		/// <summary>
		///       将文档内容转换为一个容器元素
		///       </summary>
		public const string ConvertContentToContainerElement = "ConvertContentToContainerElement";

		/// <summary>
		///       将输入域转换为普通文档内容
		///       </summary>
		public const string ConvertFieldToContent = "ConvertFieldToContent";

		/// <summary>
		///       将文档内容转换为表单元素的标签文本
		///       </summary>
		public const string ConvertTextContentToElementLabel = "ConvertTextContentToElementLabel";

		/// <summary>
		///       替换,暂不支持
		///       </summary>
		public const string Replace = "Replace";

		/// <summary>
		///       退格删除
		///       </summary>
		public const string Backspace = "Backspace";

		/// <summary>
		///       复制
		///       </summary>
		public const string Copy = "Copy";

		/// <summary>
		///       已文本方式进行复制
		///       </summary>
		public const string CopyAsText = "CopyAsText";

		/// <summary>
		///       带清空输入域内容的复制
		///       </summary>
		public const string CopyWithClearFieldValue = "CopyWithClearFieldValue";

		/// <summary>
		///       剪切
		///       </summary>
		public const string Cut = "Cut";

		/// <summary>
		///       粘贴
		///       </summary>
		public const string Paste = "Paste";

		public const string PasteAsText = "PasteAsText";

		/// <summary>
		///       选择性粘贴
		///       </summary>
		public const string SpecifyPaste = "SpecifyPaste";

		/// <summary>
		///       删除
		///       </summary>
		public const string Delete = "Delete";

		/// <summary>
		///       物理删除,当处于逻辑删除模式下调用该命令能物理删除内容
		///       </summary>
		public const string DeleteAbsolute = "DeleteAbsolute";

		/// <summary>
		///       删除文档中后面的空白内容
		///       </summary>
		public const string DeleteRedundant = "DeleteRedundant";

		/// <summary>
		///       清空所有输入域中的内容
		///       </summary>
		public const string ClearInputFieldValue = "ClearInputFieldValue";

		/// <summary>
		///       撤销,Core模块用到该命令。
		///       </summary>
		public const string Undo = "Undo";

		/// <summary>
		///       重做,Core模块用到该命令。
		///       </summary>
		public const string Redo = "Redo";

		/// <summary>
		///       清除撤销操作信息列表
		///       </summary>
		public const string ClearUndo = "ClearUndo";

		/// <summary>
		///       排版方向
		///       </summary>
		public const string LayoutDirection = "LayoutDirection";

		/// <summary>
		///       段落左对齐
		///       </summary>
		public const string AlignLeft = "AlignLeft";

		/// <summary>
		///       段落居中对齐
		///       </summary>
		public const string AlignCenter = "AlignCenter";

		/// <summary>
		///       段落右对齐
		///       </summary>
		public const string AlignRight = "AlignRight";

		/// <summary>
		///       段落两边对齐
		///       </summary>
		public const string AlignJustify = "AlignJustify";

		/// <summary>
		///       分散对齐
		///       </summary>
		public const string AlignDistribute = "AlignDistribute";

		/// <summary>
		///       粗体
		///       </summary>
		public const string Bold = "Bold";

		/// <summary>
		///       斜体
		///       </summary>
		public const string Italic = "Italic";

		/// <summary>
		///       下划线
		///       </summary>
		public const string Underline = "Underline";

		/// <summary>
		///       用下边框形式实现的下划线
		///       </summary>
		public const string InputFieldUnderLine = "InputFieldUnderLine";

		/// <summary>
		///       设置删除线
		///       </summary>
		public const string Strikeout = "Strikeout";

		/// <summary>
		///       设置内边距
		///       </summary>
		public const string Padding = "Padding";

		/// <summary>
		///       固定字符间距
		///       </summary>
		public const string FixedSpacing = "FixedSpacing";

		/// <summary>
		///       字符间距
		///       </summary>
		public const string LetterSpacing = "LetterSpacing";

		/// <summary>
		///       字体设置
		///       </summary>
		public const string Font = "Font";

		public const string UnderlineStyle = "UnderlineStyle";

		/// <summary>
		///       字体名称
		///       </summary>
		public const string FontName = "FontName";

		/// <summary>
		///       字体大小
		///       </summary>
		public const string FontSize = "FontSize";

		/// <summary>
		///       前景色
		///       </summary>
		public const string Color = "Color";

		/// <summary>
		///       打印用颜色
		///       </summary>
		public const string PrintColor = "PrintColor";

		/// <summary>
		///       打印用背景色
		///       </summary>
		public const string PrintBackColor = "PrintBackColor";

		/// <summary>
		///       设置显示样式
		///       </summary>
		public const string Visibility = "Visibility";

		/// <summary>
		///       背景色
		///       </summary>
		public const string BackColor = "BackColor";

		/// <summary>
		///       字符套圈
		///       </summary>
		public const string CharacterCircle = "CharacterCircle";

		/// <summary>
		///       设置标题层次
		///       </summary>
		public const string TitleLevel = "TitleLevel";

		/// <summary>
		///       设置内容保护
		///       </summary>
		public const string ContentProtect = "ContentProtect";

		/// <summary>
		///       智能的设置容器元素事件模板的名称
		///       </summary>
		public const string SmartSetEventTemplateName = "SmartSetEventTemplateName";

		/// <summary>
		///       编辑文档元素的VB脚本代码
		///       </summary>
		public const string EditElementEventVBScript = "EditElementEventVBScript";

		/// <summary>
		///       段落左边框线
		///       </summary>
		public const string BorderLeft = "BorderLeft";

		/// <summary>
		///       段落上边框线
		///       </summary>
		public const string BorderTop = "BorderTop";

		/// <summary>
		///       段落右边框线
		///       </summary>
		public const string BorderRight = "BorderRight";

		/// <summary>
		///       段落下边框线
		///       </summary>
		public const string BorderBottom = "BorderBottom";

		/// <summary>
		///       设置文档默认样式
		///       </summary>
		public const string SetDefaultStyle = "SetDefaultStyle";

		/// <summary>
		///       插入文档节
		///       </summary>
		public const string InsertSection = "InsertSection";

		/// <summary>
		///       繁体转换为简体
		///       </summary>
		public const string TraditionalToSimplified = "TraditionalToSimplified";

		/// <summary>
		///       简体转换为繁体
		///       </summary>
		public const string SimplifiedToTraditional = "SimplifiedToTraditional";

		/// <summary>
		///       简体和繁体相互转换
		///       </summary>
		public const string SimplifiedSwapTraditional = "SimplifiedSwapTraditional";

		/// <summary>
		///       删除文档节
		///       </summary>
		public const string DeleteSection = "DeleteSection";

		/// <summary>
		///       删除一行文本
		///       </summary>
		public const string DeleteLine = "DeleteLine";

		/// <summary>
		///       文档节的边框和背景设置
		///       </summary>
		public const string SectionBorderBackgroundFormat = "SectionBorderBackgroundFormat";

		public const string InsertWhiteSpaceForAlignRight = "InsertWhiteSpaceForAlignRight";

		/// <summary>
		///       插入纯文本数据
		///       </summary>
		public const string InsertString = "InsertString";

		/// <summary>
		///       辅助插入字符串
		///       </summary>
		public const string AssistInsertString = "AssistInsertString";

		/// <summary>
		///       加载全局的辅助插入字符串列表项目
		///       </summary>
		public const string LoadGlobalAssistStringItem = "LoadGlobalAssistStringItem";

		/// <summary>
		///       从文件加载全局的辅助插入字符串列表项目
		///       </summary>
		public const string LoadGlobalAssistStringItemFromFile = "LoadGlobalAssistStringItemFromFile";

		/// <summary>
		///       插入一段XML文档
		///       </summary>
		public const string InsertXML = "InsertXML";

		/// <summary>
		///       插入一段XML文档并清除文档格式
		///       </summary>
		public const string InsertXMLWithClearFormat = "InsertXMLWithClearFormat";

		/// <summary>
		///       插入一段XML文档并清除文档中的字体名称和大小
		///       </summary>
		public const string InsertXMLWithClearFontNameSize = "InsertXMLWithClearFontNameSize";

		/// <summary>
		///       插入HTML文档
		///       </summary>
		public const string InsertHtml = "InsertHtml";

		/// <summary>
		///       插入文件内容
		///       </summary>
		public const string InsertFileContent = "InsertFileContent";

		/// <summary>
		///       插入文档内容链接
		///       </summary>
		public const string InsertContentLink = "InsertContentLink";

		/// <summary>
		///       插入文件内容块
		///       </summary>
		public const string InsertFileBlock = "InsertFileBlock";

		/// <summary>
		///       插入自定义图形
		///       </summary>
		public const string InsertCustomShape = "InsertCustomShape";

		/// <summary>
		///       插入RTF文本数据
		///       </summary>
		public const string InsertRTF = "InsertRTF";

		/// <summary>
		///       插入软回车
		///       </summary>
		public const string InsertLineBreak = "InsertLineBreak";

		/// <summary>
		///       插入分页符
		///       </summary>
		public const string InsertPageBreak = "InsertPageBreak";

		/// <summary>
		///       插入一个段落符号
		///       </summary>
		public const string InsertParagrahFlag = "InsertParagrahFlag";

		/// <summary>
		///       插入知识库节点
		///       </summary>
		public const string InsertKBEntry = "InsertKBEntry";

		/// <summary>
		///       根据当前插入点前面的文字开始插入知识库节点
		///       </summary>
		public const string BeginInsertKBEntryByPreWord = "BeginInsertKBEntryByPreWord";

		/// <summary>
		///       插入一个按钮
		///       </summary>
		public const string InsertButton = "InsertButton";

		/// <summary>
		///       插入图片
		///       </summary>
		public const string InsertImage = "InsertImage";

		/// <summary>
		///       使用截屏的方式插入图片
		///       </summary>
		public const string InsertImageWithScreenSnapshot = "InsertImageWithScreenSnapshot";

		/// <summary>
		///       使用延时截屏的方式插入图片
		///       </summary>
		public const string InsertImageWithScreenSnapshotDelay = "InsertImageWithScreenSnapshotDelay";

		/// <summary>
		///       插入文本标签元素
		///       </summary>
		public const string InsertLabel = "InsertLabel";

		/// <summary>
		///       插入水平线
		///       </summary>
		public const string InsertHorizontalLine = "InsertHorizontalLine";

		/// <summary>
		///       显示详细选项的方式插入图片 
		///       </summary>
		public const string InsertImageExt = "InsertImageExt";

		/// <summary>
		///       添加会计数字元素
		///       </summary>
		public const string InsertAccountingNumber = "InsertAccountingNumber";

		/// <summary>
		///       插入条码
		///       </summary>
		public const string InsertBarcode = "InsertBarcode";

		public const string InsertNewBarcode = "InsertNewBarcode";

		/// <summary>
		///       插入二维条码
		///       </summary>
		public const string InsertTDBarcode = "InsertTDBarcode";

		/// <summary>
		///       插入文本输入域
		///       </summary>
		public const string InsertInputField = "InsertInputField";

		/// <summary>
		///       插入体温单
		///       </summary>
		public const string InsertTemperatureChart = "InsertTemperatureChart";

		/// <summary>
		///       插入产程图
		///       </summary>
		public const string InsertFriedmanCurveChart = "InsertFriedmanCurveChart";

		/// <summary>
		///       插入媒体元素
		///       </summary>
		public const string InsertMediaElement = "InsertMediaElement";

		/// <summary>
		///       插入控件宿主元素
		///       </summary>
		public const string InsertControlHost = "InsertControlHost";

		/// <summary>
		///       插入文档字段域
		///       </summary>
		public const string InsertDocumentField = "InsertDocumentField";

		/// <summary>
		///       插入页码信息元素
		///       </summary>
		public const string InsertPageInfo = "InsertPageInfo";

		/// <summary>
		///       插入复选框列表
		///       </summary>
		public const string InsertCheckBoxList = "InsertCheckBoxList";

		/// <summary>
		///       插入多个单选框复选框
		///       </summary>
		public const string InsertCheckBoxes = "InsertCheckBoxes";

		/// <summary>
		///       插入复选框
		///       </summary>
		public const string InsertCheckBox = "InsertCheckBox";

		/// <summary>
		///       插入单选框
		///       </summary>
		public const string InsertRadioBox = "InsertRadioBox";

		/// <summary>
		///       插入多个文档元素对象
		///       </summary>
		public const string InsertElements = "InsertElements";

		/// <summary>
		///       插入批注
		///       </summary>
		public const string InsertComment = "InsertComment";

		/// <summary>
		///       编辑文档批注
		///       </summary>
		public const string EditComment = "EditComment";

		/// <summary>
		///       删除批注
		///       </summary>
		public const string DeleteComment = "DeleteComment";

		/// <summary>
		///       不校验权限的删除批注
		///       </summary>
		public const string DeleteCommentWithoutValidatePermission = "DeleteCommentWithoutValidatePermission";

		/// <summary>
		///       删除文档中所有的批注
		///       </summary>
		public const string DeleteAllComment = "DeleteAllComment";

		/// <summary>
		///       签名锁定文档内容
		///       </summary>
		public const string SignDocument = "SignDocument";

		/// <summary>
		///       删除文本输入域
		///       </summary>
		public const string DeleteField = "DeleteField";

		/// <summary>
		///       旧的删除选中的文档内容
		///       </summary>
		public const string DeleteSelectionOld = "DeleteSelectionOld";

		/// <summary>
		///       设置输入语言
		///       </summary>
		public const string SetInputLanguage = "SetInputLanguage";

		/// <summary>
		///       设置插入/替换模式
		///       </summary>
		public const string InsertMode = "InsertMode";

		/// <summary>
		///       段落列表样式
		///       </summary>
		public const string ParagraphListStyle = "ParagraphListStyle";

		/// <summary>
		///       数字列表
		///       </summary>
		public const string NumberedList = "NumberedList";

		/// <summary>
		///       圆点列表
		///       </summary>
		public const string BulletedList = "BulletedList";

		/// <summary>
		///       首行缩进
		///       </summary>
		public const string FirstLineIndent = "FirstLineIndent";

		/// <summary>
		///       特别的首行缩进
		///       </summary>
		public const string IncreaseFirstLineIndent = "IncreaseFirstLineIndent";

		/// <summary>
		///       上标
		///       </summary>
		public const string Superscript = "Superscript";

		/// <summary>
		///       下标
		///       </summary>
		public const string Subscript = "Subscript";

		/// <summary>
		///       插入变量
		///       </summary>
		public const string InsertParameter = "InsertParameter";

		/// <summary>
		///       修改元素属性
		///       </summary>
		public const string ElementProperties = "ElementProperties";

		/// <summary>
		///       简洁模式下的修改元素属性
		///       </summary>
		public const string ElementPropertiesSimpleMode = "ElementPropertiesSimpleMode";

		/// <summary>
		///       文档元素表达式
		///       </summary>
		public const string ElementExpression = "ElementExpression";

		/// <summary>
		///       编辑元素值
		///       </summary>
		public const string EditElementValue = "EditElementValue";

		/// <summary>
		///       执行文档元素默认方法
		///       </summary>
		public const string ExecuteElementDefaultMethod = "ExecuteElementDefaultMethod";

		/// <summary>
		///       段落格式
		///       </summary>
		public const string ParagraphFormat = "ParagraphFormat";

		/// <summary>
		///       边框和背景格式
		///       </summary>
		public const string BorderBackgroundFormat = "BorderBackgroundFormat";

		/// <summary>
		///       页面边框和背景格式
		///       </summary>
		public const string PageBorderBackgroundFormat = "PageBorderBackgroundFormat";

		/// <summary>
		///       输入域的边框和背景格式
		///       </summary>
		public const string FieldBorderBackgroundFormat = "FieldBorderBackgroundFormat";

		/// <summary>
		///       编辑图片附加的图形
		///       </summary>
		public const string EditImageAdditionShape = "EditImageAdditionShape";

		/// <summary>
		///       对文档中的数据进行校验
		///       </summary>
		public const string DocumentValueValidate = "DocumentValueValidate";

		/// <summary>
		///       对文档中的数据进行校验并自动生成文档批注
		///       </summary>
		public const string DocumentValueValidateWithCreateDocumentComments = "DocumentValueValidateWithCreateDocumentComments";

		/// <summary>
		///       清空数据校验结果
		///       </summary>
		public const string ClearValueValidateResult = "ClearValueValidateResult";

		/// <summary>
		///       编辑文档参数
		///       </summary>
		public const string EditDocumentParameters = "EditDocumentParameters";

		/// <summary>
		///       编辑VBA脚本代码
		///       </summary>
		public const string EditVBAScript = "EditVBAScript";

		/// <summary>
		///       立即执行VBA脚本代码
		///       </summary>
		public const string ExecuteScriptImmediately = "ExecuteScriptImmediately";

		/// <summary>
		///       设置输入域固定宽度
		///       </summary>
		public const string FieldSpecifyWidth = "FieldSpecifyWidth";

		/// <summary>
		///       清除用户留下的痕迹
		///       </summary>
		public const string ClearUserTrace = "ClearUserTrace";

		/// <summary>
		///       清除文档中所有的用户痕迹信息
		///       </summary>
		public const string ClearAllUserTrace = "ClearAllUserTrace";

		/// <summary>
		///       向文档正文附加当前用户痕迹
		///       </summary>
		public const string AttachCurrentUserTrackToBodyContent = "AttachCurrentUserTrackToBodyContent";

		/// <summary>
		///       清空文档正文内容
		///       </summary>
		public const string ClearBodyContent = "ClearBodyContent";

		/// <summary>
		///       提交所有的用户痕迹信息效果，并删除用户痕迹。
		///       </summary>
		public const string CommitUserTrace = "CommitUserTrace";

		/// <summary>
		///       撤销所有用户修订
		///       </summary>
		public const string RejectUserTrace = "RejectUserTrace";

		/// <summary>
		///       清空当前光标所在的输入域的内容
		///       </summary>
		public const string ClearCurrentFieldValue = "ClearCurrentFieldValue";

		/// <summary>
		///       清空文档中所有输入域内容
		///       </summary>
		public const string ClearAllFieldValue = "ClearAllFieldValue";

		/// <summary>
		///       清除文档格式,Core模块用到该命令。
		///       </summary>
		public const string ClearFormat = "ClearFormat";

		/// <summary>
		///       格式刷,Core模块用到该命令。
		///       </summary>
		public const string FormatBrush = "FormatBrush";

		/// <summary>
		///       文字四周围绕
		///       </summary>
		public const string TextSurroundings = "TextSurroundings";

		/// <summary>
		///       嵌入在文字中
		///       </summary>
		public const string EmbedInText = "EmbedInText";

		/// <summary>
		///       表格功能模块名称
		///       </summary>
		public const string ModuleTable = "Table";

		/// <summary>在上面插入表格行</summary>
		public const string Table_InsertRowUp = "Table_InsertRowUp";

		/// <summary>在下面插入表格行</summary>
		public const string Table_InsertRowDown = "Table_InsertRowDown";

		/// <summary>删除表格行</summary>
		public const string Table_DeleteRow = "Table_DeleteRow";

		/// <summary>在左边插入表格列</summary>
		public const string Table_InsertColumnLeft = "Table_InsertColumnLeft";

		/// <summary>在右边插入表格列</summary>
		public const string Table_InsertColumnRight = "Table_InsertColumnRight";

		/// <summary>删除表格列</summary>
		public const string Table_DeleteColumn = "Table_DeleteColumn";

		/// <summary>合并单元格</summary>
		public const string Table_MergeCell = "Table_MergeCell";

		/// <summary>
		///       插入表格
		///       </summary>
		public const string Table_InsertTable = "Table_InsertTable";

		/// <summary>拆分单元格</summary>
		public const string Table_SplitCell = "Table_SplitCell";

		/// <summary>增强的拆分单元格</summary>
		public const string Table_SplitCellExt = "Table_SplitCellExt";

		/// <summary>
		///       在一个表格后面插入新表格行，使得表格延伸到当前页面的最下面。
		///       </summary>
		public const string Table_InsertRowsToPageBottom = "Table_InsertRowsToPageBottom";

		/// <summary>
		///       修改表格行的高度，使其扩展到页面低端
		///       </summary>
		public const string Table_IncreaseRowHeightToPageBottom = "Table_IncreaseRowHeightToPageBottom";

		/// <summary>
		///       根据内容行数来拆分表格行（实现护理记录单效果）
		///       </summary>
		public const string Table_SplitRowsByContentLines = "Table_SplitRowsByContentLines";

		/// <summary>
		///       重置表格样式
		///       </summary>
		public const string Table_ResetTableStyle = "Table_ResetTableStyle";

		/// <summary>
		///       删除最后一页中的空白行
		///       </summary>
		public const string Table_RemoveEmptyRowsInLastPage = "Table_RemoveEmptyRowsInLastPage";

		/// <summary>
		///       将文档表格元素转换为数据表对象
		///       </summary>
		public const string Table_ConvertTableElementToDataTable = "Table_ConvertTableElementToDataTable";

		/// <summary>
		///       删除整个表格
		///       </summary>
		public const string Table_DeleteTable = "Table_DeleteTable";

		/// <summary>
		///       表格单元格的内容对齐方式
		///       </summary>
		public const string Table_CellAlign = "Table_CellAlign";

		/// <summary>
		///       标题行
		///       </summary>
		public const string Table_HeaderRow = "Table_HeaderRow";

		/// <summary>
		///       设置单元格网格线
		///       </summary>
		public const string Table_SetCellGridLine = "Table_SetCellGridLine";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignBottomCenter = "AlignBottomCenter";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignBottomLeft = "AlignBottomLeft";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignBottomRight = "AlignBottomRight";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignMiddleCenter = "AlignMiddleCenter";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignMiddleLeft = "AlignMiddleLeft";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignMiddleRight = "AlignMiddleRight";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignTopCenter = "AlignTopCenter";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignTopLeft = "AlignTopLeft";

		/// <summary>
		///       设置单元格对齐方式
		///       </summary>
		public const string AlignTopRight = "AlignTopRight";

		/// <summary>
		///       设置单元格的网格线
		///       </summary>
		public const string Table_CellGridLine = "Table_CellGridLine";

		/// <summary>
		///       显示所有的隐藏元素
		///       </summary>
		public const string DisplayWhole = "DisplayWhole";

		/// <summary>
		///       保存图片
		///       </summary>
		public const string SaveImageFile = "SaveImageFile";

		/// <summary>
		///       重置表单数据
		///       </summary>
		public const string ResetFormValue = "ResetFormValue";

		/// <summary>
		///       字符串资源
		///       </summary>
		public const string ResourceStrings = "ResourceStrings";

		/// <summary>
		///       着重号
		///       </summary>
		public const string EmphasisMark = "EmphasisMark";

		/// <summary>
		///       标尺
		///       </summary>
		public const string InsertRuler = "InsertRuler";
	}
}
