using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       打印每页内容事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[Guid("64EDF32F-CFD9-46ED-9B5A-B5927D1C978C")]
	[DCPublishAPI]
	[ComVisible(true)]
	[DocumentComment]
	public delegate void WriterPrintPageEventHandler(object sender, WriterPrintPageEventEventArgs e);
}
