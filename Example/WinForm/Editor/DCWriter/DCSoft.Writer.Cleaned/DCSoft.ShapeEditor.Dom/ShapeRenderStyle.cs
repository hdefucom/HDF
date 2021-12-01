using System.Runtime.InteropServices;

namespace DCSoft.ShapeEditor.Dom
{
	/// <summary>
	///       图形呈现模式
	///       </summary>
	[ComVisible(false)]
	public enum ShapeRenderStyle
	{
		/// <summary>
		///       在用户界面上绘制图形
		///       </summary>
		Paint,
		/// <summary>
		///       打印时绘制图形
		///       </summary>
		Print
	}
}
