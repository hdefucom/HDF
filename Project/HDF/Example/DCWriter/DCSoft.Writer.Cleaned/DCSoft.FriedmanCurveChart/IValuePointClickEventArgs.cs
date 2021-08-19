using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>ValuePointClickEventArgs 的COM接口</summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[Browsable(false)]
	[Guid("6D336771-9B76-4159-958D-E1C104E7599E")]
	[ComVisible(true)]
	public interface IValuePointClickEventArgs
	{
		/// <summary>属性Point</summary>
		[DispId(2)]
		FCValuePoint Point
		{
			get;
		}

		/// <summary>属性SerialName</summary>
		[DispId(4)]
		string SerialName
		{
			get;
		}

		/// <summary>属性SerialTitle</summary>
		[DispId(5)]
		string SerialTitle
		{
			get;
		}

		/// <summary>属性TitleLine</summary>
		[DispId(6)]
		FCTitleLineInfo TitleLine
		{
			get;
		}

		/// <summary>属性YAxis</summary>
		[DispId(3)]
		FCYAxisInfo YAxis
		{
			get;
		}
	}
}
