using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       合计函数类型
	                                                                    ///       </summary>
	[ComVisible(false)]
	public enum TotalFunctionStyle
	{
		                                                                    /// <summary>
		                                                                    ///       无样式
		                                                                    ///       </summary>
		None,
		                                                                    /// <summary>
		                                                                    ///       求和
		                                                                    ///       </summary>
		Sum,
		                                                                    /// <summary>
		                                                                    ///       记录个数
		                                                                    ///       </summary>
		Count,
		                                                                    /// <summary>
		                                                                    ///       求最大值
		                                                                    ///       </summary>
		Max,
		                                                                    /// <summary>
		                                                                    ///       求最小值
		                                                                    ///       </summary>
		Min,
		                                                                    /// <summary>
		                                                                    ///       求算术平均值
		                                                                    ///       </summary>
		Avg,
		                                                                    /// <summary>
		                                                                    ///       第一条数据
		                                                                    ///       </summary>
		First,
		                                                                    /// <summary>
		                                                                    ///       最后一条数据
		                                                                    ///       </summary>
		Last
	}
}
