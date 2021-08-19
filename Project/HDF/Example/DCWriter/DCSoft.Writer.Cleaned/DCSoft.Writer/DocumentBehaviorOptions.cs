using DCSoft.Common;
using DCSoft.Writer.Controls;
using DCSoftDotfuscate;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档行为设置
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Serializable]
	[ComClass("00012345-6789-ABCD-EF01-234567890068", "BAC6B1D5-40D2-4CA5-A09C-C11C595C06B7")]
	[DocumentComment]
	[ComDefaultInterface(typeof(IDocumentBehaviorOptions))]
	[Guid("00012345-6789-ABCD-EF01-234567890068")]
	[TypeConverter(typeof(TypeConverterSupportProperties))]
	[DCPublishAPI]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public class DocumentBehaviorOptions : ICloneable, IDocumentBehaviorOptions
	{
		internal const string CLASSID = "00012345-6789-ABCD-EF01-234567890068";

		internal const string CLASSID_Interface = "BAC6B1D5-40D2-4CA5-A09C-C11C595C06B7";

		private bool _CompressXMLContent = false;

		private bool _SpeedupByMultiThread = true;

		private string _LocalAutoSaveWorkDirectory = null;

		private bool _NewExpressionExecuteMode = true;

		private bool _AutoFocusWhenOpenDocument = true;

		private bool _LockScrollPositionWhenStrictFormViewMode = false;

		private bool _CheckedValueBindingHandledForTableRow = true;

		private bool _EnableContentChangedEventWhenLoadDocument = false;

		private bool _EnableCollapseSection = false;

		private int _MaxTextLengthForPaste = 0;

		private bool _OutputFieldBorderTextToContentText = true;

		private bool _AutoShowScriptErrorMessage = false;

		private bool _AutoClearTextFormatWhenPasteOrInsertContent = false;

		private bool _AutoDocumentValueValidate = false;

		private int _AutoSaveIntervalInSecond = 0;

		private bool _EnableContentLock = true;

		private int _MinCountForDropdownListSpellCodeArea = 4;

		private bool _AutoFixElementIDWhenInsertElements = true;

		private float _MaxZoomRate = 5f;

		private float _MinZoomRate = 0.2f;

		private bool _RemoveLastParagraphFlagWhenInsertDocument = false;

		private bool _MoveCaretWhenDeleteFail = true;

		private bool _DoubleCompressHtmlWhitespace = false;

		private bool _AllowDeleteJumpOutOfField = true;

		private bool _ContinueHeaderParagrahStyle = false;

		private bool _ActiveCheckInstallWindowsMediaPlayer = false;

		private bool _EnableChineseFontSizeName = true;

		private bool _MaximizedPrintPreviewDialog = false;

		private bool _RaiseQueryListItemsWhenUserEditText = false;

		private AppErrorHandleModeConsts _AppErrorHandleMode = AppErrorHandleModeConsts.ThrowException;

		private string _XMLContentEncodingName = null;

		private bool _AutoAssistInsertString = false;

		private int _AutoAssistInsertStringDetectTextLength = 0;

		private string _AutoTranslateSourceString = null;

		private string _AutoTranslateDescString = null;

		private bool _AutoScrollToCaretWhenGotFocus = false;

		private MoveFocusHotKeys _MoveFocusHotKey = MoveFocusHotKeys.None;

		private bool _EnabledElementEvent = true;

		private bool _ShowTooltip = true;

		private bool _DoubleClickToEditComment = true;

		private WriterDataObjectRange _DataObjectRange = WriterDataObjectRange.OS;

		private bool _CommentEditableWhenReadonly = false;

		private FunctionControlVisibility _CommentVisibility = FunctionControlVisibility.Auto;

		private bool _AllowDragContent = false;

		private WriterDataFormats _AcceptDataFormats = WriterDataFormats.All;

		private WriterDataFormats _CreationDataFormats = WriterDataFormats.All;

		private FormViewMode _FormView = FormViewMode.Disable;

		private bool _PreserveClipbardDataWhenExit = false;

		private bool _FastInputMode = false;

		private bool _CompressLayoutForFieldBorder = true;

		private bool _SmoothScrollView = true;

		private bool _AutoActiveSystemTaskbarBeforeShowDialog = false;

		private bool _EnableCalculateControl = true;

		private bool _EnableEditElementValue = true;

		private string _TitleForToolTip = null;

		/// <summary>
		///       自动首行字母大写
		///       </summary>
		private bool _AutoUppercaseFirstCharInFirstLine = false;

		private bool _AutoRefreshUserTrackInfos = false;

		private DCValidateIDRepeatMode _ValidateIDRepeatMode = DCValidateIDRepeatMode.None;

		private bool _IgnorePrintableAreaOffset = false;

		private bool _PageLineUnderPageBreak = false;

		private bool _ParagraphFlagFollowTableOrSection = false;

		private int _NotificationWorkingTimeout = 2000;

		private bool _HandleCommandException = true;

		private bool _GeneratePageContentVersion = false;

		private bool _DisplayFormatToInnerValue = true;

		private bool _AutoUpdateButtonVisible = false;

		private string _StdLablesForImageEditor = null;

		private bool _EnableCheckControlLoaded = false;

		private bool _EnableDeleteReadonlyEmptyContainer = true;

		private bool _SimpleElementProperties = false;

		private bool _EnableHyperLink = true;

		private int _MinImageFileSizeForConfirmCompressSaveMode = 51200;

		private DCImageCompressSaveMode _ImageCompressSaveMode = DCImageCompressSaveMode.Prompt;

		private bool _FillCommentToUserTrackList = false;

		private bool _PromptJumpBackForSearch = true;

		private bool _EnableSetJumpPrintPositionWhenPreview = true;

		private bool _ExtendingPrintDialog = true;

		private string _ImageShapeEditorBackgroundMenuItemConfig = null;

		private bool _MoveFieldWhenDragWholeContent = true;

		private bool _EnableLogUndo = true;

		private bool _ShowDebugMessage = false;

		private bool _EnableCompressUserHistories = true;

		private bool _EnableElementEvents = true;

		private bool _CloneSerialize = true;

		private bool _WeakMode = false;

		private bool _ForceCollateWhenPrint = false;

		private bool _ThreeClickToSelectParagraph = true;

		private bool _DoubleClickToSelectWord = true;

		private bool _EnableKBEntryRangeMask = true;

		private bool _PromptForExcludeSystemClipboardRange = true;

		private bool _PromptForRejectFormat = true;

		private bool _AutoIgnoreLastEmptyPage = true;

		private bool _ValidateUserIDWhenEditDeleteComment = false;

		private bool _InsertCommentBindingUserTrack = false;

		private bool _PowerfulCommentCommand = true;

		private static bool _AutoCreateInstanceInProperty = false;

		private static bool _GlobalSpecifyDebugMode = false;

		private bool _SpecifyDebugMode = false;

		private bool _EnableDataBinding = true;

		private bool _ForcePopupFormTopMost = false;

		private bool _OutputFormatedXMLSource = true;

		private int _TableCellOperationDetectDistance = 3;

		private bool _WidelyRaiseFocusEvent = false;

		private string _ExcludeKeywords = null;

		private InsertDocumentWithCheckMRIDType _InsertDocumentWithCheckMRID = InsertDocumentWithCheckMRIDType.None;

		private bool _DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject = false;

		private string _CustomWarringCheckMRID = null;

		private string _CustomPromptForbitCheckMRID = null;

		private bool _DesignMode = false;

		private bool _EnableControlHostAtDesignTime = true;

		private bool _DebugMode = false;

		private bool _EnableCopySource = true;

		private bool _EnableExpression = true;

		private bool _Printable = true;

		private bool _OutputBackgroundTextToRTF = true;

		private bool _EnableScript = true;

		private ValueEditorActiveMode _DefaultEditorActiveMode = ValueEditorActiveMode.None;

		private PromptProtectedContentMode _PromptContainUnDeleteContent = PromptProtectedContentMode.Details;

		/// <summary>
		///       是否启用Windows状态栏等待信息。
		///       </summary>
		[DefaultValue(true)]
		public bool EnabledShowWinTaskBarProgress
		{
			get
			{
				return WinTaskBarProgressInfo.Enabled;
			}
			set
			{
				WinTaskBarProgressInfo.Enabled = value;
			}
		}

		/// <summary>
		///       压缩XML内容
		///       </summary>
		[DefaultValue(false)]
		public bool CompressXMLContent
		{
			get
			{
				return _CompressXMLContent;
			}
			set
			{
				_CompressXMLContent = value;
			}
		}

		/// <summary>
		///       使用多线程来提速
		///       </summary>
		[DefaultValue(true)]
		public bool SpeedupByMultiThread
		{
			get
			{
				return _SpeedupByMultiThread;
			}
			set
			{
				_SpeedupByMultiThread = value;
			}
		}

		/// <summary>
		///       本地的自动保存用的工作目录，如果为空则不启用本地自动保存，如果不为空，则该目录会自动创建
		///       </summary>
		[DefaultValue(null)]
		public string LocalAutoSaveWorkDirectory
		{
			get
			{
				return _LocalAutoSaveWorkDirectory;
			}
			set
			{
				_LocalAutoSaveWorkDirectory = value;
			}
		}

		/// <summary>
		///       新的表达式运行模式
		///       </summary>
		[DefaultValue(true)]
		public bool NewExpressionExecuteMode
		{
			get
			{
				return _NewExpressionExecuteMode;
			}
			set
			{
				_NewExpressionExecuteMode = value;
			}
		}

		/// <summary>
		///       在打开文档时编辑器自动获取输入焦点，默认true。
		///       </summary>
		[DefaultValue(true)]
		public bool AutoFocusWhenOpenDocument
		{
			get
			{
				return _AutoFocusWhenOpenDocument;
			}
			set
			{
				_AutoFocusWhenOpenDocument = value;
			}
		}

		/// <summary>
		///       在严格表单视图模式下锁定滚动位置。默认为false，也就是允许滚动视图。
		///       </summary>
		[DefaultValue(false)]
		public bool LockScrollPositionWhenStrictFormViewMode
		{
			get
			{
				return _LockScrollPositionWhenStrictFormViewMode;
			}
			set
			{
				_LockScrollPositionWhenStrictFormViewMode = value;
			}
		}

		/// <summary>
		///       在对表格行绑定数据源的时候检查ValueBinding.Handled值，也就是判断表格行是否已经绑定过了数据源。
		///       如果检查了已经绑定过了数据源则不处理该表格行。
		///       </summary>
		[DefaultValue(true)]
		public bool CheckedValueBindingHandledForTableRow
		{
			get
			{
				return _CheckedValueBindingHandledForTableRow;
			}
			set
			{
				_CheckedValueBindingHandledForTableRow = value;
			}
		}

		/// <summary>
		///       在加载文档时是否允许触发ContentChanged事件。
		///       </summary>
		[HtmlAttribute]
		[MemberExpressionable]
		[XmlElement]
		[DefaultValue(false)]
		public bool EnableContentChangedEventWhenLoadDocument
		{
			get
			{
				return _EnableContentChangedEventWhenLoadDocument;
			}
			set
			{
				_EnableContentChangedEventWhenLoadDocument = value;
			}
		}

		/// <summary>
		///       文档节能否被收缩
		///       </summary>
		[HtmlAttribute]
		[DefaultValue(false)]
		[XmlElement]
		[MemberExpressionable]
		public bool EnableCollapseSection
		{
			get
			{
				return _EnableCollapseSection;
			}
			set
			{
				_EnableCollapseSection = value;
			}
		}

		/// <summary>
		///       粘贴操作中的最大文本长度的限制。若大于0则要粘帖的文本长度超过该值则禁止操作；为负数表示部分粘帖；等于0表示无限制。
		///       </summary>
		[DefaultValue(0)]
		public int MaxTextLengthForPaste
		{
			get
			{
				return _MaxTextLengthForPaste;
			}
			set
			{
				_MaxTextLengthForPaste = value;
			}
		}

		/// <summary>
		///       是否将输入域的边界文本输出到内容文本中
		///       </summary>
		[DefaultValue(true)]
		public bool OutputFieldBorderTextToContentText
		{
			get
			{
				return _OutputFieldBorderTextToContentText;
			}
			set
			{
				_OutputFieldBorderTextToContentText = value;
			}
		}

		/// <summary>
		///       自动显示每个脚本错误信息
		///       </summary>
		[DefaultValue(false)]
		public bool AutoShowScriptErrorMessage
		{
			get
			{
				return _AutoShowScriptErrorMessage;
			}
			set
			{
				_AutoShowScriptErrorMessage = value;
			}
		}

		/// <summary>
		///       在粘贴或插入对象时自动清除文件格式，设置为插入点所在的当前格式。
		///       </summary>
		[DefaultValue(false)]
		public bool AutoClearTextFormatWhenPasteOrInsertContent
		{
			get
			{
				return _AutoClearTextFormatWhenPasteOrInsertContent;
			}
			set
			{
				_AutoClearTextFormatWhenPasteOrInsertContent = value;
			}
		}

		/// <summary>
		///       加载文档时自动进行文档内容校验。
		///       </summary>
		[DefaultValue(false)]
		public bool AutoDocumentValueValidate
		{
			get
			{
				return _AutoDocumentValueValidate;
			}
			set
			{
				_AutoDocumentValueValidate = value;
			}
		}

		/// <summary>
		///       自动保存时间隔的秒数。如果小于等于0则不自动保存。
		///       </summary>
		[DefaultValue(0)]
		public int AutoSaveIntervalInSecond
		{
			get
			{
				return _AutoSaveIntervalInSecond;
			}
			set
			{
				_AutoSaveIntervalInSecond = value;
			}
		}

		/// <summary>
		///       是否启用文档内容锁定机制
		///       </summary>
		[DefaultValue(true)]
		public bool EnableContentLock
		{
			get
			{
				return _EnableContentLock;
			}
			set
			{
				_EnableContentLock = value;
			}
		}

		/// <summary>
		///       显示下拉列表中拼音码区域的最小项目个数
		///       </summary>
		[DefaultValue(4)]
		public int MinCountForDropdownListSpellCodeArea
		{
			get
			{
				return _MinCountForDropdownListSpellCodeArea;
			}
			set
			{
				_MinCountForDropdownListSpellCodeArea = value;
			}
		}

		/// <summary>
		///       插入文档元素时自动修正文档元素编号
		///       </summary>
		[DefaultValue(true)]
		public bool AutoFixElementIDWhenInsertElements
		{
			get
			{
				return _AutoFixElementIDWhenInsertElements;
			}
			set
			{
				_AutoFixElementIDWhenInsertElements = value;
			}
		}

		/// <summary>
		///       最大视图缩放比率。默认为5。
		///       </summary>
		[DefaultValue(5f)]
		public float MaxZoomRate
		{
			get
			{
				return _MaxZoomRate;
			}
			set
			{
				_MaxZoomRate = value;
			}
		}

		/// <summary>
		///       最小视图缩放比率。默认为0.2。
		///       </summary>
		[DefaultValue(0.2f)]
		public float MinZoomRate
		{
			get
			{
				return _MinZoomRate;
			}
			set
			{
				_MinZoomRate = value;
			}
		}

		/// <summary>
		///       在插入文档时删除要插入的文档的最后一个段落符号。默认false。
		///       </summary>
		[DefaultValue(false)]
		public bool RemoveLastParagraphFlagWhenInsertDocument
		{
			get
			{
				return _RemoveLastParagraphFlagWhenInsertDocument;
			}
			set
			{
				_RemoveLastParagraphFlagWhenInsertDocument = value;
			}
		}

		/// <summary>
		///       删除内容失败后仍然移动光标。默认true。
		///       </summary>
		/// <remarks>
		///       若设置本属性值为true，则使用Delete键删除内容失败后光标往后移动一位。
		///       使用Backspace键删除失败后光标往前移动一位。
		///       </remarks>
		[DefaultValue(true)]
		public bool MoveCaretWhenDeleteFail
		{
			get
			{
				return _MoveCaretWhenDeleteFail;
			}
			set
			{
				_MoveCaretWhenDeleteFail = value;
			}
		}

		/// <summary>
		///       输入输出HTML文档时双倍压缩空格字符.DCWriter内部使用。
		///       </summary>
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public bool DoubleCompressHtmlWhitespace
		{
			get
			{
				return _DoubleCompressHtmlWhitespace;
			}
			set
			{
				_DoubleCompressHtmlWhitespace = value;
			}
		}

		/// <summary>
		///       允许跳出输入域来删除内容
		///       </summary>
		[DefaultValue(true)]
		public bool AllowDeleteJumpOutOfField
		{
			get
			{
				return _AllowDeleteJumpOutOfField;
			}
			set
			{
				_AllowDeleteJumpOutOfField = value;
			}
		}

		/// <summary>
		///       敲回车键新建段落时是否延续标题头段落样式，默认为false。
		///       </summary>
		[DefaultValue(false)]
		public bool ContinueHeaderParagrahStyle
		{
			get
			{
				return _ContinueHeaderParagrahStyle;
			}
			set
			{
				_ContinueHeaderParagrahStyle = value;
			}
		}

		/// <summary>
		///       主动检测是否安装了Windows Media Player组件。
		///       </summary>
		[DefaultValue(false)]
		public bool ActiveCheckInstallWindowsMediaPlayer
		{
			get
			{
				return _ActiveCheckInstallWindowsMediaPlayer;
			}
			set
			{
				_ActiveCheckInstallWindowsMediaPlayer = value;
			}
		}

		/// <summary>
		///       是否使用中文字体大小名称
		///       </summary>
		/// <remarks>
		///       如果设置为false，则字体下拉列表中不会出现"三号、小三、四号、小四"之类的中文字体名称。
		///       本属性必须在创建控件对象实例后立即设置，否则无效。
		///       </remarks>
		[DefaultValue(true)]
		public bool EnableChineseFontSizeName
		{
			get
			{
				return _EnableChineseFontSizeName;
			}
			set
			{
				_EnableChineseFontSizeName = value;
			}
		}

		/// <summary>
		///       最大化显示打印预览对话框
		///       </summary>
		[DefaultValue(false)]
		public bool MaximizedPrintPreviewDialog
		{
			get
			{
				return _MaximizedPrintPreviewDialog;
			}
			set
			{
				_MaximizedPrintPreviewDialog = value;
			}
		}

		/// <summary>
		///       用户编辑器文本或者执行数据源绑定时是否触发QueryListItems事件，默认值为false。
		///       </summary>
		/// <remarks>
		///       当启用QueryListItems事件查询下拉列表的列表项目时，当用户直接
		///       编辑输入域的文本值，若本属性值为true，则触发QueryListItems事件
		///       来获得列表项目，根据用户输入的文本值来进行列表内容匹配，获得设置
		///       输入域元素的InnerValue值。
		///       <br />如果本属性值为false，则用户直接编辑输入域的内容或者执行数据源绑定时则不会触发QueryListItems事件。
		///       </remarks>
		[DefaultValue(false)]
		public bool RaiseQueryListItemsWhenUserEditText
		{
			get
			{
				return _RaiseQueryListItemsWhenUserEditText;
			}
			set
			{
				_RaiseQueryListItemsWhenUserEditText = value;
			}
		}

		/// <summary>
		///       应用程序错误处理模式
		///       </summary>
		[DefaultValue(AppErrorHandleModeConsts.ThrowException)]
		public AppErrorHandleModeConsts AppErrorHandleMode
		{
			get
			{
				return _AppErrorHandleMode;
			}
			set
			{
				_AppErrorHandleMode = value;
			}
		}

		/// <summary>
		///       输出的XML内容的编码格式
		///       </summary>
		[DefaultValue(null)]
		public string XMLContentEncodingName
		{
			get
			{
				return _XMLContentEncodingName;
			}
			set
			{
				_XMLContentEncodingName = value;
			}
		}

		/// <summary>
		///       自动启用辅助输入字符串功能
		///       </summary>
		[DefaultValue(false)]
		public bool AutoAssistInsertString
		{
			get
			{
				return _AutoAssistInsertString;
			}
			set
			{
				_AutoAssistInsertString = value;
			}
		}

		/// <summary>
		///       启用自动辅助输入文本时的检测长度
		///       </summary>
		[DefaultValue(0)]
		public int AutoAssistInsertStringDetectTextLength
		{
			get
			{
				return _AutoAssistInsertStringDetectTextLength;
			}
			set
			{
				_AutoAssistInsertStringDetectTextLength = value;
			}
		}

		/// <summary>
		///       自动转换功能中的原始字符组成的字符串
		///       </summary>
		[DefaultValue(null)]
		public string AutoTranslateSourceString
		{
			get
			{
				return _AutoTranslateSourceString;
			}
			set
			{
				_AutoTranslateSourceString = value;
			}
		}

		/// <summary>
		///       自动转换功能中的目标字符组成的字符串
		///       </summary>
		[DefaultValue(null)]
		public string AutoTranslateDescString
		{
			get
			{
				return _AutoTranslateDescString;
			}
			set
			{
				_AutoTranslateDescString = value;
			}
		}

		/// <summary>
		///       当控件获得焦点时自动滚动到光标处
		///       </summary>
		[DefaultValue(false)]
		public bool AutoScrollToCaretWhenGotFocus
		{
			get
			{
				return _AutoScrollToCaretWhenGotFocus;
			}
			set
			{
				_AutoScrollToCaretWhenGotFocus = value;
			}
		}

		/// <summary>
		///       移动焦点使用的快捷键。该属性在WinForm版和WEB版中有效。
		///       </summary>
		[DefaultValue(MoveFocusHotKeys.None)]
		[Description("移动输入焦点使用的快捷键模式")]
		[Category("Behavior")]
		public MoveFocusHotKeys MoveFocusHotKey
		{
			get
			{
				return _MoveFocusHotKey;
			}
			set
			{
				_MoveFocusHotKey = value;
			}
		}

		/// <summary>
		///       是否允许触发文档元素级事件
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool EnabledElementEvent
		{
			get
			{
				return _EnabledElementEvent;
			}
			set
			{
				_EnabledElementEvent = value;
			}
		}

		/// <summary>
		///       是否显示提示文本
		///       </summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[ComVisible(true)]
		public bool ShowTooltip
		{
			get
			{
				return _ShowTooltip;
			}
			set
			{
				_ShowTooltip = value;
			}
		}

		/// <summary>
		///       鼠标双击来编辑文档批注
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("鼠标双击来编辑文档批注")]
		public bool DoubleClickToEditComment
		{
			get
			{
				return _DoubleClickToEditComment;
			}
			set
			{
				_DoubleClickToEditComment = value;
			}
		}

		/// <summary>
		///       数据对象应用范围
		///       </summary>
		/// <remarks>
		/// </remarks>
		[DefaultValue(WriterDataObjectRange.OS)]
		[Category("Behavior")]
		public WriterDataObjectRange DataObjectRange
		{
			get
			{
				return _DataObjectRange;
			}
			set
			{
				_DataObjectRange = value;
			}
		}

		/// <summary>
		///       即使在只读状态下是否能编辑文档批注
		///       </summary>
		[DefaultValue(false)]
		public bool CommentEditableWhenReadonly
		{
			get
			{
				return _CommentEditableWhenReadonly;
			}
			set
			{
				_CommentEditableWhenReadonly = value;
			}
		}

		/// <summary>
		///       是否显示文档批注
		///       </summary>
		[Category("Appearance")]
		[DefaultValue(FunctionControlVisibility.Auto)]
		public FunctionControlVisibility CommentVisibility
		{
			get
			{
				return _CommentVisibility;
			}
			set
			{
				_CommentVisibility = value;
			}
		}

		/// <summary>
		///       能否直接拖拽文档内容
		///       </summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool AllowDragContent
		{
			get
			{
				return _AllowDragContent;
			}
			set
			{
				_AllowDragContent = value;
			}
		}

		/// <summary>
		///       编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据
		///       </summary>
		[DefaultValue(WriterDataFormats.All)]
		[Category("Behavior")]
		[Description("编辑器控件能接受的数据格式，包括粘贴操作和OLE拖拽操作获得的数据")]
		public WriterDataFormats AcceptDataFormats
		{
			get
			{
				return _AcceptDataFormats;
			}
			set
			{
				_AcceptDataFormats = value;
			}
		}

		/// <summary>
		///       编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作
		///       </summary>
		[Description("编辑器控件能创建的数据格式，这些数据将用于复制操作和OLE拖拽操作")]
		[Category("Behavior")]
		[DefaultValue(WriterDataFormats.All)]
		public WriterDataFormats CreationDataFormats
		{
			get
			{
				return _CreationDataFormats;
			}
			set
			{
				_CreationDataFormats = value;
			}
		}

		/// <summary>
		///       表单视图模式
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(FormViewMode.Disable)]
		public FormViewMode FormView
		{
			get
			{
				return _FormView;
			}
			set
			{
				if (_FormView != value)
				{
					_FormView = value;
				}
			}
		}

		/// <summary>
		///       退出应用程序后保留系统剪切板中的数据
		///       </summary>
		[DefaultValue(false)]
		public bool PreserveClipbardDataWhenExit
		{
			get
			{
				return _PreserveClipbardDataWhenExit;
			}
			set
			{
				_PreserveClipbardDataWhenExit = value;
			}
		}

		/// <summary>
		///       快速录入模式
		///       </summary>
		[DefaultValue(false)]
		public bool FastInputMode
		{
			get
			{
				return _FastInputMode;
			}
			set
			{
				_FastInputMode = value;
			}
		}

		/// <summary>
		///       对于输入域边框元素采用紧凑排版
		///       </summary>
		[DefaultValue(true)]
		public bool CompressLayoutForFieldBorder
		{
			get
			{
				return _CompressLayoutForFieldBorder;
			}
			set
			{
				_CompressLayoutForFieldBorder = value;
			}
		}

		/// <summary>
		///       是否启用平滑滚动效果
		///       </summary>
		[DefaultValue(true)]
		public bool SmoothScrollView
		{
			get
			{
				return _SmoothScrollView;
			}
			set
			{
				_SmoothScrollView = value;
			}
		}

		/// <summary>
		///       在显示对话框前自动激活系统任务条
		///       </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		[Browsable(false)]
		public bool AutoActiveSystemTaskbarBeforeShowDialog
		{
			get
			{
				return _AutoActiveSystemTaskbarBeforeShowDialog;
			}
			set
			{
				_AutoActiveSystemTaskbarBeforeShowDialog = value;
			}
		}

		/// <summary>
		///       是否允许使用计算器控件
		///       </summary>
		[ComVisible(true)]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool EnableCalculateControl
		{
			get
			{
				return _EnableCalculateControl;
			}
			set
			{
				_EnableCalculateControl = value;
			}
		}

		/// <summary>
		///       是否允许编辑文档元素内容值操作
		///       </summary>
		[DefaultValue(true)]
		[Browsable(false)]
		[Category("Behavior")]
		[ComVisible(true)]
		public bool EnableEditElementValue
		{
			get
			{
				return _EnableEditElementValue;
			}
			set
			{
				_EnableEditElementValue = value;
			}
		}

		/// <summary>
		///       提示信息的标题文本
		///       </summary>
		[DefaultValue(null)]
		public string TitleForToolTip
		{
			get
			{
				return _TitleForToolTip;
			}
			set
			{
				_TitleForToolTip = value;
			}
		}

		/// <summary>
		///       自动首行字母大写
		///       </summary>
		[DefaultValue(false)]
		public bool AutoUppercaseFirstCharInFirstLine
		{
			get
			{
				return _AutoUppercaseFirstCharInFirstLine;
			}
			set
			{
				_AutoUppercaseFirstCharInFirstLine = value;
			}
		}

		/// <summary>
		///       自动刷新用户痕迹信息列表
		///       </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool AutoRefreshUserTrackInfos
		{
			get
			{
				return _AutoRefreshUserTrackInfos;
			}
			set
			{
				_AutoRefreshUserTrackInfos = value;
			}
		}

		/// <summary>
		///       ID重复性校验模式
		///       </summary>
		[DefaultValue(DCValidateIDRepeatMode.None)]
		public DCValidateIDRepeatMode ValidateIDRepeatMode
		{
			get
			{
				return _ValidateIDRepeatMode;
			}
			set
			{
				_ValidateIDRepeatMode = value;
			}
		}

		/// <summary>
		///       打印时忽略掉可打印区域偏移量
		///       </summary>
		[DefaultValue(false)]
		public bool IgnorePrintableAreaOffset
		{
			get
			{
				return _IgnorePrintableAreaOffset;
			}
			set
			{
				_IgnorePrintableAreaOffset = value;
			}
		}

		/// <summary>
		///       分页线在分页符的下面,如果为true，则分页线在分页符的上面,也就是分页符在上一页的最下面。本属性默认为false。
		///       </summary>
		[DefaultValue(false)]
		public bool PageLineUnderPageBreak
		{
			get
			{
				return _PageLineUnderPageBreak;
			}
			set
			{
				_PageLineUnderPageBreak = value;
			}
		}

		/// <summary>
		///       排版时段落符号紧跟在表格或文档节后面
		///       </summary>
		[DefaultValue(false)]
		public bool ParagraphFlagFollowTableOrSection
		{
			get
			{
				return _ParagraphFlagFollowTableOrSection;
			}
			set
			{
				_ParagraphFlagFollowTableOrSection = value;
			}
		}

		/// <summary>
		///       通知系统忙状态的超时时间，单位毫秒
		///       </summary>
		[DefaultValue(2000)]
		public int NotificationWorkingTimeout
		{
			get
			{
				return _NotificationWorkingTimeout;
			}
			set
			{
				_NotificationWorkingTimeout = value;
			}
		}

		/// <summary>
		///       是否处理编辑器命令过程的异常
		///       </summary>
		[DefaultValue(true)]
		public bool HandleCommandException
		{
			get
			{
				return _HandleCommandException;
			}
			set
			{
				_HandleCommandException = value;
			}
		}

		/// <summary>
		///       生成页面内容版本号
		///       </summary>
		/// <remarks>
		///       生成页面内容版本号是个比较耗时的操作，非必要不要启用改选项。
		///       </remarks>
		[DefaultValue(false)]
		public bool GeneratePageContentVersion
		{
			get
			{
				return _GeneratePageContentVersion;
			}
			set
			{
				_GeneratePageContentVersion = value;
			}
		}

		/// <summary>
		///       是否对输入域的InnerValue启用DisplayFormat设置
		///       </summary>
		[DefaultValue(true)]
		public bool DisplayFormatToInnerValue
		{
			get
			{
				return _DisplayFormatToInnerValue;
			}
			set
			{
				_DisplayFormatToInnerValue = value;
			}
		}

		/// <summary>
		///       自动更新绑定了命令的按钮等UI元素的可见性
		///       </summary>
		[DefaultValue(false)]
		public bool AutoUpdateButtonVisible
		{
			get
			{
				return _AutoUpdateButtonVisible;
			}
			set
			{
				_AutoUpdateButtonVisible = value;
			}
		}

		/// <summary>
		///       图片编辑器中使用的标准文本标签列表，各个项目中间用半角逗号分开。
		///       </summary>
		/// <remarks>
		///       比如"左眼,右眼,左手,右手,可以切,必须切,袁永福到此一游"。
		///       </remarks>
		[DefaultValue(null)]
		public string StdLablesForImageEditor
		{
			get
			{
				return _StdLablesForImageEditor;
			}
			set
			{
				_StdLablesForImageEditor = value;
			}
		}

		/// <summary>
		///       执行编辑器命令前是否检查控件已经加载
		///       </summary>
		[DefaultValue(false)]
		public bool EnableCheckControlLoaded
		{
			get
			{
				return _EnableCheckControlLoaded;
			}
			set
			{
				_EnableCheckControlLoaded = value;
			}
		}

		/// <summary>
		///       能否删除内容空白而且只读的容器元素
		///       </summary>
		[DefaultValue(true)]
		public bool EnableDeleteReadonlyEmptyContainer
		{
			get
			{
				return _EnableDeleteReadonlyEmptyContainer;
			}
			set
			{
				_EnableDeleteReadonlyEmptyContainer = value;
			}
		}

		/// <summary>
		///       简洁的编辑元素属性
		///       </summary>
		[DefaultValue(false)]
		public bool SimpleElementProperties
		{
			get
			{
				return _SimpleElementProperties;
			}
			set
			{
				_SimpleElementProperties = value;
			}
		}

		/// <summary>
		///       允许使用超链接
		///       </summary>
		[DefaultValue(true)]
		public bool EnableHyperLink
		{
			get
			{
				return _EnableHyperLink;
			}
			set
			{
				_EnableHyperLink = value;
			}
		}

		/// <summary>
		///       提示压缩存储图片数据的图片文件最小大小，如果为0表示不进行判断，不压缩存储图片数据。
		///       </summary>
		[DefaultValue(51200)]
		public int MinImageFileSizeForConfirmCompressSaveMode
		{
			get
			{
				return _MinImageFileSizeForConfirmCompressSaveMode;
			}
			set
			{
				_MinImageFileSizeForConfirmCompressSaveMode = value;
			}
		}

		/// <summary>
		///       插入的图片的压缩存储模式
		///       </summary>
		[DefaultValue(DCImageCompressSaveMode.Prompt)]
		public DCImageCompressSaveMode ImageCompressSaveMode
		{
			get
			{
				return _ImageCompressSaveMode;
			}
			set
			{
				_ImageCompressSaveMode = value;
			}
		}

		/// <summary>
		///       将文档批注添加到用户痕迹列表中
		///       </summary>
		/// <remarks>
		///       本选项默认为false，如果为true，则文档中的批注将作为痕迹信息显示的用户痕迹列表中。也就是
		///       编辑器控件WriterControl.UserTrackInfos列表中。
		///       </remarks>
		[DefaultValue(false)]
		public bool FillCommentToUserTrackList
		{
			get
			{
				return _FillCommentToUserTrackList;
			}
			set
			{
				_FillCommentToUserTrackList = value;
			}
		}

		/// <summary>
		///       是否提示跳回去继续搜索文本
		///       </summary>
		[DefaultValue(true)]
		public bool PromptJumpBackForSearch
		{
			get
			{
				return _PromptJumpBackForSearch;
			}
			set
			{
				_PromptJumpBackForSearch = value;
			}
		}

		/// <summary>
		///       允许在打印预览的时候设置续打位置
		///       </summary>
		[DefaultValue(true)]
		public bool EnableSetJumpPrintPositionWhenPreview
		{
			get
			{
				return _EnableSetJumpPrintPositionWhenPreview;
			}
			set
			{
				_EnableSetJumpPrintPositionWhenPreview = value;
			}
		}

		/// <summary>
		///       是否扩展打印机设置对话框
		///       </summary>
		[DefaultValue(true)]
		public bool ExtendingPrintDialog
		{
			get
			{
				return _ExtendingPrintDialog;
			}
			set
			{
				_ExtendingPrintDialog = value;
			}
		}

		/// <summary>
		///       图片编辑器的背景菜单项目配置
		///       </summary>
		/// <remarks>
		///       默认的配置为“空白=Disabled;触觉减退=BackImage1;触觉消失=BackImage2;触觉过敏或异常=BackImage3;痛觉减退=BackImage4;痛觉消失=BackImage5;痛觉过敏或异常=BackImage6;震动觉减退或异常=BackImage7;位置觉减退或消失=BackImage8;浅感觉全部消失=BackImage9;深浅感觉全部消失=BackImage10;I度=BackImage11;II度=BackImage12;深II度=BackImage13;III三度=Black;vvv=GradientForwardDiagonal”。
		///       </remarks>
		[DefaultValue(null)]
		[Editor(typeof(GClass301), typeof(UITypeEditor))]
		public string ImageShapeEditorBackgroundMenuItemConfig
		{
			get
			{
				return _ImageShapeEditorBackgroundMenuItemConfig;
			}
			set
			{
				_ImageShapeEditorBackgroundMenuItemConfig = value;
			}
		}

		/// <summary>
		///       拖拽所有内容时移动整个输入域
		///       </summary>
		[DefaultValue(true)]
		public bool MoveFieldWhenDragWholeContent
		{
			get
			{
				return _MoveFieldWhenDragWholeContent;
			}
			set
			{
				_MoveFieldWhenDragWholeContent = value;
			}
		}

		/// <summary>
		///       是否记录撤销操作信息
		///       </summary>
		/// <remarks>
		///       如果为false，则系统不记录文档操作的信息，用户操作就不能撤销或重做。
		///       </remarks>
		[DefaultValue(true)]
		public bool EnableLogUndo
		{
			get
			{
				return _EnableLogUndo;
			}
			set
			{
				_EnableLogUndo = value;
			}
		}

		/// <summary>
		///       显示内部调试消息
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "ShowDebugMessage")]
		[DefaultValue(false)]
		public bool ShowDebugMessage
		{
			get
			{
				return _ShowDebugMessage;
			}
			set
			{
				_ShowDebugMessage = value;
			}
		}

		/// <summary>
		///       是否启用压缩用户历史修改记录
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableCompressUserHistories")]
		public bool EnableCompressUserHistories
		{
			get
			{
				return _EnableCompressUserHistories;
			}
			set
			{
				_EnableCompressUserHistories = value;
			}
		}

		/// <summary>
		///       是否启用文档元素事件
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableElementEvents")]
		[DefaultValue(true)]
		public bool EnableElementEvents
		{
			get
			{
				return _EnableElementEvents;
			}
			set
			{
				_EnableElementEvents = value;
			}
		}

		/// <summary>
		///       复制序列化模式
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "CloneSerialize")]
		[DefaultValue(true)]
		public bool CloneSerialize
		{
			get
			{
				return _CloneSerialize;
			}
			set
			{
				_CloneSerialize = value;
			}
		}

		/// <summary>
		///       脆弱模式，默认为false。
		///       </summary>
		/// <remarks>
		///       当处于脆弱模式时，DCWriter中很多系统异常不经处理而直接抛出，这有利于暴露出错误的根源。但会造成系统不稳定。
		///       </remarks>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentBehaviorOptions), "WeakMode")]
		public bool WeakMode
		{
			get
			{
				return _WeakMode;
			}
			set
			{
				_WeakMode = value;
			}
		}

		/// <summary>
		///       打印的时候强制自动分页，默认为false。
		///       </summary>
		/// <remarks>
		///       .NET框架的一个BUG，导致有时打印多份的时候无法自动分页，此处强制设置自动分页。
		///       而不管在打印机设置中是否使用自动分页。这是在没有修正系统BUG时的临时扑救措施。
		///       该系统BUG说明可见http://support.microsoft.com/kb/2744968。不建议设置该属性。
		///       </remarks>
		[DCDescription(typeof(DocumentBehaviorOptions), "ForceCollateWhenPrint")]
		[DefaultValue(false)]
		public bool ForceCollateWhenPrint
		{
			get
			{
				return _ForceCollateWhenPrint;
			}
			set
			{
				_ForceCollateWhenPrint = value;
			}
		}

		/// <summary>
		///       鼠标连续三击选中段落，默认为true.
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "ThreeClickToSelectParagraph")]
		public bool ThreeClickToSelectParagraph
		{
			get
			{
				return _ThreeClickToSelectParagraph;
			}
			set
			{
				_ThreeClickToSelectParagraph = value;
			}
		}

		/// <summary>
		///       双击选中文字,默认为true.
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "DoubleClickToSelectWord")]
		public bool DoubleClickToSelectWord
		{
			get
			{
				return _DoubleClickToSelectWord;
			}
			set
			{
				_DoubleClickToSelectWord = value;
			}
		}

		/// <summary>
		///       启用知识库节点范围掩码,默认true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableKBEntryRangeMask")]
		public bool EnableKBEntryRangeMask
		{
			get
			{
				return _EnableKBEntryRangeMask;
			}
			set
			{
				_EnableKBEntryRangeMask = value;
			}
		}

		/// <summary>
		///       遇到未包含系统剪切板时进行提示
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "PromptForExcludeSystemClipboardRange")]
		[DefaultValue(true)]
		public bool PromptForExcludeSystemClipboardRange
		{
			get
			{
				return _PromptForExcludeSystemClipboardRange;
			}
			set
			{
				_PromptForExcludeSystemClipboardRange = value;
			}
		}

		/// <summary>
		///       遇到拒绝的数据格式进行提示
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "PromptForRejectFormat")]
		public bool PromptForRejectFormat
		{
			get
			{
				return _PromptForRejectFormat;
			}
			set
			{
				_PromptForRejectFormat = value;
			}
		}

		/// <summary>
		///       打印和打印预览时自动忽略掉最后一个空白页
		///       </summary>
		/// <remarks>
		///       在少数情况下，最后一页只有一个段落符号，可以认为最后一页就没有任何实际内容。
		///       本选项来让编辑器打印的时候自动忽略掉最后一页。
		///       </remarks>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "AutoIgnoreLastEmptyPage")]
		public bool AutoIgnoreLastEmptyPage
		{
			get
			{
				return _AutoIgnoreLastEmptyPage;
			}
			set
			{
				_AutoIgnoreLastEmptyPage = value;
			}
		}

		/// <summary>
		///       在编辑和删除文档批注时是否检查当前用户ID是否等于批注的创建者ID
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentBehaviorOptions), "ValidateUserIDWhenEditDeleteComment")]
		public bool ValidateUserIDWhenEditDeleteComment
		{
			get
			{
				return _ValidateUserIDWhenEditDeleteComment;
			}
			set
			{
				_ValidateUserIDWhenEditDeleteComment = value;
			}
		}

		/// <summary>
		///       插入文档批注时是否设置用户痕迹，默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "InsertCommentBindingUserTrack")]
		[DefaultValue(false)]
		public bool InsertCommentBindingUserTrack
		{
			get
			{
				return _InsertCommentBindingUserTrack;
			}
			set
			{
				_InsertCommentBindingUserTrack = value;
			}
		}

		/// <summary>
		///       批注编辑操作是否是强大的。如果是强大的则不受授权控制及内容保护的限制。默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "PowerfulCommentCommand")]
		public bool PowerfulCommentCommand
		{
			get
			{
				return _PowerfulCommentCommand;
			}
			set
			{
				_PowerfulCommentCommand = value;
			}
		}

		/// <summary>
		///       静态的设置在属性中自动创建变量对象实例
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "StaticAutoCreateInstanceInProperty")]
		public static bool StaticAutoCreateInstanceInProperty
		{
			get
			{
				return _AutoCreateInstanceInProperty;
			}
			set
			{
				_AutoCreateInstanceInProperty = value;
			}
		}

		/// <summary>
		///       在属性中自动创建变量对象实例，默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "AutoCreateInstanceInProperty")]
		[DefaultValue(false)]
		public bool AutoCreateInstanceInProperty
		{
			get
			{
				return _AutoCreateInstanceInProperty;
			}
			set
			{
				_AutoCreateInstanceInProperty = value;
			}
		}

		/// <summary>
		///       全局性的特别调试模式，内部使用，默认为false。
		///       </summary>
		public static bool GlobalSpecifyDebugMode
		{
			get
			{
				return _GlobalSpecifyDebugMode;
			}
			set
			{
				_GlobalSpecifyDebugMode = value;
			}
		}

		/// <summary>
		///       全局性的特别调试模式值，内部使用，默认为false。
		///       </summary>
		[DefaultValue(false)]
		public bool GlobalSpecifyDebugModeValue
		{
			get
			{
				return _GlobalSpecifyDebugMode;
			}
			set
			{
				_GlobalSpecifyDebugMode = value;
			}
		}

		/// <summary>
		///       特别的调试模式，内部使用，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentBehaviorOptions), "SpecifyDebugMode")]
		public bool SpecifyDebugMode
		{
			get
			{
				return _SpecifyDebugMode;
			}
			set
			{
				_SpecifyDebugMode = value;
			}
		}

		/// <summary>
		///       是否启用数据源绑定，如果为false，则编辑器不执行数据源绑定。默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableDataBinding")]
		public bool EnableDataBinding
		{
			get
			{
				return _EnableDataBinding;
			}
			set
			{
				_EnableDataBinding = value;
			}
		}

		/// <summary>
		///       强制弹出式数据输入框为TopMost模式，默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentBehaviorOptions), "ForcePopupFormTopMost")]
		public bool ForcePopupFormTopMost
		{
			get
			{
				return _ForcePopupFormTopMost;
			}
			set
			{
				_ForcePopupFormTopMost = value;
			}
		}

		/// <summary>
		///       是否输出格式化的XML文本，默认为true。
		///       </summary>
		/// <remarks>格式化的XML文本带有缩进控制，阅读方便，但文档比较大。</remarks>
		[DCDescription(typeof(DocumentBehaviorOptions), "OutputFormatedXMLSource")]
		[DefaultValue(true)]
		public bool OutputFormatedXMLSource
		{
			get
			{
				return _OutputFormatedXMLSource;
			}
			set
			{
				_OutputFormatedXMLSource = value;
			}
		}

		/// <summary>
		///       表格单元格操作检测时使用的距离长度，单位为屏幕像素，默认为3。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "TableCellOperationDetectDistance")]
		[DefaultValue(3)]
		public int TableCellOperationDetectDistance
		{
			get
			{
				return _TableCellOperationDetectDistance;
			}
			set
			{
				_TableCellOperationDetectDistance = value;
			}
		}

		/// <summary>
		///       宽范围的触发焦点事件,都昌内部使用。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "WidelyRaiseFocusEvent")]
		[DefaultValue(false)]
		public bool WidelyRaiseFocusEvent
		{
			get
			{
				return _WidelyRaiseFocusEvent;
			}
			set
			{
				_WidelyRaiseFocusEvent = value;
			}
		}

		/// <summary>
		///       全文违禁关键字列表，可包含多个违禁关键字，各个关键字之间用半角逗号分开。
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentBehaviorOptions), "ExcludeKeywords")]
		public string ExcludeKeywords
		{
			get
			{
				return _ExcludeKeywords;
			}
			set
			{
				_ExcludeKeywords = value;
			}
		}

		/// <summary>
		///       插入文档内容时MRID值的检测模式。默认为None。
		///       </summary>
		[DefaultValue(InsertDocumentWithCheckMRIDType.None)]
		[DCDescription(typeof(DocumentBehaviorOptions), "InsertDocumentWithCheckMRID")]
		public InsertDocumentWithCheckMRIDType InsertDocumentWithCheckMRID
		{
			get
			{
				return _InsertDocumentWithCheckMRID;
			}
			set
			{
				_InsertDocumentWithCheckMRID = value;
			}
		}

		/// <summary>
		///       在获得外部数据源时如果MRID为空则不检查MRID设置。默认为false。
		///       </summary>
		[DefaultValue(false)]
		public bool DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject
		{
			get
			{
				return _DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject;
			}
			set
			{
				_DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject = value;
			}
		}

		/// <summary>
		///       自定义的检查病历编号不通过的警告提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，不建议执行本次操作，是否继续？”。
		///       </summary>
		[DefaultValue(null)]
		[DCDescription(typeof(DocumentBehaviorOptions), "CustomWarringCheckMRID")]
		public string CustomWarringCheckMRID
		{
			get
			{
				return _CustomWarringCheckMRID;
			}
			set
			{
				_CustomWarringCheckMRID = value;
			}
		}

		/// <summary>
		///       自定义的检查病历编号不通过的禁止提示信息，可以设置为“警告：当前文档关联的编号为“{0}”，而要粘贴的内容关联的编号为“{1}”，根据规范，禁止执行本次操作。”
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "CustomPromptForbitCheckMRID")]
		public string CustomPromptForbitCheckMRID
		{
			get
			{
				return _CustomPromptForbitCheckMRID;
			}
			set
			{
				_CustomPromptForbitCheckMRID = value;
			}
		}

		/// <summary>
		///       编辑器是否处于设计模式。默认为false。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "DesignMode")]
		[DefaultValue(false)]
		public bool DesignMode
		{
			get
			{
				return _DesignMode;
			}
			set
			{
				_DesignMode = value;
			}
		}

		/// <summary>
		///       编辑器在设计模式下仍然允许承载控件，默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableControlHostAtDesignTime")]
		public bool EnableControlHostAtDesignTime
		{
			get
			{
				return _EnableControlHostAtDesignTime;
			}
			set
			{
				_EnableControlHostAtDesignTime = value;
			}
		}

		/// <summary>
		///       系统是否处于调试模式。若为true，则系统处于调试模式，系统会输出一些调试文本信息。默认为false。
		///       </summary>
		[DefaultValue(false)]
		[DCDescription(typeof(DocumentBehaviorOptions), "DebugMode")]
		public bool DebugMode
		{
			get
			{
				return _DebugMode;
			}
			set
			{
				_DebugMode = value;
			}
		}

		/// <summary>
		///       允许执行内容复制,默认true。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableCopySource")]
		[DefaultValue(true)]
		public bool EnableCopySource
		{
			get
			{
				return _EnableCopySource;
			}
			set
			{
				_EnableCopySource = value;
			}
		}

		/// <summary>
		///       是否允许表达式。如果为false，则系统不执行表达式，级联模板功能也无法运行。默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableExpression")]
		[DefaultValue(true)]
		public bool EnableExpression
		{
			get
			{
				return _EnableExpression;
			}
			set
			{
				_EnableExpression = value;
			}
		}

		/// <summary>
		///       文档能否打印。若为false则文档不能打印。默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "Printable")]
		[DefaultValue(true)]
		public bool Printable
		{
			get
			{
				return _Printable;
			}
			set
			{
				_Printable = value;
			}
		}

		/// <summary>
		///       在导出RTF文档时是否导出文本输入域的背景文本。默认为true。
		///       </summary>
		[DCDescription(typeof(DocumentBehaviorOptions), "OutputBackgroundTextToRTF")]
		[DefaultValue(true)]
		public bool OutputBackgroundTextToRTF
		{
			get
			{
				return _OutputBackgroundTextToRTF;
			}
			set
			{
				_OutputBackgroundTextToRTF = value;
			}
		}

		/// <summary>
		///       允许VBA宏脚本。默认为true。
		///       </summary>
		[DefaultValue(true)]
		[DCDescription(typeof(DocumentBehaviorOptions), "EnableScript")]
		public bool EnableScript
		{
			get
			{
				return _EnableScript;
			}
			set
			{
				_EnableScript = value;
			}
		}

		/// <summary>
		///       默认的数值编辑器激活模式，默认为None。
		///       </summary>
		[DefaultValue(ValueEditorActiveMode.None)]
		[DCDescription(typeof(DocumentBehaviorOptions), "DefaultEditorActiveMode")]
		public ValueEditorActiveMode DefaultEditorActiveMode
		{
			get
			{
				return _DefaultEditorActiveMode;
			}
			set
			{
				_DefaultEditorActiveMode = value;
			}
		}

		/// <summary>
		///       当视图删除无法删除的内容时的提示方式，默认为Details。
		///       </summary>
		[DefaultValue(PromptProtectedContentMode.Details)]
		[DCDescription(typeof(DocumentBehaviorOptions), "PromptProtectedContent")]
		public PromptProtectedContentMode PromptProtectedContent
		{
			get
			{
				return _PromptContainUnDeleteContent;
			}
			set
			{
				_PromptContainUnDeleteContent = value;
			}
		}

		object ICloneable.Clone()
		{
			return (DocumentBehaviorOptions)MemberwiseClone();
		}

		/// <summary>
		///       复制对象
		///       </summary>
		/// <returns>复制品</returns>
		public DocumentBehaviorOptions Clone()
		{
			return (DocumentBehaviorOptions)((ICloneable)this).Clone();
		}
	}
}
