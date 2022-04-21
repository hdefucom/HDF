using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       用户操作痕迹类型
	///       </summary>
	[Guid("BEC7CF45-F27F-45E0-8AD8-4CBBCE6EF3E2")]
	[ComVisible(true)]
	
	
	public enum UserTrackType
	{
		/// <summary>
		///       插入内容
		///       </summary>
		Create,
		/// <summary>
		///       删除内容
		///       </summary>
		Delete,
		/// <summary>
		///       添加批注
		///       </summary>
		Comment
	}
}
