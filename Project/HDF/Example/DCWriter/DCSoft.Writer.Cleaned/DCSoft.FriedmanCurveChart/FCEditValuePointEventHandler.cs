using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑数据点事件参数
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("02B7BFA5-9D1C-4B5B-AB61-C967BFE022F6")]
	[ComVisible(true)]
	public delegate void FCEditValuePointEventHandler(object sender, FCEditValuePointEventArgs e);
}
