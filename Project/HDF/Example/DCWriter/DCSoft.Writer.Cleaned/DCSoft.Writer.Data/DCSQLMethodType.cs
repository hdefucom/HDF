using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Data
{
	/// <summary>
	///       SQL方法执行类型
	///       </summary>
	[DocumentComment]
	[ComVisible(false)]
	public enum DCSQLMethodType
	{
		/// <summary>
		///       自动检测
		///       </summary>
		AutoDetect,
		/// <summary>
		///       读取所有的数据
		///       </summary>
		ReadAllValues,
		/// <summary>
		///       执行SQL更新，返回修改的记录个数
		///       </summary>
		ExecuteNonQuery,
		/// <summary>
		///       批量执行SQL更新，返回修改的记录个数
		///       </summary>
		ExecuteNonQueryBatch,
		/// <summary>
		///       查询数据，获得第一个数值
		///       </summary>
		ExecuteScalar,
		/// <summary>
		///       查询数据，获得一个数据表
		///       </summary>
		ReadDataTable,
		/// <summary>
		///       查询数据，返回一个实体类型
		///       </summary>
		ReadSingInstance,
		/// <summary>
		///       查询数据，返回一个实体类型数组
		///       </summary>
		ReadInstanceArray
	}
}
