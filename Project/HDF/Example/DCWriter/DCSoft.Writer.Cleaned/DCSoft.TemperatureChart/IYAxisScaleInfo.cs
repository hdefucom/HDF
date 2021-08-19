using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>YAxisScaleInfo 的COM接口</summary>
	[Browsable(false)]
	[Guid("F54EB66F-C7CA-4DB9-91C4-77A97438B6ED")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IYAxisScaleInfo
	{
		/// <summary>属性Color</summary>
		[DispId(5)]
		Color Color
		{
			get;
			set;
		}

		/// <summary>属性ColorValue</summary>
		[DispId(6)]
		string ColorValue
		{
			get;
			set;
		}

		/// <summary>属性ScaleRate</summary>
		[DispId(2)]
		float ScaleRate
		{
			get;
			set;
		}

		/// <summary>属性Text</summary>
		[DispId(3)]
		string Text
		{
			get;
			set;
		}

		/// <summary>属性Value</summary>
		[DispId(4)]
		float Value
		{
			get;
			set;
		}
	}
}
