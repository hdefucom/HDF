using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       编辑数据点事件参数
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[ComVisible(true)]
	[Guid("3EBDE4DC-C655-42AB-845C-3980914DA0AD")]
	public delegate void EditValuePointEventHandler(object sender, EditValuePointEventArgs e);
}
