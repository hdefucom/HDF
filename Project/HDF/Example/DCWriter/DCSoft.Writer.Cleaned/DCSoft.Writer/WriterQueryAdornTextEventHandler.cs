using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       查询文档元素扩展标记文本事件委托类型
	///       </summary>
	/// <param name="eventSender">参数</param>
	/// <param name="args">参数</param>
	/// <remarks>编制 袁永福</remarks>
	[Guid("98572E71-BE53-41B0-A527-EB250D66FBE2")]
	[ComVisible(true)]
	[DocumentComment]
	[DCPublishAPI]
	public delegate void WriterQueryAdornTextEventHandler(object sender, WriterQueryAdornTextEventArgs e);
}
