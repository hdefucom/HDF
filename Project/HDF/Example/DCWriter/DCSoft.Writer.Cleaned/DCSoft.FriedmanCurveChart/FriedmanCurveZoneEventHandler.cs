using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       时间区域事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("CF94AF81-7734-4983-ABA8-CE6D3C00C59A")]
	[ComVisible(true)]
	public delegate void FriedmanCurveZoneEventHandler(object sender, FriedmanCurveZoneEventArgs e);
}
