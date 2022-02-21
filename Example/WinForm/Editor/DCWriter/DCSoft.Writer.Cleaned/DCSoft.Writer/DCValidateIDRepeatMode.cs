using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       ID重复性校验行为
	///       </summary>
	[Guid("9A5DBD4B-5389-4D6C-941B-3E2F139795F4")]
	
	[DocumentComment]
	[ComVisible(true)]
	public enum DCValidateIDRepeatMode
	{
		/// <summary>
		///       不做任何校验
		///       </summary>
		None,
		/// <summary>
		///       只进行检查，不校验
		///       </summary>
		DetectOnly,
		/// <summary>
		///       自动修正ID号
		///       </summary>
		AutoFix,
		/// <summary>
		///       抛出异常
		///       </summary>
		ThrowException
	}
}
