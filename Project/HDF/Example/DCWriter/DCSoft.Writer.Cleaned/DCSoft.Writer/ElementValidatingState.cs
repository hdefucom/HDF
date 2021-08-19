using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer
{
	/// <summary>
	///       文档元素校验结果
	///       </summary>
	[Guid("867346C4-E109-4322-92EF-4ED2E454AF5A")]
	[ComVisible(true)]
	[DocumentComment]
	public enum ElementValidatingState
	{
		/// <summary>
		///       校验成功，无需进行后续的校验
		///       </summary>
		Success,
		/// <summary>
		///       校验通过，还需进行后续校验
		///       </summary>
		Pass,
		/// <summary>
		///       校验失败
		///       </summary>
		Fail
	}
}
