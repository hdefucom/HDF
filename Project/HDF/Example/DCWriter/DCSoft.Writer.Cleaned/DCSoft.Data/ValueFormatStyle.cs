using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       数据源格式类型
	                                                                    ///       </summary>
	[Guid("1EA77249-70D2-4B6C-AB89-7ACE33B294B3")]
	[ComVisible(true)]
	public enum ValueFormatStyle
	{
		                                                                    /// <summary>
		                                                                    ///       无样式
		                                                                    ///       </summary>
		None,
		                                                                    /// <summary>
		                                                                    ///       数字
		                                                                    ///       </summary>
		Numeric,
		                                                                    /// <summary>
		                                                                    ///       货币
		                                                                    ///       </summary>
		Currency,
		                                                                    /// <summary>
		                                                                    ///       时间日期
		                                                                    ///       </summary>
		DateTime,
		                                                                    /// <summary>
		                                                                    ///       字符串
		                                                                    ///       </summary>
		String,
		                                                                    /// <summary>
		                                                                    ///       固定文本长度
		                                                                    ///       </summary>
		SpecifyLength,
		                                                                    /// <summary>
		                                                                    ///       布尔类型
		                                                                    ///       </summary>
		Boolean,
		                                                                    /// <summary>
		                                                                    ///       百分比
		                                                                    ///       </summary>
		Percent
	}
}
