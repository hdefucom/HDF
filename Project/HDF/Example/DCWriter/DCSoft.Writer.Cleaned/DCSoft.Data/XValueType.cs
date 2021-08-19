using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       数据类型
	                                                                    ///       </summary>
	[ComVisible(false)]
	public enum XValueType
	{
		                                                                    /// <summary>
		                                                                    ///       字符串
		                                                                    ///       </summary>
		String,
		                                                                    /// <summary>
		                                                                    ///       空引用
		                                                                    ///       </summary>
		Null,
		                                                                    /// <summary>
		                                                                    ///       空数据
		                                                                    ///       </summary>
		DBNull,
		                                                                    /// <summary>
		                                                                    ///       字符数据
		                                                                    ///       </summary>
		Char,
		                                                                    /// <summary>
		                                                                    ///       布尔类型数据
		                                                                    ///       </summary>
		Boolean,
		                                                                    /// <summary>
		                                                                    ///       字节数据
		                                                                    ///       </summary>
		Byte,
		                                                                    /// <summary>
		                                                                    ///       时间日期数据
		                                                                    ///       </summary>
		DateTime,
		                                                                    /// <summary>
		                                                                    ///       定点数
		                                                                    ///       </summary>
		Decimal,
		                                                                    /// <summary>
		                                                                    ///       双精度浮点数
		                                                                    ///       </summary>
		Double,
		                                                                    /// <summary>
		                                                                    ///       16位整数
		                                                                    ///       </summary>
		Int16,
		                                                                    /// <summary>
		                                                                    ///       32位整数
		                                                                    ///       </summary>
		Int32,
		                                                                    /// <summary>
		                                                                    ///       64位整数
		                                                                    ///       </summary>
		Int64,
		                                                                    /// <summary>
		                                                                    ///       带符号字节数据
		                                                                    ///       </summary>
		SByte,
		                                                                    /// <summary>
		                                                                    ///       单精度浮点数
		                                                                    ///       </summary>
		Single,
		                                                                    /// <summary>
		                                                                    ///       16位无符号整数
		                                                                    ///       </summary>
		UInt16,
		                                                                    /// <summary>
		                                                                    ///       32位无符号整数
		                                                                    ///       </summary>
		UInt32,
		                                                                    /// <summary>
		                                                                    ///       64位无符号整数
		                                                                    ///       </summary>
		UInt64,
		                                                                    /// <summary>
		                                                                    ///       字节数据
		                                                                    ///       </summary>
		Binary,
		                                                                    /// <summary>
		                                                                    ///       大小
		                                                                    ///       </summary>
		Size,
		                                                                    /// <summary>
		                                                                    ///       浮点数大小
		                                                                    ///       </summary>
		SizeF,
		                                                                    /// <summary>
		                                                                    ///       坐标
		                                                                    ///       </summary>
		Point,
		                                                                    /// <summary>
		                                                                    ///       浮点数坐标
		                                                                    ///       </summary>
		PointF,
		                                                                    /// <summary>
		                                                                    ///       矩形
		                                                                    ///       </summary>
		Rectangle,
		                                                                    /// <summary>
		                                                                    ///       浮点数矩形
		                                                                    ///       </summary>
		RectangleF,
		                                                                    /// <summary>
		                                                                    ///       颜色
		                                                                    ///       </summary>
		Color,
		                                                                    /// <summary>
		                                                                    ///       字体对象
		                                                                    ///       </summary>
		Font,
		                                                                    /// <summary>
		                                                                    ///       未知的对象数据
		                                                                    ///       </summary>
		Object
	}
}
