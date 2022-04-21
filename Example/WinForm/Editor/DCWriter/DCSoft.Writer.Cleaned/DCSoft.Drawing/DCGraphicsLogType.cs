using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       图形记录类型
	///       </summary>
	[ComVisible(false)]
	
	
	public enum DCGraphicsLogType
	{
		/// <summary>
		///       不记录
		///       </summary>
		None,
		/// <summary>
		///       只记录内容数据
		///       </summary>
		Content,
		/// <summary>
		///       图形数据
		///       </summary>
		Graphics
	}
}
