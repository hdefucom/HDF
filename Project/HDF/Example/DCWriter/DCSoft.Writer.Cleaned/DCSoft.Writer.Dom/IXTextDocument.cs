using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSoft.Writer.Security;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocument 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("8E2EF4DB-94EE-40C9-B5F1-D81600FCC154")]
	public interface IXTextDocument
	{
		/// <summary>属性Attributes</summary>
		[DispId(29)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性BaseUrl</summary>
		[DispId(30)]
		string BaseUrl
		{
			get;
			set;
		}

		/// <summary>属性Body</summary>
		[DispId(31)]
		XTextDocumentBodyElement Body
		{
			get;
		}

		/// <summary>属性BodyText</summary>
		[DispId(97)]
		string BodyText
		{
			get;
			set;
		}

		/// <summary>属性Bottom</summary>
		[DispId(32)]
		float Bottom
		{
			get;
		}

		/// <summary>属性CheckBoxes</summary>
		[DispId(210)]
		XTextElementList CheckBoxes
		{
			get;
		}

		/// <summary>属性Comments</summary>
		[DispId(33)]
		DocumentCommentList Comments
		{
			get;
			set;
		}

		/// <summary>属性Content</summary>
		[DispId(34)]
		XTextContent Content
		{
			get;
		}

		/// <summary>属性ContentStyles</summary>
		[DispId(35)]
		DocumentContentStyleContainer ContentStyles
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(36)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性CurrentContentElement</summary>
		[DispId(37)]
		XTextDocumentContentElement CurrentContentElement
		{
			get;
			set;
		}

		/// <summary>属性CurrentContentPartyStyle</summary>
		[DispId(38)]
		PageContentPartyStyle CurrentContentPartyStyle
		{
			get;
		}

		/// <summary>属性CurrentElement</summary>
		[DispId(39)]
		XTextElement CurrentElement
		{
			get;
		}

		/// <summary>属性CurrentField</summary>
		[DispId(40)]
		XTextFieldElementBase CurrentField
		{
			get;
		}

		/// <summary>属性CurrentInputField</summary>
		[DispId(98)]
		XTextInputFieldElement CurrentInputField
		{
			get;
		}

		/// <summary>属性CurrentOutlineNode</summary>
		[DispId(138)]
		DocumentOutlineNode CurrentOutlineNode
		{
			get;
		}

		/// <summary>属性CurrentPage</summary>
		[DispId(41)]
		PrintPage CurrentPage
		{
			get;
			set;
		}

		/// <summary>属性CurrentParagraphEOF</summary>
		[DispId(42)]
		XTextParagraphFlagElement CurrentParagraphEOF
		{
			get;
		}

		/// <summary>属性CurrentSection</summary>
		[DispId(43)]
		XTextSectionElement CurrentSection
		{
			get;
		}

		/// <summary>属性CurrentStyleInfo</summary>
		[DispId(44)]
		CurrentContentStyleInfo CurrentStyleInfo
		{
			get;
			set;
		}

		/// <summary>属性CurrentSubDocument</summary>
		[DispId(165)]
		XTextSubDocumentElement CurrentSubDocument
		{
			get;
		}

		/// <summary>属性CurrentTableCell</summary>
		[DispId(45)]
		XTextTableCellElement CurrentTableCell
		{
			get;
		}

		/// <summary>属性CurrentUser</summary>
		[DispId(166)]
		UserHistoryInfo CurrentUser
		{
			get;
		}

		/// <summary>属性DefaultFont</summary>
		[DispId(46)]
		XFontValue DefaultFont
		{
			get;
			set;
		}

		/// <summary>属性DefaultStyle</summary>
		[DispId(47)]
		DocumentContentStyle DefaultStyle
		{
			get;
			set;
		}

		/// <summary>属性DomImageList</summary>
		[DispId(139)]
		DCStdImageList DomImageList
		{
			get;
		}

		/// <summary>属性EditorControl</summary>
		[DispId(48)]
		WriterControl EditorControl
		{
			get;
			set;
		}

		/// <summary>属性EditorVersionString</summary>
		[DispId(49)]
		string EditorVersionString
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(50)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(131)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(118)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(132)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性Fields</summary>
		[DispId(51)]
		XTextElementList Fields
		{
			get;
		}

		/// <summary>属性FileFormat</summary>
		[DispId(52)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(53)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性Footer</summary>
		[DispId(54)]
		XTextDocumentFooterElement Footer
		{
			get;
		}

		/// <summary>属性FooterForFirstPage</summary>
		[DispId(231)]
		XTextDocumentFooterForFirstPageElement FooterForFirstPage
		{
			get;
		}

		/// <summary>属性FormValuesXml</summary>
		[DispId(167)]
		string FormValuesXml
		{
			get;
		}

		/// <summary>属性GlobalPageIndex</summary>
		[DispId(55)]
		int GlobalPageIndex
		{
			get;
		}

		/// <summary>属性GlobalPages</summary>
		[DispId(56)]
		PrintPageCollection GlobalPages
		{
			get;
			set;
		}

		/// <summary>属性Header</summary>
		[DispId(57)]
		XTextDocumentHeaderElement Header
		{
			get;
		}

		/// <summary>属性HeaderForFirstPage</summary>
		[DispId(232)]
		XTextDocumentHeaderForFirstPageElement HeaderForFirstPage
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(58)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性HoverElement</summary>
		[DispId(59)]
		XTextElement HoverElement
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(60)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Images</summary>
		[DispId(61)]
		XTextElementList Images
		{
			get;
		}

		/// <summary>属性Info</summary>
		[DispId(62)]
		DocumentInfo Info
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(168)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(169)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性InputFields</summary>
		[DispId(145)]
		XTextElementList InputFields
		{
			get;
		}

		/// <summary>属性LastAlertInfos</summary>
		[DispId(149)]
		SystemAlertInfoList LastAlertInfos
		{
			get;
		}

		/// <summary>属性LastPrintResult</summary>
		[DispId(121)]
		PrintResult LastPrintResult
		{
			get;
			set;
		}

		/// <summary>属性LocalConfig</summary>
		[DispId(122)]
		LocalConfig LocalConfig
		{
			get;
			set;
		}

		/// <summary>属性LocalExcludeKeywords</summary>
		[DispId(63)]
		string LocalExcludeKeywords
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(108)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性ModifiedInputFields</summary>
		[DispId(146)]
		XTextElementList ModifiedInputFields
		{
			get;
		}

		/// <summary>属性Options</summary>
		[DispId(64)]
		DocumentOptions Options
		{
			get;
			set;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(211)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OutlineNodes</summary>
		[DispId(140)]
		DocumentOutlineNodeList OutlineNodes
		{
			get;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(153)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性PageIndexfix</summary>
		[DispId(133)]
		int PageIndexfix
		{
			get;
			set;
		}

		/// <summary>属性Pages</summary>
		[DispId(66)]
		PrintPageCollection Pages
		{
			get;
			set;
		}

		/// <summary>属性PageSettings</summary>
		[DispId(67)]
		XPageSettings PageSettings
		{
			get;
			set;
		}

		/// <summary>属性PageViewMode</summary>
		[DispId(68)]
		PageViewMode PageViewMode
		{
			get;
			set;
		}

		/// <summary>属性Parameters</summary>
		[DispId(69)]
		DocumentParameterCollection Parameters
		{
			get;
			set;
		}

		/// <summary>属性RadioBoxes</summary>
		[DispId(206)]
		XTextElementList RadioBoxes
		{
			get;
		}

		/// <summary>属性ReadyState</summary>
		[DispId(207)]
		DomReadyStates ReadyState
		{
			get;
		}

		/// <summary>属性RegisterCode</summary>
		[DispId(142)]
		string RegisterCode
		{
			get;
			set;
		}

		/// <summary>属性RTFText</summary>
		[DispId(70)]
		string RTFText
		{
			get;
			set;
		}

		/// <summary>属性SaveDocumentOptionsToFile</summary>
		[DispId(170)]
		bool SaveDocumentOptionsToFile
		{
			get;
			set;
		}

		/// <summary>属性ScriptLanguage</summary>
		[DispId(236)]
		ScriptLanguageType ScriptLanguage
		{
			get;
			set;
		}

		/// <summary>属性ScriptText</summary>
		[DispId(71)]
		string ScriptText
		{
			get;
			set;
		}

		/// <summary>属性Sections</summary>
		[DispId(72)]
		XTextElementList Sections
		{
			get;
		}

		/// <summary>属性Selection</summary>
		[DispId(73)]
		XTextSelection Selection
		{
			get;
		}

		/// <summary>属性ServerObject</summary>
		[DispId(74)]
		object ServerObject
		{
			get;
			set;
		}

		/// <summary>属性SingleSelectedElement</summary>
		[DispId(75)]
		XTextElement SingleSelectedElement
		{
			get;
		}

		/// <summary>属性SpecialTag</summary>
		[DispId(76)]
		string SpecialTag
		{
			get;
			set;
		}

		/// <summary>属性States</summary>
		[DispId(99)]
		DocumentStates States
		{
			get;
			set;
		}

		/// <summary>属性SubDocuments</summary>
		[DispId(141)]
		XTextElementList SubDocuments
		{
			get;
		}

		/// <summary>属性Tables</summary>
		[DispId(77)]
		XTextElementList Tables
		{
			get;
		}

		/// <summary>属性TagValue</summary>
		[DispId(100)]
		object TagValue
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(78)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(152)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(79)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(92)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性UserHistories</summary>
		[DispId(80)]
		UserHistoryInfoList UserHistories
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(81)]
		float Width
		{
			get;
			set;
		}

		/// <summary>属性XMLText</summary>
		[DispId(82)]
		string XMLText
		{
			get;
			set;
		}

		/// <summary>属性XMLTextUnFormatted</summary>
		[DispId(93)]
		string XMLTextUnFormatted
		{
			get;
		}

		/// <summary>方法AllocElementID</summary>
		[DispId(205)]
		bool AllocElementID(string prefix, XTextElement element);

		/// <summary>方法AppendChildElement</summary>
		[DispId(186)]
		bool AppendChildElement(XTextElement element);

		/// <summary>方法AppendSubDocument</summary>
		[DispId(154)]
		void AppendSubDocument(XTextSubDocumentElement newSubDoc);

		/// <summary>方法Clear</summary>
		[DispId(2)]
		void Clear();

		/// <summary>方法Clone</summary>
		[DispId(94)]
		XTextElement Clone(bool Deeply);

		/// <summary>方法CreateComment</summary>
		[DispId(150)]
		DocumentComment CreateComment();

		/// <summary>方法CreateDocumentFragment</summary>
		[DispId(155)]
		XTextDocument CreateDocumentFragment();

		/// <summary>方法CreateElement</summary>
		[DispId(151)]
		XTextElement CreateElement(string typeName);

		/// <summary>方法CreateElementByXMLFragment</summary>
		[DispId(147)]
		XTextElement CreateElementByXMLFragment(string string_0);

		/// <summary>方法CreateTextElements</summary>
		[DispId(3)]
		XTextElementList CreateTextElements(string strText, DocumentContentStyle paragraphStyle, DocumentContentStyle textStyle);

		/// <summary>方法CreateTextElementsExt</summary>
		[DispId(4)]
		XTextElementList CreateTextElementsExt(string strText, DocumentContentStyle paragraphStyle, DocumentContentStyle textStyle, bool enablePermission);

		/// <summary>方法CreateTextNode</summary>
		[DispId(156)]
		XTextStringElement CreateTextNode(string string_0);

		/// <summary>方法DetectValueBindingModified</summary>
		[DispId(233)]
		DetectResultForValueBindingModifiedList DetectValueBindingModified();

		/// <summary>方法ExecuteLayout</summary>
		[DispId(5)]
		void ExecuteLayout();

		/// <summary>方法ExecuteTableSubfield</summary>
		[DispId(215)]
		bool ExecuteTableSubfield(bool updateView);

		/// <summary>方法FillDataSource</summary>
		[DispId(135)]
		int FillDataSource(bool fastMode);

		/// <summary>方法GetAllElements</summary>
		[DispId(101)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(107)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(87)]
		string GetAttribute(string name);

		/// <summary>方法GetBindingDataSources</summary>
		[DispId(187)]
		string GetBindingDataSources();

		/// <summary>方法GetCheckBoxElementsSpecifyName</summary>
		[DispId(143)]
		XTextElementList GetCheckBoxElementsSpecifyName(string name);

		/// <summary>方法GetCheckedValueList</summary>
		[DispId(144)]
		string GetCheckedValueList(string spliter, bool includeCheckbox, bool includeRadio, bool includeElementID, bool includeElementName);

		/// <summary>方法GetCurrentElementByTypeName</summary>
		[DispId(6)]
		XTextElement GetCurrentElementByTypeName(string typeName);

		/// <summary>方法GetDataSourceBindingDescriptions</summary>
		[DispId(188)]
		DataSourceBindingDescriptionList GetDataSourceBindingDescriptions();

		/// <summary>方法GetDataSourceBindingDescriptionsXML</summary>
		[DispId(175)]
		string GetDataSourceBindingDescriptionsXML();

		/// <summary>方法GetDetectValueBindingModifiedMessage</summary>
		[DispId(234)]
		string GetDetectValueBindingModifiedMessage();

		/// <summary>方法GetDocumentParameterValueXml</summary>
		[DispId(102)]
		string GetDocumentParameterValueXml(string name);

		/// <summary>方法GetDocumnetParameterValue</summary>
		[DispId(103)]
		object GetDocumnetParameterValue(string name);

		/// <summary>方法GetElementAt</summary>
		[DispId(7)]
		XTextElement GetElementAt(float float_0, float float_1, bool strict);

		/// <summary>方法GetElementAttribute</summary>
		[DispId(136)]
		string GetElementAttribute(string string_0, string attributeName);

		/// <summary>方法GetElementById</summary>
		[DispId(8)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementInnerXmlByID</summary>
		[DispId(179)]
		string GetElementInnerXmlByID(string string_0);

		/// <summary>方法GetElementOuterXmlByID</summary>
		[DispId(180)]
		string GetElementOuterXmlByID(string string_0);

		/// <summary>方法GetElementProperty</summary>
		[DispId(123)]
		string GetElementProperty(string string_0, string name);

		/// <summary>方法GetElementsById</summary>
		[DispId(113)]
		XTextElementList GetElementsById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(9)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(10)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetElementTextByID</summary>
		[DispId(171)]
		string GetElementTextByID(string string_0);

		/// <summary>方法GetElementVisible</summary>
		[DispId(124)]
		bool GetElementVisible(string string_0);

		/// <summary>方法GetElementXMLFragmentByID</summary>
		[DispId(181)]
		string GetElementXMLFragmentByID(string string_0);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(89)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetFormValue</summary>
		[DispId(11)]
		string GetFormValue(string name);

		/// <summary>方法GetInputFieldInnerValue</summary>
		[DispId(176)]
		string GetInputFieldInnerValue(string string_0);

		/// <summary>方法GetNextElementByTypeName</summary>
		[DispId(13)]
		XTextElement GetNextElementByTypeName(XTextElement startElement, string nextElementTypeName);

		/// <summary>方法GetNowDateTime</summary>
		[DispId(183)]
		DateTime GetNowDateTime();

		/// <summary>方法GetParameterEnabled</summary>
		[DispId(184)]
		bool GetParameterEnabled(string parameterName);

		/// <summary>方法GetParameterValue</summary>
		[DispId(15)]
		object GetParameterValue(string name);

		/// <summary>方法GetRTFText</summary>
		[DispId(16)]
		string GetRTFText(bool IncludeSelectionOnly);

		/// <summary>方法GetStyleIndexByString</summary>
		[DispId(230)]
		int GetStyleIndexByString(string styleString);

		/// <summary>方法GetSubDoumentContentXmlByID</summary>
		[DispId(182)]
		string GetSubDoumentContentXmlByID(string string_0);

		/// <summary>方法GetTableCell</summary>
		[DispId(112)]
		XTextTableCellElement GetTableCell(string tableID, int rowIndex, int colIndex);

		/// <summary>方法GetTableCellText</summary>
		[DispId(125)]
		string GetTableCellText(string tableID, int rowIndex, int colIndex);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(172)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(114)]
		bool HasAttribute(string name);

		/// <summary>方法ImportElements</summary>
		[DispId(17)]
		void ImportElements(XTextElementList elements);

		/// <summary>方法InsertSubDocuentAtCurrentPosition</summary>
		[DispId(157)]
		void InsertSubDocuentAtCurrentPosition(XTextSubDocumentElement newSubDoc, bool insertUp);

		/// <summary>方法Load</summary>
		[DispId(18)]
		void Load(string fileName, string format);

		/// <summary>方法LoadDocumentInstance</summary>
		[DispId(19)]
		void LoadDocumentInstance(string fileName, string format, XTextDocument instance);

		/// <summary>方法LoadFromBase64String</summary>
		[DispId(83)]
		void LoadFromBase64String(string text, string format);

		/// <summary>方法LoadFromBase64StringFastMode</summary>
		[DispId(216)]
		void LoadFromBase64StringFastMode(string text, string format);

		/// <summary>方法LoadFromFile</summary>
		[DispId(20)]
		void LoadFromFile(string fileName, string format);

		/// <summary>方法LoadFromFileFastMode</summary>
		[DispId(217)]
		void LoadFromFileFastMode(string fileName, string format);

		/// <summary>方法LoadFromString</summary>
		[DispId(84)]
		void LoadFromString(string text, string format);

		/// <summary>方法LoadFromStringFastMode</summary>
		[DispId(218)]
		void LoadFromStringFastMode(string text, string format);

		/// <summary>方法LoadUseAppendModeFromBase64String</summary>
		[DispId(115)]
		void LoadUseAppendModeFromBase64String(string string_0, string format);

		/// <summary>方法LoadUseAppendModeFromFileName</summary>
		[DispId(116)]
		void LoadUseAppendModeFromFileName(string fileName, string format);

		/// <summary>方法LoadUseAppendModeFromString</summary>
		[DispId(117)]
		void LoadUseAppendModeFromString(string string_0, string format);

		/// <summary>方法LockContentByElement</summary>
		[DispId(158)]
		bool LockContentByElement(XTextContainerElement element, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法LockContentByElementID</summary>
		[DispId(159)]
		bool LockContentByElementID(string elementID, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法LockContentByTableRow</summary>
		[DispId(160)]
		bool LockContentByTableRow(string tableID, int rowIndexBase0, string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(220)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBGetElementById</summary>
		[DispId(225)]
		XTextElement PBGetElementById(ref string string_0);

		/// <summary>方法PBGetElementsById</summary>
		[DispId(226)]
		XTextElementList PBGetElementsById(ref string string_0);

		/// <summary>方法PBGetElementsByName</summary>
		[DispId(227)]
		XTextElementList PBGetElementsByName(ref string name);

		/// <summary>方法PBGetElementsByTypeName</summary>
		[DispId(228)]
		XTextElementList PBGetElementsByTypeName(ref string name);

		/// <summary>方法PBLoadFromString</summary>
		[DispId(223)]
		void PBLoadFromString(ref string text, ref string format);

		/// <summary>方法PBSaveToString</summary>
		[DispId(229)]
		string PBSaveToString(ref string format);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(221)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法PBSetElementTextByID</summary>
		[DispId(222)]
		bool PBSetElementTextByID(ref string string_0, ref string text);

		/// <summary>方法PBSetTableCellText</summary>
		[DispId(224)]
		bool PBSetTableCellText(ref string tableID, ref int rowIndex, ref int colIndex, ref string newText);

		/// <summary>方法RefreshInnerView</summary>
		[DispId(219)]
		void RefreshInnerView(bool fastMode);

		/// <summary>方法RefreshPages</summary>
		[DispId(21)]
		void RefreshPages();

		/// <summary>方法RefreshSize</summary>
		[DispId(22)]
		void RefreshSize(DocumentPaintEventArgs args);

		/// <summary>方法RefreshSize_2</summary>
		[DispId(91)]
		void RefreshSize_2();

		/// <summary>方法RefreshSizeWithoutParamter</summary>
		[DispId(23)]
		void RefreshSizeWithoutParamter();

		/// <summary>方法RejectUserTrace</summary>
		[DispId(174)]
		bool RejectUserTrace();

		/// <summary>方法ResetFormValue</summary>
		[DispId(148)]
		bool ResetFormValue();

		/// <summary>方法Save</summary>
		[DispId(24)]
		void Save(string fileName, string format);

		/// <summary>方法SaveLongImageFile</summary>
		[DispId(191)]
		void SaveLongImageFile(string fileName);

		/// <summary>方法SaveLongImageFileZoom</summary>
		[DispId(208)]
		void SaveLongImageFileZoom(string fileName, float zoomRate);

		/// <summary>方法SaveLongImageToBase64String</summary>
		[DispId(192)]
		string SaveLongImageToBase64String(string format);

		/// <summary>方法SaveLongImageToBase64StringZoom</summary>
		[DispId(212)]
		string SaveLongImageToBase64StringZoom(string format, float zoomRate);

		/// <summary>方法SavePageImageFile</summary>
		[DispId(109)]
		void SavePageImageFile(int pageIndex, string fileName);

		/// <summary>方法SavePageImageFileZoom</summary>
		[DispId(209)]
		void SavePageImageFileZoom(int pageIndex, string fileName, float zoomRate);

		/// <summary>方法SavePageImageToBase64String</summary>
		[DispId(110)]
		string SavePageImageToBase64String(int pageIndex, string format);

		/// <summary>方法SavePageImageToBase64StringZoom</summary>
		[DispId(213)]
		string SavePageImageToBase64StringZoom(int pageIndex, string format, float zoomRate);

		/// <summary>方法SaveToBase64String</summary>
		[DispId(85)]
		string SaveToBase64String(string format);

		/// <summary>方法SaveToBinary</summary>
		[DispId(25)]
		byte[] SaveToBinary(string format);

		/// <summary>方法SaveToFile</summary>
		[DispId(26)]
		void SaveToFile(string fileName, string format);

		/// <summary>方法SaveToString</summary>
		[DispId(86)]
		string SaveToString(string format);

		/// <summary>方法Select</summary>
		[DispId(27)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(90)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(161)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(162)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetDocumentParameterValue</summary>
		[DispId(163)]
		bool SetDocumentParameterValue(string name, object newValue);

		/// <summary>方法SetDocumentParameterValueXml</summary>
		[DispId(104)]
		void SetDocumentParameterValueXml(string name, string xmlText);

		/// <summary>方法SetElementAttribute</summary>
		[DispId(137)]
		bool SetElementAttribute(string string_0, string attributeName, string attributeValue);

		/// <summary>方法SetElementProperty</summary>
		[DispId(126)]
		bool SetElementProperty(string string_0, string name, string Value);

		/// <summary>方法SetElementTextByID</summary>
		[DispId(173)]
		bool SetElementTextByID(string string_0, string text);

		/// <summary>方法SetElementVisible</summary>
		[DispId(128)]
		bool SetElementVisible(string string_0, bool visible);

		/// <summary>方法SetFormValue</summary>
		[DispId(177)]
		bool SetFormValue(string name, string Value);

		/// <summary>方法SetInputFieldInnerValue</summary>
		[DispId(178)]
		bool SetInputFieldInnerValue(string string_0, string newValue);

		/// <summary>方法SetInputFieldSelectedIndexs</summary>
		[DispId(129)]
		bool SetInputFieldSelectedIndexs(string string_0, string indexs);

		/// <summary>方法SetParameterEnabled</summary>
		[DispId(185)]
		void SetParameterEnabled(string parameterName, bool enabled);

		/// <summary>方法SetParameterValue</summary>
		[DispId(105)]
		bool SetParameterValue(string name, object newValue);

		/// <summary>方法SetTableCellText</summary>
		[DispId(130)]
		bool SetTableCellText(string tableID, int rowIndex, int colIndex, string newText);

		/// <summary>方法SetVisibleForElementMarkAutoHide</summary>
		[DispId(120)]
		XTextElementList SetVisibleForElementMarkAutoHide(bool visible, bool logUndo);

		/// <summary>方法UpdateUserInfoSaveTime</summary>
		[DispId(28)]
		void UpdateUserInfoSaveTime(bool addNewHistoryInfo);

		/// <summary>方法UpdateViewForDataSource</summary>
		[DispId(164)]
		int UpdateViewForDataSource();

		/// <summary>方法ValueValidate</summary>
		[DispId(95)]
		ValueValidateResultList ValueValidate();

		/// <summary>方法ValueValidateWithCreateDocumentComments</summary>
		[DispId(235)]
		ValueValidateResultList ValueValidateWithCreateDocumentComments();

		/// <summary>方法WriteDataFromDataSourceToDocument</summary>
		[DispId(189)]
		int WriteDataFromDataSourceToDocument();

		/// <summary>方法WriteDataFromDataSourceToDocumentSpecifyParameterNames</summary>
		[DispId(214)]
		int WriteDataFromDataSourceToDocumentSpecifyParameterNames(string parameterNames);

		/// <summary>方法WriteDataFromDocumentToDataSource</summary>
		[DispId(190)]
		int WriteDataFromDocumentToDataSource();

		/// <summary>方法WriteDataSource</summary>
		[DispId(96)]
		int WriteDataSource();
	}
}
