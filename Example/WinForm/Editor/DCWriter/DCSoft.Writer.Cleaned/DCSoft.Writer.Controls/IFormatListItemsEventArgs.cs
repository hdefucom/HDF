using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>FormatListItemsEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[Browsable(false)]
	[Guid("0BE89845-454A-4680-B841-F3847FD44DFD")]
	public interface IFormatListItemsEventArgs
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

		/// <summary>属性FormatString</summary>
		[DispId(4)]
		string FormatString
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(5)]
		string Result
		{
			get;
			set;
		}

		/// <summary>属性SelectedItems</summary>
		[DispId(6)]
		string[] SelectedItems
		{
			get;
		}

		/// <summary>属性Separator</summary>
		[DispId(10)]
		string Separator
		{
			get;
		}

		/// <summary>属性SeparatorChar</summary>
		[DispId(7)]
		char SeparatorChar
		{
			get;
		}

		/// <summary>属性UnselectedItems</summary>
		[DispId(8)]
		string[] UnselectedItems
		{
			get;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(9)]
		WriterControl WriterControl
		{
			get;
		}
	}
}
