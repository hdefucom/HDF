using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       移动目标
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[Guid("EF6EAA22-1372-4776-B72D-1CDE7DEA08DD")]
	[ComVisible(true)]
	
	
	public enum MoveTarget
	{
		/// <summary>
		///       无意义
		///       </summary>
		None,
		/// <summary>
		///       文档开头
		///       </summary>
		DocumentHome,
		/// <summary>
		///       文档尾
		///       </summary>
		DocumentEnd,
		/// <summary>
		///       单元格的开头
		///       </summary>
		CellHome,
		/// <summary>
		///       单元格结尾
		///       </summary>
		CellEnd,
		/// <summary>
		///       上一个单元格
		///       </summary>
		PreCell,
		/// <summary>
		///       下一个单元格
		///       </summary>
		NextCell,
		/// <summary>
		///       表格前面
		///       </summary>
		BeforeTable,
		/// <summary>
		///       表格后面
		///       </summary>
		AfterTable,
		/// <summary>
		///       文档域前面
		///       </summary>
		BeforeField,
		/// <summary>
		///       文档域后面
		///       </summary>
		AfterField,
		/// <summary>
		///       段落开头
		///       </summary>
		ParagraphHome,
		/// <summary>
		///       段落尾
		///       </summary>
		ParagraphEnd,
		/// <summary>
		///       上一行
		///       </summary>
		PreLine,
		/// <summary>
		///       下一行
		///       </summary>
		NextLine,
		/// <summary>
		///       输入域开头
		///       </summary>
		FieldHome,
		/// <summary>
		///       输入域结尾
		///       </summary>
		FieldEnd,
		/// <summary>
		///       行首
		///       </summary>
		Home,
		/// <summary>
		///       行尾
		///       </summary>
		End,
		/// <summary>
		///       当前页首
		///       </summary>
		PageHome,
		/// <summary>
		///       当前页尾
		///       </summary>
		PageEnd,
		/// <summary>
		///       视图开始位置
		///       </summary>
		ViewHome,
		/// <summary>
		///       视图结束位置
		///       </summary>
		ViewEnd
	}
}
