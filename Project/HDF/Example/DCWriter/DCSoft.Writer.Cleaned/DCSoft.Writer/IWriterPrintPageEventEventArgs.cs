using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterPrintPageEventEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("9E285C5F-A5A2-4351-8E00-691CAB35CB1E")]
	public interface IWriterPrintPageEventEventArgs
	{
		/// <summary>属性Cancel</summary>
		[DispId(2)]
		bool Cancel
		{
			get;
			set;
		}

		/// <summary>属性DefaultPageSettings</summary>
		[DispId(3)]
		PageSettings DefaultPageSettings
		{
			get;
		}

		/// <summary>属性Document</summary>
		[DispId(4)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Graphics</summary>
		[DispId(5)]
		Graphics Graphics
		{
			get;
		}

		/// <summary>属性HasMorePages</summary>
		[DispId(6)]
		bool HasMorePages
		{
			get;
			set;
		}

		/// <summary>属性MarginBounds</summary>
		[DispId(7)]
		Rectangle MarginBounds
		{
			get;
		}

		/// <summary>属性PageBounds</summary>
		[DispId(8)]
		Rectangle PageBounds
		{
			get;
		}

		/// <summary>属性PageIndex</summary>
		[DispId(9)]
		int PageIndex
		{
			get;
		}

		/// <summary>属性PageSettings</summary>
		[DispId(10)]
		PageSettings PageSettings
		{
			get;
		}

		/// <summary>属性PrintDocument</summary>
		[DispId(11)]
		WriterPrintDocument PrintDocument
		{
			get;
		}

		/// <summary>属性PrinterSettings</summary>
		[DispId(12)]
		PrinterSettings PrinterSettings
		{
			get;
		}
	}
}
