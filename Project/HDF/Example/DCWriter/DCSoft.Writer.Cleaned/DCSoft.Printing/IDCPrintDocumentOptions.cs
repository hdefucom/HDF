using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>DCPrintDocumentOptions 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("25E85F8F-A621-4234-A476-89E581DB83EB")]
	[ComVisible(true)]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IDCPrintDocumentOptions
	{
		/// <summary>属性AsyncPrint</summary>
		[DispId(3)]
		bool AsyncPrint
		{
			get;
			set;
		}

		/// <summary>属性AutoFitPageSize</summary>
		[DispId(4)]
		bool AutoFitPageSize
		{
			get;
			set;
		}

		/// <summary>属性BodyOffsetY</summary>
		[DispId(5)]
		float BodyOffsetY
		{
			get;
			set;
		}

		/// <summary>属性CleanMode</summary>
		[DispId(6)]
		bool CleanMode
		{
			get;
			set;
		}

		/// <summary>属性DisableRefreshDocumentLayout</summary>
		[DispId(21)]
		bool DisableRefreshDocumentLayout
		{
			get;
			set;
		}

		/// <summary>属性DrawFirstHeaderFooterWhenJumpPrintMode</summary>
		[DispId(7)]
		bool DrawFirstHeaderFooterWhenJumpPrintMode
		{
			get;
			set;
		}

		/// <summary>属性FromPage</summary>
		[DispId(8)]
		int FromPage
		{
			get;
			set;
		}

		/// <summary>属性GlobalPageIndexFix</summary>
		[DispId(9)]
		int GlobalPageIndexFix
		{
			get;
			set;
		}

		/// <summary>属性JumpPrint</summary>
		[DispId(10)]
		JumpPrintInfo JumpPrint
		{
			get;
			set;
		}

		/// <summary>属性ManualDuplex</summary>
		[DispId(11)]
		bool ManualDuplex
		{
			get;
			set;
		}

		/// <summary>属性PaperSourceName</summary>
		[DispId(12)]
		string PaperSourceName
		{
			get;
			set;
		}

		/// <summary>属性PreparePrintJob</summary>
		[DispId(13)]
		bool PreparePrintJob
		{
			get;
			set;
		}

		/// <summary>属性PrinterName</summary>
		[DispId(14)]
		string PrinterName
		{
			get;
			set;
		}

		/// <summary>属性PrintMode</summary>
		[DispId(15)]
		DCPrintMode PrintMode
		{
			get;
			set;
		}

		/// <summary>属性PrintRange</summary>
		[DispId(16)]
		PrintRange PrintRange
		{
			get;
			set;
		}

		/// <summary>属性ShowDebugMessage</summary>
		[DispId(17)]
		bool ShowDebugMessage
		{
			get;
			set;
		}

		/// <summary>属性SpecifyCopies</summary>
		[DispId(18)]
		int SpecifyCopies
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPageIndexs</summary>
		[DispId(19)]
		List<int> SpecifyPageIndexs
		{
			get;
			set;
		}

		/// <summary>属性ToPage</summary>
		[DispId(20)]
		int ToPage
		{
			get;
			set;
		}

		/// <summary>方法Clone</summary>
		[DispId(2)]
		DCPrintDocumentOptions Clone();
	}
}
