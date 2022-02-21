using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文档图形对象标志
	///       </summary>
	[ComVisible(false)]
	
	[Flags]
	public enum DocumentImageFlags
	{
		/// <summary>
		///       无状态
		///       </summary>
		None = 0x0,
		/// <summary>
		///       自定义的绘制背景
		///       </summary>
		CustomBackground = 0x1
	}
}
