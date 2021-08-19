using DCSoft.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextElement 的COM接口</summary>
	[ComVisible(true)]
	[Guid("26ABDEDB-D16C-3C3C-A699-34268D8C7D95")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IXTextElement
	{
		/// <summary>属性AbsLeft</summary>
		[DispId(12)]
		float AbsLeft
		{
			get;
		}

		/// <summary>属性AbsTop</summary>
		[DispId(13)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性Attributes</summary>
		[DispId(45)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性DispalyTypeName</summary>
		[DispId(37)]
		string DispalyTypeName
		{
			get;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(43)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(15)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性FirstContentElement</summary>
		[DispId(16)]
		XTextElement FirstContentElement
		{
			get;
		}

		/// <summary>属性Focused</summary>
		[DispId(17)]
		bool Focused
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(18)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(19)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(46)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(48)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LastContentElement</summary>
		[DispId(20)]
		XTextElement LastContentElement
		{
			get;
		}

		/// <summary>属性NextElement</summary>
		[DispId(21)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(47)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(49)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(22)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(23)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(24)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(25)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(51)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerParagraphEOF</summary>
		[DispId(26)]
		XTextParagraphFlagElement OwnerParagraphEOF
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(27)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(28)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(52)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(53)]
		float PixelWidth
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(29)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(30)]
		RuntimeDocumentContentStyle RuntimeStyle
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

		/// <summary>属性TypeName</summary>
		[DispId(34)]
		string TypeName
		{
			get;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(40)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(35)]
		bool Visible
		{
			get;
			set;
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

		/// <summary>方法Clone</summary>
		[DispId(41)]
		XTextElement Clone(bool Deeply);

		/// <summary>方法CreateContentDocument</summary>
		[DispId(3)]
		XTextDocument CreateContentDocument(bool includeThis);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(4)]
		void EditorRefreshView();

		/// <summary>方法EditorSetSize</summary>
		[DispId(5)]
		bool EditorSetSize(float width, float height, bool updateView, bool logUndo);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(44)]
		bool EditorSetStyle(DocumentContentStyle style);

		/// <summary>方法EditorSetVisible</summary>
		[DispId(6)]
		bool EditorSetVisible(bool visible);

		/// <summary>方法EditorSetVisibleExt</summary>
		[DispId(7)]
		bool EditorSetVisibleExt(bool visible, bool logUndo, bool fastMode);

		/// <summary>方法EndSetStyle</summary>
		[DispId(8)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(9)]
		void Focus();

		/// <summary>方法GetAttribute</summary>
		[DispId(38)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(50)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(42)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法PBGetAttribute</summary>
		[DispId(54)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(55)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(11)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(39)]
		bool SetAttribute(string name, string Value);
	}
}
