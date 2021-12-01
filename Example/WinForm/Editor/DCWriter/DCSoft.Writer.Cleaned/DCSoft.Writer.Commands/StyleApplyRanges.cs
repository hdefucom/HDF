using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Commands
{
	/// <summary>
	///       样式应用范围
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	[Flags]
	[DCPublishAPI]
	public enum StyleApplyRanges
	{
		/// <summary>
		///       没有应用范围
		///       </summary>
		None = 0x0,
		/// <summary>
		///       应用于文本
		///       </summary>
		Text = 0x1,
		/// <summary>
		///       应用到字段
		///       </summary>
		Field = 0x2,
		/// <summary>
		///       应用到段落
		///       </summary>
		Paragraph = 0x4,
		/// <summary>
		///       应用到单元格
		///       </summary>
		Cell = 0x8,
		/// <summary>
		///       应用到表格行
		///       </summary>
		Row = 0x10,
		/// <summary>
		///       应用到表格
		///       </summary>
		Table = 0x20,
		/// <summary>
		///       应用到文档节
		///       </summary>
		Section = 0x40
	}
}
