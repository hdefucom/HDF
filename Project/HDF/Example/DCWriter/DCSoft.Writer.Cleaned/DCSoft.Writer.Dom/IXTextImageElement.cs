using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.ShapeEditor.Dom;
using DCSoft.WinForms;
using DCSoft.Writer.Script;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextImageElement 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("F52F4335-C691-4DCD-BDBD-3D8E6DCC530A")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IXTextImageElement
	{
		/// <summary>属性AbsLeft</summary>
		[DispId(13)]
		float AbsLeft
		{
			get;
		}

		/// <summary>属性AbsTop</summary>
		[DispId(14)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性AdditionShape</summary>
		[DispId(55)]
		ShapeDocument AdditionShape
		{
			get;
			set;
		}

		/// <summary>属性AdditionShapeContent</summary>
		[DispId(15)]
		string AdditionShapeContent
		{
			get;
			set;
		}

		/// <summary>属性AdditionShapeFixSize</summary>
		[DispId(16)]
		bool AdditionShapeFixSize
		{
			get;
			set;
		}

		/// <summary>属性Alt</summary>
		[DispId(17)]
		string Alt
		{
			get;
			set;
		}

		/// <summary>属性Attributes</summary>
		[DispId(18)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性ColumnIndex</summary>
		[DispId(19)]
		int ColumnIndex
		{
			get;
		}

		/// <summary>属性CompressSaveMode</summary>
		[DispId(72)]
		bool CompressSaveMode
		{
			get;
			set;
		}

		/// <summary>属性ContentElement</summary>
		[DispId(20)]
		XTextContentElement ContentElement
		{
			get;
		}

		/// <summary>属性ContentReadonly</summary>
		[DispId(69)]
		ContentReadonlyState ContentReadonly
		{
			get;
			set;
		}

		/// <summary>属性ContentVersion</summary>
		[DispId(21)]
		int ContentVersion
		{
			get;
		}

		/// <summary>属性Deleteable</summary>
		[DispId(62)]
		bool Deleteable
		{
			get;
			set;
		}

		/// <summary>属性DocumentContentElement</summary>
		[DispId(22)]
		XTextDocumentContentElement DocumentContentElement
		{
			get;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(67)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Elements</summary>
		[DispId(24)]
		XTextElementList Elements
		{
			get;
			set;
		}

		/// <summary>属性Enabled</summary>
		[DispId(63)]
		bool Enabled
		{
			get;
			set;
		}

		/// <summary>属性EnableRepeatedImage</summary>
		[DispId(71)]
		bool EnableRepeatedImage
		{
			get;
			set;
		}

		/// <summary>属性EventTemplateName</summary>
		[DispId(25)]
		string EventTemplateName
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(26)]
		bool Focused
		{
			get;
		}

		/// <summary>属性HasAdditionalShape</summary>
		[DispId(27)]
		bool HasAdditionalShape
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(28)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性ID</summary>
		[DispId(29)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性Image</summary>
		[DispId(30)]
		XImageValue Image
		{
			get;
			set;
		}

		/// <summary>属性ImageData</summary>
		[DispId(31)]
		byte[] ImageData
		{
			get;
			set;
		}

		/// <summary>属性InnerXML</summary>
		[DispId(75)]
		string InnerXML
		{
			get;
		}

		/// <summary>属性InnerXMLWithoutTrack</summary>
		[DispId(78)]
		string InnerXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性LinkInfo</summary>
		[DispId(64)]
		HyperlinkInfo LinkInfo
		{
			get;
			set;
		}

		/// <summary>属性Name</summary>
		[DispId(32)]
		string Name
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(33)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OffsetX</summary>
		[DispId(86)]
		float OffsetX
		{
			get;
			set;
		}

		/// <summary>属性OffsetY</summary>
		[DispId(87)]
		float OffsetY
		{
			get;
			set;
		}

		/// <summary>属性OuterXML</summary>
		[DispId(76)]
		string OuterXML
		{
			get;
		}

		/// <summary>属性OuterXMLWithoutTrack</summary>
		[DispId(79)]
		string OuterXMLWithoutTrack
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(34)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(35)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(36)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(37)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerPagePartyStyle</summary>
		[DispId(80)]
		PageContentPartyStyle OwnerPagePartyStyle
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(38)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性PageImages</summary>
		[DispId(60)]
		PageImageInfoList PageImages
		{
			get;
			set;
		}

		/// <summary>属性Parent</summary>
		[DispId(39)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PixelHeight</summary>
		[DispId(81)]
		float PixelHeight
		{
			get;
			set;
		}

		/// <summary>属性PixelWidth</summary>
		[DispId(82)]
		float PixelWidth
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

		/// <summary>属性Printable</summary>
		[DispId(65)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性PrintVisibility</summary>
		[DispId(83)]
		ElementVisibility PrintVisibility
		{
			get;
			set;
		}

		/// <summary>属性Resizeable</summary>
		[DispId(41)]
		ResizeableType Resizeable
		{
			get;
			set;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(42)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性SaveContentInFile</summary>
		[DispId(43)]
		bool SaveContentInFile
		{
			get;
			set;
		}

		/// <summary>属性ScriptItems</summary>
		[DispId(66)]
		VBScriptItemList ScriptItems
		{
			get;
			set;
		}

		/// <summary>属性SmoothZoom</summary>
		[DispId(73)]
		bool SmoothZoom
		{
			get;
			set;
		}

		/// <summary>属性Source</summary>
		[DispId(44)]
		string Source
		{
			get;
			set;
		}

		/// <summary>属性Style</summary>
		[DispId(45)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(46)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Title</summary>
		[DispId(47)]
		string Title
		{
			get;
			set;
		}

		/// <summary>属性TransparentColor</summary>
		[DispId(88)]
		Color TransparentColor
		{
			get;
			set;
		}

		/// <summary>属性TransparentColorValue</summary>
		[DispId(89)]
		string TransparentColorValue
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
		[DispId(54)]
		int UserFlags
		{
			get;
			set;
		}

		/// <summary>属性VAlign</summary>
		[DispId(70)]
		VerticalAlignStyle VAlign
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(49)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(50)]
		bool Visible
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(51)]
		float Width
		{
			get;
			set;
		}

		/// <summary>属性ZOrderStyle</summary>
		[DispId(90)]
		ElementZOrderStyle ZOrderStyle
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

		/// <summary>方法EditorRefreshView</summary>
		[DispId(4)]
		void EditorRefreshView();

		/// <summary>方法EditorSetSize</summary>
		[DispId(5)]
		bool EditorSetSize(float width, float height, bool updateView, bool logUndo);

		/// <summary>方法EditorSetStyle</summary>
		[DispId(68)]
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
		[DispId(52)]
		string GetAttribute(string name);

		/// <summary>方法GetXMLFragment</summary>
		[DispId(77)]
		string GetXMLFragment();

		/// <summary>方法HasAttribute</summary>
		[DispId(61)]
		bool HasAttribute(string name);

		/// <summary>方法InvalidateView</summary>
		[DispId(10)]
		void InvalidateView();

		/// <summary>方法LoadImage</summary>
		[DispId(11)]
		bool LoadImage(string strUrl, bool setSize);

		/// <summary>方法PBGetAttribute</summary>
		[DispId(84)]
		string PBGetAttribute(ref string name);

		/// <summary>方法PBSetAttribute</summary>
		[DispId(85)]
		bool PBSetAttribute(ref string name, ref string string_0);

		/// <summary>方法Select</summary>
		[DispId(12)]
		bool Select();

		/// <summary>方法SetAttribute</summary>
		[DispId(53)]
		bool SetAttribute(string name, string Value);

		/// <summary>方法SetPageImage</summary>
		[DispId(56)]
		void SetPageImage(int pageIndex, Image image_0);

		/// <summary>方法SetPageImageByBase64String</summary>
		[DispId(57)]
		void SetPageImageByBase64String(int pageIndex, string base64);

		/// <summary>方法SetPageImageByFileName</summary>
		[DispId(58)]
		void SetPageImageByFileName(int pageIndex, string fileName);

		/// <summary>方法SetPageImageByImageValue</summary>
		[DispId(59)]
		void SetPageImageByImageValue(int pageIndex, XImageValue ximageValue_0);

		/// <summary>方法UpdateImageContent</summary>
		[DispId(74)]
		void UpdateImageContent();
	}
}
