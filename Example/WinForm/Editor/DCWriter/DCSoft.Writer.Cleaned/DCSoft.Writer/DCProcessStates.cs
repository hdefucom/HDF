using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       操作状态
	///       </summary>
	
	[Guid("D6DE82F0-456E-47A2-AB9F-D0D393D6C923")]
	
	[ComVisible(true)]
	public enum DCProcessStates
	{
		/// <summary>
		///       总是执行
		///       </summary>
		[DCDescription(typeof(DCProcessStates), "Always")]
		Always,
		/// <summary>
		///       只执行一次
		///       </summary>
		[DCDescription(typeof(DCProcessStates), "Once")]
		Once,
		/// <summary>
		///       从不执行
		///       </summary>
		[DCDescription(typeof(DCProcessStates), "Never")]
		Never
	}
}
