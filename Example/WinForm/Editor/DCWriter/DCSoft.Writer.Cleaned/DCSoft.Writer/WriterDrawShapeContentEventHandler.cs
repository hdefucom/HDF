using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       绘制图形事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	
	[Guid("82C5D39B-7300-4F03-90BD-010437F1C419")]
	[ComVisible(false)]
	public delegate void WriterDrawShapeContentEventHandler(object sender, WriterDrawShapeContentEventArgs e);
}
