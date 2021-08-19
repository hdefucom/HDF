using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       拖拽点位置
	///       </summary>
	[ComVisible(false)]
	public enum DragPointPositions
	{
		/// <summary>
		///       在图形内部
		///       </summary>
		Inner,
		/// <summary>
		///       在图形外部
		///       </summary>
		Outer,
		/// <summary>
		///       跨过边界
		///       </summary>
		Cross
	}
}
