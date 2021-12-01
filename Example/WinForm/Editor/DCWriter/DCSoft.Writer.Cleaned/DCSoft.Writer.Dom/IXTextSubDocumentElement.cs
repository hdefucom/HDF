using DCSoft.Drawing;
using DCSoft.Printing;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextSubDocumentElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("D5CEBC74-0160-4898-BE6B-24F5F55744A1")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextSubDocumentElement
	{
		/// <summary>属性CheckBoxes</summary>
		[DispId(74)]
		XTextElementList CheckBoxes
		{
			get;
		}

		/// <summary>属性CompressOwnerLineSpacing</summary>
		[DispId(51)]
		bool CompressOwnerLineSpacing
		{
			get;
			set;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(18)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(36)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(52)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(53)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性DelayLoadWhenExpand</summary>
		[DispId(75)]
		bool DelayLoadWhenExpand
		{
			get;
			set;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(54)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DocumentID</summary>
		[DispId(37)]
		string DocumentID
		{
			get;
			set;
		}

		/// <summary>属性DocumentInfo</summary>
		[DispId(19)]
		DocumentInfo DocumentInfo
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(55)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性ElementsCount</summary>
		[DispId(56)]
		int ElementsCount
		{
			get;
		}

		/// <summary>属性EnableCollapse</summary>
		[DispId(76)]
		bool EnableCollapse
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(20)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性FileFormat</summary>
		[DispId(21)]
		string FileFormat
		{
			get;
			set;
		}

		/// <summary>属性FileName</summary>
		[DispId(22)]
		string FileName
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(38)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性GridLine</summary>
		[DispId(39)]
		DCGridLineInfo GridLine
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(23)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性ImportUserTrack</summary>
		[DispId(24)]
		bool ImportUserTrack
		{
			get;
			set;
		}

		/// <summary>属性InnerText</summary>
		[DispId(57)]
		string InnerText
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(58)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(59)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性IsCollapsed</summary>
		[DispId(85)]
		bool IsCollapsed
		{
			get;
			set;
		}

		/// <summary>属性LastChild</summary>
		[DispId(40)]
		XTextElement LastChild
		{
			get;
		}

		/// <summary>属性Locked</summary>
		[DispId(25)]
		bool Locked
		{
			get;
			set;
		}

		/// <summary>属性Modified</summary>
		[DispId(26)]
		bool Modified
		{
			get;
			set;
		}

		/// <summary>属性NewPage</summary>
		[DispId(41)]
		bool NewPage
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(42)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterText</summary>
		[DispId(60)]
		string OuterText
		{
			get;
			set;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(61)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(62)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(27)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(28)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(29)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(30)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(43)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(63)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Printed</summary>
		[DispId(64)]
		bool Printed
		{
			get;
			set;
		}

		/// <summary>属性RadioBoxes</summary>
		[DispId(77)]
		XTextElementList RadioBoxes
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(31)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(32)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(33)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(78)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性ToolTip</summary>
		[DispId(79)]
		string ToolTip
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(66)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(67)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>方法AppendChildElement</summary>
		[DispId(48)]
		bool AppendChildElement(XTextElement element);

		/// <summary>方法Clear</summary>
		[DispId(49)]
		void Clear();

		/// <summary>方法Collapse</summary>
		[DispId(68)]
		bool Collapse();

		/// <summary>方法CommitUserTrace</summary>
		[DispId(2)]
		bool CommitUserTrace();

		/// <summary>方法EditorDelete</summary>
		[DispId(44)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(45)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(3)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(4)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EditorSetState</summary>
		[DispId(46)]
		bool EditorSetState(bool readOnly, Color backgroundColor, Color borderColor);

		/// <summary>方法EditorSetStateCOM</summary>
		[DispId(80)]
		bool EditorSetStateCOM(bool readOnly, string backgroundColor, string borderColor);

		/// <summary>方法Expand</summary>
		[DispId(69)]
		bool Expand();

		/// <summary>方法GetAllElements</summary>
		[DispId(5)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(6)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(7)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(70)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(71)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(8)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(9)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(47)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(10)]
		bool HasAttribute(string name);

		/// <summary>方法InsertAfter</summary>
		[DispId(72)]
		bool InsertAfter(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法InsertBefore</summary>
		[DispId(73)]
		bool InsertBefore(XTextElement newElement, XTextElement oldElement);

		/// <summary>方法LoadDocumentFromFileName</summary>
		[DispId(11)]
		void LoadDocumentFromFileName(string fileName, string format);

		/// <summary>方法LoadDocumentFromString</summary>
		[DispId(12)]
		void LoadDocumentFromString(string string_0, string format);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(82)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(83)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(81)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法SaveDocumentToFileName</summary>
		[DispId(13)]
		void SaveDocumentToFileName(string fileName, string format);

		/// <summary>方法SaveDocumentToString</summary>
		[DispId(14)]
		string SaveDocumentToString(string format);

		/// <summary>方法Select</summary>
		[DispId(50)]
		bool Select();

		/// <summary>方法SelectFirstLine</summary>
		[DispId(15)]
		bool SelectFirstLine();

		/// <summary>方法SetAttribute</summary>
		[DispId(16)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(34)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(35)]
		bool SetContentLockByCurrentUser();

		/// <summary>方法SetTextRawDOM</summary>
		[DispId(84)]
		void SetTextRawDOM(string text, int textStyleIndex, int paragraphStyleIndex);
	}
}
