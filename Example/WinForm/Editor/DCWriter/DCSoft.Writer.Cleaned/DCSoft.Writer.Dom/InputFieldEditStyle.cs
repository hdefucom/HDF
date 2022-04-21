using DCSoft.Common;
using DCSoft.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       文本输入域输入方式
	///       </summary>
	[Editor(typeof(EnumEditorSupportDescription), typeof(UITypeEditor))]
	[ComVisible(true)]
	
	[Guid("AE4DE1EA-C96F-4B53-9C22-F0EEA4FCF89E")]
	public enum InputFieldEditStyle
	{
		/// <summary>
		///       直接输入纯文本
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "Text")]
		Text,
		/// <summary>
		///       下拉列表方式
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "DropdownList")]
		DropdownList,
		/// <summary>
		///       日期类型
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "Date")]
		Date,
		/// <summary>
		///       时间日期类型
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "DateTime")]
		DateTime,
		/// <summary>
		///       去掉秒数的时间日期类型
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "DateTimeWithoutSecond")]
		DateTimeWithoutSecond,
		/// <summary>
		///       时间类型
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "Time")]
		Time,
		/// <summary>
		///       数值型
		///       </summary>
		[DCDescription(typeof(InputFieldEditStyle), "Numeric")]
		Numeric
	}
}
