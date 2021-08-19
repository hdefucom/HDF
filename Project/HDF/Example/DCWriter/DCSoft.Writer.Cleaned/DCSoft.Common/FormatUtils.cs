using System;
using System.Runtime.InteropServices;

namespace DCSoft.Common
{
	                                                                    /// <summary>
	                                                                    ///       内容格式化输出的函数集
	                                                                    ///       </summary>
	[ComVisible(false)]
	public static class FormatUtils
	{
		public const string Format_YYYYMMDDHHMM = "yyyy-MM-dd HH:mm";

		public static string ToYYYYMMDD(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyyMMdd");
		}

		public static string ToYYYY_MM_DD(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyy-MM-dd");
		}

		public static string ToYYYY_MM_DD_HH_MM_SS(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string ToYYYYMMDDHHMMSS(DateTime dateTime_0)
		{
			return dateTime_0.ToString("yyyyMMddHHmmss");
		}
	}
}
