using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       垂直对齐方式
	///       </summary>
	[Guid("E8B4C28E-25C8-451E-A4B1-D7475FDCC3FB")]
	
	[ComVisible(true)]
	public enum VerticalAlignStyle
	{
		/// <summary>
		///       对齐到顶端
		///       </summary>
		Top,
		/// <summary>
		///       垂直居中对齐
		///       </summary>
		Middle,
		/// <summary>
		///       对齐到底端
		///       </summary>
		Bottom
	}
}
