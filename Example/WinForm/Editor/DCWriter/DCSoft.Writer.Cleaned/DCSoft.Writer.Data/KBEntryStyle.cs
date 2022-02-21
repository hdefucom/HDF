using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       知识点类型
	///       </summary>
	[DocumentComment]
	[Guid("00012345-6789-ABCD-EF01-234567890030")]
	
	[ComVisible(true)]
	public enum KBEntryStyle
	{
		/// <summary>
		///       下拉列表
		///       </summary>
		List,
		/// <summary>
		///       自己设置了SQL语句来加载列表内容
		///       </summary>
		ListSQL,
		/// <summary>
		///       模板
		///       </summary>
		Template,
		/// <summary>
		///       文本输入域
		///       </summary>
		InputField,
		/// <summary>
		///       数字输入域
		///       </summary>
		NumberField,
		/// <summary>
		///       日期输入域
		///       </summary>
		DateTimeField,
		/// <summary>
		///       多选下拉列表
		///       </summary>
		MultiList,
		/// <summary>
		///       复选框列表
		///       </summary>
		CheckBoxList,
		/// <summary>
		///       单元格列表
		///       </summary>
		RadioList
	}
}
