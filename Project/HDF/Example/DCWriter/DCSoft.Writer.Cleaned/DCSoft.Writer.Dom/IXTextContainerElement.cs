using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextContainerElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("20D11DD0-C872-4394-9B47-53C6BB2B5BC1")]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextContainerElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(12)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(43)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentLock</summary>
		[DispId(53)]
		DCContentLockInfo ContentLock
		{
			get;
			set;
		}

		/// <summary>属性CopySource</summary>
		[DispId(13)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性EditorText</summary>
		[DispId(14)]
		string EditorText
		{
			get;
			set;
		}

		/// <summary>属性EditorTextExt</summary>
		[DispId(15)]
		string EditorTextExt
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(16)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性EnablePermission</summary>
		[DispId(47)]
		DCBooleanValue EnablePermission
		{
			get;
			set;
		}

		/// <summary>属性Events</summary>
		[DispId(17)]
		ElementEventTemplateList Events
		{
			get;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(18)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性FirstChild</summary>
		[DispId(54)]
		XTextElement FirstChild
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(20)]
		bool Focused
		{
			get;
		}

		/// <summary>属性HasSelection</summary>
		[DispId(48)]
		bool HasSelection
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(21)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(22)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(23)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(24)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(25)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(26)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(27)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerParagraphEOF</summary>
		[DispId(28)]
		XTextParagraphFlagElement OwnerParagraphEOF
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(29)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(30)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(31)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性RuntimeContentReadonly</summary>
		[DispId(32)]
		bool RuntimeContentReadonly
		{
			get;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(33)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(34)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(35)]
		string TypeName
		{
			get;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(44)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ValueExpression</summary>
		[DispId(50)]
		string ValueExpression
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(45)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(36)]
		float Width
		{
			get;
			set;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法CreateContentImage</summary>
		[DispId(4)]
		Image CreateContentImage();

		/// <summary>方法EditorSetContentStyle</summary>
		[DispId(37)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(38)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EndSetStyle</summary>
		[DispId(5)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(6)]
		void Focus();

		/// <summary>方法GetAllElements</summary>
		[DispId(46)]
		XTextElementList GetAllElements();

		/// <summary>方法GetAllElementsWithoutCharElement</summary>
		[DispId(49)]
		XTextElementList GetAllElementsWithoutCharElement();

		/// <summary>方法GetAttribute</summary>
		[DispId(39)]
		string GetAttribute(string name);

		/// <summary>方法GetElementById</summary>
		[DispId(7)]
		XTextElement GetElementById(string string_0);

		/// <summary>方法GetElementsByName</summary>
		[DispId(8)]
		XTextElementList GetElementsByName(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(9)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(41)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法Select</summary>
		[DispId(11)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(42)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetContentLock</summary>
		[DispId(51)]
		bool SetContentLock(string userID, string authoriseUserIDList, bool logUndo);

		/// <summary>方法SetContentLockByCurrentUser</summary>
		[DispId(52)]
		bool SetContentLockByCurrentUser();
	}
}
