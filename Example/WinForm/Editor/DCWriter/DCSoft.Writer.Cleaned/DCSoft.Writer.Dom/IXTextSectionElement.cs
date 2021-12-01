using DCSoft.Drawing;
using DCSoft.Printing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextSectionElement 的COM接口</summary>
	[Browsable(false)]
	[Guid("EEE04FE8-950D-4D23-8F0C-1CE6A0DDFC64")]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextSectionElement
	{
		/// <summary>属性AcceptChildElementTypes2</summary>
		[DispId(65)]
		ElementType AcceptChildElementTypes2
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

		/// <summary>属性CheckBoxes</summary>
		[DispId(90)]
		XTextElementList CheckBoxes
		{
			get;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(22)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentEditable</summary>
		[DispId(23)]
		bool ContentEditable
		{
			get;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(24)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(77)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentPartyStyle</summary>
		[DispId(58)]
		PageContentPartyStyle ContentPartyStyle
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(25)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性CopySource</summary>
		[DispId(26)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(27)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性Elements</summary>
		[DispId(56)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(66)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnableCollapse</summary>
		[DispId(91)]
		bool EnableCollapse
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(59)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EnableValueValidate</summary>
		[DispId(71)]
		bool EnableValueValidate
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(28)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(78)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(29)]
		bool Focused
		{
			get;
		}

		/// <summary>属性GridLine</summary>
		[DispId(79)]
		DCGridLineInfo GridLine
		{
			get;
			set;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(60)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(30)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(31)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(73)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(80)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性IsCollapsed</summary>
		[DispId(98)]
		bool IsCollapsed
		{
			get;
			set;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(32)]
		bool IsEmpty
		{
			get;
			set;
		}

		/// <summary>属性LastChild</summary>
		[DispId(81)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(63)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(33)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(34)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(74)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(82)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(35)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(36)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(37)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(38)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(83)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(39)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性ParagraphsEOFs</summary>
		[DispId(40)]
		XTextElementList ParagraphsEOFs
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(41)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(42)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrivateContent</summary>
		[DispId(43)]
		XTextElementList PrivateContent
		{
			get;
		}

		/// <summary>属性PrivateLines</summary>
		[DispId(44)]
		XTextLineList PrivateLines
		{
			get;
		}

		/// <summary>属性RadioBoxes</summary>
		[DispId(92)]
		XTextElementList RadioBoxes
		{
			get;
		}

		/// <summary>属性RuntimeContentReadonly</summary>
		[DispId(45)]
		bool RuntimeContentReadonly
		{
			get;
		}

		/// <summary>属性SpecifyFixedLineHeight</summary>
		[DispId(68)]
		float SpecifyFixedLineHeight
		{
			get;
			set;
		}

		/// <summary>属性SpecifyHeight</summary>
		[DispId(69)]
		float SpecifyHeight
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(46)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(47)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(93)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(94)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(48)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(55)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(62)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性VisibleExpression</summary>
		[DispId(67)]
		string VisibleExpression
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(49)]
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

		/// <summary>方法Collapse</summary>
		[DispId(86)]
		bool Collapse();

		/// <summary>方法CommitUserTrace</summary>
		[DispId(70)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(5)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorDelete</summary>
		[DispId(6)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(7)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(50)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(51)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(8)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(9)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(10)]
		bool EndSetStyle();

		/// <summary>方法Expand</summary>
		[DispId(87)]
		bool Expand();

		/// <summary>方法Focus</summary>
		[DispId(11)]
		void Focus();

		/// <summary>方法GetAllElements</summary>
		[DispId(57)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(61)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(52)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(12)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementByIdExt</summary>
		[DispId(88)]
		XTextElement GetElementByIdExt(string string_0, bool idAttributeOnly);

		/// <summary>方法GetElementsByName</summary>
		[DispId(13)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(14)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(53)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(89)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(64)]
		bool HasAttribute(string name);

		/// <summary>方法InsertAfter</summary>
		[DispId(84)]
		bool InsertAfter(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertBefore</summary>
		[DispId(85)]
		bool InsertBefore(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertChildElement</summary>
		[DispId(15)]
		bool InsertChildElement(int index, XTextElement element);

		/// <summary>方法InvalidateView</summary>
		[DispId(16)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(95)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(96)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(17)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(18)]
		bool Select();

		/// <summary>方法SelectFirstLine</summary>
		[DispId(72)]
		bool SelectFirstLine();

		/// <summary>方法SetAttribute</summary>
		[DispId(54)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(75)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(76)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetEditorText</summary>
		[DispId(19)]
		bool SetEditorText(SetContainerTextArgs args);

		/// <summary>方法SetEditorTextExt</summary>
		[DispId(20)]
		bool SetEditorTextExt(string newText, DomAccessFlags flags, bool disablePermissioin, bool updateContent);

		/// <summary>方法SetTextRawDOM</summary>
		[DispId(97)]
		void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex);
	}
}
