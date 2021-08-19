using DCSoft.Writer.Controls;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>DocumentBehaviorOptions 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("BAC6B1D5-40D2-4CA5-A09C-C11C595C06B7")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IDocumentBehaviorOptions
	{
		/// <summary>属性AcceptDataFormats</summary>
		[DispId(72)]
		WriterDataFormats AcceptDataFormats
		{
			get;
			set;
		}

		/// <summary>属性ActiveCheckInstallWindowsMediaPlayer</summary>
		[DispId(93)]
		bool ActiveCheckInstallWindowsMediaPlayer
		{
			get;
			set;
		}

		/// <summary>属性AllowDeleteJumpOutOfField</summary>
		[DispId(95)]
		bool AllowDeleteJumpOutOfField
		{
			get;
			set;
		}

		/// <summary>属性AllowDragContent</summary>
		[DispId(73)]
		bool AllowDragContent
		{
			get;
			set;
		}

		/// <summary>属性AppErrorHandleMode</summary>
		[DispId(90)]
		AppErrorHandleModeConsts AppErrorHandleMode
		{
			get;
			set;
		}

		/// <summary>属性AutoActiveSystemTaskbarBeforeShowDialog</summary>
		[DispId(68)]
		bool AutoActiveSystemTaskbarBeforeShowDialog
		{
			get;
			set;
		}

		/// <summary>属性AutoAssistInsertString</summary>
		[DispId(74)]
		bool AutoAssistInsertString
		{
			get;
			set;
		}

		/// <summary>属性AutoAssistInsertStringDetectTextLength</summary>
		[DispId(88)]
		int AutoAssistInsertStringDetectTextLength
		{
			get;
			set;
		}

		/// <summary>属性AutoClearTextFormatWhenPasteOrInsertContent</summary>
		[DispId(106)]
		bool AutoClearTextFormatWhenPasteOrInsertContent
		{
			get;
			set;
		}

		/// <summary>属性AutoCreateInstanceInProperty</summary>
		[DispId(22)]
		bool AutoCreateInstanceInProperty
		{
			get;
			set;
		}

		/// <summary>属性AutoDocumentValueValidate</summary>
		[DispId(107)]
		bool AutoDocumentValueValidate
		{
			get;
			set;
		}

		/// <summary>属性AutoFixElementIDWhenInsertElements</summary>
		[DispId(102)]
		bool AutoFixElementIDWhenInsertElements
		{
			get;
			set;
		}

		/// <summary>属性AutoFocusWhenOpenDocument</summary>
		[DispId(115)]
		bool AutoFocusWhenOpenDocument
		{
			get;
			set;
		}

		/// <summary>属性AutoIgnoreLastEmptyPage</summary>
		[DispId(25)]
		bool AutoIgnoreLastEmptyPage
		{
			get;
			set;
		}

		/// <summary>属性AutoRefreshUserTrackInfos</summary>
		[DispId(63)]
		bool AutoRefreshUserTrackInfos
		{
			get;
			set;
		}

		/// <summary>属性AutoSaveIntervalInSecond</summary>
		[DispId(105)]
		int AutoSaveIntervalInSecond
		{
			get;
			set;
		}

		/// <summary>属性AutoScrollToCaretWhenGotFocus</summary>
		[DispId(75)]
		bool AutoScrollToCaretWhenGotFocus
		{
			get;
			set;
		}

		/// <summary>属性AutoShowScriptErrorMessage</summary>
		[DispId(109)]
		bool AutoShowScriptErrorMessage
		{
			get;
			set;
		}

		/// <summary>属性AutoTranslateDescString</summary>
		[DispId(76)]
		string AutoTranslateDescString
		{
			get;
			set;
		}

		/// <summary>属性AutoTranslateSourceString</summary>
		[DispId(77)]
		string AutoTranslateSourceString
		{
			get;
			set;
		}

		/// <summary>属性AutoUpdateButtonVisible</summary>
		[DispId(51)]
		bool AutoUpdateButtonVisible
		{
			get;
			set;
		}

		/// <summary>属性AutoUppercaseFirstCharInFirstLine</summary>
		[DispId(64)]
		bool AutoUppercaseFirstCharInFirstLine
		{
			get;
			set;
		}

		/// <summary>属性CheckedValueBindingHandledForTableRow</summary>
		[DispId(114)]
		bool CheckedValueBindingHandledForTableRow
		{
			get;
			set;
		}

		/// <summary>属性CloneSerialize</summary>
		[DispId(34)]
		bool CloneSerialize
		{
			get;
			set;
		}

		/// <summary>属性CommentEditableWhenReadonly</summary>
		[DispId(78)]
		bool CommentEditableWhenReadonly
		{
			get;
			set;
		}

		/// <summary>属性CommentVisibility</summary>
		[DispId(79)]
		FunctionControlVisibility CommentVisibility
		{
			get;
			set;
		}

		/// <summary>属性CompressLayoutForFieldBorder</summary>
		[DispId(69)]
		bool CompressLayoutForFieldBorder
		{
			get;
			set;
		}

		/// <summary>属性CompressXMLContent</summary>
		[DispId(119)]
		bool CompressXMLContent
		{
			get;
			set;
		}

		/// <summary>属性ContinueHeaderParagrahStyle</summary>
		[DispId(96)]
		bool ContinueHeaderParagrahStyle
		{
			get;
			set;
		}

		/// <summary>属性CreationDataFormats</summary>
		[DispId(80)]
		WriterDataFormats CreationDataFormats
		{
			get;
			set;
		}

		/// <summary>属性CustomPromptForbitCheckMRID</summary>
		[DispId(2)]
		string CustomPromptForbitCheckMRID
		{
			get;
			set;
		}

		/// <summary>属性CustomWarringCheckMRID</summary>
		[DispId(3)]
		string CustomWarringCheckMRID
		{
			get;
			set;
		}

		/// <summary>属性DataObjectRange</summary>
		[DispId(81)]
		WriterDataObjectRange DataObjectRange
		{
			get;
			set;
		}

		/// <summary>属性DebugMode</summary>
		[DispId(4)]
		bool DebugMode
		{
			get;
			set;
		}

		/// <summary>属性DefaultEditorActiveMode</summary>
		[DispId(5)]
		ValueEditorActiveMode DefaultEditorActiveMode
		{
			get;
			set;
		}

		/// <summary>属性DesignMode</summary>
		[DispId(6)]
		bool DesignMode
		{
			get;
			set;
		}

		/// <summary>属性DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject</summary>
		[DispId(108)]
		bool DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject
		{
			get;
			set;
		}

		/// <summary>属性DisplayFormatToInnerValue</summary>
		[DispId(54)]
		bool DisplayFormatToInnerValue
		{
			get;
			set;
		}

		/// <summary>属性DoubleClickToEditComment</summary>
		[DispId(82)]
		bool DoubleClickToEditComment
		{
			get;
			set;
		}

		/// <summary>属性DoubleClickToSelectWord</summary>
		[DispId(26)]
		bool DoubleClickToSelectWord
		{
			get;
			set;
		}

		/// <summary>属性DoubleCompressHtmlWhitespace</summary>
		[DispId(97)]
		bool DoubleCompressHtmlWhitespace
		{
			get;
			set;
		}

		/// <summary>属性EnableCalculateControl</summary>
		[DispId(65)]
		bool EnableCalculateControl
		{
			get;
			set;
		}

		/// <summary>属性EnableCheckControlLoaded</summary>
		[DispId(49)]
		bool EnableCheckControlLoaded
		{
			get;
			set;
		}

		/// <summary>属性EnableChineseFontSizeName</summary>
		[DispId(94)]
		bool EnableChineseFontSizeName
		{
			get;
			set;
		}

		/// <summary>属性EnableCollapseSection</summary>
		[DispId(112)]
		bool EnableCollapseSection
		{
			get;
			set;
		}

		/// <summary>属性EnableCompressUserHistories</summary>
		[DispId(36)]
		bool EnableCompressUserHistories
		{
			get;
			set;
		}

		/// <summary>属性EnableContentChangedEventWhenLoadDocument</summary>
		[DispId(113)]
		bool EnableContentChangedEventWhenLoadDocument
		{
			get;
			set;
		}

		/// <summary>属性EnableContentLock</summary>
		[DispId(104)]
		bool EnableContentLock
		{
			get;
			set;
		}

		/// <summary>属性EnableControlHostAtDesignTime</summary>
		[DispId(7)]
		bool EnableControlHostAtDesignTime
		{
			get;
			set;
		}

		/// <summary>属性EnableCopySource</summary>
		[DispId(8)]
		bool EnableCopySource
		{
			get;
			set;
		}

		/// <summary>属性EnableDataBinding</summary>
		[DispId(9)]
		bool EnableDataBinding
		{
			get;
			set;
		}

		/// <summary>属性EnabledElementEvent</summary>
		[DispId(83)]
		bool EnabledElementEvent
		{
			get;
			set;
		}

		/// <summary>属性EnableDeleteReadonlyEmptyContainer</summary>
		[DispId(48)]
		bool EnableDeleteReadonlyEmptyContainer
		{
			get;
			set;
		}

		/// <summary>属性EnabledShowWinTaskBarProgress</summary>
		[DispId(121)]
		bool EnabledShowWinTaskBarProgress
		{
			get;
			set;
		}

		/// <summary>属性EnableEditElementValue</summary>
		[DispId(66)]
		bool EnableEditElementValue
		{
			get;
			set;
		}

		/// <summary>属性EnableElementEvents</summary>
		[DispId(35)]
		bool EnableElementEvents
		{
			get;
			set;
		}

		/// <summary>属性EnableExpression</summary>
		[DispId(10)]
		bool EnableExpression
		{
			get;
			set;
		}

		/// <summary>属性EnableHyperLink</summary>
		[DispId(45)]
		bool EnableHyperLink
		{
			get;
			set;
		}

		/// <summary>属性EnableKBEntryRangeMask</summary>
		[DispId(27)]
		bool EnableKBEntryRangeMask
		{
			get;
			set;
		}

		/// <summary>属性EnableLogUndo</summary>
		[DispId(37)]
		bool EnableLogUndo
		{
			get;
			set;
		}

		/// <summary>属性EnableScript</summary>
		[DispId(11)]
		bool EnableScript
		{
			get;
			set;
		}

		/// <summary>属性EnableSetJumpPrintPositionWhenPreview</summary>
		[DispId(42)]
		bool EnableSetJumpPrintPositionWhenPreview
		{
			get;
			set;
		}

		/// <summary>属性ExcludeKeywords</summary>
		[DispId(12)]
		string ExcludeKeywords
		{
			get;
			set;
		}

		/// <summary>属性ExtendingPrintDialog</summary>
		[DispId(38)]
		bool ExtendingPrintDialog
		{
			get;
			set;
		}

		/// <summary>属性FastInputMode</summary>
		[DispId(71)]
		bool FastInputMode
		{
			get;
			set;
		}

		/// <summary>属性FillCommentToUserTrackList</summary>
		[DispId(43)]
		bool FillCommentToUserTrackList
		{
			get;
			set;
		}

		/// <summary>属性ForceCollateWhenPrint</summary>
		[DispId(32)]
		bool ForceCollateWhenPrint
		{
			get;
			set;
		}

		/// <summary>属性ForcePopupFormTopMost</summary>
		[DispId(13)]
		bool ForcePopupFormTopMost
		{
			get;
			set;
		}

		/// <summary>属性FormView</summary>
		[DispId(84)]
		FormViewMode FormView
		{
			get;
			set;
		}

		/// <summary>属性GeneratePageContentVersion</summary>
		[DispId(55)]
		bool GeneratePageContentVersion
		{
			get;
			set;
		}

		/// <summary>属性GlobalSpecifyDebugModeValue</summary>
		[DispId(59)]
		bool GlobalSpecifyDebugModeValue
		{
			get;
			set;
		}

		/// <summary>属性HandleCommandException</summary>
		[DispId(56)]
		bool HandleCommandException
		{
			get;
			set;
		}

		/// <summary>属性IgnorePrintableAreaOffset</summary>
		[DispId(60)]
		bool IgnorePrintableAreaOffset
		{
			get;
			set;
		}

		/// <summary>属性ImageCompressSaveMode</summary>
		[DispId(52)]
		DCImageCompressSaveMode ImageCompressSaveMode
		{
			get;
			set;
		}

		/// <summary>属性ImageShapeEditorBackgroundMenuItemConfig</summary>
		[DispId(39)]
		string ImageShapeEditorBackgroundMenuItemConfig
		{
			get;
			set;
		}

		/// <summary>属性InsertCommentBindingUserTrack</summary>
		[DispId(23)]
		bool InsertCommentBindingUserTrack
		{
			get;
			set;
		}

		/// <summary>属性InsertDocumentWithCheckMRID</summary>
		[DispId(14)]
		InsertDocumentWithCheckMRIDType InsertDocumentWithCheckMRID
		{
			get;
			set;
		}

		/// <summary>属性LocalAutoSaveWorkDirectory</summary>
		[DispId(116)]
		string LocalAutoSaveWorkDirectory
		{
			get;
			set;
		}

		/// <summary>属性LockScrollPositionWhenStrictFormViewMode</summary>
		[DispId(117)]
		bool LockScrollPositionWhenStrictFormViewMode
		{
			get;
			set;
		}

		/// <summary>属性MaximizedPrintPreviewDialog</summary>
		[DispId(92)]
		bool MaximizedPrintPreviewDialog
		{
			get;
			set;
		}

		/// <summary>属性MaxTextLengthForPaste</summary>
		[DispId(111)]
		int MaxTextLengthForPaste
		{
			get;
			set;
		}

		/// <summary>属性MaxZoomRate</summary>
		[DispId(100)]
		float MaxZoomRate
		{
			get;
			set;
		}

		/// <summary>属性MinCountForDropdownListSpellCodeArea</summary>
		[DispId(103)]
		int MinCountForDropdownListSpellCodeArea
		{
			get;
			set;
		}

		/// <summary>属性MinImageFileSizeForConfirmCompressSaveMode</summary>
		[DispId(46)]
		int MinImageFileSizeForConfirmCompressSaveMode
		{
			get;
			set;
		}

		/// <summary>属性MinZoomRate</summary>
		[DispId(101)]
		float MinZoomRate
		{
			get;
			set;
		}

		/// <summary>属性MoveCaretWhenDeleteFail</summary>
		[DispId(98)]
		bool MoveCaretWhenDeleteFail
		{
			get;
			set;
		}

		/// <summary>属性MoveFieldWhenDragWholeContent</summary>
		[DispId(40)]
		bool MoveFieldWhenDragWholeContent
		{
			get;
			set;
		}

		/// <summary>属性MoveFocusHotKey</summary>
		[DispId(85)]
		MoveFocusHotKeys MoveFocusHotKey
		{
			get;
			set;
		}

		/// <summary>属性NewExpressionExecuteMode</summary>
		[DispId(118)]
		bool NewExpressionExecuteMode
		{
			get;
			set;
		}

		/// <summary>属性NotificationWorkingTimeout</summary>
		[DispId(57)]
		int NotificationWorkingTimeout
		{
			get;
			set;
		}

		/// <summary>属性OutputBackgroundTextToRTF</summary>
		[DispId(15)]
		bool OutputBackgroundTextToRTF
		{
			get;
			set;
		}

		/// <summary>属性OutputFieldBorderTextToContentText</summary>
		[DispId(110)]
		bool OutputFieldBorderTextToContentText
		{
			get;
			set;
		}

		/// <summary>属性OutputFormatedXMLSource</summary>
		[DispId(16)]
		bool OutputFormatedXMLSource
		{
			get;
			set;
		}

		/// <summary>属性PageLineUnderPageBreak</summary>
		[DispId(61)]
		bool PageLineUnderPageBreak
		{
			get;
			set;
		}

		/// <summary>属性ParagraphFlagFollowTableOrSection</summary>
		[DispId(58)]
		bool ParagraphFlagFollowTableOrSection
		{
			get;
			set;
		}

		/// <summary>属性PowerfulCommentCommand</summary>
		[DispId(24)]
		bool PowerfulCommentCommand
		{
			get;
			set;
		}

		/// <summary>属性PreserveClipbardDataWhenExit</summary>
		[DispId(86)]
		bool PreserveClipbardDataWhenExit
		{
			get;
			set;
		}

		/// <summary>属性Printable</summary>
		[DispId(17)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性PromptForExcludeSystemClipboardRange</summary>
		[DispId(28)]
		bool PromptForExcludeSystemClipboardRange
		{
			get;
			set;
		}

		/// <summary>属性PromptForRejectFormat</summary>
		[DispId(29)]
		bool PromptForRejectFormat
		{
			get;
			set;
		}

		/// <summary>属性PromptJumpBackForSearch</summary>
		[DispId(44)]
		bool PromptJumpBackForSearch
		{
			get;
			set;
		}

		/// <summary>属性PromptProtectedContent</summary>
		[DispId(18)]
		PromptProtectedContentMode PromptProtectedContent
		{
			get;
			set;
		}

		/// <summary>属性RaiseQueryListItemsWhenUserEditText</summary>
		[DispId(91)]
		bool RaiseQueryListItemsWhenUserEditText
		{
			get;
			set;
		}

		/// <summary>属性RemoveLastParagraphFlagWhenInsertDocument</summary>
		[DispId(99)]
		bool RemoveLastParagraphFlagWhenInsertDocument
		{
			get;
			set;
		}

		/// <summary>属性ShowDebugMessage</summary>
		[DispId(41)]
		bool ShowDebugMessage
		{
			get;
			set;
		}

		/// <summary>属性ShowTooltip</summary>
		[DispId(87)]
		bool ShowTooltip
		{
			get;
			set;
		}

		/// <summary>属性SimpleElementProperties</summary>
		[DispId(47)]
		bool SimpleElementProperties
		{
			get;
			set;
		}

		/// <summary>属性SmoothScrollView</summary>
		[DispId(70)]
		bool SmoothScrollView
		{
			get;
			set;
		}

		/// <summary>属性SpecifyDebugMode</summary>
		[DispId(19)]
		bool SpecifyDebugMode
		{
			get;
			set;
		}

		/// <summary>属性SpeedupByMultiThread</summary>
		[DispId(120)]
		bool SpeedupByMultiThread
		{
			get;
			set;
		}

		/// <summary>属性StdLablesForImageEditor</summary>
		[DispId(50)]
		string StdLablesForImageEditor
		{
			get;
			set;
		}

		/// <summary>属性TableCellOperationDetectDistance</summary>
		[DispId(20)]
		int TableCellOperationDetectDistance
		{
			get;
			set;
		}

		/// <summary>属性ThreeClickToSelectParagraph</summary>
		[DispId(30)]
		bool ThreeClickToSelectParagraph
		{
			get;
			set;
		}

		/// <summary>属性TitleForToolTip</summary>
		[DispId(67)]
		string TitleForToolTip
		{
			get;
			set;
		}

		/// <summary>属性ValidateIDRepeatMode</summary>
		[DispId(62)]
		DCValidateIDRepeatMode ValidateIDRepeatMode
		{
			get;
			set;
		}

		/// <summary>属性ValidateUserIDWhenEditDeleteComment</summary>
		[DispId(31)]
		bool ValidateUserIDWhenEditDeleteComment
		{
			get;
			set;
		}

		/// <summary>属性WeakMode</summary>
		[DispId(33)]
		bool WeakMode
		{
			get;
			set;
		}

		/// <summary>属性WidelyRaiseFocusEvent</summary>
		[DispId(21)]
		bool WidelyRaiseFocusEvent
		{
			get;
			set;
		}

		/// <summary>属性XMLContentEncodingName</summary>
		[DispId(89)]
		string XMLContentEncodingName
		{
			get;
			set;
		}
	}
}
