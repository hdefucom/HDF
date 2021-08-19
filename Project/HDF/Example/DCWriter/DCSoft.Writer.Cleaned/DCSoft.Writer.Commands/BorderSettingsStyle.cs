using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       边框设置样式
	///       </summary>
	[ComVisible(false)]
	[Flags]
	public enum BorderSettingsStyle
	{
		/// <summary>
		///       无边框
		///       </summary>
		None = 0x0,
		/// <summary>
		///       方框
		///       </summary>
		Rectangle = 0x1,
		/// <summary>
		///       全部
		///       </summary>
		Both = 0x2,
		/// <summary>
		///       自定义
		///       </summary>
		Custom = 0x3
	}
}
