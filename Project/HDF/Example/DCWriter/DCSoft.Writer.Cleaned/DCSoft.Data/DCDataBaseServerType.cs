using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Data
{
	                                                                    /// <summary>
	                                                                    ///       可识别的数据库服务器类型
	                                                                    ///       </summary>
	[Guid("60EE6411-1492-4905-A53A-73BB29D4A317")]
	[ComVisible(true)]
	[DCPublishAPI]
	public enum DCDataBaseServerType
	{
		                                                                    /// <summary>
		                                                                    ///       尚未识别
		                                                                    ///       </summary>
		None,
		                                                                    /// <summary>
		                                                                    ///       无法识别的类型
		                                                                    ///       </summary>
		Invalidate,
		                                                                    /// <summary>
		                                                                    ///       MS ACCESS数据库
		                                                                    ///       </summary>
		Access,
		                                                                    /// <summary>
		                                                                    ///       MS SQL SERVER
		                                                                    ///       </summary>
		MSSQLServer,
		                                                                    /// <summary>
		                                                                    ///       Oracle
		                                                                    ///       </summary>
		Oracle,
		                                                                    /// <summary>
		                                                                    ///       DB2
		                                                                    ///       </summary>
		DB2,
		                                                                    /// <summary>
		                                                                    ///       MySQL
		                                                                    ///       </summary>
		MySQL
	}
}
