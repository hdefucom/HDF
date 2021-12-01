using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterPrintEventEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("6A6AA3C0-2F4D-4D61-B319-3949DF34037E")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	public interface IWriterPrintEventEventArgs
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

		/// <summary>属性PrintAction</summary>
		[DispId(5)]
		PrintAction PrintAction
		{
			get;
		}

		/// <summary>属性PrintDocument</summary>
		[DispId(6)]
		WriterPrintDocument PrintDocument
		{
			get;
		}

		/// <summary>属性PrinterSettings</summary>
		[DispId(7)]
		PrinterSettings PrinterSettings
		{
			get;
		}
	}
}
