using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextLineBreakElement 的COM接口</summary>
	[Browsable(false)]
	[Guid("2245E560-B282-4C3C-97B0-D0947F2FAB88")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextLineBreakElement
	{
		/// <summary>属性Height</summary>
		[DispId(9)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(10)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(11)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(12)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(13)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(14)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(15)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(16)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(17)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(18)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(19)]
		string TypeName
		{
			get;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(21)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(20)]
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

		/// <summary>方法EditorRefreshView</summary>
		[DispId(4)]
		void EditorRefreshView();

		/// <summary>方法EndSetStyle</summary>
		[DispId(5)]
		bool EndSetStyle();

		/// <summary>方法Focus</summary>
		[DispId(6)]
		void Focus();

		/// <summary>方法InvalidateView</summary>
		[DispId(7)]
		void InvalidateView();

		/// <summary>方法Select</summary>
		[DispId(8)]
		bool Select();
	}
}
