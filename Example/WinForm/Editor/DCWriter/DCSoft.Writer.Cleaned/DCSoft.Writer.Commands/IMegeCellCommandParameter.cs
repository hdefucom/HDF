using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>MegeCellCommandParameter 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("656D6F74-BFE0-4C7E-9B9B-829FA3270DBC")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IMegeCellCommandParameter
	{
		/// <summary>属性Cell</summary>
		[DispId(2)]
		XTextTableCellElement Cell
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
