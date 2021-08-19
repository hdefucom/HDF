using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       默认的时间日期服务器对象
	///       </summary>
	[DocumentComment]
	[ComDefaultInterface(typeof(IDateTimeService))]
	[ComVisible(false)]
	[DCInternal]
	public class DefaultDateTimeService : IDateTimeService
	{
		/// <summary>
		///       获得系统当前时间
		///       </summary>
		/// <returns>
		/// </returns>
		public DateTime GetNow()
		{
			return DateTime.Now;
		}
	}
}
