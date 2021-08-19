using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       事件表达式执行目标查找方式
	///       </summary>
	[Guid("71893968-7D77-45F7-A5DE-2C232387DDD6")]
	[DocumentComment]
	[ComVisible(true)]
	public enum EventExpressionTarget
	{
		/// <summary>
		///       下一个元素
		///       </summary>
		NextElement,
		/// <summary>
		///       自定义
		///       </summary>
		Custom,
		/// <summary>
		///       不指定任何元素
		///       </summary>
		None
	}
}
