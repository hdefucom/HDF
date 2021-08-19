using System.Runtime.InteropServices;

namespace DCSoft.WinForms.Native
{
	[ComVisible(false)]
	public enum AnimatedDrawStyle
	{
		/// <summary>
		///       无样式
		///       </summary>
		None,
		/// <summary>
		///       系统样式
		///       </summary>
		System,
		/// <summary>
		///       矩形
		///       </summary>
		Rectangle,
		/// <summary>
		///       旋转矩形样式
		///       </summary>
		RotateRectangle
	}
}
