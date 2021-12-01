using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>TableCommandArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("EC482230-315B-42F4-9ABF-58A573F70AF8")]
	[ComVisible(true)]
	public interface ITableCommandArgs
	{
		/// <summary>属性ColIndex</summary>
		[DispId(2)]
		int ColIndex
		{
			get;
			set;
		}

		/// <summary>属性ColsCount</summary>
		[DispId(6)]
		int ColsCount
		{
			get;
			set;
		}

		/// <summary>属性Result</summary>
		[DispId(7)]
		bool Result
		{
			get;
			set;
		}

		/// <summary>属性RowIndex</summary>
		[DispId(3)]
		int RowIndex
		{
			get;
			set;
		}

		/// <summary>属性RowsCount</summary>
		[DispId(8)]
		int RowsCount
		{
			get;
			set;
		}

		/// <summary>属性TableElement</summary>
		[DispId(4)]
		XTextTableElement TableElement
		{
			get;
			set;
		}

		/// <summary>属性TableID</summary>
		[DispId(5)]
		string TableID
		{
			get;
			set;
		}
	}
}
