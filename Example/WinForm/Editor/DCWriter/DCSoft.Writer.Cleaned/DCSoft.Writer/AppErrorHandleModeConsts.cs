using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       应用程序错误处理模式
	///       </summary>
	[DocumentComment]
	[Guid("0597BC05-6B99-45B3-AD46-7C45B9FAB4CD")]
	[ComVisible(true)]
	public enum AppErrorHandleModeConsts
	{
		/// <summary>
		///       不做处理
		///       </summary>
		None,
		/// <summary>
		///       抛出异常
		///       </summary>
		ThrowException,
		/// <summary>
		///       忽略错误。
		///       </summary>
		Ignore,
		/// <summary>
		///       显示消息
		///       </summary>
		ShowMessge,
		/// <summary>
		///       显示详细信息
		///       </summary>
		ShowDetailMessage
	}
}
