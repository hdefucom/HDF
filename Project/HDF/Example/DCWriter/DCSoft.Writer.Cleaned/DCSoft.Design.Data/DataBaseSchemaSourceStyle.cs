using System.Runtime.InteropServices;

namespace DCSoft.Design.Data
{
	/// <summary>
	///       数据模式来源类型
	///       </summary>
	/// <remarks>编制 袁永福</remarks>
	[ComVisible(false)]
	public enum DataBaseSchemaSourceStyle
	{
		/// <summary>
		///       未知样式
		///       </summary>
		Unknow,
		/// <summary>
		///       从PDM文件填充对象
		///       </summary>
		PDM,
		/// <summary>
		///       从Access2000数据库填充对象
		///       </summary>
		Access2000,
		/// <summary>
		///       从SQLSERVER数据库填充对象
		///       </summary>
		SQLServer,
		/// <summary>
		///       从ORACLE数据库填充对象
		///       </summary>
		Oracle,
		/// <summary>
		///       从MySQL数据库填充对象
		///       </summary>
		MySQL,
		/// <summary>
		///       从程序集中填充对象
		///       </summary>
		Assembly,
		/// <summary>
		///       源自DBaseIII数据库文件(*.pdf)
		///       </summary>
		DBaseIII
	}
}
