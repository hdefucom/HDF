using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoft.Writer.Extension;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Extension.Medical;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>InstanceFactoryForCOM 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("77B824D9-ED20-4C92-AC3D-FF75FEB2839F")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IInstanceFactoryForCOM
	{
		/// <summary>方法ConvertToBorderBackgroundCommandParameter</summary>
		[DispId(69)]
		BorderBackgroundCommandParameter ConvertToBorderBackgroundCommandParameter(object sourceValue);

		/// <summary>方法ConvertToCanInsertObjectEventArgs</summary>
		[DispId(136)]
		CanInsertObjectEventArgs ConvertToCanInsertObjectEventArgs(object sourceValue);

		/// <summary>方法ConvertToCommandErrorEventArgs</summary>
		[DispId(70)]
		CommandErrorEventArgs ConvertToCommandErrorEventArgs(object sourceValue);

		/// <summary>方法ConvertToContentChangedEventArgs</summary>
		[DispId(71)]
		ContentChangedEventArgs ConvertToContentChangedEventArgs(object sourceValue);

		/// <summary>方法ConvertToContentChangingEventArgs</summary>
		[DispId(72)]
		ContentChangingEventArgs ConvertToContentChangingEventArgs(object sourceValue);

		/// <summary>方法ConvertToCopySourceInfo</summary>
		[DispId(73)]
		CopySourceInfo ConvertToCopySourceInfo(object sourceValue);

		/// <summary>方法ConvertToCreateElementsByKBEntryEventArgs</summary>
		[DispId(137)]
		CreateElementsByKBEntryEventArgs ConvertToCreateElementsByKBEntryEventArgs(object sourceValue);

		/// <summary>方法ConvertToCurrentContentStyleInfo</summary>
		[DispId(74)]
		CurrentContentStyleInfo ConvertToCurrentContentStyleInfo(object sourceValue);

		/// <summary>方法ConvertToCurrentDepartmentInfo</summary>
		[DispId(75)]
		CurrentDepartmentInfo ConvertToCurrentDepartmentInfo(object sourceValue);

		/// <summary>方法ConvertToCurrentUserInfo</summary>
		[DispId(76)]
		CurrentUserInfo ConvertToCurrentUserInfo(object sourceValue);

		/// <summary>方法ConvertToDataSourceDescriptor</summary>
		[DispId(77)]
		DataSourceDescriptor ConvertToDataSourceDescriptor(object sourceValue);

		/// <summary>方法ConvertToDataSourceDescriptorList</summary>
		[DispId(78)]
		DataSourceDescriptorList ConvertToDataSourceDescriptorList(object sourceValue);

		/// <summary>方法ConvertToDocumentComment</summary>
		[DispId(79)]
		DocumentComment ConvertToDocumentComment(object sourceValue);

		/// <summary>方法ConvertToDocumentContentStyle</summary>
		[DispId(80)]
		DocumentContentStyle ConvertToDocumentContentStyle(object sourceValue);

		/// <summary>方法ConvertToElementCancelEventArgs</summary>
		[DispId(138)]
		ElementCancelEventArgs ConvertToElementCancelEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementEventArgs</summary>
		[DispId(139)]
		ElementEventArgs ConvertToElementEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementEventTemplate</summary>
		[DispId(81)]
		ElementEventTemplate ConvertToElementEventTemplate(object sourceValue);

		/// <summary>方法ConvertToElementExpressionEventArgs</summary>
		[DispId(140)]
		ElementExpressionEventArgs ConvertToElementExpressionEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementKeyEventArgs</summary>
		[DispId(141)]
		ElementKeyEventArgs ConvertToElementKeyEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementLoadEventArgs</summary>
		[DispId(142)]
		ElementLoadEventArgs ConvertToElementLoadEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementMouseEventArgs</summary>
		[DispId(143)]
		ElementMouseEventArgs ConvertToElementMouseEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementPaintEventArgs</summary>
		[DispId(144)]
		ElementPaintEventArgs ConvertToElementPaintEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementQueryStateEventArgs</summary>
		[DispId(145)]
		ElementQueryStateEventArgs ConvertToElementQueryStateEventArgs(object sourceValue);

		/// <summary>方法ConvertToElementValidatingEventArgs</summary>
		[DispId(146)]
		ElementValidatingEventArgs ConvertToElementValidatingEventArgs(object sourceValue);

		/// <summary>方法ConvertToEventExpressionInfo</summary>
		[DispId(82)]
		EventExpressionInfo ConvertToEventExpressionInfo(object sourceValue);

		/// <summary>方法ConvertToEventExpressionInfoList</summary>
		[DispId(83)]
		EventExpressionInfoList ConvertToEventExpressionInfoList(object sourceValue);

		/// <summary>方法ConvertToFileContentSource</summary>
		[DispId(84)]
		FileContentSource ConvertToFileContentSource(object sourceValue);

		/// <summary>方法ConvertToFileOpenCommandParameter</summary>
		[DispId(85)]
		FileOpenCommandParameter ConvertToFileOpenCommandParameter(object sourceValue);

		/// <summary>方法ConvertToFilePrintPreviewCommandParameter</summary>
		[DispId(86)]
		FilePrintPreviewCommandParameter ConvertToFilePrintPreviewCommandParameter(object sourceValue);

		/// <summary>方法ConvertToFileSaveCommandParameter</summary>
		[DispId(87)]
		FileSaveCommandParameter ConvertToFileSaveCommandParameter(object sourceValue);

		/// <summary>方法ConvertToFilterValueEventArgs</summary>
		[DispId(147)]
		FilterValueEventArgs ConvertToFilterValueEventArgs(object sourceValue);

		/// <summary>方法ConvertToFormatListItemsEventArgs</summary>
		[DispId(148)]
		FormatListItemsEventArgs ConvertToFormatListItemsEventArgs(object sourceValue);

		/// <summary>方法ConvertToGridLineInfo</summary>
		[DispId(88)]
		GridLineInfo ConvertToGridLineInfo(object sourceValue);

		/// <summary>方法ConvertToGridLineSettings</summary>
		[DispId(89)]
		GridLineSettings ConvertToGridLineSettings(object sourceValue);

		/// <summary>方法ConvertToInputFieldSettings</summary>
		[DispId(90)]
		InputFieldSettings ConvertToInputFieldSettings(object sourceValue);

		/// <summary>方法ConvertToInsertDocumentCommandParameter</summary>
		[DispId(149)]
		InsertDocumentCommandParameter ConvertToInsertDocumentCommandParameter(object sourceValue);

		/// <summary>方法ConvertToInsertObjectEventArgs</summary>
		[DispId(150)]
		InsertObjectEventArgs ConvertToInsertObjectEventArgs(object sourceValue);

		/// <summary>方法ConvertToInsertStringCommandParameter</summary>
		[DispId(91)]
		InsertStringCommandParameter ConvertToInsertStringCommandParameter(object sourceValue);

		/// <summary>方法ConvertToJumpPrintInfo</summary>
		[DispId(92)]
		JumpPrintInfo ConvertToJumpPrintInfo(object sourceValue);

		/// <summary>方法ConvertToKBEntry</summary>
		[DispId(93)]
		KBEntry ConvertToKBEntry(object sourceValue);

		/// <summary>方法ConvertToKBEntryList</summary>
		[DispId(94)]
		KBEntryList ConvertToKBEntryList(object sourceValue);

		/// <summary>方法ConvertToKBLibrary</summary>
		[DispId(95)]
		KBLibrary ConvertToKBLibrary(object sourceValue);

		/// <summary>方法ConvertToListItem</summary>
		[DispId(96)]
		ListItem ConvertToListItem(object sourceValue);

		/// <summary>方法ConvertToListItemCollection</summary>
		[DispId(97)]
		ListItemCollection ConvertToListItemCollection(object sourceValue);

		/// <summary>方法ConvertToListSourceInfo</summary>
		[DispId(98)]
		ListSourceInfo ConvertToListSourceInfo(object sourceValue);

		/// <summary>方法ConvertToMegeCellCommandParameter</summary>
		[DispId(99)]
		MegeCellCommandParameter ConvertToMegeCellCommandParameter(object sourceValue);

		/// <summary>方法ConvertToParagraphFormatCommandParameter</summary>
		[DispId(100)]
		ParagraphFormatCommandParameter ConvertToParagraphFormatCommandParameter(object sourceValue);

		/// <summary>方法ConvertToParseSelectedItemsEventArgs</summary>
		[DispId(151)]
		ParseSelectedItemsEventArgs ConvertToParseSelectedItemsEventArgs(object sourceValue);

		/// <summary>方法ConvertToPrintPageCollection</summary>
		[DispId(101)]
		PrintPageCollection ConvertToPrintPageCollection(object sourceValue);

		/// <summary>方法ConvertToPrintResult</summary>
		[DispId(102)]
		PrintResult ConvertToPrintResult(object sourceValue);

		/// <summary>方法ConvertToQueryListItemsEventArgs</summary>
		[DispId(152)]
		QueryListItemsEventArgs ConvertToQueryListItemsEventArgs(object sourceValue);

		/// <summary>方法ConvertToQueryUserHistoryDisplayTextEventArgs</summary>
		[DispId(153)]
		QueryUserHistoryDisplayTextEventArgs ConvertToQueryUserHistoryDisplayTextEventArgs(object sourceValue);

		/// <summary>方法ConvertToSearchReplaceCommandArgs</summary>
		[DispId(103)]
		SearchReplaceCommandArgs ConvertToSearchReplaceCommandArgs(object sourceValue);

		/// <summary>方法ConvertToSectionCourseRecord</summary>
		[DispId(154)]
		SectionCourseRecord ConvertToSectionCourseRecord(object sourceValue);

		/// <summary>方法ConvertToSectionCourseRecordDocumentController</summary>
		[DispId(104)]
		SectionCourseRecordDocumentController ConvertToSectionCourseRecordDocumentController(object sourceValue);

		/// <summary>方法ConvertToSplitCellExtCommandParameter</summary>
		[DispId(105)]
		SplitCellExtCommandParameter ConvertToSplitCellExtCommandParameter(object sourceValue);

		/// <summary>方法ConvertToStatusTextChangedEventArgs</summary>
		[DispId(155)]
		StatusTextChangedEventArgs ConvertToStatusTextChangedEventArgs(object sourceValue);

		/// <summary>方法ConvertToTableCommandArgs</summary>
		[DispId(106)]
		TableCommandArgs ConvertToTableCommandArgs(object sourceValue);

		/// <summary>方法ConvertToTrackVisibleConfig</summary>
		[DispId(107)]
		TrackVisibleConfig ConvertToTrackVisibleConfig(object sourceValue);

		/// <summary>方法ConvertToValueFormater</summary>
		[DispId(108)]
		ValueFormater ConvertToValueFormater(object sourceValue);

		/// <summary>方法ConvertToValueValidateStyle</summary>
		[DispId(109)]
		ValueValidateStyle ConvertToValueValidateStyle(object sourceValue);

		/// <summary>方法ConvertToWriterCommandEventArgs</summary>
		[DispId(156)]
		WriterCommandEventArgs ConvertToWriterCommandEventArgs(object sourceValue);

		/// <summary>方法ConvertToWriterEventArgs</summary>
		[DispId(157)]
		WriterEventArgs ConvertToWriterEventArgs(object sourceValue);

		/// <summary>方法ConvertToWriterMouseEventArgs</summary>
		[DispId(158)]
		WriterMouseEventArgs ConvertToWriterMouseEventArgs(object sourceValue);

		/// <summary>方法ConvertToXAttribute</summary>
		[DispId(110)]
		XAttribute ConvertToXAttribute(object sourceValue);

		/// <summary>方法ConvertToXAttributeList</summary>
		[DispId(111)]
		XAttributeList ConvertToXAttributeList(object sourceValue);

		/// <summary>方法ConvertToXPageSettings</summary>
		[DispId(112)]
		XPageSettings ConvertToXPageSettings(object sourceValue);

		/// <summary>方法ConvertToXTextBarcodeFieldElement</summary>
		[DispId(113)]
		XTextBarcodeFieldElement ConvertToXTextBarcodeFieldElement(object sourceValue);

		/// <summary>方法ConvertToXTextCheckBoxElement</summary>
		[DispId(114)]
		XTextCheckBoxElement ConvertToXTextCheckBoxElement(object sourceValue);

		/// <summary>方法ConvertToXTextContentLinkFieldElement</summary>
		[DispId(115)]
		XTextContentLinkFieldElement ConvertToXTextContentLinkFieldElement(object sourceValue);

		/// <summary>方法ConvertToXTextControlHostElement</summary>
		[DispId(116)]
		XTextControlHostElement ConvertToXTextControlHostElement(object sourceValue);

		/// <summary>方法ConvertToXTextDocument</summary>
		[DispId(117)]
		XTextDocument ConvertToXTextDocument(object sourceValue);

		/// <summary>方法ConvertToXTextDocumentList</summary>
		[DispId(118)]
		XTextDocumentList ConvertToXTextDocumentList(object sourceValue);

		/// <summary>方法ConvertToXTextElementList</summary>
		[DispId(119)]
		XTextElementList ConvertToXTextElementList(object sourceValue);

		/// <summary>方法ConvertToXTextFileBlockElement</summary>
		[DispId(120)]
		XTextFileBlockElement ConvertToXTextFileBlockElement(object sourceValue);

		/// <summary>方法ConvertToXTextHorizontalLineElement</summary>
		[DispId(121)]
		XTextHorizontalLineElement ConvertToXTextHorizontalLineElement(object sourceValue);

		/// <summary>方法ConvertToXTextImageElement</summary>
		[DispId(122)]
		XTextImageElement ConvertToXTextImageElement(object sourceValue);

		/// <summary>方法ConvertToXTextInputFieldElement</summary>
		[DispId(123)]
		XTextInputFieldElement ConvertToXTextInputFieldElement(object sourceValue);

		/// <summary>方法ConvertToXTextLabelElement</summary>
		[DispId(124)]
		XTextLabelElement ConvertToXTextLabelElement(object sourceValue);

		/// <summary>方法ConvertToXTextLineBreakElement</summary>
		[DispId(125)]
		XTextLineBreakElement ConvertToXTextLineBreakElement(object sourceValue);

		/// <summary>方法ConvertToXTextMedicalExpressionFieldElement</summary>
		[DispId(126)]
		XTextMedicalExpressionFieldElement ConvertToXTextMedicalExpressionFieldElement(object sourceValue);

		/// <summary>方法ConvertToXTextPageBreakElement</summary>
		[DispId(127)]
		XTextPageBreakElement ConvertToXTextPageBreakElement(object sourceValue);

		/// <summary>方法ConvertToXTextPageInfoElement</summary>
		[DispId(128)]
		XTextPageInfoElement ConvertToXTextPageInfoElement(object sourceValue);

		/// <summary>方法ConvertToXTextParagraphFlagElement</summary>
		[DispId(129)]
		XTextParagraphFlagElement ConvertToXTextParagraphFlagElement(object sourceValue);

		/// <summary>方法ConvertToXTextRadioBoxElement</summary>
		[DispId(162)]
		XTextRadioBoxElement ConvertToXTextRadioBoxElement(object sourceValue);

		/// <summary>方法ConvertToXTextSectionElement</summary>
		[DispId(130)]
		XTextSectionElement ConvertToXTextSectionElement(object sourceValue);

		/// <summary>方法ConvertToXTextSignElement</summary>
		[DispId(131)]
		XTextSignElement ConvertToXTextSignElement(object sourceValue);

		/// <summary>方法ConvertToXTextTableCellElement</summary>
		[DispId(132)]
		XTextTableCellElement ConvertToXTextTableCellElement(object sourceValue);

		/// <summary>方法ConvertToXTextTableColumnElement</summary>
		[DispId(133)]
		XTextTableColumnElement ConvertToXTextTableColumnElement(object sourceValue);

		/// <summary>方法ConvertToXTextTableElement</summary>
		[DispId(134)]
		XTextTableElement ConvertToXTextTableElement(object sourceValue);

		/// <summary>方法ConvertToXTextTableRowElement</summary>
		[DispId(135)]
		XTextTableRowElement ConvertToXTextTableRowElement(object sourceValue);

		/// <summary>方法CreateBorderBackgroundCommandParameter</summary>
		[DispId(2)]
		BorderBackgroundCommandParameter CreateBorderBackgroundCommandParameter();

		/// <summary>方法CreateCommandErrorEventArgs</summary>
		[DispId(3)]
		CommandErrorEventArgs CreateCommandErrorEventArgs();

		/// <summary>方法CreateContentChangedEventArgs</summary>
		[DispId(4)]
		ContentChangedEventArgs CreateContentChangedEventArgs();

		/// <summary>方法CreateContentChangingEventArgs</summary>
		[DispId(5)]
		ContentChangingEventArgs CreateContentChangingEventArgs();

		/// <summary>方法CreateCopySourceInfo</summary>
		[DispId(6)]
		CopySourceInfo CreateCopySourceInfo();

		/// <summary>方法CreateCurrentContentStyleInfo</summary>
		[DispId(7)]
		CurrentContentStyleInfo CreateCurrentContentStyleInfo();

		/// <summary>方法CreateCurrentDepartmentInfo</summary>
		[DispId(8)]
		CurrentDepartmentInfo CreateCurrentDepartmentInfo();

		/// <summary>方法CreateCurrentUserInfo</summary>
		[DispId(9)]
		CurrentUserInfo CreateCurrentUserInfo();

		/// <summary>方法CreateDataSourceDescriptor</summary>
		[DispId(10)]
		DataSourceDescriptor CreateDataSourceDescriptor();

		/// <summary>方法CreateDataSourceDescriptorList</summary>
		[DispId(11)]
		DataSourceDescriptorList CreateDataSourceDescriptorList();

		/// <summary>方法CreateDocumentComment</summary>
		[DispId(12)]
		DocumentComment CreateDocumentComment();

		/// <summary>方法CreateDocumentContentStyle</summary>
		[DispId(13)]
		DocumentContentStyle CreateDocumentContentStyle();

		/// <summary>方法CreateElementEventArgs</summary>
		[DispId(159)]
		ElementEventArgs CreateElementEventArgs();

		/// <summary>方法CreateElementEventTemplate</summary>
		[DispId(14)]
		ElementEventTemplate CreateElementEventTemplate();

		/// <summary>方法CreateEventExpressionInfo</summary>
		[DispId(15)]
		EventExpressionInfo CreateEventExpressionInfo();

		/// <summary>方法CreateEventExpressionInfoList</summary>
		[DispId(16)]
		EventExpressionInfoList CreateEventExpressionInfoList();

		/// <summary>方法CreateFileContentSource</summary>
		[DispId(17)]
		FileContentSource CreateFileContentSource();

		/// <summary>方法CreateFileOpenCommandParameter</summary>
		[DispId(18)]
		FileOpenCommandParameter CreateFileOpenCommandParameter();

		/// <summary>方法CreateFilePrintPreviewCommandParameter</summary>
		[DispId(19)]
		FilePrintPreviewCommandParameter CreateFilePrintPreviewCommandParameter();

		/// <summary>方法CreateFileSaveCommandParameter</summary>
		[DispId(20)]
		FileSaveCommandParameter CreateFileSaveCommandParameter();

		/// <summary>方法CreateGridLineInfo</summary>
		[DispId(21)]
		GridLineInfo CreateGridLineInfo();

		/// <summary>方法CreateGridLineSettings</summary>
		[DispId(22)]
		GridLineSettings CreateGridLineSettings();

		/// <summary>方法CreateInputFieldSettings</summary>
		[DispId(23)]
		InputFieldSettings CreateInputFieldSettings();

		/// <summary>方法CreateInsertDocumentCommandParameter</summary>
		[DispId(161)]
		InsertDocumentCommandParameter CreateInsertDocumentCommandParameter();

		/// <summary>方法CreateInsertStringCommandParameter</summary>
		[DispId(24)]
		InsertStringCommandParameter CreateInsertStringCommandParameter();

		/// <summary>方法CreateJumpPrintInfo</summary>
		[DispId(25)]
		JumpPrintInfo CreateJumpPrintInfo();

		/// <summary>方法CreateKBEntry</summary>
		[DispId(26)]
		KBEntry CreateKBEntry();

		/// <summary>方法CreateKBEntryList</summary>
		[DispId(27)]
		KBEntryList CreateKBEntryList();

		/// <summary>方法CreateKBLibrary</summary>
		[DispId(28)]
		KBLibrary CreateKBLibrary();

		/// <summary>方法CreateListItem</summary>
		[DispId(29)]
		ListItem CreateListItem();

		/// <summary>方法CreateListItemCollection</summary>
		[DispId(30)]
		ListItemCollection CreateListItemCollection();

		/// <summary>方法CreateListSourceInfo</summary>
		[DispId(31)]
		ListSourceInfo CreateListSourceInfo();

		/// <summary>方法CreateMegeCellCommandParameter</summary>
		[DispId(32)]
		MegeCellCommandParameter CreateMegeCellCommandParameter();

		/// <summary>方法CreateParagraphFormatCommandParameter</summary>
		[DispId(33)]
		ParagraphFormatCommandParameter CreateParagraphFormatCommandParameter();

		/// <summary>方法CreatePrintPageCollection</summary>
		[DispId(34)]
		PrintPageCollection CreatePrintPageCollection();

		/// <summary>方法CreatePrintResult</summary>
		[DispId(35)]
		PrintResult CreatePrintResult();

		/// <summary>方法CreateSearchReplaceCommandArgs</summary>
		[DispId(36)]
		SearchReplaceCommandArgs CreateSearchReplaceCommandArgs();

		/// <summary>方法CreateSectionCourseRecordDocumentController</summary>
		[DispId(37)]
		SectionCourseRecordDocumentController CreateSectionCourseRecordDocumentController();

		/// <summary>方法CreateSplitCellExtCommandParameter</summary>
		[DispId(38)]
		SplitCellExtCommandParameter CreateSplitCellExtCommandParameter();

		/// <summary>方法CreateTableCommandArgs</summary>
		[DispId(39)]
		TableCommandArgs CreateTableCommandArgs();

		/// <summary>方法CreateTrackVisibleConfig</summary>
		[DispId(40)]
		TrackVisibleConfig CreateTrackVisibleConfig();

		/// <summary>方法CreateValueFormater</summary>
		[DispId(41)]
		ValueFormater CreateValueFormater();

		/// <summary>方法CreateValueValidateStyle</summary>
		[DispId(42)]
		ValueValidateStyle CreateValueValidateStyle();

		/// <summary>方法CreateXAttribute</summary>
		[DispId(43)]
		XAttribute CreateXAttribute();

		/// <summary>方法CreateXAttributeList</summary>
		[DispId(44)]
		XAttributeList CreateXAttributeList();

		/// <summary>方法CreateXDataBinding</summary>
		[DispId(163)]
		XDataBinding CreateXDataBinding();

		/// <summary>方法CreateXPageSettings</summary>
		[DispId(45)]
		XPageSettings CreateXPageSettings();

		/// <summary>方法CreateXTextBarcodeFieldElement</summary>
		[DispId(46)]
		XTextBarcodeFieldElement CreateXTextBarcodeFieldElement();

		/// <summary>方法CreateXTextCheckBoxElement</summary>
		[DispId(47)]
		XTextCheckBoxElement CreateXTextCheckBoxElement();

		/// <summary>方法CreateXTextContentLinkFieldElement</summary>
		[DispId(48)]
		XTextContentLinkFieldElement CreateXTextContentLinkFieldElement();

		/// <summary>方法CreateXTextControlHostElement</summary>
		[DispId(49)]
		XTextControlHostElement CreateXTextControlHostElement();

		/// <summary>方法CreateXTextDocument</summary>
		[DispId(50)]
		XTextDocument CreateXTextDocument();

		/// <summary>方法CreateXTextDocumentList</summary>
		[DispId(51)]
		XTextDocumentList CreateXTextDocumentList();

		/// <summary>方法CreateXTextElementList</summary>
		[DispId(52)]
		XTextElementList CreateXTextElementList();

		/// <summary>方法CreateXTextFileBlockElement</summary>
		[DispId(53)]
		XTextFileBlockElement CreateXTextFileBlockElement();

		/// <summary>方法CreateXTextHorizontalLineElement</summary>
		[DispId(54)]
		XTextHorizontalLineElement CreateXTextHorizontalLineElement();

		/// <summary>方法CreateXTextImageElement</summary>
		[DispId(55)]
		XTextImageElement CreateXTextImageElement();

		/// <summary>方法CreateXTextInputFieldElement</summary>
		[DispId(56)]
		XTextInputFieldElement CreateXTextInputFieldElement();

		/// <summary>方法CreateXTextLabelElement</summary>
		[DispId(57)]
		XTextLabelElement CreateXTextLabelElement();

		/// <summary>方法CreateXTextLineBreakElement</summary>
		[DispId(58)]
		XTextLineBreakElement CreateXTextLineBreakElement();

		/// <summary>方法CreateXTextMedicalExpressionFieldElement</summary>
		[DispId(59)]
		XTextMedicalExpressionFieldElement CreateXTextMedicalExpressionFieldElement();

		/// <summary>方法CreateXTextPageBreakElement</summary>
		[DispId(60)]
		XTextPageBreakElement CreateXTextPageBreakElement();

		/// <summary>方法CreateXTextPageInfoElement</summary>
		[DispId(61)]
		XTextPageInfoElement CreateXTextPageInfoElement();

		/// <summary>方法CreateXTextParagraphFlagElement</summary>
		[DispId(62)]
		XTextParagraphFlagElement CreateXTextParagraphFlagElement();

		/// <summary>方法CreateXTextRadioBoxElement</summary>
		[DispId(164)]
		XTextRadioBoxElement CreateXTextRadioBoxElement();

		/// <summary>方法CreateXTextSectionElement</summary>
		[DispId(63)]
		XTextSectionElement CreateXTextSectionElement();

		/// <summary>方法CreateXTextSignElement</summary>
		[DispId(64)]
		XTextSignElement CreateXTextSignElement();

		/// <summary>方法CreateXTextTableCellElement</summary>
		[DispId(65)]
		XTextTableCellElement CreateXTextTableCellElement();

		/// <summary>方法CreateXTextTableColumnElement</summary>
		[DispId(66)]
		XTextTableColumnElement CreateXTextTableColumnElement();

		/// <summary>方法CreateXTextTableElement</summary>
		[DispId(67)]
		XTextTableElement CreateXTextTableElement();

		/// <summary>方法CreateXTextTableRowElement</summary>
		[DispId(68)]
		XTextTableRowElement CreateXTextTableRowElement();
	}
}
