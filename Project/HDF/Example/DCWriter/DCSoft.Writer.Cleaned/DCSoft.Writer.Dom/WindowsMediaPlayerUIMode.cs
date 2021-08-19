using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       内置的媒体播放器界面模式
	///       </summary>
	[ComVisible(true)]
	[Guid("10656616-F932-4D9F-9365-C5691B3D64D9")]
	public enum WindowsMediaPlayerUIMode
	{
		/// <summary>
		///       不可见的
		///       </summary>
		invisible,
		/// <summary>
		///       无控件
		///       </summary>
		none,
		/// <summary>
		///       精简模式
		///       </summary>
		mini,
		/// <summary>
		///       完整模式
		///       </summary>
		full
	}
}
