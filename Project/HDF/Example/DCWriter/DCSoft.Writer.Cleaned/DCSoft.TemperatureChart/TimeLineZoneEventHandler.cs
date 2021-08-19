using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间区域事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("1A4043FD-D083-4D07-B673-98E48865FA35")]
	[ComVisible(true)]
	public delegate void TimeLineZoneEventHandler(object sender, TimeLineZoneEventArgs e);
}
