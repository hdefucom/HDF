using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>SplitCellExtCommandParameter 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("4CF17461-1E5F-4301-B22D-C9B5F7AB48A1")]
	public interface ISplitCellExtCommandParameter
	{
		/// <summary>属性CellElement</summary>
		[DispId(2)]
		XTextTableCellElement CellElement
		{
			get;
			set;
		}

		/// <summary>属性CellID</summary>
		[DispId(3)]
		string CellID
		{
			get;
			set;
		}

		/// <summary>属性NewColSpan</summary>
		[DispId(4)]
		int NewColSpan
		{
			get;
			set;
		}

		/// <summary>属性NewRowSpan</summary>
		[DispId(5)]
		int NewRowSpan
		{
			get;
			set;
		}
	}
}
