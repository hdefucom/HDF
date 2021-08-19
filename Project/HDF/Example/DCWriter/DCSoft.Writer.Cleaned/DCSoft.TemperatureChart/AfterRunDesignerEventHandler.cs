using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.TemperatureChart
{
	/// <summary>
	///       时间轴运行设计器之后的事件的委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[Guid("3A78251F-92EF-4F5E-8F99-F3A0FADDFFCC")]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	public delegate void AfterRunDesignerEventHandler(object sender, AfterRunDesignerEventArgs e);
}
