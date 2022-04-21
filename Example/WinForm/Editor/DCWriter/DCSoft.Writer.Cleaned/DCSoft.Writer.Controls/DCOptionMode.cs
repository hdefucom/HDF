using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Controls
{
	/// <summary>
	///       选项状态
	///       </summary>
	
	[Guid("72317938-F0CD-430D-8730-C9ED807F91BC")]
	[ComVisible(true)]
	public enum DCOptionMode
	{
		/// <summary>
		///       启用状态
		///       </summary>
		True,
		/// <summary>
		///       禁止状态
		///       </summary>
		False,
		/// <summary>
		///       自动检测
		///       </summary>
		AutoDetect
	}
}
