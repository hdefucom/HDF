using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxWriterControlForPB 事件的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("0AE0E8E8-3A75-4A4C-9F0D-077312A860BA")]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IAxWriterControlForPBComEvents
	{
		/// <summary> AfterExecuteCommand 事件</summary>
		[DispId(12340)]
		void AfterExecuteCommand([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCommandEventArgs e);

		/// <summary> AfterLoadDocumentDom 事件</summary>
		[DispId(12498)]
		void AfterLoadDocumentDom([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> BeforeExecuteCommand 事件</summary>
		[DispId(12499)]
		void BeforeExecuteCommand([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCommandEventArgs e);

		/// <summary> BeforeRecordDeleted 事件</summary>
		[DispId(12689)]
		void BeforeRecordDeleted([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCancelEventArgs e);

		/// <summary> ComCustomCommand 事件</summary>
		[DispId(12500)]
		void ComCustomCommand([MarshalAs(UnmanagedType.AsAny)] object sender, CustomCommandEventArgs e);

		/// <summary> ComEventDocumentContentChanged 事件</summary>
		[DispId(12341)]
		void ComEventDocumentContentChanged();

		/// <summary> ComEventDocumentLoad 事件</summary>
		[DispId(12342)]
		void ComEventDocumentLoad();

		/// <summary> ComEventSelectionChanged 事件</summary>
		[DispId(12343)]
		void ComEventSelectionChanged();

		/// <summary> ComEventStatusTextChanged 事件</summary>
		[DispId(12344)]
		void ComEventStatusTextChanged();

		/// <summary> CommandError 事件</summary>
		[DispId(12345)]
		void CommandError([MarshalAs(UnmanagedType.AsAny)] object sender, CommandErrorEventArgs e);

		/// <summary> CurrentRecordChanged 事件</summary>
		[DispId(12690)]
		void CurrentRecordChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> DocumentContentChanged 事件</summary>
		[DispId(12346)]
		void DocumentContentChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> DocumentLoad 事件</summary>
		[DispId(12347)]
		void DocumentLoad([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> DocumentNavigateContentChanged 事件</summary>
		[DispId(12348)]
		void DocumentNavigateContentChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventAfterCollapseSection 事件</summary>
		[DispId(12935)]
		void EventAfterCollapseSection([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSectionElementEventArgs e);

		/// <summary> EventAfterExpandSection 事件</summary>
		[DispId(12936)]
		void EventAfterExpandSection([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSectionElementEventArgs e);

		/// <summary> EventAfterFieldContentEdit 事件</summary>
		[DispId(12886)]
		void EventAfterFieldContentEdit([MarshalAs(UnmanagedType.AsAny)] object sender, WriterAfterFieldContentEditEventArgs e);

		/// <summary> EventAfterLoadRawDOM 事件</summary>
		[DispId(12778)]
		void EventAfterLoadRawDOM([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventBeforeCollapseSection 事件</summary>
		[DispId(12937)]
		void EventBeforeCollapseSection([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSectionElementCancelEventArgs e);

		/// <summary> EventBeforeExpandSection 事件</summary>
		[DispId(12938)]
		void EventBeforeExpandSection([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSectionElementCancelEventArgs e);

		/// <summary> EventBeforeFieldContentEdit 事件</summary>
		[DispId(12887)]
		void EventBeforeFieldContentEdit([MarshalAs(UnmanagedType.AsAny)] object sender, WriterBeforeFieldContentEditEventArgs e);

		/// <summary> EventBeforePlayMedia 事件</summary>
		[DispId(12833)]
		void EventBeforePlayMedia([MarshalAs(UnmanagedType.AsAny)] object sender, WriterBeforePlayMediaEventArgs e);

		/// <summary> EventBeforeShowDialog 事件</summary>
		[DispId(12501)]
		void EventBeforeShowDialog([MarshalAs(UnmanagedType.AsAny)] object sender, WriterShowDialogEventArgs e);

		/// <summary> EventBeforeUIKeyboardInputString 事件</summary>
		[DispId(12811)]
		void EventBeforeUIKeyboardInputString([MarshalAs(UnmanagedType.AsAny)] object sender, WriterBeforeUIKeyboardInputStringEventArgs e);

		/// <summary> EventBeginPrint 事件</summary>
		[DispId(12911)]
		void EventBeginPrint([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintEventEventArgs e);

		/// <summary> EventButtonClick 事件</summary>
		[DispId(12744)]
		void EventButtonClick([MarshalAs(UnmanagedType.AsAny)] object sender, WriterButtonClickEventArgs e);

		/// <summary> EventCanInsertObject 事件</summary>
		[DispId(12349)]
		void EventCanInsertObject([MarshalAs(UnmanagedType.AsAny)] object sender, CanInsertObjectEventArgs e);

		/// <summary> EventCollectProtectedElements 事件</summary>
		[DispId(12710)]
		void EventCollectProtectedElements([MarshalAs(UnmanagedType.AsAny)] object sender, CollectProtectedElementsEventArgs e);

		/// <summary> EventContentChanged 事件</summary>
		[DispId(12523)]
		void EventContentChanged([MarshalAs(UnmanagedType.AsAny)] object sender, ContentChangedEventArgs e);

		/// <summary> EventContentChanging 事件</summary>
		[DispId(12524)]
		void EventContentChanging([MarshalAs(UnmanagedType.AsAny)] object sender, ContentChangingEventArgs e);

		/// <summary> EventCreateElementsByKBEntry 事件</summary>
		[DispId(12350)]
		void EventCreateElementsByKBEntry([MarshalAs(UnmanagedType.AsAny)] object sender, CreateElementsByKBEntryEventArgs e);

		/// <summary> EventCreateInstance 事件</summary>
		[DispId(12487)]
		void EventCreateInstance([MarshalAs(UnmanagedType.AsAny)] object sender, CreateInstanceEventArgs e);

		/// <summary> EventDrawShapeContent 事件</summary>
		[DispId(12801)]
		void EventDrawShapeContent([MarshalAs(UnmanagedType.AsAny)] object sender, WriterDrawShapeContentEventArgs e);

		/// <summary> EventEditElementValue 事件</summary>
		[DispId(12751)]
		void EventEditElementValue([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEditElementValueEventArgs e);

		/// <summary> EventElementCheckedChanged 事件</summary>
		[DispId(12818)]
		void EventElementCheckedChanged(string elementID, string elementName, string elementValue, XTextElement element);

		/// <summary> EventElementGotFocus 事件</summary>
		[DispId(12951)]
		void EventElementGotFocus([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> EventElementLostFocus 事件</summary>
		[DispId(12952)]
		void EventElementLostFocus([MarshalAs(UnmanagedType.AsAny)] object sender, ElementEventArgs e);

		/// <summary> EventElementMouseClick 事件</summary>
		[DispId(12939)]
		void EventElementMouseClick([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> EventElementMouseDblClick 事件</summary>
		[DispId(12940)]
		void EventElementMouseDblClick([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> EventElementMouseDown 事件</summary>
		[DispId(12941)]
		void EventElementMouseDown([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> EventElementMouseMove 事件</summary>
		[DispId(12942)]
		void EventElementMouseMove([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> EventElementMouseUp 事件</summary>
		[DispId(12943)]
		void EventElementMouseUp([MarshalAs(UnmanagedType.AsAny)] object sender, ElementMouseEventArgs e);

		/// <summary> EventElementValidating 事件</summary>
		[DispId(12865)]
		void EventElementValidating([MarshalAs(UnmanagedType.AsAny)] object sender, ElementValidatingEventArgs e);

		/// <summary> EventEndPrint 事件</summary>
		[DispId(12912)]
		void EventEndPrint([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintEventEventArgs e);

		/// <summary> EventEndTabStop 事件</summary>
		[DispId(12696)]
		void EventEndTabStop([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventExpressionFunction 事件</summary>
		[DispId(12758)]
		void EventExpressionFunction([MarshalAs(UnmanagedType.AsAny)] object sender, WriterExpressionFunctionEventArgs e);

		/// <summary> EventFormatListItems 事件</summary>
		[DispId(12351)]
		void EventFormatListItems([MarshalAs(UnmanagedType.AsAny)] object sender, FormatListItemsEventArgs e);

		/// <summary> EventGetAdornText 事件</summary>
		[DispId(12752)]
		void EventGetAdornText([MarshalAs(UnmanagedType.AsAny)] object sender, WriterGetAdornTextEventArgs e);

		/// <summary> EventGetLinkListItems 事件</summary>
		[DispId(12726)]
		void EventGetLinkListItems([MarshalAs(UnmanagedType.AsAny)] object sender, GetLinkListItemsEventArgs e);

		/// <summary> EventInsertObject 事件</summary>
		[DispId(12352)]
		void EventInsertObject([MarshalAs(UnmanagedType.AsAny)] object sender, InsertObjectEventArgs e);

		/// <summary> EventKeyDownExt 事件</summary>
		[DispId(12917)]
		void EventKeyDownExt([MarshalAs(UnmanagedType.AsAny)] object eventSender, int keyCode, int modifiers);

		/// <summary> EventKeyPressExt 事件</summary>
		[DispId(12918)]
		void EventKeyPressExt([MarshalAs(UnmanagedType.AsAny)] object eventSender, int keyCode);

		/// <summary> EventKeyUpExt 事件</summary>
		[DispId(12919)]
		void EventKeyUpExt([MarshalAs(UnmanagedType.AsAny)] object eventSender, int keyCode, int modifiers);

		/// <summary> EventLinkClick 事件</summary>
		[DispId(12740)]
		void EventLinkClick([MarshalAs(UnmanagedType.AsAny)] object sender, WriterLinkEventArgs e);

		/// <summary> EventMouseClickExt 事件</summary>
		[DispId(12510)]
		void EventMouseClickExt([MarshalAs(UnmanagedType.AsAny)] object sender, WriterMouseEventArgs e);

		/// <summary> EventMouseDblClickExt 事件</summary>
		[DispId(12511)]
		void EventMouseDblClickExt([MarshalAs(UnmanagedType.AsAny)] object sender, WriterMouseEventArgs e);

		/// <summary> EventMouseDownExt 事件</summary>
		[DispId(12512)]
		void EventMouseDownExt([MarshalAs(UnmanagedType.AsAny)] object sender, WriterMouseEventArgs e);

		/// <summary> EventMouseMoveExt 事件</summary>
		[DispId(12513)]
		void EventMouseMoveExt([MarshalAs(UnmanagedType.AsAny)] object sender, WriterMouseEventArgs e);

		/// <summary> EventMouseUpExt 事件</summary>
		[DispId(12514)]
		void EventMouseUpExt([MarshalAs(UnmanagedType.AsAny)] object sender, WriterMouseEventArgs e);

		/// <summary> EventOutlineTreeChanged 事件</summary>
		[DispId(12824)]
		void EventOutlineTreeChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventParseSelectedItems 事件</summary>
		[DispId(12353)]
		void EventParseSelectedItems([MarshalAs(UnmanagedType.AsAny)] object sender, ParseSelectedItemsEventArgs e);

		/// <summary> EventPrintPage 事件</summary>
		[DispId(12913)]
		void EventPrintPage([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintPageEventEventArgs e);

		/// <summary> EventPrintQueryPageSettings 事件</summary>
		[DispId(12914)]
		void EventPrintQueryPageSettings([MarshalAs(UnmanagedType.AsAny)] object sender, WriterPrintQueryPageSettingsEventArgs e);

		/// <summary> EventPromptProtectedContent 事件</summary>
		[DispId(12701)]
		void EventPromptProtectedContent([MarshalAs(UnmanagedType.AsAny)] object sender, PromptProtectedContentEventArgs e);

		/// <summary> EventQueryAssistInputItems 事件</summary>
		[DispId(12814)]
		void EventQueryAssistInputItems([MarshalAs(UnmanagedType.AsAny)] object sender, WriterQueryAssistInputItemsEventArgs e);

		/// <summary> EventReadFileContent 事件</summary>
		[DispId(12749)]
		void EventReadFileContent([MarshalAs(UnmanagedType.AsAny)] object sender, WriterReadFileContentEventArgs e);

		/// <summary> EventReadonlyChanged 事件</summary>
		[DispId(12759)]
		void EventReadonlyChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventRefreshDomTree 事件</summary>
		[DispId(12976)]
		void EventRefreshDomTree([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventReportError 事件</summary>
		[DispId(12779)]
		void EventReportError([MarshalAs(UnmanagedType.AsAny)] object sender, WriterReportErrorEventArgs e);

		/// <summary> EventSaveFileContent 事件</summary>
		[DispId(12750)]
		void EventSaveFileContent([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSaveFileContentEventArgs e);

		/// <summary> EventSaveFileContentForAutoSave 事件</summary>
		[DispId(12882)]
		void EventSaveFileContentForAutoSave([MarshalAs(UnmanagedType.AsAny)] object sender, WriterSaveFileContentEventArgs e);

		/// <summary> EventTableAddNewRowWhenPressTabKey 事件</summary>
		[DispId(12702)]
		void EventTableAddNewRowWhenPressTabKey([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> EventTableRowHeightChanged 事件</summary>
		[DispId(12804)]
		void EventTableRowHeightChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterTableRowHeightChangedEventArgs e);

		/// <summary> EventTableRowHeightChanging 事件</summary>
		[DispId(12805)]
		void EventTableRowHeightChanging([MarshalAs(UnmanagedType.AsAny)] object sender, WriterTableRowHeightChangingEventArgs e);

		/// <summary> EventUIStartEditContent 事件</summary>
		[DispId(12492)]
		void EventUIStartEditContent([MarshalAs(UnmanagedType.AsAny)] object sender, WriterStartEditEventArgs e);

		/// <summary> EventUnknowCommand 事件</summary>
		[DispId(12354)]
		void EventUnknowCommand([MarshalAs(UnmanagedType.AsAny)] object sender, WriterCommandEventArgs e);

		/// <summary> EventZoomChanged 事件</summary>
		[DispId(12705)]
		void EventZoomChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> FilterValue 事件</summary>
		[DispId(12355)]
		void FilterValue([MarshalAs(UnmanagedType.AsAny)] object sender, FilterValueEventArgs e);

		/// <summary> HoverElementChanged 事件</summary>
		[DispId(12356)]
		void HoverElementChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> QueryKBEntries 事件</summary>
		[DispId(12360)]
		void QueryKBEntries([MarshalAs(UnmanagedType.AsAny)] object sender, QueryKBEntriesEventArgs e);

		/// <summary> QueryListItems 事件</summary>
		[DispId(12361)]
		void QueryListItems([MarshalAs(UnmanagedType.AsAny)] object sender, QueryListItemsEventArgs e);

		/// <summary> QueryUserHistoryDisplayText 事件</summary>
		[DispId(12362)]
		void QueryUserHistoryDisplayText([MarshalAs(UnmanagedType.AsAny)] object sender, QueryUserHistoryDisplayTextEventArgs e);

		/// <summary> ScriptError 事件</summary>
		[DispId(12363)]
		void ScriptError([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> SelectionChanged 事件</summary>
		[DispId(12364)]
		void SelectionChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> SelectionChanging 事件</summary>
		[DispId(12365)]
		void SelectionChanging([MarshalAs(UnmanagedType.AsAny)] object sender, SelectionChangingEventArgs e);

		/// <summary> StatusTextChanged 事件</summary>
		[DispId(12366)]
		void StatusTextChanged([MarshalAs(UnmanagedType.AsAny)] object sender, StatusTextChangedEventArgs e);

		/// <summary> UserTrackListChanged 事件</summary>
		[DispId(12367)]
		void UserTrackListChanged([MarshalAs(UnmanagedType.AsAny)] object sender, WriterEventArgs e);

		/// <summary> VOIDCOMDocumentContentChanged 事件</summary>
		[DispId(12781)]
		void VOIDCOMDocumentContentChanged();

		/// <summary> VOIDCOMDocumentLoad 事件</summary>
		[DispId(12782)]
		void VOIDCOMDocumentLoad();

		/// <summary> VOIDCOMSelectionChanged 事件</summary>
		[DispId(12368)]
		void VOIDCOMSelectionChanged();
	}
}
