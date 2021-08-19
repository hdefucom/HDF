using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       插入点位置修正方向
	///       </summary>
	[ComVisible(false)]
	[DCInternal]
	public enum FixIndexDirection
	{
		/// <summary>
		///       向前修正
		///       </summary>
		Forward,
		/// <summary>
		///       向后修正
		///       </summary>
		Back,
		/// <summary>
		///       所有的方向
		///       </summary>
		Both
	}
}
