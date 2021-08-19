using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextBarcodeFieldElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("F156FA30-D580-47B0-B870-C436D3BD9486")]
	public interface IXTextBarcodeFieldElement
	{
		/// <summary>属性AbsLeft</summary>
		[DispId(14)]
		float AbsLeft
		{
			get;
		}

		/// <summary>属性AbsTop</summary>
		[DispId(15)]
		float AbsTop
		{
			get;
		}

		/// <summary>属性Attributes</summary>
		[DispId(16)]
		XAttributeList Attributes
		{
			get;
			set;
		}

		/// <summary>属性Bottom</summary>
		[DispId(17)]
		float Bottom
		{
			get;
		}

		/// <summary>属性CopySource</summary>
		[DispId(18)]
		CopySourceInfo CopySource
		{
			get;
			set;
		}

		/// <summary>属性ElementIndex</summary>
		[DispId(38)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(20)]
		bool Focused
		{
			get;
		}

		/// <summary>属性ID</summary>
		[DispId(21)]
		string ID
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(22)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(23)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(24)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(25)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(26)]
		int OwnerPageIndex
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

		/// <summary>属性PreviousElement</summary>
		[DispId(29)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Readonly</summary>
		[DispId(30)]
		bool Readonly
		{
			get;
			set;
		}

		/// <summary>属性RuntimeStyle</summary>
		[DispId(31)]
		RuntimeDocumentContentStyle RuntimeStyle
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(32)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(33)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(34)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Top</summary>
		[DispId(35)]
		float Top
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(36)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Visible</summary>
		[DispId(37)]
		bool Visible
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

		/// <summary>方法EditorDelete</summary>
		[DispId(4)]
		bool EditorDelete(bool logUndo);

		/// <summary>方法EditorRefreshView</summary>
		[DispId(5)]
		void EditorRefreshView();

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

		/// <summary>方法InvalidateHighlightInfo</summary>
		[DispId(10)]
		void InvalidateHighlightInfo();

		/// <summary>方法InvalidateView</summary>
		[DispId(11)]
		void InvalidateView();

		/// <summary>方法IsParentOrSupParent</summary>
		[DispId(12)]
		bool IsParentOrSupParent(XTextElement element);

		/// <summary>方法Select</summary>
		[DispId(13)]
		bool Select();
	}
}
