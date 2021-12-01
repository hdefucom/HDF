using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterTableRowHeightChangingEventArgs 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("7AD13E83-92A5-4E61-8439-E4B373690D1F")]
	[Browsable(false)]
	public interface IWriterTableRowHeightChangingEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性Document</summary>
		[DispId(3)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Element</summary>
		[DispId(4)]
		XTextElement Element
		{
			get;
		}

		/// <summary>属性NewHeight</summary>
		[DispId(5)]
		float NewHeight
		{
			get;
			set;
		}

		/// <summary>属性OldHeight</summary>
		[DispId(6)]
		float OldHeight
		{
			get;
		}

		/// <summary>属性RowElement</summary>
		[DispId(7)]
		XTextTableRowElement RowElement
		{
			get;
		}
	}
}
