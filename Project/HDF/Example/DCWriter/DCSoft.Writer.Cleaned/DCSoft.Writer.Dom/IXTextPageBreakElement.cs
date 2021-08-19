using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextPageBreakElement 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("BC40D9FD-B2AD-462C-9C9F-9B8EC5D612CC")]
	public interface IXTextPageBreakElement
	{
		/// <summary>属性Height</summary>
		[DispId(8)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(9)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(10)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(11)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(12)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(13)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(14)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(15)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(16)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(17)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(18)]
		int StyleIndex
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

		/// <summary>方法Select</summary>
		[DispId(7)]
		bool Select();
	}
}
