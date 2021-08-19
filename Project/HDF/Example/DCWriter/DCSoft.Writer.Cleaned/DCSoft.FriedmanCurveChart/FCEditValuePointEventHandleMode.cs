using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑数据点事件处理模式
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum FCEditValuePointEventHandleMode
	{
		/// <summary>
		///       不允许编辑数据点
		///       </summary>
		None,
		/// <summary>
		///       应用程序编程处理
		///       </summary>
		Program,
		/// <summary>
		///       静默模式
		///       </summary>
		Silent,
		/// <summary>
		///       使用内置的用户界面
		///       </summary>
		OwnedUI
	}
}
