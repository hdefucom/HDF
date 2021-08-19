using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.FriedmanCurveChart
{
	/// <summary>
	///       编辑数据点模式
	///       </summary>
	[Guid("7D19F2F0-93AD-4EDC-806A-37E9BB8B0780")]
	[DocumentComment]
	[ComVisible(true)]
	public enum FCEditValuePointMode
	{
		/// <summary>
		///       新增数据点
		///       </summary>
		Insert,
		/// <summary>
		///       删除数据点
		///       </summary>
		Delete,
		/// <summary>
		///       修改数据点数值
		///       </summary>
		Update
	}
}
