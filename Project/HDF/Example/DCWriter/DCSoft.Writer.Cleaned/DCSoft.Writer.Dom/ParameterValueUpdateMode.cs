using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       参数值更新方式
	///       </summary>
	[ComVisible(false)]
	public enum ParameterValueUpdateMode
	{
		/// <summary>
		///       固定值
		///       </summary>
		Fixed,
		/// <summary>
		///       加载文档后更新内容
		///       </summary>
		UpdateWhenAfterLoad,
		/// <summary>
		///       动态更新
		///       </summary>
		DynamicUpdate
	}
}
