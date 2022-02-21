using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       文档参数值类型
	///       </summary>
	
	[ComVisible(false)]
	public enum DocumentParameterValueType
	{
		/// <summary>
		///       纯文本
		///       </summary>
		Text,
		/// <summary>
		///       布尔类型值
		///       </summary>
		Boolean,
		/// <summary>
		///       数值
		///       </summary>
		Numeric,
		/// <summary>
		///       日期
		///       </summary>
		Date,
		/// <summary>
		///       时间
		///       </summary>
		Time,
		/// <summary>
		///       日期时间
		///       </summary>
		DateTime,
		/// <summary>
		///       二进制数据
		///       </summary>
		Binary,
		/// <summary>
		///       对象类型
		///       </summary>
		Object
	}
}
