using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       字符圈样式
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("9BA67798-F22C-487E-BE98-305C14241484")]
	[DocumentComment]
	[ComVisible(true)]
	
	public enum CharacterCircleStyles
	{
		/// <summary>
		///       无字符圈
		///       </summary>
		None,
		/// <summary>
		///       圆形字符圈
		///       </summary>
		Circle,
		/// <summary>
		///       矩形字符圈
		///       </summary>
		Rectangle
	}
}
