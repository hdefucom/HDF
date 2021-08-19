using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterTableRowHeightChangedEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("FC83CB1D-B2DF-47FB-9404-0473E15477EB")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IWriterTableRowHeightChangedEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(3)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性NewHeight</summary>
		[DispId(4)]
		float NewHeight
		{
			get;
		}

		/// <summary>属性OldHeight</summary>
		[DispId(5)]
		float OldHeight
		{
			get;
		}

		/// <summary>属性RowElement</summary>
		[DispId(6)]
		XTextTableRowElement RowElement
		{
			get;
		}
	}
}
