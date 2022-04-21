using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       打印时查询页面设置事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[ComVisible(true)]
	[Guid("F9A8E04A-B3A0-499B-B417-28C4898711AB")]
	
	
	public delegate void WriterPrintQueryPageSettingsEventHandler(object sender, WriterPrintQueryPageSettingsEventArgs e);
}
