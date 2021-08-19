using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       数据点点击事件委托对象
	///       </summary>
	[ComVisible(true)]
	[Guid("F488D835-A60C-4CEF-AB3B-A1F82CC4AEC2")]
	public delegate void FCValuePointClickEventHandler(object sender, FCValuePointClickEventArgs e);
}
