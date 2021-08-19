using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextContentLinkFieldElement 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("C9D4A84C-019B-4B0F-9917-5AD2F4E56109")]
	public interface IXTextContentLinkFieldElement
	{
		/// <summary>属性Attributes</summary>
		[DispId(9)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ContentBuilder</summary>
		[DispId(10)]
		ContentBuilder ContentBuilder
		{
			get;
		}

		/// <summary>属性ContentSource</summary>
		[DispId(11)]
		FileContentSource ContentSource
		{
			get;
			set;
		}

		/// <summary>属性CopySource</summary>
		[DispId(12)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(13)]
		bool Focused
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(14)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(15)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(16)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(17)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(18)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(19)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(20)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(21)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(22)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Readonly</summary>
		[DispId(23)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性ReplaceUpdateMode</summary>
		[DispId(24)]
		bool ReplaceUpdateMode
		{
			get;
			set;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(25)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性SaveLinkedContent</summary>
		[DispId(26)]
		bool SaveLinkedContent
		{
			get;
			set;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(27)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(28)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性UserFlags</summary>
		[DispId(36)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(37)]
		int ViewIndex
		{
			get;
		}

		/// <summary>方法BeginSetStyle</summary>
		[DispId(2)]
		bool BeginSetStyle();

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
		[DispId(29)]
		void EditorSetContentStyle(DocumentContentStyle newStyle, bool logUndo);

		/// <summary>方法EditorSetContentStyleFast</summary>
		[DispId(30)]
		bool EditorSetContentStyleFast(DocumentContentStyle newStyle);

		/// <summary>方法EndSetStyle</summary>
		[DispId(6)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(7)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(31)]
		string GetAttribute(string name);

		/// <summary>方法GetElementsByTypeName</summary>
		[DispId(33)]
		XTextElementList GetElementsByTypeName(string elementTypeName);

		/// <summary>方法GetFirstElementByTypeName</summary>
		[DispId(34)]
		XTextElement GetFirstElementByTypeName(string elementTypeName);

		/// <summary>方法Select</summary>
		[DispId(8)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(35)]
		bool SetAttribute(string name, string Value);
	}
}
