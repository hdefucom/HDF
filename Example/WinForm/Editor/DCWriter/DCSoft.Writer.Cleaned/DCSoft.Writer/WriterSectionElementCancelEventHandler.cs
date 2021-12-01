using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       可取消的文档节元素事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	[Guid("C9C216D6-71E5-4DDB-8366-1E6A68E21C44")]
	public delegate void WriterSectionElementCancelEventHandler(object sender, WriterSectionElementCancelEventArgs e);
}
