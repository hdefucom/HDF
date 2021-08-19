using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       重置文档元素DOM状态的操作模式
	///       </summary>
	[ComVisible(true)]
	[Guid("AA9038E5-B29D-4D8F-BC2C-5C466A50E41E")]
	public enum ResetDomStateMode
	{
		/// <summary>
		///       无任何操作
		///       </summary>
		None,
		/// <summary>
		///       新的
		///       </summary>
		NewInputContent
	}
}
