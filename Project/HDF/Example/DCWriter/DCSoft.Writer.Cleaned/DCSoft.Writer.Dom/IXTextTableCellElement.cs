using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Data;
using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextTableCellElement 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("27BA9E41-2E8E-408F-B95A-0709630742AB")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextTableCellElement
	{
		/// <summary>属性AbsTop</summary>
		[DispId(123)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性AcceptChildElementTypes2</summary>
		[DispId(95)]
		ElementType AcceptChildElementTypes2
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(83)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性AutoFixFontSizeMode</summary>
		[DispId(110)]
		ContentAutoFixFontSizeMode AutoFixFontSizeMode
		{
			get;
			set;
		}

		/// <summary>属性BottomVisibleCell</summary>
		[DispId(23)]
		XTextTableCellElement BottomVisibleCell
		{
			get;
		}

		/// <summary>属性CellID</summary>
		[DispId(24)]
		string CellID
		{
			get;
		}

		/// <summary>属性ColIndex</summary>
		[DispId(25)]
		int ColIndex
		{
			get;
		}

		/// <summary>属性ColSpan</summary>
		[DispId(26)]
		int ColSpan
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(27)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(28)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(29)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(115)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentPartyStyle</summary>
		[DispId(84)]
		PageContentPartyStyle ContentPartyStyle
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(74)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(30)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性CopySource</summary>
		[DispId(31)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(32)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性EditorText</summary>
		[DispId(85)]
		string EditorText
		{
			get;
			set;
		}

		/// <summary>属性EditorTextExt</summary>
		[DispId(86)]
		string EditorTextExt
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(33)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(96)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(87)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(102)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性Events</summary>
		[DispId(34)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(35)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Expression</summary>
		[DispId(36)]
		string Expression
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(111)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(38)]
		bool Focused
		{
			get;
		}

		/// <summary>属性GridLine</summary>
		[DispId(118)]
		DCGridLineInfo GridLine
		{
			get;
			set;
		}

		/// <summary>属性HasContentElement</summary>
		[DispId(39)]
		bool HasContentElement
		{
			get;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(40)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(41)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(42)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(105)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(106)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(43)]
		bool IsEmpty
		{
			get;
			set;
		}

		/// <summary>属性IsOverrided</summary>
		[DispId(44)]
		bool IsOverrided
		{
			get;
		}

		/// <summary>属性LastChild</summary>
		[DispId(112)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性LeftVisibleCell</summary>
		[DispId(45)]
		XTextTableCellElement LeftVisibleCell
		{
			get;
		}

		/// <summary>属性MaxInputLength</summary>
		[DispId(125)]
		int MaxInputLength
		{
			get;
			set;
		}

		/// <summary>属性MirrorViewForCrossPage</summary>
		[DispId(126)]
		bool MirrorViewForCrossPage
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(89)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性MoveFocusHotKey</summary>
		[DispId(90)]
		MoveFocusHotKeys MoveFocusHotKey
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(81)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(107)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(108)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OverrideCell</summary>
		[DispId(46)]
		XTextTableCellElement OverrideCell
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(47)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerColumn</summary>
		[DispId(100)]
		XTextTableColumnElement OwnerColumn
		{
			get;
			set;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(49)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLastPageIndex</summary>
		[DispId(131)]
		int OwnerLastPageIndex
		{
			get;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(50)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(51)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(116)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerRow</summary>
		[DispId(52)]
		XTextTableRowElement OwnerRow
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(53)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性OwnerTable</summary>
		[DispId(54)]
		XTextTableElement OwnerTable
		{
			get;
		}

		/// <summary>属性ParagraphsEOFs</summary>
		[DispId(55)]
		XTextElementList ParagraphsEOFs
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(56)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(57)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(132)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性PrivateContent</summary>
		[DispId(58)]
		XTextElementList PrivateContent
		{
			get;
		}

		/// <summary>属性PrivateLines</summary>
		[DispId(59)]
		XTextLineList PrivateLines
		{
			get;
		}

		/// <summary>属性PropertyExpressions</summary>
		[DispId(119)]
		PropertyExpressionInfoList PropertyExpressions
		{
			get;
			set;
		}

		/// <summary>属性RightVisibleCell</summary>
		[DispId(60)]
		XTextTableCellElement RightVisibleCell
		{
			get;
		}

		/// <summary>属性RowIndex</summary>
		[DispId(61)]
		int RowIndex
		{
			get;
		}

		/// <summary>属性RowSpan</summary>
		[DispId(62)]
		int RowSpan
		{
			get;
			set;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(63)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(64)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性SlantSplitLineStyle</summary>
		[DispId(65)]
		RectangleSlantSplitStyle SlantSplitLineStyle
		{
			get;
			set;
		}

		/// <summary>属性SpecifyFixedLineHeight</summary>
		[DispId(99)]
		float SpecifyFixedLineHeight
		{
			get;
			set;
		}

		/// <summary>属性StressBorder</summary>
		[DispId(98)]
		bool StressBorder
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(66)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(67)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(68)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(69)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(124)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性TopVisibleCell</summary>
		[DispId(70)]
		XTextTableCellElement TopVisibleCell
		{
			get;
		}

		/// <summary>属性TypeName</summary>
		[DispId(71)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(80)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueBinding</summary>
		[DispId(127)]
		XDataBinding ValueBinding
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(92)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(73)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法AppendChildElement</summary>
		[DispId(2)]
		bool AppendChildElement(XTextElement element);

		/// <summary>方法BeginSetStyle</summary>
		[DispId(3)]
		bool BeginSetStyle();

		/// <summary>方法Clear</summary>
		[DispId(4)]
		void Clear();

		/// <summary>方法CommitUserTrace</summary>
		[DispId(101)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(5)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(6)]
		void EditorRefreshView();

		/// <summary>方法EditorSetBorderColor</summary>
		[DispId(91)]
		bool EditorSetBorderColor(DCDirection direction, bool borderVisible, Color color);

		/// <summary>方法EditorSetCellWidthSingle</summary>
		[DispId(93)]
		bool EditorSetCellWidthSingle(float newWidth, bool logUndo);

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(75)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(76)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(117)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法EditorSetStyleDeeply</summary>
		[DispId(104)]
		bool EditorSetStyleDeeply(DocumentContentStyle style);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(7)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(8)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(9)]
		bool EndSetStyle();

		/// <summary>方法FixElements</summary>
		[DispId(10)]
		void FixElements();

		/// <summary>方法Focus</summary>
		[DispId(11)]
		void Focus();

		/// <summary>方法GetAllElements</summary>
		[DispId(82)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(88)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(77)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(12)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementByIdExt</summary>
		[DispId(122)]
		XTextElement GetElementByIdExt(string string_0, bool idAttributeOnly);

		/// <summary>方法GetElementsByName</summary>
		[DispId(13)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(14)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(78)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(109)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(94)]
		bool HasAttribute(string name);

		/// <summary>方法InsertAfter</summary>
		[DispId(120)]
		bool InsertAfter(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertBefore</summary>
		[DispId(121)]
		bool InsertBefore(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertChildElement</summary>
		[DispId(15)]
		bool InsertChildElement(int index, XTextElement element);

		/// <summary>方法InvalidateView</summary>
		[DispId(16)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(128)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(129)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(17)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(18)]
		bool Select();

		/// <summary>方法SelectFirstLine</summary>
		[DispId(103)]
		bool SelectFirstLine();

		/// <summary>方法SetAttribute</summary>
		[DispId(79)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(113)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(114)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetEditorText</summary>
		[DispId(19)]
		bool SetEditorText(SetContainerTextArgs args);

		/// <summary>方法SetEditorTextExt</summary>
		[DispId(20)]
		bool SetEditorTextExt(string newText, DomAccessFlags flags, bool disablePermissioin, bool updateContent);

		/// <summary>方法SetInnerTextFast</summary>
		[DispId(21)]
		XTextElementList SetInnerTextFast(string string_0);

		/// <summary>方法SetTextRawDOM</summary>
		[DispId(130)]
		void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex);
	}
}
