using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextParagraphFlagElement 的COM接口</summary>
	[Guid("DD4653F9-509D-4AEE-A021-AD63E1A59A1C")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IXTextParagraphFlagElement
	{
		/// <summary>属性ElementIndex</summary>
		[DispId(24)]
		int ElementIndex
		{
			get;
			set;
		}

		/// <summary>属性Focused</summary>
		[DispId(9)]
		bool Focused
		{
			get;
		}

		/// <summary>属性Height</summary>
		[DispId(10)]
		float Height
		{
			get;
			set;
		}

		/// <summary>属性NextElement</summary>
		[DispId(11)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(12)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(13)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(14)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(15)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(16)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性ParagraphText</summary>
		[DispId(26)]
		string ParagraphText
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(17)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性PreviousElement</summary>
		[DispId(18)]
		XTextElement PreviousElement
		{
			get;
		}

		/// <summary>属性Style</summary>
		[DispId(19)]
		DocumentContentStyle Style
		{
			get;
			set;
		}

		/// <summary>属性StyleIndex</summary>
		[DispId(20)]
		int StyleIndex
		{
			get;
			set;
		}

		/// <summary>属性TypeName</summary>
		[DispId(21)]
		string TypeName
		{
			get;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(22)]
		int ViewIndex
		{
			get;
		}

		/// <summary>属性Width</summary>
		[DispId(23)]
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

		/// <summary>方法GetParagraphElements</summary>
		[DispId(25)]
		XTextElementList GetParagraphElements();

		/// <summary>方法InvalidateView</summary>
		[DispId(7)]
		void InvalidateView();
	}
}
