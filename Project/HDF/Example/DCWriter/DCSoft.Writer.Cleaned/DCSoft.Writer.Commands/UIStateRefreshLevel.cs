using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       用户界面命令控件刷新等级
	///       </summary>
	[ComVisible(true)]
	[Guid("B1DF9D77-628C-4CBF-9710-488CD89172E6")]
	[DCPublishAPI]
	public enum UIStateRefreshLevel
	{
		/// <summary>
		///       不刷新
		///       </summary>
		None,
		/// <summary>
		///       只刷新当前命令绑定的用户界面控件的状态
		///       </summary>
		Current,
		/// <summary>
		///       刷新所有的用户界面控件的状态
		///       </summary>
		All
	}
}
