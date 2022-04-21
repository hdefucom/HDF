using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       背景文字输出模式
	///       </summary>
	[ComVisible(false)]
	
	
	public enum DCBackgroundTextOutputMode
	{
		/// <summary>
		///       不输出
		///       </summary>
		None,
		/// <summary>
		///       输出空白字符
		///       </summary>
		Whitespace,
		/// <summary>
		///       输出文本
		///       </summary>
		Output,
		/// <summary>
		///       输出为下划线
		///       </summary>
		Underline
	}
}
