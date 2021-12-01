using DCSoft.Common;
using System;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       时间日期服务器对象接口
	///       </summary>
	[DCInternal]
	[Obsolete("请使用WriterControl.SynchroServerTime()")]
	[ComVisible(false)]
	[Guid("00012345-6789-ABCD-EF01-23456789009C")]
	public interface IDateTimeService
	{
		/// <summary>
		///       获得当前时间
		///       </summary>
		/// <returns>
		/// </returns>
		DateTime GetNow();
	}
}
