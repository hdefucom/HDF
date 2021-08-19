using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>GridLineInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[Guid("45D41CAF-FDE9-4AE9-8B95-2935FE7426E5")]
	[Browsable(false)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IGridLineInfo
	{
		/// <summary>属性ColorValue</summary>
		[DispId(2)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性DashStyle</summary>
		[DispId(3)]
		DashStyle DashStyle
		{
			get;
			set;
		}

		/// <summary>属性LineWidth</summary>
		[DispId(4)]
		int LineWidth
		{
			get;
			set;
		}

		/// <summary>属性Step</summary>
		[DispId(5)]
		float Step
		{
			get;
			set;
		}

		/// <summary>属性Visible</summary>
		[DispId(6)]
		bool Visible
		{
			get;
			set;
		}
	}
}
