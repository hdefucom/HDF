using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextDocumentFooterElement 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("BF7E4F23-D792-4A4F-822E-B770CF526A4E")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextDocumentFooterElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(38)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Content</summary>
		[DispId(14)]
		XTextContent Content
		{
			get;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(15)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(39)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(16)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性Elements</summary>
		[DispId(35)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(40)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(17)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(43)]
		bool Focused
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(18)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(47)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性IsEmpty</summary>
		[DispId(19)]
		bool IsEmpty
		{
			get;
			set;
		}

		/// <summary>属性Lines</summary>
		[DispId(20)]
		XTextLineList Lines
		{
			get;
		}

		/// <summary>属性NextElement</summary>
		[DispId(32)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(33)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(34)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性PrivateContent</summary>
		[DispId(21)]
		XTextElementList PrivateContent
		{
			get;
		}

		/// <summary>属性PrivateLines</summary>
		[DispId(22)]
		XTextLineList PrivateLines
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(23)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(24)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(25)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(36)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>方法AppendChildElement</summary>
		[DispId(2)]
		bool AppendChildElement(XTextElement element);

		/// <summary>方法AppendContentElement</summary>
		[DispId(48)]
		void AppendContentElement(XTextElement element);

		/// <summary>方法AppendContentElements</summary>
		[DispId(46)]
		void AppendContentElements(XTextElementList elements);

		/// <summary>方法BeginSetStyle</summary>
		[DispId(3)]
		bool BeginSetStyle();

		/// <summary>方法Clear</summary>
		[DispId(4)]
		void Clear();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(5)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(6)]
		void EditorRefreshView();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(26)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(27)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EndSetStyle</summary>
		[DispId(7)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(41)]
		void Focus();

		/// <summary>方法GetAllElements</summary>
		[DispId(37)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAttribute</summary>
		[DispId(28)]
		string GetAttribute(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(29)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(30)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法InsertChildElement</summary>
		[DispId(8)]
		bool InsertChildElement(int index, XTextElement element);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(44)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(45)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法RemoveChild</summary>
		[DispId(9)]
		bool RemoveChild(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(42)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(31)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetEditorText</summary>
		[DispId(10)]
		bool SetEditorText(SetContainerTextArgs args);

		/// <summary>方法SetEditorTextExt</summary>
		[DispId(11)]
		bool SetEditorTextExt(string newText, DomAccessFlags flags, bool disablePermissioin, bool updateContent);

		/// <summary>方法SetSelection</summary>
		[DispId(12)]
		bool SetSelection(int startIndex, int length);

		/// <summary>方法SetSelectionRange</summary>
		[DispId(13)]
		bool SetSelectionRange(int firstIndex, int lastIndex);
	}
}
