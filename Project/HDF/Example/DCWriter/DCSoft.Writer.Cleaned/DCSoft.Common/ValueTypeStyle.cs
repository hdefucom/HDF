using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       数据类型
	                                                                    ///       </summary>
	[Guid("00012345-6789-ABCD-EF01-234567890190")]
	[ComVisible(true)]
	public enum ValueTypeStyle
	{
		                                                                    /// <summary>
		                                                                    ///       文本
		                                                                    ///       </summary>
		Text,
		                                                                    /// <summary>
		                                                                    ///       整数
		                                                                    ///       </summary>
		Integer,
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
		                                                                    ///       正则表达式
		                                                                    ///       </summary>
		RegExpress
	}
}
