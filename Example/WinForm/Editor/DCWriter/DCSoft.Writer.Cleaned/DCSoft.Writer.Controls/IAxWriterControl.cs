using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Expression;
using DCSoft.Writer.Extension;
using DCSoft.Writer.Extension.Data;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.Security;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DCSoft.Writer.Controls
{
	/// <summary>AxWriterControl 的COM接口</summary>
	[Browsable(false)]
	[Guid("FCA69A82-5224-4AF5-BA57-C3E41F61806E")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IAxWriterControl
	{
		/// <summary>属性AcceptDataFormats</summary>
		[DispId(12478)]
		WriterDataFormats AcceptDataFormats
		{
			get;
			set;
		}

		/// <summary>属性AdditionPageTitle</summary>
		[DispId(12741)]
		string AdditionPageTitle
		{
			get;
			set;
		}

		/// <summary>属性AllowDragContent</summary>
		[DispId(12411)]
		bool AllowDragContent
		{
			get;
			set;
		}

		/// <summary>属性AllowDrop</summary>
		[DispId(12412)]
		bool AllowDrop
		{
			get;
			set;
		}

		/// <summary>属性AppHost</summary>
		[DispId(12413)]
		WriterAppHost AppHost
		{
			get;
			set;
		}

		/// <summary>属性AutoDisposeContextMenu</summary>
		[DispId(12977)]
		bool AutoDisposeContextMenu
		{
			get;
			set;
		}

		/// <summary>属性AutoDisposeDocument</summary>
		[DispId(12978)]
		bool AutoDisposeDocument
		{
			get;
			set;
		}

		/// <summary>属性AutoUserLogin</summary>
		[DispId(12414)]
		bool AutoUserLogin
		{
			get;
			set;
		}

		/// <summary>属性AxContentBase64String</summary>
		[DispId(12755)]
		string AxContentBase64String
		{
			get;
			set;
		}

		/// <summary>属性BackColor</summary>
		[DispId(-501)]
		Color BackColor
		{
			get;
			set;
		}

		/// <summary>属性BackColorString</summary>
		[DispId(12841)]
		string BackColorString
		{
			get;
			set;
		}

		/// <summary>属性BackgroundMode</summary>
		[DispId(12717)]
		bool BackgroundMode
		{
			get;
			set;
		}

		/// <summary>属性BorderStyle</summary>
		[DispId(12415)]
		BorderStyle BorderStyle
		{
			get;
			set;
		}

		/// <summary>属性CodeBaseForUpdateAssembly</summary>
		[DispId(12754)]
		string CodeBaseForUpdateAssembly
		{
			get;
			set;
		}

		/// <summary>属性ComFocused</summary>
		[DispId(12697)]
		bool ComFocused
		{
			get;
		}

		/// <summary>属性ComHtmlText</summary>
		[DispId(12969)]
		string ComHtmlText
		{
			get;
		}

		/// <summary>属性CommandStateNeedRefreshFlag</summary>
		[DispId(12815)]
		bool CommandStateNeedRefreshFlag
		{
			get;
			set;
		}

		/// <summary>属性CommentVisibility</summary>
		[DispId(12715)]
		FunctionControlVisibility CommentVisibility
		{
			get;
			set;
		}

		/// <summary>属性CourseRecordController</summary>
		[DispId(12692)]
		SectionCourseRecordDocumentController CourseRecordController
		{
			get;
		}

		/// <summary>属性CreationDataFormats</summary>
		[DispId(12479)]
		WriterDataFormats CreationDataFormats
		{
			get;
			set;
		}

		/// <summary>属性CurrentBold</summary>
		[DispId(12766)]
		bool CurrentBold
		{
			get;
		}

		/// <summary>属性CurrentColumnIndex</summary>
		[DispId(12416)]
		int CurrentColumnIndex
		{
			get;
		}

		/// <summary>属性CurrentComment</summary>
		[DispId(12855)]
		DocumentComment CurrentComment
		{
			get;
		}

		/// <summary>属性CurrentContentPartyStyle</summary>
		[DispId(12417)]
		PageContentPartyStyle CurrentContentPartyStyle
		{
			get;
			set;
		}

		/// <summary>属性CurrentElement</summary>
		[DispId(12418)]
		XTextElement CurrentElement
		{
			get;
		}

		/// <summary>属性CurrentFontName</summary>
		[DispId(12767)]
		string CurrentFontName
		{
			get;
		}

		/// <summary>属性CurrentFontSize</summary>
		[DispId(12768)]
		float CurrentFontSize
		{
			get;
		}

		/// <summary>属性CurrentInputField</summary>
		[DispId(12480)]
		XTextInputFieldElement CurrentInputField
		{
			get;
		}

		/// <summary>属性CurrentItalic</summary>
		[DispId(12769)]
		bool CurrentItalic
		{
			get;
		}

		/// <summary>属性CurrentLine</summary>
		[DispId(12419)]
		XTextLine CurrentLine
		{
			get;
		}

		/// <summary>属性CurrentLineIndex</summary>
		[DispId(12420)]
		int CurrentLineIndex
		{
			get;
		}

		/// <summary>属性CurrentLineIndexInPage</summary>
		[DispId(12421)]
		int CurrentLineIndexInPage
		{
			get;
		}

		/// <summary>属性CurrentLineOwnerPageIndex</summary>
		[DispId(12831)]
		int CurrentLineOwnerPageIndex
		{
			get;
		}

		/// <summary>属性CurrentLinePrivateIndexInPage</summary>
		[DispId(12832)]
		int CurrentLinePrivateIndexInPage
		{
			get;
		}

		/// <summary>属性CurrentNavigateNode</summary>
		[DispId(12756)]
		NavigateNode CurrentNavigateNode
		{
			get;
		}

		/// <summary>属性CurrentOutlineNode</summary>
		[DispId(12836)]
		DocumentOutlineNode CurrentOutlineNode
		{
			get;
		}

		/// <summary>属性CurrentPage</summary>
		[DispId(12422)]
		PrintPage CurrentPage
		{
			get;
			set;
		}

		/// <summary>属性CurrentPageBorderColor</summary>
		[DispId(12843)]
		Color CurrentPageBorderColor
		{
			get;
			set;
		}

		/// <summary>属性CurrentPageBorderColorString</summary>
		[DispId(12844)]
		string CurrentPageBorderColorString
		{
			get;
			set;
		}

		/// <summary>属性CurrentPageIndex</summary>
		[DispId(12423)]
		int CurrentPageIndex
		{
			get;
			set;
		}

		/// <summary>属性CurrentParagraphAlign</summary>
		[DispId(12770)]
		DocumentContentAlignment CurrentParagraphAlign
		{
			get;
		}

		/// <summary>属性CurrentParagraphEOF</summary>
		[DispId(12926)]
		XTextParagraphFlagElement CurrentParagraphEOF
		{
			get;
		}

		/// <summary>属性CurrentSection</summary>
		[DispId(12481)]
		XTextSectionElement CurrentSection
		{
			get;
		}

		/// <summary>属性CurrentStyle</summary>
		[DispId(12424)]
		DocumentContentStyle CurrentStyle
		{
			get;
		}

		/// <summary>属性CurrentSubDocument</summary>
		[DispId(12872)]
		XTextSubDocumentElement CurrentSubDocument
		{
			get;
		}

		/// <summary>属性CurrentSubscript</summary>
		[DispId(12771)]
		bool CurrentSubscript
		{
			get;
		}

		/// <summary>属性CurrentSuperscript</summary>
		[DispId(12772)]
		bool CurrentSuperscript
		{
			get;
		}

		/// <summary>属性CurrentTable</summary>
		[DispId(12482)]
		XTextTableElement CurrentTable
		{
			get;
		}

		/// <summary>属性CurrentTableCell</summary>
		[DispId(12483)]
		XTextTableCellElement CurrentTableCell
		{
			get;
		}

		/// <summary>属性CurrentTableRow</summary>
		[DispId(12484)]
		XTextTableRowElement CurrentTableRow
		{
			get;
		}

		/// <summary>属性CurrentUnderline</summary>
		[DispId(12773)]
		bool CurrentUnderline
		{
			get;
		}

		/// <summary>属性CurrentUser</summary>
		[DispId(12927)]
		UserHistoryInfo CurrentUser
		{
			get;
		}

		/// <summary>属性DataObjectRange</summary>
		[DispId(12698)]
		WriterDataObjectRange DataObjectRange
		{
			get;
			set;
		}

		/// <summary>属性DialogTitlePrefix</summary>
		[DispId(12699)]
		string DialogTitlePrefix
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(12425)]
		XTextDocument Document
		{
			get;
			set;
		}

		/// <summary>属性DocumentBaseUrl</summary>
		[DispId(12426)]
		string DocumentBaseUrl
		{
			get;
			set;
		}

		/// <summary>属性DocumentBehaviorOptions</summary>
		[DispId(12979)]
		DocumentBehaviorOptions DocumentBehaviorOptions
		{
			get;
		}

		/// <summary>属性DocumentContentVersion</summary>
		[DispId(12427)]
		int DocumentContentVersion
		{
			get;
		}

		/// <summary>属性DocumentEditOptions</summary>
		[DispId(12980)]
		DocumentEditOptions DocumentEditOptions
		{
			get;
		}

		/// <summary>属性DocumentOptions</summary>
		[DispId(12429)]
		DocumentOptions DocumentOptions
		{
			get;
			set;
		}

		/// <summary>属性DocumentOptionsXML</summary>
		[DispId(12800)]
		string DocumentOptionsXML
		{
			get;
			set;
		}

		/// <summary>属性DocumentSecurityOptions</summary>
		[DispId(12981)]
		DocumentSecurityOptions DocumentSecurityOptions
		{
			get;
		}

		/// <summary>属性DocumentViewOptions</summary>
		[DispId(12982)]
		DocumentViewOptions DocumentViewOptions
		{
			get;
		}

		/// <summary>属性DomImageList</summary>
		[DispId(12709)]
		DCStdImageList DomImageList
		{
			get;
		}

		/// <summary>属性DoubleClickToEditComment</summary>
		[DispId(12430)]
		bool DoubleClickToEditComment
		{
			get;
			set;
		}

		/// <summary>属性EnabledControlEvent</summary>
		[DispId(12810)]
		bool EnabledControlEvent
		{
			get;
			set;
		}

		/// <summary>属性EnabledElementEvent</summary>
		[DispId(12431)]
		bool EnabledElementEvent
		{
			get;
			set;
		}

		/// <summary>属性EnableJumpPrint</summary>
		[DispId(12432)]
		bool EnableJumpPrint
		{
			get;
			set;
		}

		/// <summary>属性EnableUIEventStartEditContent</summary>
		[DispId(12700)]
		bool EnableUIEventStartEditContent
		{
			get;
			set;
		}

		/// <summary>属性EndPageIndex</summary>
		[DispId(12521)]
		int EndPageIndex
		{
			get;
			set;
		}

		/// <summary>属性EventTemplates</summary>
		[DispId(12508)]
		ElementEventTemplateList EventTemplates
		{
			get;
			set;
		}

		/// <summary>属性ExcludeKeywords</summary>
		[DispId(12433)]
		string ExcludeKeywords
		{
			get;
			set;
		}

		/// <summary>属性ExtViewMode</summary>
		[DispId(12928)]
		WriterControlExtViewMode ExtViewMode
		{
			get;
			set;
		}

		/// <summary>属性FormValuesArray</summary>
		[DispId(12434)]
		string[] FormValuesArray
		{
			get;
		}

		/// <summary>属性FormValuesString</summary>
		[DispId(12509)]
		string FormValuesString
		{
			get;
		}

		/// <summary>属性FormValuesXml</summary>
		[DispId(12873)]
		string FormValuesXml
		{
			get;
		}

		/// <summary>属性FormView</summary>
		[DispId(12435)]
		FormViewMode FormView
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_Cell</summary>
		[DispId(12436)]
		ElementEventTemplate GlobalEventTemplate_Cell
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_CheckBox</summary>
		[DispId(12437)]
		ElementEventTemplate GlobalEventTemplate_CheckBox
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_Element</summary>
		[DispId(12438)]
		ElementEventTemplate GlobalEventTemplate_Element
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_Field</summary>
		[DispId(12439)]
		ElementEventTemplate GlobalEventTemplate_Field
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_Image</summary>
		[DispId(12440)]
		ElementEventTemplate GlobalEventTemplate_Image
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_Table</summary>
		[DispId(12441)]
		ElementEventTemplate GlobalEventTemplate_Table
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplate_TableRow</summary>
		[DispId(12442)]
		ElementEventTemplate GlobalEventTemplate_TableRow
		{
			get;
			set;
		}

		/// <summary>属性GlobalEventTemplates</summary>
		[DispId(12443)]
		ElementEventTemlateMap GlobalEventTemplates
		{
			get;
			set;
		}

		/// <summary>属性HeaderFooterFlagVisible</summary>
		[DispId(12444)]
		HeaderFooterFlagVisible HeaderFooterFlagVisible
		{
			get;
			set;
		}

		/// <summary>属性HeaderFooterReadonly</summary>
		[DispId(12445)]
		bool HeaderFooterReadonly
		{
			get;
			set;
		}

		/// <summary>属性HoverElement</summary>
		[DispId(12446)]
		XTextElement HoverElement
		{
			get;
		}

		/// <summary>属性Images</summary>
		[DispId(12774)]
		XTextElementList Images
		{
			get;
		}

		/// <summary>属性InputFields</summary>
		[DispId(12827)]
		XTextElementList InputFields
		{
			get;
		}

		/// <summary>属性InstanceFactory</summary>
		[DispId(12477)]
		InstanceFactoryForCOM InstanceFactory
		{
			get;
		}

		/// <summary>属性IsAdministrator</summary>
		[DispId(12447)]
		bool IsAdministrator
		{
			get;
			set;
		}

		/// <summary>属性JumpPrint</summary>
		[DispId(12448)]
		JumpPrintInfo JumpPrint
		{
			get;
			set;
		}

		/// <summary>属性JumpPrintEndPosition</summary>
		[DispId(12449)]
		float JumpPrintEndPosition
		{
			get;
			set;
		}

		/// <summary>属性JumpPrintPosition</summary>
		[DispId(12450)]
		float JumpPrintPosition
		{
			get;
			set;
		}

		/// <summary>属性KBLibraryUrl</summary>
		[DispId(12777)]
		string KBLibraryUrl
		{
			get;
			set;
		}

		/// <summary>属性LastAlertInfos</summary>
		[DispId(12848)]
		SystemAlertInfoList LastAlertInfos
		{
			get;
		}

		/// <summary>属性LastEventMessage</summary>
		[DispId(12854)]
		WriterControlEventMessage LastEventMessage
		{
			get;
		}

		/// <summary>属性LastPrintPosition</summary>
		[DispId(12725)]
		int LastPrintPosition
		{
			get;
			set;
		}

		/// <summary>属性LastPrintResult</summary>
		[DispId(12724)]
		PrintResult LastPrintResult
		{
			get;
			set;
		}

		/// <summary>属性LicenceDisplayMode</summary>
		[DispId(12874)]
		DCLicenceDisplayMode LicenceDisplayMode
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(12451)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性ModifiedInputFields</summary>
		[DispId(12828)]
		XTextElementList ModifiedInputFields
		{
			get;
		}

		/// <summary>属性MoveFocusHotKey</summary>
		[DispId(12452)]
		MoveFocusHotKeys MoveFocusHotKey
		{
			get;
			set;
		}

		/// <summary>属性Navigator</summary>
		[DispId(12485)]
		DocumentNavigator Navigator
		{
			get;
		}

		/// <summary>属性OutlineNodes</summary>
		[DispId(12837)]
		DocumentOutlineNodeList OutlineNodes
		{
			get;
		}

		/// <summary>属性PageBackColor</summary>
		[DispId(12453)]
		Color PageBackColor
		{
			get;
			set;
		}

		/// <summary>属性PageBackColorString</summary>
		[DispId(12842)]
		string PageBackColorString
		{
			get;
			set;
		}

		/// <summary>属性PageBorderColor</summary>
		[DispId(12454)]
		Color PageBorderColor
		{
			get;
			set;
		}

		/// <summary>属性PageBorderColorString</summary>
		[DispId(12845)]
		string PageBorderColorString
		{
			get;
			set;
		}

		/// <summary>属性PageCount</summary>
		[DispId(12455)]
		int PageCount
		{
			get;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(12456)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性Pages</summary>
		[DispId(12457)]
		PrintPageCollection Pages
		{
			get;
			set;
		}

		/// <summary>属性PageSpacing</summary>
		[DispId(12458)]
		int PageSpacing
		{
			get;
			set;
		}

		/// <summary>属性PageTitlePosition</summary>
		[DispId(12459)]
		PageTitlePosition PageTitlePosition
		{
			get;
			set;
		}

		/// <summary>属性PositionInfoText</summary>
		[DispId(12460)]
		string PositionInfoText
		{
			get;
		}

		/// <summary>属性ProductVersion</summary>
		[DispId(12461)]
		string ProductVersion
		{
			get;
		}

		/// <summary>属性Readonly</summary>
		[DispId(12462)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性RegisterCode</summary>
		[DispId(12463)]
		string RegisterCode
		{
			get;
			set;
		}

		/// <summary>属性RegisterCodeFileUrl</summary>
		[DispId(12775)]
		string RegisterCodeFileUrl
		{
			get;
			set;
		}

		/// <summary>属性RTFText</summary>
		[DispId(12464)]
		string RTFText
		{
			get;
			set;
		}

		/// <summary>属性RuleBackColor</summary>
		[DispId(12806)]
		Color RuleBackColor
		{
			get;
			set;
		}

		/// <summary>属性RuleVisible</summary>
		[DispId(12807)]
		bool RuleVisible
		{
			get;
			set;
		}

		/// <summary>属性Selection</summary>
		[DispId(12465)]
		XTextSelection Selection
		{
			get;
		}

		/// <summary>属性SelectionStartPosition</summary>
		[DispId(12466)]
		Point SelectionStartPosition
		{
			get;
		}

		/// <summary>属性ShowTooltip</summary>
		[DispId(12720)]
		bool ShowTooltip
		{
			get;
			set;
		}

		/// <summary>属性SingleSelectedElement</summary>
		[DispId(12794)]
		XTextElement SingleSelectedElement
		{
			get;
		}

		/// <summary>属性SpecifyLoadFileNameOnce</summary>
		[DispId(12858)]
		string SpecifyLoadFileNameOnce
		{
			get;
			set;
		}

		/// <summary>属性StartPageIndex</summary>
		[DispId(12522)]
		int StartPageIndex
		{
			get;
			set;
		}

		/// <summary>属性StatusText</summary>
		[DispId(12467)]
		string StatusText
		{
			get;
			set;
		}

		/// <summary>属性SubDocuments</summary>
		[DispId(12875)]
		XTextElementList SubDocuments
		{
			get;
		}

		/// <summary>属性Tables</summary>
		[DispId(12776)]
		XTextElementList Tables
		{
			get;
		}

		/// <summary>属性Text</summary>
		[DispId(12468)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性UserTrackInfos</summary>
		[DispId(12713)]
		UserTrackInfoList UserTrackInfos
		{
			get;
		}

		/// <summary>属性WebServiceUrl</summary>
		[DispId(12816)]
		string WebServiceUrl
		{
			get;
			set;
		}

		/// <summary>属性XMLText</summary>
		[DispId(12469)]
		string XMLText
		{
			get;
			set;
		}

		/// <summary>属性XMLTextForSave</summary>
		[DispId(12846)]
		string XMLTextForSave
		{
			get;
			set;
		}

		/// <summary>属性XMLTextUnFormatted</summary>
		[DispId(12497)]
		string XMLTextUnFormatted
		{
			get;
		}

		/// <summary>方法AddBufferedListItems</summary>
		[DispId(12695)]
		void AddBufferedListItems(string name, ListItemCollection items, bool globalItems);

		/// <summary>方法AddContextMenuItem</summary>
		[DispId(12502)]
		void AddContextMenuItem(string text, string commandName);

		/// <summary>方法AddContextMenuItemByTypeName</summary>
		[DispId(12795)]
		void AddContextMenuItemByTypeName(string elementTypeName, string name, string commandName, string text);

		/// <summary>方法AddContextMenuSeparatorByTypeName</summary>
		[DispId(12796)]
		void AddContextMenuSeparatorByTypeName(string elementTypeName);

		/// <summary>方法AddDropdownListItem</summary>
		[DispId(12780)]
		bool AddDropdownListItem(string string_0, string text, string Value, bool saveToXml);

		/// <summary>方法AddXMLLinkListProvider</summary>
		[DispId(12817)]
		void AddXMLLinkListProvider(string providerName, string xmlFileName);

		/// <summary>方法AppendSubDocument</summary>
		[DispId(12866)]
		void AppendSubDocument(XTextSubDocumentElement newSubDoc);

		/// <summary>方法AutoSaveDelete</summary>
		[DispId(12959)]
		void AutoSaveDelete(string fileID);

		/// <summary>方法AutoSaveExists</summary>
		[DispId(12960)]
		bool AutoSaveExists(string fileID, bool confirm);

		/// <summary>方法AutoSaveLoadDocument</summary>
		[DispId(12961)]
		bool AutoSaveLoadDocument(string fileID);

		/// <summary>方法BeginEditElementValue</summary>
		[DispId(12783)]
		bool BeginEditElementValue(XTextElement element);

		/// <summary>方法BeginEditElementValueById</summary>
		[DispId(12784)]
		bool BeginEditElementValueById(string string_0);

		/// <summary>方法BeginInsertKB</summary>
		[DispId(12474)]
		bool BeginInsertKB();

		/// <summary>方法BeginUpdate</summary>
		[DispId(12953)]
		void BeginUpdate();

		/// <summary>方法CancelEditElementValue</summary>
		[DispId(12504)]
		bool CancelEditElementValue();

		/// <summary>方法ClearContent</summary>
		[DispId(12369)]
		void ClearContent();

		/// <summary>方法ClearContextMenuItem</summary>
		[DispId(12503)]
		void ClearContextMenuItem();

		/// <summary>方法ClearEventMessage</summary>
		[DispId(12885)]
		void ClearEventMessage();

		/// <summary>方法ClearUndo</summary>
		[DispId(12711)]
		void ClearUndo();

		/// <summary>方法CloseForPB</summary>
		[DispId(12884)]
		void CloseForPB();

		/// <summary>方法CloseForPBWithoutDock</summary>
		[DispId(12892)]
		void CloseForPBWithoutDock();

		/// <summary>方法ComCallInstanceMethodByName</summary>
		[DispId(12488)]
		object ComCallInstanceMethodByName(object instance, string name, string paramters);

		/// <summary>方法ComCallMethodByName</summary>
		[DispId(12489)]
		object ComCallMethodByName(string name, string paramters);

		/// <summary>方法ComConvertToBorderBackgroundCommandParameter</summary>
		[DispId(12525)]
		BorderBackgroundCommandParameter ComConvertToBorderBackgroundCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToCanInsertObjectEventArgs</summary>
		[DispId(12526)]
		CanInsertObjectEventArgs ComConvertToCanInsertObjectEventArgs(object sourceValue);

		/// <summary>方法ComConvertToCommandErrorEventArgs</summary>
		[DispId(12527)]
		CommandErrorEventArgs ComConvertToCommandErrorEventArgs(object sourceValue);

		/// <summary>方法ComConvertToContentChangedEventArgs</summary>
		[DispId(12528)]
		ContentChangedEventArgs ComConvertToContentChangedEventArgs(object sourceValue);

		/// <summary>方法ComConvertToContentChangingEventArgs</summary>
		[DispId(12529)]
		ContentChangingEventArgs ComConvertToContentChangingEventArgs(object sourceValue);

		/// <summary>方法ComConvertToCopySourceInfo</summary>
		[DispId(12530)]
		CopySourceInfo ComConvertToCopySourceInfo(object sourceValue);

		/// <summary>方法ComConvertToCreateElementsByKBEntryEventArgs</summary>
		[DispId(12531)]
		CreateElementsByKBEntryEventArgs ComConvertToCreateElementsByKBEntryEventArgs(object sourceValue);

		/// <summary>方法ComConvertToCurrentContentStyleInfo</summary>
		[DispId(12532)]
		CurrentContentStyleInfo ComConvertToCurrentContentStyleInfo(object sourceValue);

		/// <summary>方法ComConvertToCurrentDepartmentInfo</summary>
		[DispId(12533)]
		CurrentDepartmentInfo ComConvertToCurrentDepartmentInfo(object sourceValue);

		/// <summary>方法ComConvertToCurrentUserInfo</summary>
		[DispId(12534)]
		CurrentUserInfo ComConvertToCurrentUserInfo(object sourceValue);

		/// <summary>方法ComConvertToDataSourceDescriptor</summary>
		[DispId(12535)]
		DataSourceDescriptor ComConvertToDataSourceDescriptor(object sourceValue);

		/// <summary>方法ComConvertToDataSourceDescriptorList</summary>
		[DispId(12536)]
		DataSourceDescriptorList ComConvertToDataSourceDescriptorList(object sourceValue);

		/// <summary>方法ComConvertToDocumentComment</summary>
		[DispId(12537)]
		DocumentComment ComConvertToDocumentComment(object sourceValue);

		/// <summary>方法ComConvertToDocumentContentStyle</summary>
		[DispId(12538)]
		DocumentContentStyle ComConvertToDocumentContentStyle(object sourceValue);

		/// <summary>方法ComConvertToElementCancelEventArgs</summary>
		[DispId(12539)]
		ElementCancelEventArgs ComConvertToElementCancelEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementEventArgs</summary>
		[DispId(12540)]
		ElementEventArgs ComConvertToElementEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementEventTemplate</summary>
		[DispId(12541)]
		ElementEventTemplate ComConvertToElementEventTemplate(object sourceValue);

		/// <summary>方法ComConvertToElementExpressionEventArgs</summary>
		[DispId(12542)]
		ElementExpressionEventArgs ComConvertToElementExpressionEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementKeyEventArgs</summary>
		[DispId(12543)]
		ElementKeyEventArgs ComConvertToElementKeyEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementLoadEventArgs</summary>
		[DispId(12544)]
		ElementLoadEventArgs ComConvertToElementLoadEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementMouseEventArgs</summary>
		[DispId(12545)]
		ElementMouseEventArgs ComConvertToElementMouseEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementPaintEventArgs</summary>
		[DispId(12546)]
		ElementPaintEventArgs ComConvertToElementPaintEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementQueryStateEventArgs</summary>
		[DispId(12547)]
		ElementQueryStateEventArgs ComConvertToElementQueryStateEventArgs(object sourceValue);

		/// <summary>方法ComConvertToElementValidatingEventArgs</summary>
		[DispId(12548)]
		ElementValidatingEventArgs ComConvertToElementValidatingEventArgs(object sourceValue);

		/// <summary>方法ComConvertToEventExpressionInfo</summary>
		[DispId(12549)]
		EventExpressionInfo ComConvertToEventExpressionInfo(object sourceValue);

		/// <summary>方法ComConvertToEventExpressionInfoList</summary>
		[DispId(12550)]
		EventExpressionInfoList ComConvertToEventExpressionInfoList(object sourceValue);

		/// <summary>方法ComConvertToFileContentSource</summary>
		[DispId(12551)]
		FileContentSource ComConvertToFileContentSource(object sourceValue);

		/// <summary>方法ComConvertToFileOpenCommandParameter</summary>
		[DispId(12552)]
		FileOpenCommandParameter ComConvertToFileOpenCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToFilePrintPreviewCommandParameter</summary>
		[DispId(12553)]
		FilePrintPreviewCommandParameter ComConvertToFilePrintPreviewCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToFileSaveCommandParameter</summary>
		[DispId(12554)]
		FileSaveCommandParameter ComConvertToFileSaveCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToFilterValueEventArgs</summary>
		[DispId(12555)]
		FilterValueEventArgs ComConvertToFilterValueEventArgs(object sourceValue);

		/// <summary>方法ComConvertToFormatListItemsEventArgs</summary>
		[DispId(12556)]
		FormatListItemsEventArgs ComConvertToFormatListItemsEventArgs(object sourceValue);

		/// <summary>方法ComConvertToGridLineInfo</summary>
		[DispId(12557)]
		GridLineInfo ComConvertToGridLineInfo(object sourceValue);

		/// <summary>方法ComConvertToGridLineSettings</summary>
		[DispId(12558)]
		GridLineSettings ComConvertToGridLineSettings(object sourceValue);

		/// <summary>方法ComConvertToInputFieldSettings</summary>
		[DispId(12559)]
		InputFieldSettings ComConvertToInputFieldSettings(object sourceValue);

		/// <summary>方法ComConvertToInsertDocumentCommandParameter</summary>
		[DispId(12560)]
		InsertDocumentCommandParameter ComConvertToInsertDocumentCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToInsertObjectEventArgs</summary>
		[DispId(12561)]
		InsertObjectEventArgs ComConvertToInsertObjectEventArgs(object sourceValue);

		/// <summary>方法ComConvertToInsertStringCommandParameter</summary>
		[DispId(12562)]
		InsertStringCommandParameter ComConvertToInsertStringCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToJumpPrintInfo</summary>
		[DispId(12563)]
		JumpPrintInfo ComConvertToJumpPrintInfo(object sourceValue);

		/// <summary>方法ComConvertToKBEntry</summary>
		[DispId(12564)]
		KBEntry ComConvertToKBEntry(object sourceValue);

		/// <summary>方法ComConvertToKBEntryList</summary>
		[DispId(12565)]
		KBEntryList ComConvertToKBEntryList(object sourceValue);

		/// <summary>方法ComConvertToKBLibrary</summary>
		[DispId(12566)]
		KBLibrary ComConvertToKBLibrary(object sourceValue);

		/// <summary>方法ComConvertToLinkListBindingInfo</summary>
		[DispId(12729)]
		LinkListBindingInfo ComConvertToLinkListBindingInfo(object sourceValue);

		/// <summary>方法ComConvertToListItem</summary>
		[DispId(12567)]
		ListItem ComConvertToListItem(object sourceValue);

		/// <summary>方法ComConvertToListItemCollection</summary>
		[DispId(12568)]
		ListItemCollection ComConvertToListItemCollection(object sourceValue);

		/// <summary>方法ComConvertToListSourceInfo</summary>
		[DispId(12569)]
		ListSourceInfo ComConvertToListSourceInfo(object sourceValue);

		/// <summary>方法ComConvertToMegeCellCommandParameter</summary>
		[DispId(12570)]
		MegeCellCommandParameter ComConvertToMegeCellCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToParagraphFormatCommandParameter</summary>
		[DispId(12571)]
		ParagraphFormatCommandParameter ComConvertToParagraphFormatCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToParseSelectedItemsEventArgs</summary>
		[DispId(12572)]
		ParseSelectedItemsEventArgs ComConvertToParseSelectedItemsEventArgs(object sourceValue);

		/// <summary>方法ComConvertToPrintPageCollection</summary>
		[DispId(12573)]
		PrintPageCollection ComConvertToPrintPageCollection(object sourceValue);

		/// <summary>方法ComConvertToPrintResult</summary>
		[DispId(12574)]
		PrintResult ComConvertToPrintResult(object sourceValue);

		/// <summary>方法ComConvertToQueryListItemsEventArgs</summary>
		[DispId(12575)]
		QueryListItemsEventArgs ComConvertToQueryListItemsEventArgs(object sourceValue);

		/// <summary>方法ComConvertToQueryUserHistoryDisplayTextEventArgs</summary>
		[DispId(12576)]
		QueryUserHistoryDisplayTextEventArgs ComConvertToQueryUserHistoryDisplayTextEventArgs(object sourceValue);

		/// <summary>方法ComConvertToSearchReplaceCommandArgs</summary>
		[DispId(12577)]
		SearchReplaceCommandArgs ComConvertToSearchReplaceCommandArgs(object sourceValue);

		/// <summary>方法ComConvertToSectionCourseRecord</summary>
		[DispId(12578)]
		SectionCourseRecord ComConvertToSectionCourseRecord(object sourceValue);

		/// <summary>方法ComConvertToSectionCourseRecordDocumentController</summary>
		[DispId(12579)]
		SectionCourseRecordDocumentController ComConvertToSectionCourseRecordDocumentController(object sourceValue);

		/// <summary>方法ComConvertToSectionCourseRecordSource</summary>
		[DispId(12693)]
		SectionCourseRecordSource ComConvertToSectionCourseRecordSource(object sourceValue);

		/// <summary>方法ComConvertToSplitCellExtCommandParameter</summary>
		[DispId(12580)]
		SplitCellExtCommandParameter ComConvertToSplitCellExtCommandParameter(object sourceValue);

		/// <summary>方法ComConvertToStatusTextChangedEventArgs</summary>
		[DispId(12581)]
		StatusTextChangedEventArgs ComConvertToStatusTextChangedEventArgs(object sourceValue);

		/// <summary>方法ComConvertToTableCommandArgs</summary>
		[DispId(12582)]
		TableCommandArgs ComConvertToTableCommandArgs(object sourceValue);

		/// <summary>方法ComConvertToTrackVisibleConfig</summary>
		[DispId(12583)]
		TrackVisibleConfig ComConvertToTrackVisibleConfig(object sourceValue);

		/// <summary>方法ComConvertToUserHistoryInfo</summary>
		[DispId(12706)]
		UserHistoryInfo ComConvertToUserHistoryInfo(object sourceValue);

		/// <summary>方法ComConvertToValueFormater</summary>
		[DispId(12584)]
		ValueFormater ComConvertToValueFormater(object sourceValue);

		/// <summary>方法ComConvertToValueValidateResultList</summary>
		[DispId(12704)]
		ValueValidateResultList ComConvertToValueValidateResultList(object sourceValue);

		/// <summary>方法ComConvertToValueValidateStyle</summary>
		[DispId(12585)]
		ValueValidateStyle ComConvertToValueValidateStyle(object sourceValue);

		/// <summary>方法ComConvertToWriterCommandEventArgs</summary>
		[DispId(12586)]
		WriterCommandEventArgs ComConvertToWriterCommandEventArgs(object sourceValue);

		/// <summary>方法ComConvertToWriterEventArgs</summary>
		[DispId(12587)]
		WriterEventArgs ComConvertToWriterEventArgs(object sourceValue);

		/// <summary>方法ComConvertToWriterMouseEventArgs</summary>
		[DispId(12588)]
		WriterMouseEventArgs ComConvertToWriterMouseEventArgs(object sourceValue);

		/// <summary>方法ComConvertToXAttribute</summary>
		[DispId(12589)]
		XAttribute ComConvertToXAttribute(object sourceValue);

		/// <summary>方法ComConvertToXAttributeList</summary>
		[DispId(12590)]
		XAttributeList ComConvertToXAttributeList(object sourceValue);

		/// <summary>方法ComConvertToXMLLinkListProvider</summary>
		[DispId(12730)]
		XMLLinkListProvider ComConvertToXMLLinkListProvider(object sourceValue);

		/// <summary>方法ComConvertToXPageSettings</summary>
		[DispId(12591)]
		XPageSettings ComConvertToXPageSettings(object sourceValue);

		/// <summary>方法ComConvertToXTextBarcodeFieldElement</summary>
		[DispId(12592)]
		XTextBarcodeFieldElement ComConvertToXTextBarcodeFieldElement(object sourceValue);

		/// <summary>方法ComConvertToXTextButtonElement</summary>
		[DispId(12746)]
		XTextButtonElement ComConvertToXTextButtonElement(object sourceValue);

		/// <summary>方法ComConvertToXTextCheckBoxElement</summary>
		[DispId(12593)]
		XTextCheckBoxElement ComConvertToXTextCheckBoxElement(object sourceValue);

		/// <summary>方法ComConvertToXTextContentLinkFieldElement</summary>
		[DispId(12594)]
		XTextContentLinkFieldElement ComConvertToXTextContentLinkFieldElement(object sourceValue);

		/// <summary>方法ComConvertToXTextControlHostElement</summary>
		[DispId(12595)]
		XTextControlHostElement ComConvertToXTextControlHostElement(object sourceValue);

		/// <summary>方法ComConvertToXTextCustomShapeElement</summary>
		[DispId(12802)]
		XTextCustomShapeElement ComConvertToXTextCustomShapeElement(object sourceValue);

		/// <summary>方法ComConvertToXTextDocument</summary>
		[DispId(12596)]
		XTextDocument ComConvertToXTextDocument(object sourceValue);

		/// <summary>方法ComConvertToXTextDocumentList</summary>
		[DispId(12597)]
		XTextDocumentList ComConvertToXTextDocumentList(object sourceValue);

		/// <summary>方法ComConvertToXTextElement</summary>
		[DispId(12747)]
		XTextElement ComConvertToXTextElement(object sourceValue);

		/// <summary>方法ComConvertToXTextElementList</summary>
		[DispId(12598)]
		XTextElementList ComConvertToXTextElementList(object sourceValue);

		/// <summary>方法ComConvertToXTextFileBlockElement</summary>
		[DispId(12599)]
		XTextFileBlockElement ComConvertToXTextFileBlockElement(object sourceValue);

		/// <summary>方法ComConvertToXTextHorizontalLineElement</summary>
		[DispId(12600)]
		XTextHorizontalLineElement ComConvertToXTextHorizontalLineElement(object sourceValue);

		/// <summary>方法ComConvertToXTextImageElement</summary>
		[DispId(12601)]
		XTextImageElement ComConvertToXTextImageElement(object sourceValue);

		/// <summary>方法ComConvertToXTextInputFieldElement</summary>
		[DispId(12602)]
		XTextInputFieldElement ComConvertToXTextInputFieldElement(object sourceValue);

		/// <summary>方法ComConvertToXTextLabelElement</summary>
		[DispId(12603)]
		XTextLabelElement ComConvertToXTextLabelElement(object sourceValue);

		/// <summary>方法ComConvertToXTextLineBreakElement</summary>
		[DispId(12604)]
		XTextLineBreakElement ComConvertToXTextLineBreakElement(object sourceValue);

		/// <summary>方法ComConvertToXTextMedicalExpressionFieldElement</summary>
		[DispId(12605)]
		XTextMedicalExpressionFieldElement ComConvertToXTextMedicalExpressionFieldElement(object sourceValue);

		/// <summary>方法ComConvertToXTextPageBreakElement</summary>
		[DispId(12606)]
		XTextPageBreakElement ComConvertToXTextPageBreakElement(object sourceValue);

		/// <summary>方法ComConvertToXTextPageInfoElement</summary>
		[DispId(12607)]
		XTextPageInfoElement ComConvertToXTextPageInfoElement(object sourceValue);

		/// <summary>方法ComConvertToXTextParagraphFlagElement</summary>
		[DispId(12608)]
		XTextParagraphFlagElement ComConvertToXTextParagraphFlagElement(object sourceValue);

		/// <summary>方法ComConvertToXTextRadioBoxElement</summary>
		[DispId(12609)]
		XTextRadioBoxElement ComConvertToXTextRadioBoxElement(object sourceValue);

		/// <summary>方法ComConvertToXTextSectionElement</summary>
		[DispId(12610)]
		XTextSectionElement ComConvertToXTextSectionElement(object sourceValue);

		/// <summary>方法ComConvertToXTextSignElement</summary>
		[DispId(12611)]
		XTextSignElement ComConvertToXTextSignElement(object sourceValue);

		/// <summary>方法ComConvertToXTextSubDocumentElement</summary>
		[DispId(12876)]
		XTextSubDocumentElement ComConvertToXTextSubDocumentElement(object sourceValue);

		/// <summary>方法ComConvertToXTextSubDocumentSectionElement</summary>
		[DispId(12812)]
		XTextSubDocumentElement ComConvertToXTextSubDocumentSectionElement(object sourceValue);

		/// <summary>方法ComConvertToXTextTableCellElement</summary>
		[DispId(12612)]
		XTextTableCellElement ComConvertToXTextTableCellElement(object sourceValue);

		/// <summary>方法ComConvertToXTextTableColumnElement</summary>
		[DispId(12613)]
		XTextTableColumnElement ComConvertToXTextTableColumnElement(object sourceValue);

		/// <summary>方法ComConvertToXTextTableElement</summary>
		[DispId(12614)]
		XTextTableElement ComConvertToXTextTableElement(object sourceValue);

		/// <summary>方法ComConvertToXTextTableRowElement</summary>
		[DispId(12615)]
		XTextTableRowElement ComConvertToXTextTableRowElement(object sourceValue);

		/// <summary>方法ComCreateBorderBackgroundCommandParameter</summary>
		[DispId(12616)]
		BorderBackgroundCommandParameter ComCreateBorderBackgroundCommandParameter();

		/// <summary>方法ComCreateCommandErrorEventArgs</summary>
		[DispId(12617)]
		CommandErrorEventArgs ComCreateCommandErrorEventArgs();

		/// <summary>方法ComCreateContentChangedEventArgs</summary>
		[DispId(12618)]
		ContentChangedEventArgs ComCreateContentChangedEventArgs();

		/// <summary>方法ComCreateContentChangingEventArgs</summary>
		[DispId(12619)]
		ContentChangingEventArgs ComCreateContentChangingEventArgs();

		/// <summary>方法ComCreateCopySourceInfo</summary>
		[DispId(12620)]
		CopySourceInfo ComCreateCopySourceInfo();

		/// <summary>方法ComCreateCurrentContentStyleInfo</summary>
		[DispId(12621)]
		CurrentContentStyleInfo ComCreateCurrentContentStyleInfo();

		/// <summary>方法ComCreateCurrentDepartmentInfo</summary>
		[DispId(12622)]
		CurrentDepartmentInfo ComCreateCurrentDepartmentInfo();

		/// <summary>方法ComCreateCurrentUserInfo</summary>
		[DispId(12623)]
		CurrentUserInfo ComCreateCurrentUserInfo();

		/// <summary>方法ComCreateDataSourceDescriptor</summary>
		[DispId(12624)]
		DataSourceDescriptor ComCreateDataSourceDescriptor();

		/// <summary>方法ComCreateDataSourceDescriptorList</summary>
		[DispId(12625)]
		DataSourceDescriptorList ComCreateDataSourceDescriptorList();

		/// <summary>方法ComCreateDCGridLineInfo</summary>
		[DispId(12970)]
		DCGridLineInfo ComCreateDCGridLineInfo();

		/// <summary>方法ComCreateDocumentComment</summary>
		[DispId(12626)]
		DocumentComment ComCreateDocumentComment();

		/// <summary>方法ComCreateDocumentContentStyle</summary>
		[DispId(12627)]
		DocumentContentStyle ComCreateDocumentContentStyle();

		/// <summary>方法ComCreateElementEventArgs</summary>
		[DispId(12628)]
		ElementEventArgs ComCreateElementEventArgs();

		/// <summary>方法ComCreateElementEventTemplate</summary>
		[DispId(12629)]
		ElementEventTemplate ComCreateElementEventTemplate();

		/// <summary>方法ComCreateEventExpressionInfo</summary>
		[DispId(12631)]
		EventExpressionInfo ComCreateEventExpressionInfo();

		/// <summary>方法ComCreateEventExpressionInfoList</summary>
		[DispId(12632)]
		EventExpressionInfoList ComCreateEventExpressionInfoList();

		/// <summary>方法ComCreateFileContentSource</summary>
		[DispId(12633)]
		FileContentSource ComCreateFileContentSource();

		/// <summary>方法ComCreateFileOpenCommandParameter</summary>
		[DispId(12634)]
		FileOpenCommandParameter ComCreateFileOpenCommandParameter();

		/// <summary>方法ComCreateFilePrintCommandParameter</summary>
		[DispId(12946)]
		FilePrintCommandParameter ComCreateFilePrintCommandParameter();

		/// <summary>方法ComCreateFilePrintPreviewCommandParameter</summary>
		[DispId(12635)]
		FilePrintPreviewCommandParameter ComCreateFilePrintPreviewCommandParameter();

		/// <summary>方法ComCreateFileSaveCommandParameter</summary>
		[DispId(12636)]
		FileSaveCommandParameter ComCreateFileSaveCommandParameter();

		/// <summary>方法ComCreateGridLineInfo</summary>
		[DispId(12637)]
		GridLineInfo ComCreateGridLineInfo();

		/// <summary>方法ComCreateGridLineSettings</summary>
		[DispId(12638)]
		GridLineSettings ComCreateGridLineSettings();

		/// <summary>方法ComCreateInputFieldSettings</summary>
		[DispId(12639)]
		InputFieldSettings ComCreateInputFieldSettings();

		/// <summary>方法ComCreateInsertDocumentCommandParameter</summary>
		[DispId(12640)]
		InsertDocumentCommandParameter ComCreateInsertDocumentCommandParameter();

		/// <summary>方法ComCreateInsertStringCommandParameter</summary>
		[DispId(12641)]
		InsertStringCommandParameter ComCreateInsertStringCommandParameter();

		/// <summary>方法ComCreateJumpPrintInfo</summary>
		[DispId(12642)]
		JumpPrintInfo ComCreateJumpPrintInfo();

		/// <summary>方法ComCreateKBEntry</summary>
		[DispId(12643)]
		KBEntry ComCreateKBEntry();

		/// <summary>方法ComCreateKBEntryList</summary>
		[DispId(12644)]
		KBEntryList ComCreateKBEntryList();

		/// <summary>方法ComCreateKBLibrary</summary>
		[DispId(12645)]
		KBLibrary ComCreateKBLibrary();

		/// <summary>方法ComCreateLinkListBindingInfo</summary>
		[DispId(12727)]
		LinkListBindingInfo ComCreateLinkListBindingInfo();

		/// <summary>方法ComCreateListItem</summary>
		[DispId(12646)]
		ListItem ComCreateListItem();

		/// <summary>方法ComCreateListItemCollection</summary>
		[DispId(12647)]
		ListItemCollection ComCreateListItemCollection();

		/// <summary>方法ComCreateListSourceInfo</summary>
		[DispId(12648)]
		ListSourceInfo ComCreateListSourceInfo();

		/// <summary>方法ComCreateMegeCellCommandParameter</summary>
		[DispId(12649)]
		MegeCellCommandParameter ComCreateMegeCellCommandParameter();

		/// <summary>方法ComCreateParagraphFormatCommandParameter</summary>
		[DispId(12650)]
		ParagraphFormatCommandParameter ComCreateParagraphFormatCommandParameter();

		/// <summary>方法ComCreatePrintPageCollection</summary>
		[DispId(12651)]
		PrintPageCollection ComCreatePrintPageCollection();

		/// <summary>方法ComCreatePrintResult</summary>
		[DispId(12652)]
		PrintResult ComCreatePrintResult();

		/// <summary>方法ComCreateSearchReplaceCommandArgs</summary>
		[DispId(12653)]
		SearchReplaceCommandArgs ComCreateSearchReplaceCommandArgs();

		/// <summary>方法ComCreateSectionCourseRecordDocumentController</summary>
		[DispId(12654)]
		SectionCourseRecordDocumentController ComCreateSectionCourseRecordDocumentController();

		/// <summary>方法ComCreateSectionCourseRecordSource</summary>
		[DispId(12694)]
		SectionCourseRecordSource ComCreateSectionCourseRecordSource();

		/// <summary>方法ComCreateSplitCellExtCommandParameter</summary>
		[DispId(12655)]
		SplitCellExtCommandParameter ComCreateSplitCellExtCommandParameter();

		/// <summary>方法ComCreateTableCommandArgs</summary>
		[DispId(12656)]
		TableCommandArgs ComCreateTableCommandArgs();

		/// <summary>方法ComCreateTrackVisibleConfig</summary>
		[DispId(12657)]
		TrackVisibleConfig ComCreateTrackVisibleConfig();

		/// <summary>方法ComCreateUserHistoryInfo</summary>
		[DispId(12707)]
		UserHistoryInfo ComCreateUserHistoryInfo();

		/// <summary>方法ComCreateValueFormater</summary>
		[DispId(12658)]
		ValueFormater ComCreateValueFormater();

		/// <summary>方法ComCreateValueValidateStyle</summary>
		[DispId(12659)]
		ValueValidateStyle ComCreateValueValidateStyle();

		/// <summary>方法ComCreateXAttribute</summary>
		[DispId(12660)]
		XAttribute ComCreateXAttribute();

		/// <summary>方法ComCreateXAttributeList</summary>
		[DispId(12661)]
		XAttributeList ComCreateXAttributeList();

		/// <summary>方法ComCreateXDataBinding</summary>
		[DispId(12929)]
		XDataBinding ComCreateXDataBinding();

		/// <summary>方法ComCreateXMLLinkListProvider</summary>
		[DispId(12728)]
		XMLLinkListProvider ComCreateXMLLinkListProvider();

		/// <summary>方法ComCreateXPageSettings</summary>
		[DispId(12662)]
		XPageSettings ComCreateXPageSettings();

		/// <summary>方法ComCreateXTextBarcodeFieldElement</summary>
		[DispId(12663)]
		XTextBarcodeFieldElement ComCreateXTextBarcodeFieldElement();

		/// <summary>方法ComCreateXTextButtonElement</summary>
		[DispId(12748)]
		XTextButtonElement ComCreateXTextButtonElement();

		/// <summary>方法ComCreateXTextCheckBoxElement</summary>
		[DispId(12664)]
		XTextCheckBoxElement ComCreateXTextCheckBoxElement();

		/// <summary>方法ComCreateXTextContentLinkFieldElement</summary>
		[DispId(12665)]
		XTextContentLinkFieldElement ComCreateXTextContentLinkFieldElement();

		/// <summary>方法ComCreateXTextControlHostElement</summary>
		[DispId(12666)]
		XTextControlHostElement ComCreateXTextControlHostElement();

		/// <summary>方法ComCreateXTextCustomShapeElement</summary>
		[DispId(12803)]
		XTextCustomShapeElement ComCreateXTextCustomShapeElement();

		/// <summary>方法ComCreateXTextDocument</summary>
		[DispId(12667)]
		XTextDocument ComCreateXTextDocument();

		/// <summary>方法ComCreateXTextDocumentList</summary>
		[DispId(12668)]
		XTextDocumentList ComCreateXTextDocumentList();

		/// <summary>方法ComCreateXTextElementList</summary>
		[DispId(12669)]
		XTextElementList ComCreateXTextElementList();

		/// <summary>方法ComCreateXTextFileBlockElement</summary>
		[DispId(12670)]
		XTextFileBlockElement ComCreateXTextFileBlockElement();

		/// <summary>方法ComCreateXTextHorizontalLineElement</summary>
		[DispId(12671)]
		XTextHorizontalLineElement ComCreateXTextHorizontalLineElement();

		/// <summary>方法ComCreateXTextImageElement</summary>
		[DispId(12672)]
		XTextImageElement ComCreateXTextImageElement();

		/// <summary>方法ComCreateXTextInputFieldElement</summary>
		[DispId(12673)]
		XTextInputFieldElement ComCreateXTextInputFieldElement();

		/// <summary>方法ComCreateXTextLabelElement</summary>
		[DispId(12674)]
		XTextLabelElement ComCreateXTextLabelElement();

		/// <summary>方法ComCreateXTextLineBreakElement</summary>
		[DispId(12675)]
		XTextLineBreakElement ComCreateXTextLineBreakElement();

		/// <summary>方法ComCreateXTextMedicalExpressionFieldElement</summary>
		[DispId(12676)]
		XTextMedicalExpressionFieldElement ComCreateXTextMedicalExpressionFieldElement();

		/// <summary>方法ComCreateXTextNewMedicalExpressionElement</summary>
		[DispId(12950)]
		XTextNewMedicalExpressionElement ComCreateXTextNewMedicalExpressionElement();

		/// <summary>方法ComCreateXTextPageBreakElement</summary>
		[DispId(12677)]
		XTextPageBreakElement ComCreateXTextPageBreakElement();

		/// <summary>方法ComCreateXTextPageInfoElement</summary>
		[DispId(12678)]
		XTextPageInfoElement ComCreateXTextPageInfoElement();

		/// <summary>方法ComCreateXTextParagraphFlagElement</summary>
		[DispId(12679)]
		XTextParagraphFlagElement ComCreateXTextParagraphFlagElement();

		/// <summary>方法ComCreateXTextRadioBoxElement</summary>
		[DispId(12680)]
		XTextRadioBoxElement ComCreateXTextRadioBoxElement();

		/// <summary>方法ComCreateXTextSectionElement</summary>
		[DispId(12681)]
		XTextSectionElement ComCreateXTextSectionElement();

		/// <summary>方法ComCreateXTextSignElement</summary>
		[DispId(12682)]
		XTextSignElement ComCreateXTextSignElement();

		/// <summary>方法ComCreateXTextSubDocumentElement</summary>
		[DispId(12877)]
		XTextSubDocumentElement ComCreateXTextSubDocumentElement();

		/// <summary>方法ComCreateXTextSubDocumentSectionElement</summary>
		[DispId(12813)]
		XTextSubDocumentElement ComCreateXTextSubDocumentSectionElement();

		/// <summary>方法ComCreateXTextTableCellElement</summary>
		[DispId(12683)]
		XTextTableCellElement ComCreateXTextTableCellElement();

		/// <summary>方法ComCreateXTextTableColumnElement</summary>
		[DispId(12684)]
		XTextTableColumnElement ComCreateXTextTableColumnElement();

		/// <summary>方法ComCreateXTextTableElement</summary>
		[DispId(12685)]
		XTextTableElement ComCreateXTextTableElement();

		/// <summary>方法ComCreateXTextTableRowElement</summary>
		[DispId(12686)]
		XTextTableRowElement ComCreateXTextTableRowElement();

		/// <summary>方法ComCreateXTextTemperatureChartElement</summary>
		[DispId(12967)]
		XTextTemperatureChartElement ComCreateXTextTemperatureChartElement();

		/// <summary>方法ComDispose</summary>
		[DispId(12708)]
		void ComDispose();

		/// <summary>方法ComFocus</summary>
		[DispId(12370)]
		bool ComFocus();

		/// <summary>方法ComGetAutoScrollPositionX</summary>
		[DispId(12947)]
		int ComGetAutoScrollPositionX();

		/// <summary>方法ComGetAutoScrollPositionY</summary>
		[DispId(12948)]
		int ComGetAutoScrollPositionY();

		/// <summary>方法ComGetCurrentCoreVersion</summary>
		[DispId(12971)]
		string ComGetCurrentCoreVersion();

		/// <summary>方法ComGetCurrentPageIndexByScrollPosition</summary>
		[DispId(12968)]
		int ComGetCurrentPageIndexByScrollPosition();

		/// <summary>方法ComGetDocumentOptionValue</summary>
		[DispId(12490)]
		string ComGetDocumentOptionValue(string name);

		/// <summary>方法ComGetElementClientBounds</summary>
		[DispId(12371)]
		RectangleClass ComGetElementClientBounds(XTextElement element);

		/// <summary>方法ComGetProperty</summary>
		[DispId(12372)]
		object ComGetProperty(string propertyName);

		/// <summary>方法ComInvalidate</summary>
		[DispId(12373)]
		void ComInvalidate();

		/// <summary>方法Command_ElementProperties</summary>
		[DispId(12687)]
		XTextElement Command_ElementProperties(bool showUI, object parameter);

		/// <summary>方法Command_InsertInputField</summary>
		[DispId(12688)]
		XTextInputFieldElement Command_InsertInputField(bool showUI, object parameter);

		/// <summary>方法CommitContentUserTrace</summary>
		[DispId(12785)]
		bool CommitContentUserTrace(XTextContainerElement element);

		/// <summary>方法CommitContentUserTraceById</summary>
		[DispId(12786)]
		bool CommitContentUserTraceById(string string_0);

		/// <summary>方法CommitDocumentUserTrace</summary>
		[DispId(12787)]
		bool CommitDocumentUserTrace();

		/// <summary>方法ComSelect</summary>
		[DispId(12374)]
		void ComSelect();

		/// <summary>方法ComSetAutoScrollPosition</summary>
		[DispId(12949)]
		void ComSetAutoScrollPosition(int int_0, int int_1);

		/// <summary>方法ComSetDocumentOption</summary>
		[DispId(12491)]
		bool ComSetDocumentOption(string name, string Value);

		/// <summary>方法ComSetProperty</summary>
		[DispId(12375)]
		bool ComSetProperty(string propertyName, string Value);

		/// <summary>方法ConverToUTF8DecodedString</summary>
		[DispId(12895)]
		string ConverToUTF8DecodedString(string unicodeString);

		/// <summary>方法Copy</summary>
		[DispId(12974)]
		bool Copy();

		/// <summary>方法CreateDocumentFromClipboard</summary>
		[DispId(12703)]
		XTextDocument CreateDocumentFromClipboard();

		/// <summary>方法CreateElementByXMLFragment</summary>
		[DispId(12847)]
		XTextElement CreateElementByXMLFragment(string string_0);

		/// <summary>方法CreateElementsByKBEntry</summary>
		[DispId(12475)]
		void CreateElementsByKBEntry(CreateElementsByKBEntryEventArgs args);

		/// <summary>方法CreateInstanceByTypeName</summary>
		[DispId(12376)]
		object CreateInstanceByTypeName(string typeName);

		/// <summary>方法DelayFocus</summary>
		[DispId(12716)]
		void DelayFocus(int interval);

		/// <summary>方法DetectValueBindingModified</summary>
		[DispId(12983)]
		DetectResultForValueBindingModifiedList DetectValueBindingModified();

		/// <summary>方法DocumentValueValidate</summary>
		[DispId(12851)]
		ValueValidateResultList DocumentValueValidate();

		/// <summary>方法DocumentValueValidateWithCreateDocumentComments</summary>
		[DispId(12975)]
		ValueValidateResultList DocumentValueValidateWithCreateDocumentComments();

		/// <summary>方法DocumentValueValidateXML</summary>
		[DispId(12852)]
		string DocumentValueValidateXML();

		/// <summary>方法EditLabelPageText</summary>
		[DispId(12867)]
		bool EditLabelPageText(XTextLabelElement xtextLabelElement_0);

		/// <summary>方法EndUpdate</summary>
		[DispId(12954)]
		void EndUpdate();

		/// <summary>方法ExecuteCommand</summary>
		[DispId(12377)]
		object ExecuteCommand(string commandName, bool showUI, object parameter);

		/// <summary>方法ExecuteStringCommand</summary>
		[DispId(12505)]
		object ExecuteStringCommand(string command);

		/// <summary>方法FlashElement</summary>
		[DispId(12890)]
		void FlashElement(XTextElement element, bool autoScroll);

		/// <summary>方法FlashElements</summary>
		[DispId(12745)]
		void FlashElements(XTextElementList elements, bool autoScroll);

		/// <summary>方法FocusElementById</summary>
		[DispId(12760)]
		bool FocusElementById(string string_0);

		/// <summary>方法GCCollect</summary>
		[DispId(12966)]
		void GCCollect();

		/// <summary>方法GetBindingDataSources</summary>
		[DispId(12905)]
		string GetBindingDataSources();

		/// <summary>方法GetCheckedValueList</summary>
		[DispId(12819)]
		string GetCheckedValueList(string spliter, bool includeCheckbox, bool includeRadio, bool includeElementID, bool includeElementName);

		/// <summary>方法GetCommandNameList</summary>
		[DispId(12743)]
		string GetCommandNameList();

		/// <summary>方法GetCurrentElementByTypeName</summary>
		[DispId(12378)]
		XTextElement GetCurrentElementByTypeName(string typeName);

		/// <summary>方法GetCustomAttribute</summary>
		[DispId(12915)]
		string GetCustomAttribute(string name);

		/// <summary>方法GetDataSourceBindingDescriptions</summary>
		[DispId(12906)]
		DataSourceBindingDescriptionList GetDataSourceBindingDescriptions();

		/// <summary>方法GetDataSourceBindingDescriptionsXML</summary>
		[DispId(12891)]
		string GetDataSourceBindingDescriptionsXML();

		/// <summary>方法GetDetectValueBindingModifiedMessage</summary>
		[DispId(12984)]
		string GetDetectValueBindingModifiedMessage();

		/// <summary>方法GetDocumentParameterEnabled</summary>
		[DispId(12903)]
		bool GetDocumentParameterEnabled(string parameterName);

		/// <summary>方法GetDocumentParameterValueXml</summary>
		[DispId(12379)]
		string GetDocumentParameterValueXml(string name);

		/// <summary>方法GetDocumentValueValidateResultCount</summary>
		[DispId(12838)]
		int GetDocumentValueValidateResultCount();

		/// <summary>方法GetDocumnetParameterValue</summary>
		[DispId(12380)]
		object GetDocumnetParameterValue(string name);

		/// <summary>方法GetElementAttribute</summary>
		[DispId(12820)]
		string GetElementAttribute(string string_0, string attributeName);

		/// <summary>方法GetElementById</summary>
		[DispId(12381)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementByIdExt</summary>
		[DispId(12921)]
		XTextElement GetElementByIdExt(string string_0, bool idAttributeOnly);

		/// <summary>方法GetElementByPosition</summary>
		[DispId(12382)]
		XTextElement GetElementByPosition(int int_0, int int_1);

		/// <summary>方法GetElementChecked</summary>
		[DispId(12839)]
		bool GetElementChecked(string string_0);

		/// <summary>方法GetElementClientBounds</summary>
		[DispId(12506)]
		Rectangle GetElementClientBounds(XTextElement element);

		/// <summary>方法GetElementInnerXmlByID</summary>
		[DispId(12899)]
		string GetElementInnerXmlByID(string string_0);

		/// <summary>方法GetElementOuterXmlByID</summary>
		[DispId(12900)]
		string GetElementOuterXmlByID(string string_0);

		/// <summary>方法GetElementProperty</summary>
		[DispId(12761)]
		string GetElementProperty(string string_0, string name);

		/// <summary>方法GetElementsById</summary>
		[DispId(12821)]
		XTextElementList GetElementsById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(12922)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(12923)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetElementText</summary>
		[DispId(12797)]
		string GetElementText(string string_0);

		/// <summary>方法GetElementTextByID</summary>
		[DispId(12880)]
		string GetElementTextByID(string string_0);

		/// <summary>方法GetElementVisible</summary>
		[DispId(12798)]
		bool GetElementVisible(string string_0);

		/// <summary>方法GetElementXMLFragmentByID</summary>
		[DispId(12901)]
		string GetElementXMLFragmentByID(string string_0);

		/// <summary>方法GetEventMessage</summary>
		[DispId(12853)]
		WriterControlEventMessage GetEventMessage();

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(12924)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetInputFieldElementById</summary>
		[DispId(12515)]
		XTextInputFieldElement GetInputFieldElementById(string string_0);

		/// <summary>方法GetInputFieldInnerValue</summary>
		[DispId(12896)]
		string GetInputFieldInnerValue(string string_0);

		/// <summary>方法GetLastEventNames</summary>
		[DispId(12383)]
		string GetLastEventNames();

		/// <summary>方法GetNavigateNodesString</summary>
		[DispId(12516)]
		string GetNavigateNodesString();

		/// <summary>方法GetNavigateNodesXMLString</summary>
		[DispId(12893)]
		string GetNavigateNodesXMLString();

		/// <summary>方法GetNextElementByTypeName</summary>
		[DispId(12822)]
		XTextElement GetNextElementByTypeName(XTextElement startElement, string nextElementTypeName);

		/// <summary>方法GetNowDateTime</summary>
		[DispId(12925)]
		DateTime GetNowDateTime();

		/// <summary>方法GetOptionValue</summary>
		[DispId(12825)]
		string GetOptionValue(string name);

		/// <summary>方法GetSpecifyElementsByTypeName</summary>
		[DispId(12384)]
		XTextElementList GetSpecifyElementsByTypeName(string typeName);

		/// <summary>方法GetStyleIndexByString</summary>
		[DispId(12964)]
		int GetStyleIndexByString(string styleString);

		/// <summary>方法GetSubDoumentContentXmlByID</summary>
		[DispId(12902)]
		string GetSubDoumentContentXmlByID(string string_0);

		/// <summary>方法GetTableCell</summary>
		[DispId(12788)]
		XTextTableCellElement GetTableCell(string tableID, int rowIndex, int colIndex);

		/// <summary>方法GetTableCellText</summary>
		[DispId(12789)]
		string GetTableCellText(string tableID, int rowIndex, int colIndex);

		/// <summary>方法GetTableElementById</summary>
		[DispId(12517)]
		XTextTableElement GetTableElementById(string string_0);

		/// <summary>方法HandleBackspace</summary>
		[DispId(12385)]
		bool HandleBackspace();

		/// <summary>方法InsertSubDocuentAtCurrentPosition</summary>
		[DispId(12868)]
		void InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement newSubDoc, bool insertUp);

		/// <summary>方法IsCommandChecked</summary>
		[DispId(12386)]
		bool IsCommandChecked(string commandName);

		/// <summary>方法IsCommandEnabled</summary>
		[DispId(12387)]
		bool IsCommandEnabled(string commandName);

		/// <summary>方法IsCommandSupported</summary>
		[DispId(12388)]
		bool IsCommandSupported(string commandName);

		/// <summary>方法LoadDocumentFromBase64String</summary>
		[DispId(12471)]
		bool LoadDocumentFromBase64String(string text, string format);

		/// <summary>方法LoadDocumentFromBinary</summary>
		[DispId(12470)]
		bool LoadDocumentFromBinary(byte[] byte_0, string format);

		/// <summary>方法LoadDocumentFromFile</summary>
		[DispId(12389)]
		bool LoadDocumentFromFile(string string_0, string format);

		/// <summary>方法LoadDocumentFromString</summary>
		[DispId(12390)]
		bool LoadDocumentFromString(string text, string format);

		/// <summary>方法LoadDocumentString</summary>
		[DispId(12486)]
		bool LoadDocumentString(string xmlText);

		/// <summary>方法LockContentByElement</summary>
		[DispId(12869)]
		bool LockContentByElement(XTextContainerElement element, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法LockContentByElementID</summary>
		[DispId(12870)]
		bool LockContentByElementID(string elementID, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法LockContentByTableRow</summary>
		[DispId(12871)]
		bool LockContentByTableRow(string tableID, int rowIndexBase0, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法MoveDownOneLine</summary>
		[DispId(12859)]
		void MoveDownOneLine();

		/// <summary>方法MoveEnd</summary>
		[DispId(12860)]
		void MoveEnd();

		/// <summary>方法MoveHome</summary>
		[DispId(12861)]
		void MoveHome();

		/// <summary>方法MoveLeft</summary>
		[DispId(12862)]
		void MoveLeft();

		/// <summary>方法MoveRight</summary>
		[DispId(12863)]
		void MoveRight();

		/// <summary>方法MoveTo</summary>
		[DispId(12391)]
		void MoveTo(MoveTarget target);

		/// <summary>方法MoveToClientPosition</summary>
		[DispId(12894)]
		bool MoveToClientPosition(int clientX, int clientY);

		/// <summary>方法MoveToPage</summary>
		[DispId(12392)]
		bool MoveToPage(int index);

		/// <summary>方法MoveToPosition</summary>
		[DispId(12518)]
		void MoveToPosition(int index);

		/// <summary>方法MoveUpOneLine</summary>
		[DispId(12864)]
		void MoveUpOneLine();

		/// <summary>方法Navigate</summary>
		[DispId(12476)]
		bool Navigate(NavigateNode node);

		/// <summary>方法NavigateByNodeID</summary>
		[DispId(12519)]
		bool NavigateByNodeID(string string_0);

		/// <summary>方法NavigateByUserTrackInfo</summary>
		[DispId(12712)]
		bool NavigateByUserTrackInfo(UserTrackInfo info);

		/// <summary>方法PreloadSystem</summary>
		[DispId(12963)]
		void PreloadSystem();

		/// <summary>方法PrintDocumentExt</summary>
		[DispId(12790)]
		void PrintDocumentExt(bool showDialog, string specifyPageIndexs);

		/// <summary>方法RaiseElementContentChangedEvent</summary>
		[DispId(12742)]
		void RaiseElementContentChangedEvent(XTextElement element);

		/// <summary>方法RedrawDocument</summary>
		[DispId(12944)]
		void RedrawDocument();

		/// <summary>方法RefreshDocument</summary>
		[DispId(12393)]
		void RefreshDocument();

		/// <summary>方法RefreshDocumentLayout</summary>
		[DispId(12955)]
		void RefreshDocumentLayout();

		/// <summary>方法RefreshInnerView</summary>
		[DispId(12956)]
		void RefreshInnerView(bool fastMode);

		/// <summary>方法RejectUserTrace</summary>
		[DispId(12808)]
		bool RejectUserTrace();

		/// <summary>方法RemoveContextMenuItemByTypeName</summary>
		[DispId(12799)]
		void RemoveContextMenuItemByTypeName(string elementTypeName, string name);

		/// <summary>方法ResetAutoSaveTask</summary>
		[DispId(12883)]
		void ResetAutoSaveTask();

		/// <summary>方法ResetFormValue</summary>
		[DispId(12834)]
		bool ResetFormValue();

		/// <summary>方法ResetOutlineNodes</summary>
		[DispId(12835)]
		void ResetOutlineNodes();

		/// <summary>方法SaveDocumentToBase64String</summary>
		[DispId(12472)]
		string SaveDocumentToBase64String(string format);

		/// <summary>方法SaveDocumentToFile</summary>
		[DispId(12394)]
		bool SaveDocumentToFile(string string_0, string format);

		/// <summary>方法SaveDocumentToString</summary>
		[DispId(12473)]
		string SaveDocumentToString(string format);

		/// <summary>方法SaveLongImageFile</summary>
		[DispId(12909)]
		void SaveLongImageFile(string fileName);

		/// <summary>方法SaveLongImageFileZoom</summary>
		[DispId(12930)]
		void SaveLongImageFileZoom(string fileName, float zoomRate);

		/// <summary>方法SaveLongImageToBase64String</summary>
		[DispId(12910)]
		string SaveLongImageToBase64String(string format);

		/// <summary>方法SaveLongImageToBase64StringZoom</summary>
		[DispId(12931)]
		string SaveLongImageToBase64StringZoom(string format, float zoomRate);

		/// <summary>方法SavePageImageFile</summary>
		[DispId(12738)]
		void SavePageImageFile(int pageIndex, string fileName);

		/// <summary>方法SavePageImageFileZoom</summary>
		[DispId(12932)]
		void SavePageImageFileZoom(int pageIndex, string fileName, float zoomRate);

		/// <summary>方法SavePageImageToBase64String</summary>
		[DispId(12739)]
		string SavePageImageToBase64String(int pageIndex, string format);

		/// <summary>方法SavePageImageToBase64StringZoom</summary>
		[DispId(12933)]
		string SavePageImageToBase64StringZoom(int pageIndex, string format, float zoomRate);

		/// <summary>方法SaveToAxContentBase64String</summary>
		[DispId(12976)]
		string SaveToAxContentBase64String();

		/// <summary>方法ScrollToCaret</summary>
		[DispId(12395)]
		void ScrollToCaret();

		/// <summary>方法ScrollToCaretExt</summary>
		[DispId(12396)]
		void ScrollToCaretExt(ScrollToViewStyle style);

		/// <summary>方法ScrollToViewPosition</summary>
		[DispId(12721)]
		void ScrollToViewPosition(float viewPosition);

		/// <summary>方法SelectAll</summary>
		[DispId(12397)]
		void SelectAll();

		/// <summary>方法SelectElementById</summary>
		[DispId(12762)]
		bool SelectElementById(string string_0);

		/// <summary>方法SetCommandEnabled</summary>
		[DispId(12850)]
		bool SetCommandEnabled(string commandName, bool enable);

		/// <summary>方法SetCommandEnableHotKey</summary>
		[DispId(12791)]
		bool SetCommandEnableHotKey(string commandName, bool enableHotKey);

		/// <summary>方法SetCommandEnableLowLevel</summary>
		[DispId(12792)]
		bool SetCommandEnableLowLevel(string commandName, bool enable);

		/// <summary>方法SetCurrentDepartmentInfo</summary>
		[DispId(12493)]
		void SetCurrentDepartmentInfo(string departmentID, string departmentName);

		/// <summary>方法SetCustomAttribute</summary>
		[DispId(12916)]
		void SetCustomAttribute(string name, string Value);

		/// <summary>方法SetDocumentParameterEnabled</summary>
		[DispId(12904)]
		void SetDocumentParameterEnabled(string parameterName, bool enabled);

		/// <summary>方法SetDocumentParameterValue</summary>
		[DispId(12398)]
		void SetDocumentParameterValue(string name, object Value);

		/// <summary>方法SetDocumentParameterValueXml</summary>
		[DispId(12399)]
		void SetDocumentParameterValueXml(string name, string xmlText);

		/// <summary>方法SetDomImageByBase64String</summary>
		[DispId(12888)]
		void SetDomImageByBase64String(DCStdImageKey dcstdImageKey_0, string base64String);

		/// <summary>方法SetDomImageByFileName</summary>
		[DispId(12889)]
		void SetDomImageByFileName(DCStdImageKey dcstdImageKey_0, string fileName);

		/// <summary>方法SetElementAttribute</summary>
		[DispId(12823)]
		bool SetElementAttribute(string string_0, string attributeName, string attributeValue);

		/// <summary>方法SetElementChecked</summary>
		[DispId(12840)]
		bool SetElementChecked(string string_0, bool newChecked);

		/// <summary>方法SetElementProperty</summary>
		[DispId(12763)]
		bool SetElementProperty(string string_0, string name, string Value);

		/// <summary>方法SetElementText</summary>
		[DispId(12764)]
		bool SetElementText(string string_0, string text);

		/// <summary>方法SetElementTextByID</summary>
		[DispId(12881)]
		bool SetElementTextByID(string string_0, string text);

		/// <summary>方法SetElementVisible</summary>
		[DispId(12765)]
		bool SetElementVisible(string string_0, bool visible);

		/// <summary>方法SetInputFieldInnerValue</summary>
		[DispId(12897)]
		bool SetInputFieldInnerValue(string string_0, string newValue);

		/// <summary>方法SetInputFieldSelectedIndexs</summary>
		[DispId(12809)]
		bool SetInputFieldSelectedIndexs(string string_0, string indexs);

		/// <summary>方法SetNativeHostedControlHandle</summary>
		[DispId(12878)]
		bool SetNativeHostedControlHandle(string hostedElementID, IntPtr handle);

		/// <summary>方法SetOptionValue</summary>
		[DispId(12826)]
		bool SetOptionValue(string name, string Value);

		/// <summary>方法SetRegisterCode</summary>
		[DispId(12898)]
		void SetRegisterCode(string regCode);

		/// <summary>方法SetResourceStringValue</summary>
		[DispId(12920)]
		void SetResourceStringValue(string name, string Value);

		/// <summary>方法SetStatusText</summary>
		[DispId(12879)]
		void SetStatusText(string text);

		/// <summary>方法SetTableCellText</summary>
		[DispId(12793)]
		bool SetTableCellText(string tableID, int rowIndex, int colIndex, string newText);

		/// <summary>方法SetToMSWordVisualStyle</summary>
		[DispId(12934)]
		void SetToMSWordVisualStyle();

		/// <summary>方法ShowAboutDialog</summary>
		[DispId(12400)]
		void ShowAboutDialog();

		/// <summary>方法StartCourseRecordMode</summary>
		[DispId(12691)]
		void StartCourseRecordMode();

		/// <summary>方法StartLocalAutoSave</summary>
		[DispId(12962)]
		bool StartLocalAutoSave();

		/// <summary>方法StringToColor</summary>
		[DispId(12945)]
		Color StringToColor(string string_0);

		/// <summary>方法SynchroServerTime</summary>
		[DispId(12829)]
		void SynchroServerTime(DateTime serverTime);

		/// <summary>方法SynchroServerTimeByParameters</summary>
		[DispId(12830)]
		void SynchroServerTimeByParameters(int year, int month, int int_0, int hour, int minute, int second);

		/// <summary>方法UIStartEditContent</summary>
		[DispId(12507)]
		bool UIStartEditContent();

		/// <summary>方法UpdateDataSourceForView</summary>
		[DispId(12856)]
		int UpdateDataSourceForView();

		/// <summary>方法UpdateTextCaret</summary>
		[DispId(12401)]
		void UpdateTextCaret();

		/// <summary>方法UpdateTextCaretByElement</summary>
		[DispId(12402)]
		void UpdateTextCaretByElement(XTextElement element);

		/// <summary>方法UpdateTextCaretWithoutScroll</summary>
		[DispId(12403)]
		void UpdateTextCaretWithoutScroll();

		/// <summary>方法UpdateUserInfoSaveTime</summary>
		[DispId(12404)]
		void UpdateUserInfoSaveTime();

		/// <summary>方法UpdateUserInfoSaveTimeExt</summary>
		[DispId(12405)]
		void UpdateUserInfoSaveTimeExt(bool addNewHistoryInfo);

		/// <summary>方法UpdateViewForDataSource</summary>
		[DispId(12857)]
		int UpdateViewForDataSource();

		/// <summary>方法UserLoginByCurrentUserInfo</summary>
		[DispId(12406)]
		bool UserLoginByCurrentUserInfo();

		/// <summary>方法UserLoginByParameter</summary>
		[DispId(12407)]
		bool UserLoginByParameter(string userID, string userName, int permissionLevel);

		/// <summary>方法UserLoginByUserLoginInfo</summary>
		[DispId(12408)]
		bool UserLoginByUserLoginInfo(UserLoginInfo loginInfo, bool updateUI);

		/// <summary>方法Win32SetFoucs</summary>
		[DispId(12409)]
		bool Win32SetFoucs();

		/// <summary>方法WriteDataFromDataSourceToDocument</summary>
		[DispId(12907)]
		int WriteDataFromDataSourceToDocument();

		/// <summary>方法WriteDataFromDataSourceToDocumentSpecifyParameterNames</summary>
		[DispId(12958)]
		int WriteDataFromDataSourceToDocumentSpecifyParameterNames(string parameterNames);

		/// <summary>方法WriteDataFromDocumentToDataSource</summary>
		[DispId(12908)]
		int WriteDataFromDocumentToDataSource();

		/// <summary>方法WriteDataSource</summary>
		[DispId(12410)]
		int WriteDataSource();
	}
}
