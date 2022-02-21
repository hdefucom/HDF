using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询用户历史痕迹显示文本事件
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[Guid("AF8B2F2B-E77D-4CE6-B012-6A7AC1A13E9F")]
	[DocumentComment]
	
	[ComVisible(true)]
	public delegate void QueryUserHistoryDisplayTextEventHandler(object sender, QueryUserHistoryDisplayTextEventArgs e);
}
