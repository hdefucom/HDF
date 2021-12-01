using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Printing
{
	/// <summary>DCGridLineInfo 的COM接口</summary>
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[Guid("6A9CB5D0-49CA-4BFE-BFE2-4902A7E79214")]
	public interface IDCGridLineInfo
	{
		/// <summary>属性AlignToGridLine</summary>
		[DispId(2)]
		bool AlignToGridLine
		{
			get;
			set;
		}

		/// <summary>属性Color</summary>
		[DispId(3)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorValue</summary>
		[DispId(4)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性GridNumInOnePage</summary>
		[DispId(5)]
		int GridNumInOnePage
		{
			get;
			set;
		}

		/// <summary>属性GridSpanInCM</summary>
		[DispId(6)]
		float GridSpanInCM
		{
			get;
			set;
		}

		/// <summary>属性LineStyle</summary>
		[DispId(7)]
		DashStyle LineStyle
		{
			get;
			set;
		}

		/// <summary>属性LineWidth</summary>
		[DispId(8)]
		float LineWidth
		{
			get;
			set;
		}

		/// <summary>属性Printable</summary>
		[DispId(10)]
		bool Printable
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(11)]
		bool Visible
		{
			get;
			set;
		}
	}
}
