using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法参数数据类型
	///       </summary>
	[ComVisible(false)]
	[DocumentComment]
	public enum DCSQLMethodParameterType
	{
		/// <summary>
		///       默认类型
		///       </summary>
		Default,
		/// <summary>
		///       布尔值
		///       </summary>
		Boolean,
		/// <summary>
		///       日期类型
		///       </summary>
		Date,
		/// <summary>
		///       整数
		///       </summary>
		Integer,
		/// <summary>
		///       单精度浮点数
		///       </summary>
		Single,
		/// <summary>
		///       双精度浮点数
		///       </summary>
		Double,
		/// <summary>
		///       长整型
		///       </summary>
		LongInteger,
		/// <summary>
		///       字符串
		///       </summary>
		String,
		/// <summary>
		///       超长字符串
		///       </summary>
		LongString
	}
}
