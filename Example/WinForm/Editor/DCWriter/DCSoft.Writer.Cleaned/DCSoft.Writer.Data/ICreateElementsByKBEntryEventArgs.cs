using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>CreateElementsByKBEntryEventArgs 的COM接口</summary>
	[Guid("C50410E4-125F-4F45-B3E9-83A48DF8B7CF")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface ICreateElementsByKBEntryEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		XTextDocument Document
		{
			get;
		}

		/// <summary>属性Handled</summary>
		[DispId(3)]
		bool Handled
		{
			get;
			set;
		}

		/// <summary>属性Host</summary>
		[DispId(4)]
		WriterAppHost Host
		{
			get;
		}

		/// <summary>属性InputSource</summary>
		[DispId(5)]
		InputValueSource InputSource
		{
			get;
		}

		/// <summary>属性KBEntry</summary>
		[DispId(6)]
		KBEntry KBEntry
		{
			get;
		}

		/// <summary>属性Result</summary>
		[DispId(7)]
		XTextElementList Result
		{
			get;
			set;
		}

		/// <summary>属性WriterControl</summary>
		[DispId(8)]
		WriterControl WriterControl
		{
			get;
		}
	}
}
