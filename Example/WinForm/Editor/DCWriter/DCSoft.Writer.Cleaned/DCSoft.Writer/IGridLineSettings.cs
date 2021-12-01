using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>GridLineSettings 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("18A4C37F-F6AC-4617-B27F-DAE378CE8E13")]
	public interface IGridLineSettings
	{
		/// <summary>属性GridLineColor</summary>
		[DispId(2)]
		Color GridLineColor
		{
			get;
			set;
		}

		/// <summary>属性GridLineColorValue</summary>
		[DispId(3)]
		string GridLineColorValue
		{
			get;
			set;
		}

		/// <summary>属性LineStyle</summary>
		[DispId(6)]
		DashStyle LineStyle
		{
			get;
			set;
		}

		/// <summary>属性PrintGridLine</summary>
		[DispId(4)]
		bool PrintGridLine
		{
			get;
			set;
		}

		/// <summary>属性ShowGridLine</summary>
		[DispId(5)]
		bool ShowGridLine
		{
			get;
			set;
		}
	}
}
