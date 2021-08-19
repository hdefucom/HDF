using DCSoft.Common;
using System.Runtime.InteropServices;

namespace DCSoft.Writer.Dom
{
	/// <summary>
	///       容器元素自动隐藏模式
	///       </summary>
	[ComVisible(true)]
	[DCPublishAPI]
	[Guid("E11C260F-BC7B-41A7-ACD8-8216AF0074AF")]
	[DocumentComment]
	public enum ContainerAutoHideMode
	{
		/// <summary>
		///       不做设置
		///       </summary>
		None,
		/// <summary>
		///       内容为空时自动隐藏
		///       </summary>
		HideWhenEmpty,
		/// <summary>
		///       子输入域内容为空时自动隐藏
		///       </summary>
		HideWhenChildFieldEmpty
	}
}
