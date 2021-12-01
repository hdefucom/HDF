using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       元素Z坐标位置类型
	///       </summary>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("340FF3DC-F8DE-4666-9B15-8D91F854E9E1")]
	public enum ElementZOrderStyle
	{
		/// <summary>
		///       正常模式
		///       </summary>
		Normal,
		/// <summary>
		///       在文本之下
		///       </summary>
		UnderText,
		/// <summary>
		///       在文本前面
		///       </summary>
		InFrontOfText
	}
}
