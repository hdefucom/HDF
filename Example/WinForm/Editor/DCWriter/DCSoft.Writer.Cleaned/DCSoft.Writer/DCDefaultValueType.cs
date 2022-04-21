using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       默认值类型
	///       </summary>
	[Guid("C195EDF6-D57E-4ABC-BFA5-88FADBE56B2F")]
	
	
	[ComVisible(true)]
	public enum DCDefaultValueType
	{
		/// <summary>
		///       没有设置
		///       </summary>
		None,
		/// <summary>
		///       空白内容
		///       </summary>
		Empty,
		/// <summary>
		///       当前日期
		///       </summary>
		CurrentDate,
		/// <summary>
		///       当前时间
		///       </summary>
		CurrentTime,
		/// <summary>
		///       当前日期时间
		///       </summary>
		CurrentDateTime,
		/// <summary>
		///       当前用户号
		///       </summary>
		CurrnetUserID,
		/// <summary>
		///       当前用户名
		///       </summary>
		CurrentUserName
	}
}
