using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       元素加载状态
	///       </summary>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("8B4DBBF3-60DD-44B5-A32E-6D7AC6A49575")]
	public enum DomReadyStates
	{
		/// <summary>
		///       元素尚未初始化
		///       </summary>
		UnInitialized,
		/// <summary>
		///       正在加载
		///       </summary>
		Loading,
		/// <summary>
		///       数据加载完毕
		///       </summary>
		Loaded,
		/// <summary>
		///       完全的加载完毕。
		///       </summary>
		Complete
	}
}
