using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>TimeLineZoneEventArgs 的COM接口</summary>
	[Guid("2DE44842-5AD0-48BC-95DB-1CE9A961EE80")]
	[Browsable(false)]
	[ComVisible(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ITimeLineZoneEventArgs
	{
		/// <summary>属性Document</summary>
		[DispId(2)]
		TemperatureDocument Document
		{
			get;
		}

		/// <summary>属性Zone</summary>
		[DispId(3)]
		TimeLineZoneInfo Zone
		{
			get;
		}
	}
}
