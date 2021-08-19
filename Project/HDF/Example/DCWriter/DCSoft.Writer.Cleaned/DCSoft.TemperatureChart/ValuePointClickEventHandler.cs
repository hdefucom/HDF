using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       数据点点击事件委托对象
	///       </summary>
	[Guid("7CB2272E-E00A-4556-A4E9-EB90556FBCC3")]
	[ComVisible(true)]
	public delegate void ValuePointClickEventHandler(object sender, ValuePointClickEventArgs e);
}
