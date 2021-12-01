using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       根据知识库节点创建文档元素对象事件委托类型
	///       </summary>
	/// <param name="eventSender">
	/// </param>
	/// <param name="args">
	/// </param>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("D86B02F9-36FF-4FEA-B61E-3043471DCC85")]
	public delegate void CreateElementsByKBEntryEventHandler(object sender, CreateElementsByKBEntryEventArgs e);
}
