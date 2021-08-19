using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Expression
{
	/// <summary>
	///       绑定表达式样式
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum BindingExpressionStyle
	{
		/// <summary>
		///       表达式
		///       </summary>
		Expression,
		/// <summary>
		///       数据源绑定
		///       </summary>
		DataBinding,
		/// <summary>
		///       脚本
		///       </summary>
		Script
	}
}
