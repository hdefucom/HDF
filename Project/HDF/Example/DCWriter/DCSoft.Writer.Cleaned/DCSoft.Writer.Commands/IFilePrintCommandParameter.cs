using DCSoft.Printing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>FilePrintCommandParameter 的COM接口</summary>
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("4840FBE8-F48F-4D45-8ED9-E9915FCE0D9D")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IFilePrintCommandParameter
	{
		/// <summary>属性CleanPrintMode</summary>
		[DispId(3)]
		bool CleanPrintMode
		{
			get;
			set;
		}

		/// <summary>属性DrawFirstHeaderFooterWhenJumpPrintMode</summary>
		[DispId(8)]
		bool DrawFirstHeaderFooterWhenJumpPrintMode
		{
			get;
			set;
		}

		/// <summary>属性JumpPrintInfo</summary>
		[DispId(4)]
		JumpPrintInfo JumpPrintInfo
		{
			get;
			set;
		}

		/// <summary>属性ManualDuplex</summary>
		[DispId(5)]
		bool ManualDuplex
		{
			get;
			set;
		}

		/// <summary>属性SpecifyCopies</summary>
		[DispId(7)]
		int SpecifyCopies
		{
			get;
			set;
		}

		/// <summary>属性SpecifyPrinterName</summary>
		[DispId(9)]
		string SpecifyPrinterName
		{
			get;
			set;
		}

		/// <summary>方法AddSpecifyPageIndex</summary>
		[DispId(6)]
		void AddSpecifyPageIndex(int pageIndex);

		/// <summary>方法SetSpecifyPageIndexs</summary>
		[DispId(2)]
		void SetSpecifyPageIndexs(string indexs);
	}
}
