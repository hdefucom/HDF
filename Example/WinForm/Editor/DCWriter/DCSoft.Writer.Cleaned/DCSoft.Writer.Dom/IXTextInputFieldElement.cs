using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Expression;
using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextInputFieldElement 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("7F013F6B-FFF8-3B8B-BD4E-4EB9FE965505")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextInputFieldElement
	{
		/// <summary>属性AbsLeft</summary>
		[DispId(95)]
		float AbsLeft
		{
			get;
		}

		/// <summary>属性AbsTop</summary>
		[DispId(96)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性AcceptChildElementTypes2</summary>
		[DispId(19)]
		ElementType AcceptChildElementTypes2
		{
			get;
			set;
		}

		/// <summary>属性AcceptTab</summary>
		[DispId(20)]
		bool AcceptTab
		{
			get;
			set;
		}

		/// <summary>属性Alignment</summary>
		[DispId(123)]
		StringAlignment Alignment
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(21)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性AutoSetSpellCodeInDropdownList</summary>
		[DispId(140)]
		bool AutoSetSpellCodeInDropdownList
		{
			get;
			set;
		}

		/// <summary>属性BackgroundText</summary>
		[DispId(22)]
		string BackgroundText
		{
			get;
			set;
		}

		/// <summary>属性BackgroundTextColor</summary>
		[DispId(124)]
		Color BackgroundTextColor
		{
			get;
			set;
		}

		/// <summary>属性BackgroundTextItalic</summary>
		[DispId(152)]
		DCBooleanValueHasDefault BackgroundTextItalic
		{
			get;
			set;
		}

		/// <summary>属性BorderElementColor</summary>
		[DispId(125)]
		Color BorderElementColor
		{
			get;
			set;
		}

		/// <summary>属性BorderTextPosition</summary>
		[DispId(160)]
		DCBorderTextPosition BorderTextPosition
		{
			get;
			set;
		}

		/// <summary>属性BorderVisible</summary>
		[DispId(103)]
		DCVisibleState BorderVisible
		{
			get;
			set;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(23)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentEditable</summary>
		[DispId(24)]
		bool ContentEditable
		{
			get;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(25)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(135)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(26)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(27)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性CopySource</summary>
		[DispId(28)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性CustomValueEditorTypeName</summary>
		[DispId(29)]
		string CustomValueEditorTypeName
		{
			get;
			set;
		}

		/// <summary>属性DataName</summary>
		[DispId(156)]
		string DataName
		{
			get;
			set;
		}

		/// <summary>属性DefaultEventExpression</summary>
		[DispId(30)]
		string DefaultEventExpression
		{
			get;
			set;
		}

		/// <summary>属性DefaultSelectedIndexs</summary>
		[DispId(151)]
		string DefaultSelectedIndexs
		{
			get;
			set;
		}

		/// <summary>属性DefaultValueForValueBinding</summary>
		[DispId(155)]
		string DefaultValueForValueBinding
		{
			get;
			set;
		}

		/// <summary>属性DefaultValueType</summary>
		[DispId(131)]
		DCDefaultValueType DefaultValueType
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(31)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DispalyTypeName</summary>
		[DispId(85)]
		string DispalyTypeName
		{
			get;
		}

		/// <summary>属性DisplayFormat</summary>
		[DispId(32)]
		ValueFormater DisplayFormat
		{
			get;
			set;
		}

		/// <summary>属性DisplayName</summary>
		[DispId(86)]
		string DisplayName
		{
			get;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(33)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性EditorActiveMode</summary>
		[DispId(34)]
		ValueEditorActiveMode EditorActiveMode
		{
			get;
			set;
		}

		/// <summary>属性EditorText</summary>
		[DispId(35)]
		string EditorText
		{
			get;
			set;
		}

		/// <summary>属性EditorTextExt</summary>
		[DispId(36)]
		string EditorTextExt
		{
			get;
			set;
		}

		/// <summary>属性ElementIDForEditableDependent</summary>
		[DispId(146)]
		string ElementIDForEditableDependent
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(116)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(38)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(111)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnableHighlight</summary>
		[DispId(39)]
		EnableState EnableHighlight
		{
			get;
			set;
		}

		/// <summary>属性EnableLastSelectedListItems</summary>
		[DispId(154)]
		bool EnableLastSelectedListItems
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(102)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableUserEditInnerValue</summary>
		[DispId(153)]
		bool EnableUserEditInnerValue
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(118)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性EndBorderText</summary>
		[DispId(119)]
		string EndBorderText
		{
			get;
			set;
		}

		/// <summary>属性EndElement</summary>
		[DispId(40)]
		XTextFieldBorderElement EndElement
		{
			get;
			set;
		}

		/// <summary>属性EventExpressions</summary>
		[DispId(41)]
		EventExpressionInfoList EventExpressions
		{
			get;
			set;
		}

		/// <summary>属性Events</summary>
		[DispId(97)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(42)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FastInputMode</summary>
		[DispId(158)]
		DCFastInputMode FastInputMode
		{
			get;
			set;
		}

		/// <summary>属性FieldSettings</summary>
		[DispId(44)]
		InputFieldSettings FieldSettings
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(136)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性FirstContentElement</summary>
		[DispId(45)]
		XTextElement FirstContentElement
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(46)]
		bool Focused
		{
			get;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(47)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(48)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(49)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerText</summary>
		[DispId(142)]
		string InnerText
		{
			get;
			set;
		}

		/// <summary>属性InnerValue</summary>
		[DispId(50)]
		string InnerValue
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(127)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(129)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性IsLogicDeleted</summary>
		[DispId(51)]
		bool IsLogicDeleted
		{
			get;
		}

		/// <summary>属性LabelText</summary>
		[DispId(52)]
		string LabelText
		{
			get;
			set;
		}

		/// <summary>属性LastChild</summary>
		[DispId(137)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性LastContentElement</summary>
		[DispId(98)]
		XTextElement LastContentElement
		{
			get;
		}

		/// <summary>属性LastSelectedListItems</summary>
		[DispId(143)]
		ListItemCollection LastSelectedListItems
		{
			get;
			set;
		}

		/// <summary>属性LinkListBinding</summary>
		[DispId(105)]
		LinkListBindingInfo LinkListBinding
		{
			get;
			set;
		}

		/// <summary>属性MaxInputLength</summary>
		[DispId(159)]
		int MaxInputLength
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(99)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性MoveFocusHotKey</summary>
		[DispId(53)]
		MoveFocusHotKeys MoveFocusHotKey
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(54)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(55)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(128)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(130)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(56)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(57)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(58)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(59)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(138)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerParagraphEOF</summary>
		[DispId(60)]
		XTextParagraphFlagElement OwnerParagraphEOF
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(61)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(62)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(63)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(165)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性PropertyExpressions</summary>
		[DispId(145)]
		PropertyExpressionInfoList PropertyExpressions
		{
			get;
			set;
		}

		/// <summary>属性Readonly</summary>
		[DispId(64)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性RuntimeContentReadonly</summary>
		[DispId(65)]
		bool RuntimeContentReadonly
		{
			get;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(66)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(67)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性SelectedIndex</summary>
		[DispId(107)]
		int SelectedIndex
		{
			get;
			set;
		}

		/// <summary>属性SelectedSpellCode</summary>
		[DispId(147)]
		string SelectedSpellCode
		{
			get;
			set;
		}

		/// <summary>属性ShowInputFieldStateTag</summary>
		[DispId(148)]
		DCBooleanValue ShowInputFieldStateTag
		{
			get;
			set;
		}

		/// <summary>属性SpecifyWidth</summary>
		[DispId(68)]
		float SpecifyWidth
		{
			get;
			set;
		}

		/// <summary>属性StartBorderText</summary>
		[DispId(120)]
		string StartBorderText
		{
			get;
			set;
		}

		/// <summary>属性StartElement</summary>
		[DispId(69)]
		XTextFieldBorderElement StartElement
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(70)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(71)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性TabIndex</summary>
		[DispId(72)]
		int TabIndex
		{
			get;
			set;
		}

		/// <summary>属性TabStop</summary>
		[DispId(73)]
		bool TabStop
		{
			get;
			set;
		}

		/// <summary>属性TagValue</summary>
		[DispId(100)]
		object TagValue
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(74)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TextColor</summary>
		[DispId(126)]
		Color TextColor
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(75)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(76)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UnitText</summary>
		[DispId(77)]
		string UnitText
		{
			get;
			set;
		}

		/// <summary>属性UserEditable</summary>
		[DispId(78)]
		bool UserEditable
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(92)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValidateStyle</summary>
		[DispId(79)]
		ValueValidateStyle ValidateStyle
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(80)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(106)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性ViewEncryptType</summary>
		[DispId(81)]
		ContentViewEncryptType ViewEncryptType
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(82)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(83)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性VisibleExpression</summary>
		[DispId(115)]
		string VisibleExpression
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(84)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法AppendChildElement</summary>
		[DispId(144)]
		bool AppendChildElement(XTextElement element);

		/// <summary>方法BeginEditValue</summary>
		[DispId(112)]
		bool BeginEditValue();

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法BelongToDocumentDom</summary>
		[DispId(93)]
		bool BelongToDocumentDom(XTextDocument document, bool checkLogicDelete);

		/// <summary>方法Clone</summary>
		[DispId(94)]
		XTextElement Clone(bool Deeply);

		/// <summary>方法CommitUserTrace</summary>
		[DispId(117)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorDelete</summary>
		[DispId(4)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(5)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(87)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(88)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(121)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法EditorSetStyleDeeply</summary>
		[DispId(122)]
		bool EditorSetStyleDeeply(DocumentContentStyle style);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(6)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(7)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(8)]
		bool EndSetStyle();

		/// <summary>方法EndSetStyleDeeply</summary>
		[DispId(108)]
		bool EndSetStyleDeeply();

		/// <summary>方法EndSetStyleWithLogUndo</summary>
		[DispId(109)]
		bool EndSetStyleWithLogUndo();

		/// <summary>方法EnsureHasListItemsInstance</summary>
		[DispId(132)]
		void EnsureHasListItemsInstance();

		/// <summary>方法Focus</summary>
		[DispId(9)]
		void Focus();

		/// <summary>方法FocusWithoutActiveEditor</summary>
		[DispId(113)]
		void FocusWithoutActiveEditor();

		/// <summary>方法GetAllElements</summary>
		[DispId(101)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(104)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(89)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(10)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(11)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(12)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(90)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetNextFocusFieldElement</summary>
		[DispId(114)]
		XTextInputFieldElementBase GetNextFocusFieldElement();

		/// <summary>方法GetXMLFragment</summary>
		[DispId(141)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(110)]
		bool HasAttribute(string name);

		/// <summary>方法InsertAfter</summary>
		[DispId(149)]
		bool InsertAfter(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertBefore</summary>
		[DispId(150)]
		bool InsertBefore(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InvalidateView</summary>
		[DispId(13)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(162)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(163)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(157)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(14)]
		bool Select();

		/// <summary>方法SelectWithoutBorderElement</summary>
		[DispId(139)]
		bool SelectWithoutBorderElement();

		/// <summary>方法SetAttribute</summary>
		[DispId(91)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(133)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(134)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetEditorText</summary>
		[DispId(15)]
		bool SetEditorText(SetContainerTextArgs args);

		/// <summary>方法SetEditorTextExt</summary>
		[DispId(16)]
		bool SetEditorTextExt(string newText, DomAccessFlags flags, bool disablePermissioin, bool updateContent);

		/// <summary>方法SetInnerTextFast</summary>
		[DispId(17)]
		XTextElementList SetInnerTextFast(string string_0);

		/// <summary>方法SetTextRawDOM</summary>
		[DispId(164)]
		void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex);

		/// <summary>方法UpdateInnerValue</summary>
		[DispId(161)]
		void UpdateInnerValue(bool updateParent);
	}
}
