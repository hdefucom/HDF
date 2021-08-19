using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       文档超链接点击事件委托类型
	///       </summary>
	/// <param name="eventSender">事件发起者</param>
	/// <param name="args">事件参数</param>
	[Guid("DA44B130-856E-4ECA-8C53-FE76C27D7D93")]
	[ComVisible(true)]
	[DocumentComment]
	public delegate void FCDocumentLinkClickEventHandler(object sender, FCDocumentLinkClickEventArgs e);
}
