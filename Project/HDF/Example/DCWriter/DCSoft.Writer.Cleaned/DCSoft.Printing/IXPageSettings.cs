using DCSoft.Drawing;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>XPageSettings 的COM接口</summary>
	[Browsable(false)]
	[ComVisible(true)]
	[Guid("8CCA7539-5D1E-4EF5-924B-931C4B16313C")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IXPageSettings
	{
		/// <summary>属性AutoChoosePageSize</summary>
		[DispId(26)]
		bool AutoChoosePageSize
		{
			get;
			set;
		}

		/// <summary>属性AutoFitPageSize</summary>
		[DispId(2)]
		bool AutoFitPageSize
		{
			get;
			set;
		}

		/// <summary>属性AutoPaperWidth</summary>
		[DispId(3)]
		bool AutoPaperWidth
		{
			get;
			set;
		}

		/// <summary>属性BottomMargin</summary>
		[DispId(4)]
		int BottomMargin
		{
			get;
			set;
		}

		/// <summary>属性BottomMarginInCM</summary>
		[DispId(29)]
		float BottomMarginInCM
		{
			get;
			set;
		}

		/// <summary>属性Copies</summary>
		[DispId(5)]
		int Copies
		{
			get;
			set;
		}

		/// <summary>属性DocumentGridLine</summary>
		[DispId(28)]
		DCGridLineInfo DocumentGridLine
		{
			get;
			set;
		}

		/// <summary>属性EditTimeBackgroundImage</summary>
		[DispId(6)]
		XImageValue EditTimeBackgroundImage
		{
			get;
			set;
		}

		/// <summary>属性FooterDistance</summary>
		[DispId(7)]
		int FooterDistance
		{
			get;
			set;
		}

		/// <summary>属性ForPOSPrinter</summary>
		[DispId(23)]
		bool ForPOSPrinter
		{
			get;
			set;
		}

		/// <summary>属性HeaderDistance</summary>
		[DispId(8)]
		int HeaderDistance
		{
			get;
			set;
		}

		/// <summary>属性HeaderFooterDifferentFirstPage</summary>
		[DispId(33)]
		bool HeaderFooterDifferentFirstPage
		{
			get;
			set;
		}

		/// <summary>属性Landscape</summary>
		[DispId(9)]
		bool Landscape
		{
			get;
			set;
		}

		/// <summary>属性LeftMargin</summary>
		[DispId(10)]
		int LeftMargin
		{
			get;
			set;
		}

		/// <summary>属性LeftMarginInCM</summary>
		[DispId(30)]
		float LeftMarginInCM
		{
			get;
			set;
		}

		/// <summary>属性Margins</summary>
		[DispId(11)]
		Margins Margins
		{
			get;
			set;
		}

		/// <summary>属性OffsetX</summary>
		[DispId(12)]
		float OffsetX
		{
			get;
			set;
		}

		/// <summary>属性OffsetY</summary>
		[DispId(13)]
		float OffsetY
		{
			get;
			set;
		}

		/// <summary>属性PageBorderBackground</summary>
		[DispId(22)]
		PageBorderBackgroundStyle PageBorderBackground
		{
			get;
			set;
		}

		/// <summary>属性PageIndexsForHideHeaderFooter</summary>
		[DispId(25)]
		string PageIndexsForHideHeaderFooter
		{
			get;
			set;
		}

		/// <summary>属性PaperHeight</summary>
		[DispId(14)]
		int PaperHeight
		{
			get;
			set;
		}

		/// <summary>属性PaperKind</summary>
		[DispId(15)]
		PaperKind PaperKind
		{
			get;
			set;
		}

		/// <summary>属性PaperSize</summary>
		[DispId(16)]
		PaperSize PaperSize
		{
			get;
			set;
		}

		/// <summary>属性PaperSource</summary>
		[DispId(17)]
		string PaperSource
		{
			get;
			set;
		}

		/// <summary>属性PaperWidth</summary>
		[DispId(18)]
		int PaperWidth
		{
			get;
			set;
		}

		/// <summary>属性PrinterName</summary>
		[DispId(19)]
		string PrinterName
		{
			get;
			set;
		}

		/// <summary>属性RightMargin</summary>
		[DispId(20)]
		int RightMargin
		{
			get;
			set;
		}

		/// <summary>属性RightMarginInCM</summary>
		[DispId(31)]
		float RightMarginInCM
		{
			get;
			set;
		}

		/// <summary>属性SpecifyDuplex</summary>
		[DispId(34)]
		DCDuplexType SpecifyDuplex
		{
			get;
			set;
		}

		/// <summary>属性SwapLeftRightMargin</summary>
		[DispId(35)]
		bool SwapLeftRightMargin
		{
			get;
			set;
		}

		/// <summary>属性TerminalText</summary>
		[DispId(27)]
		DocumentTerminalTextInfo TerminalText
		{
			get;
			set;
		}

		/// <summary>属性TopMargin</summary>
		[DispId(21)]
		int TopMargin
		{
			get;
			set;
		}

		/// <summary>属性TopMarginInCM</summary>
		[DispId(32)]
		float TopMarginInCM
		{
			get;
			set;
		}

		/// <summary>属性Watermark</summary>
		[DispId(24)]
		WatermarkInfo Watermark
		{
			get;
			set;
		}

		/// <summary>属性EnableHeaderFooter</summary>
		[DispId(40)]
		bool EnableHeaderFooter
		{
			get;
			set;
		}
	}
}
