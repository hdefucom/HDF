using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>DocumentPageSettings 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("0AE918FD-08BF-4655-9A90-A7BEF48F2673")]
	public interface IDocumentPageSettings
	{
		/// <summary>属性BottomMargin</summary>
		[DispId(2)]
		int BottomMargin
		{
			get;
			set;
		}

		/// <summary>属性Landscape</summary>
		[DispId(3)]
		bool Landscape
		{
			get;
			set;
		}

		/// <summary>属性LeftMargin</summary>
		[DispId(4)]
		int LeftMargin
		{
			get;
			set;
		}

		/// <summary>属性PaperHeight</summary>
		[DispId(5)]
		int PaperHeight
		{
			get;
			set;
		}

		/// <summary>属性PaperSizeName</summary>
		[DispId(6)]
		string PaperSizeName
		{
			get;
			set;
		}

		/// <summary>属性PaperWidth</summary>
		[DispId(7)]
		int PaperWidth
		{
			get;
			set;
		}

		/// <summary>属性RightMargin</summary>
		[DispId(8)]
		int RightMargin
		{
			get;
			set;
		}

		/// <summary>属性TopMargin</summary>
		[DispId(9)]
		int TopMargin
		{
			get;
			set;
		}

		/// <summary>属性AutoFitPageSize</summary>
		[DispId(10)]
		bool AutoFitPageSize
		{
			get;
			set;
		}
	}
}
