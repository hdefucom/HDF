using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.WinForms
{
	/// <summary>
	///       滚动到视图的样式
	///       </summary>
	[DocumentComment]
	[Guid("F95F03FF-AA45-421E-A210-954986DD8B4E")]
	[ComVisible(true)]
	public enum ScrollToViewStyle
	{
		/// <summary>
		///       正常模式
		///       </summary>
		Normal,
		/// <summary>
		///       滚动到顶端
		///       </summary>
		Top,
		/// <summary>
		///       滚动到中间
		///       </summary>
		Middle,
		/// <summary>
		///       滚动到低端
		///       </summary>
		Bottom
	}
}
