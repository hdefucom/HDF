using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       打印事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[DocumentComment]
	
	[Guid("B526EB58-AF98-407F-BDD5-B5D4F436DB6B")]
	[ComVisible(true)]
	public delegate void WriterPrintEventHandler(object sender, WriterPrintEventEventArgs e);
}
