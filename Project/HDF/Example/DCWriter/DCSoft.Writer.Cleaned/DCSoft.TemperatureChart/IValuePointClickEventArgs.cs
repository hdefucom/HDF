using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>ValuePointClickEventArgs 的COM接口</summary>
	[ComVisible(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Guid("3CCC98ED-57ED-4855-8A32-D955579FE7F0")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IValuePointClickEventArgs
	{
		/// <summary>属性Point</summary>
		[DispId(2)]
		ValuePoint Point
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
		TitleLineInfo TitleLine
		{
			get;
		}

		/// <summary>属性YAxis</summary>
		[DispId(3)]
		YAxisInfo YAxis
		{
			get;
		}
	}
}
