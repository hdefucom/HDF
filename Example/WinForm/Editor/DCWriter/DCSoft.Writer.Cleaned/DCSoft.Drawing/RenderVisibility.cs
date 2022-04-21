using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Drawing
{
	/// <summary>
	///       文档元素可见性配置
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	
	[Flags]
	[ComVisible(true)]
	[Guid("9F8DD933-DCE4-4E00-B595-443043D64D7D")]
	public enum RenderVisibility
	{
		/// <summary>
		///       隐藏，不可见的,但仍然在用户界面上显示。
		///       </summary>
		Hidden = 0x0,
		/// <summary>
		///       在用户界面中可见
		///       </summary>
		Paint = 0x1,
		/// <summary>
		///       在打印时可见
		///       </summary>
		Print = 0x2,
		/// <summary>
		///       导出PDF时可见
		///       </summary>
		PDF = 0x4,
		/// <summary>
		///       在任何时候都可见
		///       </summary>
		All = 0xFFFF
	}
}
