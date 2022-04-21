using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       加载知识库节点模板内容事件委托类型
	///       </summary>
	/// <param name="sender">参数</param>
	/// <param name="args">参数</param>
	[Guid("8C9EC181-9B3E-4870-AC59-AEC10D1476BA")]
	[ComVisible(true)]
	
	
	public delegate void KBEntryLoadTemplateContentEventHandler(object sender, KBEntryLoadTemplateContentEventArgs e);
}
