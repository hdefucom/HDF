using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内容区域样式
	///       </summary>
	[Guid("3AC7F75D-30FA-4388-91E4-E56467461766")]
	[DocumentComment]
	
	[ComVisible(true)]
	public enum ContentRangeMode
	{
		/// <summary>
		///       文档内容
		///       </summary>
		Content,
		/// <summary>
		///       纯表格单元格
		///       </summary>
		Cell,
		/// <summary>
		///       混合模式，包括文档内容和表格单元格
		///       </summary>
		Mixed
	}
}
