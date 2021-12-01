using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       方向
	///       </summary>
	[Guid("9372E347-F535-4F39-89C7-5247D8891C24")]
	[DCPublishAPI]
	[ComVisible(true)]
	public enum DCDirection
	{
		/// <summary>
		///       左
		///       </summary>
		Left,
		/// <summary>
		///       上
		///       </summary>
		Top,
		/// <summary>
		///       右
		///       </summary>
		Right,
		/// <summary>
		///       下
		///       </summary>
		Bottom
	}
}
