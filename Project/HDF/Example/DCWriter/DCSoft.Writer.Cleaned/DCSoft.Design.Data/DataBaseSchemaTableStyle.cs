using System.Runtime.InteropServices;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       表类型
	///       </summary>
	[ComVisible(false)]
	public enum DataBaseSchemaTableStyle
	{
		/// <summary>
		///       系统表
		///       </summary>
		SystemTable,
		/// <summary>
		///       用户表
		///       </summary>
		UserTable,
		/// <summary>
		///       视图
		///       </summary>
		View
	}
}
