using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>XPenStyle 的COM接口</summary>
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("A2F1D3B1-F2B5-4749-96E5-E548D0AAA1F3")]
	[ComVisible(true)]
	[Browsable(false)]
	public interface IXPenStyle
	{
		/// <summary>属性Color</summary>
		[DispId(2)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorString</summary>
		[DispId(3)]
		string ColorString
		{
			get;
			set;
		}

		/// <summary>属性DashStyle</summary>
		[DispId(4)]
		DashStyle DashStyle
		{
			get;
			set;
		}

		/// <summary>属性Width</summary>
		[DispId(5)]
		float Width
		{
			get;
			set;
		}
	}
}
