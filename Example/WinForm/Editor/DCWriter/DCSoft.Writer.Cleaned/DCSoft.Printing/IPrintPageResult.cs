using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>PrintPageResult 的COM接口</summary>
	[Guid("E3595082-8CB9-40DD-AA15-25B46F3152F6")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IPrintPageResult
	{
		/// <summary>属性ContentHeight</summary>
		[DispId(2)]
		float ContentHeight
		{
			get;
			set;
		}

		/// <summary>属性ContentHeightPrinted</summary>
		[DispId(3)]
		float ContentHeightPrinted
		{
			get;
			set;
		}

		/// <summary>属性EndPositionInPage</summary>
		[DispId(7)]
		float EndPositionInPage
		{
			get;
			set;
		}

		/// <summary>属性Page</summary>
		[DispId(4)]
		PrintPage Page
		{
			get;
			set;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(5)]
		int PageIndex
		{
			get;
			set;
		}

		/// <summary>属性StartPositionInPage</summary>
		[DispId(6)]
		float StartPositionInPage
		{
			get;
			set;
		}

		/// <summary>属性TickSpan</summary>
		[DispId(8)]
		int TickSpan
		{
			get;
			set;
		}
	}
}
