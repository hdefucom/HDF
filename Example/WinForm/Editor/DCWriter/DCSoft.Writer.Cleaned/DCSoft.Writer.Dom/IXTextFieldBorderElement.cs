using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>XTextFieldBorderElement 的COM接口</summary>
	[Guid("7D241B15-732B-42D4-8C46-D37365E00837")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXTextFieldBorderElement
	{
		/// <summary>属性Focused</summary>
		[DispId(4)]
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
		[DispId(5)]
		XTextElement NextElement
		{
			get;
		}

		/// <summary>属性OwnerCell</summary>
		[DispId(6)]
		XTextTableCellElement OwnerCell
		{
			get;
		}

		/// <summary>属性OwnerDocument</summary>
		[DispId(7)]
		XTextDocument OwnerDocument
		{
			get;
			set;
		}

		/// <summary>属性OwnerField</summary>
		[DispId(8)]
		XTextFieldElementBase OwnerField
		{
			get;
		}

		/// <summary>属性OwnerLine</summary>
		[DispId(9)]
		XTextLine OwnerLine
		{
			get;
			set;
		}

		/// <summary>属性OwnerPageIndex</summary>
		[DispId(10)]
		int OwnerPageIndex
		{
			get;
		}

		/// <summary>属性OwnerSection</summary>
		[DispId(11)]
		XTextSectionElement OwnerSection
		{
			get;
		}

		/// <summary>属性Parent</summary>
		[DispId(12)]
		XTextContainerElement Parent
		{
			get;
			set;
		}

		/// <summary>属性Position</summary>
		[DispId(13)]
		BorderElementPosition Position
		{
			get;
			set;
		}

		/// <summary>属性ViewIndex</summary>
		[DispId(15)]
		int ViewIndex
		{
			get;
		}

		/// <summary>方法Focus</summary>
		[DispId(2)]
		void Focus();

		/// <summary>方法Select</summary>
		[DispId(3)]
		bool Select();
	}
}
