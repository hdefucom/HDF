using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       控件承载模式
	///       </summary>
	[ComVisible(true)]
	[Guid("1BA2AD35-4146-4BFE-9BF6-9405D91A10FF")]
	public enum ObjectHostMode
	{
		/// <summary>
		///       禁止承载。
		///       </summary>
		Disable,
		/// <summary>
		///       静态承载,只显示预览图片，无法和用户互动。
		///       </summary>
		Static,
		/// <summary>
		///       动态承载，显示承载的对象，允许和用户互动。
		///       </summary>
		Dynamic
	}
}
