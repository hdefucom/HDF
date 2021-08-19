using DCSoft.Writer.Dom;
using DCSoft.Writer.Printing;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>WriterPrintQueryPageSettingsEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("9DF128AB-A6B7-4989-8C19-6E73AA50AF16")]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IWriterPrintQueryPageSettingsEventArgs
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

		/// <summary>属性PageSettings</summary>
		[DispId(5)]
		PageSettings PageSettings
		{
			get;
		}

		/// <summary>属性PrintAction</summary>
		[DispId(6)]
		PrintAction PrintAction
		{
			get;
		}

		/// <summary>属性PrintDocument</summary>
		[DispId(7)]
		WriterPrintDocument PrintDocument
		{
			get;
		}

		/// <summary>属性PrinterSettings</summary>
		[DispId(8)]
		PrinterSettings PrinterSettings
		{
			get;
		}
	}
}
