using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       数据校验结果类型
	///       </summary>
	[DocumentComment]
	[ComVisible(true)]
	[Guid("789E846E-8985-4EDE-9FB3-85BE1E520697")]
	[DCPublishAPI]
	public enum ValueValidateResultTypes
	{
		/// <summary>
		///       数据校验
		///       </summary>
		ValueValidate,
		/// <summary>
		///       违禁关键字
		///       </summary>
		ExcludeKeyword
	}
}
