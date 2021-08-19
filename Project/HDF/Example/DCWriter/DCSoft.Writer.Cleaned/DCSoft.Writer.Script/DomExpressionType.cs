using System.Runtime.InteropServices;

namespace DCSoft.Writer.Script
{
	/// <summary>
	///       表达式类型
	///       </summary>
	[ComVisible(false)]
	public enum DomExpressionType
	{
		/// <summary>
		///       简单的表达式类型
		///       </summary>
		Simple,
		/// <summary>
		///       脚本表达式
		///       </summary>
		Script,
		/// <summary>
		///        自定义表达式
		///       </summary>
		Custom
	}
}
