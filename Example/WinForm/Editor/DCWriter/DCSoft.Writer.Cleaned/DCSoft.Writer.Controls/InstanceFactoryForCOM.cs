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
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       针对于COM的对象实例创建器
	///       </summary>
	/// <remarks>
	///       针对在COM开发中创建对象实例不方便或者功能不稳定，在此定义工厂类
	///       用于方便的实例化各种对象实例。
	///       编制袁永福</remarks>
	[ComClass("BE5A816C-0337-4B9C-8935-E2CA67007A3E", "77B824D9-ED20-4C92-AC3D-FF75FEB2839F")]
	[ComDefaultInterface(typeof(IInstanceFactoryForCOM))]
	[Guid("BE5A816C-0337-4B9C-8935-E2CA67007A3E")]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	
	
	public class InstanceFactoryForCOM : IInstanceFactoryForCOM
	{
		internal const string CLASSID = "BE5A816C-0337-4B9C-8935-E2CA67007A3E";

		internal const string CLASSID_Interface = "77B824D9-ED20-4C92-AC3D-FF75FEB2839F";

		public XDataBinding CreateXDataBinding()
		{
			return new XDataBinding();
		}

		public ValueValidateStyle CreateValueValidateStyle()
		{
			return new ValueValidateStyle();
		}

		public ValueFormater CreateValueFormater()
		{
			return new ValueFormater();
		}

		public GridLineInfo CreateGridLineInfo()
		{
			return new GridLineInfo();
		}

		public JumpPrintInfo CreateJumpPrintInfo()
		{
			return new JumpPrintInfo();
		}

		public PrintPageCollection CreatePrintPageCollection()
		{
			return new PrintPageCollection();
		}

		public PrintResult CreatePrintResult()
		{
			return new PrintResult();
		}

		public XPageSettings CreateXPageSettings()
		{
			return new XPageSettings();
		}

		public BorderBackgroundCommandParameter CreateBorderBackgroundCommandParameter()
		{
			return new BorderBackgroundCommandParameter();
		}

		public FileOpenCommandParameter CreateFileOpenCommandParameter()
		{
			return new FileOpenCommandParameter();
		}

		public FilePrintPreviewCommandParameter CreateFilePrintPreviewCommandParameter()
		{
			return new FilePrintPreviewCommandParameter();
		}

		public FileSaveCommandParameter CreateFileSaveCommandParameter()
		{
			return new FileSaveCommandParameter();
		}

		public InsertDocumentCommandParameter CreateInsertDocumentCommandParameter()
		{
			return new InsertDocumentCommandParameter();
		}

		public InsertStringCommandParameter CreateInsertStringCommandParameter()
		{
			return new InsertStringCommandParameter();
		}

		public MegeCellCommandParameter CreateMegeCellCommandParameter()
		{
			return new MegeCellCommandParameter();
		}

		public ParagraphFormatCommandParameter CreateParagraphFormatCommandParameter()
		{
			return new ParagraphFormatCommandParameter();
		}

		public SearchReplaceCommandArgs CreateSearchReplaceCommandArgs()
		{
			return new SearchReplaceCommandArgs();
		}

		public SplitCellExtCommandParameter CreateSplitCellExtCommandParameter()
		{
			return new SplitCellExtCommandParameter();
		}

		public TableCommandArgs CreateTableCommandArgs()
		{
			return new TableCommandArgs();
		}

		public ContentChangedEventArgs CreateContentChangedEventArgs()
		{
			return new ContentChangedEventArgs();
		}

		public ContentChangingEventArgs CreateContentChangingEventArgs()
		{
			return new ContentChangingEventArgs();
		}

		public CommandErrorEventArgs CreateCommandErrorEventArgs()
		{
			return new CommandErrorEventArgs();
		}

		public CurrentDepartmentInfo CreateCurrentDepartmentInfo()
		{
			return new CurrentDepartmentInfo();
		}

		public CurrentUserInfo CreateCurrentUserInfo()
		{
			return new CurrentUserInfo();
		}

		public KBEntry CreateKBEntry()
		{
			return new KBEntry();
		}

		public KBEntryList CreateKBEntryList()
		{
			return new KBEntryList();
		}

		public KBLibrary CreateKBLibrary()
		{
			return new KBLibrary();
		}

		public ListItem CreateListItem()
		{
			return new ListItem();
		}

		public ListItemCollection CreateListItemCollection()
		{
			return new ListItemCollection();
		}

		public ListSourceInfo CreateListSourceInfo()
		{
			return new ListSourceInfo();
		}

		public XTextRadioBoxElement CreateXTextRadioBoxElement()
		{
			return new XTextRadioBoxElement();
		}

		public CopySourceInfo CreateCopySourceInfo()
		{
			return new CopySourceInfo();
		}

		public CurrentContentStyleInfo CreateCurrentContentStyleInfo()
		{
			return new CurrentContentStyleInfo();
		}

		public DocumentComment CreateDocumentComment()
		{
			return new DocumentComment();
		}

		public DocumentContentStyle CreateDocumentContentStyle()
		{
			return new DocumentContentStyle();
		}

		public FileContentSource CreateFileContentSource()
		{
			return new FileContentSource();
		}

		public InputFieldSettings CreateInputFieldSettings()
		{
			return new InputFieldSettings();
		}

		public XAttribute CreateXAttribute()
		{
			return new XAttribute();
		}

		public XAttributeList CreateXAttributeList()
		{
			return new XAttributeList();
		}

		public XTextBarcodeFieldElement CreateXTextBarcodeFieldElement()
		{
			return new XTextBarcodeFieldElement();
		}

		public XTextCheckBoxElement CreateXTextCheckBoxElement()
		{
			return new XTextCheckBoxElement();
		}

		public XTextContentLinkFieldElement CreateXTextContentLinkFieldElement()
		{
			return new XTextContentLinkFieldElement();
		}

		public XTextControlHostElement CreateXTextControlHostElement()
		{
			return new XTextControlHostElement();
		}

		public XTextDocument CreateXTextDocument()
		{
			return new XTextDocument();
		}

		public XTextDocumentList CreateXTextDocumentList()
		{
			return new XTextDocumentList();
		}

		public XTextElementList CreateXTextElementList()
		{
			return new XTextElementList();
		}

		public XTextFileBlockElement CreateXTextFileBlockElement()
		{
			return new XTextFileBlockElement();
		}

		public XTextHorizontalLineElement CreateXTextHorizontalLineElement()
		{
			return new XTextHorizontalLineElement();
		}

		public XTextImageElement CreateXTextImageElement()
		{
			return new XTextImageElement();
		}

		public XTextInputFieldElement CreateXTextInputFieldElement()
		{
			return new XTextInputFieldElement();
		}

		public XTextLabelElement CreateXTextLabelElement()
		{
			return new XTextLabelElement();
		}

		public XTextLineBreakElement CreateXTextLineBreakElement()
		{
			return new XTextLineBreakElement();
		}

		public XTextPageBreakElement CreateXTextPageBreakElement()
		{
			return new XTextPageBreakElement();
		}

		public XTextPageInfoElement CreateXTextPageInfoElement()
		{
			return new XTextPageInfoElement();
		}

		public XTextParagraphFlagElement CreateXTextParagraphFlagElement()
		{
			return new XTextParagraphFlagElement();
		}

		public XTextSectionElement CreateXTextSectionElement()
		{
			return new XTextSectionElement();
		}

		public XTextSignElement CreateXTextSignElement()
		{
			return new XTextSignElement();
		}

		public XTextTableCellElement CreateXTextTableCellElement()
		{
			return new XTextTableCellElement();
		}

		public XTextTableColumnElement CreateXTextTableColumnElement()
		{
			return new XTextTableColumnElement();
		}

		public XTextTableElement CreateXTextTableElement()
		{
			return new XTextTableElement();
		}

		public XTextTableRowElement CreateXTextTableRowElement()
		{
			return new XTextTableRowElement();
		}

		public ElementEventArgs CreateElementEventArgs()
		{
			return new ElementEventArgs();
		}

		public ElementEventTemplate CreateElementEventTemplate()
		{
			return new ElementEventTemplate();
		}

		public EventExpressionInfo CreateEventExpressionInfo()
		{
			return new EventExpressionInfo();
		}

		public EventExpressionInfoList CreateEventExpressionInfoList()
		{
			return new EventExpressionInfoList();
		}

		public DataSourceDescriptor CreateDataSourceDescriptor()
		{
			return new DataSourceDescriptor();
		}

		public DataSourceDescriptorList CreateDataSourceDescriptorList()
		{
			return new DataSourceDescriptorList();
		}

		public XTextMedicalExpressionFieldElement CreateXTextMedicalExpressionFieldElement()
		{
			return new XTextMedicalExpressionFieldElement();
		}

		public SectionCourseRecordDocumentController CreateSectionCourseRecordDocumentController()
		{
			return new SectionCourseRecordDocumentController();
		}

		public GridLineSettings CreateGridLineSettings()
		{
			return new GridLineSettings();
		}

		public TrackVisibleConfig CreateTrackVisibleConfig()
		{
			return new TrackVisibleConfig();
		}

		public ValueValidateStyle ConvertToValueValidateStyle(object sourceValue)
		{
			return sourceValue as ValueValidateStyle;
		}

		public ValueFormater ConvertToValueFormater(object sourceValue)
		{
			return sourceValue as ValueFormater;
		}

		public GridLineInfo ConvertToGridLineInfo(object sourceValue)
		{
			return sourceValue as GridLineInfo;
		}

		public JumpPrintInfo ConvertToJumpPrintInfo(object sourceValue)
		{
			return sourceValue as JumpPrintInfo;
		}

		public PrintPageCollection ConvertToPrintPageCollection(object sourceValue)
		{
			return sourceValue as PrintPageCollection;
		}

		public PrintResult ConvertToPrintResult(object sourceValue)
		{
			return sourceValue as PrintResult;
		}

		public XPageSettings ConvertToXPageSettings(object sourceValue)
		{
			return sourceValue as XPageSettings;
		}

		public CanInsertObjectEventArgs ConvertToCanInsertObjectEventArgs(object sourceValue)
		{
			return sourceValue as CanInsertObjectEventArgs;
		}

		public BorderBackgroundCommandParameter ConvertToBorderBackgroundCommandParameter(object sourceValue)
		{
			return sourceValue as BorderBackgroundCommandParameter;
		}

		public FileOpenCommandParameter ConvertToFileOpenCommandParameter(object sourceValue)
		{
			return sourceValue as FileOpenCommandParameter;
		}

		public FilePrintPreviewCommandParameter ConvertToFilePrintPreviewCommandParameter(object sourceValue)
		{
			return sourceValue as FilePrintPreviewCommandParameter;
		}

		public FileSaveCommandParameter ConvertToFileSaveCommandParameter(object sourceValue)
		{
			return sourceValue as FileSaveCommandParameter;
		}

		public InsertDocumentCommandParameter ConvertToInsertDocumentCommandParameter(object sourceValue)
		{
			return sourceValue as InsertDocumentCommandParameter;
		}

		public InsertStringCommandParameter ConvertToInsertStringCommandParameter(object sourceValue)
		{
			return sourceValue as InsertStringCommandParameter;
		}

		public MegeCellCommandParameter ConvertToMegeCellCommandParameter(object sourceValue)
		{
			return sourceValue as MegeCellCommandParameter;
		}

		public ParagraphFormatCommandParameter ConvertToParagraphFormatCommandParameter(object sourceValue)
		{
			return sourceValue as ParagraphFormatCommandParameter;
		}

		public SearchReplaceCommandArgs ConvertToSearchReplaceCommandArgs(object sourceValue)
		{
			return sourceValue as SearchReplaceCommandArgs;
		}

		public SplitCellExtCommandParameter ConvertToSplitCellExtCommandParameter(object sourceValue)
		{
			return sourceValue as SplitCellExtCommandParameter;
		}

		public TableCommandArgs ConvertToTableCommandArgs(object sourceValue)
		{
			return sourceValue as TableCommandArgs;
		}

		public WriterCommandEventArgs ConvertToWriterCommandEventArgs(object sourceValue)
		{
			return sourceValue as WriterCommandEventArgs;
		}

		public ContentChangedEventArgs ConvertToContentChangedEventArgs(object sourceValue)
		{
			return sourceValue as ContentChangedEventArgs;
		}

		public ContentChangingEventArgs ConvertToContentChangingEventArgs(object sourceValue)
		{
			return sourceValue as ContentChangingEventArgs;
		}

		public CommandErrorEventArgs ConvertToCommandErrorEventArgs(object sourceValue)
		{
			return sourceValue as CommandErrorEventArgs;
		}

		public FormatListItemsEventArgs ConvertToFormatListItemsEventArgs(object sourceValue)
		{
			return sourceValue as FormatListItemsEventArgs;
		}

		public ParseSelectedItemsEventArgs ConvertToParseSelectedItemsEventArgs(object sourceValue)
		{
			return sourceValue as ParseSelectedItemsEventArgs;
		}

		public QueryListItemsEventArgs ConvertToQueryListItemsEventArgs(object sourceValue)
		{
			return sourceValue as QueryListItemsEventArgs;
		}

		public StatusTextChangedEventArgs ConvertToStatusTextChangedEventArgs(object sourceValue)
		{
			return sourceValue as StatusTextChangedEventArgs;
		}

		public CreateElementsByKBEntryEventArgs ConvertToCreateElementsByKBEntryEventArgs(object sourceValue)
		{
			return sourceValue as CreateElementsByKBEntryEventArgs;
		}

		public CurrentDepartmentInfo ConvertToCurrentDepartmentInfo(object sourceValue)
		{
			return sourceValue as CurrentDepartmentInfo;
		}

		public CurrentUserInfo ConvertToCurrentUserInfo(object sourceValue)
		{
			return sourceValue as CurrentUserInfo;
		}

		public KBEntry ConvertToKBEntry(object sourceValue)
		{
			return sourceValue as KBEntry;
		}

		public KBEntryList ConvertToKBEntryList(object sourceValue)
		{
			return sourceValue as KBEntryList;
		}

		public KBLibrary ConvertToKBLibrary(object sourceValue)
		{
			return sourceValue as KBLibrary;
		}

		public ListItem ConvertToListItem(object sourceValue)
		{
			return sourceValue as ListItem;
		}

		public ListItemCollection ConvertToListItemCollection(object sourceValue)
		{
			return sourceValue as ListItemCollection;
		}

		public ListSourceInfo ConvertToListSourceInfo(object sourceValue)
		{
			return sourceValue as ListSourceInfo;
		}

		public CopySourceInfo ConvertToCopySourceInfo(object sourceValue)
		{
			return sourceValue as CopySourceInfo;
		}

		public CurrentContentStyleInfo ConvertToCurrentContentStyleInfo(object sourceValue)
		{
			return sourceValue as CurrentContentStyleInfo;
		}

		public DocumentComment ConvertToDocumentComment(object sourceValue)
		{
			return sourceValue as DocumentComment;
		}

		public DocumentContentStyle ConvertToDocumentContentStyle(object sourceValue)
		{
			return sourceValue as DocumentContentStyle;
		}

		public FileContentSource ConvertToFileContentSource(object sourceValue)
		{
			return sourceValue as FileContentSource;
		}

		public InputFieldSettings ConvertToInputFieldSettings(object sourceValue)
		{
			return sourceValue as InputFieldSettings;
		}

		public XAttribute ConvertToXAttribute(object sourceValue)
		{
			return sourceValue as XAttribute;
		}

		public XAttributeList ConvertToXAttributeList(object sourceValue)
		{
			return sourceValue as XAttributeList;
		}

		public XTextBarcodeFieldElement ConvertToXTextBarcodeFieldElement(object sourceValue)
		{
			return sourceValue as XTextBarcodeFieldElement;
		}

		public XTextCheckBoxElement ConvertToXTextCheckBoxElement(object sourceValue)
		{
			return sourceValue as XTextCheckBoxElement;
		}

		public XTextRadioBoxElement ConvertToXTextRadioBoxElement(object sourceValue)
		{
			return sourceValue as XTextRadioBoxElement;
		}

		public XTextContentLinkFieldElement ConvertToXTextContentLinkFieldElement(object sourceValue)
		{
			return sourceValue as XTextContentLinkFieldElement;
		}

		public XTextControlHostElement ConvertToXTextControlHostElement(object sourceValue)
		{
			return sourceValue as XTextControlHostElement;
		}

		public XTextDocument ConvertToXTextDocument(object sourceValue)
		{
			return sourceValue as XTextDocument;
		}

		public XTextDocumentList ConvertToXTextDocumentList(object sourceValue)
		{
			return sourceValue as XTextDocumentList;
		}

		public XTextElementList ConvertToXTextElementList(object sourceValue)
		{
			return sourceValue as XTextElementList;
		}

		public XTextFileBlockElement ConvertToXTextFileBlockElement(object sourceValue)
		{
			return sourceValue as XTextFileBlockElement;
		}

		public XTextHorizontalLineElement ConvertToXTextHorizontalLineElement(object sourceValue)
		{
			return sourceValue as XTextHorizontalLineElement;
		}

		public XTextImageElement ConvertToXTextImageElement(object sourceValue)
		{
			return sourceValue as XTextImageElement;
		}

		public XTextInputFieldElement ConvertToXTextInputFieldElement(object sourceValue)
		{
			return sourceValue as XTextInputFieldElement;
		}

		public XTextLabelElement ConvertToXTextLabelElement(object sourceValue)
		{
			return sourceValue as XTextLabelElement;
		}

		public XTextLineBreakElement ConvertToXTextLineBreakElement(object sourceValue)
		{
			return sourceValue as XTextLineBreakElement;
		}

		public XTextPageBreakElement ConvertToXTextPageBreakElement(object sourceValue)
		{
			return sourceValue as XTextPageBreakElement;
		}

		public XTextPageInfoElement ConvertToXTextPageInfoElement(object sourceValue)
		{
			return sourceValue as XTextPageInfoElement;
		}

		public XTextParagraphFlagElement ConvertToXTextParagraphFlagElement(object sourceValue)
		{
			return sourceValue as XTextParagraphFlagElement;
		}

		public XTextSectionElement ConvertToXTextSectionElement(object sourceValue)
		{
			return sourceValue as XTextSectionElement;
		}

		public XTextSignElement ConvertToXTextSignElement(object sourceValue)
		{
			return sourceValue as XTextSignElement;
		}

		public XTextTableCellElement ConvertToXTextTableCellElement(object sourceValue)
		{
			return sourceValue as XTextTableCellElement;
		}

		public XTextTableColumnElement ConvertToXTextTableColumnElement(object sourceValue)
		{
			return sourceValue as XTextTableColumnElement;
		}

		public XTextTableElement ConvertToXTextTableElement(object sourceValue)
		{
			return sourceValue as XTextTableElement;
		}

		public XTextTableRowElement ConvertToXTextTableRowElement(object sourceValue)
		{
			return sourceValue as XTextTableRowElement;
		}

		public ElementCancelEventArgs ConvertToElementCancelEventArgs(object sourceValue)
		{
			return sourceValue as ElementCancelEventArgs;
		}

		public ElementEventArgs ConvertToElementEventArgs(object sourceValue)
		{
			return sourceValue as ElementEventArgs;
		}

		public ElementEventTemplate ConvertToElementEventTemplate(object sourceValue)
		{
			return sourceValue as ElementEventTemplate;
		}

		public ElementExpressionEventArgs ConvertToElementExpressionEventArgs(object sourceValue)
		{
			return sourceValue as ElementExpressionEventArgs;
		}

		public ElementKeyEventArgs ConvertToElementKeyEventArgs(object sourceValue)
		{
			return sourceValue as ElementKeyEventArgs;
		}

		public ElementLoadEventArgs ConvertToElementLoadEventArgs(object sourceValue)
		{
			return sourceValue as ElementLoadEventArgs;
		}

		public ElementMouseEventArgs ConvertToElementMouseEventArgs(object sourceValue)
		{
			return sourceValue as ElementMouseEventArgs;
		}

		public ElementPaintEventArgs ConvertToElementPaintEventArgs(object sourceValue)
		{
			return sourceValue as ElementPaintEventArgs;
		}

		public ElementQueryStateEventArgs ConvertToElementQueryStateEventArgs(object sourceValue)
		{
			return sourceValue as ElementQueryStateEventArgs;
		}

		public ElementValidatingEventArgs ConvertToElementValidatingEventArgs(object sourceValue)
		{
			return sourceValue as ElementValidatingEventArgs;
		}

		public EventExpressionInfo ConvertToEventExpressionInfo(object sourceValue)
		{
			return sourceValue as EventExpressionInfo;
		}

		public EventExpressionInfoList ConvertToEventExpressionInfoList(object sourceValue)
		{
			return sourceValue as EventExpressionInfoList;
		}

		public DataSourceDescriptor ConvertToDataSourceDescriptor(object sourceValue)
		{
			return sourceValue as DataSourceDescriptor;
		}

		public DataSourceDescriptorList ConvertToDataSourceDescriptorList(object sourceValue)
		{
			return sourceValue as DataSourceDescriptorList;
		}

		public XTextMedicalExpressionFieldElement ConvertToXTextMedicalExpressionFieldElement(object sourceValue)
		{
			return sourceValue as XTextMedicalExpressionFieldElement;
		}

		public SectionCourseRecord ConvertToSectionCourseRecord(object sourceValue)
		{
			return sourceValue as SectionCourseRecord;
		}

		public SectionCourseRecordDocumentController ConvertToSectionCourseRecordDocumentController(object sourceValue)
		{
			return sourceValue as SectionCourseRecordDocumentController;
		}

		public FilterValueEventArgs ConvertToFilterValueEventArgs(object sourceValue)
		{
			return sourceValue as FilterValueEventArgs;
		}

		public GridLineSettings ConvertToGridLineSettings(object sourceValue)
		{
			return sourceValue as GridLineSettings;
		}

		public InsertObjectEventArgs ConvertToInsertObjectEventArgs(object sourceValue)
		{
			return sourceValue as InsertObjectEventArgs;
		}

		public QueryUserHistoryDisplayTextEventArgs ConvertToQueryUserHistoryDisplayTextEventArgs(object sourceValue)
		{
			return sourceValue as QueryUserHistoryDisplayTextEventArgs;
		}

		public TrackVisibleConfig ConvertToTrackVisibleConfig(object sourceValue)
		{
			return sourceValue as TrackVisibleConfig;
		}

		public WriterEventArgs ConvertToWriterEventArgs(object sourceValue)
		{
			return sourceValue as WriterEventArgs;
		}

		public WriterMouseEventArgs ConvertToWriterMouseEventArgs(object sourceValue)
		{
			return sourceValue as WriterMouseEventArgs;
		}
	}
}
