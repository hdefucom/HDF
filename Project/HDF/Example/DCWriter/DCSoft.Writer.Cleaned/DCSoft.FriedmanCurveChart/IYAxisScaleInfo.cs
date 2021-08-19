using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>YAxisScaleInfo 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Guid("694CCFD3-83A1-45D3-B464-C7C084E785EB")]
	[Browsable(false)]
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
