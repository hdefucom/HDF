using DCSoft.Drawing;
using DCSoft.Printing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocumentBodyElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("8E21E3CD-581D-4A91-947F-DEFE29EDEE04")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IXTextDocumentBodyElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(51)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(16)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性Content</summary>
		[DispId(17)]
		XTextContent Content
		{
			get;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(18)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentEditable</summary>
		[DispId(46)]
		bool ContentEditable
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(66)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentPartyStyle</summary>
		[DispId(19)]
		PageContentPartyStyle ContentPartyStyle
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(52)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(20)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性CurrentLine</summary>
		[DispId(21)]
		XTextLine CurrentLine
		{
			get;
		}

		/// <summary>属性CurrentParagraphEOF</summary>
		[DispId(22)]
		XTextParagraphFlagElement CurrentParagraphEOF
		{
			get;
		}

		/// <summary>属性Elements</summary>
		[DispId(42)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(53)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(23)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(70)]
		bool Focused
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(24)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(60)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(61)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(25)]
		bool IsEmpty
		{
			get;
			set;
		}

		/// <summary>属性Lines</summary>
		[DispId(26)]
		XTextLineList Lines
		{
			get;
		}

		/// <summary>属性Modified</summary>
		[DispId(58)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(38)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(62)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(63)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(39)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(40)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrivateContent</summary>
		[DispId(27)]
		XTextElementList PrivateContent
		{
			get;
		}

		/// <summary>属性PrivateLines</summary>
		[DispId(28)]
		XTextLineList PrivateLines
		{
			get;
		}

		/// <summary>属性Sections</summary>
		[DispId(47)]
		XTextElementList Sections
		{
			get;
		}

		/// <summary>属性Selection</summary>
		[DispId(29)]
		XTextSelection Selection
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(30)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性TagValue</summary>
		[DispId(48)]
		object TagValue
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(31)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(32)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(43)]
		int UserFlags
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
		[DispId(54)]
		bool CommitUserTrace();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(5)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(6)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(33)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(34)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EndSetStyle</summary>
		[DispId(7)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(69)]
		void Focus();

		/// <summary>方法GetAllElements</summary>
		[DispId(49)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(55)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAllLines</summary>
		[DispId(50)]
		XTextLineList GetAllLines();

		/// <summary>方法GetAttribute</summary>
		[DispId(41)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(44)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(45)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(35)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(36)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetLinesInPage</summary>
		[DispId(8)]
		XTextLineList GetLinesInPage(PrintPage page);

		/// <summary>方法GetLinesInPageIndex</summary>
		[DispId(9)]
		XTextLineList GetLinesInPageIndex(int pageIndex);

		/// <summary>方法GetRemainSpacingInLastPage</summary>
		[DispId(57)]
		float GetRemainSpacingInLastPage();

		/// <summary>方法HasAttribute</summary>
		[DispId(56)]
		bool HasAttribute(string name);

		/// <summary>方法InsertAfter</summary>
		[DispId(67)]
		bool InsertAfter(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertBefore</summary>
		[DispId(68)]
		bool InsertBefore(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertChildElement</summary>
		[DispId(10)]
		bool InsertChildElement(int index, XTextElement element);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(71)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(72)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(11)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(12)]
		bool Select();

		/// <summary>方法SelectFirstLine</summary>
		[DispId(59)]
		bool SelectFirstLine();

		/// <summary>方法SetAttribute</summary>
		[DispId(37)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(64)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(65)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetEditorText</summary>
		[DispId(13)]
		bool SetEditorText(SetContainerTextArgs args);

		/// <summary>方法SetSelection</summary>
		[DispId(14)]
		bool SetSelection(int startIndex, int length);

		/// <summary>方法SetSelectionRange</summary>
		[DispId(15)]
		bool SetSelectionRange(int firstIndex, int lastIndex);

		/// <summary>方法SetTextRawDOM</summary>
		[DispId(73)]
		void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex);
	}
}
