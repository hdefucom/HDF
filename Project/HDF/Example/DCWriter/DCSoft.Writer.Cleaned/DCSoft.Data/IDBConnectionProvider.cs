using DCSoft.Common;
using System.Data;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       数据库连接提供者对象
	                                                                    ///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public interface IDBConnectionProvider
	{
		                                                                    /// <summary>
		                                                                    ///       获得一个数据库连接对象
		                                                                    ///       </summary>
		                                                                    /// <returns>数据库连接对象</returns>
		IDbConnection GetConnection();

		                                                                    /// <summary>
		                                                                    ///       释放数据库连接对象
		                                                                    ///       </summary>
		                                                                    /// <param name="conn">数据库连接对象</param>
		void ReleaseConnection(IDbConnection conn);
	}
}
