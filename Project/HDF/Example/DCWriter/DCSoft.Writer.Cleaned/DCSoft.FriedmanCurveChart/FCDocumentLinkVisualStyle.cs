using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       超链接可视化模式
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public enum FCDocumentLinkVisualStyle
	{
		/// <summary>
		///       无效果
		///       </summary>
		None,
		/// <summary>
		///       鼠标悬浮就显示
		///       </summary>
		Hover,
		/// <summary>
		///       一直显示
		///       </summary>
		Always
	}
}
